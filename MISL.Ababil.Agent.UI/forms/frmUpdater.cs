using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Services;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmUpdater : Form, ISoftwareUpdateObserver
    {
        private const string PercentageSign = @"%";
        private const string PercentageSeparator = @". ";
        private bool _progressIndicatorsReady;

        public bool OkToExit;


        public frmUpdater()
        {
            InitializeComponent();
        }

        public bool InitiateUpdate(out bool exitRequired)
        {
            bool updating = false;
            exitRequired = false;
            UpdateType updateType = UpdateService.CheckUpdateType();
            if (updateType == UpdateType.Normal)
            {
                Show();
                DialogResult response = MessageBox.Show("Your current version is " + UpdateCom.CurrentVersion + " while the latest version is " + UpdateCom.GetLatestVersion() + "\n\n" + StringTable.frmUpdater_InitiateUpdate_, StringTable.Update_Available, MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {
                    SetupProgressIndicators();
                    UpdateService.InitiateUpdate(this);
                    updating = true;
                }
                else
                {
                    Close();
                }
            }
            else if (updateType == UpdateType.Enforced)
            {
                Show();
                DialogResult response = MessageBox.Show("Your current version is " + UpdateCom.CurrentVersion + " while the latest version is " + UpdateCom.GetLatestVersion() + "\n\n" + StringTable.Mandatory_Update_Message, StringTable.Mandatory_update_available, MessageBoxButtons.OK);
                if (response == DialogResult.OK)
                {
                    SetupProgressIndicators();
                    UpdateService.InitiateUpdate(this);
                    updating = true;
                }
                else
                {
                    Close();
                    exitRequired = true;
                }
            }
            else if (updateType == UpdateType.None)
            {
                Close();
            }
            return updating;
        }
        
        public void Progressed(int progressPercentage)
        {
            lblUpdateStatus.Text = StringTable.Downloading_update_Label + 
                progressPercentage + PercentageSign + PercentageSeparator + StringTable.Thank_you_for_your_kind_patience_;
            if (_progressIndicatorsReady)
            {
                pgbDownloadProgress.Value = progressPercentage;
            }
        }

        private void SetupProgressIndicators()
        {
            if (!pgbDownloadProgress.Visible) pgbDownloadProgress.Visible = true;
            if (!lblUpdateStatus.Visible) lblUpdateStatus.Visible = true;
            if (pgbDownloadProgress.Minimum != 0) pgbDownloadProgress.Minimum = 0;
            if (pgbDownloadProgress.Maximum != 100) pgbDownloadProgress.Maximum = 100;
            lblCheckForUpdates.Text = StringTable.Update_Available_Caption;
            _progressIndicatorsReady = true;
        }

        public void Completed(string setupFileName)
        {
            if (File.Exists(setupFileName))
            {
                MessageBox.Show(
                    StringTable.Download_Completed_, StringTable.Download_Completed_Title);
                try
                {
                    Process.Start(setupFileName);
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    //ignored
                }
                OkToExit = true;
            }
        }
    }
}
