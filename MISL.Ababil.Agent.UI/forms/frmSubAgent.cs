using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using System.IO;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using System.Text.RegularExpressions;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;


namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmSubAgent : Form
    {
        List<SubAgentUser> usrList = new List<SubAgentUser>();
        AgentInformation objAgentInfo = new AgentInformation();
        AgentServices objAgentServices = new AgentServices();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        SubAgentInformation _subagentInformation = new SubAgentInformation();
        long _agentid = 0;
        bool update = false;
        long idForUpdate = 0;
        int columnLoaded = 0;
        public frmSubAgent()
        {
            InitializeComponent();
            ConfigureValidation();
            getSetupData();
        }
        public frmSubAgent(SubAgentInformation subagentInfo, long agentId, ActionType actionType)
        {
            if (ActionType.update == actionType)
            {
                InitializeComponent();
                update = true;
                _subagentInformation = subagentInfo;
                _agentid = agentId;
                ConfigureValidation();
                getSetupData();
                setSubAgentInfoToUpdate(subagentInfo, agentId);

                cmbAgentName.Enabled = false;
            }
        }
        private void frmSubAgent_Load(object sender, EventArgs e)
        {
            try
            {
                txtMobile.MaxLength = CommonRules.mobileNoLength;
                //getSetupData();

                cmbAgentName.SelectedValue = _agentid;
                // ComboBox cb = (ComboBox)sender;
                //    gvUserInfo.CellValueChanged +=
                //new DataGridViewCellEventHandler(gvUserInfo_CellValueChanged);
                //    gvUserInfo.CurrentCellDirtyStateChanged +=
                //        new EventHandler(gvUserInfo_CurrentCellDirtyStateChanged);
                //    gvUserInfo.CellClick +=
                //        new DataGridViewCellEventHandler(gvUserInfo_CellClick);


            }
            catch (Exception ex)
            {
            }

        }
        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void gvUserInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvUserInfo.IsCurrentCellDirty)
            {
                gvUserInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // If a check box cell is clicked, this event handler disables   
        // or enables the button in the same row as the clicked cell. 
        public void gvUserInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvUserInfo.Columns[e.ColumnIndex].Name == "CheckBoxes")
            {
                DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)gvUserInfo.Rows[e.RowIndex].Cells["Buttons"];

                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)gvUserInfo.Rows[e.RowIndex].Cells["CheckBoxes"];
                buttonCell.Enabled = !(Boolean)checkCell.Value;

                gvUserInfo.Invalidate();
            }
        }
        // If the user clicks on an enabled button cell, this event handler   
        // reports that the button is enabled. 
        void gvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvUserInfo.Columns[e.ColumnIndex].Name == "Buttons")
            {
                DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)gvUserInfo.Rows[e.RowIndex].Cells["Buttons"];

                if (buttonCell.Enabled)
                {
                    MessageBox.Show(gvUserInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is enabled");
                }
            }
        }
        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, cmbAgentName, "Agent Name", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, txtSubAgentName, "Sub Agent/ Business Name", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, cmbBranch, "Branch", (long)ValidationType.ListSelected, true);

            //____following field(s) can be null; ignored unless non-mandatory field validation returns true even when these are null____//
            //                      
            ValidationManager.ConfigureValidation(this, cmbDivitionBus, "Division", (long)ValidationType.ListSelected);
            ValidationManager.ConfigureValidation(this, cmbDistrictBus, "District", (long)ValidationType.ListSelected);
            ValidationManager.ConfigureValidation(this, cmbThanaBus, "Thana", (long)ValidationType.ListSelected);
            ValidationManager.ConfigureValidation(this, cmbPostCodeBus, "Post Code", (long)ValidationType.ListSelected);
            ValidationManager.ConfigureValidation(this, cmbCountryBus, "Country", (long)ValidationType.ListSelected);


            ValidationManager.ConfigureValidation(this, cmbAgentAccountNo, "Agent account no.", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, txtCode, "Sub Agent Code", (long)ValidationType.NonWhitespaceNonEmptyText);
            ValidationManager.ConfigureValidation(this, txtMobile, "Mobile", (long)ValidationType.BangladeshiCellphoneNumber, true);
            ValidationManager.ConfigureValidation(this, txtEmail, "Email", (long)ValidationType.EmailAddress);

        }
        private void addDeleteButtons()
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            gvUserInfo.Columns.Add(btnDelete);
        }

        public void newUsercredentials(string userName, string password, UserType userType, List<BiometricTemplate> fingerdata)
        {

            List<AgentUser> usrList = new List<AgentUser>();
            AgentUser usrInfo = new AgentUser();

            usrInfo.username = userName;
            usrInfo.password = password;
            usrInfo.fingerDatas = fingerdata;

            usrList.Add(usrInfo);

            gvUserInfo.DataSource = usrList;
            gvUserInfo.AutoGenerateColumns = false;
            gvUserInfo.Visible = true;
            gvUserInfo.Show();

            this.Refresh();

        }
        private void getSetupData()
        {
            //string configvalue1 = ConfigurationManager.AppSettings["countryId"];
            try
            {
                objAgentInfoList = objAgentServices.getAgentInfoBranchWise();
                BindingSource bs = new BindingSource();
                bs.DataSource = objAgentInfoList;
                UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
                //cmbAgentName.Text = "Select";
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
            //genAccountList(Convert.ToInt64(cmbAgentName.SelectedValue));
            UtilityServices.fillBranches(ref cmbBranch);
            //cmbBranch.Text = "Select";
            cmbBranch.SelectedValue = CommonRules.agentBankDivisionId;
            cmbBranch.Enabled = false;
            UtilityServices.fillDivisions(ref cmbDivitionBus);
            UtilityServices.fillCountries(ref cmbCountryBus);
            cmbCountryBus.SelectedValue = CommonRules.countryId;
            cmbCountryBus.Enabled = false;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //this.Text = cmbAgentName.SelectedValue.ToString();
            clearAllInputData();
        }
        private void clearAllInputData()
        {
            txtSubAgentName.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtAddressLineOne.Text = string.Empty;
            txtAddressLineTwo.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;

            cmbBranch.Text = "Select";
            cmbDistrictBus.DataSource = null;
            cmbThanaBus.DataSource = null;
            cmbPostCodeBus.DataSource = null;

            pictureBoxsubAgent.Image = null;
            gvUserInfo.DataSource = null;
            gvUserInfo.Columns.Clear();
            usrList = null;
        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        //____Replaced by new validation code
        //
        //private Boolean validationCheck()
        //{
        //    #region Required Data Check
        //    if (txtSubAgentName.Text == "")
        //    {
        //        Message.showError("Input Sub Agent/ Business Name.");
        //        txtSubAgentName.Focus();
        //        return false;
        //    }
        //    if (txtCode.Text == "")
        //    {

        //        Message.showError("Input Sub Agent Code.");
        //        txtCode.Focus();
        //        return false;

        //    }
        //    if (cmbAgentAccountNo.Items.Count == 0) { MessageBox.Show("Select Account No."); return false; }
        //    if (usrList.Count == 0) { MessageBox.Show("Add user"); return false; }
        //    //if (pictureBoxsubAgent.Image == null) { MessageBox.Show("Add Photo."); return; }
        //    #endregion

        //    if (txtEmail.Text.Trim() != "")
        //    {
        //        if (IsEmailValidated() == false) return false;
        //    }

        //    return true;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            clearEror();


            if (validationCheck())
            {

                string result = Message.showConfirmation("Are you sure to save sub agent?");

                if (result == "yes")
                {
                    SubAgentServices objSubAgentServices = new SubAgentServices();
                    SubAgentInformation objSubAgentInfo = fillSubAgentInfo();

                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        string retrnMsg = objSubAgentServices.saveSubAgentInfo(objSubAgentInfo);
                        ProgressUIManager.CloseProgress();

                        Message.showInformation("Sub Agent created successfully");
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
        }


        private void genAccountList(long agentId)
        {
            /*
            if (!cb.Focused)
            {
                return;
            }
            */
            //long agentId = Convert.ToInt64(cmbAgentName.SelectedValue);
            List<AccountInformation> accList = new List<AccountInformation>();
            objAgentInfo = objAgentInfoList.Single(o => o.id == agentId);

            accList = objAgentServices.getAgentAccountList(agentId);
            BindingSource bs = new BindingSource();
            bs.DataSource = accList;
            UtilityServices.fillComboBox(cmbAgentAccountNo, bs, "accountNumber", "id");

        }



        private SubAgentInformation fillSubAgentInfo()
        {
            SubAgentInformation objSubAgentInfo = new SubAgentInformation();
            if (idForUpdate != 0) objSubAgentInfo.id = idForUpdate;

            objSubAgentInfo.status = OutletStatus.ACTIVE;       // WALI :: 29-Dec-2015
            objSubAgentInfo.name = txtSubAgentName.Text;
            objSubAgentInfo.subAgentCode = txtCode.Text.Trim();
            objSubAgentInfo.businessAddress = UtilityServices.genClientAddress(txtAddressLineOne.Text.Trim(), txtAddressLineTwo.Text.Trim(), cmbPostCodeBus, cmbThanaBus, cmbDistrictBus, cmbDivitionBus, cmbCountryBus, null, null);
            if (_subagentInformation.businessAddress != null)
                objSubAgentInfo.businessAddress.id = _subagentInformation.businessAddress.id;
            objSubAgentInfo.mobleNumber = txtMobile.Text;
            objSubAgentInfo.email = txtEmail.Text;
            objSubAgentInfo.agentAccount = UtilityServices.genAccountInfo(Convert.ToInt32(cmbAgentAccountNo.SelectedValue), null, null, false, null, null, null);
            objSubAgentInfo.agent = objAgentInfo;
            //objSubAgentInfo.agent = UtilityServices.GetAgentInformation();

            if (pictureBoxsubAgent.Image != null)
            {
                objSubAgentInfo.img = imageToByteArray(pictureBoxsubAgent.Image);
                //objSubAgentInfo.img = ImageToBase64(pictureBoxsubAgent.Image,System.Drawing.Imaging.ImageFormat.Jpeg);

            }

            //datagrid
            {
                for (int i = 0; i < gvUserInfo.Rows.Count; i++)
                {
                    bool? retVal = ((bool?)gvUserInfo.Rows[i].Cells[2].Value) ?? false;
                    //usrList[i].active = retVal ?? false;
                    if (retVal == true) usrList[i].userStatus = UserStatus.ACTIVE;
                    else usrList[i].userStatus = UserStatus.INACTIVE;
                }
            }

            if (usrList != null) objSubAgentInfo.users = usrList;
            if (cmbBranch.SelectedValue != null)
                objSubAgentInfo.monitoringBranch = Convert.ToInt64(cmbBranch.SelectedValue);
            return objSubAgentInfo;

        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                clearEror();
                OpenFileDialog dlg = new OpenFileDialog();
                UtilityServices.uploadPhoto(ref dlg, ref pictureBoxsubAgent);
            }
            catch (Exception)
            {
                throw new ApplicationException("Image loading error....");
            }
            //try
            //{
            //    clearEror();
            //    OpenFileDialog dlg = new OpenFileDialog();
            //    UtilityServices.uploadPhoto(ref dlg, ref pictureBoxsubAgent);
            //    //dlg.Title = "Open Image";
            //    ////dlg.Filter = "All files (*.*)|*.*";
            //    //dlg.Filter = "Image Files(*.jpg; *.jpeg;)|*.jpg; *.jpeg;";

            //    //if (dlg.ShowDialog() == DialogResult.OK)
            //    //{
            //    //    #region Image file length check
            //    //    MemoryStream ms = new MemoryStream();
            //    //    Image img = new Bitmap(dlg.FileName);
            //    //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    //    if (ms.Length > 100000)
            //    //    {                    
            //    //        Message.showError("Image file should be in 100 KB");
            //    //        return;
            //    //    }
            //    //    #endregion


            //    //    pictureBoxsubAgent.Image = new Bitmap(dlg.FileName);

            //    //}

            //    //dlg.Dispose();
            //}
            //catch (Exception ex)
            //{ }
        }
        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //long imgLength = ms.Length;
            return ms.ToArray();
        }
        private void clearEror()
        {
            lblImageError.Text = "";
        }
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            frmUserCreate objFrmUser = new frmUserCreate();
            DialogResult dr = objFrmUser.ShowDialog();

            if (dr == DialogResult.OK)
            {
                SubAgentUser objUserInformation = new SubAgentUser();
                if (usrList == null) { usrList = new List<SubAgentUser>(); }

                objUserInformation = objFrmUser.newUsercredentials();
                objUserInformation.isNewUser = true;
                //objUserInformation.active = true;
                objUserInformation.userStatus = UserStatus.ACTIVE;
                usrList.Add(objUserInformation);


                if (objUserInformation != null)
                {
                    if (objUserInformation.username == "") { Message.showError("User name is required."); return; }
                    if (objUserInformation.password == "") { Message.showError("User password is required."); return; }
                    if (objUserInformation.fingerDatas == null) { Message.showError("User finger print  is required."); return; }
                }

                //gvUserInfo.AutoGenerateColumns = false;
                gvUserInfo.DataSource = null;
                //gvUserInfo.DataSource = usrList.Select(o => new SubagentUserGrid(o) { Username = o.username, Active = o.active ?? false }).ToList();
                gvUserInfo.DataSource = usrList.Select(o => new SubagentUserGrid(o) { Username = o.username}).ToList();

                List<SubagentUserGrid>userGridList = new List<SubagentUserGrid>();
                foreach(SubAgentUser user in usrList)
                {
                    
                }

                loadDeleteButtons();
                gvUserInfo.Refresh();
                //if (columnLoaded == 0)
                //{
                //    DataGridViewDisableButtonColumn buttonColumn = new DataGridViewDisableButtonColumn();
                //    buttonColumn.Text = "Delete";
                //    buttonColumn.Name = "Delete";
                //    buttonColumn.UseColumnTextForButtonValue = true;
                //    gvUserInfo.Columns.Add(buttonColumn);
                //    columnLoaded = 1;
                //}
                //else
                //{
                //    gvUserInfo.Columns[0].DisplayIndex = 0;
                //}
                //DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)gvUserInfo.Rows[usrList.Count - 1].Cells[0];
                //buttonCell.Enabled = false;
            }

        }
        private void loadDeleteButtons()
        {
            if (usrList != null)
            {
                if (columnLoaded == 0)
                {
                    DataGridViewDisableButtonColumn buttonColumn = new DataGridViewDisableButtonColumn();
                    buttonColumn.Text = "Delete";
                    buttonColumn.Name = "Delete";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    gvUserInfo.Columns.Insert(0, buttonColumn);
                    columnLoaded = 1;
                }
                //else
                //{
                //    gvUserInfo.Columns[0].DisplayIndex = 0;
                //}

                for (int i = 0; i < usrList.Count; i++)
                {
                    SubAgentUser user = usrList[i];
                    if (user.isNewUser != true)
                    {
                        DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)gvUserInfo.Rows[i].Cells["Delete"];
                        buttonCell.Enabled = false;
                    }
                }
            }
        }
        private void gvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (gvUserInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            //{
            //    int rowIndex = e.RowIndex;
            //    usrList.RemoveAt(rowIndex);
            //    gvUserInfo.DataSource = null;
            //    gvUserInfo.DataSource = usrList.Select(o => new UserGrid(o) { UserName = o.username, UserType = o.userType }).ToList();
            //}
        }
        private void setSubAgentInfoToUpdate(SubAgentInformation subagentInfo, long agentId)
        {
            if (subagentInfo != null)
            {
                getSetupData();
                cmbAgentName.SelectedValue = agentId;

                objAgentInfo = objAgentInfoList.Single(o => o.id == agentId);
                #region Get Account List of Agent
                //long agentId = Convert.ToInt64(cmbAgentName.SelectedValue);
                List<AccountInformation> accList = new List<AccountInformation>();
                //objAgentInfo = objAgentInfoList.Single(o => o.id == agentId);
                try
                {
                    accList = objAgentServices.getAgentAccountList(agentId);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = accList;
                    UtilityServices.fillComboBox(cmbAgentAccountNo, bs, "accountNumber", "id");
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
                #endregion


                Bitmap image;
                idForUpdate = subagentInfo.id;
                txtSubAgentName.Text = subagentInfo.name;
                txtCode.Text = subagentInfo.subAgentCode;

                #region Address set
                if (subagentInfo.businessAddress != null)
                {
                    txtAddressLineOne.Text = subagentInfo.businessAddress.addressLineOne;
                    txtAddressLineTwo.Text = subagentInfo.businessAddress.addressLineTwo;
                    if (subagentInfo.businessAddress.division != null)
                    {
                        cmbDivitionBus.SelectedValue = subagentInfo.businessAddress.division.id;
                        if (subagentInfo.businessAddress.district != null)
                        {
                            UtilityServices.fillDistrictsByDivision(ref cmbDistrictBus, subagentInfo.businessAddress.division.id);
                            cmbDistrictBus.SelectedValue = subagentInfo.businessAddress.district.id;
                            if (subagentInfo.businessAddress.thana != null)
                            {
                                UtilityServices.fillThanaByDistrict(ref cmbThanaBus, subagentInfo.businessAddress.district.id);
                                cmbThanaBus.SelectedValue = subagentInfo.businessAddress.thana.id;
                            }
                            if (subagentInfo.businessAddress.postalCode != null)
                            {
                                UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodeBus, subagentInfo.businessAddress.district.id);
                                cmbPostCodeBus.SelectedValue = subagentInfo.businessAddress.postalCode.id;
                            }
                        }

                    }
                    if (subagentInfo.businessAddress.country != null)
                    {
                        cmbCountryBus.SelectedValue = subagentInfo.businessAddress.country.id;
                    }
                }
                #endregion

                txtMobile.Text = subagentInfo.mobleNumber;
                txtEmail.Text = subagentInfo.email;
                //txtSubAgentLocation.Text = subagentInfo.businessAddress.addressLineOne;                
                if (subagentInfo.agentAccount != null) cmbAgentAccountNo.SelectedValue = subagentInfo.agentAccount.id;
                usrList = subagentInfo.users;

                if (usrList.Count > 0)
                {
                    //DataGridViewDisableButtonColumn buttonColumn = new DataGridViewDisableButtonColumn();
                    //buttonColumn.Text = "Delete";
                    //buttonColumn.Name = "Delete";
                    //buttonColumn.UseColumnTextForButtonValue = true;
                    //gvUserInfo.Columns.Add(buttonColumn);
                    //columnLoaded = 1;
                    //gvUserInfo.DataSource = usrList.Select(o => new SubagentUserGrid(o) { Username = o.username, Active = o.active ?? false }).ToList();
                    gvUserInfo.DataSource = usrList.Select(o => new SubagentUserGrid(o) { Username = o.username}).ToList();
                    loadDeleteButtons();
                    gvUserInfo.Refresh();
                }
                #region Image set

                //byte[] bytes = Convert.FromBase64String(subagentInfo.img);


                if (subagentInfo.img != null)
                {
                    pictureBoxsubAgent.Image = UtilityServices.byteArrayToImage(subagentInfo.img);
                    //using (MemoryStream stream = new MemoryStream(bytes))
                    //{
                    //    image = new Bitmap(stream);
                    //}
                    //pictureBoxsubAgent.Image = image;
                }


                #endregion


            }
        }
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cb = (ComboBox)sender;

            if (!cb.Focused)
            {
                return;
            }

            long agentId = Convert.ToInt64(cmbAgentName.SelectedValue);
            List<AccountInformation> accList = new List<AccountInformation>();
            objAgentInfo = objAgentInfoList.Single(o => o.id == agentId);
            try
            {
                accList = objAgentServices.getAgentAccountList(agentId);
                BindingSource bs = new BindingSource();
                bs.DataSource = accList;
                UtilityServices.fillComboBox(cmbAgentAccountNo, bs, "accountNumber", "id");
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() != "")
            {
                IsEmailValidated();
            }

        }
        private bool IsEmailValidated()
        {

            //Regex regEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            Regex regEMail = new Regex(@"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$");

            if (regEMail.IsMatch(txtEmail.Text) == false)
            {
                MessageBox.Show("Input valid Email Address.");
                return false;
            }
            else return true;
        }

        private void btnWebCam_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmWebCam webCam = new frmWebCam();
            //    DialogResult dr = webCam.ShowDialog();

            //    if (dr == DialogResult.OK)
            //    {
            //        ImageConverter converter = new ImageConverter();
            //        Image img = (Image)converter.ConvertFrom(webCam.getPhoto());
            //        if (img != null) pictureBoxsubAgent.Image = img;
            //        else MessageBox.Show("Photo not taken.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Photo not taken.");
            //}
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
                        pictureBoxsubAgent.Image = img;
                    else MessageBox.Show("Photo not taken.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Photo not taken.");
            }

        }

        private void cmbDivitionBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            int divisionId = Convert.ToInt32(cmbDivitionBus.SelectedValue);
            UtilityServices.fillDistrictsByDivision(ref cmbDistrictBus, divisionId);

            cmbThanaBus.DataSource = null;
            cmbPostCodeBus.DataSource = null;
        }

        private void cmbDistrictBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillThanaByDistrict(ref cmbThanaBus, Convert.ToInt32(cmbDistrictBus.SelectedValue));
            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodeBus, Convert.ToInt32(cmbDistrictBus.SelectedValue));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSubAgent_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

        private void gvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)gvUserInfo.Rows[e.RowIndex].Cells["Delete"];

            if (buttonCell.Enabled)
            {
                //MessageBox.Show(gvUserInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is enabled");

                try
                {
                    if (gvUserInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        int rowIndex = e.RowIndex;
                        string userName = usrList[e.RowIndex].username;

                        string result = Message.showConfirmation("Are you sure to delete " + userName + "?");

                        if (result == "yes")
                        {
                            if (usrList[e.RowIndex].isNewUser == true)
                            {
                                usrList.RemoveAt(e.RowIndex);
                                //if (usrList.Count == 0) columnLoaded = 0;
                            }
                            else
                            {
                                Message.showInformation("This user cannot be deleted.");
                            }
                        }
                        //gvUserInfo.DataSource = usrList.Select(o => new SubagentUserGrid(o) { Username = o.username, Active = o.active ?? false }).ToList();
                        gvUserInfo.DataSource = usrList.Select(o => new SubagentUserGrid(o) { Username = o.username}).ToList();
                        //loadDeleteButtons();
                        loadDeleteButtons();
                        gvUserInfo.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadDeleteButtons();
            gvUserInfo.Refresh();
            timer1.Enabled = false;
        }

        private void frmSubAgent_Shown(object sender, EventArgs e)
        {

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            loadDeleteButtons();
            gvUserInfo.Refresh();
        }
    }
    public class SubagentUserGrid
    {
        public string Username { get; set; }
        public bool Active { get; set; }

        private SubAgentUser _obj;

        public SubagentUserGrid(SubAgentUser obj)
        {
            _obj = obj;

            if (obj.userStatus == UserStatus.ACTIVE) this.Active = true;
            else if (obj.userStatus == UserStatus.INACTIVE) this.Active = false;
        }

        public SubAgentUser GetModel()
        {
            return _obj;
        }
    }
}
