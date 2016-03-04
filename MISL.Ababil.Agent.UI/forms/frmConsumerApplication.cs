using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report;
using System.IO;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Communication;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmConsumerApplication : MetroForm
    {
        private Packet _receivePacket;
        private GUI _gui = new GUI();
        private CustomerApplyDto _customerApplyDto;
        private AgentProduct _agentProduct = new AgentProduct();
        private ConsumerServices _objConsumerServices = new ConsumerServices();
        private AgentServices _objAgentServices = new AgentServices();
        private List<custIndividualData> _individuals = new List<custIndividualData>();
        private List<BiometricTemplate> _fingerList = new List<BiometricTemplate>();
        private List<AgentProduct> _agentProductList = new List<AgentProduct>();
        private List<CisType> _cisTypes;
        private int _columnLoaded = 0;

        public frmConsumerApplication(Packet packet)
        {
            InitializeComponent();
            _receivePacket = packet;
            InitialSetup();
            _customerApplyDto = new CustomerApplyDto();
            _customerApplyDto.ownerInformations = new List<OwnerInformation>();
            addCaptureButtons();
            addDeleteButtons();
            ConfigUIEnhancement();
        }

        private void InitialSetup()
        {
            SetupDataLoad();
            SetupComponents();
        }

        private void SetupDataLoad()
        {
            UtilityServices.fillCustomerTypes(ref cmbCustomerType);

            UtilityCom objUtil = new UtilityCom();
            try
            {
                _cisTypes = objUtil.getcmbCustomerTypes();

                BindingSource bsc = new BindingSource();
                bsc.DataSource = _cisTypes;
                UtilityServices.fillComboBox(cmbCustomerType, bsc, "description", "id");
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }

            cmbCustomerType.SelectedIndex = -1;
            cmbCustomerType.Text = "Select";
            //UtilityServices.fillOwnerTypes(ref cmbOwnerType);
            cmbAccType.DataSource = Enum.GetValues(typeof(ProductType));
            cmbAccType.Enabled = false;
            txtMobile.MaxLength = 11;
            _agentProductList = _objAgentServices.getAgentProductByProductType(cmbAccType.Text);
            BindingSource bs = new BindingSource();
            bs.DataSource = _agentProductList;
            UtilityServices.fillComboBox(cmbProduct, bs, "productTitle", "id");
            cmbProduct.SelectedIndex = -1;
            txtOpeningDeposit.Text = "";
        }

        public void SetupComponents()
        {

        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);
            _gui.Config(ref txtConsumeName, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            //gui.Config(ref txtNationalId, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER, null);
            _gui.Config(ref txtMobile, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE, null);
            _gui.Config(ref cmbAccType, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref cmbProduct, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref txtOpeningDeposit);

            _gui.Config(ref cmbCustomerType, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref cmbOwnerType, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref txtIndiFirstName);
            _gui.Config(ref txtIndiLastName);
            _gui.Config(ref txtAccOperated, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER, null);
            _gui.Config(ref txtCustomerId);
            _gui.Config(ref txtNationalId, ValidCheck.VALIDATIONTYPES.TEXTBOX_NationalID, "");
        }

        private void addCaptureButtons()
        {
            DataGridViewButtonColumn buttonCapture = new DataGridViewButtonColumn();
            buttonCapture.Text = "Capture";
            buttonCapture.UseColumnTextForButtonValue = true;
            gvIndividualsList.Columns.Add(buttonCapture);
        }

        private void addDeleteButtons()
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            gvIndividualsList.Columns.Add(btnDelete);
        }

        private void btnPicUpload_Click(object sender, EventArgs e)
        {
            try
            {
                UtilityServices.uploadPhoto(ref openFileDialog1, ref pbConsumerPic);
            }
            catch (Exception)
            {
                throw new ApplicationException("Image loading error....");
            }
        }

        private bool checkValidation(CustomerApplyDto customerApplyDto)
        {
            if (customerApplyDto.customerName.Trim() == "")
            {
                Message.showWarning("Consumer name can not be left blank");
                return false;
            }
            if (customerApplyDto.nationalId.Trim() == "")
            {
                Message.showWarning("National Id can not be left blank");
                return false;
            }
            if (customerApplyDto.mobileNo.Trim() == "")
            {
                Message.showWarning("Mobile number can not be left blank");
                return false;
            }
            if (customerApplyDto.photo == null)
            {
                Message.showWarning("Consumer Photo can not be left blank.");
                return false;
            }
            if (customerApplyDto.productType == 0)
            {
                Message.showWarning("Product can not be left blank.");
                return false;
            }

            //
            //keep for future modification
            //
            //if (customerApplyDto.openingDeposit < _agentProduct.openingDeposit)
            //{
            //    Message.showWarning("Opening deposit should be atleast " + _agentProduct.openingDeposit + ".");
            //    return false;
            //}

            if (gvIndividualsList.Rows.Count <= 0)
            {
                Message.showWarning("Owner information not found!.");
                return false;
            }

            //fingerprint capture checking
            {
                for (int i = 0; i < customerApplyDto.ownerInformations.Count; i++)
                {
                    if (customerApplyDto.ownerInformations[i].fingerDatas == null || customerApplyDto.ownerInformations[i].fingerDatas.Count <= 0)
                    {
                        Message.showWarning("Fingerprint not captured for individual: " + customerApplyDto.ownerInformations[i].individualInformation.firstName + "!");
                        return false;
                    }
                }
            }

            if (customerApplyDto.noOfOperator <= 0)
            {
                Message.showWarning("Number of operators not valid.");
                return false;
            }

            if (customerApplyDto.noOfOperator > gvIndividualsList.Rows.Count)
            {
                Message.showWarning("Number of operators not valid.");
                return false;
            }

            return true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            string result = Message.showConfirmation("Are you sure to apply?");
            _gui.RefreshOwnerForm();
            if (result == "yes")
            {
                if (_gui.IsAllControlValidated())
                {
                    if (pbConsumerPic.Image == null)
                    {
                        Message.showWarning("Consumer Photo can not be left blank.");
                        btnApply.Enabled = true;
                        _gui.RefreshOwnerForm();
                        return;
                    }
                    FillObjectWithComponentValue();

                    if (checkValidation(_customerApplyDto))
                    {
                        try
                        {
                            ProgressUIManager.ShowProgress(this);
                            string retrnMsg = _objConsumerServices.applyConsumer(_customerApplyDto);
                            ProgressUIManager.CloseProgress();

                            Message.showInformation("Consumer application draft saved successfully with reference number " + retrnMsg);
                            clearAllControls();
                            _gui.RefreshOwnerForm();
                            frmShowReport objfrmShowReport = new frmShowReport();
                            objfrmShowReport.PreAccountReport(retrnMsg);
                            _gui.RefreshOwnerForm();
                        }
                        catch (Exception ex)
                        {
                            ProgressUIManager.CloseProgress();
                            btnApply.Enabled = true;
                            Message.showError(ex.Message);
                            _gui.RefreshOwnerForm();
                        }
                    }
                }
                else
                {
                    Message.showError("Validation error!");
                    _gui.RefreshOwnerForm();
                    _gui.IsAllControlValidated();
                }
            }
            else
            {
                btnApply.Enabled = true;
                _gui.RefreshOwnerForm();

                return;
            }
            btnApply.Enabled = true;
            _gui.RefreshOwnerForm();
            _gui.IsAllControlValidated();
        }

        private void FillObjectWithComponentValue()
        {
            try
            {
                _customerApplyDto.customerName = txtConsumeName.Text.Trim();
                _customerApplyDto.nationalId = txtNationalId.Text.Trim();
                _customerApplyDto.mobileNo = txtMobile.Text.Trim();
                _customerApplyDto.photo = UtilityServices.imageToByteArray(pbConsumerPic.Image);
                if (cmbCustomerType.SelectedIndex >= 0)
                {
                    _customerApplyDto.cisType = _cisTypes[cmbCustomerType.SelectedIndex];
                }
                // consumerApp.customer = _consumerApp.customer;
                _customerApplyDto.productType = _agentProduct.id;
                _customerApplyDto.noOfOperator = (txtAccOperated.Text.Trim() != "") ? Convert.ToInt32(txtAccOperated.Text.Trim()) : 0;
                _customerApplyDto.openingDeposit = (txtOpeningDeposit.Text.Trim() != "") ? Convert.ToDecimal(txtOpeningDeposit.Text.Trim()) : 0;
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void clearAllControls()
        {
            txtConsumeName.Text = string.Empty;
            txtNationalId.Text = string.Empty;
            txtMobile.Text = string.Empty;
            cmbProduct.SelectedIndex = -1;
            txtOpeningDeposit.Text = "";
            lblCustomerId.Text = "";
            pbConsumerPic.Image = null;
            txtIndiFirstName.Text = string.Empty;
            txtIndiLastName.Text = string.Empty;
            gvIndividualsList.DataSource = null;
            txtAccOperated.Text = "0";
            chkSendToBranch.Checked = false;
            _customerApplyDto = new CustomerApplyDto();
            _customerApplyDto.ownerInformations = new List<OwnerInformation>();
            _individuals = new List<custIndividualData>();
            _fingerList = new List<BiometricTemplate>();
            cmbAccType.Text = "Select";
            cmbProduct.Text = "Select";
            cmbCustomerType.Text = "Select";
            cmbOwnerType.Text = "Select";
            metroTabControl1.SelectedTab = metroTabControl1.TabPages[0];
            metroTabControl2.SelectedTab = metroTabControl2.TabPages[0];
            _gui.RefreshOwnerForm();
            _gui.FocusControl(txtConsumeName);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string result = Message.showConfirmation("Are you sure to clear all data?");
            _gui.RefreshOwnerForm();
            if (result == "yes")
            {
                clearAllControls();
                _gui.RefreshOwnerForm();
            }
            _gui.RefreshOwnerForm();
        }

        private void frmConsumerApplication_Load(object sender, EventArgs e)
        {
            try
            {
                txtConsumeName.Focus();
                metroTabControl1.SelectedTab = metroTabControl1.TabPages[0];
                txtConsumeName.Focus();
                SendKeys.Send("{Tab}");
            }
            catch { }
        }

        private void btnFinger_Click(object sender, EventArgs e)
        {
            frmFingerprintCapture objFrmFinger = new frmFingerprintCapture(txtConsumeName.Text.Trim());
            DialogResult dr = objFrmFinger.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _fingerList = objFrmFinger.bioMetricTemplates;
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

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text.Trim() != "")
                showDataFromCustomerId();
            else
                Message.showInformation("Please provide valide Customer Id");
        }
        private void showDataFromCustomerId()
        {
            /*

                        try
                        {
                            int customerId = Convert.ToInt32(txtCustomerId.Text.Trim());
                            CustomerDto objCustomer = objCustomerServices.GetCustomerInfo(customerId);
                            if (objCustomer != null)
                            {
                                List<OwnerInformation> objOwnerInfo = new List<OwnerInformation>();
                                foreach (OwnerInformation owner in objOwnerInfo)
                                {
                                    custIndividualData custIndi = new custIndividualData();
                                    custIndi.firstName = owner.individualInformation.firstName;
                                    custIndi.lastName = owner.individualInformation.lastName;
                                    //custIndi.fingerDatas=
                                    if (individuals == null)
                                        individuals = new List<custIndividualData>();
                                    individuals.Add(custIndi);
                                }
                                gvIndividualsList.DataSource = individuals;
                            }
                        }
                        catch (Exception ex)
                        {
                            Message.showError(ex.Message);
                        }
                        */

        }
        private bool validIndividual()
        {
            if (cmbCustomerType.Text == "Select" || cmbCustomerType.Text == "")
            {
                Message.showError("Customer type not found");
                return false;
            }
            if (cmbOwnerType.Text == "" || cmbOwnerType.Text == "Select")
            {
                Message.showError("Owner type not found");
                return false;
            }
            if (txtIndiFirstName.Text == "")
            {
                Message.showError("Individual first name not found");
                return false;
            }
            if (txtIndiLastName.Text == "")
            {
                Message.showError("Individual last name not found");
                return false;
            }
            return true;
        }

        private void btnAddIndividual_Click(object sender, EventArgs e)
        {
            if (validIndividual())
            {
                OwnerInformation objOwner = new OwnerInformation();
                IndividualInformation objIndividualInfo = new IndividualInformation();
                objIndividualInfo.firstName = txtIndiFirstName.Text.Trim();
                objIndividualInfo.lastName = txtIndiLastName.Text.Trim();
                if (cmbCustomerType.Text != "Select")
                {
                    try
                    {
                        objOwner.ownerType = UtilityServices.getOwnerTypes(Convert.ToInt32(cmbCustomerType.SelectedValue)).Single(o => o.id == Convert.ToInt32(cmbOwnerType.SelectedValue));
                    }
                    catch (Exception ex)
                    {
                        Message.showError(ex.Message);
                    }
                }
                objOwner.individualInformation = objIndividualInfo;
                _customerApplyDto.ownerInformations.Add(objOwner);
                gvIndividualsList.DataSource = _customerApplyDto.ownerInformations.Select(o => new CustomerIndividualGrid(o) { FirstName = o.individualInformation.firstName, LastName = o.individualInformation.lastName }).ToList();
                txtAccOperated.Text = (((txtAccOperated.Text != "") ? Convert.ToInt32(txtAccOperated.Text) : 0) + 1).ToString();
                colorFingerDataRows(_customerApplyDto.ownerInformations);
                txtIndiFirstName.Text = "";
                txtIndiLastName.Text = "";
                txtIndiFirstName.Focus();
            }
            txtIndiFirstName.Focus();
        }

        private void colorFingerDataRows(List<OwnerInformation> owners)
        {
            for (int i = 0; i < owners.Count; i++)
            {
                if (owners[i].fingerDatas != null)
                {
                    if (owners[i].fingerDatas.Count != 0)
                    {
                        gvIndividualsList.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        private void gvIndividualsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    frmFingerprintCapture objFrmFinger = new frmFingerprintCapture(txtConsumeName.Text.Trim());
                    DialogResult dr = objFrmFinger.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        _fingerList = objFrmFinger.bioMetricTemplates;
                        _customerApplyDto.ownerInformations[e.RowIndex].fingerDatas = _fingerList;
                        _customerApplyDto.ownerInformations[e.RowIndex].capture = true;
                        colorFingerDataRows(_customerApplyDto.ownerInformations);
                    }
                }
                if (e.ColumnIndex == 1)
                {
                    int rowIndex = e.RowIndex;
                    _customerApplyDto.ownerInformations.RemoveAt(rowIndex);
                    gvIndividualsList.DataSource = null;
                    gvIndividualsList.DataSource = _customerApplyDto.ownerInformations.Select(o => new CustomerIndividualGrid(o) { FirstName = o.individualInformation.firstName, LastName = o.individualInformation.lastName }).ToList();
                    colorFingerDataRows(_customerApplyDto.ownerInformations);
                    int individualCount = gvIndividualsList.Rows.Count;
                    int operatorCount = (txtAccOperated.Text != "") ? Convert.ToInt32(txtAccOperated.Text.Trim()) : 0;
                    if (operatorCount <= individualCount)
                    {
                        //txtAccOperated.Text = "1";
                    }
                    else
                        txtAccOperated.Text = (((txtAccOperated.Text != "") ? Convert.ToInt32(txtAccOperated.Text) : 0) - 1).ToString();
                }
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            _agentProduct = _agentProductList.Single(o => o.id == Convert.ToInt32(cmbProduct.SelectedValue));
            txtOpeningDeposit.Text = _agentProduct.openingDeposit.ToString(); //String.Format("{0:#,##0}", _agentProduct.openingDeposit);
        }

        private void txtAccOperated_Leave(object sender, EventArgs e)
        {
            int individualCount = gvIndividualsList.Rows.Count;
            int operatorCount = (txtAccOperated.Text != "") ? Convert.ToInt32(txtAccOperated.Text.Trim()) : 0;
            if (operatorCount < 0)
            {
                Message.showError("Number of operator cannot be negative.");
                txtAccOperated.Focus();
            }
            else
            {
                if (operatorCount > individualCount)
                {
                    Message.showError("Number of operators is higher than number of individuals.");
                    txtAccOperated.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillOwnerTypesByCisType(ref cmbOwnerType, Convert.ToInt32(cmbCustomerType.SelectedValue));
            cmbOwnerType.SelectedIndex = -1;
            cmbOwnerType.Text = "Select";
        }

        private void btnWebcam_Click(object sender, EventArgs e)
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
                        Message.showError("Image file should be in " + CommonRules.imageSizeLimit / 1024 + " KB");
                        return;
                    }
                    #endregion
                    if (img != null)
                        pbConsumerPic.Image = img;
                    else
                        Message.showError("Photo not taken.");
                }
            }
            catch (Exception ex)
            {
                Message.showError("Photo not taken.");
            }
        }

        private void txtOpeningDeposit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOpeningDeposit.Text))
            {
                txtOpeningDeposit.Text = "0";
            }
            //decimal openingDepositAmt = (txtOpeningDeposit.Text.Trim() != "") ? Convert.ToDecimal(txtOpeningDeposit.Text.Trim()) : 0;
            //decimal minimumAmt = _agentProduct.openingDeposit;
            //if (openingDepositAmt < minimumAmt)
            //{
            //    Message.showInformation("Minimum opening deposit for this product is " + minimumAmt + " TK.");
            //    txtOpeningDeposit.Focus();
            //}
        }

        private void frmConsumerApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }

        private void frmConsumerApplication_Deactivate(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void txtOpeningDeposit_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOpeningDeposit.Text))
            {
                txtOpeningDeposit.Text = "0";
            }
        }
    }

    public class custIndividualData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<BiometricTemplate> fingerDatas { get; set; }
    }

    public class CustomerIndividualGrid
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private OwnerInformation _obj;

        public CustomerIndividualGrid(OwnerInformation obj)
        {
            _obj = obj;
        }

        public OwnerInformation GetModel()
        {
            return _obj;
        }
    }

    public class AgentProductsGrid
    {
        public string Product_Prefix { get; set; }
        public string Product_Title { get; set; }

        private AgentProduct _obj;

        public AgentProductsGrid(AgentProduct obj)
        {
            _obj = obj;
        }

        public AgentProduct GetModel()
        {
            return _obj;
        }
    }
}