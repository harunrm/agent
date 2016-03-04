using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmAccountCreation : Form
    {
        public frmAccountCreation()
        {
            InitializeComponent();

            ConfigureValidation();

        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, cmbProduct, "Product", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbCurrency, "Currency", (long)ValidationType.ListSelected, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void txtPercentage_Leave(object sender, EventArgs e)
        {
            double decValue;
            if (double.TryParse(txtPercentage.Text, out decValue))
            {
              txtPercentage.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
        }

        private void txtPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void frmAccountCreation_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }
        public static bool ReleaseValidationData(Form form)
        {
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int queueId = ValidationManager.QueueValidateControl (cmbIndividualId, "Individual", (long)ValidationType.ListSelected, 0, true);
            ValidationManager.QueueValidateControl(txtRelation, "Relation", (long)ValidationType.NonWhitespaceNonEmptyText, queueId, false);
            ValidationManager.QueueValidateControl(txtPercentage, "Share percentage", (long)ValidationType.Integral + (long)ValidationType.WithinRange, queueId, true, false, 1, 100);
            ValidationManager.ValidateQueue(queueId);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {           
            if (ValidationCheck())
            {
                ProgressUIManager.ShowProgress(this);
                //
                //add time consuming code here.
                //
                ProgressUIManager.CloseProgress();
            }        
        }

        private Boolean ValidationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

    }
}
