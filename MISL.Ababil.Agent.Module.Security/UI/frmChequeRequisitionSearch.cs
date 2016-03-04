using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Module.Security.UI
{
    public partial class frmChequeRequisitionSearch : MetroForm
    {
        public frmChequeRequisitionSearch()
        {
            InitializeComponent();
            SetupComponent();
        }

        private void SetupComponent()
        {

        }

        //ChequeRequisitionService _chequeRequisitionService = new ChequeRequisitionService();
        //public List<ChequeRequisitionSearchResultDto> _ChequeRequestSearchResultList;
        private bool _filling;

        private void frmChequeRequisitionSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            dgvResult.DataSource = null;
            dgvResult.Rows.Clear();
            dgvResult.Columns.Clear();
            //ChequeRequestSearchDto chequeRequestSearchDto = new ChequeRequestSearchDto();            
            //chequeRequestSearchDto.fromDate = null; // UtilityServices.GetLongDate(dtpFrom.Value);
            //chequeRequestSearchDto.toDate = null; // UtilityServices.GetLongDate(dtpTo.Value);

            if (cmbStatus.SelectedValue != null)
            {
                //chequeRequestSearchDto.requisitionStatus = (ChequeRequisitionStatus)cmbStatus.SelectedValue;
            }

            try
            {
                //////  ProgressUIManager.ShowProgress(this);
                ////_ChequeRequestSearchResultList = _chequeRequisitionService.GetChequeRequisitionList(chequeRequestSearchDto);
                ////// ProgressUIManager.CloseProgress();

                ////if (_ChequeRequestSearchResultList != null)
                ////{
                ////    dgvResult.DataSource = null;                    
                ////    dgvResult.DataSource = _ChequeRequestSearchResultList.Select(o => new ChequeRequestSearchResultGrid(o)
                ////    {
                ////        outletName = o.outletName,
                ////        outletUser = o.outletUser,
                ////        refNumber = o.refNumber,
                ////        submiteDate = UtilityServices.getBDFormattedDateFromLong(o.submiteDate),
                ////        accTitle = o.accTitle,
                ////        accNumber = o.accNumber,
                ////        noOfLeaf = o.noOfLeaf,
                ////        urgencyType = o.urgencyType,
                ////        Status = (o.requisitionStatus).ToString()
                ////    }).ToList();

                ////    for (int i = 0; i < dgvResult.Columns.Count; i++)
                ////    {
                ////        dgvResult.Columns[i].ReadOnly = true;
                ////    }

                ////    //View Button
                ////    {
                ////        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                ////        buttonColumn.Text = "View";
                ////        buttonColumn.UseColumnTextForButtonValue = true;
                ////        buttonColumn.ReadOnly = false;
                ////        dgvResult.Columns.Add(buttonColumn);
                ////    }                    
                ////}
                ////else
                ////{
                ////    ProgressUIManager.CloseProgress();
                ////    btnSearch.Enabled = true;
                ////    MsgBox.showInformation("No applications available");
                ////}
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                MsgBox.showError(ex.Message);
            }

            //lblItemsFound.Text = "Item(s) Found: " + dgvRemittance.Rows.Count.ToString();
            this.Enabled = true;
            this.UseWaitCursor = false;
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Search();
            }
            catch { }
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {

            }

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {

            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnReceive_Click(object sender, EventArgs e)
        {

        }
    }
}