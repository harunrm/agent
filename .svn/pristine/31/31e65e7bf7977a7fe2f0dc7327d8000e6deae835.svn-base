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

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmTransactionProfile : Form
    {
        private List<TransactionProfileDto> _transactionProfileDtos;
        public bool _viewMode = false;
        private object _cellValue;

        public frmTransactionProfile()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            if (string.IsNullOrEmpty(txtAccountNumber.Text) || string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                return;
            }

            TransactionProfileEditServices transactionProfileEditServices = new TransactionProfileEditServices();
            _transactionProfileDtos = transactionProfileEditServices.GetTransactionProfileByAccountNo(txtAccountNumber.Text);

            if (_transactionProfileDtos != null && _transactionProfileDtos.Count != 0)
            {
                dgvTP.DataSource = null;
                dgvTP.DataSource = _transactionProfileDtos.Select(o => new TransactionProfileDtoGrid(o)
                {
                    limitRule = o.limitRule,
                    precedence = o.precedence.ToString(),
                    dailyNoOfTxn = (o.dailyNoOfTxn).ToString(),
                    dailySingleTxnAmount = o.dailySingleTxnAmount.ToString(),
                    dailyTotalTxnAmount = o.dailyTotalTxnAmount.ToString(),
                    monthlyNoOfTxn = o.monthlyNoOfTxn.ToString(),
                    monthlyTotalTxnAmount = o.monthlyTotalTxnAmount.ToString()
                }).ToList();
                SetDGVColHeader();
            }
            else
            {
                Message.showError("Account number not found!");
            }
        }

        private void SetDGVColHeader()
        {
            dgvTP.Columns[0].HeaderText = "Limit Rule";
            dgvTP.Columns[0].MinimumWidth = 270;
            dgvTP.Columns[0].DefaultCellStyle.BackColor = Color.LightBlue;
            dgvTP.Columns[0].ReadOnly = true;

            dgvTP.Columns[1].HeaderText = "Precedence";
            dgvTP.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTP.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            dgvTP.Columns[1].ReadOnly = true;
            dgvTP.Columns[1].Visible = false;

            dgvTP.Columns[2].HeaderText = "Daily No. of Txn";
            dgvTP.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTP.Columns[3].HeaderText = "Daily Single Txn Amount";
            dgvTP.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTP.Columns[4].HeaderText = "Daily Total Txn Amount";
            dgvTP.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTP.Columns[5].HeaderText = "Monthly No. of Txn";
            dgvTP.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTP.Columns[6].HeaderText = "Monthly Total Txn Amount";
            dgvTP.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public class TransactionProfileDtoGrid
        {
            //public long id { get; set; }
            //public string accountNo { get; set; }
            public string limitRule { get; set; }
            public string precedence { get; set; }
            public string dailyNoOfTxn { get; set; }
            public string dailySingleTxnAmount { get; set; }
            public string dailyTotalTxnAmount { get; set; }
            public string monthlyNoOfTxn { get; set; }
            public string monthlyTotalTxnAmount { get; set; }

            private TransactionProfileDto _obj;

            public TransactionProfileDtoGrid(TransactionProfileDto obj)
            {
                _obj = obj;
            }

            public TransactionProfileDto GetModel()
            {
                return _obj;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvTP.Rows.Count == 0)
            {
                MessageBox.Show("Here is nothing to save!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Do you want to save?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_transactionProfileDtos != null)
                {
                    try
                    {
                        TransactionProfileEditServices transactionProfileEditServices = new TransactionProfileEditServices();
                        string responseString = transactionProfileEditServices.saveTransactionProfileDtoList(_transactionProfileDtos);
                        Message.showInformation("Transaction Profile Save Successfully.");
                    }
                    catch (Exception ex)
                    {
                        Message.showError(ex.Message);
                    }
                }
            }
        }

        private void dgvTP_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try {
            switch (e.ColumnIndex)
            {
                case 0:
                    _transactionProfileDtos[e.RowIndex].limitRule = dgvTP.Rows[e.RowIndex].Cells[0].Value.ToString();
                    break;
                case 1:
                    if (dgvTP.Rows[e.RowIndex].Cells[1].Value == null)
                    {
                        _transactionProfileDtos[e.RowIndex].precedence = null;
                    }
                    else
                    {
                        _transactionProfileDtos[e.RowIndex].precedence = long.Parse(dgvTP.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                    break;
                case 2:
                    try
                    {
                        if (dgvTP.Rows[e.RowIndex].Cells[2].Value == null)
                        {
                            _transactionProfileDtos[e.RowIndex].dailyNoOfTxn = null;
                        }
                        else
                        {
                            _transactionProfileDtos[e.RowIndex].dailyNoOfTxn = long.Parse(dgvTP.Rows[e.RowIndex].Cells[2].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        dgvTP.Rows[e.RowIndex].Cells[2].Value = _transactionProfileDtos[e.RowIndex].dailyNoOfTxn;
                        Message.showError(ex.Message);
                    }
                    break;

                case 3:
                    try
                    {
                        if (dgvTP.Rows[e.RowIndex].Cells[3].Value == null)
                        {
                            _transactionProfileDtos[e.RowIndex].dailySingleTxnAmount = null;
                        }
                        else
                        {
                            if (
                                    _cellValue != null
                                &&
                                    !string.IsNullOrEmpty(_cellValue.ToString())
                                )
                            {
                                _transactionProfileDtos[e.RowIndex].dailySingleTxnAmount = decimal.Parse(dgvTP.Rows[e.RowIndex].Cells[3].Value.ToString());
                            }
                            else
                            {
                                dgvTP.Rows[e.RowIndex].Cells[3].Value = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dgvTP.Rows[e.RowIndex].Cells[3].Value = _transactionProfileDtos[e.RowIndex].dailySingleTxnAmount;
                        Message.showError(ex.Message);
                    }
                    break;


                case 4:
                    try
                    {
                        if (dgvTP.Rows[e.RowIndex].Cells[4].Value == null)
                        {
                            _transactionProfileDtos[e.RowIndex].dailyTotalTxnAmount = null;
                        }
                        else
                        {
                            if (
                                   _cellValue != null
                               &&
                                   !string.IsNullOrEmpty(_cellValue.ToString())
                               )
                            {
                                _transactionProfileDtos[e.RowIndex].dailyTotalTxnAmount = decimal.Parse(dgvTP.Rows[e.RowIndex].Cells[4].Value.ToString());
                            }
                            else
                            {
                                dgvTP.Rows[e.RowIndex].Cells[4].Value = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dgvTP.Rows[e.RowIndex].Cells[4].Value = _transactionProfileDtos[e.RowIndex].dailyTotalTxnAmount;
                        Message.showError(ex.Message);
                    }
                    break;
                case 5:
                    try
                    {
                        if (dgvTP.Rows[e.RowIndex].Cells[5].Value == null)
                        {
                            _transactionProfileDtos[e.RowIndex].monthlyNoOfTxn = null;
                        }
                        else
                        {
                            _transactionProfileDtos[e.RowIndex].monthlyNoOfTxn = long.Parse(dgvTP.Rows[e.RowIndex].Cells[5].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        dgvTP.Rows[e.RowIndex].Cells[4].Value = _transactionProfileDtos[e.RowIndex].monthlyNoOfTxn;
                        Message.showError(ex.Message);
                    }
                    break;
                case 6:
                    try
                    {
                        if (dgvTP.Rows[e.RowIndex].Cells[6].Value == null)
                        {
                            _transactionProfileDtos[e.RowIndex].monthlyTotalTxnAmount = null;
                        }
                        else
                        {
                            if (
                                  _cellValue != null
                              &&
                                  !string.IsNullOrEmpty(_cellValue.ToString())
                              )
                            {
                                _transactionProfileDtos[e.RowIndex].monthlyTotalTxnAmount = decimal.Parse(dgvTP.Rows[e.RowIndex].Cells[6].Value.ToString());
                            }
                            else
                            {
                                dgvTP.Rows[e.RowIndex].Cells[6].Value = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dgvTP.Rows[e.RowIndex].Cells[6].Value = _transactionProfileDtos[e.RowIndex].monthlyTotalTxnAmount;
                        Message.showError(ex.Message);
                    }
                    break;
            }
            //}
            //catch(Exception ex)
            //{
            //    dgvTP.CancelEdit();
            //    Message.showError(ex.Message);

            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel the edit?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                search();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                dgvTP.DataSource = null;
                dgvTP.Rows.Clear();
                txtAccountNumber.Text = "";
            }
            catch { }
        }

        private void frmTransactionProfile_Load(object sender, EventArgs e)
        {
            if (_viewMode == true)
            {
                dgvTP.ReadOnly = true;
                btnSave.Visible = false;
            }
        }

        private void frmTransactionProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void dgvTP_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                _cellValue = dgvTP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
            catch { }
        }
    }
}