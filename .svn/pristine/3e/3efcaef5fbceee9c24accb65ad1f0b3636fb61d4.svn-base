using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MetroFramework.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmUserCreate : MetroForm
    {
        private GUI _gui = new GUI();
        private List<BiometricTemplate> _fingerList;

        frmSubAgent _frmsubagent;

        public frmUserCreate()
        {
            InitializeComponent();
            _frmsubagent = new frmSubAgent();

            ConfigureValidation();

            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);
            _gui.Config(ref txtUserName, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, "");
            _gui.Config(ref txtPassword, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, "");
            _gui.Config(ref txtPassword2, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, "");
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtUserName, "User Name", (long)ValidationType.UserName, true);
            ValidationManager.ConfigureValidation(this, txtPassword, "Password", (long)ValidationType.StrongPassword, true);
        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFingerprintCapture objFrmFinger = new frmFingerprintCapture(txtUserName.Text.Trim());

            DialogResult dr = objFrmFinger.ShowDialog();
            if (dr == DialogResult.OK)
            {

                _fingerList = objFrmFinger.bioMetricTemplates;

            }
            if (_fingerList != null)
                lblFingerprintResult.Text = "Fingerprint captured successfully";
            else
                lblFingerprintResult.Text = "Fingerprint capture failed";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validationCheck() && isPasswordSame())
            {
                btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                //put "ADD" code here.
            }
        }

        private bool isPasswordSame()
        {
            if (txtPassword.Text == txtPassword2.Text)
            {
                return true;
            }
            else
            {
                Message.showError("Password didn't match! Please retype the same password.");
                return false;
            }
        }

        private void frmUserCreate_Load(object sender, EventArgs e)
        {

        }

        public SubAgentUser newUsercredentials()
        {


            SubAgentUser usrInfo = new SubAgentUser();

            usrInfo.username = txtUserName.Text;
            usrInfo.password = txtPassword.Text;
            usrInfo.fingerDatas = _fingerList;
            return usrInfo;

        }

        private void frmUserCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

    }
}
