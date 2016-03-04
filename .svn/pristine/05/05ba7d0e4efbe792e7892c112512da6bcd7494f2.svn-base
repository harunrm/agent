using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Services;
using System.Configuration;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MetroFramework.Forms;
using MISL.Ababil.Agent.LocalStorageService;
using System.Threading.Tasks;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Report.DataSets;
using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.UI.forms
{

    public partial class frmLogin : Form
    {
        Boolean fingerPrintApplicable = false;
        LoginService loginService = new LoginService();
        string bioTemplate = "";
        //ActivityMonitor.ActivityMonitor _am = new ActivityMonitor.ActivityMonitor();
        private bool frmClosing = false;


        //private const int CS_DROPSHADOW = 0x00020000;
        ////private const int CS_DROPSHADOW_ = 0x1025;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        // add the drop shadow flag for automatically drawing
        //        // a drop shadow around the form
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DROPSHADOW;
        //        return cp;
        //    }
        //}

        public frmLogin()
        {
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            this.TransparencyKey = Color.Empty;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //bio.OnCapture += new EventHandler(bio_OnCapture);
            //_am.WarningMinutes = 45; //values are changed to seconds
            //_am.MaxMinutesIdle = 300; //values are changed to seconds
            //_am.Idle += new EventHandler(am_Idle);
            //pbAbabilLogo.Image = Image.FromFile(@"Contents\Ababil_Logo.jpg");
            time.BackColor = System.Drawing.Color.Transparent;
            lblDate.BackColor = System.Drawing.Color.Transparent;
            lblAgent.BackColor = System.Drawing.Color.Transparent;
            lblBankName.BackColor = System.Drawing.Color.Transparent;
            time.Text = SessionInfo.currentDate.ToString("h:mm:ss tt");
            lblDate.Text = DateTime.Now.ToLongDateString(); //check
            lbl_version.Text = "Version: " + UpdateCom.CurrentVersion;
            lbl_version.BackColor = System.Drawing.Color.Transparent;
            lbl_version.Left = lblAgent.Left + lblAgent.Width - lbl_version.Width - 3;
            //txtVersion.Text = "Version: " + UpdateCom.CurrentVersion;


            //lblPassword.BackColor = System.Drawing.Color.Transparent;
            timer1.Enabled = true;
            timer1.Interval = 1000;

            ConfigureValidation();

            Task task2 = new Task(new Action(PreLoadOnBackground), TaskCreationOptions.LongRunning);
            task2.Start();

            //show label to indicate TEST/Production
            {
                if (UtilityServices.getConfigData("mode") == "test")
                {
                    panelTest.Visible = true;
                    panelTest.Left = this.Width - panelTest.Width + 4;
                }
                else
                {
                    panelTest.Visible = false;
                }
            }
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtUsername, "Username", (long)ValidationType.UserName, true);
            ValidationManager.ConfigureValidation(this, txtPassword, "Password", (long)ValidationType.Password, true);
        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        void am_Idle(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void enableTimer()
        {
            timer1.Enabled = true;
            txtUsername.Focus();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            userLogin();
            btnLogin.Enabled = true;
        }

        private void userLogin()
        {
            try
            {
                if (validationCheck())
                {
                    if (txtUsername.Text == "")
                    {
                        Message.showWarning("User name can not be left blank");
                    }
                    else
                    {
                        if (txtPassword.Text == "")
                        {
                            Message.showWarning("Password can not be left blank");
                        }
                        else
                        {

                            if (UtilityServices.getConfigData("fingerPrintApplicable") == "Y")
                            {
                                fingerPrintApplicable = true;
                            }
                            else
                            {
                                fingerPrintApplicable = false;

                            }
                            fingerPrintApplicable = loginService.RequiresBiometricAuthentication(txtUsername.Text);

                            if (fingerPrintApplicable)
                            {
                                bio.CaptureFingerData();
                            }

                            else
                            {
                                ProgressUIManager.ShowProgress(this);
                                login();
                                ProgressUIManager.CloseProgress();

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnLogin.Enabled = true;
                Message.showError(ex.Message);
            }


            //frmPro.Close();
            //this.Enabled = true;
            //this.UseWaitCursor = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            exitConfirmation();
            Application.ExitThread();
            Application.Exit();
        }

        private bool exitConfirmation()
        {
            if (Message.showConfirmation("Do you want to exit the application?") == "yes")
            {
                frmClosing = true;
                timer1.Enabled = false;
                return true;
            }
            return false;
        }

        private void clearInputControls()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void taskRun()
        {
            LocalStorage localStorage = new LocalStorage();
            localStorage.Sync();
        }

        private void login()
        {
            string userName = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                if (loginService.authenticate(userName, password, fingerPrintApplicable, bioTemplate))
                {
                    Action action = new Action(taskRun);
                    Task task = new Task(action);
                    task.Start();

                    frmMainApp mainApp = new frmMainApp(this);
                    mainApp.Show();
                    clearInputControls();
                    timer1.Enabled = false;
                    this.Hide();

                    if (SessionInfo.isexpired == true)
                    {
                        ProgressUIManager.CloseProgress();
                        mainApp.Enabled = false;
                        mainApp.MainMenuStrip.Enabled = false;
                        frmPasswordChange frm = new frmPasswordChange();
                        frm.ControlBox = false;
                        frm.btnCancel.Visible = false;
                        frm.btnOK.Location = frm.btnCancel.Location;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Application.ExitThread();
                            Application.Restart();
                        }
                    }
                }
                else
                {
                    Message.showError("Invalid username or password!");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid user information")
                {
                    Message.showError("Invalid username or password!");
                }
                else
                {
                    Message.showError(ex.Message);
                }
            }
        }

        private void PreLoadOnBackground()
        {
            frmReportViewer frm = new frmReportViewer();
            crBlankReport repObj = new crBlankReport();
            frm.crvReportViewer.ReportSource = repObj;
            frm.Width = 0;
            frm.Height = 0;
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Minimized;
            frm.Show();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnLogin.Focus();                
                userLogin();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void bio_OnCapture(object sender, EventArgs e)
        {

            AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            if (x.result == "0")
            {
                bioTemplate = bio.GetSafeLeftFingerData();
                if (bioTemplate != "")
                {
                    login();
                }
                else
                {
                    Message.showWarning("Finger print not found");
                }

            }

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmClosing == false)
            {
                frmClosing = true;
                if (exitConfirmation() == false)
                {
                    e.Cancel = true;
                    frmClosing = false;
                }
                else
                {
                    frmClosing = true;
                    ValidationManager.ReleaseValidationData(this);
                    Application.ExitThread();
                    Application.Exit();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //ConfigureValidation();
        }

        private void frmLogin_Paint(object sender, PaintEventArgs e)
        {
            ////this.BackImage = this.BackgroundImage;
            //Graphics g = this.CreateGraphics();
            ////g.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
            //g.DrawRectangle(new Pen(Color.FromArgb(0, 68, 68, 68)), 0, 0, this.Width, this.Height);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //g.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //g.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            ////g.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
            //g.DrawRectangle(new Pen(Color.FromArgb(255, 68, 68, 68)), 0, 0, this.Width-1, this.Height-3);
            //g.DrawRectangle(new Pen(Color.FromArgb(255, 68, 68, 68)), 1, 1, this.Width - 2, this.Height - 4);
            //g.DrawRectangle(new Pen(Color.FromArgb(255, 68, 68, 68)), 2, 2, this.Width - 3, this.Height - 5);
        }
    }
}
