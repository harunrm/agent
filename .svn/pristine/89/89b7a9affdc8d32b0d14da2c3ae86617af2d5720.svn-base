using System;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MetroFramework.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmBranchUserRegistration : MetroForm
    {
        public frmBranchUserRegistration()
        {
            InitializeComponent();
            cmbRoles.SelectedIndex = 2;
            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtFirstName, "First Name", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, txtLastName, "Last Name", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, txtUserName, "Username", (long)ValidationType.UserName, true);
            ValidationManager.ConfigureValidation(this, txtPassword, "Password", (long)ValidationType.StrongPassword, true);
            ValidationManager.ConfigureValidation(this, cmbRoles, "Role", (long)ValidationType.ListSelected, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            if (validationCheck())
            {
                if (!validateInputs())
                {
                    btnSave.Enabled = true;
                    return;
                }

                BranchUser user = FillBranchUser();

                ProgressUIManager.ShowProgress(this);
                ServiceResult result = UserService.CreateBranchUser(user);
                ProgressUIManager.CloseProgress();

                if (result.Success)
                {
                    ClearAllInputData();
                    //MessageBox.Show(StringTable.Branch_user_ + txtUserName.Text + StringTable.was_created_successfully, StringTable.Success);
                    MessageBox.Show("User " + txtUserName.Text + StringTable.was_created_successfully, StringTable.Success);

                }
                else
                {
                    //MessageBox.Show(StringTable.Branch_user_ + txtUserName.Text + StringTable.CreationFailedFor + result.Message, StringTable.Failure);
                    MessageBox.Show("User " + txtUserName.Text + StringTable.CreationFailedFor + result.Message, StringTable.Failure);
                }
            }

            btnSave.Enabled = true;
        }

        private void ClearAllInputData()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPasswordRetype.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }

        private BranchUser FillBranchUser()
        {
            BranchUser user = new BranchUser();
            user.firstName = txtFirstName.Text;
            user.lastName = txtLastName.Text;
            user.username = txtUserName.Text;
            user.password = txtPassword.Text;
            user.userRole = cmbRoles.Text;
            return user;
        }

        private bool validateInputs()
        {
            string validationMessage = "";

            if (!txtPassword.Text.Equals(txtPasswordRetype.Text))
                validationMessage += StringTable.TheTwoPasswordsDoNotMatch;

            if (txtUserName.Text.Trim().Length < 1)
                validationMessage += StringTable.ValidUserNameRequired;

            if (txtPassword.Text.Trim().Length < 1)
                validationMessage += StringTable.ValidPasswordRequired;

            if (txtFirstName.Text.Trim().Length < 1)
                validationMessage += StringTable.ValidFirstNameRequired;

            if (txtLastName.Text.Trim().Length < 1)
                validationMessage += StringTable.ValidLastNameRequired;

            if (!validationMessage.Equals(""))
            {
                MessageBox.Show(StringTable.PleaseCorrectTheFollowingInputErrors + validationMessage, StringTable.InputErrors);
                return false;
            }

            return true;
        }

        private void frmBranchUserRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllInputData();
        }
    }
}