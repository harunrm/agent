using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.Development
{
    public partial class frmDataAsign : Form
    {

        String result;
        public frmDataAsign()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtInput.Text)){
                lblMsg.Text = "Input Data may be empty";
            }
            else {

      
                String inputDataWhole = txtInput.Text;

                string[] lines = inputDataWhole.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                foreach (String line in lines)
                {
                    String inputData = line.Remove(line.Length - 1);
                    string[] splitedText = inputData.Split('=');
                    String getText = splitedText[1].Trim() + " = "+splitedText[0].Trim() + ";";
                    result = result + "\r\n" + getText;

                }
                
                Clipboard.SetText(result);
                lblMsg.Text = "Result copied to Clipboard";
            }

        }

        private void txtInput_MouseLeave(object sender, EventArgs e)
        {
            lblMsg.Text = "";
        }
    }
}
