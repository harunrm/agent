using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Report.DataSets;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Services;
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
    public partial class frmOutletCashInfoDetails : MetroForm
    {
        private Packet _packet;
        private String _callFrom;
        private bool _isAll;
        private List<CashTxnDetails> _cashTxnDetailsList = new List<CashTxnDetails>();
        OutletCashDetailsDS _outletCashDetilsDS = null;
        frmReportViewer viewer = new frmReportViewer();
        ReportHeaders rptHeaders = new ReportHeaders();

        public frmOutletCashInfoDetails(Packet packet, string callFrom, List<CashTxnDetails> cashTxnDetailsList, bool isAll)
        {
            _packet = packet;
            _callFrom = callFrom;
            _cashTxnDetailsList = cashTxnDetailsList;
            _isAll = isAll;

            InitializeComponent();

            preparedUI();

            if (isAll == false)
            {
                FillComponentWithObjectValue();
            }
            else
            {
                FillComponentWithAllObjectValue();
                this.Width += 180;
                this.Height += 100;
            }
        }

        private void FillComponentWithObjectValue()
        {
            dgvDetails.Columns.Clear();
            dgvDetails.DataSource = _cashTxnDetailsList.Select(o => new CashTxnDetailsGrid(o) { txnTime = o.txnTime, txnCategory = o.category, amount = o.amount, txnUser = o.txnUser }).ToList();

            dgvDetails.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[0].DefaultCellStyle.Padding = new Padding(8, 1, 8, 1);
            dgvDetails.Columns[0].HeaderText = "Transaction Time";
            //dgvDetails.Columns[0].MinimumWidth = 120;
            dgvDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDetails.Columns[0].Width = 120;
            dgvDetails.Columns[0].FillWeight = 120f;

            dgvDetails.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetails.Columns[1].DefaultCellStyle.Padding = new Padding(8, 1, 8, 1);
            dgvDetails.Columns[1].HeaderText = "Category";

            dgvDetails.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetails.Columns[2].DefaultCellStyle.Padding = new Padding(8, 1, 8, 1);
            dgvDetails.Columns[2].HeaderText = "Amount";
            dgvDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDetails.Columns[2].MinimumWidth = dgvDetails.Columns[2].Width = 120;
            dgvDetails.Columns[2].FillWeight = 120f;

            dgvDetails.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetails.Columns[3].DefaultCellStyle.Padding = new Padding(8, 1, 12, 1);
            dgvDetails.Columns[3].HeaderText = "Transaction User";
            dgvDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDetails.Columns[3].MinimumWidth = dgvDetails.Columns[3].Width = 180;
            dgvDetails.Columns[3].FillWeight = 180f;
        }

        private void FillComponentWithAllObjectValue()
        {
            dgvDetails.Columns.Clear();
            dgvDetails.DataSource = _cashTxnDetailsList.Select(o => new AllCashTxnDetailsGrid(o) { txnTime = o.txnTime, txnCategory = o.category, amount = o.amount, txnType = o.cashFlowType, txnUser = o.txnUser }).ToList();

            dgvDetails.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[0].DefaultCellStyle.Padding = new Padding(8, 1, 8, 1);
            dgvDetails.Columns[0].HeaderText = "Transaction Time";
            dgvDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDetails.Columns[0].Width = 120;
            dgvDetails.Columns[0].FillWeight = 120f;

            dgvDetails.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetails.Columns[1].DefaultCellStyle.Padding = new Padding(8, 1, 8, 1);
            dgvDetails.Columns[1].HeaderText = "Category";

            dgvDetails.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetails.Columns[2].DefaultCellStyle.Padding = new Padding(8, 1, 8, 1);
            dgvDetails.Columns[2].HeaderText = "Amount";
            dgvDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDetails.Columns[2].MinimumWidth = dgvDetails.Columns[2].Width = 120;
            dgvDetails.Columns[2].FillWeight = 120f;

            dgvDetails.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[3].DefaultCellStyle.Padding = new Padding(8, 1, 12, 1);
            dgvDetails.Columns[3].HeaderText = "Cash Flow Type";
            dgvDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDetails.Columns[3].MinimumWidth = dgvDetails.Columns[3].Width = 120;
            dgvDetails.Columns[3].FillWeight = 120f;

            dgvDetails.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetails.Columns[4].DefaultCellStyle.Padding = new Padding(8, 1, 12, 1);
            dgvDetails.Columns[4].HeaderText = "Transaction User";
            dgvDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDetails.Columns[4].MinimumWidth = dgvDetails.Columns[4].Width = 170;
            dgvDetails.Columns[4].FillWeight = 170f;
        }

        private void preparedUI()
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_callFrom == "receiveDetails")
            {
                _outletCashDetilsDS = new OutletCashDetailsDS();
                cROutletCashDetailsInfo objPaymentAll = new cROutletCashDetailsInfo();
                //rptHeaders = UtilityServices.getReportHeaders("Account Monitoring Report");
                rptHeaders = UtilityServices.getReportHeaders(this.Text);
                TextObject txtBankNamePaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchNamePaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddressPaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeadingPaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUserPaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDatePaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        txtBankNamePaymentAll.Text = rptHeaders.branchDto.bankName;
                        txtBranchNamePaymentAll.Text = rptHeaders.branchDto.branchName;
                        txtBranchAddressPaymentAll.Text = rptHeaders.branchDto.branchAddress;
                    }

                }

                txtPrintUserPaymentAll.Text = rptHeaders.printUser;
                txtPrintDatePaymentAll.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-", "/");
                //txtReportHeadingPaymentAll.Text = rptHeaders.reportHeading;
                txtReportHeadingPaymentAll.Text = rptHeaders.reportHeading;
                loadOutletCashDetailsInfo();
                objPaymentAll.SetDataSource(_outletCashDetilsDS);
                viewer.crvReportViewer.ReportSource = objPaymentAll;
                viewer.ShowDialog(this.Parent);

            }

            else if (_callFrom == "paymentDetails")
            {
                _outletCashDetilsDS = new OutletCashDetailsDS();
                cROutletCashDetailsInfo objPaymentAll = new cROutletCashDetailsInfo();
                rptHeaders = UtilityServices.getReportHeaders(this.Text);
                TextObject txtBankNamePaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchNamePaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddressPaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeadingPaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUserPaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDatePaymentAll = objPaymentAll.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        txtBankNamePaymentAll.Text = rptHeaders.branchDto.bankName;
                        txtBranchNamePaymentAll.Text = rptHeaders.branchDto.branchName;
                        txtBranchAddressPaymentAll.Text = rptHeaders.branchDto.branchAddress;
                    }

                }

                txtPrintUserPaymentAll.Text = rptHeaders.printUser;
                txtPrintDatePaymentAll.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-", "/");
                txtReportHeadingPaymentAll.Text = rptHeaders.reportHeading;

                loadOutletCashDetailsInfo();
                objPaymentAll.SetDataSource(_outletCashDetilsDS);
                viewer.crvReportViewer.ReportSource = objPaymentAll;
                viewer.ShowDialog(this.Parent);
            }
            else if (_callFrom == "receiveAll")
            {
                cROutletCashDetails ObjRecieveAll = new cROutletCashDetails();
                rptHeaders = UtilityServices.getReportHeaders("Outlet Cash Recieve Information");
                TextObject txtBankNameReciveAll = ObjRecieveAll.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchNameReciveAll = ObjRecieveAll.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddressReciveAll = ObjRecieveAll.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeadingReciveAll = ObjRecieveAll.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUserReciveAll = ObjRecieveAll.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                //TextObject txtPrintDateReciveAll = ObjRecieveAll.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;

                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        txtBankNameReciveAll.Text = rptHeaders.branchDto.bankName;
                        txtBranchNameReciveAll.Text = rptHeaders.branchDto.branchName;
                        txtBranchAddressReciveAll.Text = rptHeaders.branchDto.branchAddress;
                    }

                }
                _outletCashDetilsDS = new OutletCashDetailsDS();

                txtPrintUserReciveAll.Text = rptHeaders.printUser;
                txtReportHeadingReciveAll.Text = rptHeaders.reportHeading;
                loadAllCashInformation();
                ObjRecieveAll.SetDataSource(_outletCashDetilsDS);
                viewer.crvReportViewer.ReportSource = ObjRecieveAll;
                viewer.ShowDialog(this.Parent);


            }
            else if (_callFrom == "paymentAll")

            {
                cROutletCashDetails repObj = new cROutletCashDetails();
                frmReportViewer viewer = new frmReportViewer();
                ReportHeaders rptHeaders = new ReportHeaders();

                rptHeaders = UtilityServices.getReportHeaders("Outlet Cash Payment Information");
                TextObject txtBankName = repObj.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = repObj.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = repObj.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = repObj.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = repObj.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                //TextObject txtPrintDate = repObj.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;

                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        if (!string.IsNullOrEmpty(rptHeaders.branchDto.bankName))
                        {
                            txtBankName.Text = rptHeaders.branchDto.bankName;
                        }
                        if (!string.IsNullOrEmpty(rptHeaders.branchDto.branchName))
                        {
                            txtBranchName.Text = rptHeaders.branchDto.branchName;
                        }
                        if (!string.IsNullOrEmpty(rptHeaders.branchDto.branchAddress))
                        {
                            txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
                        }
                    }

                }
                _outletCashDetilsDS = new OutletCashDetailsDS();
                txtPrintUser.Text = rptHeaders.printUser;
              //  txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-", "/");
                txtReportHeading.Text = rptHeaders.reportHeading;
                loadAllCashInformation();
                repObj.SetDataSource(_outletCashDetilsDS);
                viewer.crvReportViewer.ReportSource = repObj;
                viewer.ShowDialog(this.Parent);

            }
            else if (_callFrom == "all")
            {
                ReportHeaders rptHeaders = new ReportHeaders();
                cROutletAllCashInformation repObj = new cROutletAllCashInformation();
                rptHeaders = UtilityServices.getReportHeaders(this.Text);
                TextObject txtBankName = repObj.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = repObj.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = repObj.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = repObj.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = repObj.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = repObj.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;

                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        txtBankName.Text = rptHeaders.branchDto.bankName;
                        txtBranchName.Text = rptHeaders.branchDto.branchName;
                        txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
                    }

                }
                _outletCashDetilsDS = new OutletCashDetailsDS();


                txtPrintUser.Text = rptHeaders.printUser;
                txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-", "/");
                txtReportHeading.Text = rptHeaders.reportHeading;
                loadAll(); ;
                repObj.SetDataSource(_outletCashDetilsDS);
                viewer.crvReportViewer.ReportSource = repObj;
                viewer.ShowDialog(this.Parent);



            }

        }
        private void loadAllCashInformation()
        {

            _outletCashDetilsDS = new OutletCashDetailsDS();

            if (_cashTxnDetailsList != null)
            {
                foreach (CashTxnDetails cashDetailsItems in _cashTxnDetailsList)
                {
                    OutletCashDetailsDS.OutletCashDetailsDTRow newRow = _outletCashDetilsDS.OutletCashDetailsDT.NewOutletCashDetailsDTRow();
                    newRow.txnTime = cashDetailsItems.txnTime;
                    newRow.cashFlowType = cashDetailsItems.category;
                    newRow.amount = cashDetailsItems.amount;
                    newRow.txnUser = cashDetailsItems.txnUser;
                    _outletCashDetilsDS.OutletCashDetailsDT.AddOutletCashDetailsDTRow(newRow);
                }

            }
            _outletCashDetilsDS.AcceptChanges();

        }
        private void loadAll()
        {

            _outletCashDetilsDS = new OutletCashDetailsDS();

            if (_cashTxnDetailsList != null)
            {
                foreach (CashTxnDetails cashDetailsItems in _cashTxnDetailsList)
                {
                    OutletCashDetailsDS.OutletCashDetailsDTRow newRow = _outletCashDetilsDS.OutletCashDetailsDT.NewOutletCashDetailsDTRow();
                    newRow.txnTime = cashDetailsItems.txnTime;
                    newRow.cashFlowType = cashDetailsItems.cashFlowType;
                    newRow.amount = cashDetailsItems.amount;
                    newRow.txnUser = cashDetailsItems.txnUser;
                    newRow.category = cashDetailsItems.category;
                    _outletCashDetilsDS.OutletCashDetailsDT.AddOutletCashDetailsDTRow(newRow);
                }

            }
            _outletCashDetilsDS.AcceptChanges();

        }
        private void loadOutletCashDetailsInfo()
        {

            _outletCashDetilsDS = new OutletCashDetailsDS();


            if (_cashTxnDetailsList != null)
            {

                foreach (CashTxnDetails cashDetailsItems in _cashTxnDetailsList)
                {
                    OutletCashDetailsDS.OutletCashDetailsDTRow newRow = _outletCashDetilsDS.OutletCashDetailsDT.NewOutletCashDetailsDTRow();
                    newRow.txnTime = cashDetailsItems.txnTime;
                    newRow.amount = cashDetailsItems.amount;
                    newRow.txnUser = cashDetailsItems.txnUser;
                    _outletCashDetilsDS.OutletCashDetailsDT.AddOutletCashDetailsDTRow(newRow);
                }

            }
            _outletCashDetilsDS.AcceptChanges();

        }
    }

    public class CashTxnDetailsGrid
    {
        public string txnTime { get; set; }
        public string txnCategory { get; set; }
        public decimal amount { get; set; }
        public string txnUser { get; set; }
        //public long txnNo { get; set; }
        //public string isSystemTxn { get; set; }

        private CashTxnDetails _obj;

        public CashTxnDetailsGrid(CashTxnDetails obj)
        {
            _obj = obj;
        }

        public CashTxnDetails GetModel()
        {
            return _obj;
        }
    }

    public class AllCashTxnDetailsGrid
    {
        public string txnTime { get; set; }
        public string txnCategory { get; set; }
        public decimal amount { get; set; }
        public string txnType { get; set; }
        public string txnUser { get; set; }
        //public long txnNo { get; set; }
        //public string isSystemTxn { get; set; }        


        private CashTxnDetails _obj;

        public AllCashTxnDetailsGrid(CashTxnDetails obj)
        {
            _obj = obj;
        }

        public CashTxnDetails GetModel()
        {
            return _obj;
        }
    }
}