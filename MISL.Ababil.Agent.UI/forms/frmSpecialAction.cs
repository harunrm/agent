using MetroFramework.Forms;
using MISL.Ababil.Agent.Services;
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
    public partial class frmSpecialAction : MetroForm
    {
        public frmSpecialAction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpecialServices specialServices = new SpecialServices();
            Message.showInformation(specialServices.MoveDocToFlat());
        }
    }
}
