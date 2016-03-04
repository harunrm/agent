using MetroFramework.Controls;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.UI.forms.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Module.Common.UI
{
    public class GUI
    {
        public static Control OwnerForm;

        public Dictionary<object, GUIValidation.VALIDATIONTYPES> ControlsForValidation = new Dictionary<object, GUIValidation.VALIDATIONTYPES>();

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

            if (OwnerForm != null)
            {
                OwnerForm.SuspendLayout();
            }

            for (int i = 0; i < ControlsForValidation.Count; i++)
            {
                switch (ControlsForValidation.ElementAt(i).Value)
                {
                    case GUIValidation.VALIDATIONTYPES.TEXTBOX_EMPTY:
                        {
                            Control control = (Control)ControlsForValidation.ElementAt(i).Key;
                            Control parent = control.Parent;

                            if (GUIValidation.IsEmpty(control, null))
                            {
                                result = false;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case GUIValidation.VALIDATIONTYPES.TEXTBOX_NUMBER:
                        //GUIValidation.IsNumber(((MetroTextBox)ControlsForValidation.ElementAt(i).Key), null);
                        {
                            Control control = (Control)ControlsForValidation.ElementAt(i).Key;
                            Control parent = control.Parent;

                            if (GUIValidation.IsNumber(ref control, null))
                            {
                                result = false;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case GUIValidation.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE:
                        //GUIValidation.IsNumber(((MetroTextBox)ControlsForValidation.ElementAt(i).Key), null);
                        {
                            MetroTextBox control = (MetroTextBox)ControlsForValidation.ElementAt(i).Key;
                            control.MaxLength = 11;
                            Control parent = control.Parent;

                            if (GUIValidation.IsMobileNumber(control, null))
                            {
                                result = false;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case GUIValidation.VALIDATIONTYPES.TEXTBOX_DATE:
                        //code here.
                        break;
                    case GUIValidation.VALIDATIONTYPES.TEXTBOX_NationalID:
                        //GUIValidation.IsNumber(((MetroTextBox)ControlsForValidation.ElementAt(i).Key), null);
                        {
                            MetroTextBox control = (MetroTextBox)ControlsForValidation.ElementAt(i).Key;
                            Control parent = control.Parent;

                            if (GUIValidation.IsNationalID(control, null))
                            {
                                result = true;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case GUIValidation.VALIDATIONTYPES.TEXTBOX_DATE_NULLABLE:
                        //code here.
                        break;
                    case GUIValidation.VALIDATIONTYPES.COMBOBOX_EMPTY:
                        //GUIValidation.IsEmpty(((MetroComboBox)ControlsForValidation.ElementAt(i).Key), null);
                        {
                            MetroComboBox control = (MetroComboBox)ControlsForValidation.ElementAt(i).Key;
                            Control parent = control.Parent;

                            if (GUIValidation.IsEmpty(control, null))
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

        public void Config(Control[] control)
        {
            for (int i = 0; i < control.Length; i++)
            {
                GUI_Events gui_events = new GUI_Events();
                control[i].Enter += gui_events.control_Enter;
                control[i].Leave += gui_events.control_Leave;
                control[i].KeyUp += gui_events.control_KeyUp;
                control[i].Click += gui_events.control_Click;
            }
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

        public void Config(ref TextBox control)
        {
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.KeyUp += gui_events.control_KeyUp;
            control.Click += gui_events.control_Click;
        }

        public void Config(ref MetroFramework.Controls.MetroTextBox control, GUIValidation.VALIDATIONTYPES validationType, string message)
        {
            ControlsForValidation.Add(control, validationType);
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.Click += gui_events.control_Click;
            switch (validationType)
            {
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_EMPTY:
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsEmptyValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_NUMBER:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsNumberValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsNumberValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE:
                    control.MaxLength = 11;
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsMobileNumberValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsMobileNumberValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_DATE:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsDateValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsDateValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_DATE_NULLABLE:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsDateNullableValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsDateNullableValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_NationalID:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsNationalIDNullableValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsNationalIDNullableValidation;
                    break;
                //case GUIValidation.VALIDATIONTYPES.COMBOBOX_EMPTY:
                //    control.KeyUp += gui_events.control_KeyUp_ComboBoxIsEmptyValidation;
                //    break;
                default:
                    break;
            }
        }

        public void Config(ref TextBox control, GUIValidation.VALIDATIONTYPES validationType, string message)
        {
            ControlsForValidation.Add(control, validationType);
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.Click += gui_events.control_Click;
            switch (validationType)
            {
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_EMPTY:
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsEmptyValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_NUMBER:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsNumberValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsNumberValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE:
                    control.MaxLength = 11;
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsMobileNumberValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsMobileNumberValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_DATE:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsDateValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsDateValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_DATE_NULLABLE:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsDateNullableValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsDateNullableValidation;
                    break;
                case GUIValidation.VALIDATIONTYPES.TEXTBOX_NationalID:
                    control.KeyPress += gui_events.control_KeyPress_TextBoxIsNationalIDNullableValidation;
                    control.KeyUp += gui_events.control_KeyUp_TextBoxIsNationalIDNullableValidation;
                    break;
                //case GUIValidation.VALIDATIONTYPES.COMBOBOX_EMPTY:
                //    control.KeyUp += gui_events.control_KeyUp_ComboBoxIsEmptyValidation;
                //    break;
                default:
                    break;
            }
        }

        public void Config(ref MetroFramework.Controls.MetroComboBox control, GUIValidation.VALIDATIONTYPES validationType, string message)
        {
            ControlsForValidation.Add(control, validationType);
            GUI_Events gui_events = new GUI_Events();
            control.Enter += gui_events.control_Enter;
            control.Leave += gui_events.control_Leave;
            control.Click += gui_events.control_Click;
            switch (validationType)
            {
                case GUIValidation.VALIDATIONTYPES.COMBOBOX_EMPTY:
                    control.KeyUp += gui_events.control_KeyUp_ComboBoxIsEmptyValidation;
                    break;
                default:
                    break;
            }
        }

        public enum CONTROLSTATES
        {
            CS_ENABLE,
            CS_DISABLE,
            CS_VISIBLE,
            CS_HIDDEN,
            CS_READONLY,
            CS_READWRITE
        }

        public void SetControlState(CONTROLSTATES controlState, Control[] controls)
        {
            switch (controlState)
            {
                case CONTROLSTATES.CS_ENABLE:
                    SetControlEnable(controls, true);
                    break;
                case CONTROLSTATES.CS_DISABLE:
                    SetControlEnable(controls, false);
                    break;
                case CONTROLSTATES.CS_VISIBLE:
                    SetControlVisible(controls, true);
                    break;
                case CONTROLSTATES.CS_HIDDEN:
                    SetControlVisible(controls, false);
                    break;
                case CONTROLSTATES.CS_READONLY:
                    SetControlReadOnly(controls, true);
                    break;
                case CONTROLSTATES.CS_READWRITE:
                    SetControlReadOnly(controls, false);
                    break;
                default:
                    break;
            }
        }

        private void SetControlEnable(Control[] controls, bool val)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].Enabled = val;
            }
        }

        private void SetControlVisible(Control[] controls, bool val)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].Visible = val;
            }
        }


        public void EmptyControls(Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].ResetText();
            }
        }

        private void SetControlReadOnly(Control[] controls, bool val)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] is TextBox)
                {
                    ((TextBox)controls[i]).ReadOnly = val;
                }
                else if ((controls[i] is MetroTextBox))
                {
                    ((MetroTextBox)controls[i]).ReadOnly = val;
                }
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
                //if (!GUIValidation.IsDateExt(((CustomDateTimePicker)sender).txtDTP, true))
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

                    if (control is MetroTextBox)
                    {
                        if (GUIValidation.IsEmpty((MetroTextBox)control, null))
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
                    if (control is TextBox)
                    {
                        if (GUIValidation.IsEmpty((TextBox)control, null))
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

                    if (GUIValidation.IsNumber(ref control, null))
                    {
                        // IsValidFocus = true;
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 2, control.Top - 2, control.Width + 3, control.Height + 3);
                        //g.Flush();
                        //g.Save();
                        //MsgBox.showError("Field cannot be empty");
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

                    if (GUIValidation.IsMobileNumber((MetroTextBox)sender, null))
                    {
                        // IsValidFocus = true;
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 1, control.Top - 1, control.Width + 1, control.Height + 1);
                        //g.DrawRectangle(new Pen(Color.Red), control.Left - 2, control.Top - 2, control.Width + 3, control.Height + 3);
                        //g.Flush();
                        //g.Save();
                        //MsgBox.showError("Field cannot be empty");
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

                    if (GUIValidation.IsEmpty((MetroComboBox)sender, null))
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




            public void control_KeyPress_TextBoxIsNationalIDNullableValidation(object sender, KeyPressEventArgs e)
            {

            }

            public void control_KeyUp_TextBoxIsNationalIDNullableValidation(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    Control parent = ((Control)sender).Parent;
                    Control control = ((Control)sender);

                    MetroTextBox textBox = (MetroTextBox)sender;
                    Graphics g = textBox.Parent.CreateGraphics();

                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        MsgBox.showError("Invalid National ID");
                        g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                        return;
                    }
                    else if (!GUIValidation.IsNationalID((MetroTextBox)sender, ""))
                    {
                        MsgBox.showError("Invalid National ID");
                        g.DrawRectangle(Pens.Red, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                        return;
                    }
                    g.DrawRectangle(Pens.White, textBox.Left - 1, textBox.Top - 1, textBox.Width + 1, textBox.Height + 1);
                    //g.Flush();
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
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


        public static class DeveloperMode
        {
            private static Form _frm;
            public static string ControlNames = "";

            public static void EnableDeveloperMode(Form frm)
            {
                ControlNames = "";
                SetClickEvent(frm);

                MsgBox.showInformation("DEVELOPER MODE IS ACTIVATED!");
            }

            public static void EnableDeveloperMode(MetroForm frm)
            {
                ControlNames = "";
                SetClickEvent(frm);

                MsgBox.showInformation("DEVELOPER MODE IS ACTIVATED!");
            }

            private static void SetClickEvent(Control control)
            {
                control.Enabled = true;
                control.Click += Control_Click;
                if (control.HasChildren == true)
                {
                    for (int i = 0; i < control.Controls.Count; i++)
                    {
                        SetClickEvent(control.Controls[i]);
                    }
                }
            }

            private static void Control_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(ControlNames))
                {
                    ControlNames += ((Control)sender).Name;
                }
                else
                {
                    ControlNames += ", " + ((Control)sender).Name;

                }
                Clipboard.SetText(ControlNames);
            }
        }
    }
    //public MetroForm OwnerForm;
}