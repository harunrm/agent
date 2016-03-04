using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Report;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCashInformation : Form
    {
        private CashInformationDto cashInformation;
        private decimal totalReceived = 0;
        private decimal totalPayment = 0;

        public frmCashInformation()
        {
            InitializeComponent();
            dataLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataLoad()
        {
            ProgressUIManager.ShowProgress(this);
            CashInformationService cashInformationService = new CashInformationService();
            try
            {
                totalReceived = 0;
                totalPayment = 0;
                cashInformation = cashInformationService.GetCashInformationList();
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }

            ProgressUIManager.CloseProgress();

            if (cashInformation != null)
            {
                //DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                //buttonColumn.Text = "Open";
                //buttonColumn.UseColumnTextForButtonValue = true;
                //dgvCashInformation.Columns.Add(buttonColumn);

                lblOutlet.Text = "Outlet : " + cashInformation.outletName;
                txtPreviousDayBalance.Text = cashInformation.previousDayBalance.ToString();

                dgvCashInformation.DataSource = null;
                dgvCashInformation.DataSource =
                    cashInformation.cashInfoDetailsDtos.Select(
                        o =>
                            new CashInfoDetailsGrid(o)
                            {
                                txnDate = UtilityServices.getDateFromLong(o.txnDate).ToString("hh:mm:ss tt") ?? "",
                                receiveAmount = o.receiveAmount ?? 0,
                                paymentAmount = o.paymentAmount ?? 0,
                                purpose = o.purpose

                            }).ToList();

                dgvCashInformation.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCashInformation.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                FillRowHeaderAndCalculateSum();


                try
                {
                    dgvCashInformation.Columns["txnDate"].Width = 110;
                    dgvCashInformation.Columns["receiveAmount"].Width = 130;
                    dgvCashInformation.Columns["paymentAmount"].Width = 130;
                    dgvCashInformation.Columns["purpose"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch
                {
                }

                dgvCashInformation.Columns["txnDate"].HeaderText = "Time";
                dgvCashInformation.Columns["txnDate"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dgvCashInformation.Columns["receiveAmount"].HeaderText = "Receive Amount";
                dgvCashInformation.Columns["paymentAmount"].HeaderText = "Payment Amount";
                dgvCashInformation.Columns["purpose"].HeaderText = "Purpose";



                repositionControls();
            }
            else
            {
                ProgressUIManager.CloseProgress();
                btnRefresh.Enabled = true;
                Message.showInformation("No applications available");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataLoad();
        }

        private void FillRowHeaderAndCalculateSum()
        {
            for (int i = 0; i < dgvCashInformation.Rows.Count; i++)
            {
                dgvCashInformation.Rows[i].HeaderCell.Value = String.Format("{0}", dgvCashInformation.Rows[i].Index + 1);
                totalReceived += decimal.Parse(dgvCashInformation.Rows[i].Cells[1].Value.ToString());
                totalPayment += decimal.Parse(dgvCashInformation.Rows[i].Cells[2].Value.ToString());
            }
            txtTotalReceived.Text = totalReceived.ToString();
            txtTotalPayment.Text = totalPayment.ToString();
            txtCashInHand.Text = (totalReceived - totalPayment + cashInformation.previousDayBalance).ToString();
        }

        public class CashInfoDetailsGrid
        {
            public string txnDate { get; set; }
            public decimal? receiveAmount { get; set; }
            public decimal? paymentAmount { get; set; }
            public string purpose { get; set; }

            private cashInfoDetailsDtos _obj;

            public CashInfoDetailsGrid(cashInfoDetailsDtos obj)
            {
                _obj = obj;
            }

            public cashInfoDetailsDtos GetModel()
            {
                return _obj;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmAgentDayEndSummary objfrmAgentDayEndSummary = new frmAgentDayEndSummary();
            //showReport
            //objfrmAgentDayEndSummary.showReportFromCashInformation();
            objfrmAgentDayEndSummary.showReportNull();
        }

        private void frmCashInformation_ResizeEnd(object sender, EventArgs e)
        {
            //repositionControls();
        }

        private void dgvCashInformation_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            repositionControls();
        }


        private void repositionControls()
        {
            try
            {
                txtTotalReceived.Left = dgvCashInformation.RowHeadersWidth + dgvCashInformation.Columns["txnDate"].Width;
                txtTotalPayment.Left = dgvCashInformation.RowHeadersWidth + dgvCashInformation.Columns["txnDate"].Width + dgvCashInformation.Columns["receiveAmount"].Width;
                txtTotalReceived.Width = dgvCashInformation.Columns["receiveAmount"].Width;
                txtTotalPayment.Width = dgvCashInformation.Columns["paymentAmount"].Width;
                txtCashInHand.Width = dgvCashInformation.Columns["receiveAmount"].Width;
                txtCashInHand.Left = txtTotalReceived.Left;
                lblTotal.Left = txtTotalReceived.Left - lblTotal.Width - 2;
                lblCashInHand.Left = txtTotalReceived.Left - lblCashInHand.Width - 2;
            }
            catch { }
        }

        private void frmCashInformation_Resize(object sender, EventArgs e)
        {
            repositionControls();
        }

        private void frmCashInformation_Load(object sender, EventArgs e)
        {

        }
    }
}