using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Infrastructure.Validation

{
    public class ValidationManager
    {
        private const bool ForceBackColor = true;
        private const string SpecialCharacterRegexPattern = "^[a-zA-Z0-9 ]*$";
        private const string ContainsDigitPattern = @"\d+";

        private static readonly Color InvalidBackColor = Color.GreenYellow;
        private static readonly Color MandatoryFailedBackColor = Color.Crimson;
        private static readonly Color ValidBackColor = Color.White;

        private static readonly Hashtable _queueControls = new Hashtable();
        private static readonly Hashtable _queueValidationDefinitions = new Hashtable();
        private static readonly Hashtable _validatedForms = new Hashtable();
        private static readonly Hashtable _tabIndexedControl = new Hashtable();

        private static short _errorIndex = 0;

        internal class ValidationDefinition
        {
            public string ControlName;
            public string ControlDescription;
            public long ValidationRequirement;
            public bool Mandatory;
            public bool EffectBackColor;
            public object FirstParameter;
            public object SecondParameter;
        }


        public static bool ConfigureValidation(Form form, Control control, string controlDescription, long validationRequirement, bool mandatory = false, bool effectBackcolor = false, object firstParameter = null, object secondParameter = null)
        {
            bool success = false;

            if (form == null || control == null || !ValidateNonEmptyText(controlDescription) ||
                validationRequirement < 1) return success;

            string formName = form.Name;
            string controlName = control.Name;

            ValidationDefinition validationDefinition = new ValidationDefinition();

            validationDefinition.ControlName = controlName;
            validationDefinition.ControlDescription = controlDescription;
            validationDefinition.ValidationRequirement = validationRequirement;
            validationDefinition.Mandatory = mandatory;
            validationDefinition.EffectBackColor = effectBackcolor;
            if (ForceBackColor) validationDefinition.EffectBackColor = true;
            validationDefinition.FirstParameter = firstParameter;
            validationDefinition.SecondParameter = secondParameter;

            List<ValidationDefinition> validationDefinitions;
            bool duplicationValidationRequirement = false;

            if (_validatedForms.ContainsKey(formName))
            {
                validationDefinitions = _validatedForms[formName] as List<ValidationDefinition>;
                if (validationDefinitions != null)
                {
                    foreach (ValidationDefinition definition in validationDefinitions)
                    {
                        if ((definition.ControlName.Equals(validationDefinition.ControlName)) &&
                             (definition.ValidationRequirement.Equals(validationDefinition.ValidationRequirement)))
                        {
                            duplicationValidationRequirement = true;
                            break;
                        }
                    }
                    if (!duplicationValidationRequirement)
                        validationDefinitions.Add(validationDefinition);
                    else
                        return success;
                }
                else
                {
                    validationDefinitions = new List<ValidationDefinition>();
                    validationDefinitions.Add(validationDefinition);
                    _validatedForms[formName] = validationDefinitions;
                }
            }
            else
            {
                validationDefinitions = new List<ValidationDefinition>();
                validationDefinitions.Add(validationDefinition);
                _validatedForms.Add(formName, validationDefinitions);
            }

            success = true;
            return success;
        }


        public static bool ReleaseValidationData(Form form)
        {
            string formName = form.Name;
            if (_validatedForms.ContainsKey(formName))
            {
                _validatedForms.Remove(formName);
            }

            return true;
        }

        public static int QueueValidateControl(Control control, string controlDescription, long validationRequirement, int queueId = 0, bool mandatory = false, bool effectBackColor = false, object firstParameter = null, object secondParameter = null)
        {
            int newId;
            if (queueId == 0)
            {
                newId = _queueControls.Keys.Count + 1;
                _queueControls.Add(newId, null);
                _queueValidationDefinitions.Add(newId, null);
            }
            else
            {
                newId = queueId;
            }

            if (!_queueControls.ContainsKey(newId) || !(_queueValidationDefinitions.ContainsKey(newId))) throw new Exception("Invalid queue Id");

            List<ValidationDefinition> validationDefinitions;
            List<Control> controls;
            if (_queueValidationDefinitions[newId] == null)
            {
                validationDefinitions = new List<ValidationDefinition>();
                _queueValidationDefinitions[newId] = validationDefinitions;
            }
            else
            {
                validationDefinitions = _queueValidationDefinitions[newId] as List<ValidationDefinition>;
            }

            if (_queueControls[newId] == null)
            {
                controls = new List<Control>();
                _queueControls[newId] = controls;
            }
            else
            {
                controls = _queueControls[newId] as List<Control>;
            }

            controls.Add(control);
            
            ValidationDefinition validationDefinition = new ValidationDefinition();

            validationDefinition.ControlName = control.Name;
            validationDefinition.ControlDescription = controlDescription;
            validationDefinition.ValidationRequirement = validationRequirement;
            validationDefinition.Mandatory = mandatory;
            if (ForceBackColor) validationDefinition.EffectBackColor = true;
            validationDefinition.EffectBackColor = effectBackColor;
            validationDefinition.FirstParameter = firstParameter;
            validationDefinition.SecondParameter = secondParameter;

            validationDefinitions.Add(validationDefinition);

            return newId;

        }

        public static bool ValidateQueue(int queueId)
        {
            bool success = false;
            if (!_queueControls.ContainsKey(queueId) || !(_queueValidationDefinitions.ContainsKey(queueId))) throw new Exception("Invalid queue Id");
            List<ValidationDefinition> validationDefinitions = _queueValidationDefinitions[queueId] as List<ValidationDefinition>;
            List<Control> controls = _queueControls[queueId] as List<Control>;
            if (validationDefinitions == null || controls == null) return success;
            _tabIndexedControl.Clear();
            _errorIndex = 0;

            string validationMessage = "";
            bool mandatoryViolated = false;

            validationMessage = IterateControlsForValidation (controls, validationDefinitions, validationMessage);

            if (validationMessage.Contains(StringTable.This_field_is_mandatory_)) mandatoryViolated = true;

            success = !mandatoryViolated;

            if (validationMessage.Length > 0)
            {
                MessageBox.Show(StringTable.Inputs_Need_Attention + "\n\n" + validationMessage, StringTable.Input_error);

                if (_tabIndexedControl.Count > 0)
                {
                    ICollection tabIndexes = _tabIndexedControl.Keys;
                    int minTabIndex = int.MaxValue;
                    foreach (int indexed in tabIndexes)
                    {
                        minTabIndex = Math.Min(minTabIndex, indexed);
                    }
                    ((Control)_tabIndexedControl[minTabIndex]).Focus();

                }
                _tabIndexedControl.Clear();

            }

            _errorIndex = 0;
            _queueControls.Clear();
            _queueValidationDefinitions.Clear();

            return success;
        }

        public static bool ValidateSubset(Form form, List<Control> controls)
        {
            bool success = false;
            if (form == null) return success;
            if (!_validatedForms.ContainsKey(form.Name)) return success;
            List<ValidationDefinition> validationDefinitions = _validatedForms[form.Name] as List<ValidationDefinition>;
            if (validationDefinitions == null) return success;
            if (controls == null) return success;

            string validationMessage = "";
            bool mandatoryViolated = false;
            _tabIndexedControl.Clear();
            _errorIndex = 0;

            validationMessage = IterateControlsForValidation(controls, validationDefinitions, validationMessage);

            if (validationMessage.Contains(StringTable.This_field_is_mandatory_)) mandatoryViolated = true;

            success = !mandatoryViolated;

            if (validationMessage.Length > 0)
            {
                MessageBox.Show(StringTable.Inputs_Need_Attention + "\n\n" + validationMessage, StringTable.Input_error);
            }

            if (_tabIndexedControl.Count > 0)
            {
                ICollection tabIndexes = _tabIndexedControl.Keys;
                int minTabIndex = int.MaxValue;
                foreach (int indexed in tabIndexes)
                {
                    minTabIndex = Math.Min(minTabIndex, indexed);
                }
                form.Focus();
                ((Control)_tabIndexedControl[minTabIndex]).Focus();

            }

            _errorIndex = 0;
            _tabIndexedControl.Clear();

            return success;
        }

        public static bool ValidateForm(Form form)
        {
            bool success = false;
            if (form == null) return success;
            if (!_validatedForms.ContainsKey(form.Name)) return success;
            List<ValidationDefinition> validationDefinitions = _validatedForms[form.Name] as List<ValidationDefinition>;
            if (validationDefinitions == null) return success;

            string validationMessage = "";
            bool mandatoryViolated = false;
            _errorIndex = 0;

            _tabIndexedControl.Clear();

            Control.ControlCollection controlCollection = form.Controls;

            validationMessage = TraverseControlsForValidation(controlCollection, validationDefinitions, validationMessage);

            if (validationMessage.Contains(StringTable.This_field_is_mandatory_)) mandatoryViolated = true;

            success = !mandatoryViolated;

            if (validationMessage.Length > 0)
            {
                MessageBox.Show(StringTable.Inputs_Need_Attention + "\n\n" + validationMessage, StringTable.Input_error);
            }

            if (_tabIndexedControl.Count > 0)
            {
                ICollection tabIndexes = _tabIndexedControl.Keys;
                int minTabIndex = int.MaxValue;
                foreach (int indexed in tabIndexes)
                {
                    minTabIndex = Math.Min(minTabIndex, indexed);
                }
                form.Focus();
                ((Control)_tabIndexedControl[minTabIndex]).Focus();

            }

            _errorIndex = 0;
            _tabIndexedControl.Clear();

            return success;
        }

        private static string IterateControlsForValidation(List<Control> controlCollection, List<ValidationDefinition> validationDefinitions,
    string validationMessage)
        {
            string controlName;
            long validationRequirement;

            foreach (Control control in controlCollection)
            {
                controlName = control.Name;
                foreach (ValidationDefinition validationDefinition in validationDefinitions)
                {
                    //Application.DoEvents();
                    if (!validationDefinition.ControlName.Equals(controlName)) continue;
                    validationRequirement = validationDefinition.ValidationRequirement;
                    validationMessage = ApplyValidation(validationRequirement, control, validationMessage, validationDefinition);
                }

            }
            return validationMessage;
        }




        private static string TraverseControlsForValidation(Control.ControlCollection controlCollection, List<ValidationDefinition> validationDefinitions,
            string validationMessage)
        {
            string controlName;
            long validationRequirement;

            foreach (Control control in controlCollection)
            {
                try
                {
                    if (!control.Enabled) continue;
                    if (((TextBox) control).ReadOnly) continue;
                }
                catch (Exception)
                {
                    //ignored
                }
                controlName = control.Name;
                foreach (ValidationDefinition validationDefinition in validationDefinitions)
                {
                    //Application.DoEvents();
                    if (!validationDefinition.ControlName.Equals(controlName)) continue;
                    validationRequirement = validationDefinition.ValidationRequirement;
                    validationMessage = ApplyValidation(validationRequirement, control, validationMessage, validationDefinition);
                }

                if (control.HasChildren)
                {
                    if (control.Controls.Count > 0)
                    {
                        validationMessage += TraverseControlsForValidation(control.Controls, validationDefinitions,
                            "");
                    }
                }

            }
            return validationMessage;
        }

        private static string ApplyValidation(long validationRequirement, Control control, string validationMessage,
            ValidationDefinition validationDefinition)
        {
            string thisOnesValidation = "";

            if ((!validationDefinition.Mandatory) && (!ValidateNonEmptyText(control.Text)))
                return validationMessage;

            if (CheckValidationRequirement(validationRequirement, ValidationType.BangladeshiCellphoneNumber))
            {
                if (!ValidateBdCellphoneNumber(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Is_not_a_valid_cell_phone_number_);
                }
            }
            if (CheckValidationRequirement(validationRequirement, ValidationType.BangladeshiLandPhoneNumber))
            {
                if (!ValidateBdLandphoneNumber(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Is_not_a_valid_land_phone_number_);
                }
            }
            if (CheckValidationRequirement(validationRequirement, ValidationType.ContainsParticularText))
            {
                if (!ValidateTextContains(control.Text, validationDefinition.FirstParameter.ToString()))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_contain_the_text_ + " " +
                        validationDefinition.FirstParameter);
                }
            }
            if (CheckValidationRequirement(validationRequirement, ValidationType.EmailAddress))
            {
                if (!ValidateEmailAddress(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_be_a_valid_email_address_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.StartsWithParticularText))
            {
                if (!ValidateTextEndsWith(control.Text, validationDefinition.FirstParameter.ToString()))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_start_with_the_text_ + validationDefinition.FirstParameter);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.EndsWithParticularText))
            {
                if (!ValidateTextEndsWith(control.Text, validationDefinition.FirstParameter.ToString()))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_end_with_the_text + " " +
                        validationDefinition.FirstParameter);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.Integral))
            {
                if (!ValidateIntegral(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_be_an_integer_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.NonEmptyText))
            {
                if (!ValidateNonEmptyText(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_not_be_empty_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.AtLeastOneDigitInside))
            {
                if (!ValidateAtLeastOneDigitInside(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_contain_at_least_one_digit_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.AtLeastOneSpecialCharacterInside))
            {
                if (!ValidateAtLeastOneSpecialCharactersInside(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_contain_at_least_one_special_character_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.NonEmptyTextWithoutSpecialCharactersInside))
            {
                if (!ValidateNonEmptyTextWithoutSpecialCharactersInside(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_contain_no_special_characters_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.NonEmptyTextWithoutWhitespaceCharactersInside))
            {
                if (!ValidateNonEmptyTextWithoutSpaceInside(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_not_contain_a_whitespace_character_inside_it_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.NonWhitespaceNonEmptyText))
            {
                if (!ValidateNonEmptyTextWithoutSpace(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_not_be_empty_and_needs_non_whitespace_characters_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.NonZero))
            {
                if (!ValidateNonZero(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Cannot_be_zero_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.Numeric))
            {
                if (!ValidateDecimal(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_be_numeric_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.Positive))
            {
                if (!ValidatePositive(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_be_a_positive_number_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.WithinRange))
            {
                decimal firstParameter, secondParameter;
                var paramA = validationDefinition.FirstParameter;
                if (paramA == null) paramA = decimal.MinValue;
                bool validFirstParameter = decimal.TryParse(paramA.ToString(), out firstParameter);
                var paramB = validationDefinition.SecondParameter;
                if (paramB == null) paramB = decimal.MaxValue;
                bool validSecondParameter = decimal.TryParse(paramB.ToString(), out secondParameter);
                if (!validFirstParameter || !validSecondParameter)
                {
                    throw new Exception("Invalid parameters");
                }
                else
                {
                    if (!ValidateDecimalWithValueRange(control.Text, firstParameter, secondParameter))
                    {
                        object b = paramB;
                        if (b.ToString().Equals(decimal.MaxValue.ToString()))
                        {
                            thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                                StringTable.Should_be_a_number_between + " " + paramA + " and above");
                        }
                        else
                        {
                            thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                                StringTable.Should_be_a_number_between + " " + paramA + " and " + b);
                        }
                    }
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.TextWithLengthRange))
            {
                uint firstParameter, secondParameter;
                var paramA = validationDefinition.FirstParameter;
                if (paramA == null) paramA = uint.MinValue;
                bool validFirstParameter = uint.TryParse(paramA.ToString(), out firstParameter);
                var paramB = validationDefinition.SecondParameter;
                if (paramB == null) paramB = uint.MaxValue;
                bool validSecondParameter = uint.TryParse(paramB.ToString(), out secondParameter);
                if (!validFirstParameter || !validSecondParameter)
                {
                    throw new Exception("Invalid parameters");
                }

                if (!ValidateTextLength(control.Text, firstParameter, secondParameter))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_be_a_text_of_length_between + firstParameter + " and " + secondParameter + " characters.");
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.ListSelected))
            {
                if (!ValidateValueSelected(control))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_have_a_value_selected);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.GridHasRows))
            {
                if (!ValidateGridHasRows(control))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_have_at_least_one_entry_);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.UserName))
            {
                if (!ValidateUsername(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should__contain_proper_user_name_input);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.Password))
            {
                if (!ValidatePassword(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_contain_proper_password_input);
                }
            }

            if (CheckValidationRequirement(validationRequirement, ValidationType.StrongPassword))
            {
                if (!ValidateStrongPassword(control.Text))
                {
                    thisOnesValidation = AppendValidationMessage(thisOnesValidation, validationDefinition,
                        StringTable.Should_be_a_strong_password);
                }
            }

            if (thisOnesValidation.Length > 0)
            {
                _errorIndex++;
                validationMessage = validationMessage + _errorIndex + ". " + thisOnesValidation;

                if (validationDefinition.EffectBackColor) 
                    control.BackColor = InvalidBackColor;

                if (validationDefinition.Mandatory) 
                    control.BackColor = MandatoryFailedBackColor;

                if (control.TabStop)
                {
                    if (_tabIndexedControl.ContainsKey(control.TabIndex))
                    {
                        _tabIndexedControl[control.TabIndex] = control;                        
                    }
                    else
                    {
                        _tabIndexedControl.Add(control.TabIndex, control);
                    }
                }

            }
            else
            {
                control.BackColor = ValidBackColor;
            }

            return validationMessage;
        }


        private static string AppendValidationMessage(string validationMessage, ValidationDefinition validationDefinition, string validationTreatment)
        {

            validationMessage += validationDefinition.ControlDescription + " " + 
                                 validationTreatment;
            if (validationDefinition.Mandatory)
            {
                validationMessage += " " + StringTable.This_field_is_mandatory_;
            }
            validationMessage += "\n";
            return validationMessage;
        }

        private static bool CheckValidationRequirement(long validationRequirement, ValidationType validationCriterion)
        {
            return (validationRequirement & (long)validationCriterion) == (long) validationCriterion;
        }

        public static bool WrongRange(double minimum, double maximum)
        {
            return maximum < minimum;
        }

        public static bool ValidateIntegral(string valueToValidate)
        {
            long integral;
            decimal dec;
            decimal.TryParse(valueToValidate, out dec);
            long.TryParse(valueToValidate, out integral);
            return (integral == dec);
        }

        public static bool ValidateDecimal(string valueToValidate)
        {
            decimal dec;
            return decimal.TryParse(valueToValidate, out dec);
        }

        public static bool ValidateNumericValueRange(double numeric, double minimum = double.NegativeInfinity,
            double maximum = double.PositiveInfinity)
        {
            if (WrongRange(minimum, maximum)) return false;
            return (numeric >= minimum) && (numeric <= maximum);
        }

        public static bool ValidateIntegralWithValueRange(string valueToValidate, long minimum = long.MinValue,
            long maximum = long.MaxValue)
        {
            if (WrongRange(minimum, maximum)) return false;
            bool valid = ValidateIntegral(valueToValidate);
            if (valid)
            {
                valid = ValidateNumericValueRange(Convert.ToDouble(valueToValidate), minimum, maximum);
            }
            return valid;
        }

        public static bool ValidateDecimalWithValueRange(string valueToValidate, decimal minimum = decimal.MinValue,
            decimal maximum = decimal.MaxValue)
        {
            if (WrongRange((double) minimum, (double) maximum)) return false;
            bool valid = ValidateDecimal(valueToValidate);
            if (valid)
            {
                valid = ValidateNumericValueRange(Convert.ToDouble(valueToValidate), (double) minimum, (double) maximum);
            }
            return valid;
        }

        public static bool ValidatePositive(string valueToValidate)
        {
            return ValidateDecimalWithValueRange(valueToValidate, 0);
        }

        public static bool ValidateNonZero(string valueToValidate)
        {
            if (ValidateDecimal(valueToValidate))
            {
                double value = Convert.ToDouble(valueToValidate);
                return (value > 0) || (value < 0);
            }
            return false;
        }

        public static bool ValidateNonEmptyText(string valueToValidate)
        {
            return !string.IsNullOrEmpty(valueToValidate);
        }


        public static bool ValidateNonEmptyTextWithoutSpace(string valueToValidate)
        {
            return !string.IsNullOrWhiteSpace(valueToValidate);
        }

        public static bool ValidateNonEmptyTextWithoutSpaceInside(string valueToValidate)
        {
            return !(string.IsNullOrWhiteSpace(valueToValidate) || valueToValidate.Contains(" ") || valueToValidate.Contains("\t") || valueToValidate.Contains("\r") || valueToValidate.Contains("\n"));
        }

        public static bool ValidateNonEmptyTextWithoutSpecialCharactersInside(string valueToValidate)
        {
            var regexItem = new Regex(SpecialCharacterRegexPattern);
            return (ValidateNonEmptyText(valueToValidate) && regexItem.IsMatch(valueToValidate));
        }

        public static bool ValidateAtLeastOneSpecialCharactersInside(string valueToValidate)
        {
            var regexItem = new Regex(SpecialCharacterRegexPattern);
            return (ValidateNonEmptyText(valueToValidate) && !regexItem.IsMatch(valueToValidate));
        }

        public static bool ValidateAtLeastOneDigitInside(string valueToValidate)
        {
            return (ValidateNonEmptyText(valueToValidate) && Regex.IsMatch(valueToValidate, ContainsDigitPattern));
        }

        public static bool ValidateTextStartsWith(string valueToValidate, string content)
        {
            return valueToValidate.StartsWith(content);
        }

        public static bool ValidateTextEndsWith(string valueToValidate, string content)
        {
            return valueToValidate.EndsWith(content);
        }

        public static bool ValidateTextContains(string valueToValidate, string content)
        {
            return valueToValidate.Contains(content);
        }


        public static bool ValidateTextLength(string valueToValidate, uint minimum = 0, uint maximum = int.MaxValue)
        {
            if (WrongRange(minimum, maximum)) return false;
            int stringLength = valueToValidate.Length;
            return (stringLength >= minimum) && (stringLength <= maximum);
        }

        public static bool ValidatePassword(string valueToValidate)
        {
            return ValidateNonEmptyTextWithoutSpace(valueToValidate);
        }

        public static bool ValidateStrongPassword(string valueToValidate)
        {
            return ValidateAtLeastOneDigitInside(valueToValidate) &&
                ValidateAtLeastOneUppercaseInside(valueToValidate) &&
                ValidateAtLeastOneLowerCaseInside(valueToValidate);
        }

        private static bool ValidateAtLeastOneLowerCaseInside(string valueToValidate)
        {
            return (valueToValidate.ToUpper() != valueToValidate);
        }

        public static bool ValidateAtLeastOneUppercaseInside(string valueToValidate)
        {
            return (valueToValidate.ToLower() != valueToValidate);
        }

        public static bool ValidateUsername(string valueToValidate)
        {
            return ValidateNonEmptyTextWithoutSpace(valueToValidate);
        }

        public static bool ValidateBdCellphoneNumber(string valueToValidate)
        {
            valueToValidate = valueToValidate.Trim();
            valueToValidate = valueToValidate.Replace(" ", "");
            valueToValidate = valueToValidate.Replace("-", "");
            valueToValidate = valueToValidate.Replace("+88", "");

            if (valueToValidate.StartsWith("011") ||
                valueToValidate.StartsWith("015") ||
                valueToValidate.StartsWith("016") ||
                valueToValidate.StartsWith("017") ||
                valueToValidate.StartsWith("018") ||
                valueToValidate.StartsWith("019"))
            {
                if ((valueToValidate.Length == 11) && ValidateIntegralWithValueRange(valueToValidate, 1)) return true;
            }
            return false;
        }

        public static bool ValidateBdLandphoneNumber(string valueToValidate)
        {
            valueToValidate = valueToValidate.Trim();
            valueToValidate = valueToValidate.Replace(" ", "");
            valueToValidate = valueToValidate.Replace("-", "");
            valueToValidate = valueToValidate.Replace("+880", "");

            if (ValidateTextLength(valueToValidate, 4, 11) && ValidateIntegralWithValueRange(valueToValidate, 1)) return true;
            return false;
        }


        public static bool ValidateEmailAddress(string valueToValidate)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(valueToValidate);
                return mailAddress.Address == valueToValidate;
            }
            catch
            {
                return false;
            }
        }


        public static bool ValidateValueSelected(Control control)
        {
            try
            {
                if (control is ListBox)
                {
                    return ((ListBox) control).SelectedIndex > -1;
                }
                if (control is ComboBox)
                {
                    return ((ComboBox) control).SelectedIndex > -1;
                }
            }
            catch
            {
                // ignored
            }
            return false;
        }

        public static bool ValidateGridHasRows(Control control)
        {
            try
            {
                if (control is DataGridView)
                {
                    return ((DataGridView) control).Rows.Count > 0;
                }
                if (control is DataGrid)
                {
                    return ((DataGrid)control).VisibleRowCount > 0;
                }
            }
            catch
            {
                // ignored
            }
            return false;
        }

    }
}