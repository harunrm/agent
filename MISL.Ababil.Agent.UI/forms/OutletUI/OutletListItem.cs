using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Controls;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using System.Windows.Forms.DataVisualization.Charting;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure;

namespace MISL.Ababil.Agent.UI.forms.OutletUI
{
    public partial class OutletListItem : UserControl
    {
        public string OutletId { get; set; }
        public string OutletUserId { get; set; }

        private SubAgentInformation _subAgentInformation;
        private SubAgentUser _outletUserinformation;
        LimitUserType _limitUserType;

        private bool isEditCredit = false;
        private bool isEditDebit = false;

        public OutletListItem(Packet packet, SubAgentInformation subAgentInformation)
        {
            InitializeComponent();
            SetControlSelectionEvents();

            _subAgentInformation = subAgentInformation;
            if (true)
            {
                lblCodeValue.Text = _subAgentInformation.subAgentCode;
                lblNameValue.Text = _subAgentInformation.name;
                lblAddress.Text = _subAgentInformation.businessAddress.addressLineOne;
                lblDistrict.Text = _subAgentInformation.businessAddress.district.title;
                lblPhone.Text = _subAgentInformation.mobleNumber;
                OutletId = _subAgentInformation.id.ToString();

                tglCreditLimit.Checked = _subAgentInformation.creditLimitApplicable;
                tglDebitLimit.Checked = _subAgentInformation.debitLimitApplicable;

                SetCreditLimitEnable(_subAgentInformation.creditLimitApplicable);
                SetDebitLimitEnable(_subAgentInformation.debitLimitApplicable);
            }
        }
        public OutletListItem(Packet packet, LimitUserType limitUserType, object receivedObj)
        {
            InitializeComponent();
            SetControlSelectionEvents();

            _limitUserType = limitUserType;
            if (_limitUserType == LimitUserType.Outlet)
            {
                #region Outlet 
                _subAgentInformation = receivedObj as SubAgentInformation;

                lblCodeValue.Text = _subAgentInformation.subAgentCode;
                lblNameValue.Text = _subAgentInformation.name;
                lblAddress.Text = _subAgentInformation.businessAddress.addressLineOne;
                lblDistrict.Text = _subAgentInformation.businessAddress.district.title;
                lblPhone.Text = _subAgentInformation.mobleNumber;
                OutletId = _subAgentInformation.id.ToString();

                tglCreditLimit.Checked = _subAgentInformation.creditLimitApplicable;
                tglDebitLimit.Checked = _subAgentInformation.debitLimitApplicable;

                SetCreditLimitEnable(_subAgentInformation.creditLimitApplicable);
                SetDebitLimitEnable(_subAgentInformation.debitLimitApplicable);
                #endregion
            }
            else if (_limitUserType == LimitUserType.User)
            {
                #region Outlet User
                _outletUserinformation = receivedObj as SubAgentUser;

                lblCodeValue.Text = _outletUserinformation.id.ToString();
                lblNameValue.Text = _outletUserinformation.username;
                //lblAddress.Text = _outletUserinformation.businessAddress.addressLineOne;
                //lblDistrict.Text = _subAgentInformation.businessAddress.district.title;
                //lblPhone.Text = _subAgentInformation.mobleNumber;
                OutletUserId = _outletUserinformation.id.ToString();

                tglCreditLimit.Checked = _outletUserinformation.creditLimitApplicable;
                tglDebitLimit.Checked = _outletUserinformation.debitLimitApplicable;

                SetCreditLimitEnable(_outletUserinformation.creditLimitApplicable);
                SetDebitLimitEnable(_outletUserinformation.debitLimitApplicable);
                #endregion
            }
        }

        private void SetControlSelectionEvents()
        {
            SetEvents(this);
            for (int i = 0; i < Controls.Count; i++)
            {
                SetEvents(Controls[i]);
                if (Controls[i].HasChildren)
                {
                    for (int j = 0; j < Controls[i].Controls.Count; j++)
                    {
                        SetEvents(Controls[i].Controls[j]);
                    }
                }
            }
        }

        private void SetEvents(Control control)
        {
            control.MouseEnter += OutletListItem_MouseEnter;
            control.MouseLeave += OutletListItem_MouseLeave;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeControlSelectState(true);
        }

        private void Control_Enter(object sender, EventArgs e)
        {
            ChangeControlSelectState(true);
        }

        private void OutletListItem_MouseEnter(object sender, EventArgs e)
        {
            ChangeControlSelectState(true);
        }

        private void OutletListItem_MouseLeave(object sender, EventArgs e)
        {
            ChangeControlSelectState(false);
        }

        private void ChangeControlSelectState(bool isSelected)
        {
            if (isSelected)
            {
                this.BackColor = Color.LightGray;
                for (int i = 0; i < Controls.Count; i++)
                {
                    Controls[i].BackColor = Color.LightGray;
                    if (Controls[i].HasChildren)
                    {
                        for (int j = 0; j < Controls[i].Controls.Count; j++)
                        {
                            Controls[i].Controls[j].BackColor = Color.LightGray;
                        }
                    }
                }
                panelHeader.BackColor = panelFooter.BackColor = Color.FromArgb(0, 122, 170);
                lblCodeValue.BackColor = lblNameValue.BackColor = lblName.BackColor = lblCode.BackColor = Color.FromArgb(0, 122, 170);
                lblCodeValue.ForeColor = lblNameValue.ForeColor = lblName.ForeColor = lblCode.ForeColor = Color.White;
                tglActive.BackColor = Color.LightGray;

                if (isEditCredit == false)
                {
                    txtCreditLimit.BackColor = Color.Silver;
                }
                else
                {
                    txtCreditLimit.BackColor = Color.White;
                }
                if (isEditDebit == false)
                {
                    txtDebitLimit.BackColor = Color.Silver;
                }
                else
                {
                    txtDebitLimit.BackColor = Color.White;
                }
            }
            else
            {
                this.BackColor = Color.White;
                for (int i = 0; i < Controls.Count; i++)
                {
                    Controls[i].BackColor = Color.White;
                    if (Controls[i].HasChildren)
                    {
                        for (int j = 0; j < Controls[i].Controls.Count; j++)
                        {
                            Controls[i].Controls[j].BackColor = Color.White;
                        }
                    }
                }
                panelHeader.BackColor = panelFooter.BackColor = Color.FromArgb(122, 163, 237);
                lblCodeValue.BackColor = lblNameValue.BackColor = lblName.BackColor = lblCode.BackColor = Color.FromArgb(122, 163, 237);
                lblCodeValue.ForeColor = lblNameValue.ForeColor = lblName.ForeColor = lblCode.ForeColor = Color.White;
                tglActive.BackColor = Color.Gainsboro;
                txtCreditLimit.BackColor = txtDebitLimit.BackColor = Color.Gainsboro;
                tglActive.BackColor = Color.White;
            }

            panel1.BackColor = panel2.BackColor = panel3.BackColor = panel5.BackColor = Color.Gainsboro;
            pbLgUsage.BackColor = Color.FromArgb(252, 180, 65);
            pbLgRemaining.BackColor = Color.FromArgb(65, 140, 240);

            if (btnCreditLimit.Enabled == false)
            {
                btnCreditLimit.BackColor = Color.Gray;
            }
            else
            {
                btnCreditLimit.BackColor = Color.FromArgb(0, 122, 170);
            }
            if (btnDebitLimit.Enabled == false)
            {
                btnDebitLimit.BackColor = Color.Gray;
            }
            else
            {
                btnDebitLimit.BackColor = Color.FromArgb(0, 122, 170);
            }
        }

        private void btnCreditLimit_Click(object sender, EventArgs e)
        {
            if (btnCreditLimit.Text == "Edit")
            {
                isEditCredit = true;
                txtCreditLimit.BackColor = Color.White;
                txtCreditLimit.ReadOnly = false;
                btnCreditLimit.Text = "Save";
                txtCreditLimit.Focus();
                txtCreditLimit.SelectAll();
            }
            else
            {
                try
                {
                    ServiceResult result = new ServiceResult();
                    SubAgentService subAgentService = new SubAgentService();
                    if (_limitUserType == LimitUserType.Outlet)
                    {
                        subAgentService.SaveSubagentCreditLimit(OutletId, decimal.Parse(txtCreditLimit.Text));
                        SetCreditChartAndLabelValues(decimal.Parse(txtCreditLimit.Text), _subAgentInformation.usedDailyCreditLimit, true);
                    }
                    else if (_limitUserType == LimitUserType.User)
                    {
                        result = subAgentService.SaveSubAgentUserCreditLimit(OutletUserId, decimal.Parse(txtCreditLimit.Text));
                        if (result.Success) SetCreditChartAndLabelValues(decimal.Parse(txtCreditLimit.Text), _outletUserinformation.usedDailyCreditLimit, true);
                        else Message.showError(result.Message);
                    }

                    isEditCredit = false;
                    txtCreditLimit.BackColor = Color.Gainsboro;
                    txtCreditLimit.ReadOnly = true;
                    btnCreditLimit.Text = "Edit";
                }
                catch (Exception exp) { Message.showError(exp.Message); }
                //isEditCredit = false;
                //txtCreditLimit.BackColor = Color.Gainsboro;
                //txtCreditLimit.ReadOnly = true;
                //btnCreditLimit.Text = "Edit";
            }
        }

        private void btnDebitLimit_Click(object sender, EventArgs e)
        {
            if (btnDebitLimit.Text == "Edit")
            {
                isEditDebit = true;
                txtDebitLimit.BackColor = Color.White;
                txtDebitLimit.ReadOnly = false;
                btnDebitLimit.Text = "Save";
                txtDebitLimit.Focus();
                txtDebitLimit.SelectAll();
            }
            else
            {
                try
                {
                    ServiceResult result = new ServiceResult();
                    SubAgentService subAgentCom = new SubAgentService();
                    if (_limitUserType == LimitUserType.Outlet)
                    {
                        subAgentCom.SaveSubagentDebitLimit(OutletId, decimal.Parse(txtDebitLimit.Text));
                        SetDebitChartAndLabelValues(decimal.Parse(txtDebitLimit.Text), _subAgentInformation.usedDailyDebitLimit, true);
                    }
                    else if (_limitUserType == LimitUserType.User)
                    {
                        result = subAgentCom.SaveSubAgentUserDebitLimit(OutletUserId, decimal.Parse(txtDebitLimit.Text));
                        if (result.Success) SetDebitChartAndLabelValues(decimal.Parse(txtDebitLimit.Text), _outletUserinformation.usedDailyDebitLimit, true);
                        else Message.showError(result.Message);
                    }

                    isEditDebit = false;
                    txtDebitLimit.BackColor = Color.Gainsboro;
                    txtDebitLimit.ReadOnly = true;
                    btnDebitLimit.Text = "Edit";
                }
                catch (Exception exp) { Message.showError(exp.Message); }
                //isEditDebit = false;
                //txtDebitLimit.BackColor = Color.Gainsboro;
                //txtDebitLimit.ReadOnly = true;
                //btnDebitLimit.Text = "Edit";
            }
            crtDebit.Update();
        }

        private void tglActive_CheckedChanged(object sender, EventArgs e)
        {
            if (tglActive.Checked)
            {
                if (_limitUserType == LimitUserType.Outlet) lblActiveInactiveStatus.Text = "Outlet Active";
                else if (_limitUserType == LimitUserType.User) lblActiveInactiveStatus.Text = "User Active";
            }
            else
            {
                if (_limitUserType == LimitUserType.Outlet) lblActiveInactiveStatus.Text = "Outlet Inactive";
                else if (_limitUserType == LimitUserType.User) lblActiveInactiveStatus.Text = "User Inactive";
            }
        }

        public void SetCreditLimitEnable(bool val)
        {
            btnCreditLimit.Enabled = txtCreditLimit.Enabled = lblCRDailyLimit.Enabled = val;

            if (val)
            {
                if (_limitUserType == LimitUserType.Outlet)
                {
                    SetCreditChartAndLabelValues
                    (
                        _subAgentInformation.dailyCreditLimit,
                        _subAgentInformation.usedDailyCreditLimit,
                        true
                    );
                }
                else if (_limitUserType == LimitUserType.User)
                {
                    SetCreditChartAndLabelValues
                    (
                        _outletUserinformation.dailyCreditLimit,
                        _outletUserinformation.usedDailyCreditLimit,
                        true
                    );
                }
            }
            else
            {
                SetCreditChartAndLabelValues
                (
                    0,
                    0,
                    false
                );
            }
        }

        public void SetDebitLimitEnable(bool val)
        {
            btnDebitLimit.Enabled = txtDebitLimit.Enabled = lblDRDailyLimit.Enabled = val;

            if (val)
            {
                if (_limitUserType == LimitUserType.Outlet)
                {
                    SetDebitChartAndLabelValues
                    (
                        _subAgentInformation.dailyDebitLimit,
                        _subAgentInformation.usedDailyDebitLimit,
                        true
                    );
                }
                else if (_limitUserType == LimitUserType.User)
                {
                    SetDebitChartAndLabelValues
                    (
                        _outletUserinformation.dailyDebitLimit,
                        _outletUserinformation.usedDailyDebitLimit,
                        true
                    );
                }
            }
            else
            {
                SetDebitChartAndLabelValues
                (
                    0,
                    0,
                    false
                );
            }
        }

        private void tglCreditLimit_CheckedChanged(object sender, EventArgs e)
        {
            SetCreditLimitEnable(tglCreditLimit.Checked);
        }

        private void tglDebitLimit_CheckedChanged(object sender, EventArgs e)
        {
            SetDebitLimitEnable(tglDebitLimit.Checked);
        }

        private void btnCreditLimit_EnabledChanged(object sender, EventArgs e)
        {
            if (btnCreditLimit.Enabled == false)
            {
                btnCreditLimit.BackColor = Color.Gray;
            }
            else
            {
                btnCreditLimit.BackColor = Color.FromArgb(0, 122, 170);
            }
        }

        private void btnDebitLimit_EnabledChanged(object sender, EventArgs e)
        {
            if (btnDebitLimit.Enabled == false)
            {
                btnDebitLimit.BackColor = Color.Gray;
            }
            else
            {
                btnDebitLimit.BackColor = Color.FromArgb(0, 122, 170);
            }
        }

        private void tglCreditLimit_Click(object sender, EventArgs e)
        {
            bool tmpStatus = !tglCreditLimit.Checked;
            SubAgentService subAgentService = new SubAgentService();
            ServiceResult result = new ServiceResult();
            try
            {
                if (_limitUserType == LimitUserType.Outlet)
                {
                    subAgentService.SetCreditLimit(OutletId, tglCreditLimit.Checked);
                    SetCreditLimitEnable(tglCreditLimit.Checked);
                }
                else if (_limitUserType == LimitUserType.User)
                {
                    result = subAgentService.SetSubAgentUserCreditLimit(OutletUserId, tglCreditLimit.Checked);
                    if (result.Success) SetCreditLimitEnable(tglCreditLimit.Checked);
                    else Message.showError(result.Message);
                }
            }
            catch
            {
                tglCreditLimit.Checked = tmpStatus;
                SetCreditLimitEnable(tmpStatus);
                Message.showError("Could not set Credit limit status!");
            }
        }

        private void tglDebitLimit_Click(object sender, EventArgs e)
        {
            bool tmpStatus = tglDebitLimit.Checked;
            try
            {
                SubAgentService subAgentService = new SubAgentService();
                ServiceResult result = new ServiceResult();
                if (_limitUserType == LimitUserType.Outlet)
                {
                    subAgentService.SetDebitLimit(OutletId, tglDebitLimit.Checked);
                    SetDebitLimitEnable(tglDebitLimit.Checked);
                }
                else if (_limitUserType == LimitUserType.User)
                {
                    result = subAgentService.SetSubAgentUserDebitLimit(OutletUserId, tglDebitLimit.Checked);
                    if (result.Success) SetDebitLimitEnable(tglDebitLimit.Checked);
                    else Message.showError(result.Message);
                }
            }
            catch
            {
                tglDebitLimit.Checked = tmpStatus;
                SetDebitLimitEnable(tmpStatus);
                Message.showError("Could not set debit limit status!");
            }
        }

        public void SetCreditChartAndLabelValues(decimal limit)
        {
            lblCRLimitValue.Text = limit.ToString();
            lblCRRemainingValue.Text = (decimal.Parse(lblCRLimitValue.Text) - decimal.Parse(lblCRUsageValue.Text)).ToString();
            crtCredit.Series[0].Points[0].YValues[0] = double.Parse(lblCRRemainingValue.Text);
            crtCredit.Series[0].Points[1].YValues[0] = double.Parse(lblCRUsageValue.Text);
            crtCredit.Update();
        }

        public void SetCreditChartAndLabelValues(decimal? limit, decimal? usage, bool enabled)
        {
            decimal remaining = ((limit == null || limit.ToString() == "") ? 0 : limit ?? 0) - ((usage == null || usage.ToString() == "") ? 0 : usage ?? 0);

            lblCRLimitValue.Text = ((limit == null || limit.ToString() == "") ? 0 : limit ?? 0).ToString();
            lblCRUsageValue.Text = ((usage == null || usage.ToString() == "") ? 0 : usage ?? 0).ToString();

            lblCRRemainingValue.Text = remaining.ToString();
            crtCredit.Visible = enabled;

            crtCredit.Series[0].Points.Clear();
            DataPoint dataPointRem = new DataPoint();
            dataPointRem.SetValueY(double.Parse(lblCRRemainingValue.Text));
            crtCredit.Series[0].Points.Add(dataPointRem);

            DataPoint dataPointUsage = new DataPoint();

            dataPointUsage.SetValueY(double.Parse(lblCRUsageValue.Text));
            crtCredit.Series[0].Points.Add(dataPointUsage);

            lblCRLimitValue.Enabled = lblCRUsageValue.Enabled = lblCRRemainingValue.Enabled = enabled;
            lblCRLimit.Enabled = lblCRUsage.Enabled = lblCRRemaining.Enabled = enabled;

            if (enabled)
            {
                txtCreditLimit.Text = limit == null ? "0.00" : limit.ToString();
            }
            else
            {
                txtCreditLimit.Text = "0.00";
            }
        }

        public void SetDebitChartAndLabelValues(decimal limit)
        {
            lblDRLimitValue.Text = limit.ToString();
            lblDRRemainingValue.Text = (decimal.Parse(lblDRLimitValue.Text) - decimal.Parse(lblDRUsageValue.Text)).ToString();
            crtDebit.Series[0].Points[0].YValues[0] = double.Parse(lblDRRemainingValue.Text);
            crtDebit.Series[0].Points[1].YValues[0] = double.Parse(lblDRUsageValue.Text);
            crtDebit.Update();
        }

        public void SetDebitChartAndLabelValues(decimal? limit, decimal? usage, bool enabled)
        {
            decimal remaining = ((limit == null || limit.ToString() == "") ? 0 : limit ?? 0) - ((usage == null || usage.ToString() == "") ? 0 : usage ?? 0);

            lblDRLimitValue.Text = ((limit == null || limit.ToString() == "") ? 0 : limit ?? 0).ToString();
            lblDRUsageValue.Text = ((usage == null || usage.ToString() == "") ? 0 : usage ?? 0).ToString();

            lblDRRemainingValue.Text = remaining.ToString();

            crtDebit.Series[0].Points.Clear();
            DataPoint dataPointRem = new DataPoint();
            dataPointRem.SetValueY(double.Parse(lblDRRemainingValue.Text));
            crtDebit.Series[0].Points.Add(dataPointRem);

            DataPoint dataPointUsage = new DataPoint();
            dataPointUsage.SetValueY(double.Parse(lblDRUsageValue.Text));
            crtDebit.Series[0].Points.Add(dataPointUsage);

            lblDRLimitValue.Enabled = lblDRUsageValue.Enabled = lblDRRemainingValue.Enabled = enabled;
            lblDRLimit.Enabled = lblDRUsage.Enabled = lblDRRemaining.Enabled = enabled;
            crtDebit.Visible = enabled;

            if (enabled)
            {
                txtDebitLimit.Text = limit == null ? "0.00" : limit.ToString();
            }
            else
            {
                txtDebitLimit.Text = "0.00";
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (_limitUserType == LimitUserType.Outlet)
                {
                    frmOutletUserList frm = new frmOutletUserList(null, _subAgentInformation);
                    frm.ShowDialog();
                }
            }
            catch (Exception exp)
            { }
        }
    }
}