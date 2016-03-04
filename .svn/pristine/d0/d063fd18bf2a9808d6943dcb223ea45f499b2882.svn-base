using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.UI.forms.Dashboard.Pages
{
    public partial class ucDashboardIncome : UserControl
    {
        private Color tmoColor;

        public ucDashboardIncome()
        {
            InitializeComponent();
        }

        private void chartDaily_MouseUp(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    HitTestResult hitTestResult = ((Chart)sender).HitTest(e.X, e.Y);
            //    //label1.Text = hitTestResult.Series.Points[hitTestResult.PointIndex].LegendText;
            //    //hitTestResult.Series.Points[hitTestResult.PointIndex].Color = tmoColor;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].BorderColor = Color.Black;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].BorderWidth = 0;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].LabelForeColor = Color.Black;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].CustomProperties = "Exploded=False";
            //    //hitTestResult.Series.Points[hitTestResult.PointIndex].Color = Color.Black;
            //}
            //catch { }
        }

        private void resetChartSerise(Chart chart)
        {
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                chart.Series[0].Points[i].BorderWidth = 0;
                chart.Series[0].Points[i].CustomProperties = "Exploded=False";
            }
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

            //try
            //{
            //    ToolTip tip = new ToolTip();

            //    HitTestResult hitTestResult = ((Chart)sender).HitTest(e.X, e.Y);
            //    string str = hitTestResult.Series.Points[hitTestResult.PointIndex].LegendText;

            //    tmoColor = hitTestResult.Series.Points[hitTestResult.PointIndex].Color;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].Color = Color.Black;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].LabelForeColor = Color.White;
            //}
            //catch
            //{
            //}
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

            //try
            //{
            //    HitTestResult hitTestResult = ((Chart)sender).HitTest(e.X, e.Y);
            //    //label1.Text = hitTestResult.Series.Points[hitTestResult.PointIndex].LegendText;
            //    tmoColor = hitTestResult.Series.Points[hitTestResult.PointIndex].Color;
            //    //hitTestResult.Series.Points[hitTestResult.PointIndex].Color = Color.Black;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].BorderColor = Color.Black;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].BorderWidth = 1;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].LabelForeColor = Color.White;
            //    hitTestResult.Series.Points[hitTestResult.PointIndex].CustomProperties = "Exploded=True";
            //    //hitTestResult.Series.Points[hitTestResult.PointIndex].Color = Color.Black;
            //}
            //catch { }
        }

        private void ucDashboardIncome_Load(object sender, EventArgs e)
        {
            SetColorofWeekByMonth(SessionInfo.currentDate);
            SetColorofMonth();
            SetYearlyCharLabel();
        }

        private void SetYearlyCharLabel()
        {
            for (int i = 1; i <= chartYearly.Series[0].Points.Count; i++)
            {
                try
                {
                    chartYearly.Series[0].Points[i - 1].AxisLabel = (new DateTime(2015, i, 1)).ToString("MMM");
                }
                catch (Exception)
                {

                }
            }
        }

        public void SetColorofWeekByMonth(DateTime dateTime)
        {
            Color colorDark = Color.FromArgb(0, 128, 255);
            Color colorLight = Color.FromArgb(0, 50, 170);
            bool colorUsed = false;

            for (int i = 0; i < chartMonthly.Series[0].Points.Count; i++)
            {
                try
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, i + 1);
                    if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                    {
                        colorUsed = !colorUsed;
                    }
                    if (colorUsed == false)
                    {
                        chartMonthly.Series[0].Points[i].Color = colorDark;
                    }
                    else
                    {
                        chartMonthly.Series[0].Points[i].Color = colorLight;
                    }
                }
                catch { }
            }
        }

        public void SetColorofMonth()
        {
            Color colorDark = Color.FromArgb(0, 128, 255);
            Color colorLight = Color.FromArgb(0, 50, 170);
            bool colorUsed = false;

            try
            {
                for (int i = 0; i < chartYearly.Series[0].Points.Count; i++)
                {
                    //try
                    //{
                    //    dateTime = new DateTime(dateTime.Year, i + 1, 1);
                    //    if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                    //    {
                    colorUsed = !colorUsed;
                    //}
                    if (colorUsed == false)
                    {
                        chartYearly.Series[0].Points[i].Color = colorDark;
                    }
                    else
                    {
                        chartYearly.Series[0].Points[i].Color = colorLight;
                    }
                }
            }
            catch { }
        }

        private void timerReset_Tick(object sender, EventArgs e)
        {

        }
    }
}