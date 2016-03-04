using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
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
    public partial class frmBrRemarks : Form
    {
        public frmBrRemarks()
        {
            InitializeComponent();
        }
        public frmBrRemarks(ConsumerAppResultDto _consumerApp)
        {
            InitializeComponent();
            if (_consumerApp != null && _consumerApp.appId != 0)
                setAppData(_consumerApp);
        }
        private void setAppData(ConsumerAppResultDto consumerApp)
        {
            lblConsumerName.Text = consumerApp.consumerName;
            lblMobileNo.Text = consumerApp.mobileNo;
            //----lblRemarks.Text = consumerApp.remarks;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
