using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.UI.forms.MessageUI;

namespace MISL.Ababil.Agent.UI
{
    public class Message
    {

        public static string showConfirmation(string msg)
        {
            frmMessageUI frm = new frmMessageUI();
            frm.picIcon.Image = Properties.Resources.help;
            frm.Style = MetroFramework.MetroColorStyle.Blue;
            frm.lblTitle.Text = "Confirmation";
            frm.lblMsg.Text = msg;
            frm.btnYes.DialogResult = DialogResult.Yes;
            frm.btnYes.Focus();
            frm.btnNo.DialogResult = DialogResult.No;
            DialogResult result = frm.ShowDialog();

            //DialogResult result = MessageBox.Show(msg,
            //   "Confirmation",
            //   MessageBoxButtons.YesNo,
            //   MessageBoxIcon.Question,
            //   MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                return "yes";
            }
            else
                return "no";

        }


        public static void showError(string msg)
        {
            frmMessageUI frm = new frmMessageUI();
            frm.picIcon.Image = Properties.Resources.err;
            frm.Style = MetroFramework.MetroColorStyle.Red;
            frm.lblTitle.Text = "Error";
            frm.lblMsg.Text = msg;
            frm.btnYes.Visible = false;
            frm.btnNo.DialogResult = DialogResult.OK;
            frm.btnNo.Text = "OK";
            frm.btnNo.Focus();
            DialogResult result = frm.ShowDialog();

            //MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void showInformation(string msg)
        {
            frmMessageUI frm = new frmMessageUI();
            frm.picIcon.Image = Properties.Resources.info;
            frm.Style = MetroFramework.MetroColorStyle.Blue;
            frm.lblTitle.Text = "Information";
            frm.lblMsg.Text = msg;
            frm.btnYes.Visible = false;
            frm.btnNo.DialogResult = DialogResult.OK;
            frm.btnNo.Text = "OK";
            frm.btnNo.Focus();
            DialogResult result = frm.ShowDialog();

            //MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void showWarning(string msg)
        {
            frmMessageUI frm = new frmMessageUI();
            frm.picIcon.Image = Properties.Resources.warn;
            frm.Style = MetroFramework.MetroColorStyle.Yellow;
            frm.lblTitle.Text = "Warning";
            frm.lblMsg.Text = msg;
            frm.btnYes.Visible = false;
            frm.btnNo.DialogResult = DialogResult.OK;
            frm.btnNo.Text = "OK";
            frm.btnNo.Focus();
            DialogResult result = frm.ShowDialog();

            //MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


    }
}
