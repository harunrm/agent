using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmOutletCashInfo : MetroForm
    {
        private Packet _packet = null;
        private OutletCashSummaryDto _outletCashSummaryDto = null;
        private OutletCashSumReqDto _outletCashSumReqDto = null;
        OutletCashInfoDS _outletCashInfoDS;

        public frmOutletCashInfo(Packet packet, OutletCashSumReqDto outletCashSumReqDto)
        {
            _packet = packet;
            _outletCashSumReqDto = outletCashSumReqDto;

            InitializeComponent();
            preparedUI();

            FillComponentWithObjectValue();
        }

        private void preparedUI()
        {
            SetupDataLoad();
            SetupComponents();
        }

        private void SetupComponents()
        {

        }

        private void SetupDataLoad()
        {

        }

        private void FillComponentWithObjectValue()
        {
            if (_outletCashSumReqDto != null)
            {
                LoadOutletCashSummary(_outletCashSumReqDto);
                if (_outletCashSummaryDto != null)
                {
                    lblOutletName.Text = _outletCashSummaryDto.outletName;
                    lblOutletAddress.Text = _outletCashSummaryDto.businessAddress.addressLineOne;
                    lblOutletMobileNo.Text = _outletCashSummaryDto.mobileNumber;
                    lblOutletPreviousDayBalance.Text = _outletCashSummaryDto.previousDayBalance.ToString();
                    lblOutletDate.Text = _outletCashSumReqDto.informationDate.ToString("dd-MM-yyyy").Replace("-", "/");


                    for (int i = 0; i < _outletCashSummaryDto.receiveCashSummaryDtos.Count; i++)
                    {
                        dgvReceived.Rows.Add("", _outletCashSummaryDto.receiveCashSummaryDtos[i].itemName, _outletCashSummaryDto.receiveCashSummaryDtos[i].balance, "", "Details");
                    }

                    for (int i = 0; i < _outletCashSummaryDto.paymentCashSummaryDtos.Count; i++)
                    {
                        dgvPayment.Rows.Add("", _outletCashSummaryDto.paymentCashSummaryDtos[i].itemName, _outletCashSummaryDto.paymentCashSummaryDtos[i].balance, "", "Details");
                    }

                    ////dgvReceived.DataSource = _outletCashSummaryDto.receiveCashSummaryDtos.Select(o => new CashSummaryGrid(o) { blank0 = "", itemName = o.itemName, balance = o.balance, blank1 = "" }).ToList();
                    //////details button
                    ////{
                    ////    DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
                    ////    dataGridViewButtonColumn.HeaderText = "Details";
                    ////    dgvReceived.Columns.Add(dataGridViewButtonColumn);
                    ////}

                    ////dgvPayment.DataSource = _outletCashSummaryDto.paymentCashSummaryDtos.Select(o => new CashSummaryGrid(o) { itemName = o.itemName, balance = o.balance }).ToList();                    
                    //////details button
                    ////{
                    ////    DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
                    ////    dataGridViewButtonColumn.HeaderText = "Details";
                    ////    dgvPayment.Columns.Add(dataGridViewButtonColumn);
                    ////}

                    decimal receivedTotal = CalcTotalByDataGridView(dgvReceived);
                    decimal paymentTotal = CalcTotalByDataGridView(dgvPayment);
                    lblReceivedTotalValue.Text = receivedTotal.ToString();
                    lblPaymentTotalValue.Text = paymentTotal.ToString();
                    lblCurrentBalanceValue.Text = (_outletCashSummaryDto.previousDayBalance + receivedTotal - paymentTotal).ToString();
                }
            }
        }

        private void LoadOutletCashSummary(OutletCashSumReqDto outletCashSumReqDto)
        {
            CashInformationService cashInformationService = new CashInformationService();
            _outletCashSummaryDto = cashInformationService.GetOutletCashSummary(outletCashSumReqDto);
        }

        private decimal CalcTotalByDataGridView(DataGridView dgv)
        {
            decimal total = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[2].Value != null)
                    total += (decimal)dgv.Rows[i].Cells[2].Value;
            }
            return total;
        }

        private void dgvReceived_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) //details
            {
                CashInformationService cashInformationService = new CashInformationService();
                List<CashTxnDetails> cashTxnDetailsList = cashInformationService.GetOutletCashInfoDetails(_outletCashSumReqDto.outletId, dgvReceived.Rows[e.RowIndex].Cells[1].Value.ToString(), _outletCashSumReqDto.informationDate);

                Packet packet = new Packet();
                packet.actionType = FormActionType.View;
                packet.intentType = IntentType.Request;

                frmOutletCashInfoDetails frm = new frmOutletCashInfoDetails(packet, "receiveDetails", cashTxnDetailsList, false);
                frm.Text = dgvReceived.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.ShowDialog();
            }
        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) //details
            {
                CashInformationService cashInformationService = new CashInformationService();
                List<CashTxnDetails> cashTxnDetailsList = cashInformationService.GetOutletCashInfoDetails(_outletCashSumReqDto.outletId, dgvPayment.Rows[e.RowIndex].Cells[1].Value.ToString(), _outletCashSumReqDto.informationDate);

                Packet packet = new Packet();
                packet.actionType = FormActionType.View;
                packet.intentType = IntentType.Request;

                frmOutletCashInfoDetails frm = new frmOutletCashInfoDetails(packet, "paymentDetails", cashTxnDetailsList, false);
               
                frm.ShowDialog();
            }
        }

        private void lnkBtnViewAllReceived_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CashInformationService cashInformationService = new CashInformationService();
            List<CashTxnDetails> cashTxnDetailsList = cashInformationService.GetOutletCashInfoWithAllDetails
            (
                _outletCashSumReqDto.outletId, CashFlowType.Receive, _outletCashSumReqDto.informationDate
            );

            Packet packet = new Packet();
            packet.actionType = FormActionType.View;
            packet.intentType = IntentType.Request;

            frmOutletCashInfoDetails frm = new frmOutletCashInfoDetails(packet, "receiveAll", cashTxnDetailsList, false);
            frm.ShowDialog();
        }

        private void lnkBtnViewAllPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CashInformationService cashInformationService = new CashInformationService();
            List<CashTxnDetails> cashTxnDetailsList = cashInformationService.GetOutletCashInfoWithAllDetails(_outletCashSumReqDto.outletId, CashFlowType.Payment, _outletCashSumReqDto.informationDate);

            Packet packet = new Packet();
            packet.actionType = FormActionType.View;
            packet.intentType = IntentType.Request;

            frmOutletCashInfoDetails frm = new frmOutletCashInfoDetails(packet, "paymentAll", cashTxnDetailsList, false);
            frm.ShowDialog();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            CashInformationService cashInformationService = new CashInformationService();
            List<CashTxnDetails> cashTxnDetailsList = cashInformationService.GetOutletCashInfoWithAllViewDetails(_outletCashSumReqDto.outletId, _outletCashSumReqDto.informationDate);

            Packet packet = new Packet();
            packet.actionType = FormActionType.View;
            packet.intentType = IntentType.Request;

            frmOutletCashInfoDetails frm = new frmOutletCashInfoDetails(packet, "all", cashTxnDetailsList, true);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            cROutletCashInfo repObj = new cROutletCashInfo();
            frmReportViewer viewer = new frmReportViewer();
            ReportHeaders rptHeaders = new ReportHeaders();
            rptHeaders = UtilityServices.getReportHeaders("Outlet Cash Information");

            TextObject txtBankName = repObj.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
            TextObject txtBranchName = repObj.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
            TextObject txtBranchAddress = repObj.ReportDefinition.ReportObjects["txtBankBranchAddress"] as TextObject;
            TextObject txtReportHeading = repObj.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
            TextObject txtPrintUser = repObj.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
            TextObject txtPrintDate = repObj.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
            TextObject txtPreviousDayBalance = repObj.ReportDefinition.ReportObjects["txtPreviousDayBalance"] as TextObject;
            TextObject txtCurrentBalance = repObj.ReportDefinition.ReportObjects["txtCurrentBalance"] as TextObject;
            if (rptHeaders != null)
            {
                if (rptHeaders.branchDto != null)
                {
                    txtBankName.Text = rptHeaders.branchDto.bankName;
                    txtBranchName.Text = rptHeaders.branchDto.branchName;
                    txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
                }
                txtReportHeading.Text = rptHeaders.reportHeading;
                txtPrintUser.Text = rptHeaders.printUser;
                txtPrintDate.Text = rptHeaders.printDate.ToString("dd-MM-yyyy").Replace("-","/");
                txtPreviousDayBalance.Text = _outletCashSummaryDto.previousDayBalance.ToString("N", new CultureInfo("BN-BD"));
                decimal receivedTotal = CalcTotalByDataGridView(dgvReceived);
                decimal paymentTotal = CalcTotalByDataGridView(dgvPayment);
                txtCurrentBalance.Text = (_outletCashSummaryDto.previousDayBalance + receivedTotal - paymentTotal).ToString("N", new CultureInfo("BN-BD"));
            }
            LoadAccountMonitoring();

            repObj.SetDataSource(_outletCashInfoDS);
            viewer.crvReportViewer.ReportSource = repObj;
            viewer.ShowDialog(this.Parent);
        }

        private void LoadAccountMonitoring()
        {
            _outletCashInfoDS = new OutletCashInfoDS();

            //try
            //{
            if (_outletCashSummaryDto.receiveCashSummaryDtos != null)
            {
                foreach (CashSummaryDto cashSummaryDto in _outletCashSummaryDto.receiveCashSummaryDtos)
                {
                    OutletCashInfoDS.OutletCashRecieveDTRow newRow = _outletCashInfoDS.OutletCashRecieveDT.NewOutletCashRecieveDTRow();

                    newRow.itemName = cashSummaryDto.itemName;
                    newRow.balance = cashSummaryDto.balance;
                    newRow.noOfTxn = cashSummaryDto.noOfTxn;
                    _outletCashInfoDS.OutletCashRecieveDT.AddOutletCashRecieveDTRow(newRow);

                }
                foreach (CashSummaryDto cashSummaryDto in _outletCashSummaryDto.paymentCashSummaryDtos)
                {
                    OutletCashInfoDS.OutletCashPaymentDTRow newRow = _outletCashInfoDS.OutletCashPaymentDT.NewOutletCashPaymentDTRow();

                    newRow.itemName = cashSummaryDto.itemName;
                    newRow.balance = cashSummaryDto.balance;
                    //newRow.noOfTxn = cashSummaryDto.noOfTxn;
                    _outletCashInfoDS.OutletCashPaymentDT.AddOutletCashPaymentDTRow(newRow);

                }
            }
            _outletCashInfoDS.AcceptChanges();
            //}
            //catch (Exception)
            //{
            //    //ignored
            //}
        }

        private void frmOutletCashInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }



    public class CashSummaryGrid
    {
        public string blank0 { get; set; }
        public string itemName { get; set; }
        public decimal balance { get; set; }
        public string blank1 { get; set; }

        //public long noOfTxn { get; set; }

        private CashSummaryDto _obj;

        public CashSummaryGrid(CashSummaryDto obj)
        {
            _obj = obj;
        }

        public CashSummaryDto GetModel()
        {
            return _obj;
        }
    }
}
