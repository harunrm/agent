using MetroFramework.Forms;
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
    public partial class frmMainWindow : MetroForm
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button2, new Point(0, button2.Height));
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if(panel2.Width== 190)
        //    {
        //        panel2.Width = 8;
        //        lblTitle.Text = "O";
        //        //flowMenu.Visible = false;
        //    }
        //    else
        //    {
        //        lblTitle.Text = "Outlet";
        //        panel2.Width = 190;
        //    //    flowMenu.Visible = true;
        //    }
        //}

        //private void lblTitle_Click(object sender, EventArgs e)
        //{
        //    if (panel2.Width == 8)
        //    {
        //        lblTitle.Text = "Outlet";
        //        panel2.Width = 190;
        //     //   flowMenu.Visible = true;
        //    }
        //}

        //private void panel2_Click(object sender, EventArgs e)
        //{
        //    if (panel2.Width == 8)
        //    {
        //        lblTitle.Text = "Outlet";
        //        panel2.Width = 190;
        //     //   flowMenu.Visible = true;
        //    }
        //}

        //private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        //{
        //    //treeView1.Height = 100;
        //}

        //private void treeView2_AfterExpand(object sender, TreeViewEventArgs e)
        //{
        //  //  treeView2.Height = 100;
        //}

        //private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        //{
        //    //treeView1.Height = 22;
        //}

        //private void treeView2_AfterCollapse(object sender, TreeViewEventArgs e)
        //{
        // //   treeView2.Height = 22;
        //}
    }
}
