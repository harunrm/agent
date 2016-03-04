using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MetroFramework.Forms;
using MISL.Ababil.Agent.LocalStorageService;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCashEntry : MetroForm
    {

        private Packet _receivePacket;
        public GUI _gui = new GUI();
        private OutletCashTransactionRegister _cashTransactionDto = null;
        public frmCashEntry(Packet packet)
        {
            InitializeComponent();
            _receivePacket = packet;
            InitialSetup();   
        }

        private void InitialSetup()
        {
            SetupDataLoad();
            SetupComponents();
        }

        private void SetupDataLoad()
        {
            //SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
            //txtOutletName.Text = currentSubagentInfo.name;

            txtOutletName.Text = LocalCache.OwnSubagentCachingData.subAgentCacheDto.subAgentName;

            dtpDate.Value = SessionInfo.currentDate;
            mtbDate.Text = dtpDate.Value.ToString("dd-MM-yyyy");

            CashEntryService cashEntryService = new CashEntryService();
            BindingSource bs = new BindingSource();
            List<TransactionPurpose> retVal = LocalCache.GetTransactionPurposeList();

            bs.DataSource = retVal;
            UtilityServices.fillComboBox(cmbTransactionPurpose, bs, "cmbFillingDisplayMember", "id");
            cmbTransactionPurpose.SelectedIndex = -1;
        }

        public void SetupComponents()
        {
            _gui = new GUI(this);
            //gui.Config(ref txtOutletName);
            _gui.Config(ref cmbTransactionPurpose, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref txtTransactionAmount, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER, null);
            _gui.Config(ref txtRemarks);
            _gui.FocusControl(cmbTransactionPurpose);
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Message.showConfirmation("Are you sure to save?") == "yes")
            {
                if (_gui.IsAllControlValidated())
                {
                    FillObjectWithComponentValue();
                    if (_cashTransactionDto != null)
                    {
                        try
                        {
                            CashEntryService cashEntryService = new CashEntryService();
                            string responseString = cashEntryService.SaveOutletCashTransactionRegister(_cashTransactionDto);
                            Message.showInformation(responseString);
                            ResetUI();
                            _gui.RefreshOwnerForm();
                            _gui.FocusControl(cmbTransactionPurpose);                            
                        }
                        catch (Exception ex)
                        {
                            Message.showError(ex.Message);
                            _gui.RefreshOwnerForm();
                            _gui.IsAllControlValidated();
                        }
                    }
                }
                else
                {
                    Message.showError("Validation error!");
                    _gui.RefreshOwnerForm();
                    _gui.IsAllControlValidated();
                }
            }
            else
            {
                _gui.RefreshOwnerForm();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Message.showConfirmation("Are you sure to clear?") == "yes")
            {
                ResetUI();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ResetUI()
        {
            _cashTransactionDto = null;
            cmbTransactionPurpose.SelectedIndex = 0;
            txtTransactionAmount.Text = "";
            txtRemarks.Text = "";
            dtpDate.Value = SessionInfo.currentDate;
            mtbDate.Text = dtpDate.Value.ToString("dd-MM-yyyy");
            _gui.FocusControl(cmbTransactionPurpose);
        }

        private void FillObjectWithComponentValue()
        {
            _cashTransactionDto = new OutletCashTransactionRegister();
            SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
            _cashTransactionDto.subagentId = currentSubagentInfo.id;
            _cashTransactionDto.transactionDate = UtilityServices.GetLongDate(Convert.ToDateTime(dtpDate.Value.ToShortDateString()));
            _cashTransactionDto.transactionPurposeId = (long)cmbTransactionPurpose.SelectedValue;
            _cashTransactionDto.amount = decimal.Parse(txtTransactionAmount.Text);

            double decValue;
            if (double.TryParse(txtTransactionAmount.Text, out decValue))
            {
                txtTransactionAmount.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                _cashTransactionDto.amount = decimal.Parse(txtTransactionAmount.Text);
            }

            _cashTransactionDto.remark = txtRemarks.Text;
            _cashTransactionDto.entyUser = SessionInfo.username;
            _cashTransactionDto.entyDate = UtilityServices.GetLongDate(SessionInfo.currentDate).ToString();  //DateTime.Now;
        }


        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            mtbDate.Text = dtpDate.Value.ToString("dd-MM-yyyy");
        }

        private void mtbDate_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDate.Value = d;
            }
            catch (Exception ex) { }
        }

        private void txtTransactionAmount_Leave(object sender, EventArgs e)
        {
            double decValue;
            if (double.TryParse(txtTransactionAmount.Text, out decValue))
            {
                txtTransactionAmount.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
        }

        private void frmCashEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }
}