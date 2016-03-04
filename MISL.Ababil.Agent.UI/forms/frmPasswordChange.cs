using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MetroFramework.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmPasswordChange : MetroForm
    {
        public frmPasswordChange()
        {
            InitializeComponent();
            lblUserNameText.Text = SessionInfo.username;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPasswordChange_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                PasswordChangeService passwordChangeService = new PasswordChangeService();
                passwordChangeInfo objPasswordChangeInfo = new passwordChangeInfo();

                objPasswordChangeInfo.changedBy = SessionInfo.username;
                objPasswordChangeInfo.changedOn = UtilityServices.GetLongDate(SessionInfo.currentDate);
                objPasswordChangeInfo.confirmPassword = txtRetypeNewPassword.Text;
                objPasswordChangeInfo.newPassword = txtNewPassword.Text;
                objPasswordChangeInfo.oldPassword = txtCurrentPassword.Text;
                objPasswordChangeInfo.username = lblUserNameText.Text;

                string responseString = passwordChangeService.savePasswordChange(objPasswordChangeInfo);

                if (responseString == "SUCCESS")
                {
                    Message.showInformation("Password successfully changed.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    Message.showError(responseString);
                }
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void frmPasswordChange_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
        }

        int tmpX = 0;
        int tmpY = 0;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left = Cursor.Position.X - tmpX;
                this.Top = Cursor.Position.Y - tmpY;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = e.X;
            tmpY = e.Y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //    button2.Text = "3";
            //}
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    button2.Text = "2";
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroTextBox1_Enter(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(new Pen(Color.DodgerBlue), ((Control)sender).Left - 1, ((Control)sender).Top - 1, ((Control)sender).Width + 1, ((Control)sender).Height + 1);
            g.Flush();
        }

        private void metroTextBox1_Leave(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //g.DrawRectangle(Pens.Black, metroTextBox1.Left - 1, metroTextBox1.Top - 1, metroTextBox1.Width + 2, metroTextBox1.Height + 2);
            g.Flush();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPasswordChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }
}

