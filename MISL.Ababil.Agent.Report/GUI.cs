using MetroFramework.Controls;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Report
{
    public class GUI
    {
        //public MetroForm OwnerForm;
        public Control OwnerForm;

        public Dictionary<object, ValidCheck.VALIDATIONTYPES> ControlsForValidation = new Dictionary<object, ValidCheck.VALIDATIONTYPES>();

        Timer t = new Timer();


        public GUI()
        {

        }

        public object FocusedControl = null;

        public GUI(MetroForm ownerForm)
        {
            OwnerForm = ownerForm;
        }

        public GUI(Form ownerForm)
        {
            OwnerForm = ownerForm;
        }

        public void RefreshOwnerForm()
        {
            ((Form)OwnerForm).FormBorderStyle = FormBorderStyle.None;
            OwnerForm.Focus();
            OwnerForm.Update();
            OwnerForm.Refresh();
        }

        private void T_Click(object sender, EventArgs e)
        {
            ((Form)OwnerForm).Close();
        }

        public void FocusControl(object control)
        {
            Control controlObj = (Control)control;
            Control parent = controlObj.Parent;
            controlObj.Focus();
            controlObj.Refresh();
            Graphics g = parent.CreateGraphics();
            g.DrawRectangle(new Pen(Color.DodgerBlue), controlObj.Left - 1, controlObj.Top - 1, controlObj.Width + 1, controlObj.Height + 1);
        }

        public bool IsAllControlValidated()
        {
            bool result = true;
            bool firstControl = true;

            OwnerForm.SuspendLayout();

            for (int i = 0; i < ControlsForValidation.Count; i++)
            {
                switch (ControlsForValidation.ElementAt(i).Value)
                {
                    case ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY:
                        {
                            MetroTextBox control = (MetroTextBox)ControlsForValidation.ElementAt(i).Key;
                            Control parent = control.Parent;

                            if (ValidCheck.IsEmpty(control, null))
                            {
                                result = false;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER:
                        //ValidCheck.IsNumber(((MetroTextBox)ControlsForValidation.ElementAt(i).Key), null);
                        {
                            MetroTextBox control = (MetroTextBox)ControlsForValidation.ElementAt(i).Key;
                            Control parent = control.Parent;

                            if (ValidCheck.IsNumber(control, null))
                            {
                                result = false;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE:
                        //ValidCheck.IsNumber(((MetroTextBox)ControlsForValidation.ElementAt(i).Key), null);
                        {
                            MetroTextBox control = (MetroTextBox)ControlsForValidation.ElementAt(i).Key;
                            control.MaxLength = 11;
                            Control parent = control.Parent;

                            if (ValidCheck.IsMobileNumber(control, null))
                            {
                                result = false;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case ValidCheck.VALIDATIONTYPES.TEXTBOX_DATE:
                        //code here.
                        break;
                    case ValidCheck.VALIDATIONTYPES.TEXTBOX_DATE_NULLABLE:
                        //code here.
                        break;
                    case ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY:
                        //ValidCheck.IsEmpty(((MetroComboBox)ControlsForValidation.ElementAt(i).Key), null);
                        {
                            MetroComboBox control = (MetroComboBox)ControlsForValidation.ElementAt(i).Key;
                            Control parent = control.Parent;

                            if (ValidCheck.IsEmpty(control, null))
                            {
                                result = false;
                            }
                            else
                            {
                            }
                        }
                        break;
                    default:
                        break;
                }
                if (firstControl == true)
                {
                    if (result == false)
                    {
                        firstControl = false;
                        ((Control)ControlsForValidation.ElementAt(i).Key).Focus();
                    }
                }
            }
            return result;
        }

        public void Config(ref Control control)
        {
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.KeyUp += gui_events.control_KeyUp;
            control.Click += gui_events.control_Click;
        }

        public void Config(ref CustomDateTimePicker control)
        {
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_CustomDateTimePickerLeave;
            control.KeyUp += gui_events.control_CustomDateTimePickerKeyUp;
            control.Click += gui_events.control_Click;
        }

        public void Config(ref MetroFramework.Controls.MetroComboBox control)
        {
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.KeyUp += gui_events.control_KeyUp;
            control.Click += gui_events.control_Click;
        }

        public void Config(ref MetroFramework.Controls.MetroTextBox control)
        {
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.KeyUp += gui_events.control_KeyUp;
            control.Click += gui_events.control_Click;
        }

        public void Config(ref MetroFramework.Controls.MetroTextBox control, ValidCheck.VALIDATIONTYPES validationType, string message)
        {
            ControlsForValidation.Add(control, validationType);
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.Click += gui_events.control_Click;
            switch (validationType)
            {
                case ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY:
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsEmptyValidation;
                    break;
                case ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsNumberValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsNumberValidation;
                    break;
                case ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE:
                    control.MaxLength = 11;
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsMobileNumberValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsMobileNumberValidation;
                    break;
                case ValidCheck.VALIDATIONTYPES.TEXTBOX_DATE:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsDateValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsDateValidation;
                    break;
                case ValidCheck.VALIDATIONTYPES.TEXTBOX_DATE_NULLABLE:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsDateNullableValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsDateNullableValidation;
                    break;
                //case ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY:
                //    control.KeyUp += gui_events.control_KeyUp_ComboBoxIsEmptyValidation;
                //    break;
                default:
                    break;
            }
        }


        public void Config(ref MetroFramework.Controls.MetroComboBox control, ValidCheck.VALIDATIONTYPES validationType, string message)
        {
            ControlsForValidation.Add(control, validationType);
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.Click += gui_events.control_Click;
            switch (validationType)
            {
                case ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY:
                    control.KeyUp += gui_events.control_KeyUp_ComboBoxIsEmptyValidation;
                    break;
                default:
                    break;
            }
        }

        public class GUI_Events
        {
            public string DATE_SAPERATOR = "-";
            public bool IsValidFocus = false;

            public void control_Click(object sender, EventArgs e)
            {
                System.Threading.Thread.Sleep(10); Application.DoEvents();
                // if (IsValidFocus == false)
                {
                    Control parent = ((Control)sender).Parent;
                    //parent.Refresh();
                    Control control = ((Control)sender);
                    Graphics g = parent.CreateGraphics();
                    g.DrawRectangle(new Pen(Color.DodgerBlue), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                }
                //else
                //{
                //    IsValidFocus = false;
                //}
            }


            public void control_Enter(object sender, EventArgs e)
            {
                System.Threading.Thread.Sleep(50); Application.DoEvents();
                // if (IsValidFocus == false)
                {
                    Control parent = ((Control)sender).Parent;
                    //parent.Refresh();
                    Control control = ((Control)sender);
                    Graphics g = parent.CreateGraphics();
                    g.DrawRectangle(new Pen(Color.DodgerBlue), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                }
                //else
                //{
                //    IsValidFocus = false;
                //}
            }

            public void control_Leave(object sender, EventArgs e)
            {

                Control parent = ((Control)sender).Parent;
                Control control = ((Control)sender);
                //if (control.Focused == false)
                {
                    Graphics g = parent.CreateGraphics();
                    g.DrawRectangle(new Pen(Color.White), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                    //IsValidFocus = false;
                }
                //g.DrawRectangle(new Pen(Color.White), control.Left - 2, control.Top - 2, control.Width + 3, control.Height + 3);
                //g.Flush();
                //g.Save();
            }

            public void control_CustomDateTimePickerLeave(object sender, EventArgs e)
            {

                //Control parent = ((Control)sender).Parent;
                //Control control = ((Control)sender);
                ////  if (control.Focused == false)
                //if (!ValidCheck.IsDateExt(((CustomDateTimePicker)sender).txtDTP, true))
                //{
                //    Graphics g = parent.CreateGraphics();
                //    g.DrawRectangle(new Pen(Color.White), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                //    IsValidFocus = false;
                //}
                //g.DrawRectangle(new Pen(Color.White), control.Left - 2, control.Top - 2, control.Width + 3, control.Height + 3);
                //g.Flush();
                //g.Save();
            }

            public void control_KeyUp_TextBoxIsEmptyValidation(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    Control parent = ((Control)sender).Parent;
                    Control control = ((Control)sender);

                    if (ValidCheck.IsEmpty((MetroTextBox)sender, null))
                    {
                        //IsValidFocus = true;
                    }
                    else
                    {
                        //IsValidFocus = false;
                        // e.Handled = true;
                        SendKeys.Send("{TAB}");
                    }
                }
            }

            public void control_KeyUp_TextBoxIsNumberValidation(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    Control parent = ((Control)sender).Parent;
                    //parent.Refresh();
                    Control control = ((Control)sender);
                    ////Graphics g = parent.CreateGraphics();

                    if (ValidCheck.IsNumber((MetroTextBox)sender, null))
                    {
                        // IsValidFocus = true;
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 2, control.Top - 2, control.Width + 3, control.Height + 3);
                        //g.Flush();
                        //g.Save();
                        //Message.showError("Field cannot be empty");
                    }
                    else
                    {
                        // IsValidFocus = false;
                        // e.Handled = true;
                        SendKeys.Send("{TAB}");
                        //System.Threading.Thread.Sleep(10);
                    }
                }
            }

            public void control_KeyPress_TextBoxIsNumberValidation(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '.')
                {
                    if (((Control)sender).Text.IndexOf(".", 0) > -1)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                if ((!char.IsNumber(e.KeyChar)) && ((Keys)e.KeyChar != Keys.Back) && ((Keys)e.KeyChar != Keys.OemPeriod) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

            }

            public void control_KeyUp_TextBoxIsMobileNumberValidation(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    Control parent = ((Control)sender).Parent;
                    //parent.Refresh();
                    Control control = ((Control)sender);
                    ////Graphics g = parent.CreateGraphics();

                    if (ValidCheck.IsMobileNumber((MetroTextBox)sender, null))
                    {
                        // IsValidFocus = true;
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 2, control.Top - 2, control.Width + 3, control.Height + 3);
                        //g.Flush();
                        //g.Save();
                        //Message.showError("Field cannot be empty");
                    }
                    else
                    {
                        // IsValidFocus = false;
                        // e.Handled = true;
                        SendKeys.Send("{TAB}");
                        //System.Threading.Thread.Sleep(10);
                    }
                }
            }

            public void control_KeyPress_TextBoxIsMobileNumberValidation(object sender, KeyPressEventArgs e)
            {
                //if (e.KeyChar == '.')
                //{
                //    if (((Control)sender).Text.IndexOf(".", 0) > -1)
                //    {
                //        e.Handled = true;
                //        return;
                //    }
                //}
                if ((!char.IsNumber(e.KeyChar)) && ((Keys)e.KeyChar != Keys.Back))
                {
                    e.Handled = true;
                }

            }

            public void control_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                    ////System.Threading.Thread.Sleep(10);
                }
            }

            public void control_KeyUp_ComboBoxIsEmptyValidation(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    Control parent = ((Control)sender).Parent;
                    Control control = ((Control)sender);

                    if (ValidCheck.IsEmpty((MetroComboBox)sender, null))
                    {
                        IsValidFocus = true;
                    }
                    else
                    {
                        IsValidFocus = false;
                        e.Handled = true;
                        SendKeys.Send("{TAB}");
                        //System.Threading.Thread.Sleep(10);
                    }
                }
            }

            public void control_KeyUp_TextBoxIsDateValidation(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    Control parent = ((Control)sender).Parent;
                    Control control = ((Control)sender);

                    MetroTextBox textBox = (MetroTextBox)sender;

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

                        return;
                        //g.Flush();
                    }
                    g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }

            public void control_KeyPress_TextBoxIsDateValidation(object sender, KeyPressEventArgs e)
            {

            }

            public void control_KeyPress_TextBoxIsDateNullableValidation(object sender, KeyPressEventArgs e)
            {

            }

            public void control_KeyUp_TextBoxIsDateNullableValidation(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    Control parent = ((Control)sender).Parent;
                    Control control = ((Control)sender);

                    MetroTextBox textBox = (MetroTextBox)sender;
                    Graphics g = textBox.Parent.CreateGraphics();

                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        CultureInfo enUS = new CultureInfo("en-US");

                        DateTime tmp;
                        if (textBox.Text.Length == 8)
                        {
                            textBox.Text = textBox.Text.Substring(0, 2) + DATE_SAPERATOR + textBox.Text.Substring(2, 2) + DATE_SAPERATOR + textBox.Text.Substring(4, 4); ;
                        }
                        if (DateTime.TryParseExact(textBox.Text.Replace("/", "-"), "d-M-yyyy", enUS, DateTimeStyles.None, out tmp) == false)
                        {
                            g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);

                            return;
                            //g.Flush();
                        }
                    }
                    g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }

            public void control_CustomDateTimePickerKeyUp(object sender, KeyEventArgs e)
            {
                if (((CustomDateTimePicker)sender).IsValid() == true)
                {
                    if (e.KeyCode == Keys.Return)
                    {
                        e.Handled = true;
                        SendKeys.Send("{TAB}");
                        ////System.Threading.Thread.Sleep(10);
                    }
                }
            }
        }
    }
}
