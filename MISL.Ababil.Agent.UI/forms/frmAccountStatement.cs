using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms;

namespace MISL.Ababil.Agent.UI.Forms
{
    public partial class frmAccountStatement : Form
    {
        public frmAccountStatement()
        {
            InitializeComponent();
            ConfigureValidation();
            mtbFrom.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            mtbTo.Text = dateTimePicker2.Value.ToString("dd-MM-yyyy");
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtAccountNo, "Account Number", (long)ValidationType.Numeric + (long)ValidationType.NonWhitespaceNonEmptyText, true);
        }

        private void frmAccountStatement_Load(object sender, EventArgs e)
        {
            this.Text = StringTable.frmAccountStatement;
            gpbAccountStatementInfo.Text = StringTable.gpbAccountStatementInfo;
            lblAccountNumber.Text = StringTable.lblAccountNumber;
            lbltName.Text = StringTable.lbltName;
            lblFromDate.Text = StringTable.lblFromDate;
            lblToDate.Text = StringTable.lblToDate;
            btnShow.Text = StringTable.btnShow;
            btnShowReport.Text = StringTable.btnShowReport;
        }

        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                try
                {
                    string[] str = mtbFrom.Text.Split('-');
                    DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                    dateTimePicker1.Value = d;
                }
                catch
                {
                    Message.showError("Please enter the date in correct format.");
                    //mtbFrom.Focus();
                    //mtbFrom.SelectAll();
                    return;
                }

                try
                {
                    string[] str = mtbTo.Text.Split('-');
                    DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                    dateTimePicker2.Value = d;
                }
                catch
                {
                    Message.showError("Please enter the date in correct format.");
                    //mtbTo.Focus();
                    //mtbTo.SelectAll();
                    return;
                }

                ///////////////////////////////////////////////////////////////////////
                // put code here
                ///////////////////////////////////////////////////////////////////////
            }
        }
        public static bool ReleaseValidationData(Form form)
        {
            return true;
        }

        private Boolean CheckValidation()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void frmAccountStatement_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

        private void mtbFrom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string[] str = mtbFrom.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dateTimePicker1.Value = d;
            }
            catch (Exception ex) { }
        }

        private void mtbTo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string[] str = mtbTo.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dateTimePicker2.Value = d;
            }
            catch (Exception ex) { }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mtbFrom.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            mtbTo.Text = dateTimePicker2.Value.ToString("dd-MM-yyyy");
        }
    }
}
