using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.ProgressUI
{
    public static class ProgressUIManager
    {
        private static frmProgress frmPro;
        private static Form OwnerForm;

        public static void ShowProgress(Form ownerForm)
        {
            OwnerForm = ownerForm;

            frmPro = new frmProgress();
            //frmPro.BackColor = ownerForm.BackColor;
            //frmPro.BackgroundImage = ownerForm.BackgroundImage;
            //frmPro.BackgroundImageLayout = ownerForm.BackgroundImageLayout;

            OwnerForm.UseWaitCursor = true;
            frmPro.UseWaitCursor = true;
            frmPro.TopMost = true;
            frmPro.Show();
            Application.DoEvents();
            OwnerForm.Update();
            OwnerForm.Refresh();
        }

        public static void CloseProgress()
        {
            try
            {
                frmPro.Close();
                OwnerForm.Update();
                OwnerForm.Refresh();
                OwnerForm.UseWaitCursor = false;
                OwnerForm.Focus();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
