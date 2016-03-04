using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmRemittanceEntry : Form
    {
        public Remittance openingRemittance = null;

        private const long MAX_FILE_SIZE = 1 * 1024 * 1024;

        public enum RemittanceEntryModes
        {
            Client,
            Admin
        }

        public frmRemittanceEntry()
        {
            InitializeComponent();
        }

        public frmRemittanceEntry(Remittance remittance, RemittanceEntryModes remittanceEntryModes)
        {
            InitializeComponent();

            openingRemittance = remittance;

            if (remittanceEntryModes == RemittanceEntryModes.Client)
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
                btnCorrect.Visible = false;
                txtComment.Enabled = false;

                this.Text = "Remittance Entry";
            }
            if (remittanceEntryModes == RemittanceEntryModes.Admin)
            {
                btnSubmit.Visible = false;
                txtStatus.Visible = false;
                lblStatus.Visible = false;
                txtComment.Enabled = true;

                this.Text = "Remittance Entry (Admin) - Edit";
            }
        }

        private void loadRemittance(Remittance remittance)
        {
            cbxNameofExchangeHouse.SelectedValue = remittance.exchangeHouse.id;
            txtRecipientName.Text = remittance.recipientName;
            txtRecipientNationalID.Text = remittance.nationalId;
            txtRecipientAddressLine1.Text = remittance.address.addressLineOne;
            txtRecipientAddressLine2.Text = remittance.address.addressLineTwo;
            cbxDivision.SelectedValue = remittance.address.division.id;
            cbxDistrict.SelectedValue = remittance.address.district.id;
            cbxThana.SelectedValue = remittance.address.thana.id;
            cbxPostalCode.SelectedValue = remittance.address.postalCode.id;
            cbxCountry.SelectedValue = remittance.address.country.id;

            txtSenderName.Text = remittance.senderName;
            cbxSenderCountry.SelectedValue = remittance.senderCounrty.id;
            txtPurposeofRemittance.Text = remittance.purpose;
            dtpDateSent.Value = DateTime.Parse(remittance.sendingDate);
            txtPINCode.Text = remittance.pin;
            txtAmount.Text = remittance.amount.ToString();

            txtStatus.Text = remittance.Status;
            txtComment.Text = remittance.Comment;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Remittance remittance = fillRemittance();
            //RemittanceServices remittanceServices = new RemittanceServices();
            //string responseString = remittanceServices.sumbitRemittance(remittance);
            //MessageBox.Show(responseString);
        }

        private Remittance fillRemittance()
        {

            if (txtRecipientName.Text.Trim() == null) { MessageBox.Show("Recipient Name is empty!"); }
            if (txtRecipientAddressLine1.Text.Trim() == null) { MessageBox.Show("Recipient Address Line One is empty!"); }
            if (txtRecipientAddressLine2.Text.Trim() == null) { MessageBox.Show("Recipient Address Line Two is empty!"); }
            if (txtRecipientNationalID.Text.Trim() == null) { MessageBox.Show("National ID is empty!"); }
            if (txtSenderName.Text.Trim() == null) { MessageBox.Show("Sender Name is empty!"); }
            if (txtPurposeofRemittance.Text.Trim() == null) { MessageBox.Show("Purpose of Remittance is empty!"); }
            if (txtPINCode.Text.Trim() == null) { MessageBox.Show("PIN Code is empty!"); }

            Remittance remittance = new Remittance();

            ExchangeHouse exHouse = new ExchangeHouse();
            exHouse.id = (long)cbxNameofExchangeHouse.SelectedValue;
            remittance.exchangeHouse = exHouse;

            remittance.recipientName = txtRecipientName.Text;

            Address address = new Address();
            address.addressLineOne = txtRecipientAddressLine1.Text;
            address.addressLineTwo = txtRecipientAddressLine2.Text;

            remittance.nationalId = txtRecipientNationalID.Text;

            Division division = new Division();
            division.id = (int)cbxDivision.SelectedValue;
            address.division = division;

            District district = new District();
            district.id = (int)cbxDistrict.SelectedValue;
            address.district = district;

            Thana thana = new Thana();
            thana.id = (int)cbxThana.SelectedValue;
            address.thana = thana;

            PostalCode postalCode = new PostalCode();
            postalCode.id = (long)cbxPostalCode.SelectedValue;
            address.postalCode = postalCode;

            Country country = new Country();
            country.id = (long)cbxCountry.SelectedValue;
            address.country = country;

            remittance.address = address;


            remittance.senderName = txtSenderName.Text;

            Country senderCountry = new Country();
            senderCountry.id = (long)cbxSenderCountry.SelectedValue;
            remittance.senderCounrty = senderCountry;

            remittance.purpose = txtPurposeofRemittance.Text;
            remittance.sendingDate = dtpDateSent.Value.ToUnixTime().ToString();

            remittance.pin = txtPINCode.Text;
            remittance.amount = decimal.Parse(txtAmount.Text);


            remittance.Comment = txtComment.Text;

            return remittance;
        }

        private void frmEntry_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            UtilityServices.fillCountries(ref cbxCountry);
            UtilityServices.fillCountries(ref cbxSenderCountry);
            UtilityServices.fillDivisions(ref cbxDivision);

            fillExchangeHouseList(ref cbxNameofExchangeHouse);
        }

        private void fillExchangeHouseList(ref ComboBox cbxExHouse)
        {
            cbxExHouse.Items.Clear();
            RemittanceCom remCom = new RemittanceCom();
            List<ExchangeHouse> exHouses = remCom.getListofExchangeHouse();

            BindingSource bs = new BindingSource();
            bs.DataSource = exHouses;
            fillComboBox(cbxExHouse, bs, "name", "id");
        }

        public ExchangeHouse getExchangeHouseByID(long id)
        {
            RemittanceCom remCom = new RemittanceCom();
            List<ExchangeHouse> exHouses = remCom.getListofExchangeHouse();

            if (exHouses.Count > 0)
            {

                return null;
            }

            return null;
        }

        private void cbxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            int divisionId = Convert.ToInt32(cbxDivision.SelectedValue);
            UtilityServices.fillDistrictsByDivision(ref cbxDistrict, divisionId);

            cbxThana.DataSource = null;
            cbxPostalCode.DataSource = null;
        }

        private void cbxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillThanaByDistrict(ref cbxThana, Convert.ToInt32(cbxDistrict.SelectedValue));
            UtilityServices.fillPostalCodeByDistrict(ref cbxPostalCode, Convert.ToInt32(cbxDistrict.SelectedValue));
        }

        public static void fillComboBox(ComboBox cmb, BindingSource bs, string displayMember, string valueMember)
        {
            cmb.DataSource = bs;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void resetAll()
        {
            txtRecipientName.Text = null;
            txtRecipientAddressLine1.Text = null;
            txtRecipientAddressLine2.Text = null;
            txtRecipientNationalID.Text = null;
            txtSenderName.Text = null;
            txtPurposeofRemittance.Text = null;
            txtPINCode.Text = null;
            txtAmount = null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFileName.Text = openFileDialog.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (File.Exists(txtFileName.Text) == true)
            //{
            //    dgvFiles.Rows.Add(txtFileName.Text, "Remove");
            //}
        }

        //private void dgvFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
        //    {
        //        if (MessageBox.Show("Do you want to remove the selected file?", "File Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            byte[] retVal = fileToByteArray(dgvFiles.Rows[e.RowIndex].Cells[0].Value.ToString());
        //        }
        //    }
        //}

        public static byte[] fileToByteArray(string fileName)
        {
            if (File.Exists(fileName) == true)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[fileInfo.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                return buffer;
            }
            return null;
        }

        public static void byteArrayToFile(ref byte[] buffer, string tempFileName)
        {
            FileStream fs = new FileStream(tempFileName, FileMode.CreateNew);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //Remittance remittance = fillRemittance();
            //RemittanceServices remittanceServices = new RemittanceServices();
            //string responseString = remittanceServices.approveRemittance(remittance);
            //MessageBox.Show(responseString);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            //Remittance remittance = fillRemittance();
            //RemittanceServices remittanceServices = new Services.RemittanceServices();
            //frmRemittanceComment frm = new frmRemittanceComment();
            //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    remittance.Comment = frm.txtComment.Text;
            //    remittance.Status = "Reject";

            //}
            //string responseString = remittanceServices.rejectRemittance(remittance);
            //MessageBox.Show(responseString);
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            //Remittance remittance = fillRemittance();
            //RemittanceServices remittanceServices = new Services.RemittanceServices();
            //remittance.Status = "Correct";
            //string responseString = remittanceServices.correctRemittance(remittance);
            //MessageBox.Show(responseString);
        }

        private void cbxThana_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}