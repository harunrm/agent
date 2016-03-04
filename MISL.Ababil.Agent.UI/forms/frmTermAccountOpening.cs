using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using System.IO;
using System.Linq;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using MISL.Ababil.Agent.UI.forms.CommentUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.LocalStorageService;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;
using MISL.Ababil.Agent.Communication;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmTermAccountOpening : Form
    {

        private Packet _receivePacket;
        private GUI _gui = new GUI();

        private TermAccountRequestDto _termAccountRequestDto = new TermAccountRequestDto();
        private List<TermProductType> _itdProducts = new List<TermProductType>();
        private List<TermProductType> _mtdProducts = new List<TermProductType>();
        private List<SspInstallment> installments = new List<SspInstallment>();

        private int _updateNomineeIndex;
        private int _RowIndex;
        private List<CommentDto> _comments;
        private CommentDto _commentDraft;
        private ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();
        private NomineeInformationTemp _nomineeTemp = null;
        private IndividualServices _individualServices = new IndividualServices();
        private ConsumerServices _consumerServices = new ConsumerServices();
        private UtilityCom _utilityCom = new UtilityCom();

        public frmTermAccountOpening(Packet packet, TermAccountRequestDto termAccountRequestDto)
        {
            InitializeComponent();
            _receivePacket = packet;
            _termAccountRequestDto = termAccountRequestDto;
            preparedUI();
            FillComponentWithObjectValue();

            if (packet.DeveloperMode)
            {
                GUI.DeveloperMode.EnableDeveloperMode(this);
            }
        }

        private void preparedUI()
        {
            SetupDataLoad();
            SetupComponents();
        }

        private void SetupDataLoad()
        {
            _itdProducts = LocalCache.GetITDProducts();
            _mtdProducts = LocalCache.GetMTDProducts();
        }

        public void SetupComponents()
        {
            if (_termAccountRequestDto == null)
            {
                _termAccountRequestDto = new TermAccountRequestDto();
                _termAccountRequestDto.termAccountInformation = new TermAccountInformation();
                _termAccountRequestDto.termAccountInformation.termProductType = 0;
                _termAccountRequestDto.nominees = new List<NomineeInformationTemp>();
                // _termAccountRequestDto.commentDto = new CommentDto();
            }

            _gui = new GUI(this);
            //_gui.Config(ref txtOutletName);

            if (_termAccountRequestDto.termAccountInformation.accountStatus == TermAccountStatus.approved || _termAccountRequestDto.termAccountInformation.accountStatus == TermAccountStatus.canceled)
            {
                //general tab
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                {
                    cmbAccountType,
                    txtAccount,
                    cmbProducts,
                    txtSSPAccTitle,
                    cmbInstallmentSize,
                    txtAmount
                });
                ////

                //nominee tab
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                {
                    txtRelationship,
                    txtRatio,
                    txtInstruction,
                    txtIndividualId,
                    btview,
                    btnSearchIndividual,
                    btnBrowse,
                    btnCapture,
                    btnZoom,
                    btnAdd,
                });
                ////

                //general tab
                _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                {
                    btnClear,
                    btnSubmit,
                    btnReject,
                    btnApprove,
                    btnCorrection
                });
                ////

                gvNomineeDetail.Columns[0].Visible = false; //delete button
                btnNewIndividual.Text = "View";
            }
            else
            {
                if
                    (
                        SessionInfo.userBasicInformation.userType == AgentUserType.Outlet
                        &&
                        (
                            _termAccountRequestDto.termAccountInformation.accountStatus == TermAccountStatus.correction
                            ||
                            _termAccountRequestDto.termAccountInformation.accountStatus == TermAccountStatus.submitted
                        )
                   )
                {
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                    {
                        btnClear,
                        btnSubmit
                    });
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                    {
                        btnApprove,
                        btnReject,
                        btnCorrection
                    });
                }
                else if
                    (
                        SessionInfo.userBasicInformation.userType == AgentUserType.Outlet
                        &&
                        _termAccountRequestDto.termAccountInformation.accountStatus != TermAccountStatus.correction
                        &&
                        _termAccountRequestDto.termAccountInformation.accountStatus != TermAccountStatus.submitted
                    )
                {
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                    {
                        btnApprove,
                        btnReject,
                        btnCorrection
                    });
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                     {
                        btnSubmit,
                        btnClear
                    });
                }
                else
                {
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                    {
                        btnApprove,
                        btnReject,
                        btnCorrection
                    });

                    _gui.SetControlState(GUI.CONTROLSTATES.CS_ENABLE, new Control[]
                    {
                        btnApprove,
                        btnReject,
                        btnCorrection
                    });
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                    {
                        btnSubmit,
                        btnClear
                    });
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_READONLY, new Control[]
                    {
                        txtRelationship,
                        txtRatio,
                        txtInstruction,
                        txtIndividualId,
                        txtAccount,
                        txtSSPAccTitle,
                        txtAmount
                    });
                    _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                    {
                        cmbAccountType,
                        cmbProducts,
                        cmbInstallmentSize,
                        btnBrowse,
                        btnCapture,
                        btnAdd
                    });

                    gvNomineeDetail.Columns[0].Visible = false; //delete button
                    btnNewIndividual.Text = "View";
                }
            }
        }

        private void FillComponentWithObjectValue()
        {
            txtAccount.Text = _termAccountRequestDto.termAccountInformation.depositAccNum;
            lblCustomerName.Text = _termAccountRequestDto.termAccountInformation.depositAcctitle;
            txtAmount.Text = _termAccountRequestDto.termAccountInformation.amount.ToString();
            showConsumerInformation();
            switch (_termAccountRequestDto.termAccountInformation.accountType)
            {
                case AccountType.SSP:
                    cmbAccountType.SelectedIndex = 0;
                    BindingSource bsTermProductTmp = new BindingSource();
                    bsTermProductTmp.DataSource = _itdProducts;
                    cmbProducts.DataSource = bsTermProductTmp;
                    break;
                case AccountType.MTDR:
                    BindingSource bsMTDProductTmp = new BindingSource();
                    bsMTDProductTmp.DataSource = _mtdProducts;
                    cmbProducts.DataSource = bsMTDProductTmp;
                    cmbAccountType.SelectedIndex = 1;
                    break;
            }

            if (_termAccountRequestDto.termAccountInformation.termProductType != null)
            {
                cmbProducts.SelectedValue = _termAccountRequestDto.termAccountInformation.termProductType.Value;
            }

            txtSSPAccTitle.Text = _termAccountRequestDto.termAccountInformation.accTitle;


            if (cmbProducts.SelectedValue != null)
            {
                List<SspInstallment> sspInstallmentTmp = new List<SspInstallment>();
                if (_termAccountRequestDto.termAccountInformation.accountType == AccountType.SSP)
                {
                    sspInstallmentTmp = LocalCache.GetITDInstallment();
                    sspInstallmentTmp = sspInstallmentTmp.Where(sspInstallment => sspInstallment.sspProductType.id == (long)cmbProducts.SelectedValue).ToList().OrderBy(sspInstallment => sspInstallment.installAmount).ToList().Where(installmentSize => installmentSize.installAmount == _termAccountRequestDto.termAccountInformation.amount).ToList();
                    //_termAccountRequestDto.termAccountInformation.amount;
                    cmbInstallmentSize.SelectedItem = sspInstallmentTmp[0];
                }
            }

            fillNomineeList(_termAccountRequestDto.nominees);

            _comments = (List<CommentDto>)TermService.GetCommentsID((_termAccountRequestDto.termAccountInformation.commentId).ToString()).ReturnedObject;
            CommentText();
        }

        private void fillNomineeList(List<NomineeInformationTemp> nominees)
        {
            if (nominees != null && nominees.Count >= 0)
            {
                //if (nominees[nominees.Count - 1] != null)
                {
                    gvNomineeDetail.DataSource = null;
                    gvNomineeDetail.DataSource = nominees.Select
                        (o => new NomineesGrid(o)
                        {
                            Name = o.individualInformation.firstName + o.individualInformation.lastName,
                            Relation = o.relation,
                            Ratio = o.ratio.ToString()
                        }).ToList();
                }
            }
        }

        private void FillObjectWithComponentValue()
        {
            _termAccountRequestDto.termAccountInformation.depositAccNum = txtAccount.Text;
            _termAccountRequestDto.termAccountInformation.depositAcctitle = lblCustomerName.Text;

            if (cmbAccountType.SelectedIndex >= 0)
            {
                if (cmbAccountType.SelectedIndex == 0)
                {
                    _termAccountRequestDto.termAccountInformation.accountType = AccountType.SSP;
                }
                else if (cmbAccountType.SelectedIndex == 1)
                {
                    _termAccountRequestDto.termAccountInformation.accountType = AccountType.MTDR;
                }
            }
            else
            {
                _termAccountRequestDto.termAccountInformation.accountType = null;
            }

            if (cmbProducts.SelectedIndex >= 0)
            {
                if (cmbAccountType.SelectedIndex == 0)
                {
                    _termAccountRequestDto.termAccountInformation.termProductType = _itdProducts[cmbProducts.SelectedIndex].id;
                }
                else if (cmbAccountType.SelectedIndex == 1)
                {
                    _termAccountRequestDto.termAccountInformation.termProductType = _mtdProducts[cmbProducts.SelectedIndex].id;
                }
            }
            else
            {
                _termAccountRequestDto.termAccountInformation.termProductType = null;
            }
            _termAccountRequestDto.termAccountInformation.accTitle = txtSSPAccTitle.Text;
            if (cmbAccountType.SelectedIndex == 0)
            {
                if (cmbInstallmentSize.SelectedIndex >= 0)
                {
                    _termAccountRequestDto.termAccountInformation.amount = installments[cmbInstallmentSize.SelectedIndex].installAmount;
                }
            }
            else if (cmbAccountType.SelectedIndex == 1)
            {
                _termAccountRequestDto.termAccountInformation.amount = decimal.Parse(txtAmount.Text);
            }
        }

        private bool validationCheck()
        {
            if (string.IsNullOrEmpty(_termAccountRequestDto.termAccountInformation.depositAccNum))
            {
                Message.showWarning("Please provide link account!!");
                return false;
            }
            if (_termAccountRequestDto.termAccountInformation.accountType == null)
            {
                Message.showWarning("Account type cannot be left blank!!");
                return false;
            }
            if (_termAccountRequestDto.termAccountInformation.termProductType == null)
            {
                Message.showWarning("Product cannot be left blank!!");
                return false;
            }
            if (string.IsNullOrEmpty(_termAccountRequestDto.termAccountInformation.accTitle))
            {
                Message.showWarning("Account title cannot be left blank!!");
                return false;
            }
            if (_termAccountRequestDto.termAccountInformation.amount <= 0)
            {
                Message.showWarning("Instalment size cannot be left blank!!");
                return false;
            }
            if (_termAccountRequestDto.termAccountInformation.kycProfileNo <= 0 || _termAccountRequestDto.termAccountInformation.kycProfileNo == null)
            {
                Message.showWarning("KYC not found!!");
                return false;
            }
            if (_termAccountRequestDto.nominees.Count <= 0)
            {
                Message.showWarning("Nominee information not found!!");
                return false;
            }
            else
            {
                for (int i = 0; i < _termAccountRequestDto.nominees.Count; i++)
                {
                    if
                        (
                            _termAccountRequestDto.nominees[i].individualInformation.documentInfoId == null
                            ||
                            _termAccountRequestDto.nominees[i].individualInformation.documentInfoId == 0
                        )
                    {
                        Message.showWarning("Nominee document not found!!");
                        return false;
                    }
                }
            }
            if (_termAccountRequestDto.termAccountInformation.accountType == AccountType.MTDR)
            {
                if (!IsValidAmountForMTDR())
                {
                    Message.showWarning("Amount not valid for MTDR!!");
                    return false;
                }
            }

            return true;
        }

        private bool IsValidAmountForMTDR()
        {
            decimal amount = decimal.Parse(txtAmount.Text);
            if (amount % 5000 == 0)
            {
                return true;
            }
            return false;
        }

        public TermAccountRequestDto getFilledObject()
        {
            return _termAccountRequestDto;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillObjectWithComponentValue();

            if (validationCheck())
            {
                if (_receivePacket.intentType == IntentType.Request)
                {
                    this.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _gui.EmptyControls(new Control[]
            {
                txtIndividualId,
                lblIndividualName,
                lblFatherName,
                lblBirthDate,
                lblMobileNo,
                txtRelationship,
                txtInstruction,
                txtRatio
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-------------------------------------------------------------//
        //-------------------------------------------------------------//

        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindingSource bsTermProduct = new BindingSource();

            if (cmbAccountType.SelectedIndex == 0)
            {
                //_itdProducts
                if (_itdProducts.Count > 0)
                {
                    if (_itdProducts[0].productDescription != "(Select)")
                    {
                        TermProductType apSelect = new TermProductType();
                        apSelect.productDescription = "(Select)";
                        (_itdProducts).Insert(0, apSelect);
                    }
                    if (_itdProducts[1].productDescription == "(All)")
                    {
                        _itdProducts.RemoveAt(1);
                    }
                }
                bsTermProduct.DataSource = _itdProducts;
                txtAmount.Visible = false;
                txtMsg.Visible = false;
                cmbInstallmentSize.Visible = true;
                label6.Text = "Installment Size :";
            }
            else if (cmbAccountType.SelectedIndex == 1)
            {

                //_mtdProducts
                if (_mtdProducts.Count > 0)
                {
                    if (_mtdProducts[0].productDescription != "(Select)")
                    {
                        TermProductType apSelect = new TermProductType();
                        apSelect.productDescription = "(Select)";
                        (_mtdProducts).Insert(0, apSelect);
                    }
                    if (_mtdProducts[1].productDescription == "(All)")
                    {
                        _mtdProducts.RemoveAt(1);
                    }
                }
                bsTermProduct.DataSource = _mtdProducts;
                txtAmount.Visible = true;
                txtMsg.Visible = true;
                cmbInstallmentSize.Visible = false;
                label6.Text = "Amount :";
            }
            cmbProducts.DataSource = null;
            UtilityServices.fillComboBox(cmbProducts, bsTermProduct, "productDescription", "id");
            cmbProducts.SelectedIndex = -1;
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProducts.SelectedIndex < 1)
                    return;
                installments = LocalCache.GetITDInstallment();

                installments = installments.Where(sspInstallment => sspInstallment.sspProductType.id == (long)cmbProducts.SelectedValue).ToList().OrderBy(sspInstallment => sspInstallment.installAmount).ToList();

                BindingSource bs = new BindingSource();
                bs.DataSource = installments;
                cmbInstallmentSize.DataSource = null;
                cmbInstallmentSize.DataSource = bs;
                cmbInstallmentSize.ValueMember = "id";
                cmbInstallmentSize.DisplayMember = "installAmount";
            }
            catch
            {

            }
        }

        private void gvNomineeDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomineeServices objNomineeSerivices = new NomineeServices();
            try
            {
                _RowIndex = e.RowIndex;
                NomineeInformationTemp nominee = _termAccountRequestDto.nominees[_RowIndex];
                if (nominee.individualInformation != null)
                {
                    txtIndividualId.ReadOnly = true;
                    if (nominee.individualInformation.id != 0)
                        txtIndividualId.Text = nominee.individualInformation.id.ToString();
                    lblExistingIndividualName.Text = nominee.individualInformation.firstName + " " + nominee.individualInformation.lastName;
                }
                //txtInstruction.Text=nominee
                txtRelationship.Text = nominee.relation;
                txtRatio.Text = nominee.ratio.ToString();
                ImageConverter converter = new ImageConverter();
                pbImageNominee.Image = (nominee.photo != null) ? (Image)converter.ConvertFrom(nominee.photo) : null;
                txtInstruction.Text = nominee.instruction;
                if (gvNomineeDetail.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0) //delete
                    {
                        int rowIndex = e.RowIndex;
                        long nomineeId = _termAccountRequestDto.nominees[e.RowIndex].id;
                        string result = Message.showConfirmation("Are you sure to delete this nominee?");

                        if (result == "yes")
                        {
                            try
                            {
                                string deleteString = "";
                                if (nomineeId != 0)
                                {
                                    deleteString = objNomineeSerivices.deleteNomineeById(nomineeId);
                                }
                                _termAccountRequestDto.nominees.RemoveAt(rowIndex);
                                //Message.showInformation(deleteString);
                            }
                            catch (Exception ex)
                            {
                                Message.showError(ex.Message);
                            }
                            fillNomineeList(_termAccountRequestDto.nominees);
                        }

                    }
                    if (e.ColumnIndex == 1) //view
                    {
                        btnNewIndividual.Text = "Edit Individual";
                        {
                            btnNewIndividual.Enabled = true;
                        }
                        if (!UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
                        {
                            btnNewIndividual.Text = "View Individual";
                            btnNewIndividual.Enabled = true;
                        }
                        lblEditIndividualNotice.Text = "Click '" + btnNewIndividual.Text + "' button to view detail information of individual";
                        btnAdd.Text = "Update";

                        _updateNomineeIndex = e.RowIndex;
                        _nomineeTemp = _termAccountRequestDto.nominees[_updateNomineeIndex];

                        lblExistingIndividualName.Text = _nomineeTemp.individualInformation.firstName + " " + _nomineeTemp.individualInformation.lastName;
                        lblIndividualName.Text = _nomineeTemp.individualInformation.firstName + " " + _nomineeTemp.individualInformation.lastName;
                        lblFatherName.Text = _nomineeTemp.individualInformation.fatherFirstName;
                        lblBirthDate.Text = _nomineeTemp.individualInformation.dateOfBirthSt;
                        lblMobileNo.Text = _nomineeTemp.individualInformation.mobileNo;

                        if (_nomineeTemp.photo != null)
                        {
                            //byte[] bytes = _nomineeTemp.photo;
                            Image image = UtilityServices.byteArrayToImage(_nomineeTemp.photo);
                            pbImageNominee.Image = image;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            Packet packetTmp = new Packet();
            packetTmp.actionType = FormActionType.Edit;
            packetTmp.intentType = IntentType.Request;

            string stageTmp = "";
            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                stageTmp = "Submission";
            }
            else
            {
                stageTmp = "Approval";
            }

            if (_termAccountRequestDto != null)
            {
                if (_termAccountRequestDto != null)
                {
                    //if (_receivePacket.actionType != FormActionType.New)
                    {
                        if (_termAccountRequestDto.termAccountInformation != null)
                        {
                            if (_termAccountRequestDto.termAccountInformation.commentId != null
                                ||
                                _termAccountRequestDto.termAccountInformation.commentId != 0)
                            {
                                _comments = (List<CommentDto>)TermService.GetCommentsID((_termAccountRequestDto.termAccountInformation.commentId).ToString()).ReturnedObject;
                            }

                        }
                        frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                        frm.Top = this.Top + btnComments.Top - frm.Height + 40;
                        frm.Left = btnComments.Left + this.Left + 10;
                        frm.ShowDialog();
                        _commentDraft = frm._commentDraft;
                        CommentText();
                        return;
                    }
                }
            }

            if (_receivePacket.actionType == FormActionType.New)
            {
                frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                frm.Top = this.Top + btnComments.Top - frm.Height + 40;
                frm.Left = btnComments.Left + this.Left + 10;
                frm.ShowDialog();
                _commentDraft = frm._commentDraft;
                CommentText();
            }
        }

        private void CommentText()
        {
            int count = _comments.Count;
            if (_commentDraft != null)
            {
                count++;
                btnComments.BackColor = Color.LightGreen;
            }
            btnComments.Text = "Comment (" + count.ToString() + ")";
        }

        private void btnKYC_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.intentType = IntentType.SelfDriven;
            packet.actionType = _receivePacket.actionType;

            //frmKYC kycForm = new frmKYC(
            //    packet,
            //    _termAccountRequestDto.termAccountInformation.kycProfileNo,
            //    _consumerInformationDto.id.ToString(),
            //    _consumerInformationDto.consumerTitle
            //);

            //DialogResult kf = kycForm.ShowDialog();
            //if (kf == DialogResult.OK)
            //{
            //    _termAccountRequestDto.termAccountInformation.kycProfileNo = kycForm.getFilledObject();
            //}

            try
            {
                frmTPAndKYC tpkycForm = new frmTPAndKYC(false);
                tpkycForm._loadKYC(packet,
                                    _termAccountRequestDto.termAccountInformation.kycProfileNo,
                                    _consumerInformationDto.id.ToString(),
                                    _consumerInformationDto.consumerTitle);
                tpkycForm.tpAndKYC.TabPages.RemoveAt(0);

                DialogResult kf = tpkycForm.ShowDialog();
                if (kf == DialogResult.OK)
                {
                    _termAccountRequestDto.termAccountInformation.kycProfileNo = tpkycForm.getKycID();
                }
            }
            catch (Exception exp)
            { Message.showError(exp.Message); }
        }

        private void btnNewIndividual_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            //packet.DeveloperMode = true;

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                if (btnNewIndividual.Text == "New Idividual")
                {
                    packet.actionType = FormActionType.New;
                }
                else
                {
                    if (
                            _termAccountRequestDto.termAccountInformation.accountStatus != TermAccountStatus.approved
                                &&
                            _termAccountRequestDto.termAccountInformation.accountStatus != TermAccountStatus.canceled
                        )
                    {
                        packet.actionType = FormActionType.Edit;
                    }
                    else
                    {
                        packet.actionType = FormActionType.View;
                    }
                }
            }
            else
            {
                packet.actionType = FormActionType.View;
            }

            IndividualInformation individualInformation = null;

            if (_nomineeTemp != null)
            {
                individualInformation = _nomineeTemp.individualInformation;
            }
            else
            {
                //_nomineeTemp = new NomineeInformationTemp();
            }

            frmIndividualInformation frmindividualInformation = new frmIndividualInformation(packet, individualInformation);

            DialogResult dr = frmindividualInformation.ShowDialog();
            if (dr == DialogResult.OK)
            {
                individualInformation = frmindividualInformation.getFilledObject();
                lblExistingIndividualName.Text = individualInformation.firstName + " " + individualInformation.lastName;
                lblIndividualName.Text = individualInformation.firstName + " " + individualInformation.lastName;
                lblFatherName.Text = individualInformation.fatherFirstName;
                lblBirthDate.Text = individualInformation.dateOfBirthSt;
                lblMobileNo.Text = individualInformation.mobileNo;
                btnNewIndividual.Text = "Edit";

                if (_nomineeTemp == null)
                {
                    _nomineeTemp = new NomineeInformationTemp();
                }
                if (_nomineeTemp.individualInformation == null)
                {
                    _nomineeTemp.individualInformation = new IndividualInformation();
                }
                _nomineeTemp.individualInformation = individualInformation;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                UtilityServices.uploadPhoto(ref openFileDialog1, ref pbImageNominee);
            }
            catch (Exception)
            {
                throw new ApplicationException("Image loading error....");
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                frmWebCam webCam = new frmWebCam();
                DialogResult dr = webCam.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    ImageConverter converter = new ImageConverter();
                    Bitmap imgbitmap = (Bitmap)converter.ConvertFrom(webCam.getPhoto());
                    Image img = (Image)converter.ConvertFrom(webCam.getPhoto());
                    img = UtilityServices.getResizedImage(imgbitmap, CommonRules.imageSizeLimit, 100, "");
                    #region Image file length check
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (ms.Length > CommonRules.imageSizeLimit)
                    {
                        MessageBox.Show("Image file should be in " + CommonRules.imageSizeLimit / 1024 + " KB");
                        return;
                    }
                    #endregion
                    if (img != null)
                    {
                        pbImageNominee.Image = img;
                    }
                    else
                    {
                        Message.showError("Photo not taken.");
                    }
                }
            }
            catch (Exception ex)
            {
                Message.showError("Photo not taken.");
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (pbImageNominee.Image != null)
            {
                frmDocumentZoom frm = new frmDocumentZoom();
                frm.pictureZoomBox.Image = pbImageNominee.Image;
                frm.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnNewIndividual.Text = "New";

            byte[] nomineePhoto = UtilityServices.imageToByteArray(pbImageNominee.Image);

            if (nomineePhoto != null)
            {

                int ratio = (txtRatio.Text.Trim() != "") ? Convert.ToInt32(txtRatio.Text.Trim()) : 0;

                if (_nomineeTemp != null)
                {
                    _nomineeTemp.instruction = txtInstruction.Text;
                    _nomineeTemp.ratio = ratio;
                    _nomineeTemp.relation = txtRelationship.Text;
                    _nomineeTemp.photo = nomineePhoto;
                }
                if (_termAccountRequestDto.nominees == null)
                {
                    _termAccountRequestDto.nominees = new List<NomineeInformationTemp>();
                }
                //if (checkValidation(_nomineeTemp) && !string.IsNullOrEmpty(txtRelationship.Text) && !string.IsNullOrEmpty(txtInstruction.Text))
                if (checkValidationForUpdate(_nomineeTemp) && !string.IsNullOrEmpty(txtRelationship.Text) && !string.IsNullOrEmpty(txtInstruction.Text))
                {
                    if (btnAdd.Text == "Add")
                    {
                        if (checkValidationForUpdate(_nomineeTemp))
                        {
                            _termAccountRequestDto.nominees.Add(_nomineeTemp);
                            _nomineeTemp = null;
                        }
                    }
                    if (btnAdd.Text == "Update")
                    {
                        if (checkValidationForUpdate(_nomineeTemp))
                        {
                            _termAccountRequestDto.nominees[_updateNomineeIndex] = _nomineeTemp;
                            _nomineeTemp = null;
                        }
                    }

                    fillNomineeList(_termAccountRequestDto.nominees);
                    clearNomineeComponent();


                }
                else
                {
                    Message.showError("Nominee validation failed!");
                    return;
                }
            }
            else
            {
                Message.showError("Nominee photo not found!");
            }
        }

        private bool checkValidation(NomineeInformationTemp nominee)
        {
            if (!checkNomineeInfo(nominee))
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < gvNomineeDetail.Rows.Count; i++)
            {
                try
                {
                    sum += int.Parse(gvNomineeDetail.Rows[i].Cells[gvNomineeDetail.Columns.Count - 1].Value.ToString());
                }
                catch { }
            }

            if (sum + int.Parse(txtRatio.Text) > 100)
            {
                return false;
            }
            return true;
        }

        private bool checkValidationForUpdate(NomineeInformationTemp nominee)
        {
            if (!checkNomineeInfo(nominee))
            {
                return false;
            }
            if (int.Parse(txtRatio.Text) > 100)
            {
                return false;
            }
            return true;
        }

        private bool checkValidationForSubmit()
        {
            int sum = 0;
            for (int i = 0; i < gvNomineeDetail.Rows.Count; i++)
            {
                try
                {
                    sum += int.Parse(gvNomineeDetail.Rows[i].Cells[gvNomineeDetail.Columns.Count - 1].Value.ToString());
                }
                catch { }
            }

            if (sum != 100)
            {
                return false;
            }
            return true;
        }

        private bool checkNomineeInfo(NomineeInformationTemp nominee)
        {
            if (nominee == null)
            {
                Message.showError("Nominee Information not found!");
                return false;
            }

            if (nominee.individualInformation == null)
            {
                Message.showError("Individual Information not found.");
                return false;
            }
            else
            {
                if (nominee.individualInformation.documentInfoId == 0)
                {
                    Message.showError("Document Information for individual not found.");
                    return false;
                }
            }

            if (string.IsNullOrEmpty(lblIndividualName.Text))
            {
                Message.showError("Individual name not found!");
                return false;
            }

            if (string.IsNullOrEmpty(txtRelationship.Text))
            {
                Message.showError("Relationship not found!");
                return false;
            }
            if (string.IsNullOrEmpty(txtRatio.Text))
            {
                Message.showError("Ratio not found!");
                return false;
            }
            if (pbImageNominee.Image == null)
            {
                Message.showError("Nominee picture not found!");
                return false;
            }
            return true;
        }

        private void clearNomineeComponent()
        {
            txtIndividualId.Text = "";
            pbImageNominee.Image = null;
            txtInstruction.Text = "";
            txtRatio.Text = "";
            txtRelationship.Text = "";
            lblIndividualName.Text = "";
            lblFatherName.Text = "";
            lblBirthDate.Text = "";
            lblMobileNo.Text = "";
            _updateNomineeIndex = 0;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            btnApprove.Enabled = false;
            string result = Message.showConfirmation("Do you want to approve?");
            if (result == "yes")
            {
                ApplicationStatusChangeDto applicationStatusChangeDto = new ApplicationStatusChangeDto();
                applicationStatusChangeDto.applicationId = _termAccountRequestDto.termAccountInformation.id ?? 0;
                applicationStatusChangeDto.commentDto = _commentDraft;

                try
                {
                    ProgressUIManager.ShowProgress(this);
                    TermService.ChangeTermApplicationStatus(applicationStatusChangeDto, TermAccountStatus.approved);
                    ProgressUIManager.CloseProgress();
                    Message.showInformation("Approved Successfully!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                    ProgressUIManager.CloseProgress();
                }
            }
            btnApprove.Enabled = true;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            btnReject.Enabled = false;
            if (_commentDraft == null || string.IsNullOrWhiteSpace(_commentDraft.comment) == true)
            {
                Message.showError("Comment is required!");
                return;
            }

            btnCorrection.Enabled = false;
            string result = Message.showConfirmation("Do you want to reject?");
            if (result == "yes")
            {
                ApplicationStatusChangeDto applicationStatusChangeDto = new ApplicationStatusChangeDto();
                applicationStatusChangeDto.applicationId = _termAccountRequestDto.termAccountInformation.id ?? 0;
                applicationStatusChangeDto.commentDto = _commentDraft;

                try
                {
                    TermService.ChangeTermApplicationStatus(applicationStatusChangeDto, TermAccountStatus.canceled);
                    Message.showInformation("Application rejected!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }
            btnReject.Enabled = true;
        }

        private void btnCorrection_Click(object sender, EventArgs e)
        {
            if (_commentDraft == null || string.IsNullOrWhiteSpace(_commentDraft.comment) == true)
            {
                Message.showError("Comment is required!");
                return;
            }

            btnCorrection.Enabled = false;
            string result = Message.showConfirmation("Do you want to send for correctioin?");
            if (result == "yes")
            {
                ApplicationStatusChangeDto applicationStatusChangeDto = new ApplicationStatusChangeDto();
                applicationStatusChangeDto.applicationId = _termAccountRequestDto.termAccountInformation.id ?? 0;
                applicationStatusChangeDto.commentDto = _commentDraft;

                try
                {
                    TermService.ChangeTermApplicationStatus(applicationStatusChangeDto, TermAccountStatus.correction);
                    Message.showInformation("Sent back for correction!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }
            btnCorrection.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FillObjectWithComponentValue();

            if (validationCheck() && checkValidationForSubmit())
            {
                btnSubmit.Enabled = false;
                string result = Message.showConfirmation("Do you want to submit?");
                if (result == "yes")
                {
                    DocumentServices docServices = new DocumentServices();

                    for (int i = 0; i < _termAccountRequestDto.nominees.Count; i++)
                    {
                        if (docServices.isDocumentAvailable(_termAccountRequestDto.nominees[i].individualInformation.documentInfoId ?? 0))
                        {
                            if (_termAccountRequestDto.nominees[i].individualInformation.documentInfoId == 0 || _termAccountRequestDto.nominees[i].individualInformation.documentInfoId == null)
                            {
                                Message.showError("Document not found for nominee " + _termAccountRequestDto.nominees[i].individualInformation.firstName + " " + _termAccountRequestDto.nominees[i].individualInformation.lastName);
                                btnSubmit.Enabled = true;
                                return;
                            }
                        }
                        else
                        {
                            Message.showError("Document not found for nominee!");
                            btnSubmit.Enabled = true;
                            return;
                        }
                    }


                    //FillObjectWithComponentValue();                    
                    ProgressUIManager.ShowProgress(this);
                    ServiceResult serviceResult = TermService.SubmitTermDtoRequest(_termAccountRequestDto);
                    ProgressUIManager.CloseProgress();
                    if (serviceResult.Success)
                    {
                        //Message.showInformation(serviceResult.Message);
                        Message.showInformation("Saved Successfully. Reference No.: " + serviceResult.ReturnedObject.ToString());
                        frmShowReport objfrmShowReport = new frmShowReport();
                        if (_termAccountRequestDto.termAccountInformation.accountType == AccountType.SSP)
                        {
                            objfrmShowReport.SspPreAccountReport(serviceResult.ReturnedObject.ToString(), _termAccountRequestDto.termAccountInformation.accountType);
                        }
                        if (_termAccountRequestDto.termAccountInformation.accountType == AccountType.MTDR)
                        {
                            //objfrmShowReport.MTDReport(_termAccountRequestDto.termAccountInformation.referanceNumber);
                            objfrmShowReport.SspPreAccountReport(serviceResult.ReturnedObject.ToString(), _termAccountRequestDto.termAccountInformation.accountType);

                        }
                        Close();
                    }
                    else
                    {
                        Message.showError(serviceResult.Message);
                        //Message.showError("Invalid account number!");
                    }
                }
                btnSubmit.Enabled = true;
            }
            else
            {
                Message.showError("Validation Failed!");
            }
        }

        private void txtAccount_Leave(object sender, EventArgs e)
        {
            showConsumerInformation();
        }

        private void showConsumerInformation()
        {

            if (!ValidationManager.ValidateNonEmptyTextWithoutSpace(txtAccount.Text)) return;

            try
            {
                _consumerInformationDto = _consumerServices.getConsumerInformationDtoByAcc(txtAccount.Text.Trim());
                lblCustomerName.Text = _consumerInformationDto.consumerTitle;
                txtSSPAccTitle.Text = _consumerInformationDto.consumerTitle;

                if (_consumerInformationDto.photo != null)
                {
                    byte[] bytes = Convert.FromBase64String(_consumerInformationDto.photo);
                    Image image = UtilityServices.byteArrayToImage(bytes);
                    pbCustomerPhoto.Image = image;
                }
            }
            catch (Exception ex)
            {
                Message.showWarning(ex.Message);
            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            _nomineeTemp = null;
            clearNomineeComponent();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (((Control)sender).Text.IndexOf(".", 0) > -1)
                {
                    e.Handled = true;
                    return;
                }
            }
            if ((!char.IsNumber(e.KeyChar)) && ((Keys)e.KeyChar != Keys.Back) && ((Keys)e.KeyChar != Keys.OemPeriod) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmTermAccountOpening_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class NomineesGrid
    {
        public string Name { get; set; }
        public string Relation { get; set; }
        public string Ratio { get; set; }

        private NomineeInformationTemp _obj;

        public NomineesGrid(NomineeInformationTemp obj)
        {
            _obj = obj;
        }

        public NomineeInformationTemp GetModel()
        {
            return _obj;
        }
    }
}