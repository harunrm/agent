using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Report.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.mislbd.agentbanking.report.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Services;
using System.Globalization;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Report.DataSets;
using System.IO;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmShowReport : Form
    {
        private ConsumerApplicationReportDto dto;
        private CashwithdrawlReportDto cashWithDrawlReportDto;
        private DepositReportDto depositReportDto;
        private BillPaymentReportDto billPaymentDto;
        private TransactionReportDto transactionReportDto;
        private ApprovedConsumerAppReportDto approvedConsumerDto;
        private RemittanceReportDto remittanceReportDto;

        ConsumerServices consumerService = new ConsumerServices();
        TransactionService transactionService = new TransactionService();
        TermService sspService = new TermService();
        private AmountInWords amountInWords = new AmountInWords();
        public frmShowReport()
        {
            InitializeComponent();
        }

        public void fillReportType()
        {
            cmbReportType.DisplayMember = "Text";
            cmbReportType.ValueMember = "Value";

            cmbReportType.Items.Add(new { Text = "Select", Value = "0" });
            cmbReportType.Items.Add(new { Text = "Pre Account Information", Value = "1" });
            cmbReportType.Items.Add(new { Text = "Post Account Information", Value = "2" });
            cmbReportType.Items.Add(new { Text = "Deposite", Value = "3" });
            cmbReportType.Items.Add(new { Text = "Withdraw", Value = "4" });
            cmbReportType.Items.Add(new { Text = "Money Transfer", Value = "5" });
            cmbReportType.Items.Add(new { Text = "Remittance", Value = "6" });
            cmbReportType.Items.Add(new { Text = "ITD Account", Value = "7" });
            cmbReportType.Items.Add(new { Text = "SSP Pre Account Information", Value = "8" });

            cmbReportType.SelectedText = "Select";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            if (isValidRequest())
            {
                String selectedText = cmbReportType.Text;

                //int selectedValue = int.Parse(cmbReportType.SelectedValue.ToString());
                string acNo = txtConsumerAccount.Text.Trim();

                if (selectedText == "Pre Account Information")
                {
                    try
                    {
                        dto = consumerService.GetConsumerApplicationData(txtConsumerAccount.Text);
                        ShowPreAccountInformation(acNo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //else if (selectedText == "SSP Pre Account Information")
                //{
                //    try
                //    {
                //        dto = sspService.GetSSPPaySlipRequestApplicationData(txtConsumerAccount.Text);
                //        SspPreAccountReport(acNo);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}
                else if (selectedText == "Post Account Information")
                {
                    try
                    {
                        approvedConsumerDto = consumerService.GetApprovedConsumerReportDto(txtConsumerAccount.Text);
                        ShowPostAccountInformation(acNo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (selectedText == "Deposite")
                {
                    try
                    {
                        depositReportDto = consumerService.GetDepositReportDto(txtConsumerAccount.Text);
                        ShowDeposite(acNo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (selectedText == "Withdraw")
                {
                    cashWithDrawlReportDto = consumerService.GetCashWithDrawlReportDto(txtConsumerAccount.Text);
                    ShowWithdraw(acNo);
                }
                else if (selectedText == "Money Transfer")
                {
                    try
                    {
                        transactionReportDto = transactionService.GetTransactionReportDto(txtConsumerAccount.Text);
                        ShowMoneyTranster(acNo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (selectedText == "Remittance")
                {
                    ShowRemittance(acNo);
                }
                //else if (selectedText == "ITD Account")
                //{
                //    ShowITDAccount(acNo);
                //}
                //else if (selectedText == "ITD Account")
                //{
                //    try
                //    {
                //        dto = consumerService.GetITDAApplicationData(txtConsumerAccount.Text);
                //        ShowITDAccount(acNo);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }

                //}

            }
        }
        public void SspPreAccountReport(string referenceNo, AccountType? accountType)
        {
            try
            {
                SspSlipDto sspDto = sspService.GetSSPPaySlipRequestApplicationData(referenceNo, accountType);
                sspDto.referenceNo = referenceNo;
                //dto = consumerService.GetConsumerApplicationData(NationalId);
                ShowSSPPreAccountInformation(sspDto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowSSPPreAccountInformation(SspSlipDto dto)
        {
            try
            {
                // Set Crystal Report data.
                crSSPAccountOpeningInformation objRpt = new crSSPAccountOpeningInformation();

                if (dto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && dto.agentName != null)
                    {
                        objtxtAgentName.Text = dto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && dto.outLetName != null)
                    {
                        objtxtOutlateName.Text = dto.outLetName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && dto.outLetAddress != null)
                    {
                        objtxtOutletAddress.Text = dto.outLetAddress;
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserName"] as TextObject;
                    if (objtxtUserID != null && dto.outLetUserName != null)
                    {
                        objtxtUserID.Text = dto.outLetUserName;
                    }

                    TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                    if (objtxtCustomerName != null && dto.customerName != null)
                    {
                        objtxtCustomerName.Text = dto.customerName;
                    }

                    TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                    if (objtxtUnionName != null && dto.customerUnion != null)
                    {
                        objtxtUnionName.Text = dto.customerUnion;
                    }

                    TextObject objtxtDateOfApplication = objRpt.ReportDefinition.ReportObjects["txtDateOfApplication"] as TextObject;
                    if (objtxtDateOfApplication != null)
                    {

                        //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        //DateTime date = start.AddMilliseconds(dto.dateOfApplication).ToLocalTime();
                        objtxtDateOfApplication.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace("-","/");
                    }

                    TextObject objtxtReferenceNo = objRpt.ReportDefinition.ReportObjects["txtReferenceNo"] as TextObject;
                    if (objtxtReferenceNo != null && dto.referenceNo != null)
                    {
                        objtxtReferenceNo.Text = dto.referenceNo;
                    }

                    TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                    if (objtxtVillageName != null && dto.customerVillage != null)
                    {
                        objtxtVillageName.Text = dto.customerVillage;
                    }

                    TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                    if (objtxtUpazillaName != null && dto.customerUpozilla != null)
                    {
                        objtxtUpazillaName.Text = dto.customerUpozilla;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/MM/yyyy}", dt).Replace("-","/");

                    }

                    TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                    if (objtxtMobileNO != null && dto.mobileNumber != null)
                    {
                        objtxtMobileNO.Text = dto.mobileNumber;
                    }

                    TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                    if (objtxtDistrict != null && dto.customerDistrict != null)
                    {
                        objtxtDistrict.Text = dto.customerDistrict;
                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        public void ShowRemittanceReport(string voucherNumber)
        {
            remittanceReportDto = consumerService.GetRemittanceReportDto(voucherNumber);
            ShowRemittance(voucherNumber);

        }

        public void PreAccountReport(string NationalId)
        {
            try
            {
                dto = consumerService.GetConsumerApplicationData(NationalId);
                ShowPreAccountInformation("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SSPApproveAccountReport(string referenceNo, AccountType? accountType)
        {
            try
            {
                switch (accountType)
                {
                    case AccountType.SSP:
                        SspSlipDto sspDto = sspService.GetSSPPaySlipRequestApplicationData(referenceNo, accountType);
                        ShowITDAccount(sspDto);
                        break;
                    case AccountType.MTDR:
                        SspSlipDto mtdrDto = sspService.GetMTDPPaySlipRequestApplicationDto(referenceNo, accountType);
                        ShowMTDAccountInformation(mtdrDto);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void PostAccountReport(string NationalId)
        {
            try
            {
                approvedConsumerDto = consumerService.GetApprovedConsumerReportDto(NationalId);
                ShowPostAccountInformation("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WithDrawlReport(string VoucherNumber)
        {
            cashWithDrawlReportDto = consumerService.GetCashWithDrawlReportDto(VoucherNumber);
            ShowWithdraw("");
        }

        public void DepositeReport(string VoucherNumber)
        {
            try
            {
                depositReportDto = consumerService.GetDepositReportDto(VoucherNumber);
                ShowDeposite("");
            }
            catch (Exception ex)
            {
                //Message
                //MessageBox.Show(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public void BillReportDto(string VoucherNumber)
        {
            try
            {
                billPaymentDto = consumerService.GetBillReportDto(VoucherNumber);
                ShowBillPayment("");
            }
            catch (Exception ex)
            {
                //Message
                //MessageBox.Show(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void MoneyTransferReport(string VoucherNumber)
        {
            try
            {
                transactionReportDto = transactionService.GetTransactionReportDto(VoucherNumber);
                ShowMoneyTranster("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowITDAccount(SspSlipDto dto)
        {
            try
            {
                // Set Crystal Report data.
                crITDAccountInfo objRpt = new crITDAccountInfo();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null)
                {
                    objtxtAgentName.Text = dto.agentName;
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null && dto.outLetName != null)
                {
                    objtxtOutlateName.Text = dto.outLetName;
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null && dto.outLetAddress != null)
                {
                    objtxtOutletAddress.Text = dto.outLetAddress;
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null && dto.outLetUserName != null)
                {
                    objtxtUserID.Text = dto.outLetUserName;
                }

                // customer info

                TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                if (objtxtCustomerName != null && dto.customerName != null)
                {
                    objtxtCustomerName.Text = dto.customerName;
                }

                TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                if (objtxtUnionName != null && dto.customerUnion != null)
                {
                    objtxtUnionName.Text = dto.customerUnion;
                }

                TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                if (objtxtVillageName != null && dto.customerVillage != null)
                {
                    objtxtVillageName.Text = dto.customerVillage;
                }

                TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                if (objtxtUpazillaName != null && dto.customerUpozilla != null)
                {
                    objtxtUpazillaName.Text = dto.customerUpozilla;
                }

                TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                if (objtxtMobileNO != null && dto.mobileNumber != null)
                {
                    objtxtMobileNO.Text = dto.mobileNumber;
                }

                TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                if (objtxtDistrict != null && dto.customerDistrict != null)
                {
                    objtxtDistrict.Text = dto.customerDistrict;
                }

                // Account info after creation

                TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                if (objtxtAccountName != null && dto.sspAccountName != null)
                {
                    objtxtAccountName.Text = dto.sspAccountName;
                }

                TextObject objtxtCANo = objRpt.ReportDefinition.ReportObjects["txtCANo"] as TextObject;
                if (objtxtCANo != null && dto.curOrSavingAccountNumber != null)
                {
                    objtxtCANo.Text = dto.curOrSavingAccountNumber;
                }

                TextObject objtxtTimeDuration = objRpt.ReportDefinition.ReportObjects["txtTimeDuration"] as TextObject;
                if (objtxtTimeDuration != null && dto.installmentPerod != null)
                {
                    objtxtTimeDuration.Text = dto.installmentPerod.ToString();
                }
                TextObject objtxtCustomerID = objRpt.ReportDefinition.ReportObjects["txtCustomerID"] as TextObject;
                if (objtxtCustomerID != null && dto.customerId != null)
                {
                    objtxtCustomerID.Text = dto.customerId;
                }

                TextObject objtxtAccountOpenDate = objRpt.ReportDefinition.ReportObjects["txtAccountOpenDate"] as TextObject;
                if (objtxtAccountOpenDate != null && dto.openingDate != null)
                {
                    objtxtAccountOpenDate.Text = UtilityServices.getDateFromLong(dto.openingDate).ToString("dd-MM-yyyy").Replace("-","/");
                }

                TextObject objtxtExpireDate = objRpt.ReportDefinition.ReportObjects["txtExpireDate"] as TextObject;
                if (objtxtExpireDate != null && dto.maturDate != null)
                {
                    objtxtExpireDate.Text = UtilityServices.getDateFromLong(dto.maturDate).ToString("dd-MM-yyyy").Replace("-","/");
                }

                TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                if (objtxtAccountNo != null && dto.sspAccountNumber != null)
                {
                    objtxtAccountNo.Text = dto.sspAccountNumber;
                }

                TextObject objtxtMonthlyDeposite = objRpt.ReportDefinition.ReportObjects["txtMonthlyDeposite"] as TextObject;
                if (objtxtMonthlyDeposite != null)
                {
                    objtxtMonthlyDeposite.Text = dto.installment.ToString("N", new CultureInfo("BN-BD"));
                }

                TextObject objtxtTotalWithProfite = objRpt.ReportDefinition.ReportObjects["txtTotalWithProfite"] as TextObject;
                if (objtxtTotalWithProfite != null)
                {
                    objtxtTotalWithProfite.Text = (dto.maturAmount ?? 0).ToString("N", new CultureInfo("BN-BD"));
                }

                //TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                //if (objtxtPrintDate != null)
                //{
                //    objtxtPrintDate.Text = "06/08/2015";
                //}

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        public void ShowRemittance(string refrence)
        {
            try
            {
                // Set Crystal Report data.
                crRemitence objRpt = new crRemitence();

                if (remittanceReportDto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && remittanceReportDto.agentName != null)
                    {
                        objtxtAgentName.Text = remittanceReportDto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && remittanceReportDto.outletName != null)
                    {
                        objtxtOutlateName.Text = remittanceReportDto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && remittanceReportDto.outletAddress != null)
                    {
                        objtxtOutletAddress.Text = remittanceReportDto.outletAddress;
                    }

                    // Transaction Info

                    TextObject objtxtRemitanceComName = objRpt.ReportDefinition.ReportObjects["txtRemitanceComName"] as TextObject;
                    if (objtxtRemitanceComName != null && remittanceReportDto.nameOfRemittanceInstitution != null)
                    {
                        objtxtRemitanceComName.Text = remittanceReportDto.nameOfRemittanceInstitution;
                    }

                    TextObject objtxtRemitanceName = objRpt.ReportDefinition.ReportObjects["txtRemitanceName"] as TextObject;
                    if (objtxtRemitanceName != null && remittanceReportDto.remittanceName != null)
                    {
                        objtxtRemitanceName.Text = remittanceReportDto.remittanceName;
                    }

                    TextObject objtxtBenificiaryAddress = objRpt.ReportDefinition.ReportObjects["txtBenificiaryAddress"] as TextObject;
                    if (objtxtBenificiaryAddress != null)
                    {
                        objtxtBenificiaryAddress.Text = remittanceReportDto.beneficiaryAddress;
                    }


                    TextObject objtxtTransactionID = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                    if (objtxtTransactionID != null)
                    {
                        //DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        //objtxtTransactionID.Text = String.Format("{0:dd/ MM/ yyyy}", dt); 
                        // objtxtTransactionID.Text = UtilityServices.getDateFromLong( remittanceReportDto.trDate).ToLongDateString();
                        DateTime dt = UtilityServices.getDateFromLong(remittanceReportDto.trDate);
                        objtxtTransactionID.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");
                    }

                    TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                    if (objtxtAmountOfMoney != null && remittanceReportDto.amount != null)
                    {

                        objtxtAmountOfMoney.Text = remittanceReportDto.amount.ToString("N", new CultureInfo("BN-BD"));
                    }

                    TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                    if (objtxtAmountOfMoneyInWord != null && remittanceReportDto.amountInWords != null)
                    {
                        //objtxtAmountOfMoneyInWord.Text = remittanceReportDto.amountInWords;
                        objtxtAmountOfMoneyInWord.Text = amountInWords.ToWords(remittanceReportDto.amount.ToString());
                    }

                    // Right part data

                    TextObject objtxtRemitanceNo = objRpt.ReportDefinition.ReportObjects["txtRemitanceNo"] as TextObject;
                    if (objtxtRemitanceNo != null && remittanceReportDto.remittanceNo != null)
                    {
                        objtxtRemitanceNo.Text = remittanceReportDto.remittanceNo;
                    }

                    TextObject objtxtBenificiaryName = objRpt.ReportDefinition.ReportObjects["txtBenificiaryName"] as TextObject;
                    if (objtxtBenificiaryName != null && remittanceReportDto.beneficiaryName != null)
                    {
                        objtxtBenificiaryName.Text = remittanceReportDto.beneficiaryName;
                    }

                    TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                    if (objtxtMobileNO != null && remittanceReportDto.mobileNo != null)
                    {
                        objtxtMobileNO.Text = remittanceReportDto.mobileNo;
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && remittanceReportDto.userId != null)
                    {
                        objtxtUserID.Text = remittanceReportDto.userId;
                    }
                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");

                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        public void ShowMoneyTranster(string acNo)
        {
            try
            {
                // Set Crystal Report data.
                crMoneyTransfer objRpt = new crMoneyTransfer();

                if (transactionReportDto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && transactionReportDto.agentName != null)
                    {
                        objtxtAgentName.Text = transactionReportDto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && transactionReportDto.outletName != null)
                    {
                        objtxtOutlateName.Text = transactionReportDto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && transactionReportDto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = transactionReportDto.outletAdress;
                    }

                    // Transaction Info

                    TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                    if (objtxtAccountName != null && transactionReportDto.debitoAccountName != null)
                    {
                        objtxtAccountName.Text = transactionReportDto.debitoAccountName;
                    }

                    TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                    if (objtxtAccountNo != null && transactionReportDto.debitorAccountNumber != null)
                    {
                        objtxtAccountNo.Text = transactionReportDto.debitorAccountNumber;
                    }

                    TextObject objtxtTransactionDate = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                    if (objtxtTransactionDate != null && transactionReportDto.transactionDate != null)
                    {
                        //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        //DateTime date = start.AddMilliseconds(transactionReportDto.transactionDate).ToLocalTime();
                        objtxtTransactionDate.Text = transactionReportDto.transactionDate.ToString("dd-MM-yyyy").Replace("-","/");
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && transactionReportDto.userId != null)
                    {
                        objtxtUserID.Text = transactionReportDto.userId;
                    }

                    TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                    if (objtxtAmountOfMoney != null && transactionReportDto.transactionAmount != null)
                    {
                        objtxtAmountOfMoney.Text = transactionReportDto.transactionAmount.ToString("N", new CultureInfo("BN-BD"));
                    }

                    TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                    if (objtxtAmountOfMoneyInWord != null && transactionReportDto.amountInWords != null)
                    {
                        //objtxtAmountOfMoneyInWord.Text = transactionReportDto.amountInWords;
                        objtxtAmountOfMoneyInWord.Text = amountInWords.ToWords(transactionReportDto.transactionAmount.ToString());
                    }

                    // Right part data

                    TextObject objtxtReceiverAccountName = objRpt.ReportDefinition.ReportObjects["txtReceiverAccountName"] as TextObject;
                    if (objtxtReceiverAccountName != null && transactionReportDto.creditorAccountName != null)
                    {
                        objtxtReceiverAccountName.Text = transactionReportDto.creditorAccountName;
                    }

                    TextObject objtxtReceiverAccountNo = objRpt.ReportDefinition.ReportObjects["txtReceiverAccountNo"] as TextObject;
                    if (objtxtReceiverAccountNo != null && transactionReportDto.creditorAccountNumber != null)
                    {
                        objtxtReceiverAccountNo.Text = transactionReportDto.creditorAccountNumber;
                    }

                    TextObject objtxtTrasactionID = objRpt.ReportDefinition.ReportObjects["txtTrasactionID"] as TextObject;
                    if (objtxtTrasactionID != null && transactionReportDto.voucherNumber != null)
                    {
                        objtxtTrasactionID.Text = transactionReportDto.voucherNumber;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");

                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        public void ShowWithdraw(string acNo)
        {
            try
            {
                // Set Crystal Report data.
                crWithdraw objRpt = new crWithdraw();

                if (cashWithDrawlReportDto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && cashWithDrawlReportDto.agentName != null)
                    {
                        objtxtAgentName.Text = cashWithDrawlReportDto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && cashWithDrawlReportDto.outletName != null)
                    {
                        objtxtOutlateName.Text = cashWithDrawlReportDto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && cashWithDrawlReportDto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = cashWithDrawlReportDto.outletAdress;
                    }

                    // Transaction Info

                    TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                    if (objtxtAccountName != null && cashWithDrawlReportDto.accountName != null)
                    {
                        objtxtAccountName.Text = cashWithDrawlReportDto.accountName;
                    }

                    TextObject objtxtTransactionDate = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                    if (objtxtTransactionDate != null && cashWithDrawlReportDto.transactionDate != null)
                    {

                        //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        //DateTime date = start.AddMilliseconds(cashWithDrawlReportDto.transactionDate).ToLocalTime();
                        objtxtTransactionDate.Text = cashWithDrawlReportDto.transactionDate.ToString("dd/MM/yyyy").Replace("-","/");
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && cashWithDrawlReportDto.userId != null)
                    {
                        objtxtUserID.Text = cashWithDrawlReportDto.userId;
                    }

                    TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                    if (objtxtAmountOfMoney != null)
                    {
                        objtxtAmountOfMoney.Text = cashWithDrawlReportDto.amount.ToString("N", new CultureInfo("BN-BD"));
                    }

                    TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                    if (objtxtAmountOfMoneyInWord != null && cashWithDrawlReportDto.amountInWords != null)
                    {
                        //objtxtAmountOfMoneyInWord.Text = cashWithDrawlReportDto.amountInWords;
                        objtxtAmountOfMoneyInWord.Text = amountInWords.ToWords(cashWithDrawlReportDto.amount.ToString());
                    }

                    TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                    if (objtxtAccountNo != null && cashWithDrawlReportDto.accountNumber != null)
                    {
                        objtxtAccountNo.Text = cashWithDrawlReportDto.accountNumber;
                    }

                    TextObject objtxtTrasactionID = objRpt.ReportDefinition.ReportObjects["txtTrasactionID"] as TextObject;
                    if (objtxtTrasactionID != null && cashWithDrawlReportDto.voucherNumber != null)
                    {
                        objtxtTrasactionID.Text = cashWithDrawlReportDto.voucherNumber;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");
                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        public void ShowDeposite(string acNo)
        {
            try
            {
                // Set Crystal Report data.
                crDepositeInformation objRpt = new crDepositeInformation();

                if (depositReportDto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && depositReportDto.agentName != null)
                    {
                        objtxtAgentName.Text = depositReportDto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && depositReportDto.outletName != null)
                    {
                        objtxtOutlateName.Text = depositReportDto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && depositReportDto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = depositReportDto.outletAdress;
                    }

                    // Transaction Info

                    TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                    if (objtxtAccountName != null && depositReportDto.accountName != null)
                    {
                        objtxtAccountName.Text = depositReportDto.accountName;
                    }

                    TextObject objtxtTransactionDate = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                    if (objtxtTransactionDate != null && depositReportDto.transactionDate != null)
                    {

                        objtxtTransactionDate.Text = depositReportDto.transactionDate.ToString("dd/MM/yyyy").Replace("-","/");
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && depositReportDto.userId != null)
                    {
                        objtxtUserID.Text = depositReportDto.userId;
                    }

                    TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                    if (objtxtAmountOfMoney != null)
                    {
                        //objtxtAmountOfMoney.Text = depositReportDto.amount.ToString();
                        objtxtAmountOfMoney.Text = depositReportDto.amount.ToString("N", new CultureInfo("BN-BD"));
                    }

                    TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                    if (objtxtAmountOfMoneyInWord != null && depositReportDto.amountInWords != null)
                    {
                        // objtxtAmountOfMoneyInWord.Text = depositReportDto.amountInWords;
                        objtxtAmountOfMoneyInWord.Text = amountInWords.ToWords(depositReportDto.amount.ToString());
                    }

                    TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                    if (objtxtAccountNo != null && depositReportDto.accountNumber != null)
                    {
                        objtxtAccountNo.Text = depositReportDto.accountNumber;
                    }

                    TextObject objtxtTrasactionID = objRpt.ReportDefinition.ReportObjects["txtTrasactionID"] as TextObject;
                    if (objtxtTrasactionID != null && depositReportDto.voucherNumber != null)
                    {
                        objtxtTrasactionID.Text = depositReportDto.voucherNumber;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");

                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }


        public void ShowBillPayment(string billNumber)
        {
            try
            {
                //  Set Crystal Report data.
                crBillPayment objRpt = new crBillPayment();

                if (billPaymentDto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && billPaymentDto.agentName != null)
                    {
                        objtxtAgentName.Text = billPaymentDto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && billPaymentDto.outletName != null)
                    {
                        objtxtOutlateName.Text = billPaymentDto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && billPaymentDto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = billPaymentDto.outletAdress;
                    }

                    // Transaction Info

                    TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                    if (objtxtAccountName != null && billPaymentDto.accountName != null)
                    {
                        objtxtAccountName.Text = billPaymentDto.accountName;
                    }

                    TextObject objtxtTransactionDate = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                    if (objtxtTransactionDate != null && billPaymentDto.transactionDate != null)
                    {

                        objtxtTransactionDate.Text = billPaymentDto.transactionDate.ToString("dd/MM/yyyy").Replace("-","/");
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && billPaymentDto.userId != null)
                    {
                        objtxtUserID.Text = billPaymentDto.userId;
                    }

                    TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                    if (objtxtAmountOfMoney != null)
                    {
                        //objtxtAmountOfMoney.Text = depositReportDto.amount.ToString();
                        objtxtAmountOfMoney.Text = billPaymentDto.amount.ToString("N", new CultureInfo("BN-BD"));
                    }

                    TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                    if (objtxtAmountOfMoneyInWord != null && billPaymentDto.amountInWords != null)
                    {
                        // objtxtAmountOfMoneyInWord.Text = depositReportDto.amountInWords;
                        objtxtAmountOfMoneyInWord.Text = amountInWords.ToWords(billPaymentDto.amount.ToString());
                    }

                    TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                    if (objtxtAccountNo != null && billPaymentDto.accountNumber != null)
                    {
                        objtxtAccountNo.Text = billPaymentDto.accountNumber;
                    }

                    TextObject objtxtTrasactionID = objRpt.ReportDefinition.ReportObjects["txtTrasactionID"] as TextObject;
                    if (objtxtTrasactionID != null && billPaymentDto.voucherNumber != null)
                    {
                        objtxtTrasactionID.Text = billPaymentDto.voucherNumber;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");

                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }



        public void ShowPostAccountInformation(string acNo)
        {
            try
            {
                // Set Crystal Report data.
                crAccountInfoAfterCreated objRpt = new crAccountInfoAfterCreated();

                if (approvedConsumerDto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && approvedConsumerDto.agentName != null)
                    {
                        objtxtAgentName.Text = approvedConsumerDto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && approvedConsumerDto.outletName != null)
                    {
                        objtxtOutlateName.Text = approvedConsumerDto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && approvedConsumerDto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = approvedConsumerDto.outletAdress;
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && approvedConsumerDto.userId != null)
                    {
                        objtxtUserID.Text = approvedConsumerDto.userId;
                    }

                    // customer info

                    TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                    if (objtxtCustomerName != null && approvedConsumerDto.consumerName != null)
                    {
                        objtxtCustomerName.Text = approvedConsumerDto.consumerName;
                    }

                    TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                    if (objtxtUnionName != null && approvedConsumerDto.unionName != null)
                    {
                        objtxtUnionName.Text = approvedConsumerDto.unionName;
                    }

                    TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                    if (objtxtVillageName != null && approvedConsumerDto.villageName != null)
                    {
                        objtxtVillageName.Text = approvedConsumerDto.villageName;
                    }

                    TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                    if (objtxtUpazillaName != null && approvedConsumerDto.upazillaName != null)
                    {
                        objtxtUpazillaName.Text = approvedConsumerDto.upazillaName;
                    }

                    TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                    if (objtxtMobileNO != null && approvedConsumerDto.mobileNo != null)
                    {
                        objtxtMobileNO.Text = approvedConsumerDto.mobileNo;
                    }

                    TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                    if (objtxtDistrict != null && approvedConsumerDto.districtName != null)
                    {
                        objtxtDistrict.Text = approvedConsumerDto.districtName;
                    }

                    // Account info after creation

                    TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                    if (objtxtAccountName != null && approvedConsumerDto.accountName != null)
                    {
                        objtxtAccountName.Text = approvedConsumerDto.accountName;
                    }

                    TextObject objtxtTypeOfAccount = objRpt.ReportDefinition.ReportObjects["txtTypeOfAccount"] as TextObject;
                    if (objtxtTypeOfAccount != null && approvedConsumerDto.accountType != null)
                    {
                        objtxtTypeOfAccount.Text = approvedConsumerDto.accountType;
                    }

                    TextObject objtxtCustomerID = objRpt.ReportDefinition.ReportObjects["txtCustomerID"] as TextObject;
                    if (objtxtCustomerID != null)
                    {
                        objtxtCustomerID.Text = approvedConsumerDto.consumerId.ToString();
                    }

                    TextObject objtxtAccountOpenDate = objRpt.ReportDefinition.ReportObjects["txtAccountOpenDate"] as TextObject;
                    if (objtxtAccountOpenDate != null)
                    {

                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime date = start.AddMilliseconds(approvedConsumerDto.dateOfApplication).ToLocalTime();

                        objtxtAccountOpenDate.Text = date.ToString("dd/MM/yyyy").Replace("-","/");
                    }

                    TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                    if (objtxtAccountNo != null && approvedConsumerDto.accountNumber != null)
                    {
                        objtxtAccountNo.Text = approvedConsumerDto.accountNumber;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-", "/");

                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }

        }

        public void ShowPreAccountInformation(string acNo)
        {
            try
            {
                // Set Crystal Report data.
                crAccountOpenInformation objRpt = new crAccountOpenInformation();

                if (dto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && dto.agentName != null)
                    {
                        objtxtAgentName.Text = dto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && dto.outletName != null)
                    {
                        objtxtOutlateName.Text = dto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && dto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = dto.outletAdress;
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && dto.userId != null)
                    {
                        objtxtUserID.Text = dto.userId;
                    }

                    TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                    if (objtxtCustomerName != null && dto.customerName != null)
                    {
                        objtxtCustomerName.Text = dto.customerName;
                    }

                    TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                    if (objtxtUnionName != null && dto.unionName != null)
                    {
                        objtxtUnionName.Text = dto.unionName;
                    }

                    TextObject objtxtDateOfApplication = objRpt.ReportDefinition.ReportObjects["txtDateOfApplication"] as TextObject;
                    if (objtxtDateOfApplication != null)
                    {

                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime date = start.AddMilliseconds(dto.dateOfApplication).ToLocalTime();
                        objtxtDateOfApplication.Text = date.ToString("dd/MM/yyyy").Replace("-","/");

                    }

                    TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                    if (objtxtVillageName != null && dto.villageName != null)
                    {
                        objtxtVillageName.Text = dto.villageName;
                    }

                    TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                    if (objtxtUpazillaName != null && dto.upazillaName != null)
                    {
                        objtxtUpazillaName.Text = dto.upazillaName;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");

                    }

                    TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                    if (objtxtMobileNO != null && dto.mobileNo != null)
                    {
                        objtxtMobileNO.Text = dto.mobileNo;
                    }

                    TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                    if (objtxtDistrict != null && dto.districtName != null)
                    {
                        objtxtDistrict.Text = dto.districtName;
                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private bool isValidRequest()
        {

            String selectedText = cmbReportType.Text;

            if (selectedText == "Select")
            {
                System.Windows.Forms.MessageBox.Show("Please, select report type.");
                return false;
            }
            else if (string.IsNullOrEmpty(txtConsumerAccount.Text.Trim()))
            {
                System.Windows.Forms.MessageBox.Show("Please, enter account no.");
                return false;
            }


            return true;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {
                fillReportType();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accountName = cmbReportType.Text;
            lblAccountName.Text = accountName;
        }

        public void ShowSSPAccountInformation(string refNo)
        {
            try
            {
                // Set Crystal Report data.
                crSSPAccountOpeningInformation objRpt = new crSSPAccountOpeningInformation();

                if (dto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && dto.agentName != null)
                    {
                        objtxtAgentName.Text = dto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && dto.outletName != null)
                    {
                        objtxtOutlateName.Text = dto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && dto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = dto.outletAdress;
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && dto.userId != null)
                    {
                        objtxtUserID.Text = dto.userId;
                    }

                    TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                    if (objtxtCustomerName != null && dto.customerName != null)
                    {
                        objtxtCustomerName.Text = dto.customerName;
                    }

                    TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                    if (objtxtUnionName != null && dto.unionName != null)
                    {
                        objtxtUnionName.Text = dto.unionName;
                    }

                    TextObject objtxtDateOfApplication = objRpt.ReportDefinition.ReportObjects["txtDateOfApplication"] as TextObject;
                    if (objtxtDateOfApplication != null)
                    {

                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime date = start.AddMilliseconds(dto.dateOfApplication).ToLocalTime();
                        objtxtDateOfApplication.Text = date.ToString();
                    }

                    TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                    if (objtxtVillageName != null && dto.villageName != null)
                    {
                        objtxtVillageName.Text = dto.villageName;
                    }

                    TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                    if (objtxtUpazillaName != null && dto.upazillaName != null)
                    {
                        objtxtUpazillaName.Text = dto.upazillaName;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-", "/");

                    }

                    TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                    if (objtxtMobileNO != null && dto.mobileNo != null)
                    {
                        objtxtMobileNO.Text = dto.mobileNo;
                    }

                    TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                    if (objtxtDistrict != null && dto.districtName != null)
                    {
                        objtxtDistrict.Text = dto.districtName;
                    }
                }



                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }


        //===========================================================================================//
        //                                               MTDR                                        //  
        //============================================================================================//
        public void ShowMTDAccOpeningInformation(string acNo)
        {
            try
            {
                // Set Crystal Report data.
                crAccountOpenInformation objRpt = new crAccountOpenInformation();

                if (dto != null)
                {
                    TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                    if (objtxtAgentName != null && dto.agentName != null)
                    {
                        objtxtAgentName.Text = dto.agentName;
                    }

                    TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                    if (objtxtOutlateName != null && dto.outletName != null)
                    {
                        objtxtOutlateName.Text = dto.outletName;
                    }

                    TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                    if (objtxtOutletAddress != null && dto.outletAdress != null)
                    {
                        objtxtOutletAddress.Text = dto.outletAdress;
                    }

                    TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                    if (objtxtUserID != null && dto.userId != null)
                    {
                        objtxtUserID.Text = dto.userId;
                    }

                    TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                    if (objtxtCustomerName != null && dto.customerName != null)
                    {
                        objtxtCustomerName.Text = dto.customerName;
                    }

                    TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                    if (objtxtUnionName != null && dto.unionName != null)
                    {
                        objtxtUnionName.Text = dto.unionName;
                    }

                    TextObject objtxtDateOfApplication = objRpt.ReportDefinition.ReportObjects["txtDateOfApplication"] as TextObject;
                    if (objtxtDateOfApplication != null)
                    {

                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime date = start.AddMilliseconds(dto.dateOfApplication).ToLocalTime();
                        objtxtDateOfApplication.Text = date.ToString("dd/MM/yyyy").Replace("-","/");

                    }

                    TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                    if (objtxtVillageName != null && dto.villageName != null)
                    {
                        objtxtVillageName.Text = dto.villageName;
                    }

                    TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                    if (objtxtUpazillaName != null && dto.upazillaName != null)
                    {
                        objtxtUpazillaName.Text = dto.upazillaName;
                    }

                    TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                    if (objtxtPrintDate != null)
                    {
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        objtxtPrintDate.Text = String.Format("{0:dd/ MM/ yyyy}", dt).Replace("-","/");

                    }

                    TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                    if (objtxtMobileNO != null && dto.mobileNo != null)
                    {
                        objtxtMobileNO.Text = dto.mobileNo;
                    }

                    TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                    if (objtxtDistrict != null && dto.districtName != null)
                    {
                        objtxtDistrict.Text = dto.districtName;
                    }
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        //==========================================MTD Post Account Info==================================================//
        public void MTDReport(string VoucherNumber)
        {
            try
            {

                //ShowMTDAccOpeningInformation(VoucherNumber);
            }
            catch (Exception ex)
            {

            }
        }

        public void ShowMTDAccountInformation(SspSlipDto dto)
        {
            try
            {
                crMTD objRpt = new crMTD();

                // if (dto != null)
                // {
                TextObject objtxtOutletName = objRpt.ReportDefinition.ReportObjects["txtOutletName"] as TextObject;
                if (dto.outLetName != null)
                {
                    objtxtOutletName.Text = dto.outLetName;
                }

                TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                if (dto.customerName != null)
                {
                    objtxtCustomerName.Text = dto.customerName;
                }

                TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                if (dto.sspAccountNumber != null)
                {
                    objtxtAccountNo.Text = dto.sspAccountNumber;
                }

                //
                TextObject objtxtLinkAccNo = objRpt.ReportDefinition.ReportObjects["txtLinkAccNo"] as TextObject;
                if (dto.curOrSavingAccountNumber != null)
                {
                    objtxtLinkAccNo.Text = dto.curOrSavingAccountNumber;
                }

                TextObject objtxtDuration = objRpt.ReportDefinition.ReportObjects["txtDuration"] as TextObject;
                if (dto.maturDate != null)
                {
                    double days = (UtilityServices.getDateFromLong(dto.maturDate) - UtilityServices.getDateFromLong(dto.openingDate))
                        .TotalDays;
                    double months = days / (365.25 / 12);
                    months += 1;
                    objtxtDuration.Text = ((long)months).ToString();
                }

                TextObject objtxtOpeningDate = objRpt.ReportDefinition.ReportObjects["txtOpeningDate"] as TextObject;
                if (dto.maturDate != null)
                {
                    objtxtOpeningDate.Text = UtilityServices.getDateFromLong(dto.openingDate).ToString("dd-MM-yyyy").Replace("-","/");
                }

                TextObject objtxtMaturityDate = objRpt.ReportDefinition.ReportObjects["txtMaturityDate"] as TextObject;
                if (dto.maturDate != null)
                {
                    objtxtMaturityDate.Text = UtilityServices.getDateFromLong(dto.maturDate).ToString("dd-MM-yyyy").Replace("-","/");
                }

                TextObject objtxtAmountInteger = objRpt.ReportDefinition.ReportObjects["txtAmountInteger"] as TextObject;
                {
                    objtxtAmountInteger.Text = dto.installment.ToString() + "/=";
                }

                TextObject objtxtAmountInWords = objRpt.ReportDefinition.ReportObjects["txtAmountInWords"] as TextObject;
                {
                    objtxtAmountInWords.Text = amountInWords.ToWords(dto.installment.ToString()) + "Only";
                }

                try
                {
                    ImageDS img = new ImageDS();
                    ImageDS.ImageTableRow row = img.ImageTable.NewImageTableRow();
                    byte[] b = consumerService.getConumerPhotoByAppId(long.Parse(dto.customerId));
                    Bitmap imgTmp = (Bitmap)UtilityServices.byteArrayToImage(b);
                    MemoryStream ms = new MemoryStream();
                    imgTmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] buf = ms.GetBuffer();
                    ms.Close();
                    row.Image = buf;
                    img.ImageTable.AddImageTableRow(row);
                    img.AcceptChanges();
                    objRpt.SetDataSource(img);
                }
                catch
                {
                }

                frmReportViewer frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //===========================================================================================//
        //                                               MTDR                                        //  
        //===========================================================================================//
    }
}