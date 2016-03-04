using MISL.Ababil.Agent.Infrastructure.Models.dto;
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
    public partial class frmExchangeHouseSetup : Form
    {
        public frmExchangeHouseSetup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ExchangeHouseSetupDto exchangeHouseSetupDto = new ExchangeHouseSetupDto();
            exchangeHouseSetupDto.exchangeHouse = new Infrastructure.Models.domain.models.Remittance.ExchangeHouse();
            exchangeHouseSetupDto.exchangeHouse.companyName = txtExchangeName.Text;
            //exchangeHouseSetupDto.remitanceAccountSetup.accountNature = (Infrastructure.Models.domain.models.Remittance.AccountNature)cmbAccountType.SelectedIndex;
            exchangeHouseSetupDto.remitanceAccountSetup = new Infrastructure.Models.domain.models.Remittance.RemitanceAccountSetup();
            exchangeHouseSetupDto.remitanceAccountSetup.accountNature = (Infrastructure.Models.domain.models.Remittance.AccountNature)cmbAccountType.SelectedIndex;
            exchangeHouseSetupDto.exchangeHouse.shortName = txtShortName.Text;


            ExchangeHouseSetupService exchangeHouseSetupService = new ExchangeHouseSetupService();

            string responseString = exchangeHouseSetupService.saveExchangeHouseSetup(exchangeHouseSetupDto);

            MessageBox.Show(responseString);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}