using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.CustomControls
{
    public partial class frmTestTemp : Form
    {
        public frmTestTemp()
        {
            InitializeComponent();
        }

        private void frmTestTemp_Load(object sender, EventArgs e)
        {
            SetDataGridHeaders(new string[] { "Number", "Name", "Address" });
        }

        public void SetDataGridHeaders(string[] keys, string[] header)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[keys[i]].HeaderText = header[i];
            }
        }

        public void SetDataGridHeaders(string[] header)
        {
            for (int i = 0; i < header.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = header[i];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetDataGridHeaders(new string[] { "Number", "Name", "Address" });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetDataGridHeaders(new string[] { "", "", "" });
        }
    }
}