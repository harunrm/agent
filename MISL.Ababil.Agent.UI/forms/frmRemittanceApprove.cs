using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Validation;
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
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmRemittanceApprove : Form
    {
        private AmountInWords _amountInWords = new AmountInWords();
        public Remittance _remittance = new Remittance();
        private bool _IsDocFirstRun = true;

        public frmRemittanceApprove()
        {
            InitializeComponent();
            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtCorrectionAmount, "Correction Amount", (long)ValidationType.Numeric + (long)ValidationType.Positive, false);
            ValidationManager.ConfigureValidation(this, txtCorrectionAmount, "Correction Amount", (long)ValidationType.TextWithLengthRange, false, false, 1, 11);
            //____following field(s) can be null; ignored unless non-mandatory field validation returns true even when these are null____//
            //           
            //
        }

        private void frmRemittanceFirstApproval_Load(object sender, EventArgs e)
        {
            txtRefranceNumber.Text = _remittance.referanceNumber;
            txtAgentName.Text = SessionInfo.username;
            txtExchangeHouseName.Text = _remittance.exchangeHouse.companyName;
            txtOutletName.Text = _remittance.outletName;
            txtExpectedAmount.Text = _remittance.expectedAmount.ToString("N", new CultureInfo("BN-BD"));

            double decValue;
            if (double.TryParse(txtExpectedAmount.Text, out decValue))
            {
                txtExpectedAmount.Text = decValue.ToString("N", new CultureInfo("BN-BD"));
            }
            lblExpectedAmountInWords.Text = _amountInWords.ToWords(decValue.ToString().Replace(",", ""));

            double decValue3;
            string str2 = "";
            if (double.TryParse(txtCorrectionAmount.Text, out decValue3))
            {
                str2 = decValue3.ToString("N", new CultureInfo("BN-BD"));
            }
            lblCorrectedAmountInWords.Text = _amountInWords.ToWords(str2.Replace(",", ""));


            if (_remittance.remittanceStatus == RemittanceStatus.ApprovedFirst)
            {
                lblApprover.Text = "Request Approval";
            }
            else
            {
                lblApprover.Text = "Request Verification";
            }

            if (_remittance.remittanceAmount == 0)
            {
                if (double.TryParse(txtExpectedAmount.Text, out decValue))
                {
                    txtCorrectionAmount.Text = decValue.ToString("N", new CultureInfo("BN-BD"));
                }
                lblExpectedAmountInWords.Text = _amountInWords.ToWords(decValue.ToString().Replace(",", ""));

                double decValue2;
                string str = "";
                if (double.TryParse(txtCorrectionAmount.Text, out decValue2))
                {
                    str = decValue2.ToString("N", new CultureInfo("BN-BD"));
                }
                lblCorrectedAmountInWords.Text = _amountInWords.ToWords(str.Replace(",", ""));
            }
            else
            {
                if (double.TryParse(_remittance.remittanceAmount.ToString(), out decValue))
                {
                    txtCorrectionAmount.Text = decValue.ToString("N", new CultureInfo("BN-BD"));
                }
                double decValue2;
                string str = "";
                if (double.TryParse(txtCorrectionAmount.Text, out decValue2))
                {
                    str = decValue2.ToString("N", new CultureInfo("BN-BD"));
                }
                lblCorrectedAmountInWords.Text = _amountInWords.ToWords(str.Replace(",", ""));
            }

            if (_remittance.remittanceStatus == RemittanceStatus.Submitted || _remittance.remittanceStatus == RemittanceStatus.ApprovedFirst)
            {
                btnDocuments.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getRemittanceByRefrenceNumber(Remittance remitance)
        {
            RemittanceCom remitancecom = new RemittanceCom();
            _remittance = remitancecom.getListOfRemittance(_remittance)[0];
        }

        private void btnSendToSecondApprover_Click(object sender, EventArgs e)
        {
            btnSendToSecondApprover.Enabled = false;

            if (!ValidationManager.ValidateForm(this))
            {
                btnSendToSecondApprover.Enabled = true;
                return;
            }

            if (txtCorrectionAmount.Text != "")
            {
                _remittance.remittanceAmount = decimal.Parse(txtCorrectionAmount.Text);
            }
            else
            {
                double decValue;
                if (double.TryParse(txtCorrectionAmount.Text, out decValue))
                {
                    txtCorrectionAmount.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                    _remittance.remittanceAmount = decimal.Parse(txtCorrectionAmount.Text);
                }
                double decValue2;
                string str = "";
                if (double.TryParse(txtCorrectionAmount.Text, out decValue2))
                {
                    str = decValue2.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                }
                lblCorrectedAmountInWords.Text = _amountInWords.ToWords(str.Replace(",", ""));
            }

            if (rdobtnNeedCorrection.Checked == true)
            {
                _remittance.remittanceStatus = RemittanceStatus.Corrected;
                if (string.IsNullOrEmpty(txtComments.Text) || string.IsNullOrWhiteSpace(txtComments.Text))
                {
                    Message.showError("Remarks not found!");
                    return;
                }
                else
                {
                    _remittance.comments = txtComments.Text;
                }
            }
            else if (rdobtnReject.Checked == true)
            {
                _remittance.remittanceStatus = RemittanceStatus.Rejected;
            }
            else if (rdobtnApproveSave.Checked == true)
            {
                if (_remittance.remittanceStatus == RemittanceStatus.ApprovedFirst)
                {
                    _remittance.remittanceStatus = RemittanceStatus.Approved;
                    _remittance.secondApprover = SessionInfo.username;
                    _remittance.secondApprovalDateTime = UtilityServices.GetLongDate(SessionInfo.currentDate).ToString();
                }
                else
                {
                    _remittance.remittanceStatus = RemittanceStatus.ApprovedFirst;
                    _remittance.firstApprover = SessionInfo.username;
                    _remittance.firstApprovalDateTime = UtilityServices.GetLongDate(SessionInfo.currentDate).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please select an option!");
                btnSendToSecondApprover.Enabled = true;
                return;
            }

            string result = Message.showConfirmation("Do you want to process?");
            if (result == "yes")
            {
                try
                {
                    RemittanceServices remittanceServices = new RemittanceServices();

                    ProgressUIManager.ShowProgress(this);
                    string responseString = remittanceServices.saveRemittance(_remittance);
                    ProgressUIManager.CloseProgress();

                    Message.showInformation("Process executed successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    ProgressUIManager.CloseProgress();
                    btnSendToSecondApprover.Enabled = true;
                    Message.showError(ex.Message);
                }
            }

            btnSendToSecondApprover.Enabled = true;
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            frmDocument frmDocument = new frmDocument((Int32)_remittance.documentId, ActionType.view);
            frmDocument.Show();

        }

        private void btnRequestDetails_Click(object sender, EventArgs e)
        {
            frmRemittanceAgentRequest objfrmremAgentRequest = new frmRemittanceAgentRequest();
            objfrmremAgentRequest._remittance = _remittance;
            objfrmremAgentRequest._IsFromAdmin = true;
            objfrmremAgentRequest.changeControlsReadOnly(true);
            objfrmremAgentRequest.Show();
        }

        private void rdobtnNeedCorrection_CheckedChanged(object sender, EventArgs e)
        {
            txtComments.Enabled = rdobtnNeedCorrection.Checked;
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            if (_remittance.remittanceStatus == RemittanceStatus.ApprovedFirst)
            {
                frmDocument frm = new frmDocument((Int32)_remittance.bankdocumentId, ActionType.view);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //remittance.bankdocumentId = long.Parse(frm.retrnMsg);
                }
                return;
            }

            RemittanceCom remCom = new RemittanceCom();
            List<DocumentType> docTypes = remCom.getRemittanceDocumentTypeList();

            if (docTypes != null)
            {
                if (docTypes.Count == 0)
                {
                    Message.showConfirmation("Document types not found!");
                    return;
                }
            }

            if (_IsDocFirstRun == true)
            {
                frmDocument frm = new frmDocument((Int32)0, ActionType.update, docTypes);

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _remittance.bankdocumentId = long.Parse(frm.retrnMsg);
                    _IsDocFirstRun = false;
                }
            }
            else
            {
                frmDocument frm = new frmDocument((Int32)_remittance.bankdocumentId, ActionType.update, docTypes);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _remittance.bankdocumentId = long.Parse(frm.retrnMsg);
                }
            }
        }

        private void txtCorrectionAmount_Leave(object sender, EventArgs e)
        {
            double decValue;
            if (double.TryParse(txtCorrectionAmount.Text, out decValue))
            {
                txtCorrectionAmount.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                _remittance.remittanceAmount = decimal.Parse(txtCorrectionAmount.Text);
            }
            double decValue2;
            string str = "";
            if (double.TryParse(txtCorrectionAmount.Text, out decValue2))
            {
                str = decValue2.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
            lblCorrectedAmountInWords.Text = _amountInWords.ToWords(str.Replace(",", ""));
        }

        private void txtCorrectionAmount_TextChanged(object sender, EventArgs e)
        {
            double decValue2;
            string str = "";
            if (double.TryParse(txtCorrectionAmount.Text, out decValue2))
            {
                str = decValue2.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
            lblCorrectedAmountInWords.Text = _amountInWords.ToWords(str.Replace(",", ""));
        }
    }
}