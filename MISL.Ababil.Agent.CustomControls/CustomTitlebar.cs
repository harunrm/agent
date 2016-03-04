using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.CustomControls
{
    public partial class CustomTitlebar : UserControl
    {
        public Form OwnerForm { get; set; }

        public bool ShowTitle
        {
            get
            {
                return lblTitle.Visible;
            }
            set
            {
                lblTitle.Visible = value;
            }
        }

        private int tmpX = 0;
        private int tmpY = 0;

        public CustomTitlebar()
        {
            InitializeComponent();

            //if (OwnerForm != null)
            //{
            //    OwnerForm.Resize += OwnerForm_Resize;
            //}
        }

        private void OwnerForm_Resize(object sender, EventArgs e)
        {
            //OwnerForm.Refresh();
            //OwnerForm.Update();
        }

        private void CustomTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = e.X;
            tmpY = e.Y;
        }

        private void CustomTitlebar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    OwnerForm.Left = Cursor.Position.X - tmpX;
                    OwnerForm.Top = Cursor.Position.Y - tmpY;
                }
                catch { }
            }
        }

        private void CustomTitlebar_Load(object sender, EventArgs e)
        {
            if (OwnerForm != null)
            {
                btnMax.Enabled = OwnerForm.MaximizeBox;
                btnMin.Enabled = OwnerForm.MinimizeBox;

                lblTitle.Text = OwnerForm.Text;

                if (OwnerForm.WindowState == FormWindowState.Normal)
                {
                    btnMax.Text = "1";
                    return;
                }
                if (OwnerForm.WindowState == FormWindowState.Maximized)
                {
                    btnMax.Text = "2";
                }
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            OwnerForm.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {            
            //if (OwnerForm.WindowState == FormWindowState.Normal)
            if (btnMax.Text == "1")
            {
                OwnerForm.WindowState = FormWindowState.Maximized;
                btnMax.Text = "2";
                OwnerForm.Focus();
                return;
            }
            //if (OwnerForm.WindowState == FormWindowState.Maximized)
            if (btnMax.Text == "2")
            {
                OwnerForm.WindowState = FormWindowState.Normal;
                btnMax.Text = "1";
                OwnerForm.Focus();
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OwnerForm.Close();
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (i > 3)
            //{
            //    i = 0;
            //    timer1.Enabled = false;
            //}
            //if (OwnerForm != null)
            //{
            //    OwnerForm.Refresh();
            //    OwnerForm.Update();
            //}
            //i++;
        }

        private void btnMax_MouseUp(object sender, MouseEventArgs e)
        {
            i = 0;
            timer1.Enabled = true;
        }

        private void btnMax_Enter(object sender, EventArgs e)
        {
            if (OwnerForm.WindowState == FormWindowState.Normal)
            {
                btnMax.Text = "1";
                return;
            }
            if (OwnerForm.WindowState == FormWindowState.Maximized)
            {
                btnMax.Text = "2";
            }
        }

        private void CustomTitlebar_MouseUp(object sender, MouseEventArgs e)
        {
            if (OwnerForm != null)
            {
                OwnerForm.Refresh();
                OwnerForm.Update();
            }
        }
    }
}