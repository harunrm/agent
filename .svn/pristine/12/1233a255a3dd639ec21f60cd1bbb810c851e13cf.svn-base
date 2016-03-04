using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Module.Common.UI
{    
        public static class GUIValidation
    {
            public enum VALIDATIONTYPES
            {
                TEXTBOX_EMPTY = 2,
                TEXTBOX_NUMBER = 4,
                TEXTBOX_NUMBER_MOBILE = 8,
                TEXTBOX_DATE = 16,
                TEXTBOX_DATE_NULLABLE = 32,
                TEXTBOX_NationalID = 64,
                COMBOBOX_EMPTY = 128,

            }

            public const string DATE_SAPERATOR = "-";

            public static bool IsEmpty(Control textBox, string message)
            {
                Graphics g = textBox.Parent.CreateGraphics();
                if (textBox.Text.Trim().Length == 0)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    ////g.Flush();
                    if (message != null)
                    {
                        //MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();

                return false;
            }

            public static bool IsEmpty(MetroTextBox textBox, string message)
            {
                Graphics g = textBox.Parent.CreateGraphics();
                if (textBox.Text.Trim().Length == 0)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    ////g.Flush();
                    if (message != null)
                    {
                        //MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();

                return false;
            }

            public static bool IsEmpty(TextBox textBox, string message)
            {
                Graphics g = textBox.Parent.CreateGraphics();
                if (textBox.Text.Trim().Length == 0)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    ////g.Flush();
                    if (message != null)
                    {
                        //MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();

                return false;
            }

            public static bool IsEmpty(ref TextBox textBox, string message)
            {
                Graphics g = textBox.Parent.CreateGraphics();
                if (textBox.Text.Trim().Length == 0)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    if (message != null)
                    {
                        // MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();

                return false;
            }

            public static bool IsEmpty(ref MetroTextBox textBox, string message)
            {
                Graphics g = textBox.Parent.CreateGraphics();
                if (textBox.Text.Trim().Length == 0)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    if (message != null)
                    {
                        // MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();

                return false;
            }

            public static bool IsEmpty(ref ComboBox comboBox, string message)
            {
                Graphics g = comboBox.Parent.CreateGraphics();
                if (comboBox.SelectedIndex < 0)
                {
                    g.DrawRectangle(Pens.Red, comboBox.Left - 1, comboBox.Top - 1, comboBox.Width + 1, comboBox.Height + 1);
                    //g.Flush();
                    if (message != null)
                    {
                        // MessageBox.Show(message);
                    }
                    return true;
                }
                //g.Clear(comboBox.Parent.BackColor);
                g.DrawRectangle(Pens.White, comboBox.Left - 1, comboBox.Top - 1, comboBox.Width + 1, comboBox.Height + 1);
                return false;
            }

            public static bool IsEmpty(MetroComboBox comboBox, string message)
            {
                Graphics g = comboBox.Parent.CreateGraphics();
                if (comboBox.SelectedIndex < 0)
                {
                    g.DrawRectangle(Pens.Red, comboBox.Left - 1, comboBox.Top - 1, comboBox.Width + 1, comboBox.Height + 1);
                    //g.Flush();
                    if (message != null)
                    {
                        //  MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, comboBox.Left - 1, comboBox.Top - 1, comboBox.Width + 1, comboBox.Height + 1);
                //g.Clear(comboBox.Parent.BackColor);
                return false;
            }

            public static bool IsNumber(ref Control textBox, string message)
            {
                Graphics g = textBox.Parent.CreateGraphics();
                double tmp = 0.0;
                if (double.TryParse(textBox.Text, out tmp) == false)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    if (message != null)
                    {
                        //  MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();

                return false;
            }

            //public static bool IsNumber(ref MetroTextBox textBox, string message)
            //{
            //    Graphics g = textBox.Parent.CreateGraphics();
            //    double tmp = 0.0;
            //    if (double.TryParse(textBox.Text, out tmp) == false)
            //    {
            //        g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
            //        //g.Flush();
            //        if (message != null)
            //        {
            //            //    MessageBox.Show(message);
            //        }
            //        return true;
            //    }
            //    g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
            //    //g.Flush();

            //    return false;
            //}

            public static bool IsNumber(MetroTextBox textBox, string message)
            {
                Graphics g = textBox.Parent.CreateGraphics();
                double tmp = 0.0;
                if (double.TryParse(textBox.Text, out tmp) == false)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    if (message != null)
                    {
                        // MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();

                return false;
            }

            public static bool IsNationalID(MetroTextBox textBox, string message)
            {
                bool isNationalID = true;
                int tmp = 0;
                string tmpStr = textBox.Text;


                if (tmpStr.Length == 11 || tmpStr.Length == 13 || tmpStr.Length == 17)
                {
                    isNationalID = true;
                }
                else
                {
                    isNationalID = false;
                }


                Graphics g = textBox.Parent.CreateGraphics();
                if (!isNationalID)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    if (message != null)
                    {
                        //MessageBox.Show(message);
                    }
                    return false;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                return isNationalID;
            }

            public static bool IsMobileNumber(MetroTextBox textBox, string message)
            {
                bool isMobileNumber = true;
                int tmp = 0;
                string tmpStr = textBox.Text;

                if (!int.TryParse(textBox.Text, out tmp))
                {
                    isMobileNumber = false;
                }
                else
                {
                    if (tmpStr.Length != 11)
                    {
                        isMobileNumber = false;
                    }
                    else
                    {
                        if (
                            tmpStr.Substring(0, 3) != "015"
                            &&
                            tmpStr.Substring(0, 3) != "016"
                            &&
                            tmpStr.Substring(0, 3) != "017"
                            &&
                            tmpStr.Substring(0, 3) != "018"
                            &&
                            tmpStr.Substring(0, 3) != "019"
                            &&
                            tmpStr.Substring(0, 3) != "011"
                          )
                        {
                            isMobileNumber = false;
                        }
                    }
                }

                Graphics g = textBox.Parent.CreateGraphics();
                if (!isMobileNumber)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    if (message != null)
                    {
                        //MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                return false;
            }

            public static bool IsDate(ref TextBox textBox, string message)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                Graphics g = textBox.Parent.CreateGraphics();
                DateTime tmp;
                if (textBox.Text.Length == 8)
                {
                    textBox.Text = textBox.Text.Substring(0, 2) + DATE_SAPERATOR + textBox.Text.Substring(2, 2) + DATE_SAPERATOR + textBox.Text.Substring(4, 4); ;
                }
                if (DateTime.TryParseExact(textBox.Text.Replace("/", "-"), "d-M-yyyy", enUS, DateTimeStyles.None, out tmp) == false)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    if (message != null)
                    {
                        // MessageBox.Show(message);
                    }
                    return true;
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();
                return false;
            }

            public static bool IsDate(ref TextBox textBox, bool drawBorder)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                Graphics g = textBox.Parent.CreateGraphics();
                DateTime tmp;
                if (textBox.Text.Length == 8)
                {
                    textBox.Text = textBox.Text.Substring(0, 2) + DATE_SAPERATOR + textBox.Text.Substring(2, 2) + DATE_SAPERATOR + textBox.Text.Substring(4, 4); ;
                }
                if (DateTime.TryParseExact(textBox.Text.Replace("/", "-"), "d-M-yyyy", enUS, DateTimeStyles.None, out tmp) == false)
                {
                    if (drawBorder == true)
                    {
                        g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                        return true;
                    }
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                return false;
            }

            public static bool IsDateExt(TextBox textBox, bool drawBorder)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                Graphics g = textBox.Parent.CreateGraphics();
                DateTime tmp;
                if (textBox.Text.Length == 8)
                {
                    textBox.Text = textBox.Text.Substring(0, 2) + "/" + textBox.Text.Substring(2, 2) + "/" + textBox.Text.Substring(4, 4);
                }
                if (DateTime.TryParseExact(textBox.Text, "d/M/yyyy", enUS, DateTimeStyles.None, out tmp) == false)
                {
                    if (drawBorder == true)
                    {
                        g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                        return true;
                    }
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                return false;
            }

            public static void Config_Date_TextBox(ref TextBox textBox)
            {
                textBox.Leave += Date_TextBox_Leave;
                textBox.Enter += Date_TextBox_Enter;
            }

            private static void Date_TextBox_Enter(object sender, EventArgs e)
            {

            }

            private static void Date_TextBox_Leave(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;

                CultureInfo enUS = new CultureInfo("en-US");
                Graphics g = textBox.Parent.CreateGraphics();
                DateTime tmp;
                if (textBox.Text.Length == 8)
                {
                    textBox.Text = textBox.Text.Substring(0, 2) + DATE_SAPERATOR + textBox.Text.Substring(2, 2) + DATE_SAPERATOR + textBox.Text.Substring(4, 4); ;
                }
                if (DateTime.TryParseExact(textBox.Text.Replace("/", "-"), "d-M-yyyy", enUS, DateTimeStyles.None, out tmp) == false)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();
            }

            public static void Config_Number_TextBox(ref TextBox textBox)
            {
                textBox.Leave += Number_TextBox_Leave;
                textBox.Enter += Number_TextBox_Enter;
                //textBox.KeyPress += Number_TextBox_KeyPress;
            }

            private static void Number_TextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if ((!char.IsNumber(e.KeyChar)) && ((Keys)e.KeyChar != Keys.Back) && ((Keys)e.KeyChar != Keys.Decimal))
                {
                    e.Handled = true;
                }
                //base.OnKeyPress(e);                         
            }

            private static void Number_TextBox_Enter(object sender, EventArgs e)
            {

            }

            private static void Number_TextBox_Leave(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;

                Graphics g = textBox.Parent.CreateGraphics();
                double tmp = 0.0;
                if (double.TryParse(textBox.Text, out tmp) == false)
                {
                    g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                }
                g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                //g.Flush();
            }
        }    
}