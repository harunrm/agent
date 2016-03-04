using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.CustomControls
{
    public partial class frmCustomControlTest : Form
    {
        GUI gui = new GUI();
        public frmCustomControlTest()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void frmCustomControlTest_Load(object sender, EventArgs e)
        {
            gui = new GUI(this);

            gui.Config(ref customDateTimePicker1);
            gui.Config(ref metroTextBox1);
            gui.Config(ref metroTextBox2);
            gui.Config(ref metroTextBox3);

            Task taskCheckForUpdate = new Task(() =>
            {
                retVal = LocalStorageService.LocalCache.GetCountries();
            });

            taskCheckForUpdate.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = customDateTimePicker1.Date;
        }

        BindingSource bs = new BindingSource();
        //List<TransactionPurpose> retVal = LocalStorageService.LocalCache.Caches.GetTransactionPurposeList();
        List<Country> retVal = new List<Country>();

        


        private void button3_Click(object sender, EventArgs e)
        {            
            bs.DataSource = retVal;
            UtilityServices.fillComboBox(metroComboBox1, bs, "name", "code");
            metroComboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LocalStorageService.LocalStorage ls = new LocalStorageService.LocalStorage();
            //MessageBox.Show( ls.CheckForUpdate());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LocalStorageService.LocalStorage ls = new LocalStorageService.LocalStorage();
            this.Text = ls.CheckForUpdate().ToString();
        }
    }
}