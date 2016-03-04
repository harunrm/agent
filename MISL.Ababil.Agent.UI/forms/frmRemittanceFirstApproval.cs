﻿using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
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
    public partial class frmRemittanceFirstApproval : Form
    {
        public MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance.Remittance remittance = new MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance.Remittance();

        public frmRemittanceFirstApproval()
        {
            InitializeComponent();
        }

        private void frmRemittanceFirstApproval_Load(object sender, EventArgs e)
        {
            //remittance.referanceNumber = referanceNumber;
            //getRemittanceByRefrenceNumber(remittance);
            txtRefranceNumber.Text = remittance.referanceNumber;
            txtAgentName.Text = SessionInfo.username;
            txtExchangeHouseName.Text = remittance.exchangeHouse.companyName;
            txtExpectedAmount.Text = remittance.expectedAmount.ToString();

            //RemittanceCom remmitanceCom = new RemittanceCom();
            //string accountNumber = remmitanceCom.getAccountNumber(remittance.exchangeHouse.id.ToString());
            //txtACNo.Text = accountNumber;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void getRemittanceByRefrenceNumber(MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance.Remittance remitance)
        {
            RemittanceCom remitancecom = new RemittanceCom();
            remittance = remitancecom.getListOfRemittance(remittance)[0];
        }

        private void btnSendToSecondApprover_Click(object sender, EventArgs e)
        {
            if (rdobtnNeedCorrection.Checked == true)
            {
                remittance.firstApprover = SessionInfo.username;
                remittance.firstApprovalDateTime = UtilityServices.GetLongDate(DateTime.Now).ToString();


                remittance.remittanceStatus = RemittanceStatus.Corrected;
                remittance.comments = txtComments.Text;
            }
            else if (rdobtnReject.Checked == true)
            {
                remittance.firstApprover = SessionInfo.username;
                remittance.firstApprovalDateTime = UtilityServices.GetLongDate(DateTime.Now).ToString();

                remittance.remittanceStatus = RemittanceStatus.Rejected;
            }
            else if (rdobtnApproveSave.Checked == true)
            {
                remittance.firstApprover = SessionInfo.username;
                remittance.firstApprovalDateTime = UtilityServices.GetLongDate(DateTime.Now).ToString();

                remittance.remittanceStatus = RemittanceStatus.ApprovedFirst;
            }
            else
            {
                MessageBox.Show("Please select an option!");
                return;
            }


            string result= Message.showConfirmation("Do you want to process?");
            if (result == "yes")
            {

                try
                {
                    RemittanceServices remittanceServices = new RemittanceServices();
                    string responseString = remittanceServices.saveRemittance(remittance);
                    Message.showInformation("Process executed successfully.");
                }
                catch (Exception ex)
                {

                    Message.showError(ex.Message);
                }
            }
            

        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            frmDocument frmDocument = new frmDocument((Int32)remittance.documentId, ActionType.view);
            frmDocument.Show();

        }

        private void btnRequestDetails_Click(object sender, EventArgs e)
        {
            frmRemittanceAgentRequest objfrmremAgentRequest = new frmRemittanceAgentRequest();
            objfrmremAgentRequest.remittance = remittance;
            objfrmremAgentRequest.IsFromAdmin = true;
            objfrmremAgentRequest.changeControlsReadOnly(true);
            objfrmremAgentRequest.Show();
        }



    }
}