using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;
using MISL.Ababil.Agent.UI.forms.CommentUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmConsumerCreation : Form, IKycProfileUpdateObserver, ITransactionProfileUpdateObserver
    {
        private GUI _gui = new GUI();
        private Packet _receivePacket;
        private CustomerServices _objCustomerServices = new CustomerServices();
        private ConsumerServices _objConsumerServices = new ConsumerServices();
        private NomineeServices _objNomineeSerivices = new NomineeServices();
        private IndividualServices _objIndividualServices = new IndividualServices();
        private CustomerDto _objCustomer = new CustomerDto();
        private ConsumerApplication _consumerApp = new ConsumerApplication();
        private CustomerInformation _objCustomerInfoForConsumer = new CustomerInformation();
        private List<NomineeInformationTemp> _nomineesInfo;
        private IndividualInformation _individualNominee = new IndividualInformation();
        private NomineeInformationTemp _nomineeTemp;
        private List<CommentDto> _comments;
        private CommentDto _commentDraft;

        public Dictionary<string, Address> _addresses = new Dictionary<string, Address>();

        private int _updateNomineeIndex;
        private int _RowIndex = -1;
        private long _txnProfileNo = 0;
        private long? _kycProfileNo;
        private List<NomineeRelationship> _nomineeRelationships;

        public frmConsumerCreation(Packet packet, ConsumerApplication consumerApp)
        {
            InitializeComponent();
            _receivePacket = packet;
            _consumerApp = consumerApp;
            _nomineesInfo = consumerApp.nominees;
            InitialSetup();

            //if (_receivePacket.DeveloperMode == true)
            //{
            //    GUI.DeveloperMode.EnableDeveloperMode(this);
            //}
        }

        private void InitialSetup()
        {
            SetupDataLoad();
            SetupComponents();
            FillComponentWithObjectValue();
        }

        private void SetupDataLoad()
        {
            LoadDataFromStringTable();

            txtMobileNo.MaxLength = CommonRules.mobileNoLength;
            UtilityServices.commonAddresses = new List<Address>();
            loadAllAddresses();
            addEditButtons();
            if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            {
                if (_consumerApp.applicationStatus != ApplicationStatus.approved)
                {
                    addDeleteButtons();
                }
            }

            _nomineeRelationships = UtilityServices.GetAllRelationships();
        }

        public void SetupComponents()
        {
            _gui = new GUI(this);
            //_gui.Config(ref txtOutletName);    

            BindingSource bsRelations = new BindingSource();
            bsRelations.DataSource = _nomineeRelationships;
            UtilityServices.fillComboBox(cmbRelationship, bsRelations, "relation", "id");
            cmbRelationship.SelectedIndex = -1;
            cmbRelationship.Text = "";

            if
                (
                    _consumerApp.applicationStatus == ApplicationStatus.approved
                    ||
                    _consumerApp.applicationStatus == ApplicationStatus.canceled
                )
            {
                _receivePacket.actionType = FormActionType.View;
                SetReadyOnlyMode();
                SetCloseButtonVisibleOnly();
            }
            else
            {
                if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
                {
                    if
                        (
                            _consumerApp.applicationStatus == ApplicationStatus.draft
                            ||
                            _consumerApp.applicationStatus == ApplicationStatus.correction
                        )
                    {
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                        {
                            btnCorrection,
                            btnVerify,
                            btnApprove
                        });
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                        {
                            btnCancel, //reject
                            btnClear,
                            btnSaveDraft,
                            btnSubmit
                        });
                    }
                    else
                    {
                        _receivePacket.actionType = FormActionType.View;
                        SetReadyOnlyMode();
                        SetCloseButtonVisibleOnly();
                    }
                }
                else
                {
                    SetReadyOnlyMode();

                    if (_consumerApp.applicationStatus == ApplicationStatus.submitted)
                    {
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                        {
                            btnAdd,
                            btnBrowse,
                            btnCapture,
                            btnClear,
                            btnSaveDraft,
                            btnSubmit,
                            btnApprove
                        });
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                        {
                            btnCancel, //reject
                            btnCorrection,
                            btnVerify
                        });
                    }

                    else if (_consumerApp.applicationStatus == ApplicationStatus.verified)
                    {
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                        {
                            btnAdd,
                            btnBrowse,
                            btnCapture,
                            btnClear,
                            btnSaveDraft,
                            btnSubmit,
                            btnVerify
                        });
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                        {
                            btnCancel, //reject
                            btnCorrection,
                            btnApprove
                        });
                    }
                    btnKYC.Text = "View KYC";
                    btnTP.Text = "View TP";
                    btnNew.Text = "View Customer";
                }
            }
            if (_receivePacket.actionType == FormActionType.View)
            {
                btnNewIndividual.Enabled = false;
            }
        }

        private void SetReadyOnlyMode()
        {
            _gui.SetControlState(GUI.CONTROLSTATES.CS_READONLY, new Control[]
              {
                    txtConsumerName,
                    txtIndividualId,
                    txtInstruction,
                    txtIntroducerAccNo,
                    txtMobileNo,
                    txtNationalId,
                    txtRatio,
                    cmbRelationship,
              });
            btnNewIndividual.Enabled = false;
        }

        private void SetCloseButtonVisibleOnly()
        {
            _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
           {
                    btnAdd,
                    btnBrowse,
                    btnCancel, //reject
                    btnCapture,
                    btnClear,
                    btnCorrection,
                    btnSaveDraft,
                    btnVerify,
                    btnSubmit,
                    btnApprove
           });
        }

        private void FillComponentWithObjectValue()
        {
            _txnProfileNo = _consumerApp.txnProfileSetNo;
            _kycProfileNo = _consumerApp.kycProfileNo;

            txtConsumerName.Text = _consumerApp.consumerName;
            txtNationalId.Text = _consumerApp.nationalId;
            txtMobileNo.Text = _consumerApp.mobileNo;
            txtIntroducerAccNo.Text = _consumerApp.intrducerAccNumber;
            lblIntroducerName.Text = _consumerApp.introducerAccTitle;
            lblProduct.Text = _consumerApp.agentProduct.productTitle;
            pbConsumerPic.Image = UtilityServices.byteArrayToImage(_consumerApp.photo);

            if (_consumerApp.nominees == null)
            {
                try
                {
                    _consumerApp.nominees = _objNomineeSerivices.getNomineesByConsumerApp(_consumerApp.id);
                    if (_consumerApp.nominees != null && _consumerApp.nominees.Count != 0)
                    {
                        gvNomineeDetail.DataSource = null;
                        gvNomineeDetail.DataSource = _consumerApp.nominees.Select(o => new NomineesGrid(o) { Name = o.individualInformation.firstName + o.individualInformation.lastName, Relation = o.relation, Ratio = o.ratio.ToString() }).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }

            //comment
            {
                if
                    (
                        _consumerApp.commentId != null
                        &&
                        _consumerApp.commentId != 0
                    )
                {
                    _comments = (List<CommentDto>)TermService.GetCommentsID((_consumerApp.commentId).ToString()).ReturnedObject;
                }
                else
                {
                    _comments = new List<CommentDto>();
                }

                CommentText();
            }
            //if (_consumerApp.customer == null)
            //{
            //    _consumerApp.customer = _objConsumerServices.getCustomerByAppId(_consumerApp.id);
            //    GetAddressesIntoCache();
            //}
        }

        private void CommentText()
        {
            int count = _comments.Count;
            if (_commentDraft != null)
            {
                count++;
                btnComment.BackColor = Color.LightGreen;
            }
            btnComment.Text = "Comment (" + count.ToString() + ")";
        }

        private void FillObjectWithComponentValue()
        {
            _consumerApp.consumerName = txtConsumerName.Text;
            _consumerApp.nationalId = txtNationalId.Text;
            _consumerApp.nationalId = txtNationalId.Text;
            _consumerApp.mobileNo = txtMobileNo.Text;
            _consumerApp.intrducerAccNumber = txtIntroducerAccNo.Text;
            _consumerApp.introducerAccTitle = lblIntroducerName.Text;
            _consumerApp.txnProfileSetNo = _txnProfileNo;
            _consumerApp.kycProfileNo = _kycProfileNo ?? 0;
        }

        private void loadAllAddresses()
        {
            //customer
            UtilityServices.appendCustomerAddress(ref _objCustomerInfoForConsumer);

            try
            {
                foreach (OwnerInformation own in _consumerApp.customer.owners)
                {
                    IndividualInformation ownIndi = own.individualInformation;
                    UtilityServices.appendIndividualAddress(ref ownIndi);
                }
            }
            catch
            {
            }
        }

        void addDeleteButtons()
        {
            DataGridViewButtonColumn btnNomineeDelete = new DataGridViewButtonColumn();
            gvNomineeDetail.Columns.Add(btnNomineeDelete);
            btnNomineeDelete.HeaderText = "";
            btnNomineeDelete.Text = "Delete";
            btnNomineeDelete.Name = "btnDelete";
            btnNomineeDelete.UseColumnTextForButtonValue = true;
        }

        void addEditButtons()
        {
            DataGridViewButtonColumn btnNomineeEdit = new DataGridViewButtonColumn();
            gvNomineeDetail.Columns.Add(btnNomineeEdit);
            btnNomineeEdit.HeaderText = "";
            //if (UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
            if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
                btnNomineeEdit.Text = "Edit";
            else
                btnNomineeEdit.Text = "View";
            btnNomineeEdit.Name = "btnEdit";
            btnNomineeEdit.UseColumnTextForButtonValue = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearAlliputData()
        {
            txtConsumerName.Text = string.Empty;
            //txtMobileNo.Text = string.Empty;
            txtNationalId.Text = string.Empty;
            lblProduct.Text = string.Empty;
            txtIntroducerAccNo.Text = string.Empty;
            lblIntroducerName.Text = string.Empty;
            pbImageNominee.Image = null;
            txtInstruction.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtIndividualId.Text = string.Empty;
            cmbRelationship.Text = string.Empty;
            cmbRelationship.SelectedIndex = -1;
            txtRatio.Text = string.Empty;
            pbConsumerPic.Image = null;
            _nomineesInfo = null;
            gvNomineeDetail.DataSource = null;
        }

        private void Clear()
        {
            //txtIndividualId.ReadOnly = false;

            //txtIndividualId.Text = string.Empty;
            //lblIndividualName.Text = string.Empty;
            //txtInstruction.Text = string.Empty;
            //txtRelationship.Text = string.Empty;
            //txtRatio.Text = string.Empty;
            //pbImageNominee.Image = null;
            //_individualNominee = null;

            txtIndividualId.Text = "";
            //txtIndividualId.ReadOnly = false;
            _individualNominee = null;
            _nomineeTemp = null;
            lblIndividualName.Text = "";
            txtInstruction.Text = "";
            cmbRelationship.Text = "";
            cmbRelationship.SelectedIndex = -1;
            txtRatio.Text = "";
            pbImageNominee.Image = null;

            lblIndividualName.Text = "";
            lblFatherName.Text = "";
            lblBirthDate.Text = "";
            txtMobileNumber.Text = "";

            btnNewIndividual.Text = "New Individual";
            btnAdd.Text = "Add";
        }

        private void LoadDataFromStringTable()
        {
            //this.Text = StringTable.frmConsumerCreation;
            //lblCustomerId.Text = StringTable.lblCustomerId;
            //lblConsumerName.Text = StringTable.lblConsumerName;
            //txtMobileNo.Text = StringTable.lblMobileNo;
            //lblEmail.Text = StringTable.lblEmail;
            //lblPicture.Text = StringTable.lblPicture;
            //btnChange.Text = StringTable.btnChange;
            //btnClose.Text = StringTable.btnClose;
            //btnClear.Text = StringTable.btnClear;
            //btnSave.Text = StringTable.btnSave;
            //tabConsumerCreation.TabPages[0].Text = StringTable.tabGengralInfoForConsumerCreation;
            //tabConsumerCreation.TabPages[1].Text = StringTable.tabFingerprintForConsumerCreation;
            //tabConsumerCreation.TabPages[2].Text = StringTable.tabNomineeInfoForConsumerCreation;
            //gpbNomineeDetails.Text = StringTable.gpbNomineeDetails;
            //foreach (DataGridViewColumn column in gvNomineeDetail.Columns)
            //{
            //    switch (column.Index)
            //    {
            //        case 0:
            //            column.HeaderText = StringTable.gvId;
            //            break;
            //        case 1:
            //            column.HeaderText = StringTable.gvName;
            //            break;
            //        case 2:
            //            column.HeaderText = StringTable.gvRelationship;
            //            break;
            //        case 3:
            //            column.HeaderText = StringTable.gvOtherInstruction;
            //            break;
            //        default:
            //            column.HeaderText = StringTable.gvNomineeDetails;
            //            break;
            //    }

            //}
        }

        private CustomerInformation getCustomerInfoFromCustomerDTO(CustomerDto custDTO)
        {
            CustomerInformation custINfo = new CustomerInformation();
            custINfo.title = custDTO.name;
            custINfo.email = custDTO.email;
            custINfo.mobileNumber = custDTO.mobileNumber;
            custINfo.businessAddress = custDTO.businessAddress;
            return custINfo;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.intentType = IntentType.Request;

            switch (_receivePacket.actionType)
            {
                case FormActionType.New:
                case FormActionType.Edit:
                    packet.actionType = FormActionType.Edit;
                    break;
                case FormActionType.View:
                case FormActionType.Verify:
                    packet.actionType = FormActionType.View;
                    break;
            }

            if (_consumerApp.customer == null)
            {
                _consumerApp.customer = _objConsumerServices.getCustomerByAppId(_consumerApp.id);
                //GetAddressesIntoCache();
            }

            frmCustomer customerUi = new frmCustomer(packet, _consumerApp.customer, ref _addresses);

            if (customerUi.ShowDialog() == DialogResult.OK)
            {
                _consumerApp.customer = customerUi.GetFilledObject();
            }
            //GetAddressesIntoCache();
        }

        private void GetAddressesIntoCache()
        {
            if (_consumerApp.customer == null)
            {
                return;
            }
            #region Consumer_Addresses
            {
                if
                    (
                        !_addresses.Keys.Contains(AddressKeys.ADDRESSKEYS_CONSUMER_BUSINESS)
                    &&
                        _consumerApp.customer.businessAddress != null
                    &&
                        !string.IsNullOrEmpty(_consumerApp.customer.businessAddress.addressLineOne)
                    )
                {
                    _addresses.Add(AddressKeys.ADDRESSKEYS_CONSUMER_BUSINESS, _consumerApp.customer.businessAddress);
                }
                else
                {
                    _addresses[AddressKeys.ADDRESSKEYS_CONSUMER_BUSINESS] = _consumerApp.customer.businessAddress;
                }

                if
                    (
                        !_addresses.Keys.Contains(AddressKeys.ADDRESSKEYS_CONSUMER_PERMANENT)
                    &&
                        _consumerApp.customer.permanentAddress != null
                    &&
                        !string.IsNullOrEmpty(_consumerApp.customer.permanentAddress.addressLineOne)
                    )
                {
                    _addresses.Add(AddressKeys.ADDRESSKEYS_CONSUMER_PERMANENT, _consumerApp.customer.permanentAddress);
                }
                else
                {
                    _addresses[AddressKeys.ADDRESSKEYS_CONSUMER_PERMANENT] = _consumerApp.customer.permanentAddress;
                }

                if
                    (
                        !_addresses.Keys.Contains(AddressKeys.ADDRESSKEYS_CONSUMER_PRESENT)
                    &&
                        _consumerApp.customer.presentAddress != null
                    &&
                        !string.IsNullOrEmpty(_consumerApp.customer.presentAddress.addressLineOne)
                    )
                {
                    _addresses.Add(AddressKeys.ADDRESSKEYS_CONSUMER_PRESENT, _consumerApp.customer.presentAddress);
                }
                else
                {
                    _addresses[AddressKeys.ADDRESSKEYS_CONSUMER_PRESENT] = _consumerApp.customer.presentAddress;
                }
            }
            #endregion


            #region Owner_Individual_Addresses
            {
                if (_consumerApp.customer.businessAddress == null)
                {
                    return;
                }
                string key = "";
                for (int i = 0; i < _consumerApp.customer.owners.Count; i++)
                {
                    key = AddressKeys.ADDRESSKEYS_INDIVIDUAL_PERMANENT_ID_ + _consumerApp.customer.owners[i].individualInformation.id.ToString();
                    if
                        (
                            !_addresses.Keys.Contains(key)
                        //&&
                        //    !string.IsNullOrEmpty(_consumerApp.customer.owners[i].individualInformation.permanentAddress.addressLineOne)
                        )
                    {
                        _addresses.Add(key, _consumerApp.customer.owners[i].individualInformation.permanentAddress);
                    }
                    else
                    {
                        _addresses[key] = _consumerApp.customer.owners[i].individualInformation.permanentAddress;
                    }

                    key = AddressKeys.ADDRESSKEYS_INDIVIDUAL_PRESENT_ID_ + _consumerApp.customer.owners[i].individualInformation.id.ToString();
                    if
                        (
                            !_addresses.Keys.Contains(key)
                        //&&
                        //    !string.IsNullOrEmpty(_consumerApp.customer.owners[i].individualInformation.presentAddress.addressLineOne)
                        )
                    {
                        _addresses.Add(key, _consumerApp.customer.owners[i].individualInformation.presentAddress);
                    }
                    else
                    {
                        _addresses[key] = _consumerApp.customer.owners[i].individualInformation.presentAddress;
                    }
                }
            }
            #endregion

            #region Nominee_Individual_Addresses
            {
                string key = "";
                for (int i = 0; i < _consumerApp.nominees.Count; i++)
                {
                    key = AddressKeys.ADDRESSKEYS_INDIVIDUAL_PERMANENT_ID_ + _consumerApp.nominees[i].individualInformation.id.ToString();
                    if
                        (
                            !_addresses.Keys.Contains(key)
                        //&&
                        //    !string.IsNullOrEmpty(_consumerApp.nominees[i].individualInformation.permanentAddress.addressLineOne)
                        )
                    {
                        _addresses.Add(key, _consumerApp.nominees[i].individualInformation.permanentAddress);
                    }
                    else
                    {
                        _addresses[key] = _consumerApp.nominees[i].individualInformation.permanentAddress;
                    }

                    key = AddressKeys.ADDRESSKEYS_INDIVIDUAL_PRESENT_ID_ + _consumerApp.nominees[i].individualInformation.id.ToString();
                    if
                        (
                            !_addresses.Keys.Contains(key)
                        //&&
                        //    !string.IsNullOrEmpty(_consumerApp.nominees[i].individualInformation.presentAddress.addressLineOne)
                        )
                    {
                        _addresses.Add(key, _consumerApp.nominees[i].individualInformation.presentAddress);
                    }
                    else
                    {
                        _addresses[key] = _consumerApp.nominees[i].individualInformation.presentAddress;
                    }
                }
            }
            #endregion
        }

        private void showDataFromIndividualId()
        {
            if (txtIndividualId.Text.Trim() != "")
            {
                try
                {
                    int individualId = Convert.ToInt32(txtIndividualId.Text.Trim());
                    _individualNominee = _objIndividualServices.GetIndividualInfo(individualId);
                    if (_individualNominee == null)
                    {
                        Message.showInformation("Individual not found");
                    }
                    else
                    {
                        lblIndividualName.Text = _individualNominee.firstName + " " + _individualNominee.lastName;
                        lblFatherName.Text = _individualNominee.fatherFirstName;
                        lblBirthDate.Text = _individualNominee.dateOfBirthSt.Replace("00:00:00", "");
                        txtMobileNumber.Text = _individualNominee.mobileNo;
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }
            else
            {
                Message.showError("Individual Id not found");
            }
        }

        private bool validateConsumer(ConsumerApplication consumerApp)
        {
            if (consumerApp.consumerName == "")
            {
                Message.showError("Consumer name not found");
                return false;
            }
            if (consumerApp.nationalId == "")
            {
                Message.showError("National Id not found");
                return false;
            }
            if (consumerApp.mobileNo == "")
            {
                Message.showError("Mobile number not found");
                return false;
            }
            if (consumerApp.kycProfileNo == 0)
            {
                Message.showError("KYC not found");
                return false;
            }
            if (consumerApp.txnProfileSetNo == 0)
            {
                Message.showError("TP not found");
                return false;
            }
            if (consumerApp.customer == null)
            {
                Message.showError("Customer not found");
                return false;
            }
            if (consumerApp.intrducerAccNumber == null || consumerApp.intrducerAccNumber == "")
            {
                Message.showError("Introducer account not found");
                return false;
            }
            if (consumerApp.photo == null)
            {
                Message.showError("Consumer photo not found");
                return false;
            }
            if (consumerApp.nominees.Count == 0)
            {
                Message.showError("Nominee not found");
                return false;
            }

            if (consumerApp.applicationStatus == ApplicationStatus.correction || consumerApp.applicationStatus == ApplicationStatus.canceled)
            {
                //----if (consumerApp.remarks == null || consumerApp.remarks == "")
                //----{
                //----    Message.showError("Please provide remarks before reject or send back for correction.");
                //----    return false;
                //----}
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSaveDraft.Enabled = false;
            string result = Message.showConfirmation("Are you sure to save draft?");

            if (result == "yes")
            {
                if (_consumerApp.customer == null)
                {
                    _consumerApp.customer = _objConsumerServices.getCustomerByAppId(_consumerApp.id);
                }

                if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION)) //Subagent
                {
                    FillObjectWithComponentValue();
                    _consumerApp.applicationStatus = ApplicationStatus.draft;
                    string retrnMsg = "";

                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        retrnMsg = _objConsumerServices.draftConsumer(_consumerApp);
                        ProgressUIManager.CloseProgress();
                        Message.showInformation("Consumer application draft saved successfully with reference number " + retrnMsg);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ProgressUIManager.CloseProgress();
                        btnSaveDraft.Enabled = true;
                        Message.showError(ex.Message);
                    }
                }
            }
            btnSaveDraft.Enabled = true;
        }

        private ConsumerApplication fillConsumerInfo()
        {
            CustomerInformation customerInfo = _objCustomerInfoForConsumer;
            List<NomineeInformationTemp> nominees = _nomineesInfo;
            CustomerInformation custInfo = _objCustomerInfoForConsumer;
            ConsumerApplication consumer = UtilityServices.genConsumerApplication(_consumerApp.id, txtConsumerName.Text.Trim(), txtNationalId.Text.Trim(), txtMobileNo.Text.Trim(), _consumerApp.referenceNumber, _consumerApp.photo, ApplicationStatus.draft, _objCustomerInfoForConsumer, nominees, _consumerApp.subAgentName, _consumerApp.creationDate, _consumerApp.agentProduct, _consumerApp.kycProfileNo, _consumerApp.numberOfOperator, _consumerApp.txnProfileSetNo, _consumerApp.openingAmount ?? 0, txtIntroducerAccNo.Text.Trim(), null);
            return consumer;
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
                    Message.showError("Invalid share ratio!");
                    return false;
                }
            }
            else
            {
                Message.showError("Nominee not found!");
            }
            return false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;

            FillObjectWithComponentValue();

            if (!NomineeValidationCheck())
            {
                btnSubmit.Enabled = true;
                //Message.showError("Nominee Validation Error!");
                return;
            }

            if (_consumerApp.customer == null)
            {
                _consumerApp.customer = _objConsumerServices.getCustomerByAppId(_consumerApp.id);
            }

            DocumentServices docServices = new DocumentServices();

            for (int i = 0; i < _consumerApp.customer.owners.Count; i++)
            {

                if (docServices.isDocumentAvailable(_consumerApp.customer.owners[i].individualInformation.documentInfoId ?? 0))
                {
                    if (_consumerApp.customer.owners[i].individualInformation.documentInfoId == 0 || _consumerApp.customer.owners[i].individualInformation.documentInfoId == null)
                    {
                        Message.showError("Document not found for owner " + _consumerApp.customer.owners[i].individualInformation.firstName + " " + _consumerApp.customer.owners[i].individualInformation.lastName);
                        btnSubmit.Enabled = true;
                        return;
                    }
                }
                else
                {
                    Message.showError("Document not found for owner!");
                    btnSubmit.Enabled = true;
                    return;
                }
            }

            for (int i = 0; i < _consumerApp.nominees.Count; i++)
            {
                if (docServices.isDocumentAvailable(_consumerApp.nominees[i].individualInformation.documentInfoId ?? 0))
                {
                    if (_consumerApp.nominees[i].individualInformation.documentInfoId == 0 || _consumerApp.nominees[i].individualInformation.documentInfoId == null)
                    {
                        Message.showError("Document not found for nominee " + _consumerApp.nominees[i].individualInformation.firstName + " " + _consumerApp.nominees[i].individualInformation.lastName);
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

            string retrnMsg = "";
            if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            {
                string result = Message.showConfirmation("Are you sure to submit finally?");

                if (result == "yes")
                {
                    if (validateConsumer(_consumerApp))
                    {
                        _consumerApp.applicationStatus = ApplicationStatus.submitted;
                        try
                        {
                            ProgressUIManager.ShowProgress(this);
                            retrnMsg = _objConsumerServices.submitConsumer(_consumerApp);
                            ProgressUIManager.CloseProgress();

                            Message.showInformation(retrnMsg);
                            ClearAlliputData();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            ProgressUIManager.CloseProgress();
                            btnSubmit.Enabled = true;
                            Message.showError(ex.Message);
                        }
                    }
                }
            }

            //if (UserWiseRights.fieldOfficerRights.All(s => SessionInfo.rights.Contains(s)))  //FieldOfficer
            if (UtilityServices.isRightExist(Rights.VERIFY_CONSUMER))
            {
                string result = Message.showConfirmation("Are you sure to send for approval?");

                if (result == "yes")
                {
                    _consumerApp.applicationStatus = ApplicationStatus.verified;
                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        retrnMsg = _objConsumerServices.verifyConsumer(_consumerApp);
                        ProgressUIManager.CloseProgress();

                        Message.showInformation(retrnMsg);
                        ClearAlliputData();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ProgressUIManager.CloseProgress();
                        btnSubmit.Enabled = true;
                        Message.showError(ex.Message);
                    }
                }
            }

            //if (UserWiseRights.BranchRights.All(s => SessionInfo.rights.Contains(s))) //Branch
            if (UtilityServices.isRightExist(Rights.APPROVE_CONSUMER))
            {
                string result = Message.showConfirmation("Are you sure to approve?");

                if (result == "yes")
                {
                    _consumerApp.applicationStatus = ApplicationStatus.approved;
                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        retrnMsg = _objConsumerServices.approveConsumer(_consumerApp);
                        ProgressUIManager.CloseProgress();

                        Message.showInformation(retrnMsg);
                        this.Close();
                        //ClearAlliputData();
                        frmShowReport objfrmShowReport = new frmShowReport();
                        objfrmShowReport.PostAccountReport(_consumerApp.referenceNumber);
                    }
                    catch (Exception ex)
                    {
                        ProgressUIManager.CloseProgress();
                        btnSubmit.Enabled = true;
                        Message.showError(ex.Message);
                    }
                }
            }
            btnSubmit.Enabled = true;
        }

        private void fillNomineeList(List<NomineeInformationTemp> nomineeList)
        {
            if (nomineeList != null)
            {
                gvNomineeDetail.DataSource = null;
                gvNomineeDetail.DataSource = nomineeList.Select(o => new NomineesGrid(o) { Name = o.individualInformation.firstName + o.individualInformation.lastName, Relation = o.relation, Ratio = o.ratio.ToString() }).ToList();
            }
        }
        private bool nomineeValidation(NomineeInformationTemp nominee)
        {
            if (nominee.individualInformation == null)
            {
                Message.showError("Individual not found");
                return false;
            }
            if (nominee.photo == null)
            {
                Message.showError("Nominee photo not found");
                return false;
            }
            if (nominee.ratio == 0)
            {
                Message.showError("Nominee share not found");
                return false;
            }
            long usedRatio = 0;
            if (_consumerApp.nominees == null)
            {
                _consumerApp.nominees = new List<NomineeInformationTemp>();
            }
            if (_nomineesInfo == null)
            {
                _nomineesInfo = new List<NomineeInformationTemp>();
                //Message.showWarning("Please provide nominee sharing information !!!");
                //return false;
            }
            foreach (NomineeInformationTemp eachNominee in _nomineesInfo)
            {
                usedRatio += eachNominee.ratio;
                if (btnAdd.Text == "Update")
                    usedRatio = usedRatio - _consumerApp.nominees[_updateNomineeIndex].ratio;
            }
            if (nominee.ratio > (100 - usedRatio))
            {
                Message.showError("Total share cannot exceed 100%.");
                return false;
            }
            if (nominee.relation == "")
            {
                Message.showError("Nominee relation not found");
                return false;
            }
            return true;
        }

        //private Boolean checkValidation()
        //{

        //    int sum = 0;

        //    for (int i = 0; i < gvNomineeDetail.Rows.Count; i++)
        //    {
        //        sum += int.Parse(gvNomineeDetail.Rows[i].Cells[gvNomineeDetail.Columns.Count - 1].Value.ToString());
        //    }

        //    if (sum > 100)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //private Boolean checkValidationForUpdate()
        //{

        //    int sum = 0;

        //    for (int i = 0; i < gvNomineeDetail.Rows.Count; i++)
        //    {
        //        if (i != gvNomineeDetail.SelectedRows[0].Index)
        //            sum += int.Parse(gvNomineeDetail.Rows[i].Cells[gvNomineeDetail.Columns.Count - 1].Value.ToString());
        //    }

        //    if (sum+ int.Parse(txtRatio.Text) > 100)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //private Boolean checkValidation()
        //{

        //    int sum = 0;

        //    for (int i = 0; i < gvNomineeDetail.Rows.Count; i++)
        //    {
        //        try
        //        {
        //            sum += int.Parse(gvNomineeDetail.Rows[i].Cells[gvNomineeDetail.Columns.Count - 1].Value.ToString());
        //        }
        //        catch { }
        //    }

        //    if (sum + int.Parse(txtRatio.Text) > 100)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //private Boolean checkValidationForUpdate()
        //{

        //    int sum = 0;

        //    for (int i = 0; i < gvNomineeDetail.Rows.Count; i++)
        //    {
        //        if (i != _RowIndex)
        //            try
        //            {
        //                sum += int.Parse(gvNomineeDetail.Rows[i].Cells[gvNomineeDetail.Columns.Count - 1].Value.ToString());
        //            }
        //            catch { }
        //    }

        //    if (sum + int.Parse(txtRatio.Text) > 100)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

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
                if (nominee.individualInformation.documentInfoId == null)
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

            if (string.IsNullOrEmpty(cmbRelationship.Text))
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

        private bool checkNomineeInfoForUpdate(NomineeInformationTemp nominee)
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
                //if (nominee.individualInformation.documentInfoId == null)
                //{
                //    Message.showError("Document Information for individual not found.");
                //    return false;
                //}
            }

            if (string.IsNullOrEmpty(lblIndividualName.Text))
            {
                Message.showError("Individual name not found!");
                return false;
            }

            if (string.IsNullOrEmpty(cmbRelationship.Text))
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
            if (!checkNomineeInfoForUpdate(nominee))
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
            if (_nomineeTemp != null)
            {
                byte[] nomineePhoto = UtilityServices.imageToByteArray(pbImageNominee.Image);
                int ratio = (txtRatio.Text.Trim() != "") ? Convert.ToInt32(txtRatio.Text.Trim()) : 0;

                NomineeInformationTemp nominee = UtilityServices.genNomineeInformationTemp(0,
                    _nomineeTemp.individualInformation, cmbRelationship.Text.Trim(), ratio, nomineePhoto,
                    txtInstruction.Text.Trim());

                if (btnAdd.Text == "Add")
                {
                    if (checkValidationForUpdate(nominee))
                    {
                        if (nominee != null && !string.IsNullOrEmpty(cmbRelationship.Text) &&
                            !string.IsNullOrEmpty(txtRatio.Text) && !string.IsNullOrEmpty(lblIndividualName.Text))
                        {
                            //if (_nomineesInfo == null)
                            //    _nomineesInfo = new List<NomineeInformationTemp>();
                            //_nomineesInfo.Add(_nomineeTemp);
                            _consumerApp.nominees.Add(nominee);
                            //_consumerApp.nominees = _nomineesInfo;
                            Clear();
                        }
                        else
                        {
                            Message.showError("Validation error!");
                            return;
                        }
                    }
                    else
                    {
                        Message.showError("Validation error!");
                        return;
                    }
                }
                else
                {
                    if (checkValidationForUpdate(nominee))
                    {
                        if (nominee != null && !string.IsNullOrEmpty(cmbRelationship.Text) &&
                            !string.IsNullOrEmpty(txtRatio.Text) && !string.IsNullOrEmpty(lblIndividualName.Text))
                        {
                            nominee.id = _consumerApp.nominees[_updateNomineeIndex].id;
                            _consumerApp.nominees[_updateNomineeIndex] = nominee;
                            //clearNomineesDataEx();
                            Clear();
                        }
                        else
                        {
                            Message.showError("Validation error!");
                            return;
                        }
                    }
                    else
                    {
                        Message.showError("Validation error!");
                        return;
                    }
                }
                gvNomineeDetail.DataSource = null;

                fillNomineeList(_consumerApp.nominees);

                btnNewIndividual.Text = "New Individual";
                btnAdd.Text = "Add";
            }
            else
            {
                Message.showWarning("Please add nominee information!");
            }
        }

        private void btnNewIndividual_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            //packet.DeveloperMode = true;

            if (_receivePacket.actionType == FormActionType.View)
            {
                packet.actionType = _receivePacket.actionType;
            }
            if
                (
                    btnNewIndividual.Text == "View Individual"
                &&
                    _consumerApp.applicationStatus != ApplicationStatus.draft
                &&
                    _consumerApp.applicationStatus != ApplicationStatus.correction
                &&
                    SessionInfo.userBasicInformation.userType != AgentUserType.Outlet
                )
            {
                packet.actionType = FormActionType.View;
            }

            IndividualInformation individualInformation = null;

            if (_nomineeTemp == null)
            {
                _nomineeTemp = new NomineeInformationTemp();
            }
            else
            {
                individualInformation = _nomineeTemp.individualInformation;
            }

            //GetAddressesIntoCache();

            frmIndividualInformation frmindividualInformation = null;
            if (btnNewIndividual.Text == "Edit Individual" || btnNewIndividual.Text == "View Individual")
            {
                frmindividualInformation = new frmIndividualInformation(packet, individualInformation);

            }
            else
            {
                individualInformation = null;
                frmindividualInformation = new frmIndividualInformation(packet, individualInformation);
            }

            DialogResult dr = frmindividualInformation.ShowDialog();
            if (dr == DialogResult.OK)
            {
                individualInformation = frmindividualInformation.getFilledObject();
                lblIndividualName.Text = individualInformation.firstName + " " + individualInformation.lastName;
                lblIndividualName.Text = individualInformation.firstName + " " + individualInformation.lastName;
                lblFatherName.Text = individualInformation.fatherFirstName;
                lblBirthDate.Text = individualInformation.dateOfBirthSt.Replace("00:00:00", "");
                txtMobileNumber.Text = individualInformation.mobileNo;

                _nomineeTemp.individualInformation = individualInformation;

                btnNewIndividual.Text = "Edit Individual";
            }
            //GetAddressesIntoCache();
        }

        private void btnSearchIndividual_Click(object sender, EventArgs e)
        {
            showDataFromIndividualId();
        }

        private void txtNomineeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showDataFromIndividualId();
            }
        }

        private void gvNomineeDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _updateNomineeIndex = gvNomineeDetail.SelectedCells[0].RowIndex;

                //NomineeInformationTemp nominee = _nomineesInfo[_updateNomineeIndex];
                NomineeInformationTemp nominee = _consumerApp.nominees[_updateNomineeIndex];
                _RowIndex = e.RowIndex;
                if (e.ColumnIndex != 1)
                {
                    if (nominee.individualInformation != null)
                    {
                        txtIndividualId.ReadOnly = true;
                        if (nominee.individualInformation.id != 0)
                        {
                            txtIndividualId.Text = nominee.individualInformation.id.ToString();
                        }
                        lblIndividualName.Text = nominee.individualInformation.firstName + " " +
                                                 nominee.individualInformation.lastName;
                        lblFatherName.Text = nominee.individualInformation.fatherFirstName;
                        lblBirthDate.Text = nominee.individualInformation.dateOfBirthSt.Replace("00:00:00", "");
                        //txtMobileNo.Text = nominee.individualInformation.mobileNo;
                        txtMobileNumber.Text = nominee.individualInformation.mobileNo;
                    }
                    cmbRelationship.Text = nominee.relation;
                    txtInstruction.Text = nominee.instruction;
                    txtRatio.Text = nominee.ratio.ToString();

                    ImageConverter converter = new ImageConverter();
                    pbImageNominee.Image = (nominee.photo != null) ? (Image)converter.ConvertFrom(nominee.photo) : null;
                }
                if (gvNomineeDetail.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int rowIndex = e.RowIndex;
                        long nomineeId = _consumerApp.nominees[e.RowIndex].id;

                        string result = Message.showConfirmation("Are you sure to delete this nominee?");

                        if (result == "yes")
                        {
                            try
                            {
                                string deleteString = "";
                                if (nomineeId != 0)
                                {
                                    deleteString = _objNomineeSerivices.deleteNomineeById(nomineeId);
                                }
                                _consumerApp.nominees.RemoveAt(rowIndex);
                                //Message.showInformation(deleteString);
                            }
                            catch (Exception ex)
                            {
                                Message.showError(ex.Message);
                            }
                        }
                        fillNomineeList(_consumerApp.nominees);
                        return;
                    }
                    if (e.ColumnIndex == 0)
                    {
                        if (
                                !UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION)
                            ||
                                (
                                    (
                                        _consumerApp.applicationStatus != ApplicationStatus.draft
                                        ||
                                        _consumerApp.applicationStatus != ApplicationStatus.correction
                                    )
                                &&
                                    (
                                        _receivePacket.actionType != FormActionType.New
                                        ||
                                        _receivePacket.actionType != FormActionType.Edit
                                    )
                                 )
                            )
                        {
                            btnNewIndividual.Enabled = true;
                            btnNewIndividual.Text = "View Individual";
                        }
                        else
                        {
                            btnNewIndividual.Enabled = true;
                            btnNewIndividual.Text = "Edit Individual";
                        }

                        btnAdd.Text = "Update";
                        _individualNominee = _consumerApp.nominees[gvNomineeDetail.SelectedCells[0].RowIndex].individualInformation;
                        _nomineeTemp = _consumerApp.nominees[gvNomineeDetail.SelectedCells[0].RowIndex];
                    }
                }
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void txtNationalId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtRatio_Leave(object sender, EventArgs e)
        {
            try
            {
                int nRatio = (txtRatio.Text.Trim() != "") ? Convert.ToInt32(txtRatio.Text.Trim()) : 0;
                if (nRatio > CommonRules.nomineeMaxRatio)
                {
                    Message.showError("Ratio cannot be more than" + CommonRules.nomineeMaxRatio);
                    txtRatio.Focus();
                }
            }
            catch (Exception)
            {
                txtRatio.Text = "0";
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

        public void ProfileUpdated(KycProfile profile)
        {
            //_kycProfileNo = profile.id;
            //_consumerApp.kycProfileNo = _kycProfileNo;
        }

        private void btnKYC_Click(object sender, EventArgs e)
        {
            // This button is invisible

            //if (
            //    _consumerApp.applicationStatus == ApplicationStatus.draft
            //    ||
            //    _consumerApp.applicationStatus == ApplicationStatus.draft_at_branch
            //    ||
            //    _consumerApp.applicationStatus == ApplicationStatus.correction
            //    )
            //{

            //    //kycForm.RegisterProfileUpdateObserver(this);

            //    Packet packet = new Packet();
            //    packet.actionType = FormActionType.Edit;
            //    packet.intentType = IntentType.Request;

            //    frmKYC kycForm = new frmKYC(packet, _kycProfileNo);

            //    DialogResult kf = kycForm.ShowDialog();
            //    //if (kf == DialogResult.OK)
            //    {
            //        _kycProfileNo = kycForm.getFilledObject();
            //    }
            //}
            //else
            //{
            //    //kycForm.RegisterProfileUpdateObserver(this);

            //    Packet packet = new Packet();
            //    packet.actionType = FormActionType.View;
            //    packet.intentType = IntentType.Request;

            //    frmKYC kycForm = new frmKYC(packet, _kycProfileNo);

            //    DialogResult kf = kycForm.ShowDialog();
            //    if (kf == DialogResult.OK)
            //    {
            //        _kycProfileNo = kycForm.getFilledObject();
            //    }
            //}
        }

        public void ProfileSetUpdated(CbsTxnProfileSet profileSet)
        {
            _txnProfileNo = profileSet.id;
            _consumerApp.txnProfileSetNo = _txnProfileNo;
        }

        private void btnTP_Click(object sender, EventArgs e)
        {
            // This button is invisible

            //frmCustomerTransactionProfile tpForm = new frmCustomerTransactionProfile();
            //if (_receivePacket.actionType == FormActionType.View || _receivePacket.actionType == FormActionType.Verify)
            //{
            //    tpForm.dgCustomerTnxProfile.ReadOnly = true;
            //    tpForm.btnSave.Enabled = false;
            //    tpForm.btnClear.Enabled = false;
            //}
            //tpForm.RegisterProfileUpdateObserver(this);
            //tpForm.SetProfileSetData(_txnProfileNo, txtConsumerName.Text);
            //tpForm.Show();
            //_txnProfileNo = tpForm.GetTPNo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string result = Message.showConfirmation("Are you to reject this application?");
            if (result == "yes")
            {
                if (CommentCheck())
                {
                    btnCancel.Enabled = false;
                    ApplicationStatusChangeDto applicationStatusChangeDto = new ApplicationStatusChangeDto();
                    applicationStatusChangeDto.applicationId = _consumerApp.id;
                    applicationStatusChangeDto.commentDto = _commentDraft;

                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        _objConsumerServices.changeApplicationStatus(applicationStatusChangeDto, ApplicationStatus.canceled);
                        ProgressUIManager.CloseProgress();
                        Message.showInformation("Application rejected Successfully!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        btnCancel.Enabled = true;
                        ProgressUIManager.CloseProgress();
                        Message.showError(ex.Message);
                    }
                    btnCancel.Enabled = true;
                }
                else
                {
                    Message.showWarning("Comment needed!");
                }
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
                        Message.showWarning("Image file should be in " + CommonRules.imageSizeLimit / 1024 + " KB");
                        return;
                    }
                    #endregion
                    if (img != null)
                        pbImageNominee.Image = img;
                    else Message.showError("Photo not taken.");
                }
            }
            catch (Exception ex)
            {
                Message.showError("Photo not taken.");
            }
        }

        private void txtIntroducerAccNo_Leave(object sender, EventArgs e)
        {
            if (txtIntroducerAccNo.Text.Trim() != "")
            {
                string introducerAccNo = txtIntroducerAccNo.Text.Trim();
                try
                {
                    AccountInformationDto accInfoDto = new AccountInformationDto();
                    AccountInformationService objAccInfoService = new AccountInformationService();
                    accInfoDto = objAccInfoService.getAccountInfoDTO(introducerAccNo);
                    if (accInfoDto == null)
                    {
                        Message.showInformation("No information found for introducer account");
                    }
                    else
                    {
                        lblIntroducerName.Text = accInfoDto.accountTitle;
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }
        }

        private bool CommentCheck()
        {
            if (_commentDraft != null)
            {
                return true;
            }
            return false;
        }

        private void btnCorrection_Click(object sender, EventArgs e)
        {
            string result = Message.showConfirmation("Are you sure to send for correction?");
            if (result == "yes")
            {
                if (CommentCheck())
                {
                    btnCorrection.Enabled = false;
                    ApplicationStatusChangeDto applicationStatusChangeDto = new ApplicationStatusChangeDto();
                    applicationStatusChangeDto.applicationId = _consumerApp.id;
                    applicationStatusChangeDto.commentDto = _commentDraft;

                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        _objConsumerServices.changeApplicationStatus(applicationStatusChangeDto, ApplicationStatus.correction);
                        ProgressUIManager.CloseProgress();
                        Message.showInformation("Application successfully sent for correction!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        btnCorrection.Enabled = true;
                        ProgressUIManager.CloseProgress();
                        Message.showError(ex.Message);
                    }
                    btnCorrection.Enabled = true;
                }
                else
                {
                    Message.showWarning("Comment needed!");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtRelationship_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
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

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string result = Message.showConfirmation("Are you to verify this application?");
            if (result == "yes")
            {
                btnVerify.Enabled = false;
                ApplicationStatusChangeDto applicationStatusChangeDto = new ApplicationStatusChangeDto();
                applicationStatusChangeDto.applicationId = _consumerApp.id;
                applicationStatusChangeDto.commentDto = _commentDraft;

                try
                {
                    ProgressUIManager.ShowProgress(this);
                    _objConsumerServices.changeApplicationStatus(applicationStatusChangeDto, ApplicationStatus.verified);
                    ProgressUIManager.CloseProgress();
                    Message.showInformation("Application verified Successfully!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    btnVerify.Enabled = true;
                    ProgressUIManager.CloseProgress();
                    Message.showError(ex.Message);
                }
                btnVerify.Enabled = true;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string result = Message.showConfirmation("Are you to approve this application?");
            if (result == "yes")
            {
                btnApprove.Enabled = false;
                ApplicationStatusChangeDto applicationStatusChangeDto = new ApplicationStatusChangeDto();
                applicationStatusChangeDto.applicationId = _consumerApp.id;
                applicationStatusChangeDto.commentDto = _commentDraft;

                try
                {
                    ProgressUIManager.ShowProgress(this);
                    _objConsumerServices.changeApplicationStatus(applicationStatusChangeDto, ApplicationStatus.approved);
                    ProgressUIManager.CloseProgress();
                    Message.showInformation("Application approved Successfully!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    btnApprove.Enabled = true;
                    ProgressUIManager.CloseProgress();
                    Message.showError(ex.Message);
                }
                btnApprove.Enabled = true;
            }
        }

        private void btnComment_Click(object sender, EventArgs e)
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
                if (_consumerApp.applicationStatus == ApplicationStatus.submitted)
                {
                    stageTmp = "Verification";
                }
                else
                {
                    stageTmp = "Approval";
                }
            }

            if (_consumerApp != null)
            {
                //if (_receivePacket.actionType != FormActionType.New)
                {

                    frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                    frm.Top = this.Top + btnComment.Top - frm.Height + 40;
                    frm.Left = btnComment.Left + this.Left + 10;
                    frm.ShowDialog();
                    _commentDraft = frm._commentDraft;
                    CommentText();
                    return;
                }
            }

            if (_receivePacket.actionType == FormActionType.New)
            {
                frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                frm.Top = this.Top + btnComment.Top - frm.Height + 40;
                frm.Left = btnComment.Left + this.Left + 10;
                frm.ShowDialog();
                _commentDraft = frm._commentDraft;
                CommentText();
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

        private void frmConsumerCreation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void btnSetTPandKYC_Click(object sender, EventArgs e)
        {
            try
            {
                frmTPAndKYC tpKycForm = new frmTPAndKYC(_consumerApp.agentProduct.productType, _consumerApp.agentProduct.accountCategory, true);
                if (_receivePacket.actionType == FormActionType.View || _receivePacket.actionType == FormActionType.Verify)
                {
                    tpKycForm._viewMode = true;
                    tpKycForm._enableControlsTP(false);
                    tpKycForm._enableControlsKYC(false);
                    tpKycForm.btnSave.Visible = tpKycForm.btnClear.Visible = false;
                    //tpKycForm.btnSetTransacProfile.Enabled = tpKycForm.btnSetKYC.Enabled = false;
                }

                tpKycForm.tpAndKYC.SelectTab(0);
                tpKycForm.RegisterProfileUpdateObserver(this);
                tpKycForm.SetTxnProfileSetData(_txnProfileNo, txtConsumerName.Text);
                tpKycForm.SetKYCProfileData(_kycProfileNo);
                //tpKycForm.Show();
                DialogResult dr = tpKycForm.ShowDialog();
                _txnProfileNo = tpKycForm.GetTxnProfileNo();
                _kycProfileNo = tpKycForm.getKycID();
            }
            catch (Exception exp)
            { Message.showError(exp.Message); }
        }
    }
}