using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmAllConsumerApplicationSearch : Form
    {

        List<ConsumerApplication> consumerApplications = new List<ConsumerApplication>();
        int columnLoaded = 0;
        public frmAllConsumerApplicationSearch()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllSearchData();
        }
        private void fillSetupData()
        {
            cmbApplicationStatus.DataSource = Enum.GetValues(typeof(ApplicationStatus));
        }
        private void ClearAllSearchData()
        {
            txtReferenceNo.Text = string.Empty;
            txtNationalId.Text = string.Empty;
            dateTimeFromDate.Text = string.Empty;
            dateTimeToDate.Text = string.Empty;

            dvAllApplicationSearch.DataSource = null;
            dvAllApplicationSearch.Rows.Clear();
        }

        private void frmAllConsumerApplicationSearch_Load(object sender, EventArgs e)
        {
            fillSetupData();
            dvAllApplicationSearch.Rows.Clear();
            configureDateTimePickers();
        }

        private void configureDateTimePickers()
        {
            mtbFromDate.Text = dateTimeFromDate.Value.ToString("dd-MM-yyyy");
            mtbToDate.Text = dateTimeToDate.Value.ToString("dd-MM-yyyy");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            //checking valid date
            try
            {
                string[] str = mtbFromDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dateTimeFromDate.Value = d;
            }
            catch
            {
                Message.showError("Please enter the date in correct format.");
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                return;
            }

            try
            {
                string[] str = mtbToDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dateTimeToDate.Value = d;
            }
            catch
            {
                ProgressUIManager.CloseProgress();
                Message.showError("Please enter the date in correct format.");
                btnSearch.Enabled = true;
                return;
            }

            //if (validationCheck())
            //{
            AllApplicationSearchDto dto = new AllApplicationSearchDto();
            dto.referenceNumber = txtReferenceNo.Text;
            dto.nationalId = txtNationalId.Text;
            dto.fromDate = UtilityServices.GetLongDate(Convert.ToDateTime(dateTimeFromDate.Text));
            dto.toDate = UtilityServices.GetLongDate(Convert.ToDateTime(dateTimeToDate.Text));
            dto.consumerName = null;
            dto.mobileNo = null;
            ApplicationStatus status = new ApplicationStatus();
            Enum.TryParse<ApplicationStatus>(cmbApplicationStatus.Text, out status);
            dto.applicationStatus = status;

            ProgressUIManager.ShowProgress(this);
            loadAllApplications(dto);
            ProgressUIManager.CloseProgress();

            lblItemsFound.Text = "Item(s) Found: " + dvAllApplicationSearch.Rows.Count.ToString();
            //}

            btnSearch.Enabled = true;
        }

        private void AutoRefresh()
        {
            ApplicationStatus statusTmp = new ApplicationStatus();
            Enum.TryParse<ApplicationStatus>(cmbApplicationStatus.Text, out statusTmp);
            if (statusTmp == ApplicationStatus.draft)
            {
                try
                {
                    string[] str = mtbFromDate.Text.Split('-');
                    DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                    dateTimeFromDate.Value = d;
                }
                catch
                {
                    return;
                }

                try
                {
                    string[] str = mtbToDate.Text.Split('-');
                    DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                    dateTimeToDate.Value = d;
                }
                catch
                {
                    return;
                }

                //if (validationCheck())
                //{
                AllApplicationSearchDto dto = new AllApplicationSearchDto();
                dto.referenceNumber = txtReferenceNo.Text;
                dto.nationalId = txtNationalId.Text;
                dto.fromDate = UtilityServices.GetLongDate(Convert.ToDateTime(dateTimeFromDate.Text));
                dto.toDate = UtilityServices.GetLongDate(Convert.ToDateTime(dateTimeToDate.Text));
                dto.consumerName = null;
                dto.mobileNo = null;
                ApplicationStatus status = new ApplicationStatus();
                Enum.TryParse<ApplicationStatus>(cmbApplicationStatus.Text, out status);
                dto.applicationStatus = status;
                loadAllApplications(dto);
                lblItemsFound.Text = "Item(s) Found: " + dvAllApplicationSearch.Rows.Count.ToString();
                //}
            }
        }
        private void loadAllApplications(AllApplicationSearchDto dto)
        {
            try
            {
                consumerApplications = ConsumerServices.getAllConsumerApplications(dto);
                if (consumerApplications != null)
                {
                    dvAllApplicationSearch.DataSource = null;
                    dvAllApplicationSearch.DataSource = consumerApplications.Select(o => new ConsumerApplicationGrid(o) { ConsumerName = o.consumerName, NationalId = o.nationalId, MobileNumber = o.mobileNo, ReferenceNumber = o.referenceNumber, ApplicationStatus = o.applicationStatus.ToString() }).ToList();
                    if (columnLoaded == 0)
                    {
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.Text = "Show Report";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        dvAllApplicationSearch.Columns.Add(buttonColumn);
                        columnLoaded = 1;
                    }
                    else
                    {
                        dvAllApplicationSearch.Columns[0].DisplayIndex = 5;
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

        private void dvAllApplicationSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ConsumerApplication consumerApplicationToView = new ConsumerApplication();
                consumerApplicationToView = consumerApplications[e.RowIndex];
                frmShowReport objFrmReport = new frmShowReport();

                if (consumerApplicationToView.applicationStatus == ApplicationStatus.approved)
                {
                    objFrmReport.PostAccountReport(consumerApplicationToView.referenceNumber);
                }
                else if (consumerApplicationToView.applicationStatus == ApplicationStatus.draft)
                {
                    objFrmReport.PreAccountReport(consumerApplicationToView.referenceNumber);
                }
                else
                {
                    Message.showInformation("Report available only for draft and approved applications.");
                }
            }
        }

        private void dateTimeFromDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimeToDate.MinDate = new DateTime((dateTimeFromDate.Value).Year, (dateTimeFromDate.Value).Month, (dateTimeFromDate.Value).Day);
            mtbFromDate.Text = dateTimeFromDate.Value.ToString("dd-MM-yyyy");
        }

        private void mtbFromDate_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbFromDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dateTimeFromDate.Value = d;
            }
            catch (Exception ex) { }
        }

        private void mtbToDate_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbToDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dateTimeToDate.Value = d;
            }
            catch (Exception ex) { }
        }

        private void dateTimeToDate_ValueChanged(object sender, EventArgs e)
        {
            mtbToDate.Text = dateTimeToDate.Value.ToString("dd-MM-yyyy");
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            AutoRefresh();
        }

        private void frmAllConsumerApplicationSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class ConsumerApplicationGrid
    {
        public string ConsumerName { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string ApplicationStatus { get; set; }

        private ConsumerApplication _obj;

        public ConsumerApplicationGrid(ConsumerApplication obj)
        {
            _obj = obj;
        }

        public ConsumerApplication GetModel()
        {
            return _obj;
        }
    }
}