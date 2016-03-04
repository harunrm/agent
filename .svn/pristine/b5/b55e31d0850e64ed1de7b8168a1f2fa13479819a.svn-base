using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
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

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmSSPAccountOpening : Form, IKycProfileUpdateObserver
    {
        int _RowIndex = -1;
        SspAccountInformation _sspAccountInformation;

        List<CommentDto> _commentsDraft = new List<CommentDto>();
        List<CommentDto> _comments = new List<CommentDto>();


        //List<CommentDto> CommentDto _commentDto = new CommentDto();
        //CommentDto _commentDto = new CommentDto();

        NomineeServices objNomineeSerivices = new NomineeServices();
        IndividualServices objIndividualServices = new IndividualServices();
        private List<NomineeInformation> nomineesInfo;
        private IndividualInformation individualNominee = new IndividualInformation();

        private long _kycProfileNo = 0L;
        private long _txnProfileNo = 0L;

        private readonly ConsumerServices _consumerService = new ConsumerServices();
        private ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();
        private List<SspProductType> _sspProducts = new List<SspProductType>();
        private List<SspInstallment> _sspInstallmentSizes = new List<SspInstallment>();
        private long _id;
        private string _referenceNumber = "";
        private string _subAgentUser = SessionInfo.username;
        private int _updateNomineeIndex;

        private const string Approval = "Approve";
        //private const string Resubmit = "Resubmit";

        public frmSSPAccountOpening()
        {
            InitializeComponent();
            ConfigureValidation();
            PopulateSspProducts();

            btnCorrection.Visible = false;
            btnCorrection.Enabled = false;
            btnReject.Visible = false;
            btnReject.Enabled = false;
            btnApprove.Visible = false;
            btnApprove.Enabled = false;

            lblRemarks.Visible = false;
            txtRemarks.Visible = false;
            txtRemarks.Enabled = false;
        }

        public frmSSPAccountOpening(long id)
        {

            InitializeComponent();
            ConfigureValidation();
            PopulateSspProducts();
            SspAccountInformation sspAccountInformation = SspService.GetSSPAccountInfoByID(id).ReturnedObject as SspAccountInformation;
            _id = id;
            _subAgentUser = sspAccountInformation.subAgentUser;


            if (sspAccountInformation == null)
                return;
            //FIX

            ShowSspInformation(sspAccountInformation);
            //
            if (UtilityServices.isRoleExist(Roles.adminOfficer) ||
                UtilityServices.isRoleExist(Roles.branchOfficer) ||
                UtilityServices.isRoleExist(Roles.fieldOfficer))
            {
                //btnSubmit.Text = Approval;
                btnSubmit.Enabled = false;

                btnCorrection.Visible = true;
                btnCorrection.Enabled = true;
                btnReject.Visible = true;
                btnReject.Enabled = true;
                btnApprove.Visible = true;
                btnApprove.Enabled = true;

                //lblSSPAccount.Visible = true;
                //txtSSPAccount.Visible = true;
                txtAccount.Enabled = false;
                txtSSPAccTitle.Enabled = false;
                cmbProducts.Enabled = false;
                cmbInstallmentSize.Enabled = false;


                //nominee tab
                txtIndividualId.ReadOnly = true;
                btnSearchIndividual.Enabled = false;
                btnNewIndividual.Enabled = false;
                txtInstruction.ReadOnly = true;
                txtRelationship.ReadOnly = true;
                txtRatio.ReadOnly = true;
                btnBrowse.Enabled = false;
                btnCapture.Enabled = false;
                btnAdd.Enabled = false;
                gvNomineeDetail.Columns[0].Visible = false;
                btnNewIndividual.Enabled = false;
                //

                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
                txtRemarks.Enabled = true;
            }
            else
            {
                //btnSubmit.Text = Resubmit;
                btnSubmit.Enabled = true;

                btnCorrection.Visible = false;
                btnCorrection.Enabled = false;
                btnReject.Visible = false;
                btnReject.Enabled = false;
                btnApprove.Visible = false;
                btnApprove.Enabled = false;
                gvNomineeDetail.Columns[0].Visible = false;
                btnNewIndividual.Enabled = false;

                if (sspAccountInformation.sspAccountStatus == SspAccountStatus.approved)
                {
                    btnCorrection.Enabled = false;
                    btnSubmit.Enabled = false;
                    btnReject.Enabled = false;
                    btnApprove.Enabled = false;
                    gvNomineeDetail.Columns[0].Visible = false;
                    btnNewIndividual.Enabled = false;
                }
            }
            if (sspAccountInformation.sspAccountStatus == SspAccountStatus.correction)
            {
                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
                txtRemarks.Enabled = false;
                gvNomineeDetail.Columns[0].Visible = false;
                btnNewIndividual.Enabled = false;
            }

            _referenceNumber = sspAccountInformation.referanceNumber;
            _kycProfileNo = (long)sspAccountInformation.kycProfileNo;
        }

        public frmSSPAccountOpening(SspAccountInformation sspAccountInformation)
        {
            InitializeComponent();
            ConfigureValidation();
            PopulateSspProducts();
            _id = sspAccountInformation.id;
            _subAgentUser = sspAccountInformation.subAgentUser;
            _referenceNumber = sspAccountInformation.referanceNumber;
            _kycProfileNo = (long)sspAccountInformation.kycProfileNo;
            _sspAccountInformation = sspAccountInformation;


            ShowSspInformation(sspAccountInformation);

            //customer photo
            try
            {
                ConsumerInformationDto consumerInfoDto = _consumerService.getConsumerInformationDtoByAcc(sspAccountInformation.depositAccNum);

                if (consumerInfoDto.photo != null)
                {
                    byte[] bytes = Convert.FromBase64String(consumerInfoDto.photo);
                    Image image = UtilityServices.byteArrayToImage(bytes);
                    pbCustomerPhoto.Image = image;
                }
            }
            catch (Exception ex)
            {
                Message.showWarning(ex.Message);
            }

            //Nominee
            SspAccountInformation sspAccInfoForNominee = SspService.GetSSPAccountInfoByID(sspAccountInformation.id).ReturnedObject as SspAccountInformation;
            nomineesInfo = sspAccInfoForNominee.nominees;
            if (nomineesInfo != null)
                if (nomineesInfo.Count > 0)
                    fillNomineeList(nomineesInfo);

            if (UtilityServices.isRoleExist(Roles.adminOfficer) ||
                UtilityServices.isRoleExist(Roles.branchOfficer) ||
                UtilityServices.isRoleExist(Roles.fieldOfficer))
            {
                //btnSubmit.Text = Approval;
                btnSubmit.Enabled = false;

                btnCorrection.Visible = true;
                btnCorrection.Enabled = true;
                btnReject.Visible = true;
                btnReject.Enabled = true;
                btnApprove.Visible = true;
                btnApprove.Enabled = true;
                gvNomineeDetail.Columns[0].Visible = false;
                btnNewIndividual.Enabled = false;

                //lblSSPAccount.Visible = true;
                //txtSSPAccount.Visible = true;
                txtAccount.Enabled = false;
                txtSSPAccTitle.Enabled = false;
                cmbProducts.Enabled = false;
                cmbInstallmentSize.Enabled = false;


                //nominee tab
                txtIndividualId.ReadOnly = true;
                btnSearchIndividual.Enabled = false;
                //btnNewIndividual.Enabled = false;
                txtInstruction.ReadOnly = true;
                txtRelationship.ReadOnly = true;
                txtRatio.ReadOnly = true;
                btnBrowse.Enabled = false;
                btnCapture.Enabled = false;
                btnAdd.Enabled = false;
                //

                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                txtRemarks.Enabled = false;
                if (sspAccountInformation.sspAccountStatus == SspAccountStatus.correction)
                {
                    lblRemarks.Visible = true;
                    txtRemarks.Visible = true;
                    txtRemarks.Enabled = true;
                    btnReject.Visible = false;
                    btnReject.Enabled = false;
                    btnApprove.Visible = false;
                    btnApprove.Enabled = false;
                    gvNomineeDetail.Columns[0].Visible = false;
                    btnNewIndividual.Enabled = false;
                }
            }
            else
            {
                //btnSubmit.Text = Resubmit;
                btnSubmit.Enabled = true;

                btnCorrection.Visible = false;
                btnCorrection.Enabled = false;
                btnReject.Visible = false;
                btnReject.Enabled = false;
                btnApprove.Visible = false;
                btnApprove.Enabled = false;

                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                txtRemarks.Enabled = false;
                //gvNomineeDetail.Columns[0].Visible = false;
                gvNomineeDetail.Columns[0].Visible = false;
                btnNewIndividual.Enabled = false;

                if (sspAccountInformation.sspAccountStatus == SspAccountStatus.correction)
                {
                    lblRemarks.Visible = true;
                    txtRemarks.Visible = true;
                    txtRemarks.Enabled = true;
                    gvNomineeDetail.Columns[0].Visible = false;
                    btnNewIndividual.Enabled = false;
                }
            }
            if (sspAccountInformation.sspAccountStatus == SspAccountStatus.approved || sspAccountInformation.sspAccountStatus == SspAccountStatus.canceled)
            {
                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
                txtRemarks.Enabled = false;
                btnCorrection.Enabled = false;
                btnSubmit.Enabled = false;
                btnReject.Enabled = false;
                btnApprove.Enabled = false;
                gvNomineeDetail.Columns[0].Visible = false;
                btnNewIndividual.Enabled = false;
            }


            if (
                    _sspAccountInformation.sspAccountStatus == SspAccountStatus.approved
                    ||
                    _sspAccountInformation.sspAccountStatus == SspAccountStatus.canceled
                    ||
                    _sspAccountInformation.sspAccountStatus == SspAccountStatus.submitted
                    )
            {
                btnSubmit.Enabled = false;
                txtAccount.Enabled = false;
                txtSSPAccTitle.Enabled = false;
                cmbProducts.Enabled = false;
                cmbInstallmentSize.Enabled = false;
                btnAdd.Enabled = false;
            }
        }

        private void ShowSspInformation(SspAccountInformation sspAccountInformation)
        {
            txtAccount.Text = sspAccountInformation.depositAccNum;
            txtSSPAccTitle.Text = sspAccountInformation.accTitle;
            lblCustomerName.Text = sspAccountInformation.depositAcctitle;
            //txtSSPAccount.Text = sspAccountInformation.sspAccNum;
            cmbProducts.SelectedValue = sspAccountInformation.sspProductType.id;
            cmbInstallmentSize.SelectedIndex = -1;
            long listCount = cmbInstallmentSize.Items.Count;
            for (int looper = 0; looper < listCount; looper++)
            {
                var installmentItem = cmbInstallmentSize.Items[looper];

                if (installmentItem is SspInstallment)
                {
                    var valueToValidate = (installmentItem as SspInstallment).installAmount.ToString(CultureInfo.InvariantCulture);
                    if (ValidationManager.ValidateDecimal(valueToValidate))
                    {
                        decimal value = decimal.Parse(valueToValidate);
                        if (value.Equals(sspAccountInformation.amount))
                        {
                            cmbInstallmentSize.SelectedIndex = looper;
                            break;
                        }
                    }
                }

            }

            //nominee            
            nomineesInfo = sspAccountInformation.nominees;
            ////////NomineeInformation nf = new NomineeInformation();
            ////////nf.id = 1;
            ////////nf.ratio = 12;
            ////////nf.individualInformation = new IndividualInformation();
            ////////nf.individualInformation.firstName = "asd";
            ////////nf.individualInformation.lastName = "asdasd";
            ////////nf.relation = "asd";
            ////////nomineesInfo.Add(nf);
            /// 
            if (nomineesInfo != null)
                if (nomineesInfo.Count > 0)
                    fillNomineeList(nomineesInfo);
            //

            txtRemarks.Text = sspAccountInformation.remarks;
        }


        private void PopulateSspProducts()
        {

            ServiceResult serviceResult = SspService.GetProductTypes();
            _sspProducts = serviceResult.ReturnedObject as List<SspProductType>;

            BindingSource bs = new BindingSource();
            bs.DataSource = _sspProducts;

            cmbProducts.DataSource = bs;
            cmbProducts.DisplayMember = "productDescription";
            cmbProducts.ValueMember = "id";
            cmbProducts.SelectedIndex = -1;

            if (!serviceResult.Success)
            {
                MessageBox.Show(serviceResult.Message);
            }
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtAccount, "Account",
                (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, cmbProducts, "Product",
                (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbInstallmentSize, "Installment Size",
                (long)ValidationType.ListSelected, true);
        }

        private void frmSSPAccountOpening_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

        private bool NomineeValidationCheck()
        {
            if (gvNomineeDetail.Rows.Count > 0)
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

                if (sum == 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool IsDocAvailable(ref SspAccountInformation sspAccountInformation)
        {
            try
            {
                for (int i = 0; i < sspAccountInformation.nominees.Count; i++)
                {
                    if (
                        sspAccountInformation.nominees[i].individualInformation.documentInfoId == 0
                            ||
                        sspAccountInformation.nominees[i].individualInformation.documentInfoId == null
                            )
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            string result = Message.showConfirmation("Do you want to submit?");
            if (result == "yes")
            {

                SspAccountInformation sspAccountInformation;
                if (!StoreSspAccountInformation(out sspAccountInformation))
                {
                    btnSubmit.Enabled = true;
                    return;
                }
                if (IsKYCAvailable(ref sspAccountInformation) == false)
                {
                    Message.showError("KYC Not found.");
                    //gui.RefreshOwnerForm();
                    btnSubmit.Enabled = true;
                    return;
                }
                if (!NomineeValidationCheck())
                {
                    Message.showError("Invalid nominee information!");
                    btnSubmit.Enabled = true;
                    return;
                }
                if (IsDocAvailable(ref sspAccountInformation) == false)
                {
                    Message.showError("Document Not found.");
                    //gui.RefreshOwnerForm();
                    btnSubmit.Enabled = true;
                    return;
                }

                //if (btnSubmit.Text.Equals(Approval))
                //{
                //    if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtSSPAccount.Text))
                //    {
                //        sspAccountInformation.sspAccNum = txtSSPAccount.Text;
                sspAccountInformation.sspAccountStatus = SspAccountStatus.submitted;
                sspAccountInformation.subAgentUser = _subAgentUser;
                sspAccountInformation.id = _id;
                sspAccountInformation.referanceNumber = _referenceNumber;
                //    }
                //    else
                //    {
                //        MessageBox.Show(StringTable.Please_provide_the_SSP_Account_Number_);
                //    }
                //}
                ///////////////////else if (btnSubmit.Text.Equals(Resubmit))//////////////////

                //if (btnSubmit.Text.Equals(Resubmit))
                //{
                //    if (!MessageBox.Show(StringTable.Are_you_sure_you_want_to_resubmit_,
                //        StringTable.frmSSPAccountOpening_btnSubmit_Click_Confirm_Resubmission,
                //        MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                //    {
                //        Close();
                //        btnSubmit.Enabled = true;
                //        return;
                //    }
                //}

                ProgressUIManager.ShowProgress(this);
                ServiceResult serviceResult = SspService.SubmitSspRequest(sspAccountInformation);
                ProgressUIManager.CloseProgress();

                if (serviceResult.Success)
                {
                    Message.showInformation(serviceResult.Message);
                    frmShowReport objfrmShowReport = new frmShowReport();
                    objfrmShowReport.SspPreAccountReport(serviceResult.ReturnedObject.ToString());
                    Close();
                }
                else
                {
                    MessageBox.Show(serviceResult.Message);
                }
            }
            btnSubmit.Enabled = true;
        }

        private bool IsKYCAvailable(ref SspAccountInformation sspAccountInformation)
        {
            if (sspAccountInformation.kycProfileNo == 0 || sspAccountInformation.kycProfileNo == null)
            {
                return false;
            }
            return true;
        }

        private bool StoreSspAccountInformation(out SspAccountInformation sspAccountInformation)
        {
            sspAccountInformation = new SspAccountInformation();

            if (!ValidationManager.ValidateForm(this)) return false;

            decimal amount;
            if (decimal.TryParse(cmbInstallmentSize.Text, out amount))
                sspAccountInformation.amount = amount;
            else
            {
                return false;
            }

            SspProductType productType = new SspProductType();

            long idValue;

            if (long.TryParse(cmbProducts.SelectedValue.ToString(), out idValue))
            {
                productType.id = idValue;
                productType.productDescription = cmbProducts.Text;
                sspAccountInformation.sspProductType = productType;
            }
            else
            {
                return false;
            }

            sspAccountInformation.depositAccNum = txtAccount.Text;
            sspAccountInformation.accTitle = txtSSPAccTitle.Text.Trim();
            sspAccountInformation.depositAcctitle = lblCustomerName.Text;
            if (_id > 0) sspAccountInformation.id = _id;
            sspAccountInformation.sspAccountStatus = SspAccountStatus.submitted;

            //
            sspAccountInformation.nominees = nomineesInfo;
            sspAccountInformation.kycProfileNo = _kycProfileNo;
            //
            return true;
        }

        private void txtAccount_Leave(object sender, EventArgs e)
        {
            if (!ValidationManager.ValidateNonEmptyTextWithoutSpace(txtAccount.Text)) return;

            try
            {
                _consumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtAccount.Text.Trim());
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

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateInstallmentSizes(cmbProducts.SelectedValue);
        }

        private void PopulateInstallmentSizes(object selectedValue)
        {
            if (selectedValue == null) return;
            if (!selectedValue.GetType().ToString().Equals("System.Int64")) return;

            ServiceResult serviceResult = SspService.GetInstallmentSizesByProductTypeId(selectedValue.ToString());
            _sspInstallmentSizes = serviceResult.ReturnedObject as List<SspInstallment>;

            BindingSource bs = new BindingSource();
            bs.DataSource = _sspInstallmentSizes;

            cmbInstallmentSize.DataSource = bs;
            cmbInstallmentSize.DisplayMember = "installAmount";
            cmbInstallmentSize.ValueMember = "id";
            cmbInstallmentSize.SelectedIndex = -1;

            if (!serviceResult.Success)
            {
                MessageBox.Show(serviceResult.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearchIndividual_Click(object sender, EventArgs e)
        {
            showDataFromIndividualId();
        }

        private void showDataFromIndividualId()
        {
            if (txtIndividualId.Text.Trim() != "")
            {
                try
                {
                    int individualId = Convert.ToInt32(txtIndividualId.Text.Trim());
                    individualNominee = objIndividualServices.GetIndividualInfo(individualId);
                    if (individualNominee == null)
                    {
                        lblExistingIndividualName.Text = "";
                        Message.showInformation("Individual not found");
                    }
                    else
                    {
                        lblExistingIndividualName.Text = individualNominee.firstName + " " + individualNominee.lastName;

                        //byte[] bytes = individualNominee.documentData;
                        //ImageConverter converter = new ImageConverter();
                        //pictureBox1.Image = (Image)converter.ConvertFrom(bytes);
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }

            }
            else
                Message.showError("Individual Id not found");
        }

        private void btnNewIndividual_Click(object sender, EventArgs e)
        {
            frmIndividualInformation objFrmIndividualInfo = new frmIndividualInformation();
            IndividualInformation individualForForm = new IndividualInformation();
            if (btnNewIndividual.Text == "Edit Individual" || btnNewIndividual.Text == "View Individual")
                individualForForm = individualNominee;
            if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            {
                if (_sspAccountInformation != null)
                {
                    if (
                    _sspAccountInformation.sspAccountStatus == SspAccountStatus.approved
                    ||
                    _sspAccountInformation.sspAccountStatus == SspAccountStatus.canceled
                    ||
                    _sspAccountInformation.sspAccountStatus == SspAccountStatus.submitted
                    )
                    {
                        objFrmIndividualInfo = new frmIndividualInformation(individualForForm, ActionType.view);
                    }
                    else
                    {
                        objFrmIndividualInfo = new frmIndividualInformation(individualForForm, ActionType.update);
                    }
                }
                else
                {
                    objFrmIndividualInfo = new frmIndividualInformation(individualForForm, ActionType.update);
                }
            }
            else
                objFrmIndividualInfo = new frmIndividualInformation(individualForForm, ActionType.view);
            DialogResult dr = objFrmIndividualInfo.ShowDialog();
            if (dr == DialogResult.OK)
            {
                individualNominee = objFrmIndividualInfo.getIndividualForDilogResult();
                lblExistingIndividualName.Text = individualNominee.firstName + " " + individualNominee.lastName;
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

        private bool checkNomineeInfo(NomineeInformation nominee)
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
                ////if (nominee.individualInformation.documentInfoId == 0)
                ////{
                ////    Message.showError("Document Information for individual not found.");
                ////    return false;
                ////}
            }

            if (string.IsNullOrEmpty(lblExistingIndividualName.Text))
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

        private bool checkValidation(NomineeInformation nominee)
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

        private bool checkValidationForUpdate(NomineeInformation nominee)
        {
            if (!checkNomineeInfo(nominee))
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < gvNomineeDetail.Rows.Count; i++)
            {
                if (i != _RowIndex)
                {
                    try
                    {
                        sum += int.Parse(gvNomineeDetail.Rows[i].Cells[gvNomineeDetail.Columns.Count - 1].Value.ToString());
                    }
                    catch { }
                }
            }

            if (sum + int.Parse(txtRatio.Text) > 100)
            {
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            byte[] nomineePhoto = UtilityServices.imageToByteArray(pbImageNominee.Image);
            int ratio = (txtRatio.Text.Trim() != "") ? Convert.ToInt32(txtRatio.Text.Trim()) : 0;


            //NomineeInformation nominee = UtilityServices.genNomineeInformation(0, individualNominee, null, null, txtRelationship.Text.Trim(), ratio, nomineePhoto, txtInstruction.Text.Trim());
            NomineeInformation nominee;

            if (nomineesInfo == null)
            {
                nominee = UtilityServices.genNomineeInformation(0, individualNominee, null, null, txtRelationship.Text.Trim(), ratio, nomineePhoto, txtInstruction.Text.Trim());
                nomineesInfo = new List<NomineeInformation>();
            }
            else
            {
                nominee = UtilityServices.genNomineeInformation(nomineesInfo[_updateNomineeIndex].id, individualNominee, null, null, txtRelationship.Text.Trim(), ratio, nomineePhoto, txtInstruction.Text.Trim());
                //nomineeValidation(nominee);
            }

            {

                if (btnAdd.Text == "Add")
                {
                    if (checkValidation(nominee))
                    {
                        //if (nominee != null && !string.IsNullOrEmpty(txtRelationship.Text) && !string.IsNullOrEmpty(txtRatio.Text) && !string.IsNullOrEmpty(lblExistingIndividualName.Text))
                        //{
                        nomineesInfo.Add(nominee);
                        fillNomineeList(nomineesInfo);
                        clearNomineesData();
                        lblEditIndividualNotice.Text = "";
                        //}
                        //else
                        //{
                        //    Message.showError("Validation error!");
                        //    return;
                        //}
                    }
                    else
                    {
                        //Message.showError("Invalid ratio!");
                    }
                }
                else
                {
                    //SetAutoScrollMargin nominees' ids
                    {
                        //nominee                        
                    }
                    if (checkValidationForUpdate(nominee))
                    {
                        if (nominee != null && !string.IsNullOrEmpty(txtRelationship.Text) && !string.IsNullOrEmpty(txtRatio.Text) && !string.IsNullOrEmpty(lblExistingIndividualName.Text))
                        {
                            nomineesInfo[_updateNomineeIndex] = nominee;
                            fillNomineeList(nomineesInfo);
                            clearNomineesData();
                            btnNewIndividual.Text = "New Individual";
                            btnAdd.Text = "Add";
                            //txtIndividualId.ReadOnly = false;
                            lblEditIndividualNotice.Text = "";
                        }
                        else
                        {
                            //Message.showError("Validation error!");
                            //return;
                        }
                    }
                    else
                    {
                        //Message.showError("Invalid ratio!");
                    }
                }
            }

        }

        private bool nomineeValidation(NomineeInformation nominee)
        {

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



            /*
            if (nominee.individualInformation == null)
            {
                MessageBox.Show("Individual not found");
                return false;
            }

            if (nominee.photo == null)
            {
                MessageBox.Show("Nominee photo not found");
                return false;
            }
            if (nominee.ratio == 0)
            {
                MessageBox.Show("Nominee share not found");
                return false;
            }
            long usedRatio = 0;
            foreach (NomineeInformation eachNominee in nomineesInfo)
            {
                //usedRatio += eachNominee.ratio;
                //if (btnAdd.Text == "Update")
                //    usedRatio = usedRatio - nomineesInfo[_updateNomineeIndex].ratio;
            }
            if (nominee.ratio > (100 - usedRatio))
            {
                //MessageBox.Show("Total share cannot exceed 100%.");
                //return false;
            }
            if (nominee.relation == "")
            {
                MessageBox.Show("Nominee relation not found");
                return false;
            }*/


            return true;
        }

        private void fillNomineeList(List<NomineeInformation> nomineeList)
        {
            if (nomineeList != null)
            {
                gvNomineeDetail.DataSource = null;
                gvNomineeDetail.DataSource =
                    nomineeList.Select(
                        o =>
                            new NomineesGrid(o)
                            {
                                Name = o.individualInformation.firstName + o.individualInformation.lastName,
                                Relation = o.relation,
                                Ratio = o.ratio.ToString()
                            }).ToList();
            }
        }

        private void clearNomineesData()
        {
            txtIndividualId.Text = string.Empty;
            lblExistingIndividualName.Text = string.Empty;
            txtInstruction.Text = string.Empty;
            txtRelationship.Text = string.Empty;
            txtRatio.Text = string.Empty;
            pbImageNominee.Image = null;
            individualNominee = null;
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
                        MessageBox.Show("Image file should be in " + CommonRules.imageSizeLimit / 1000 + " KB");
                        return;
                    }
                    #endregion
                    if (img != null)
                        pbImageNominee.Image = img;
                    else MessageBox.Show("Photo not taken.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Photo not taken.");
            }
        }

        private void gvNomineeDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NomineeInformation nominee = nomineesInfo[e.RowIndex];
                _RowIndex = e.RowIndex;
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
                        long nomineeId = nomineesInfo[e.RowIndex].id;
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
                                nomineesInfo.RemoveAt(rowIndex);
                                //Message.showInformation(deleteString);
                            }
                            catch (Exception ex)
                            {
                                Message.showError(ex.Message);
                            }
                        }
                        fillNomineeList(nomineesInfo);
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
                        individualNominee = nomineesInfo[_updateNomineeIndex].individualInformation;

                        //IndividualInformation objIndiInfo = nomineesInfo[e.RowIndex].individualInformation;
                        //frmIndividualInformation objFrmIndividualInfo = null;
                        ////if (UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
                        //if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
                        //    objFrmIndividualInfo = new frmIndividualInformation(objIndiInfo, ActionType.update);
                        //else
                        //    objFrmIndividualInfo = new frmIndividualInformation(objIndiInfo, ActionType.view);
                        //DialogResult dr = objFrmIndividualInfo.ShowDialog();
                        //if (dr == DialogResult.OK)
                        //{
                        //    //OwnerInformation objOwnerInfo = new OwnerInformation();
                        //    //int ownerTypeId = (cmbOwnerType.SelectedValue != "") ? Convert.ToInt32(cmbOwnerType.SelectedValue) : 0;
                        //    //objOwnerInfo.ownerType = objOwnerInfoList[e.RowIndex].ownerType;
                        //    objIndiInfo = objFrmIndividualInfo.getIndividualForDilogResult();
                        //    nomineesInfo[e.RowIndex].individualInformation = objIndiInfo;
                        //    if (nomineesInfo == null) { nomineesInfo = new List<NomineeInformation>(); }
                        //    fillNomineeList(nomineesInfo);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void frmSSPAccountOpening_Load(object sender, EventArgs e)
        {
            //____until NOMINEE is fixed____//////////////////////////
            //this.Height = 321;
            //TabControl tc = new TabControl();
            //tc.TabPages.Add(tabPage2);
            //tabControl1.TabPages.Remove(tabPage2);
            //btnReject.Visible = false;
            //btnApprove.Visible = false;
            //////////////////////////////////////////////////////////
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            btnApprove.Enabled = false;
            string result = Message.showConfirmation("Do you want to approve?");
            if (result == "yes")
            {
                SspAccountInformation sspAccountInformation;
                if (!StoreSspAccountInformation(out sspAccountInformation))
                {
                    btnApprove.Enabled = true;
                    return;
                }

                //if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtSSPAccount.Text))
                //{
                //sspAccountInformation.sspAccNum = txtSSPAccount.Text;
                sspAccountInformation.sspAccountStatus = SspAccountStatus.approved;
                sspAccountInformation.subAgentUser = _subAgentUser;
                sspAccountInformation.id = _id;
                sspAccountInformation.referanceNumber = _referenceNumber;
                sspAccountInformation.kycProfileNo = _kycProfileNo;
                //}
                //else
                //{
                //    MessageBox.Show(StringTable.Please_provide_the_SSP_Account_Number_);
                //}

                ProgressUIManager.ShowProgress(this);
                ServiceResult serviceResult = SspService.ApproveSSPRequest(sspAccountInformation);
                ProgressUIManager.CloseProgress();

                if (serviceResult.Success)
                {
                    MessageBox.Show(serviceResult.Message);
                    //frmShowReport objfrmShowReport = new frmShowReport();
                    //objfrmShowReport.SSPApproveAccountReport(sspAccountInformation.referanceNumber);
                    Close();
                }
                else
                {
                    MessageBox.Show(serviceResult.Message);
                }
            }
            btnApprove.Enabled = true;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            btnReject.Enabled = false;
            string result = Message.showConfirmation("Do you want to reject?");
            if (result == "yes")
            {
                string remarksFromMsgBox = InputDialog.Show("Remarks");
                do
                {
                    if (remarksFromMsgBox != null && remarksFromMsgBox.Count() == 0)
                    {
                        Message.showError("Please enter remarks.");
                        remarksFromMsgBox = InputDialog.Show("Remarks");
                    }
                }
                while ((remarksFromMsgBox != null && remarksFromMsgBox.Count() == 0));
                SspAccountInformation sspAccountInformation;
                if (!StoreSspAccountInformation(out sspAccountInformation))
                {
                    btnReject.Enabled = true;
                    return;
                }

                if (remarksFromMsgBox == "" || remarksFromMsgBox == null)
                {
                    if (remarksFromMsgBox == "") //null means cancel, "" means ok
                        Message.showError("Please provide remarks before reject.");
                }
                else
                {
                    //if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtSSPAccount.Text))
                    //{
                    //sspAccountInformation.sspAccNum = txtSSPAccount.Text;
                    sspAccountInformation.sspAccountStatus = SspAccountStatus.canceled; //reject
                    sspAccountInformation.subAgentUser = _subAgentUser;
                    sspAccountInformation.id = _id;
                    sspAccountInformation.referanceNumber = _referenceNumber;
                    sspAccountInformation.remarks = remarksFromMsgBox;//txtRemarks.Text.Trim();
                                                                      //}
                                                                      //else
                                                                      //{
                                                                      //    MessageBox.Show(StringTable.Please_provide_the_SSP_Account_Number_);
                                                                      //}

                    ProgressUIManager.ShowProgress(this);
                    ServiceResult serviceResult = SspService.RejectSSPRequest(sspAccountInformation);
                    ProgressUIManager.CloseProgress();

                    if (serviceResult.Success)
                    {
                        MessageBox.Show(serviceResult.Message);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(serviceResult.Message);
                    }
                }
            }
            btnReject.Enabled = true;
        }

        private void txtRatio_Leave(object sender, EventArgs e)
        {
            try
            {
                int nRatio = (txtRatio.Text.Trim() != "") ? Convert.ToInt32(txtRatio.Text.Trim()) : 0;
                if (nRatio > CommonRules.nomineeMaxRatio)
                {
                    MessageBox.Show("Ratio cannot be more than" + CommonRules.nomineeMaxRatio);
                    txtRatio.Focus();
                }
            }
            catch { }
        }
        public void ProfileUpdated(KycProfile profile)
        {
            _kycProfileNo = profile.id;
            //lblKycId.Text = _kycProfileNo.ToString();
        }
        private void btnKYC_Click(object sender, EventArgs e)
        {
            if (_sspAccountInformation != null)
            {
                if (_sspAccountInformation.sspAccountStatus == SspAccountStatus.correction)
                {
                    frmKYC kycForm = new frmKYC();
                    kycForm.RegisterProfileUpdateObserver(this);
                    kycForm.SetProfileData(_kycProfileNo, _consumerInformationDto.id.ToString(), _consumerInformationDto.consumerTitle, "");
                    kycForm.Show();
                }
                else
                {
                    frmKYC kycForm = new frmKYC();
                    kycForm._viewMode = true;
                    kycForm.RegisterProfileUpdateObserver(this);
                    kycForm.SetProfileData(_kycProfileNo, _consumerInformationDto.id.ToString(), _consumerInformationDto.consumerTitle, "");
                    kycForm.Show();
                }
            }
            else
            {
                frmKYC kycForm = new frmKYC();
                kycForm._viewMode = false;
                kycForm.RegisterProfileUpdateObserver(this);
                kycForm.SetProfileData(_kycProfileNo, _consumerInformationDto.id.ToString(), _consumerInformationDto.consumerTitle, "");
                kycForm.Show();
            }
        }

        private void btnCorrection_Click(object sender, EventArgs e)
        {
            btnCorrection.Enabled = false;
            string result = Message.showConfirmation("Do you want to send for correctioin?");
            if (result == "yes")
            {
                string remarksFromMsgBox = InputDialog.Show("Remarks");
                do
                {
                    if (remarksFromMsgBox != null && remarksFromMsgBox.Count() == 0)
                    {
                        Message.showError("Please enter remarks.");
                        remarksFromMsgBox = InputDialog.Show("Remarks");
                    }
                }
                while ((remarksFromMsgBox != null && remarksFromMsgBox.Count() == 0));
                SspAccountInformation sspAccountInformation;
                if (!StoreSspAccountInformation(out sspAccountInformation))
                {
                    btnCorrection.Enabled = true;
                    return;
                }
                if (remarksFromMsgBox == "" || remarksFromMsgBox == null)
                {
                    if (remarksFromMsgBox == "") //null means cancel, "" means ok
                        Message.showError("Please provide remarks before send back for correction.");
                }
                else
                {
                    //if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtSSPAccount.Text))
                    //{
                    //sspAccountInformation.sspAccNum = txtSSPAccount.Text;
                    sspAccountInformation.sspAccountStatus = SspAccountStatus.correction;
                    sspAccountInformation.subAgentUser = _subAgentUser;
                    sspAccountInformation.id = _id;
                    sspAccountInformation.referanceNumber = _referenceNumber;
                    sspAccountInformation.remarks = remarksFromMsgBox;//txtRemarks.Text.Trim();
                                                                      //}
                                                                      //else
                                                                      //{
                                                                      //    MessageBox.Show(StringTable.Please_provide_the_SSP_Account_Number_);
                                                                      //}
                    ProgressUIManager.ShowProgress(this);
                    ServiceResult serviceResult = SspService.CorrectionSSPRequest(sspAccountInformation);
                    ProgressUIManager.CloseProgress();

                    if (serviceResult.Success)
                    {
                        MessageBox.Show(serviceResult.Message);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(serviceResult.Message);
                    }
                }
            }
            btnCorrection.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIndividualId.Text = "";
            //txtIndividualId.ReadOnly = false;
            individualNominee = null;
            lblExistingIndividualName.Text = "";
            txtInstruction.Text = "";
            txtRelationship.Text = "";
            txtRatio.Text = "";
            pbImageNominee.Image = null;
            btnNewIndividual.Text = "New Individual";
            btnAdd.Text = "Add";
            lblEditIndividualNotice.Text = "";
        }

        private void txtRatio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back) //&& e.KeyChar != '.'
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void gvNomineeDetail_SelectionChanged(object sender, EventArgs e)
        {

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

        private void btnComments_Click(object sender, EventArgs e)
        {
            //temp
            {
                _comments = new List<CommentDto>();
                {
                    CommentDto commentDto = new CommentDto();
                    commentDto.comment = "asd1";
                    commentDto.commentUser = "asd1";
                    commentDto.stage = "asd1";
                    _comments.Add(commentDto);
                }
                {
                    CommentDto commentDto = new CommentDto();
                    commentDto.comment = "asd2";
                    commentDto.commentUser = "asd2";
                    commentDto.stage = "asd2";
                    _comments.Add(commentDto);
                }
            }
            frmCommentUI frm = new frmCommentUI(_commentsDraft, _comments);
            frm.ShowDialog();
            _commentsDraft = frm._commentsDraft;            
        }
    }
}