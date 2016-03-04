using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmTransactionRecodeSearch : Form
    {
        private List<TransactionRecord> _transactionRecordSearch = new List<TransactionRecord>();
        private int _columnLoaded = 0;

        public frmTransactionRecodeSearch()
        {
            InitializeComponent();
            fillSetupData();
            mtbTransactionDate.Text = dtpTransactionDate.Value.ToString("dd-MM-yyyy");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            //chacking valid date
            try
            {
                string[] str = mtbTransactionDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpTransactionDate.Value = d;
            }
            catch
            {
                Message.showError("Please enter the Issue Date in correct format.");
                btnSearch.Enabled = true;
                return;
            }

            TransactionRecordSerchDto objTransactionRecordSerchDto = new TransactionRecordSerchDto();
            objTransactionRecordSerchDto.voucherNumber = txtVoucherNumber.Text;
            objTransactionRecordSerchDto.transactionDate = UtilityServices.GetLongDate(Convert.ToDateTime(dtpTransactionDate.Text));
            AgentServicesType status = new AgentServicesType();
            Enum.TryParse<AgentServicesType>(cmbAgentServices.Text, out status);
            objTransactionRecordSerchDto.agentServicesType = status;

            ProgressUIManager.ShowProgress(this);
            loadAllApplications(objTransactionRecordSerchDto);
            ProgressUIManager.CloseProgress();

            btnSearch.Enabled = true;
        }

        private void loadAllApplications(TransactionRecordSerchDto transactionRecordSerchDto)
        {
            _transactionRecordSearch = TransactionService.getTransactionReocrd(transactionRecordSerchDto);
            if (_transactionRecordSearch != null)
            {
                dvAllTransactinRecordSearch.DataSource = null;
                dvAllTransactinRecordSearch.DataSource = _transactionRecordSearch.Select(o => new TransactionRecordGrid(o) { VoucherNumber = o.voucherNumber, Amount = o.amount, TransactionDate = o.transactionDate.ToString("dd-MM-yyyy").Replace("-", "/"), AgentServices = o.agentServices, SubAgentUser = o.subAgentUser, DebitAccount = o.debitAccount, CreditAccount = o.creditAccount }).ToList();
                if (_columnLoaded == 0)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Text = "View Report";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dvAllTransactinRecordSearch.Columns.Add(buttonColumn);
                    _columnLoaded = 1;
                }
                else
                {
                    dvAllTransactinRecordSearch.Columns[0].DisplayIndex = 7;
                }
            }
            else
            {
                MessageBox.Show("No Transaction record available");
            }

            lblItemsFound.Text = "Item(s) Found: " + dvAllTransactinRecordSearch.Rows.Count.ToString();
        }

        private void fillSetupData()
        {
            AgentServicesType[] agentServiceTypeArray =  (AgentServicesType[])Enum.GetValues(typeof(AgentServicesType));
            List<AgentServicesType> agentServiceTypeList = agentServiceTypeArray.ToList();

            agentServiceTypeList.RemoveAt(4); //Bill Payment
            agentServiceTypeList.RemoveAt(3); //Mini Statement

            cmbAgentServices.DataSource = agentServiceTypeList;
            dtpTransactionDate.Value = SessionInfo.currentDate;
        }

        public class TransactionRecordGrid
        {
            public AgentServicesType AgentServices { get; set; }
            public string TransactionDate { get; set; }
            public decimal Amount { get; set; }
            public string SubAgentUser { get; set; }
            public string DebitAccount { get; set; }
            public string CreditAccount { get; set; }
            public string VoucherNumber { get; set; }

            public TransactionRecord _obj;

            public TransactionRecordGrid(TransactionRecord obj)
            {
                _obj = obj;
            }

            public TransactionRecord GetModel()
            {
                return _obj;
            }
        }

        private void dvAllTransactinRecordSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                TransactionRecord transactionRecordView = new TransactionRecord();
                transactionRecordView = _transactionRecordSearch[e.RowIndex];
                frmShowReport objFrmReport = new frmShowReport();
                if (transactionRecordView.agentServices == AgentServicesType.CashWithdraw)
                {
                    objFrmReport.WithDrawlReport(transactionRecordView.voucherNumber);
                }
                if (transactionRecordView.agentServices == AgentServicesType.CashDeposit)
                {
                    objFrmReport.DepositeReport(transactionRecordView.voucherNumber);
                }
                if (transactionRecordView.agentServices == AgentServicesType.FundTransfer)
                {
                    objFrmReport.MoneyTransferReport(transactionRecordView.voucherNumber);
                }
                if (transactionRecordView.agentServices == AgentServicesType.Remittance)
                {
                    objFrmReport.ShowRemittanceReport(transactionRecordView.voucherNumber);
                }
                if (transactionRecordView.agentServices == AgentServicesType.BillPayment)
                {
                    objFrmReport.BillReportDto(transactionRecordView.voucherNumber);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dvAllTransactinRecordSearch.DataSource = null;
            dvAllTransactinRecordSearch.Rows.Clear();
        }

        private void mtbTransactionDate_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbTransactionDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpTransactionDate.Value = d;
            }
            catch (Exception ex) { }
        }

        private void dtpTransactionDate_ValueChanged(object sender, EventArgs e)
        {
            mtbTransactionDate.Text = dtpTransactionDate.Value.ToString("dd-MM-yyyy");
        }

        private void frmTransactionRecodeSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }
}