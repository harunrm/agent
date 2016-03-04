using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Services
{
    public static class Validate
    {
        public static class VTextBox
        {
            public static bool IsEmpty(ref TextBox textBox, string errorMessage)
            {                
                if (textBox.Text.Trim().Length == 0)
                {
                    if(errorMessage != null)
                    {
                        MessageBox.Show(errorMessage);
                    }
                    return true;
                }
                else
                {
                    Graphics g = textBox.Parent.CreateGraphics();
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                }
                return false;
            }
        }
    }
}