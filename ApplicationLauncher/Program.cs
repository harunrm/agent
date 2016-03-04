using System;
using System.Windows.Forms;
using MISL.Ababil.Agent.UI.forms;

namespace ApplicationLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool exitRequired;
            frmUpdater frmUpdater = new frmUpdater();

            bool updating = frmUpdater.InitiateUpdate(out exitRequired);

            if (exitRequired)
            {
                Application.Exit();
                return;
            }

            if (updating)
            {
                while (!frmUpdater.OkToExit) Application.DoEvents();
                Application.Exit();
                return;
            }

            frmLogin frm = new frmLogin();
            Application.Run(frm);
        }
    }
}