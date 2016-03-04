using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCustomerSearch : Form
    {
        GUI gui = new GUI();

        List<CustomerInfoDto> customerList = new List<CustomerInfoDto>();
        List<AgentProduct> agentProductList = new List<AgentProduct>();
        AgentServices objAgentServices = new AgentServices();
        CustomerInformation objCustomerInfoForConsumer = new CustomerInformation();
        CustomerServices objCustomerServices = new CustomerServices();
        ConsumerApplication objConsumerApp = new ConsumerApplication();
        CustomerInfoDto cusInfo = new CustomerInfoDto();
        int columnLoaded = 0;
        public frmCustomerSearch()
        {
            InitializeComponent();
            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            gui = new GUI(this);
            gui.Config(ref txtCustomerId);
            gui.Config(ref txtCustomerName);
            gui.Config(ref txtAccountNo);
            gui.Config(ref cmbAccountType);

            gui.Config(ref txtMobileNo);
            gui.Config(ref txtNationalId);
            gui.Config(ref txtDate, ValidCheck.VALIDATIONTYPES.TEXTBOX_DATE_NULLABLE, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {

            cmbAccountType.DataSource = Enum.GetValues(typeof(ProductType));
            cmbAccountType.SelectedIndex = -1;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void loadAllCustomerInfo(CustomerSearchDto dto)
        {
            try
            {
                customerList = CustomerServices.getAllCustomerInfoList(dto);
                if (customerList != null)
                {

                    dvAllCustomerSearch.DataSource = null;
                    dvAllCustomerSearch.Columns.Clear();
                    dvAllCustomerSearch.DataSource = customerList.Select(o => new CustomerApplicationGrid(o) { consumerAppId = o.consumerAppId, CustomerID = o.customerId, CustomerCbsId = o.customerCbsId, CustomerName = o.customerName, MobileNumber = o.mobileNo, TelephoneNumber = o.telephoneNo, OutletName = o.outletName, CreateUser = o.createUser, CreateDate = o.createDate.ToString("dd/MM/yyyy") }).ToList();
                    dvAllCustomerSearch.Columns[0].Visible = false;
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Text = "View";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dvAllCustomerSearch.Columns.Add(buttonColumn);
                    lblItemsFound.Text = "Item(s) Found:  " + dvAllCustomerSearch.Rows.Count;
                }
                else
                    MessageBox.Show("No Customer available");
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }
        CustomerSearchDto dto = new CustomerSearchDto();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsAtLeastOneFilled())
            {
                if (!string.IsNullOrEmpty(txtAccountNo.Text) && cmbAccountType.SelectedIndex < 0)
                {
                    Message.showError("Account Type needed.");
                    return;
                }
                SearchInfo();
            }
        }

        private bool IsAtLeastOneFilled()
        {
            bool flagAllFilled = false;
            if (
                !string.IsNullOrEmpty(txtCustomerId.Text)
                    ||
                !string.IsNullOrEmpty(txtCustomerName.Text)
                    ||
                !string.IsNullOrEmpty(txtAccountNo.Text)
                    ||
                !string.IsNullOrEmpty(txtMobileNo.Text)
                    ||
                !string.IsNullOrEmpty(txtNationalId.Text)
                    ||
                !string.IsNullOrEmpty(txtDate.Text)
                )
            {
                flagAllFilled = true;
            }
            return flagAllFilled;
        }

        private void SearchInfo()
        {
            dto = new CustomerSearchDto();
            if (txtCustomerId.Text != "") dto.customerCbsId = Convert.ToInt64(txtCustomerId.Text);
            // else dto.customerCbsId = 0;
            dto.customerName = txtCustomerName.Text;
            dto.acccountNo = txtAccountNo.Text;
            ProductType accType = new ProductType();
            Enum.TryParse<ProductType>(cmbAccountType.Text, out accType);
            if (cmbAccountType.Text != "") dto.accountType = accType;
            dto.mobileNo = txtMobileNo.Text;
            dto.nationalId = txtNationalId.Text;
            //dto.birthDate = dtpFromDate.Value;  
            ProgressUIManager.ShowProgress(this);
            loadAllCustomerInfo(dto);
            ProgressUIManager.CloseProgress();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //objCustomerInfoForConsumer = objCustomerServices.GetCustomerInfoByConsumerAppId(84);
            //frmCustomer frmCustomerInfo = new frmCustomer(objCustomerInfoForConsumer, Infrastructure.Models.common.ActionType.view);
            //frmCustomerInfo.ShowDialog();
            ClearAllInputData();
        }
        private void ClearAllInputData()
        {
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            cmbAccountType.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtNationalId.Text = string.Empty;
            dtpFromDate.Text = string.Empty;
            dvAllCustomerSearch.DataSource = null;
            dvAllCustomerSearch.Refresh();
            lblItemsFound.Text = "Item(s) Found:  0";
        }

        private void dvAllCustomerSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvAllCustomerSearch.Rows.Count > 0)
            {
                //dgvRemittance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Process"
                try
                {
                    if (dvAllCustomerSearch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
                    {

                        //objCustomerInfoForConsumer = objCustomerServices.GetCustomerInfoByConsumerAppId(long.Parse(dvAllCustomerSearch.Rows[e.RowIndex].Cells[0].Value.ToString()));
                        objCustomerInfoForConsumer = objCustomerServices.GetCustomerInfoByCustomerId(long.Parse(dvAllCustomerSearch.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString()));
                        //frmCustomer frmCustomerInfo = new frmCustomer(objCustomerInfoForConsumer, Infrastructure.Models.common.ActionType.view);
                        //frmCustomerInfo.ShowDialog();
                    }
                }
                catch
                {


                }

            }
        }

        private void txtAccountNo_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class CustomerApplicationGrid
    {
        public long consumerAppId { get; set; }
        public long? CustomerID { get; set; }
        public long? CustomerCbsId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string OutletName { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }

        private CustomerInfoDto _obj;

        public CustomerApplicationGrid(CustomerInfoDto obj)
        {
            _obj = obj;
        }

        public CustomerInfoDto GetModel()
        {
            return _obj;
        }
    }
}
