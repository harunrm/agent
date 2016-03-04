using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmPendingApplication : MetroForm
    {
        ConsumerServices _objConsumerServices = new ConsumerServices();
        List<ConsumerAppResultDto> _consumerAppResultDto = new List<ConsumerAppResultDto>();
        int _columnLoaded = 0;

        public frmPendingApplication()
        {
            InitializeComponent();
            //ConfigureValidation();
            setSubagent();
            fillSetupData();
            this.MinimizeBox = false;
        }

        private void fillSetupData()
        {
            List<ApplicationStatus> ds = Enum.GetValues(typeof(ApplicationStatus)).Cast<ApplicationStatus>().ToList();
            ds.RemoveAt(ds.Count - 1);
            cmbApplicationStatus.DataSource = ds;

            if
                (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                    ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {
                cmbApplicationStatus.SelectedItem = ApplicationStatus.verified;
            }

            if
                (
                    SessionInfo.userBasicInformation.userType == AgentUserType.FieldOfficer
                )
            {
                cmbApplicationStatus.SelectedItem = ApplicationStatus.submitted;
                cmbApplicationStatus.Enabled = false;
            }

            if
                (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Outlet
                )
            {
                cmbApplicationStatus.SelectedItem = ApplicationStatus.draft;
            }
        }

        private void setSubagent()
        {
            try
            {
                AgentServices _objAgentServices = new AgentServices();
                AgentInformation agentInformation = new AgentInformation();
                if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
                {
                    agentInformation = _objAgentServices.getAgentInfoById(SessionInfo.userBasicInformation.agent.id.ToString());
                    if (agentInformation != null)
                    {
                        BindingSource bs = new BindingSource();
                        bs.DataSource = agentInformation.subAgents;
                        {
                            try
                            {
                                SubAgentInformation saiSelect = new SubAgentInformation();
                                saiSelect.name = "(Select)";
                                agentInformation.subAgents.Insert(0, saiSelect);
                            }
                            catch //suppressed
                            {

                            }
                        }
                        UtilityServices.fillComboBox(cmbOutlet, bs, "name", "id");
                        if (cmbOutlet.Items.Count > 0)
                        {
                            cmbOutlet.SelectedValue = SessionInfo.userBasicInformation.outlet.id;
                            cmbOutlet.Enabled = false;
                            return;
                        }
                    }
                }
                else
                {
                    SubAgentServices subAgentServices = new SubAgentServices();
                    BindingSource bs = new BindingSource();
                    bs.DataSource = subAgentServices.GetAllSubAgents();
                    {
                        try
                        {
                            SubAgentInformation saiSelect = new SubAgentInformation();
                            saiSelect.name = "(Select)";
                            agentInformation.subAgents.Insert(0, saiSelect);
                        }
                        catch //suppressed
                        {

                        }
                    }
                    UtilityServices.fillComboBox(cmbOutlet, bs, "name", "id");
                    if (cmbOutlet.Items.Count > 0)
                    {
                        cmbOutlet.SelectedIndex = -1;
                    }
                }
            }
            catch { }
        }

        //private void ConfigureValidation()
        //{
        //    ValidationManager.ConfigureValidation(this, texReferenceNo, "Reference No", (long)ValidationType.Numeric, false);
        //    ValidationManager.ConfigureValidation(this, txtMobileNo, "Mobile No", (long)ValidationType.BangladeshiCellphoneNumber, false);
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmPendingApplication_Load(object sender, EventArgs e)
        {
            txtMobileNo.MaxLength = CommonRules.mobileNoLength;
        }

        class ConsumerApplicationComparer : IComparer<ConsumerApplication>
        {
            private readonly string _memberName = string.Empty; // the member name to be sorted
            private readonly SortOrder _sortOrder = SortOrder.None;

            public ConsumerApplicationComparer(string memberName, SortOrder sortingOrder)
            {
                _memberName = memberName;
                _sortOrder = sortingOrder;
            }

            public int Compare(ConsumerApplication consumerApplication1, ConsumerApplication consumerApplication2)
            {
                if (_sortOrder != SortOrder.Ascending)
                {
                    var tmp = consumerApplication1;
                    consumerApplication1 = consumerApplication2;
                    consumerApplication2 = tmp;
                }

                switch (_memberName)
                {
                    case "creationDate":
                        return consumerApplication1.creationDate.Value.CompareTo(consumerApplication2.creationDate.Value);
                    default:
                        return consumerApplication1.creationDate.Value.CompareTo(consumerApplication2.creationDate.Value);
                }
            }
        }

        private void loadAllApplications(ConsumerApplicationDto consumerApplicationDto)
        {
            try
            {
                _consumerAppResultDto = ConsumerServices.getConsumerApplications(consumerApplicationDto);
                if (_consumerAppResultDto != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = _consumerAppResultDto.Select(o => new ConsumerAppResultGrid(o) { Outlet = o.outlet, User = o.submitUser, CreationDate = (UtilityServices.getDateFromLong(o.appDate)).ToString("dd-MM-yyyy"), ConsumerName = o.consumerName, NationalId = o.nationalId, MobileNumber = o.mobileNo, ReferenceNumber = o.refNo, ApplicationStatus = o.appStatus }).ToList();
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
                    {
                        buttonColumn.Text = "Edit";
                    }
                    else
                    {
                        buttonColumn.Text = "View";
                    }
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(buttonColumn);
                    _columnLoaded = 1;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //ConsumerApplication consumerApplicationToEdit = new ConsumerApplication();
                        ConsumerAppResultDto consumerApplicationToEdit = new ConsumerAppResultDto();
                        consumerApplicationToEdit = _consumerAppResultDto[i];
                        if (consumerApplicationToEdit.appStatus == ApplicationStatus.draft_at_branch)
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                    }
                }
                else
                    MessageBox.Show("No applications available");
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        //private void loadAllApplications(ConsumerApplicationDto consumerApplicationDto)
        //{
        //    try
        //    {
        //        consumerApplications = ConsumerServices.getConsumerApplications(consumerApplicationDto);

        //        //{
        //        //    DataGridViewColumn column = dataGridView1.Columns[1];

        //        //    string columnName = column.Name;

        //        //    SortOrder sortOrder = column.HeaderCell.SortGlyphDirection == SortOrder.Ascending
        //        //                              ? SortOrder.Descending
        //        //                              : SortOrder.Ascending;

        //        //    consumerApplications.Sort(new ConsumerApplicationComparer(columnName, sortOrder));

        //        //    dataGridView1.Refresh();

        //        //    column.HeaderCell.SortGlyphDirection = sortOrder;

        //        //}
        //        if (consumerApplications != null)
        //        {
        //            dataGridView1.DataSource = null;
        //            dataGridView1.Columns.Clear();
        //            //consumerApplications.Sort();
        //            dataGridView1.DataSource = consumerApplications.Select(o => new ConsumerApplicationGrid(o) { CreationDate = (UtilityServices.getDateFromLong(o.creationDate)).ToString("dd-MM-yyyy"), ConsumerName = o.consumerName, NationalId = o.nationalId, MobileNumber = o.mobileNo, ReferenceNumber = o.referenceNumber, ApplicationStatus = o.applicationStatus }).ToList();
        //            //if (columnLoaded == 0)
        //            //{
        //            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        //            buttonColumn.Text = "Edit";
        //            buttonColumn.UseColumnTextForButtonValue = true;
        //            dataGridView1.Columns.Add(buttonColumn);
        //            columnLoaded = 1;
        //            //}
        //            //else
        //            //{
        //            //    dataGridView1.Columns[0].DisplayIndex = 6;
        //            //}
        //            for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //            {
        //                ConsumerApplication consumerApplicationToEdit = new ConsumerApplication();
        //                consumerApplicationToEdit = consumerApplications[i];
        //                //----if (consumerApplicationToEdit.applicationStatus == ApplicationStatus.draft_at_branch && consumerApplicationToEdit.remarks != null)
        //                if (consumerApplicationToEdit.applicationStatus == ApplicationStatus.draft_at_branch)
        //                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
        //            }
        //        }
        //        else
        //            MessageBox.Show("No applications available");
        //    }
        //    catch (Exception ex)
        //    {
        //        Message.showError(ex.Message);
        //    }
        //}

        public class ConsumerAppResultGrid
        {
            public string Outlet { get; set; }
            public string User { get; set; }
            public string CreationDate { get; set; }

            public string ConsumerName { get; set; }
            public string NationalId { get; set; }
            public string MobileNumber { get; set; }
            public string ReferenceNumber { get; set; }
            public ApplicationStatus ApplicationStatus { get; set; }

            private ConsumerAppResultDto _obj;

            public ConsumerAppResultGrid(ConsumerAppResultDto obj)
            {
                _obj = obj;
            }

            public ConsumerAppResultDto GetModel()
            {
                return _obj;
            }
        }
        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            search();
            btnSearch.Enabled = true;
        }

        private void search()
        {
            //if (validationCheck())
            //{
            ConsumerApplicationDto consumerApplicationDto = new ConsumerApplicationDto(); //SessionInfo.rights.Any(p => p == Rights.CREATE_BANK_USER.ToString()

            consumerApplicationDto.agentUserType = SessionInfo.userBasicInformation.userType;

            if (cmbOutlet.SelectedValue != null)
            {
                consumerApplicationDto.outletId = (long)cmbOutlet.SelectedValue;
            }
            else
            {
                consumerApplicationDto.outletId = null;
            }
            consumerApplicationDto.consumerName = consumerNameTxt.Text;
            consumerApplicationDto.mobileNo = txtMobileNo.Text;
            consumerApplicationDto.nationalId = txtNationalId.Text;
            consumerApplicationDto.referenceNumber = texReferenceNo.Text;
            consumerApplicationDto.fromDate = UtilityServices.GetLongDate(dtpFromDate.Value);
            consumerApplicationDto.toDate = UtilityServices.GetLongDate(dtpToDate.Value);
            consumerApplicationDto.applicationStatus = (ApplicationStatus?)cmbApplicationStatus.SelectedItem;

            //////////if (UserRights.rights.All(s => s.Contains(Rights.DRAFT_CONSUMER_APPLICATION.ToString())) || UserRights.rights.All(s => s.Contains(Rights.SUBMIT_CONSUMER.ToString())))
            //////////if (UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
            //////////    consumerApplicationDto.applicationStatus = ApplicationStatus.draft;
            ////////////if (UserRights.rights.All(s => s.Contains(Rights.VERIFY_CONSUMER.ToString())))
            //////////if (UserWiseRights.fieldOfficerRights.All(s => SessionInfo.rights.Contains(s)))
            //////////    consumerApplicationDto.applicationStatus = ApplicationStatus.submitted;
            ////////////if (UserRights.rights.All(s => s.Contains(Rights.APPROVE_CONSUMER.ToString())))
            //////////if (UserWiseRights.BranchRights.All(s => SessionInfo.rights.Contains(s)))
            //////////    consumerApplicationDto.applicationStatus = ApplicationStatus.verified;

            //if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            //    consumerApplicationDto.applicationStatus = ApplicationStatus.draft;
            //if (UtilityServices.isRightExist(Rights.VERIFY_CONSUMER))
            //    consumerApplicationDto.applicationStatus = ApplicationStatus.submitted;
            //if (UtilityServices.isRightExist(Rights.APPROVE_CONSUMER))
            //    consumerApplicationDto.applicationStatus = ApplicationStatus.verified;

            ProgressUIManager.ShowProgress(this);
            loadAllApplications(consumerApplicationDto);
            ProgressUIManager.CloseProgress();

            lblItemsFound.Text = "Item(s) Found: " + dataGridView1.Rows.Count.ToString();
            //}                                   
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRow = e.RowIndex;
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Rows.Count > 0)
            {
                senderGrid.Rows[e.RowIndex].Selected = true;
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ConsumerAppResultDto consumerAppResultDtoEdit = new ConsumerAppResultDto();
                consumerAppResultDtoEdit = _consumerAppResultDto[e.RowIndex];

                if (consumerAppResultDtoEdit.appStatus == ApplicationStatus.draft_at_branch)
                {
                    frmBrRemarks objFrmBrRemarks = new frmBrRemarks(consumerAppResultDtoEdit);
                    objFrmBrRemarks.Show();

                }
                else
                {
                    //ConsumerApplication consumerApplicationTmp = _objConsumerServices.getConsumerApplicationById(consumerAppResultDtoEdit.refNo);
                    ConsumerApplicationDto consumerApplicationDto = new ConsumerApplicationDto();
                    consumerApplicationDto.referenceNumber = consumerAppResultDtoEdit.refNo;
                    List<ConsumerApplication> consumerApplicationList = _objConsumerServices.getListOfConsumerApplicationsA(consumerApplicationDto);
                    try
                    {
                        byte[] consumerPhoto = _objConsumerServices.getConumerPhotoByAppId(consumerAppResultDtoEdit.appId);
                        consumerApplicationList[0].photo = consumerPhoto;
                    }
                    catch (Exception ex)
                    {
                        Message.showError(ex.Message);
                    }

                    Packet packet = new Packet();
                    packet.DeveloperMode = false;

                    if (SessionInfo.roles.Contains("Sub Agent"))
                    {
                        if (
                            consumerApplicationList[0].applicationStatus != ApplicationStatus.approved 
                            &&
                            consumerApplicationList[0].applicationStatus != ApplicationStatus.canceled
                            )
                        {
                            packet.actionType = FormActionType.Edit;
                        }
                        else
                        {
                            packet.actionType = FormActionType.View;
                        }
                    }
                    else
                    {
                        packet.actionType = FormActionType.View;
                    }

                    packet.intentType = IntentType.Request;


                    frmConsumerCreation objFrmConsumerCreation = new frmConsumerCreation(packet, consumerApplicationList[0]);
                    if (objFrmConsumerCreation.ShowDialog() != DialogResult.No)
                    {
                        btnSearch.Enabled = false;
                        btnSearch.Enabled = true;
                    }
                    search();
                    try
                    {
                        dataGridView1.Rows[selRow].Selected = true;
                    }
                    catch { }
                }
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

        private void frmPendingApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            search();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            //mtbDOB.Text = dtpDOB.Value.ToString("dd-MM-yyyy");
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            //mtbFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy");
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            //mtbToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy");
        }

        private void mtbDOB_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            //try
            //{
            //    string[] str = mtbDOB.Text.Split('-');
            //    DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
            //    dtpDOB.Value = d;
            //}
            //catch (Exception ex) { }
        }

        //private void mtbFromDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbFromDate.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpFromDate.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        //private void mtbToDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbToDate.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpToDate.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        private void btnToDateClear_Click(object sender, EventArgs e)
        {
            ///mtbToDate.Clear();
        }

        private void btnFromDateClear_Click(object sender, EventArgs e)
        {
            //mtbFromDate.Clear();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void ClearAll()
        {
            //consumerApplications = new List<ConsumerApplication>();
            _consumerAppResultDto = new List<ConsumerAppResultDto>();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            //mtbFromDate.Clear();
            //mtbToDate.Clear();

            texReferenceNo.Clear();
            txtNationalId.Clear();
            consumerNameTxt.Clear();
            txtMobileNo.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtNationalId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}