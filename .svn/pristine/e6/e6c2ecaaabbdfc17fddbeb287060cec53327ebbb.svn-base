using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Report.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnAccountOpenInfo_Click(object sender, EventArgs e)
        {
            try 
            {
                // Set Crystal Report data.
                crAccountOpenInformation objRpt = new crAccountOpenInformation();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null )
                {
                    objtxtAgentName.Text = "Agent name";
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null)
                {
                    objtxtOutlateName.Text = "Outlate name";
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null)
                {
                    objtxtOutletAddress.Text = "Outlate Addresss";
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null)
                {
                    objtxtUserID.Text = "User ID";
                }

                TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                if (objtxtCustomerName != null)
                {
                    objtxtCustomerName.Text = "Customer name";
                }

                TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                if (objtxtUnionName != null)
                {
                    objtxtUnionName.Text = "Union name";
                }

                TextObject objtxtDateOfApplication = objRpt.ReportDefinition.ReportObjects["txtDateOfApplication"] as TextObject;
                if (objtxtDateOfApplication != null)
                {
                    objtxtDateOfApplication.Text = "06/05/2015";
                }

                TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                if (objtxtVillageName != null)
                {
                    objtxtVillageName.Text = "Village name";
                }

                TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                if (objtxtUpazillaName != null)
                {
                    objtxtUpazillaName.Text = "Upazilla name";
                }

                TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (objtxtPrintDate != null)
                {
                    objtxtPrintDate.Text = "30/05/2015";
                }

                TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                if (objtxtMobileNO != null)
                {
                    objtxtMobileNO.Text = "01720944188";
                }

                TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                if (objtxtDistrict != null)
                {
                    objtxtDistrict.Text = "District name";
                }

                // Show crystal report at "Report Viewer"
                frmReportViewer  frm = new frmReportViewer();
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch(Exception ex)
            {
            
            }
        }

        private void btnAccountInfoAfterCreated_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Crystal Report data.
                crAccountInfoAfterCreated objRpt = new crAccountInfoAfterCreated();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null)
                {
                    objtxtAgentName.Text = "Agent name";
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null)
                {
                    objtxtOutlateName.Text = "Outlate name";
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null)
                {
                    objtxtOutletAddress.Text = "Outlate Addresss";
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null)
                {
                    objtxtUserID.Text = "User ID";
                }

                // customer info

                TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                if (objtxtCustomerName != null)
                {
                    objtxtCustomerName.Text = "Customer name";
                }

                TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                if (objtxtUnionName != null)
                {
                    objtxtUnionName.Text = "Union name";
                }

                TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                if (objtxtVillageName != null)
                {
                    objtxtVillageName.Text = "Village name";
                }

                TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                if (objtxtUpazillaName != null)
                {
                    objtxtUpazillaName.Text = "Upazilla name";
                }

                TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                if (objtxtMobileNO != null)
                {
                    objtxtMobileNO.Text = "01720944188";
                }

                TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                if (objtxtDistrict != null)
                {
                    objtxtDistrict.Text = "District name";
                }

                // Account info after creation

                TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                if (objtxtAccountName != null)
                {
                    objtxtAccountName.Text = "Account name";
                }

                TextObject objtxtTypeOfAccount = objRpt.ReportDefinition.ReportObjects["txtTypeOfAccount"] as TextObject;
                if (objtxtTypeOfAccount != null)
                {
                    objtxtTypeOfAccount.Text = "Type of Account";
                }

                TextObject objtxtCustomerID = objRpt.ReportDefinition.ReportObjects["txtCustomerID"] as TextObject;
                if (objtxtCustomerID != null)
                {
                    objtxtCustomerID.Text = "Customer ID";
                }

                TextObject objtxtAccountOpenDate = objRpt.ReportDefinition.ReportObjects["txtAccountOpenDate"] as TextObject;
                if (objtxtAccountOpenDate != null)
                {
                    objtxtAccountOpenDate.Text = "06/07/2015";
                }

                TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                if (objtxtAccountNo != null)
                {
                    objtxtAccountNo.Text = "2342342342342342";
                }

                TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (objtxtPrintDate != null)
                {
                    objtxtPrintDate.Text = "06/08/2015";
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

        private void btnITDAccount_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Crystal Report data.
                crITDAccountInfo objRpt = new crITDAccountInfo();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null)
                {
                    objtxtAgentName.Text = "Agent name";
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null)
                {
                    objtxtOutlateName.Text = "Outlate name";
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null)
                {
                    objtxtOutletAddress.Text = "Outlate Addresss";
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null)
                {
                    objtxtUserID.Text = "User ID";
                }

                // customer info

                TextObject objtxtCustomerName = objRpt.ReportDefinition.ReportObjects["txtCustomerName"] as TextObject;
                if (objtxtCustomerName != null)
                {
                    objtxtCustomerName.Text = "Customer name";
                }

                TextObject objtxtUnionName = objRpt.ReportDefinition.ReportObjects["txtUnionName"] as TextObject;
                if (objtxtUnionName != null)
                {
                    objtxtUnionName.Text = "Union name";
                }

                TextObject objtxtVillageName = objRpt.ReportDefinition.ReportObjects["txtVillageName"] as TextObject;
                if (objtxtVillageName != null)
                {
                    objtxtVillageName.Text = "Village name";
                }

                TextObject objtxtUpazillaName = objRpt.ReportDefinition.ReportObjects["txtUpazillaName"] as TextObject;
                if (objtxtUpazillaName != null)
                {
                    objtxtUpazillaName.Text = "Upazilla name";
                }

                TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                if (objtxtMobileNO != null)
                {
                    objtxtMobileNO.Text = "01720944188";
                }

                TextObject objtxtDistrict = objRpt.ReportDefinition.ReportObjects["txtDistrict"] as TextObject;
                if (objtxtDistrict != null)
                {
                    objtxtDistrict.Text = "District name";
                }

                // Account info after creation

                TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                if (objtxtAccountName != null)
                {
                    objtxtAccountName.Text = "Account name";
                }

                TextObject objtxtCANo = objRpt.ReportDefinition.ReportObjects["txtCANo"] as TextObject;
                if (objtxtCANo != null)
                {
                    objtxtCANo.Text = "34543554";
                }

                TextObject objtxtTimeDuration = objRpt.ReportDefinition.ReportObjects["txtTimeDuration"] as TextObject;
                if (objtxtTimeDuration != null)
                {
                    objtxtTimeDuration.Text = "36 months";
                }
                TextObject objtxtCustomerID = objRpt.ReportDefinition.ReportObjects["txtCustomerID"] as TextObject;
                if (objtxtCustomerID != null)
                {
                    objtxtCustomerID.Text = "Customer ID";
                }

                TextObject objtxtAccountOpenDate = objRpt.ReportDefinition.ReportObjects["txtAccountOpenDate"] as TextObject;
                if (objtxtAccountOpenDate != null)
                {
                    objtxtAccountOpenDate.Text = "06/07/2015";
                }

                TextObject objtxtExpireDate = objRpt.ReportDefinition.ReportObjects["txtExpireDate"] as TextObject;
                if (objtxtExpireDate != null)
                {
                    objtxtExpireDate.Text = "06/07/2019";
                }

                TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                if (objtxtAccountNo != null)
                {
                    objtxtAccountNo.Text = "234232342";
                }

                TextObject objtxtMonthlyDeposite = objRpt.ReportDefinition.ReportObjects["txtMonthlyDeposite"] as TextObject;
                if (objtxtMonthlyDeposite != null)
                {
                    objtxtMonthlyDeposite.Text = "500 TK";
                }

                TextObject objtxtTotalWithProfite = objRpt.ReportDefinition.ReportObjects["txtTotalWithProfite"] as TextObject;
                if (objtxtTotalWithProfite != null)
                {
                    objtxtTotalWithProfite.Text = "6500 TK";
                }

                TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (objtxtPrintDate != null)
                {
                    objtxtPrintDate.Text = "06/08/2015";
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

        private void btnDepositeInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Crystal Report data.
                crDepositeInformation objRpt = new crDepositeInformation();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null)
                {
                    objtxtAgentName.Text = "Agent name";
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null)
                {
                    objtxtOutlateName.Text = "Outlate name";
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null)
                {
                    objtxtOutletAddress.Text = "Outlate Addresss";
                }

                // Transaction Info

                TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                if (objtxtAccountName != null)
                {
                    objtxtAccountName.Text = "Account name";
                }

                TextObject objtxtTransactionDate = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                if (objtxtTransactionDate != null)
                {
                    objtxtTransactionDate.Text = "06/05/2015";
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null)
                {
                    objtxtUserID.Text = "324234";
                }

                TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                if (objtxtAmountOfMoney != null)
                {
                    objtxtAmountOfMoney.Text = "500 tk";
                }

                TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                if (objtxtAmountOfMoneyInWord != null)
                {
                    objtxtAmountOfMoneyInWord.Text = "Five Hundred Taka only";
                }

                TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                if (objtxtAccountNo != null)
                {
                    objtxtAccountNo.Text = "34234234";
                }

                TextObject objtxtTrasactionID = objRpt.ReportDefinition.ReportObjects["txtTrasactionID"] as TextObject;
                if (objtxtTrasactionID != null)
                {
                    objtxtTrasactionID.Text = "5657567";
                }

                TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (objtxtPrintDate != null)
                {
                    objtxtPrintDate.Text = "06/05/2015";
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

        private void btnWithdrawInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Crystal Report data.
                crWithdraw objRpt = new crWithdraw();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null)
                {
                    objtxtAgentName.Text = "Agent name";
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null)
                {
                    objtxtOutlateName.Text = "Outlate name";
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null)
                {
                    objtxtOutletAddress.Text = "Outlate Addresss";
                }

                // Transaction Info

                TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                if (objtxtAccountName != null)
                {
                    objtxtAccountName.Text = "Account name";
                }

                TextObject objtxtTransactionDate = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                if (objtxtTransactionDate != null)
                {
                    objtxtTransactionDate.Text = "06/05/2015";
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null)
                {
                    objtxtUserID.Text = "324234";
                }

                TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                if (objtxtAmountOfMoney != null)
                {
                    objtxtAmountOfMoney.Text = "500 tk";
                }

                TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                if (objtxtAmountOfMoneyInWord != null)
                {
                    objtxtAmountOfMoneyInWord.Text = "Five Hundred Taka only";
                }

                TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                if (objtxtAccountNo != null)
                {
                    objtxtAccountNo.Text = "34234234";
                }

                TextObject objtxtTrasactionID = objRpt.ReportDefinition.ReportObjects["txtTrasactionID"] as TextObject;
                if (objtxtTrasactionID != null)
                {
                    objtxtTrasactionID.Text = "5657567";
                }

                TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (objtxtPrintDate != null)
                {
                    objtxtPrintDate.Text = "06/05/2015";
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

        private void btnTransferInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Crystal Report data.
                crMoneyTransfer objRpt = new crMoneyTransfer();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null)
                {
                    objtxtAgentName.Text = "Agent name";
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null)
                {
                    objtxtOutlateName.Text = "Outlate name";
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null)
                {
                    objtxtOutletAddress.Text = "Outlate Addresss";
                }

                // Transaction Info

                TextObject objtxtAccountName = objRpt.ReportDefinition.ReportObjects["txtAccountName"] as TextObject;
                if (objtxtAccountName != null)
                {
                    objtxtAccountName.Text = "Account name";
                }

                TextObject objtxtAccountNo = objRpt.ReportDefinition.ReportObjects["txtAccountNo"] as TextObject;
                if (objtxtAccountNo != null)
                {
                    objtxtAccountNo.Text = "34234234";
                }

                TextObject objtxtTransactionDate = objRpt.ReportDefinition.ReportObjects["txtTransactionDate"] as TextObject;
                if (objtxtTransactionDate != null)
                {
                    objtxtTransactionDate.Text = "06/05/2015";
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null)
                {
                    objtxtUserID.Text = "324234";
                }

                TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                if (objtxtAmountOfMoney != null)
                {
                    objtxtAmountOfMoney.Text = "500 tk";
                }

                TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                if (objtxtAmountOfMoneyInWord != null)
                {
                    objtxtAmountOfMoneyInWord.Text = "Five Hundred Taka only";
                }

                // Right part data

                TextObject objtxtReceiverAccountName = objRpt.ReportDefinition.ReportObjects["txtReceiverAccountName"] as TextObject;
                if (objtxtReceiverAccountName != null)
                {
                    objtxtReceiverAccountName.Text = "RC Acount Name";
                }

                TextObject objtxtReceiverAccountNo = objRpt.ReportDefinition.ReportObjects["txtReceiverAccountNo"] as TextObject;
                if (objtxtReceiverAccountNo != null)
                {
                    objtxtReceiverAccountNo.Text = "1123444";
                }

                TextObject objtxtTrasactionID = objRpt.ReportDefinition.ReportObjects["txtTrasactionID"] as TextObject;
                if (objtxtTrasactionID != null)
                {
                    objtxtTrasactionID.Text = "5657567";
                }

                TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (objtxtPrintDate != null)
                {
                    objtxtPrintDate.Text = "06/05/2015";
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

        private void btnRemitance_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Crystal Report data.
                crRemitence objRpt = new crRemitence();

                TextObject objtxtAgentName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (objtxtAgentName != null)
                {
                    objtxtAgentName.Text = "Agent name";
                }

                TextObject objtxtOutlateName = objRpt.ReportDefinition.ReportObjects["txtOutlateName"] as TextObject;
                if (objtxtOutlateName != null)
                {
                    objtxtOutlateName.Text = "Outlate name";
                }

                TextObject objtxtOutletAddress = objRpt.ReportDefinition.ReportObjects["txtOutletAddress"] as TextObject;
                if (objtxtOutletAddress != null)
                {
                    objtxtOutletAddress.Text = "Outlate Addresss";
                }

                // Transaction Info

                TextObject objtxtRemitanceComName = objRpt.ReportDefinition.ReportObjects["txtRemitanceComName"] as TextObject;
                if (objtxtRemitanceComName != null)
                {
                    objtxtRemitanceComName.Text = "Company name";
                }

                TextObject objtxtRemitanceName = objRpt.ReportDefinition.ReportObjects["txtRemitanceName"] as TextObject;
                if (objtxtRemitanceName != null)
                {
                    objtxtRemitanceName.Text = "Name";
                }

                TextObject objtxtBenificiaryAddress = objRpt.ReportDefinition.ReportObjects["txtBenificiaryAddress"] as TextObject;
                if (objtxtBenificiaryAddress != null)
                {
                    objtxtBenificiaryAddress.Text = "Address";
                }

                TextObject objtxtTransactionID = objRpt.ReportDefinition.ReportObjects["txtTransactionID"] as TextObject;
                if (objtxtTransactionID != null)
                {
                    objtxtTransactionID.Text = "324234";
                }

                TextObject objtxtAmountOfMoney = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoney"] as TextObject;
                if (objtxtAmountOfMoney != null)
                {
                    objtxtAmountOfMoney.Text = "500 tk";
                }

                TextObject objtxtAmountOfMoneyInWord = objRpt.ReportDefinition.ReportObjects["txtAmountOfMoneyInWord"] as TextObject;
                if (objtxtAmountOfMoneyInWord != null)
                {
                    objtxtAmountOfMoneyInWord.Text = "Five Hundred Taka only";
                }

                // Right part data

                TextObject objtxtRemitanceNo = objRpt.ReportDefinition.ReportObjects["txtRemitanceNo"] as TextObject;
                if (objtxtRemitanceNo != null)
                {
                    objtxtRemitanceNo.Text = "33423423";
                }

                TextObject objtxtBenificiaryName = objRpt.ReportDefinition.ReportObjects["txtBenificiaryName"] as TextObject;
                if (objtxtBenificiaryName != null)
                {
                    objtxtBenificiaryName.Text = "Mr. Abdullah";
                }

                TextObject objtxtMobileNO = objRpt.ReportDefinition.ReportObjects["txtMobileNO"] as TextObject;
                if (objtxtMobileNO != null)
                {
                    objtxtMobileNO.Text = "01720944188";
                }

                TextObject objtxtUserID = objRpt.ReportDefinition.ReportObjects["txtUserID"] as TextObject;
                if (objtxtUserID != null)
                {
                    objtxtUserID.Text = "5657567";
                }
                TextObject objtxtPrintDate = objRpt.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (objtxtPrintDate != null)
                {
                    objtxtPrintDate.Text = "06/05/2015";
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

        private void frmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
