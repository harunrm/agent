using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MetroFramework.Forms;

namespace MISL.Ababil.Agent.Module.Common.UI.FingerprintUI
{
    public partial class frmFingerprintCapture : MetroForm
    {

        private const string leftHand = "Left";
        private const string rightHand = "Right";

        private const string pinkyFinger = "Pinky";
        private const string ringFinger = "Ring";
        private const string middleFinger = "Middle";
        private const string indexFinger = "Index";
        private const string thumbFinger = "Thumb";

        String fingerData;

        String leftPinkyFingerData = "";
        String leftRingFingerData = "";
        String leftMiddleFingerData = "";
        String leftIndexFingerData = "";
        String leftThumbFingerData = "";

        String rightPinkyFingerData = "";
        String rightRingFingerData = "";
        String rightMiddleFingerData = "";
        String rightIndexFingerData = "";
        String rightThumbFingerData = "";

        String currentFinger;

        public List<BiometricTemplate> bioMetricTemplates = new List<BiometricTemplate>();


        public frmFingerprintCapture(string username)
        {
            InitializeComponent();
            bio.OnCapture += new EventHandler(bio_OnCapture);
            lbl_fingerPirntFor.Text = "Fingerprint For: " + username;
        }

        //left general//

        private void l_pinky_Click(object sender, EventArgs e)
        {
            currentFinger = "l_pinky";
            bio.CaptureRegisterSingleFingerData();
        }

        private void l_ring_Click(object sender, EventArgs e)
        {

            currentFinger = "l_ring";
            bio.CaptureRegisterSingleFingerData();

        }

        private void l_middle_Click(object sender, EventArgs e)
        {
            currentFinger = "l_middle";
            bio.CaptureRegisterSingleFingerData();
        }

        private void l_index_Click(object sender, EventArgs e)
        {
            currentFinger = "l_index";
            bio.CaptureRegisterSingleFingerData();
        }

        private void l_thumb_Click(object sender, EventArgs e)
        {
            currentFinger = "l_thumb";
            bio.CaptureRegisterSingleFingerData();
        }

        //end left general//


        // left del//

        private void l_pinky_del_Click(object sender, EventArgs e)
        {
            this.l_pinky.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_pinky;
            l_pinky_del.Visible = false;
            l_pinky_fp.Image = null;
            leftPinkyFingerData = "";
        }


        private void l_ring_del_Click(object sender, EventArgs e)
        {
            this.l_ring.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_ring;
            l_ring_del.Visible = false;
            l_ring_fp.Image = null;
            leftRingFingerData = "";
        }

        private void l_middle_del_Click(object sender, EventArgs e)
        {
            this.l_middle.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_middle;
            l_middle_del.Visible = false;
            l_middle_fp.Image = null;
            leftMiddleFingerData = "";
        }

        private void l_index_del_Click(object sender, EventArgs e)
        {
            this.l_index.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_index;
            l_index_del.Visible = false;
            l_index_fp.Image = null;
            leftIndexFingerData = "";
        }

        private void l_thumb_del_Click(object sender, EventArgs e)
        {
            this.l_thumb.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_thumb;
            l_thumb_del.Visible = false;
            l_thumb_fp.Image = null;
            leftThumbFingerData = "";
        }

        // end left del//


        //right general//

        private void r_thumb_Click(object sender, EventArgs e)
        {
            currentFinger = "r_thumb";
            bio.CaptureRegisterSingleFingerData();
        }

        private void r_index_Click(object sender, EventArgs e)
        {

            currentFinger = "r_index";
            bio.CaptureRegisterSingleFingerData();
        }

        private void r_middle_Click(object sender, EventArgs e)
        {
            currentFinger = "r_middle";
            bio.CaptureRegisterSingleFingerData();
        }

        private void r_ring_Click(object sender, EventArgs e)
        {
            currentFinger = "r_ring";
            bio.CaptureRegisterSingleFingerData();
        }

        private void r_pinky_Click(object sender, EventArgs e)
        {
            currentFinger = "r_pinky";
            bio.CaptureRegisterSingleFingerData();
        }

        //end right general//

        //right del//


        private void r_thumb_del_Click(object sender, EventArgs e)
        {
            this.r_thumb.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_thumb;
            r_thumb_del.Visible = false;
            r_thumb_fp.Image = null;
            rightThumbFingerData = "";
        }

        private void r_index_del_Click(object sender, EventArgs e)
        {
            this.r_index.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_index;
            r_index_del.Visible = false;
            r_index_fp.Image = null;
            rightIndexFingerData = "";
        }

        private void r_middle_del_Click(object sender, EventArgs e)
        {
            this.r_middle.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_middle;
            r_middle_del.Visible = false;
            r_middle_fp.Image = null;
            rightMiddleFingerData = "";
        }

        private void r_ring_del_Click(object sender, EventArgs e)
        {
            this.r_ring.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_ring;
            r_ring_del.Visible = false;
            r_ring_fp.Image = null;
            rightRingFingerData = "";
        }

        private void r_pinky_del_Click(object sender, EventArgs e)
        {
            this.r_pinky.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_pinky;
            r_pinky_del.Visible = false;
            r_pinky_fp.Image = null;
            rightPinkyFingerData = "";
        }


        //end right del//



        private Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }

        private void bio_OnCapture(object sender, EventArgs e)
        {


            AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            if (x.result == "0")
            {
                //string template1 = bio.GetSafeLeftFingerData();
                //string template2 = bio.GetSafeLeftCaptureTemplate();
                String safeFingerData = bio.GetSafeLeftFingerData();
                fingerData = bio.GetFingerprintImageData();
                byte[] bytes = Convert.FromBase64String(fingerData);
                Image image;
                image = byteArrayToImage(bytes);
                image = ScaleImage(image, 70, 70);


                switch (currentFinger)
                {
                    case "l_pinky":
                        this.l_pinky.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_pinky_c;
                        l_pinky_del.Visible = true;
                        l_pinky_fp.Image = image;
                        leftPinkyFingerData = safeFingerData;
                        break;
                    case "l_ring":
                        this.l_ring.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_ring_c;
                        l_ring_del.Visible = true;
                        l_ring_fp.Image = image;
                        leftRingFingerData = safeFingerData;
                        break;
                    case "l_middle":
                        this.l_middle.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_middle_c;
                        l_middle_del.Visible = true;
                        l_middle_fp.Image = image;
                        leftMiddleFingerData = safeFingerData;
                        break;

                    case "l_index":
                        this.l_index.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_index_c;
                        l_index_del.Visible = true;
                        l_index_fp.Image = image;
                        leftIndexFingerData = safeFingerData;
                        break;
                    case "l_thumb":
                        this.l_thumb.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.left_thumb_c;
                        l_thumb_del.Visible = true;
                        l_thumb_fp.Image = image;
                        leftThumbFingerData = safeFingerData;
                        break;

                    case "r_pinky":
                        this.r_pinky.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_pinky_c;
                        r_pinky_del.Visible = true;
                        r_pinky_fp.Image = image;
                        rightPinkyFingerData = safeFingerData;
                        break;
                    case "r_ring":
                        this.r_ring.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_ring_c;
                        r_ring_del.Visible = true;
                        r_ring_fp.Image = image;
                        rightRingFingerData = safeFingerData;
                        break;
                    case "r_middle":
                        this.r_middle.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_middle_c;
                        r_middle_del.Visible = true;
                        r_middle_fp.Image = image;
                        rightMiddleFingerData = safeFingerData;
                        break;

                    case "r_index":
                        this.r_index.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_index_c;
                        r_index_del.Visible = true;
                        r_index_fp.Image = image;
                        rightIndexFingerData = safeFingerData;
                        break;
                    case "r_thumb":
                        this.r_thumb.Image = global::MISL.Ababil.Agent.Module.Common.Properties.Resources.right_thumb_c;
                        r_thumb_del.Visible = true;
                        r_thumb_fp.Image = image;
                        rightThumbFingerData = safeFingerData;
                        break;

                }


            }


        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDone_Click(object sender, EventArgs e)
        {

            //List<BiometricTemplate> bioMetricTemplates=new List<BiometricTemplate>();


            if (leftPinkyFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = leftHand;
                bioMetricTemplate.finger = pinkyFinger;
                bioMetricTemplate.bioData = leftPinkyFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }
            if (leftRingFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = leftHand;
                bioMetricTemplate.finger = ringFinger;
                bioMetricTemplate.bioData = leftRingFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }
            if (leftMiddleFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = leftHand;
                bioMetricTemplate.finger = middleFinger;
                bioMetricTemplate.bioData = leftMiddleFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }

            if (leftIndexFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = leftHand;
                bioMetricTemplate.finger = indexFinger;
                bioMetricTemplate.bioData = leftIndexFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }
            if (leftThumbFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = leftHand;
                bioMetricTemplate.finger = thumbFinger;
                bioMetricTemplate.bioData = leftThumbFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }
            if (rightPinkyFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = rightHand;
                bioMetricTemplate.finger = pinkyFinger;
                bioMetricTemplate.bioData = rightPinkyFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }
            if (rightRingFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = rightHand;
                bioMetricTemplate.finger = ringFinger;
                bioMetricTemplate.bioData = rightRingFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }
            if (rightMiddleFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = rightHand;
                bioMetricTemplate.finger = middleFinger;
                bioMetricTemplate.bioData = rightMiddleFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }

            if (rightIndexFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = rightHand;
                bioMetricTemplate.finger = indexFinger;
                bioMetricTemplate.bioData = rightIndexFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }
            if (rightThumbFingerData != "")
            {
                BiometricTemplate bioMetricTemplate = new BiometricTemplate();
                bioMetricTemplate.hand = rightHand;
                bioMetricTemplate.finger = thumbFinger;
                bioMetricTemplate.bioData = rightThumbFingerData;
                bioMetricTemplates.Add(bioMetricTemplate);
            }



            Console.WriteLine("helo");
            this.Close();

        }

        private void frmFingerprintCapture_Load(object sender, EventArgs e)
        {

        }
    }
}
