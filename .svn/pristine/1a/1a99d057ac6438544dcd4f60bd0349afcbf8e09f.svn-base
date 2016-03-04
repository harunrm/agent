using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.security
{
    public partial class EditMenuDialog : Form
    {
        public EditMenuDialog()
        {
            InitializeComponent();
        }

        private void EditMenuDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        public string MenuName
        {
            get;
            set;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.MenuName = menuNameTextBox.Text;
            if (this.MenuName == null || this.MenuName.Trim() == String.Empty)
            {
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
