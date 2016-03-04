using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Services;
using MetroFramework.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmBalanceInquiry : MetroForm
    {
        private GUI _gui = new GUI();
        private AmountInWords _amountInWords = new AmountInWords();
        private string _accountHolderFingerPrint;
        private TransactionService _service = new TransactionService();
        private ConsumerServices _consumerService = new ConsumerServices();
        private ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();

        public frmBalanceInquiry()
        {
            InitializeComponent();
            bio.Visible = false;
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblBalance.Text = "";
            //ConfigureValidation();
            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);
            _gui.Config(ref txtConsumerAccount, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.RefreshOwnerForm();
            _gui.FocusControl(txtConsumerAccount);
        }

        private void ConfigureValidation()
        {
            //ValidationManager.ConfigureValidation(this, txtConsumerAccount, "Account Number", (long)ValidationType.NonWhitespaceNonEmptyText, true);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsumerAccount.Text = "";
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblBalance.Text = "";
            lblInWords.Text = "";
            pic_conusmer.Image = null;

            //if (CheckValidation())
            //{
            //    //bio.CaptureFingerData();
            //    if (txtConsumerAccount.Text != "")
            //    {
            //        try
            //        {
            //            string accNo = txtConsumerAccount.Text.Trim();
            //            BalanceInquiryRequest request = FillBalanceInquiryRequestData();
            //            request.fingerData = accountHolderFingerPrint;
            //            string balance = service.BalanceInquiry(request, accNo);
            //            if (balance != null)
            //            {
            //                Message.showInformation("Your account balance is " + balance);
            //                txtConsumerAccount.Text = "";
            //                lblConsumerTitle.Text = "";
            //                lblMobileNo.Text = "";
            //                pic_conusmer.Image = null;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Message.showError(ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        Message.showWarning("Account number can not be left blank.");
            //    }
            //}
        }

        private Boolean CheckValidation()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConsumerAccount_Leave(object sender, EventArgs e)
        {
            //if (CheckValidation())
            if (!string.IsNullOrEmpty(txtConsumerAccount.Text) && !string.IsNullOrWhiteSpace(txtConsumerAccount.Text))
            {

                try
                {
                    _consumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtConsumerAccount.Text);

                    if (_consumerInformationDto.id == 0)
                    {
                        lblConsumerTitle.Text = _consumerInformationDto.consumerTitle;
                        lblMobileNo.Text = _consumerInformationDto.mobileNumber;

                        if (_consumerInformationDto.photo != null)
                        {
                            byte[] bytes = Convert.FromBase64String(_consumerInformationDto.photo);
                            Image image;
                            image = UtilityServices.byteArrayToImage(bytes);
                            pic_conusmer.Image = image;
                        }
                        //balance 
                        try
                        {
                            string accNo = txtConsumerAccount.Text.Trim();
                            string balance = (_consumerInformationDto.balance ?? 0).ToString("N", new CultureInfo("BN-BD"));
                            lblBalance.Text = balance;
                            lblInWords.Text = _amountInWords.ToWords(balance);
                        }
                        catch (Exception ex)
                        {
                            Message.showError(ex.Message);
                        }
                    }
                    else
                    {
                        Message.showWarning("Account Information not found.");
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                    lblConsumerTitle.Text = "";
                    lblMobileNo.Text = "";
                    pic_conusmer.Image = null;
                }
            }
        }

        private BalanceInquiryRequest FillBalanceInquiryRequestData()
        {
            BalanceInquiryRequest balanceRequest = new BalanceInquiryRequest();
            balanceRequest.accountNumber = txtConsumerAccount.Text;
            return balanceRequest;
        }

        private void bio_OnCapture(object sender, EventArgs e)
        {
            AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            if (x.result == "0")
            {

                _accountHolderFingerPrint = bio.GetSafeLeftFingerData();
                if (_accountHolderFingerPrint != null)
                {
                    if (txtConsumerAccount.Text != "")
                    {
                        string accNo = txtConsumerAccount.Text.Trim();
                        BalanceInquiryRequest request = FillBalanceInquiryRequestData();
                        request.fingerData = _accountHolderFingerPrint;
                        string balance = _service.BalanceInquiry(request, accNo);
                        MessageBox.Show("Your account balance is " + balance, "Balance", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Account holder fingerprint needed.");
                }
            }
        }

        private void txtConsumerAccount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
            lblInWords.Text = _amountInWords.ToWords(lblBalance.Text);
        }

        private void btshowAccInfo_Click(object sender, EventArgs e)
        {
            bio.CaptureFingerData();
        }

        private void btshowAccountInfo_Click(object sender, EventArgs e)
        {

        }

        private void frmBalanceInquiry_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }
        public static bool ReleaseValidationData(Form form)
        {
            return true;
        }
    }
}