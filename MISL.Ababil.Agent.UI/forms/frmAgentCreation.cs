using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmAgentCreation : Form
    {
        AgentServices objAgentServices = new AgentServices();
        CustomerServices objCustServices = new CustomerServices();
        AgentInformation _agentInformation = new AgentInformation();
        private CustomerDto customerDto;
        private List<AccountInformation> accsList;
        private List<AgentUser> userList;
        private List<SubAgentUser> subAgentUserList;
        private List<SubAgentInformation> subAgentInformationList;
        private List<BiometricTemplate> fingerList;
        long idForUpdate = 0;

        public bool IsCalledByOtherForm = false;

        public frmAgentCreation()
        {
            InitializeComponent();
            fillSetupData();
            addDeleteButtons();
            ConfigureValidation();
        }
        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtCustomerId, "Customer ID", (long)ValidationType.Numeric, true);
            ValidationManager.ConfigureValidation(this, txtAgentName, "Agnet Name", (long)ValidationType.NonEmptyText, true);
            ValidationManager.ConfigureValidation(this, txtAgentLocation, "Location", (long)ValidationType.NonEmptyText, true);
            ValidationManager.ConfigureValidation(this, cmbDivision, "Division", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbDistrict, "District", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbThana, "Thana", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbPostCode, "Post Code", (long)ValidationType.ListSelected, false);
            //ValidationManager.ConfigureValidation(this, cmbAccountNo, "Account Number", (long)ValidationType.ListSelected, true);

        }
        public frmAgentCreation(AgentInformation agentInformation, ActionType actionType)
        {
            if (ActionType.update == actionType)
            {
                InitializeComponent();
                addDeleteButtons();
            
                _agentInformation = agentInformation;
                setAgentInfoForUpdate(agentInformation);
                ConfigureValidation();
            }

        }
        private void frmAgentCreation_Load(object sender, EventArgs e)
        {
            if (IsCalledByOtherForm == false)
            {
                tabAgentCreation.TabPages.RemoveByKey("tabPageSubAgent");
            }
        }

        private void setAgentInfoForUpdate(AgentInformation agentInfo)
        {
            if (agentInfo != null)
            {
                fillSetupData();
                idForUpdate = agentInfo.id;

                txtAgentName.Text = agentInfo.businessName;
                txtCustomerId.Text = agentInfo.customerId.ToString();
                if (agentInfo.agentAddress != null)
                {
                    txtAgentLocation.Text = agentInfo.agentAddress.addressLineOne;
                    if (agentInfo.agentAddress.division != null)
                        if (agentInfo.agentAddress.division.id != 0)
                            cmbDivision.SelectedValue = agentInfo.agentAddress.division.id;
                    if (agentInfo.agentAddress.district != null)
                    {
                        if (agentInfo.agentAddress.district.id != 0)
                        {
                            UtilityServices.fillDistrictsByDivision(ref cmbDistrict, agentInfo.agentAddress.division.id);
                            cmbDistrict.SelectedValue = agentInfo.agentAddress.district.id;
                            if (agentInfo.agentAddress.thana != null)
                            {
                                if (agentInfo.agentAddress.thana.id != 0)
                                {
                                    UtilityServices.fillThanaByDistrict(ref cmbThana, Convert.ToInt32(agentInfo.agentAddress.district.id));
                                    cmbThana.SelectedValue = agentInfo.agentAddress.thana.id;
                                }
                            }
                            if (agentInfo.agentAddress.postalCode != null)
                            {
                                if (agentInfo.agentAddress.postalCode.id != 0)
                                {
                                    UtilityServices.fillPostalCodeByDistrict(ref cmbPostCode, Convert.ToInt32(agentInfo.agentAddress.district.id));
                                    cmbPostCode.SelectedValue = agentInfo.agentAddress.postalCode.id;
                                }
                            }
                        }
                    }
                }
                if (agentInfo.accounts != null)
                {
                    if (agentInfo.accounts.Count > 0)
                    {
                        accsList = agentInfo.accounts;
                        gvAccontInformation.DataSource = accsList.Select(o => new AccountGrid(o) { AccountTitle = o.accountTitle, AccountNo = o.accountNumber }).ToList();
                    }
                }
                if (agentInfo.agentUsers != null)
                {
                    if (agentInfo.agentUsers.Count > 0)
                    {
                        userList = agentInfo.agentUsers;
                        gvUsers.DataSource = userList.Select(o => new UserGrid(o) { UserName = o.username }).ToList();
                    }
                }

                if (agentInfo.subAgents != null)
                {
                    if (agentInfo.subAgents.Count > 0)
                    {
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.Text = "Open";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        dgvSubAgent.Columns.Add(buttonColumn);

                        subAgentInformationList = agentInfo.subAgents;
                        dgvSubAgent.DataSource = subAgentInformationList.Select(o => new SubAgentInformationGrid(o) { name = o.name, subAgentCode = o.subAgentCode, mobleNumber = o.mobleNumber, phoneNumber = o.phoneNumber }).ToList();
                    }
                }
            }
        }
        void addDeleteButtons()
        {
            DataGridViewButtonColumn btnUserDelete = new DataGridViewButtonColumn();
            gvUsers.Columns.Add(btnUserDelete);
            btnUserDelete.HeaderText = "";
            btnUserDelete.Text = "Delete";
            btnUserDelete.Name = "btnDelete";
            btnUserDelete.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn btnAccDelete = new DataGridViewButtonColumn();
            gvAccontInformation.Columns.Add(btnAccDelete);
            btnAccDelete.HeaderText = "";
            btnAccDelete.Text = "Delete";
            btnAccDelete.Name = "btnDelete";
            btnAccDelete.UseColumnTextForButtonValue = true;
        }
        //private void btnChangePhoto_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        UtilityServices.uploadPhoto(ref openFileDialog1, ref picboxIndividual);
        //        //lblDefaultUser.Text = openFileDialog1.FileName;
        //    }
        //    catch (Exception)
        //    {
        //        throw new ApplicationException("Image loading error....");
        //    }
        //}
        private void fillSetupData()
        {
            UtilityServices.fillDivisions(ref cmbDivision);
            cmbDivision.SelectedIndex = -1;
        }

        private void btnCloseAgentInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAgentInfo_Click(object sender, EventArgs e)
        {
            clearAllInputData();
        }
        private void clearAllInputData()
        {
            //tab1
            txtCustomerId.Text = string.Empty;
            txtAgentName.Text = string.Empty;
            lblCustomerName.Text = string.Empty;
            lblMobileNo.Text = string.Empty;
            lblEmail.Text = string.Empty;
            //lblDefaultUser.Text = string.Empty;
            txtAgentLocation.Text = string.Empty;

            //cmbDivision.Text = "Select";
            cmbDivision.SelectedIndex = -1;
            cmbDistrict.SelectedValue = "Select";
            cmbThana.SelectedValue = "Select";
            cmbPostCode.SelectedValue = "Select";
            //picboxIndividual.Image = null;

            //tab2
            cmbAccountNo.SelectedValue = "Select";
            lblAccountName.Text = string.Empty;
            gvAccontInformation.DataSource = null;

            //tab3
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            gvUsers.DataSource = null;

            //lists for grid
            accsList = null;
            userList = null;
            fingerList = null;
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillThanaByDistrict(ref cmbThana, Convert.ToInt32(cmbDistrict.SelectedValue));
            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCode, Convert.ToInt32(cmbDistrict.SelectedValue));
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            int divisionId = Convert.ToInt32(cmbDivision.SelectedValue);
            UtilityServices.fillDistrictsByDivision(ref cmbDistrict, divisionId);
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            string result = Message.showConfirmation("Are you sure to save agent?");

            if (result == "yes")
            {

                if (validationCheck())
                {

                    AgentInformation objAgentInfo = fillAgentInfo();
                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        objAgentServices.saveAgent(objAgentInfo);
                        ProgressUIManager.CloseProgress();

                        Message.showInformation("Agent created successfully");
                        clearAllInputData();
                    }
                    catch (Exception ex)
                    {
                        ProgressUIManager.CloseProgress();
                        btnSave.Enabled = true;
                        Message.showError(ex.Message);
                    }
                }

            }

            btnSave.Enabled = true;

            //requiredInputDataCheck();

            //try
            //{
            //    AgentInformation objAgentInfo = fillAgentInfo();
            //    string retrnMsg = objAgentServices.saveAgent(objAgentInfo);
            //    MessageBox.Show(retrnMsg);
            //}
            //catch(Exception ex)
            //{
            //    Message.showError(ex.Message);
            //}
            //if (retrnMsg != null) clearAllInputData();               
        }
        private void showCustomerInfo(CustomerDto objCust)
        {
            if (objCust != null)
            {
                ClearCustomerFields();

                lblCustomerName.Text = objCust.name;
                lblMobileNo.Text = objCust.mobileNumber;
                lblEmail.Text = objCust.email;
                txtAgentName.Text = objCust.name;
                Address custAddress = objCust.businessAddress;
                txtAgentLocation.Text = custAddress.addressLineOne + " " + custAddress.addressLineTwo;

                if (custAddress.district != null)
                {
                    cmbDivision.SelectedValue = custAddress.district.division.id;
                    UtilityServices.fillDistrictsByDivision(ref cmbDistrict, Convert.ToInt32(cmbDivision.SelectedValue));

                    cmbDistrict.SelectedValue = custAddress.district.id;
                    UtilityServices.fillThanaByDistrict(ref cmbThana, Convert.ToInt32(cmbDistrict.SelectedValue));
                    UtilityServices.fillPostalCodeByDistrict(ref cmbPostCode, Convert.ToInt32(cmbDistrict.SelectedValue));
                    if (custAddress.thana != null)
                    {
                        cmbThana.SelectedValue = custAddress.thana.id;
                    }
                    if (custAddress.postalCode != null)
                    {
                        cmbPostCode.SelectedValue = custAddress.postalCode.id;
                    }
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = objCust.accountInformations;
                UtilityServices.fillComboBox(cmbAccountNo, bs, "accountNumber", "accountTitle");

                //bs = new BindingSource();
                //bs.DataSource  = objCust.agentUsers
            }
        }

        private void ClearCustomerFields()
        {
            lblCustomerName.Text = "";
            lblMobileNo.Text = "";
            lblEmail.Text = "";
            txtAgentName.Text = "";
            txtAgentLocation.Text = "";
            //cmbDivision.SelectedIndex = -1;
            //cmbDistrict.SelectedIndex = -1;
            //cmbThana.SelectedIndex = -1;
            //cmbPostCode.SelectedIndex = -1;
            //if (cmbAccountNo.Items.Count > 0)
            //cmbAccountNo.Items.Clear();
        }

        private AgentInformation fillAgentInfo()
        {
            AgentInformation objAgent = new AgentInformation();
            if (idForUpdate != 0) objAgent.id = idForUpdate;
            objAgent.agentCode = "";
            objAgent.businessName = txtAgentName.Text.Trim();
            objAgent.agentAddress = UtilityServices.genClientAddress(txtAgentLocation.Text.Trim(), "", cmbPostCode, cmbThana, cmbDistrict, cmbDivision, null, null, null);
            objAgent.customerId = Convert.ToInt32(txtCustomerId.Text.Trim());
            objAgent.accounts = accsList;
            objAgent.agentUsers = userList;
            objAgent.creationDate = UtilityServices.GetLongDate(SessionInfo.currentDate);
            //objAgent.transactionStatus = 
            //objAgent.approvalStatus = new ApprovalStatus();
            //objAgent.approvalDate = UtilityServices.GetLongDate(DateTime.Now);
            //objAgent.subAgents = new List<SubAgentInformation>();
            return objAgent;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getCustomer();
        }
        private void getCustomer()
        {
            string customerIdText = txtCustomerId.Text;
            if (ValidationManager.ValidatePositive(customerIdText) &&
                ValidationManager.ValidateIntegral(customerIdText) &&
                ValidationManager.ValidateNonZero(customerIdText))
            {
                int customerId = Convert.ToInt32(customerIdText.Trim());
                customerDto = objCustServices.GetCustomerInfo(customerId);
                //if (customerDto != null)
                if (customerDto.accountInformations.Count != 0)
                    showCustomerInfo(customerDto);
                else
                    MessageBox.Show("Customer Not Found.");
            }
            else
                MessageBox.Show("Provide a valid customer id.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            validationCheck();
            try
            {
                if (customerDto != null)
                {
                    string accNo = cmbAccountNo.Text;
                    if (!ValidationManager.ValidateNonEmptyTextWithoutSpace(accNo)) return;
                    //db.StateCounties.Where(x => states.Any(s => x.State.Equals(s))).ToList();
                    AccountInformation objAcc = customerDto.accountInformations.Single(x => x.accountNumber == accNo);
                    if (accsList == null)
                        accsList = new List<AccountInformation>();
                    accsList.Add(objAcc);

                    gvAccontInformation.DataSource = null;
                    gvAccontInformation.DataSource = accsList.Select(o => new AccountGrid(o) { AccountTitle = o.accountTitle, AccountNo = o.accountNumber }).ToList();
                    cmbAccountNo.Text = "Select";
                    lblAccountName.Text = "";
                }
                else MessageBox.Show("No account available");
            }
            catch (Exception exp)
            { Message.showError(exp.Message); }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            int queueId = ValidationManager.QueueValidateControl(txtPassword, "Password", (long)ValidationType.StrongPassword, 0, true);

            ValidationManager.QueueValidateControl(txtUserName, "Username", (long)ValidationType.UserName, queueId, true);

            if (!ValidationManager.ValidateQueue(queueId)) return;


            if (txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                if (fingerList != null)
                {
                    AgentUser objUser = new AgentUser();

                    //objUser.id=
                    objUser.username = txtUserName.Text.Trim();
                    objUser.password = txtPassword.Text.Trim();
                    //objUser.agentInformation = new AgentInformation();
                    objUser.fingerDatas = fingerList;
                    if (userList == null)
                        userList = new List<AgentUser>();
                    userList.Add(objUser);

                    gvUsers.DataSource = null;
                    gvUsers.DataSource = userList.Select(o => new UserGrid(o) { UserName = o.username }).ToList();
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    lblfingerprintResult.Text = string.Empty;
                }
                else
                    MessageBox.Show("user fingerprint needed");
            }
            else
            {
                MessageBox.Show("provide Username and password");
            }
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            frmFingerprintCapture objFrmFinger = new frmFingerprintCapture(txtUserName.Text.Trim());
            DialogResult dr = objFrmFinger.ShowDialog();
            if (dr == DialogResult.OK)
            {
                fingerList = objFrmFinger.bioMetricTemplates;
            }
            if (fingerList != null)
                lblfingerprintResult.Text = "Fingerprint captured successfully";
            else
                lblfingerprintResult.Text = "Fingerprint capture failed";
        }

        private void cmbAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            string accNumber = cmbAccountNo.Text;
            lblAccountName.Text = customerDto.accountInformations.Single(x => x.accountNumber == accNumber).accountTitle;
        }

        private void gvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvUsers.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                userList.RemoveAt(rowIndex);
                gvUsers.DataSource = null;
                gvUsers.DataSource = userList.Select(o => new UserGrid(o) { UserName = o.username }).ToList();
            }
        }

        private void gvAccontInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvAccontInformation.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > 0)
            {
                int rowIndex = e.RowIndex;
                accsList.RemoveAt(rowIndex);
                gvAccontInformation.DataSource = null;
                gvAccontInformation.DataSource = accsList.Select(o => new AccountGrid(o) { AccountTitle = o.accountTitle, AccountNo = o.accountNumber });
            }
        }


        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getCustomer();
            }
        }
        private void txtCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private Boolean validationCheck()
        {
            if (accsList == null || accsList.Count == 0) { MessageBox.Show("Add Account Information."); return false; }
            if (userList == null || userList.Count == 0) { MessageBox.Show("Add User Information."); return false; }
            return ValidationManager.ValidateForm(this);
            //return true;
        }

        private void frmAgentCreation_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }
        public static bool ReleaseValidationData(Form form)
        {
            return true;
        }

        private void dgvSubAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSubAgent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Open")
            {
                if (dgvSubAgent.RowCount > 0)
                {
                    SubAgentInformation subAgentInformation = subAgentInformationList[e.RowIndex]; ;

                    if (subAgentInformation != null)
                    {
                        SubAgentServices services = new SubAgentServices();
                        try
                        {
                            subAgentInformation = services.getSubAgentInfoById(subAgentInformation.id.ToString());
                        }
                        catch (Exception ex)
                        {
                            Message.showError(ex.Message);
                        }
                        frmSubAgent objfrmSubAgent = new frmSubAgent(subAgentInformation, _agentInformation.id, ActionType.update);
                        objfrmSubAgent.ShowDialog();
                    }
                }
            }
        }
    }
    public class UserGrid
    {
        public string UserName { get; set; }

        private AgentUser _obj;

        public UserGrid(AgentUser obj)
        {
            _obj = obj;
        }

        public AgentUser GetModel()
        {
            return _obj;
        }
    }
    public class AccountGrid
    {
        public string AccountTitle { get; set; }
        public string AccountNo { get; set; }

        private AccountInformation _obj;

        public AccountGrid(AccountInformation obj)
        {
            _obj = obj;
        }

        public AccountInformation GetModel()
        {
            return _obj;
        }
    }

    public class SubAgentInformationGrid
    {
        public long id { get; set; }
        public string name { get; set; }
        public string subAgentCode { get; set; }

        public Address businessAddress { get; set; }

        public string mobleNumber { get; set; }
        public string phoneNumber { get; set; }

        private SubAgentInformation _obj;

        public SubAgentInformationGrid(SubAgentInformation obj)
        {
            _obj = obj;
        }

        public SubAgentInformation GetModel()
        {
            return _obj;
        }
    }
}
