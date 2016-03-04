using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmRemittanceComment : Form
    {
        public frmRemittanceComment()
        {
            InitializeComponent();
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            if(txtComment.Text.Length>0)
            {
                btnReject.Enabled = true;
            }
            else
            {
                btnReject.Enabled = false;
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

        }
    }
}
