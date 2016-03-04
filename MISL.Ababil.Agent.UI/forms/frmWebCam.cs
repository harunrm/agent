using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmWebCam : Form
    {
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        public frmWebCam()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                start();
            }
            catch (Exception ex)
            {

                // throw;
            }
        }
        private void start()
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {

                deviceListComboBox.Items.Add(VideoCaptureDevice.Name);

            }
            deviceListComboBox.SelectedIndex = 0;

            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[deviceListComboBox.SelectedIndex].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            //FinalVideo.DesiredFrameSize = new Size(200, 200);
            FinalVideo.Start();
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {

                if (FinalVideo.IsRunning)
                {
                    Bitmap varBmp = new Bitmap(pictureBox1.Image);
                    Bitmap newBitmap = new Bitmap(varBmp);
                    pictureBox1.Image = newBitmap;
                    FinalVideo.Stop();
                    btnCapture.Text = "Cancel";
                }
                else
                {
                    FinalVideo.Start();
                    btnCapture.Text = "Capture";
                }
            }
            catch (Exception ex)
            {

            }
        }
        void FinalVideo_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = video;

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (pictureBox1.Image == null) { MessageBox.Show("Please Capture Photo. "); return; }
        }

        public byte[] getPhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void frmWebCam_Load(object sender, EventArgs e)
        {
            try
            {
                start();

            }
            catch (Exception ex)
            {
                Message.showError("Webcam device not found.");
                this.Close();
            }

        }

        private void frmWebCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                FinalVideo.Stop();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
