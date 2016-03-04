using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MISL.Ababil.Agent.UI.forms.Dashboard.Pages
{
    public partial class ucOutletDetail : UserControl
    {
        Color tmoColor;

        public ucOutletDetail()
        {
            InitializeComponent();
        }

        private void chartDaily_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                HitTestResult hitTestResult = ((Chart)sender).HitTest(e.X, e.Y);

                if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    ((Chart)sender).Cursor = Cursors.Hand;
                    //label1.Text = hitTestResult.Series.Points[hitTestResult.PointIndex].LegendText;
                    tmoColor = hitTestResult.Series.Points[hitTestResult.PointIndex].Color;
                    //hitTestResult.Series.Points[hitTestResult.PointIndex].Color = Color.Black;
                    hitTestResult.Series.Points[hitTestResult.PointIndex].BorderColor = Color.Black;
                    hitTestResult.Series.Points[hitTestResult.PointIndex].BorderWidth = 1;
                    hitTestResult.Series.Points[hitTestResult.PointIndex].LabelForeColor = Color.White;
                    hitTestResult.Series.Points[hitTestResult.PointIndex].CustomProperties = "Exploded=True";
                    //hitTestResult.Series.Points[hitTestResult.PointIndex].Color = Color.Black;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    ((Chart)sender).Cursor = Cursors.Default;
                    resetChartSerise((Chart)sender);
                }
            }
            catch
            {
                //((Chart)sender).Cursor = Cursors.Default;
                //resetChartSerise((Chart)sender);
            }
        }

        private void chartDaily_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                HitTestResult hitTestResult = ((Chart)sender).HitTest(e.X, e.Y);

                if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    ((Chart)sender).Cursor = Cursors.Hand;
                    //label1.Text = hitTestResult.Series.Points[hitTestResult.PointIndex].LegendText;
                    string str = hitTestResult.Series.Points[hitTestResult.PointIndex].LegendText;
                    Dashboard.frmDashboardDetail frm = new frmDashboardDetail();
                    frm.Text = "Details - " + str;
                    frm.ShowDialog();
                    //MessageBox.Show(str);                                     
                }
            }
            catch
            {
                //((Chart)sender).Cursor = Cursors.Default;
                //resetChartSerise((Chart)sender);
            }
        }

        private void resetChartSerise(Chart chart)
        {
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                chart.Series[0].Points[i].BorderWidth = 0;
                chart.Series[0].Points[i].CustomProperties = "Exploded=False";
            }
        }
    }
}
