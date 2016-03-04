using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
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
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmSetFingerprint : Form
    {
        CustomerAccountDto objCustomerAccDTO = new CustomerAccountDto();
        //CustomerInformation _customerInfo = new CustomerInformation();
        CustomerServices objCustomerServices = new CustomerServices();
        int columnLoaded = 0;
        public frmSetFingerprint()
        {
            InitializeComponent();

            InitializeSetupData();
        }
        private void InitializeSetupData()
        {
            txtAccountNo.MaxLength = CommonRules.accountNumberDigitCount;
            //addCaptureButtons();
        }
        private void addCaptureButtons()
        {
            DataGridViewButtonColumn buttonCapture = new DataGridViewButtonColumn();
            buttonCapture.Text = "Capture";
            buttonCapture.UseColumnTextForButtonValue = true;
            dgvOwnerInfo.Columns.Add(buttonCapture);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            showCustomerData();
        }
        private void showCustomerData()
        {
            string accNo = txtAccountNo.Text.Trim();
            if (accNo != "")
            {
                objCustomerAccDTO = new CustomerAccountDto();
                try
                {
                    objCustomerAccDTO = objCustomerServices.GetCustomerAccountDtoByAcc(accNo);
                    if (objCustomerAccDTO.customerInformation != null)
                    {
                        lblCustomerName.Text = objCustomerAccDTO.customerInformation.title;
                        lblMobileNo.Text = objCustomerAccDTO.customerInformation.mobileNumber;
                        lblAddress.Text = UtilityServices.getAddressInString(objCustomerAccDTO.customerInformation.presentAddress);

                        dgvOwnerInfo.DataSource = objCustomerAccDTO.customerInformation.owners.Select(o => new CustomerIndividualGrid(o) { FirstName = o.individualInformation.firstName, LastName = o.individualInformation.lastName }).ToList();
                        colorFingerDataRows(objCustomerAccDTO.customerInformation);
                        if (columnLoaded == 0)
                        {
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.Text = "Capture";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            dgvOwnerInfo.Columns.Add(buttonColumn);
                            columnLoaded = 1;
                        }
                        else
                        {
                            dgvOwnerInfo.Columns[0].DisplayIndex = 2;
                        }
                        txtAccOperated.Text = objCustomerAccDTO.customerInformation.owners.Count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            string result = Message.showConfirmation("Are you sure to save?");

            if (result == "yes")
            {
                objCustomerAccDTO.numberOfOperator = (txtAccOperated.Text != "") ? Convert.ToInt16(txtAccOperated.Text.Trim()) : 0;
                if (validateData(objCustomerAccDTO))
                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        string retrnMsg = objCustomerServices.saveCustomerAccDTO(objCustomerAccDTO);
                        ProgressUIManager.CloseProgress();

                        Message.showInformation(retrnMsg);
                        clearAllControls();
                    }
                    catch (Exception ex)
                    {
                        ProgressUIManager.CloseProgress();
                        btnSave.Enabled = true;
                        Message.showError(ex.Message);
                    }
            }

            btnSave.Enabled = true;
        }

        private bool validateData(CustomerAccountDto objCustomerAccountDto)
        {
            int ownerWithFingerData = 0;
            for (int i = 0; i < dgvOwnerInfo.Rows.Count; i++)
            {
                if (objCustomerAccountDto.customerInformation.owners[i].fingerDatas != null)
                {
                    if (objCustomerAccountDto.customerInformation.owners[i].fingerDatas.Count > 0)
                        ownerWithFingerData += 1;
                }
            }
            if (ownerWithFingerData < 1)
            {
                Message.showError("Capture atleast one owners fingerprint");
                return false;
            }
            if (ownerWithFingerData < objCustomerAccountDto.numberOfOperator)
            {
                Message.showError("Number of operators cannot be greater than number of owners with fingerprints.");
                return false;
            }
            return true;
        }

        private void dgvOwnerInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string individualName = "";
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (objCustomerAccDTO.customerInformation.owners[e.RowIndex].individualInformation != null && objCustomerAccDTO.customerInformation.owners[e.RowIndex].individualInformation.id != 0)
                    individualName = objCustomerAccDTO.customerInformation.owners[e.RowIndex].individualInformation.firstName + " " + objCustomerAccDTO.customerInformation.owners[e.RowIndex].individualInformation.lastName;

                frmFingerprintCapture objFrmFinger = new frmFingerprintCapture(individualName);
                DialogResult dr = objFrmFinger.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    objCustomerAccDTO.customerInformation.owners[e.RowIndex].fingerDatas = objFrmFinger.bioMetricTemplates;
                    objCustomerAccDTO.customerInformation.owners[e.RowIndex].capture = true;
                    colorFingerDataRows(objCustomerAccDTO.customerInformation);
                }
            }
        }
        private void colorFingerDataRows(CustomerInformation customerInfo)
        {
            if (customerInfo.owners != null)
            {
                for (int i = 0; i < customerInfo.owners.Count; i++)
                {
                    //if (customerInfo.owners[i].fingerDatas != null)
                    //{
                    //    if (customerInfo.owners[i].fingerDatas.Count != 0)
                    //    {
                    //        dgvOwnerInfo.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    //    }
                    //}
                    if (customerInfo.owners[i].capture == true)
                    {
                        dgvOwnerInfo.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                showCustomerData();
            //else
            //{
            //    if (e.KeyData == (Keys.Control | Keys.V) || e.KeyData == Keys.Back || e.KeyData == Keys.Tab || e.KeyData == Keys.Decimal || (e.KeyValue >= 48 && e.KeyValue <= 57))
            //    {
            //        //e.Handled = false;
            //        //Message.showInformation(e.KeyValue.ToString());
            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //    //base.OnKeyDown(e);
            //}
        }
        private void clearAllControls()
        {
            objCustomerAccDTO = new CustomerAccountDto();
            txtAccountNo.Text = string.Empty;
            lblCustomerName.Text = string.Empty;
            lblMobileNo.Text = string.Empty;
            lblAddress.Text = string.Empty;
            dgvOwnerInfo.DataSource = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllControls();
        }

        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtAccountNo_Leave(object sender, EventArgs e)
        {
            showCustomerData();
        }

        private void txtAccOperated_Leave(object sender, EventArgs e)
        {
            int individualCount = dgvOwnerInfo.Rows.Count;
            int operatorCount = (txtAccOperated.Text != "") ? Convert.ToInt32(txtAccOperated.Text.Trim()) : 0;
            if (operatorCount < 0)
            {
                if (individualCount > 0)
                {
                    MessageBox.Show("Number of operators cannot be negative.");
                    txtAccOperated.Focus();
                }
            }
            else
            {
                if (operatorCount > individualCount)
                {
                    MessageBox.Show("Number of operators cannot be greater than number of owners.");
                    txtAccOperated.Focus();
                }
            }
        }
    }
}
