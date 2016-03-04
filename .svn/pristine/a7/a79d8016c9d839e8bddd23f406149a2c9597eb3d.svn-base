using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Services;
using System.Globalization;
using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.UI.forms.CustomControls
{
    public partial class CustomDateTimePicker : UserControl
    {
        private bool isValid = false;

        public event EventHandler ValueChanged
        {
            add { dtp.ValueChanged += value; }
            remove { dtp.ValueChanged -= value; }
        }

        public DateTime Value
        {
            get
            {
                return dtp.Value;
            }
            set
            {
                dtp.Value = value;
            }
        }

        public string Date
        {
            get
            {
                return txtDTP.Text;
            }
            set
            {
                string tmp = "";
                try
                {
                    if (!string.IsNullOrEmpty(txtDTP.Text))
                    {
                        tmp = dtp.Value.ToString("dd/MM/yyyy");
                        Date = tmp.Replace('-', '/').Replace("//", "/");
                        txtDTP.Text = Date;
                    }
                }
                catch { }
            }
        }

        public CustomDateTimePicker()
        {
            InitializeComponent();
        }

        public bool IsValid()
        {
            isValid = IsDateExt(txtDTP, true);
            return isValid;
        }

        private void txtDTP_Leave(object sender, EventArgs e)
        {
            try
            {
                isValid = IsDateExt(txtDTP, true);
            }
            catch { }
            try
            {
                string[] str = txtDTP.Text.Replace("//", "/").Split('/');
                if (str.Length == 3)
                {
                    dtp.Value = new DateTime(int.Parse(str[2]), int.Parse(str[1]), int.Parse(str[0]));
                }
            }
            catch { }
            try
            {
                isValid = IsDateExt(txtDTP, false);
            }
            catch { }
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDTP.Text = dtp.Value.ToString("dd-MM-yyyy").Replace('-', '/').Replace("//", "/");
            }
            catch { }
        }

        private void txtDTP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (!IsValid())
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }

        public bool IsDateExt(TextBox textBox, bool drawBorder)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            Graphics g = textBox.Parent.Parent.CreateGraphics();
            DateTime tmp;
            if (textBox.Text.Length == 8)
            {
                textBox.Text = textBox.Text.Substring(0, 2) + "/" + textBox.Text.Substring(2, 2) + "/" + textBox.Text.Substring(4, 4);
            }
            if (DateTime.TryParseExact(textBox.Text, "d/M/yyyy", enUS, DateTimeStyles.None, out tmp) == false)
            {
                if (drawBorder == true)
                {
                    g.DrawRectangle(Pens.Red, this.Left - 1, this.Top - 1, this.Width + 1, this.Height + 1);
                    return true;
                }
            }
            g.DrawRectangle(Pens.White, this.Left - 1, this.Top - 1, this.Width + 1, this.Height + 1);
            return false;
        }

        private void txtDTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && ((Keys)e.KeyChar != Keys.Back) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        private void CustomDateTimePicker_Load(object sender, EventArgs e)
        {
            try
            {
                dtp.Value = SessionInfo.currentDate;
                txtDTP.Text = dtp.Value.ToString("dd-MM-yyyy").Replace('-', '/').Replace("//", "/");
            }
            catch { }
        }
    }
}