using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.MessageUI;
using MISL.Ababil.Agent.UI.forms.CustomControls;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.UI.forms.Development;
using MISL.Ababil.Agent.CustomControls;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Module.ChequeRequisition.UI;
using MISL.Ababil.Agent.Module.ChequeRequisition.Report;
using MISL.Ababil.Agent.Module.Security.UI;
using MISL.Ababil.Agent.Module.Security.UI.FingerprintUI;
using MISL.Ababil.Agent.Module.Security.UI.PasswordResetUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmMainApp : Form
    {
        frmLogin _objFrmLogin = new frmLogin();
        frmGeetings _objfrmGreenting = new frmGeetings();
        MenuService _menuService;
        private bool _frmClosing = false;

        public frmMainApp(frmLogin objLogin)
        {
            this._menuService = new MenuService();
            //this.TransparencyKey = Color.Empty;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            _objFrmLogin = objLogin;

            lblUserName.Text = SessionInfo.username;
            lblLastLoginTime.Text = "Last Login Time: " + SessionInfo.loginTime.ToString();
            lblUserName.BackColor = Color.Transparent;
            lblLastLoginTime.BackColor = Color.Transparent;
            userNameToolStripMenuItem.Text = SessionInfo.username;
            lastLoginToolStripMenuItem.Text = "Last Login : " + SessionInfo.loginTime.ToString();

            RerenderBackgroundWithUserInfo();
        }

        private void frmMainApp_Load(object sender, EventArgs e)
        {
            //SpecialUserAccess
            if (SessionInfo.username == "branch_sh")
            {
                if (UtilityServices.isRightExist(Rights.ADMINISTRATIVE))
                {
                    administrativeToolStripMenuItem.Visible = true;
                    specialActionMenuItemToolStripMenuItem.Visible = true;
                }
                this.MainMenuStrip = menuBranch;
                menuBranch.Visible = true;
                return;
            }

            if (UtilityServices.getConfigData("useStaticMenu") == "N")
            {
                _menuService.InitializeMenu(this);
            }
            else
            {
                if (UtilityServices.isRoleExist(Roles.adminOfficer))
                {

                    if (UtilityServices.isRightExist(Rights.ADMINISTRATIVE))
                    {
                        administrativeToolStripMenuItem.Visible = true;
                    }
                    this.MainMenuStrip = menuBranch;
                    menuBranch.Visible = true;
                }
                if (UtilityServices.isRoleExist(Roles.branchOfficer))
                {
                    this.MainMenuStrip = menuBranch;
                    menuBranch.Visible = true;
                }
                if (UtilityServices.isRoleExist(Roles.fieldOfficer))
                {
                    this.MainMenuStrip = menuFieldOfficer;
                    menuFieldOfficer.Visible = true;
                }
                if (UtilityServices.isRoleExist(Roles.agent))
                {
                    this.MainMenuStrip = menuAgent;
                    menuAgent.Visible = true;
                }
                if (UtilityServices.isRoleExist(Roles.subAgent))
                {
                    this.MainMenuStrip = menuSubAgent;
                    menuSubAgent.Visible = true;
                }
                if (UtilityServices.isRoleExist(Roles.RemittanceApprover))
                {
                    this.MainMenuStrip = menuRemittance;
                    menuRemittance.Visible = true;
                }
            }
        }

        private void frmMainApp_Resize(object sender, EventArgs e)
        {
            // objfrmGreenting.Location = new Point((this.Width / 2) - (objfrmGreenting.Width / 2), 40);
            picExit.Location = new Point(this.Width - 100, this.Height - 150);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objFrmLogin.Show();
            _objFrmLogin.enableTimer();
            this.Close();
        }

        private void createAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool rightExist = SessionInfo.rights.Any(p => p == Rights.APPROVE_CONSUMER.ToString());
            if (rightExist)
            {
                frmAgentCreation objFrmAgentCreation = new frmAgentCreation();
                objFrmAgentCreation.MdiParent = this;
                objFrmAgentCreation.Show();
            }
        }

        private void createIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  frmIndividualInformation objFrmIndividualInformation = new frmIndividualInformation();
              objFrmIndividualInformation.MdiParent = this;
              objFrmIndividualInformation.Show();*/
        }

        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // frmCustomer objFrmCustomer = new frmCustomer();
            //objFrmCustomer.MdiParent = this;
            //objFrmCustomer.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAccountCreation objFrmAccCreate = new frmAccountCreation();
            objFrmAccCreate.MdiParent = this;
            objFrmAccCreate.Show();
        }

        private void createUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUserCreate objfrmUserCreate = new frmUserCreate();
            objfrmUserCreate.MdiParent = this;
            objfrmUserCreate.Show();
        }

        private void createSubAgentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool rightExist = SessionInfo.rights.Any(p => p == Rights.APPROVE_CONSUMER.ToString());
            if (rightExist)
            {
                frmSubAgent objfrmSubAgent = new frmSubAgent();
                objfrmSubAgent.MdiParent = this;
                objfrmSubAgent.Show();
            }
        }

        private void createConsumerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            frmConsumerCreation objfrmConsumerCreation = new frmConsumerCreation(packet, null);
            objfrmConsumerCreation.MdiParent = this;
            objfrmConsumerCreation.Show();
        }

        private void cashDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashDeposit objfrmCashDeposit = new frmCashDeposit();
            //objfrmCashDeposit.MdiParent = this;
            objfrmCashDeposit.ShowDialog(this);
        }

        private void cashWithdrawToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCashWithdraw objfrmCashWithdraw = new frmCashWithdraw();
            //objfrmCashWithdraw.MdiParent = this;
            objfrmCashWithdraw.ShowDialog(this);
        }

        private void fundTransferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFundTransfer objfrmFundTransfer = new frmFundTransfer();
            //objfrmFundTransfer.MdiParent = this;
            objfrmFundTransfer.ShowDialog(this);
        }

        private void balanceInquiryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBalanceInquiry objfrmBalanceInquiry = new frmBalanceInquiry();
            // objfrmBalanceInquiry.MdiParent = this;
            objfrmBalanceInquiry.ShowDialog(this);
        }

        private void miniStatementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMiniStatement objfrmMiniStatement = new frmMiniStatement();
            // objfrmMiniStatement.MdiParent = this;
            objfrmMiniStatement.ShowDialog(this);
        }

        private void viewAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgent objfrmAgent = new frmAgent();
            objfrmAgent.MdiParent = this;
            objfrmAgent.Show();
        }

        private void consumerApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            frmConsumerApplication objfrmConsumerApplication = new frmConsumerApplication(packet);
            objfrmConsumerApplication.ShowInTaskbar = false;
            objfrmConsumerApplication.ShowDialog(this);
        }

        private void consumerCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            frmConsumerCreation objfrmConsumerCreation = new frmConsumerCreation(packet, null);
            objfrmConsumerCreation.MdiParent = this;
            objfrmConsumerCreation.Show();
        }

        private void consumerApplicationSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPendingApplication objfrmPendingApplication = new frmPendingApplication();
            objfrmPendingApplication.ShowDialog(this);
        }

        private void transactionProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerTransactionProfile objFrmCustomerTransactionProfile = new frmCustomerTransactionProfile();
            objFrmCustomerTransactionProfile.MdiParent = this;
            objFrmCustomerTransactionProfile.Show();
        }

        private void kYCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmKYC objFrmKyc = new frmKYC();
            // objFrmKyc.MdiParent = this;
            // objFrmKyc.Show();
        }

        private void reportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowReport objfrmShowReport = new frmShowReport();
            objfrmShowReport.MdiParent = this;
            objfrmShowReport.Show();
        }

        private void consumerApplicationSearchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAllConsumerApplicationSearch objfrmallconsumerapplicationsearch = new frmAllConsumerApplicationSearch();
            //objfrmallconsumerapplicationsearch.MdiParent = this;
            objfrmallconsumerapplicationsearch.Show(this);
        }

        private void remittanceAgentRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemittanceAgentRequest objfrmRemittanceAgentRequest = new frmRemittanceAgentRequest();
            //objfrmRemittanceAgentRequest.MdiParent = this;
            objfrmRemittanceAgentRequest._IsFromAdmin = false;
            objfrmRemittanceAgentRequest.ShowDialog(this);
        }

        private void transactionRecordSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactionRecodeSearch objTransactionRecodeSearch = new frmTransactionRecodeSearch();
            //objTransactionRecodeSearch.MdiParent = this;
            objTransactionRecodeSearch.ShowDialog(this);
        }

        private void transactionRecordSearchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmTransactionRecordForBranch objTransactionRecodeSearch = new frmTransactionRecordForBranch();
            objTransactionRecodeSearch.MdiParent = this;
            objTransactionRecodeSearch.Show();
        }

        //private void transactionRecordSearchToolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    frmTransactionRecordForBranch objTransactionRecodeSearch = new frmTransactionRecordForBranch();
        //    objTransactionRecodeSearch.MdiParent = this;
        //    objTransactionRecodeSearch.Show();
        //}


        private void remittanceAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemittanceAdmin objRemittanceAdmin = new frmRemittanceAdmin();
            //objRemittanceAdmin.MdiParent = this;
            objRemittanceAdmin.ShowDialog(this);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void picExit_Click(object sender, EventArgs e)
        {
            logout();
        }

        private bool logout()
        {
            //if (MessageBox.Show("Do you want to logout?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (Message.showConfirmation("Do you want to logout?") == "yes")
            {
                if (this.MdiChildren.Length > 0)
                {
                    //MessageBox.Show("Please close all child windows before logging-out.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Message.showWarning("Please close all child windows before logging-out.");
                    return false;
                }
                else
                {
                    _objFrmLogin.Show();
                    _objFrmLogin.enableTimer();
                    _frmClosing = true;
                    this.Close();
                    return true;
                }
            }
            return false;
        }

        private void searchAgentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgentSearch agentSearch = new frmAgentSearch();
            agentSearch.MdiParent = this;
            agentSearch.Show();
        }

        private void agentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAgent agent = new frmAgent();
            agent.MdiParent = this;
            agent.Show();
        }

        private void branchUserCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool rightExist = SessionInfo.rights.Any(p => p == Rights.CREATE_BANK_USER.ToString());
            if (rightExist)
            {
                frmBranchUserRegistration branchUser = new frmBranchUserRegistration();
                branchUser.ShowDialog();
            }
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            logout();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMainApp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RerenderBackgroundWithUserInfo()
        {
            try
            {
                string fileName = Path.GetTempPath() + "aab_bitmap_tmp.bmp";

                try
                {
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }
                catch (Exception ex) { }

                Bitmap b = new Bitmap(this.BackgroundImage);
                Graphics g = Graphics.FromImage(b);
                //{
                //    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                //    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                //}
                g.DrawImage(picUser.Image, picUser.Left, picUser.Top, picUser.Width, picUser.Height);
                // g.DrawImage(picExit.Image, picExit.Left, picExit.Top, picExit.Width, picExit.Height);
                g.DrawString(lblUserName.Text, lblUserName.Font, Brushes.Black, new PointF(lblUserName.Left, lblUserName.Top));
                g.DrawString(lblLastLoginTime.Text, lblLastLoginTime.Font, Brushes.Black, new PointF(lblLastLoginTime.Left, lblLastLoginTime.Top));

                MemoryStream ms = new MemoryStream();
                b.Save(ms, ImageFormat.Png);
                this.BackgroundImage = (Image)Bitmap.FromStream(ms);
                ms.Close();
            }
            catch (Exception ex) { }
        }

        private void sSPAccountRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            packet.intentType = IntentType.SelfDriven;
            TermAccountRequestDto termAccountRequestDto = null;
            frmTermAccountOpening termForm = new frmTermAccountOpening(packet, termAccountRequestDto);
            //termForm.MdiParent = this;
            termForm.ShowDialog(this);
        }

        private void sSPRequestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTermRequestSearch frm = new frmTermRequestSearch();
            //frm.MdiParent = this;
            frm.ShowDialog(this);


            //frmSSPRequestList sspRequestListForm = new frmSSPRequestList();
            //sspRequestListForm.MdiParent = this;
            //sspRequestListForm.Show();
        }

        private void dayWiseTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactionRecord frmTrnRec = new frmTransactionRecord();
            frmTrnRec.MdiParent = this;
            frmTrnRec.Show();
        }

        private void setFingerprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetFingerprint objSetFingerPrint = new frmSetFingerprint();
            objSetFingerPrint.Show();
        }

        private void accountOpeningReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountOpeningRport frmAccOpen = new frmAccountOpeningRport();
            //frmAccOpen.MdiParent = this;
            frmAccOpen.ShowDialog(this);
        }

        private void frmMainApp_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (_frmClosing == false)
            {
                _frmClosing = true;
                if (logout() == false)
                {
                    e.Cancel = true;
                    _frmClosing = false;
                }
                else
                {
                    _frmClosing = true;
                }
            }
        }

        private void accountWiseBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountWiseBalance frmAccBalance = new frmAccountWiseBalance();
            frmAccBalance.ShowDialog(this);
        }

        private void remittanceRecordSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemittanceRecord objRemittanceRecord = new frmRemittanceRecord();
            //objRemittanceRecord.MdiParent = this;
            objRemittanceRecord.ShowDialog(this);
        }

        private void agentIncomeStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgentIncomeStatement objFrmAgentIncomeStatement = new frmAgentIncomeStatement();
            //objFrmAgentIncomeStatement.MdiParent = this;
            objFrmAgentIncomeStatement.ShowDialog(this);
        }

        private void agentCashRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashRegister objFrmAgentIncomeStatement = new frmCashRegister();
            //objFrmAgentIncomeStatement.MdiParent = this;
            objFrmAgentIncomeStatement.ShowDialog(this);
        }

        private void sSPRequestSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTermRequestSearch frm = new frmTermRequestSearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void agentCommissionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgentCommissionRport frm = new frmAgentCommissionRport();
            //frm.MdiParent = this;
            frm.ShowDialog(this);
        }

        private void cashEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            frmCashEntry frm = new frmCashEntry(packet);
            frm.ShowDialog(this);
        }

        private void agentTransactionMonitoringReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrMonitoringRport frm = new frmTrMonitoringRport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cashInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashInformation frm = new frmCashInformation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accountMonitoringReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountMonitoringRport frm = new frmAccountMonitoringRport();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void cashInformationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAgentDayEndSummary objfrmAgentDayEndSummary = new frmAgentDayEndSummary();
            objfrmAgentDayEndSummary.MdiParent = this;
            objfrmAgentDayEndSummary.Show();
        }

        private void searchSubagentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubagentSearch objfrmSubagentSearch = new frmSubagentSearch();
            objfrmSubagentSearch.MdiParent = this;
            objfrmSubagentSearch.Show();
        }

        private void kYCViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKYCViewer frm = new frmKYCViewer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuSubAgent_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void transactionProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void transactionProfileToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmTransactionProfile frm = new frmTransactionProfile();
            frm.MdiParent = this;
            frm.Show();
        }

        private void exchangeHouseSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExchangeHouseSetup frm = new frmExchangeHouseSetup();
            frm.ShowDialog();
        }

        private void billPaymentConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillPaymentConfiguration frm = new frmBillPaymentConfiguration();
            frm.ShowDialog();
        }

        private void billPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            packet.intentType = IntentType.SelfDriven;

            frmBillPayment frm = new frmBillPayment(packet, null);
            frm.ShowDialog(this);
        }

        private void tmpExhouseConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExchangeHouseSetup frm = new frmExchangeHouseSetup();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPasswordChange frm = new frmPasswordChange();
            frm.ShowDialog(this);
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMainWindow frm = new frmMainWindow();
            frm.Show();
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            frmCashRegister objFrmAgentIncomeStatement = new frmCashRegister();
            //objFrmAgentIncomeStatement.MdiParent = this;
            objFrmAgentIncomeStatement.ShowDialog(this);
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            frmTransactionProfile frm = new frmTransactionProfile();
            frm._viewMode = true;
            frm.ShowDialog(this);
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard.frmDashboard frm = new Dashboard.frmDashboard();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void tESTToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tESTMSGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMessageUI frm = new frmMessageUI();
            //frm.ShowDialog();
            //frmTestTemp frm = new frmTestTemp();
            //frm.Show();
            frmOutletList frm = new frmOutletList();
            frm.Show();
        }

        private void cashInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //frmAgentDayEndSummary frmCashInfo = new frmAgentDayEndSummary();
            //frmCashInfo.ShowDialog();
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            packet.intentType = IntentType.SelfDriven;
            frmOutletCashInfoAll frm = new frmOutletCashInfoAll(packet);
            frm.ShowDialog();
        }

        private void viewCustomerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerSearch frmCust = new frmCustomerSearch();
            frmCust.ShowDialog();
        }

        private void tESTCustDTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommentUI.frmCommentUI frm = new CommentUI.frmCommentUI();
            frm.ShowDialog();
            //try
            //{
            //  frmCustomControlTest frm = new frmCustomControlTest();
            //  frm.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    Message.showError(ex.Message);
            //}
        }

        private void mTDRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowReport objfrmShowReport = new frmShowReport();
            objfrmShowReport.MTDReport("");

        }

        private void cacheUpdateAdministrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CacheUI.frmCacheUpdateAdministration frm = new CacheUI.frmCacheUpdateAdministration();
            frm.ShowDialog();
        }

        private void dataAssignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataAsign frm = new frmDataAsign();
            frm.ShowDialog();
        }

        private void frmCustomerTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            frmCustomer frm = new frmCustomer(packet, null);
            frm.ShowDialog();
        }

        private void loadReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportViewer frm = new frmReportViewer();
            crBlankReport repObj = new crBlankReport();
            frm.crvReportViewer.ReportSource = repObj;
            frm.ShowDialog();
        }

        private void outletLimitSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOutletList frm = new frmOutletList();
            frm.ShowDialog();
        }

        private void cashInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            OutletCashSumReqDto outletCashSumReqDto = new OutletCashSumReqDto();
            outletCashSumReqDto.informationDate = SessionInfo.currentDate;
            outletCashSumReqDto.outletId = SessionInfo.userBasicInformation.outlet.id;
            frmOutletCashInfo frm = new frmOutletCashInfo(packet, outletCashSumReqDto);
            frm.ShowDialog(this);
        }

        private void specialActionMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSpecialAction frm = new frmSpecialAction();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePasswordToolStripMenuItem1_Click(sender, e);
        }

        private void resetCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Message.showConfirmation("Do you want to reset local cache?\n\nPlease save all your work before continuing. You will be logged-out in this process.") == "yes")
            {
                ProgressUIManager.ShowProgress(this);
                LocalStorageService.LocalStorage ls = new LocalStorageService.LocalStorage();
                bool retVal = ls.ResetLocalCache();
                if (!retVal)
                {
                    Message.showError("Failed to reset the Cache!");
                }
                ls = null;
                ProgressUIManager.CloseProgress();
                _frmClosing = true;
                //_objFrmLogin.Show();
                //this.Close();
                Application.ExitThread();
                Application.Restart();
            }
        }

        private void billPaymentInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBillPaymentReport frm = new frmBillPaymentReport();

            frm.ShowDialog();
        }

        private void billPaymentInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmBillPaymentReport frm = new frmBillPaymentReport();
            frm.ShowDialog(this);
        }

        private void chequeRequisitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            frmChequeRequisitionRequest frm = new frmChequeRequisitionRequest(packet, new Module.ChequeRequisition.Models.ChequeRequisitionSearchResultDto());
            frm.ShowDialog(this);
        }

        private void chequeRequisitionSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Module.ChequeRequisition.UI.frmChequeRequisitionSearch frm = new Module.ChequeRequisition.UI.frmChequeRequisitionSearch();
            frm.ShowDialog(this);
        }

        private void transactionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTransactionReport frm = new frmTransactionReport();
            frm.ShowDialog();
        }

        private void dailyTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactionReport frm = new frmTransactionReport();
            frm.ShowDialog();
        }

        private void dailyTransactionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTransactionReport frm = new frmTransactionReport();
            frm.ShowDialog();
        }

        private void chequeRequisitionSearchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Module.ChequeRequisition.UI.frmChequeRequisitionSearch frm = new Module.ChequeRequisition.UI.frmChequeRequisitionSearch();
            frm.ShowDialog(this);
        }

        private void chequeRequsitionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChequeRequisitionInformation frm = new frmChequeRequisitionInformation();
            frm.ShowDialog(this);
        }

        private void chequeDeliveryInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChequeDeliveryReport frm = new frmChequeDeliveryReport();
            frm.ShowDialog();
        }

        private void agentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgentInformationReport frm = new frmAgentInformationReport();
            frm.loadAgentInformation();
            //frm.ShowDialog();
        }

        private void outletInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOutletInfoReport frm = new frmOutletInfoReport();
            frm.ShowDialog();
        }

        private void fingerprintManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fingerprintManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            frmFingerprintChangeRequest frm = new frmFingerprintChangeRequest(packet, null, null, null);
            frm.ShowDialog(this);
        }

        private void fingerprintAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            frmFingerprintAdmin frm = new frmFingerprintAdmin();
            frm.ShowDialog(this);
        }

        private void fingerprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            frmFingerprintAdmin frm = new frmFingerprintAdmin();
            frm.ShowDialog(this);
        }

        private void outletUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOutletUserInfoReport frm = new frmOutletUserInfoReport();
            frm.ShowDialog(this);
        }

        private void agentCashInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAgentCashInformationReport frm = new frmAgentCashInformationReport();
            frmAgentCashInformation frm = new frmAgentCashInformation();
            frm.ShowDialog();
        }

        private void passwordResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet();
            packet.actionType = FormActionType.New;
            frmPasswordResetAdmin frm = new frmPasswordResetAdmin(packet);
            frm.ShowDialog(this);
        }
    }
}