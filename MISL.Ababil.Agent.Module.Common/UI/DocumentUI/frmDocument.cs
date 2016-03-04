using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
using MISL.Ababil.Agent.Infrastructure.Validation;
using System.Diagnostics;
using System.Drawing.Imaging;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;

namespace MISL.Ababil.Agent.Module.Common.UI.DocumentUI
{
    public partial class frmDocument : Form
    {
        List<DocumentType> docTypeList = new List<DocumentType>();
        List<Document> docList = new List<Document>();
        DocumentInfo docInfo = new DocumentInfo();

        public string retrnMsg = "";
        int docRowIndex;
        long docId = 0;
        bool IsEdit = false;
        byte[] bytes = null;

        //Int32 ownerID = 0;
        public frmDocument()
        {
            InitializeComponent();
            //replaced by SizeMode - Zoom
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            addDeleteButtons(ActionType.update);
            addEditButtons(ActionType.update);

            ConfigureValidation();
        }

        public frmDocument(Int32 docId, ActionType actionType)
        {
            InitializeComponent();
            lblDocName.Visible = false;
            if (actionType == ActionType.view)
            {
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                addDeleteButtons(actionType);
                addEditButtons(actionType);
                addDownloadButtons(docId);
                addViewButtons(docId);

                mtb1.Enabled = false;
                mtb2.Enabled = false;

                if (docId != 0) getDocumentListById(docId);
                changeEnabled(false);

            }
            else
            {
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                addDeleteButtons(actionType);
                addEditButtons(actionType);
                addDownloadButtons(docId);
                addViewButtons(docId);

                if (docId != 0) getDocumentListById(docId);
                changeEnabled(true);
            }

            ConfigureValidation();
        }

        public frmDocument(Int32 docId, ActionType actionType, List<DocumentType> documentTypeList)
        {
            docTypeList = documentTypeList;

            InitializeComponent();
            lblDocName.Visible = false;
            if (actionType == ActionType.view)
            {
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                addDeleteButtons(actionType);
                addEditButtons(actionType);
                addDownloadButtons(docId);

                if (docId != 0) getDocumentListById(docId);
                changeEnabled(false);

            }
            else
            {
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                addDeleteButtons(actionType);
                addEditButtons(actionType);
                addDownloadButtons(docId);

                if (docId != 0) getDocumentListById(docId);
                changeEnabled(true);
            }

            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, cmbDocTypeList, "Document Type", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, txtCode, "ID/Code", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, txtIssuePlace, "Issue Place", (long)ValidationType.NonWhitespaceNonEmptyText, false);
        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }


        private void frmDocument_Load(object sender, EventArgs e)
        {
            //getOwnerDocList(ownerID);
            getSetupData();
            //setControlEnabling();
            setupDateTimePicker();
        }

        private void setupDateTimePicker()
        {
           // dtpIssueDate.MaxDate = SessionInfo.currentDate;
          //  dtpExpireDate.MinDate = new DateTime((SessionInfo.currentDate.AddDays(1)).Year, (SessionInfo.currentDate.AddDays(1)).Month, (SessionInfo.currentDate.AddDays(1)).Day);

            mtb1.Text = dtpIssueDate.Value.ToString("dd-MM-yyyy");
            mtb2.Text = dtpExpireDate.Value.ToString("dd-MM-yyyy");
        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }

        private void setControlEnabling()
        {
            //if (!UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
            //if (SessionInfo.rights.Any(p => p != Rights.DRAFT_CONSUMER_APPLICATION.ToString()))
            //{
            //    DisableControls(this);

            //    EnableControls(btnClose);
            //}

            if (!UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            {
                DisableControls(this);
                EnableControls(btnClose);
                EnableControls(gvDocument);
            }
        }
        private void getSetupData()
        {
            DocumentServices docSeervices = new DocumentServices();
            if (docTypeList == null) docTypeList = docSeervices.getDocumentTypeList();
            else
            {
                if (docTypeList.Count == 0) docTypeList = docSeervices.getDocumentTypeList();
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = docTypeList;
            UtilityServices.fillComboBox(cmbDocTypeList, bs, "name", "id");
        }
        private void getDocumentListById(Int32 docId)
        {

            DocumentServices docServices = new DocumentServices();
            docInfo = docServices.getDocumentListById(docId.ToString());
            if (docInfo != null)
            {
                if (docInfo.documents.Count > 0)
                {
                    gvDocument.DataSource = docInfo.documents.Select(o => new DocumentGrid(o) { documentType = o.documentType.name, documentCode = o.docNumber, issuePlace = o.issuePlace, issueDate = o.issueDate, expireDate = o.expireDate }).ToList();

                }
            }

        }

        private void changeEnabled(bool boolValue)
        {
            cmbDocTypeList.Enabled = boolValue;
            txtCode.Enabled = boolValue;
            txtFilePath.Enabled = boolValue;
            txtIssuePlace.Enabled = boolValue;
            dtpIssueDate.Enabled = boolValue;
            dtpExpireDate.Enabled = boolValue;
            btnAdd.Visible = boolValue;
            btnBrowse.Visible = boolValue;
            btnWebCam.Visible = boolValue;
            btnClear.Visible = boolValue;
            btnSave.Visible = boolValue;
        }

        void ChangeEnabledAll(bool enabled)
        {
            //foreach (Control c in this.Controls)
            //{
            //    c.Enabled = enabled;
            //}          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //btnSave.DialogResult = DialogResult.None;
            if (gvDocument.Rows.Count > 0)
            {
                //btnSave.DialogResult = DialogResult.OK;
                btnSave.Enabled = false;

                if (docInfo.documents != null) docInfo.documents = docInfo.documents;

                DocumentServices DocServices = new DocumentServices();
                try
                {
                    ProgressUIManager.ShowProgress(this);
                    retrnMsg = DocServices.saveDocumentList(docInfo);
                    ProgressUIManager.CloseProgress();

                    if (retrnMsg != "")
                    {
                        MsgBox.showInformation("The document is saved.");
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    ProgressUIManager.CloseProgress();
                    btnSave.Enabled = true;
                    MsgBox.showError(ex.Message);
                }

                btnSave.Enabled = true;
            }
            else
            {
                //btnSave.DialogResult = DialogResult.None;
                MsgBox.showError("There is no document to save");
            }
        }

        public string getDocIdAfterSave()
        {
            return retrnMsg;
        }

        private void clearAllInputData()
        {
            Clear();
            gvDocument.DataSource = null;
        }
        private void addDocumentToList()
        {

            DocumentInfo docInformation = new DocumentInfo();
            Document doc = new Document();

            if (docId != 0) doc.id = docId;
            doc.documentType = UtilityServices.genDocumentType(Convert.ToInt32(cmbDocTypeList.SelectedValue), cmbDocTypeList.Text, null);
            if (lblDocName.Text != "") doc.documentName = lblDocName.Text;
            else doc.documentName = ".jpg";

            doc.docNumber = txtCode.Text.Trim();
            doc.issuePlace = txtIssuePlace.Text.Trim();
            doc.issueDate = Convert.ToDateTime(dtpIssueDate.Text); //UtilityServices.GetLongDate(Convert.ToDateTime(dtpIssueDate.Text));
            doc.expireDate = Convert.ToDateTime(dtpExpireDate.Text); //UtilityServices.GetLongDate(Convert.ToDateTime(dtpExpireDate.Text));           
            if (bytes != null) doc.documentData = bytes;

            if (docInfo == null)
            {
                docInfo = new DocumentInfo();
                docInfo.documents = new List<Document>();
                docInfo.documents.Add(doc);
            }
            else
            {
                if (docInfo.documents == null)
                {
                    docInfo.documents = new List<Document>();
                    docInfo.documents.Add(doc);
                }
                else
                {
                    docInfo.documents.Add(doc);
                }
            }




            //if (docList == null)
            //    docList = new List<Document>();
            //docList.Add(doc);

            //docInformation.documents.Add(doc);
            //docInfo = docInformation;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validationCheck())
            {
                try
                {
                    try
                    {
                        string[] str = mtb1.Text.Split('-');
                        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                        dtpIssueDate.Value = d;
                    }
                    catch
                    {
                        MsgBox.showError("Please enter the Issue Date in correct format.");
                        //mtb1.Focus();
                        //mtb1.SelectAll();
                        return;
                    }

                    try
                    {
                        string[] str = mtb2.Text.Split('-');
                        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                        dtpExpireDate.Value = d;
                    }
                    catch
                    {
                        MsgBox.showError("Please enter the Expire Date in correct format.");
                        //mtb2.Focus();
                        //mtb2.SelectAll();
                        return;
                    }



                    if (txtCode.Text == "")
                    {
                        MsgBox.showError("Input Code not found.");
                        return;
                    }
                    if (bytes == null)
                    {
                        txtFilePath.Text = "";
                        MsgBox.showError("Take a photo or Browse a file.");
                        return;
                    }
                    if (IsEdit == true)
                    {
                        if (docInfo.documents.Count > 0) docInfo.documents.Remove(docInfo.documents[docRowIndex]);
                        IsEdit = false;
                    }

                    addDocumentToList();




                    gvDocument.DataSource = null;
                    gvDocument.DataSource = docInfo.documents.Select(o => new DocumentGrid(o) { documentType = o.documentType.name, documentCode = o.docNumber, issuePlace = o.issuePlace, issueDate = o.issueDate, expireDate = o.expireDate }).ToList();
                    Clear();
                    pictureBox1.Image = null;
                    bytes = null;
                    lblDocName.Text = "";


                }
                catch (Exception ex)
                {

                }
            }

        }
        private void Clear()
        {
            txtFilePath.Text = "";
            txtCode.Text = "";
            txtIssuePlace.Text = "";
            pictureBox1.Image = null;
            setupDateTimePicker();
        }
        void addDeleteButtons(ActionType actionType)
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();

            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.Width = 70;
            btnDelete.DisplayIndex = 0;
            btnDelete.UseColumnTextForButtonValue = true;
            gvDocument.Columns.Add(btnDelete);
            if (actionType == ActionType.view)
            {
                btnDelete.Visible = false;
            }
        }

        void addDownloadButtons(int docId)
        {
            DataGridViewButtonColumn btnDownload = new DataGridViewButtonColumn();
            gvDocument.Columns.Add(btnDownload);
            btnDownload.HeaderText = "";
            btnDownload.Text = "Download";
            btnDownload.Name = "Download";
            btnDownload.Width = 70;
            btnDownload.DisplayIndex = 2;
            btnDownload.UseColumnTextForButtonValue = true;
            if (docId == 0) btnDownload.Visible = false;
            else btnDownload.Visible = true;
        }

        void addViewButtons(int docId)
        {
            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            gvDocument.Columns.Add(btnView);
            btnView.HeaderText = "";
            btnView.Text = "View";
            btnView.Name = "View";
            btnView.Width = 70;
            btnView.DisplayIndex = 3;
            btnView.UseColumnTextForButtonValue = true;
            if (docId == 0) btnView.Visible = false;
            else btnView.Visible = true;
        }

        void addEditButtons(ActionType actionType)
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            gvDocument.Columns.Add(btnEdit);
            btnEdit.HeaderText = "";
            btnEdit.Text = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.Width = 50;
            btnEdit.DisplayIndex = 1;
            btnEdit.UseColumnTextForButtonValue = true;
            if (actionType == ActionType.view)
            {
                btnEdit.Visible = false;
            }
        }

        private void setIndividualDocInfoToUpdate(Document Doc)
        {
            List<Document> individualDocList = new List<Document>();
            individualDocList.Add(Doc);
            gvDocument.DataSource = individualDocList;
        }

        private void gvDocument_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DocumentServices docServices = new DocumentServices();
            if (docInfo.documents != null)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 3)
                    {
                        Document docData = new Document();
                        try
                        {
                            docData = docServices.getDocumentFile(docInfo.documents[e.RowIndex].id.ToString());
                        }
                        catch (Exception ex)
                        {
                            MsgBox.showError(ex.Message);
                        }

                        if (docData.documentData != null)
                        {
                            bytes = docData.documentData;

                            if (docInfo.documents[e.RowIndex].documentName.ToLower() == ".png" || docInfo.documents[e.RowIndex].documentName.ToLower() == ".jpg")
                            {
                                try
                                {
                                    txtCode.Text = docInfo.documents[e.RowIndex].docNumber;
                                    lblDocName.Text = docInfo.documents[e.RowIndex].documentName;
                                    txtIssuePlace.Text = docInfo.documents[e.RowIndex].issuePlace;
                                    dtpExpireDate.Text = docInfo.documents[e.RowIndex].expireDate.ToString();
                                    dtpIssueDate.Text = docInfo.documents[e.RowIndex].issueDate.ToString();

                                    pictureBox1.Image = null;
                                    ImageConverter converter = new ImageConverter();
                                    pictureBox1.Image = (Image)converter.ConvertFrom(docData.documentData);

                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            //for PDF, open in system default PDF Reader.
                            if (docInfo.documents[e.RowIndex].documentName.ToLower() == ".pdf")
                            {
                                try
                                {
                                    pictureBox1.Image = null;
                                    //ImageConverter converter = new ImageConverter();
                                    //pictureBox1.Image = (Image)converter.ConvertFrom(docData.documentData);
                                    //docData.documentData
                                    string tempFileName = Application.LocalUserAppDataPath + "\\" +
                                                          DateTime.Now.Day.ToString() +
                                                          DateTime.Now.Minute.ToString() +
                                                          DateTime.Now.Millisecond.ToString() + ".pdf";
                                    if (!File.Exists(tempFileName))
                                    {
                                        try
                                        {
                                            FileStream fs = new FileStream(tempFileName, FileMode.CreateNew);

                                            fs.Write(docData.documentData, 0, docData.documentData.Length);
                                            fs.Close();
                                            ProcessStartInfo pros = new ProcessStartInfo();
                                            //Clipboard.SetText(tempFileName);
                                            pros.FileName = tempFileName;
                                            Process p = Process.Start(pros);
                                            p.WaitForExit();
                                            File.Delete(tempFileName);

                                        }
                                        catch (Exception ex)
                                        {
                                            //MsgBox.showError(ex.Message);
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }
                    }
                    if (e.ColumnIndex == 0)
                    {
                        string result = MsgBox.showConfirmation("Are you sure to delete document?");

                        if (result == "yes")
                        {
                            try
                            {
                                if (docInfo.documents[e.RowIndex].id != 0) docServices.deleteDocumentById(docInfo.documents[e.RowIndex].id.ToString());
                                docInfo.documents.Remove(docInfo.documents[e.RowIndex]);
                            }
                            catch (Exception ex)
                            {
                                MsgBox.showError(ex.Message);
                            }

                            //docServices.getDocumentFile(docInfo.documents[e.RowIndex].id.ToString());

                            gvDocument.DataSource = docInfo.documents.Select(o => new DocumentGrid(o) { documentType = o.documentType.name, documentCode = o.docNumber, issuePlace = o.issuePlace, issueDate = o.issueDate, expireDate = o.expireDate }).ToList();
                        }
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        pictureBox1.Image = null;
                        if (docInfo.documents[e.RowIndex].id != 0) docId = docInfo.documents[e.RowIndex].id;
                        cmbDocTypeList.SelectedValue = docInfo.documents[e.RowIndex].documentType.id;
                        txtCode.Text = docInfo.documents[e.RowIndex].docNumber;
                        lblDocName.Text = docInfo.documents[e.RowIndex].documentName;
                        txtIssuePlace.Text = docInfo.documents[e.RowIndex].issuePlace;
                        dtpExpireDate.Text = docInfo.documents[e.RowIndex].expireDate.ToString();
                        dtpIssueDate.Text = docInfo.documents[e.RowIndex].issueDate.ToString();

                        if (docInfo.documents[e.RowIndex].documentData != null)
                        {
                            if (docInfo.documents[e.RowIndex].documentName.ToLower() == ".png" || docInfo.documents[e.RowIndex].documentName.ToLower() == ".jpg")
                            {
                                bytes = docInfo.documents[e.RowIndex].documentData;
                                ImageConverter converter = new ImageConverter();
                                pictureBox1.Image = (Image)converter.ConvertFrom(bytes);
                            }

                        }
                        else
                        {
                            if (docInfo.documents[e.RowIndex].id != 0)
                            {

                                Document docData = new Document();
                                try
                                {
                                    docData = docServices.getDocumentFile(docInfo.documents[e.RowIndex].id.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MsgBox.showError(ex.Message);
                                }

                                if (docData.documentData != null)
                                {
                                    bytes = docData.documentData;

                                    if (docInfo.documents[e.RowIndex].documentName.ToLower() == ".png" || docInfo.documents[e.RowIndex].documentName.ToLower() == ".jpg")
                                    {
                                        try
                                        {
                                            pictureBox1.Image = null;
                                            ImageConverter converter = new ImageConverter();
                                            pictureBox1.Image = (Image)converter.ConvertFrom(docData.documentData);

                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }



                            }


                        }

                        docRowIndex = e.RowIndex;
                        IsEdit = true;



                    }
                    else if (e.ColumnIndex == 2)
                    {
                        if (docInfo.documents[e.RowIndex].id != 0)
                        {

                            Document docData = new Document();
                            docData = docServices.getDocumentFile(docInfo.documents[e.RowIndex].id.ToString());

                            if (docInfo.documents[e.RowIndex].documentName.ToLower() == ".png" || docInfo.documents[e.RowIndex].documentName.ToLower() == ".jpg")
                            {
                                try
                                {
                                    if (docData.documentData != null)
                                    {
                                        pictureBox1.Image = null;

                                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                                        saveFileDialog.Title = "Image";
                                        //saveFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
                                        //saveFileDialog.FileName = docInfo.documents[e.RowIndex].documentName.ToLower();

                                        saveFileDialog.ShowDialog();



                                        if (saveFileDialog.FileName != "")
                                        {

                                            File.WriteAllBytes(saveFileDialog.FileName + docInfo.documents[e.RowIndex].documentName.ToLower(), docData.documentData);
                                            MessageBox.Show("File downloaded successfully");
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }

                            }
                            else if (docInfo.documents[e.RowIndex].documentName.ToLower() == ".pdf")
                            {
                                try
                                {
                                    if (docData.documentData != null)
                                    {
                                        pictureBox1.Image = null;

                                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                                        saveFileDialog.Title = "Document";
                                        saveFileDialog.ShowDialog();

                                        if (saveFileDialog.FileName != "")
                                        {

                                            File.WriteAllBytes(saveFileDialog.FileName + ".pdf", docData.documentData);
                                            MessageBox.Show("File downloaded successfully");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                }


                            }
                        }
                    }
                }
            }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                txtFilePath.Text = "";
                //MsgBox.showInformation("Upload only JPG, PNG & PDF file.");

                bytes = null;
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Open Image";
                //dlg.Filter = "All files (*.*)|*.*";
                dlg.Filter = "Image or pdf Files(*.jpg; *.jpeg; *.png; *.pdf;)|*.jpg; *.jpeg; *.png; *.pdf;";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = dlg.FileName;
                    string extn = Path.GetExtension(dlg.FileName).ToLower();
                    lblDocName.Text = extn;
                    if (extn == ".pdf")
                    {
                        bytes = System.IO.File.ReadAllBytes(dlg.FileName);

                        #region File size Calculation
                        FileStream fs = new FileStream(dlg.FileName, FileMode.Open);
                        BinaryReader br = new BinaryReader(fs);
                        if (br.BaseStream.Length > CommonRules.pdfSizeLimit)
                        {
                            MessageBox.Show("File size should not more than " + CommonRules.pdfSizeLimit / 1000 + " KB.");
                            return;
                        }
                        #endregion
                    }
                    else if (extn == ".jpg" || extn == ".jpeg" || extn == ".png")
                    {
                        Bitmap imgbitmap = new Bitmap(dlg.FileName);
                        Image img = new Bitmap(dlg.FileName);
                        img = UtilityServices.getResizedImage(imgbitmap, CommonRules.imageSizeLimit, 100, "");
                        #region Image file length check
                        MemoryStream ms = new MemoryStream();
                        //img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        {
                            ImageCodecInfo jpgCodec = ImageCodecInfo.GetImageEncoders().Where(codec => codec.FormatID.Equals(ImageFormat.Jpeg.Guid)).FirstOrDefault();
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            //MessageBox.Show(ms.Length.ToString());
                            ms = new MemoryStream();

                            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                            System.Drawing.Imaging.Encoder myEncoder2 = System.Drawing.Imaging.Encoder.ColorDepth;
                            System.Drawing.Imaging.Encoder myEncoder3 = System.Drawing.Imaging.Encoder.Compression;

                            EncoderParameters myEncoderParameters = new EncoderParameters(2);

                            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                            EncoderParameter myEncoderParameter2 = new EncoderParameter(myEncoder2, 16L);
                            EncoderParameter myEncoderParameter3 = new EncoderParameter(myEncoder3, (long)EncoderValue.CompressionLZW);

                            myEncoderParameters.Param[0] = myEncoderParameter;
                            myEncoderParameters.Param[1] = myEncoderParameter2;
                            myEncoderParameters.Param[1] = myEncoderParameter3;

                            img.Save(ms, jpgCodec, myEncoderParameters);
                            //MessageBox.Show(ms.Length.ToString());
                        }
                        if (ms.Length > 100000) { MessageBox.Show("Image file should be in " + CommonRules.imageSizeLimit / 1024 + " KB"); return; }
                        #endregion

                        pictureBox1.Image = img;

                        bytes = imageToByteArray(pictureBox1.Image);
                    }
                }
                dlg.Dispose();
            }
            catch (Exception ex)
            { }
        }
        private void btnWebCam_Click(object sender, EventArgs e)
        {
            //////try
            //////{
            //////    frmWebCam webCam = new frmWebCam();
            //////    DialogResult dr = webCam.ShowDialog();

            //////    if (dr == DialogResult.OK)
            //////    {
            //////        ImageConverter converter = new ImageConverter();
            //////        Bitmap imgbitmap = (Bitmap)converter.ConvertFrom(webCam.getPhoto());
            //////        Image img = (Image)converter.ConvertFrom(webCam.getPhoto());
            //////        img = UtilityServices.getResizedImage(imgbitmap, CommonRules.imageSizeLimit, 100, "");
            //////        #region Image file length check
            //////        MemoryStream ms = new MemoryStream();
            //////        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //////        if (ms.Length > CommonRules.imageSizeLimit)
            //////        {
            //////            MessageBox.Show("Image file should be in " + CommonRules.imageSizeLimit / 1024 + " KB");
            //////            return;
            //////        }
            //////        #endregion
            //////        if (img != null)
            //////        {
            //////            pictureBox1.Image = img;
            //////            bytes = imageToByteArray(img);
            //////        }
            //////        else MessageBox.Show("Photo not taken.");
            //////    }
            //////}
            //////catch (Exception ex)
            //////{
            //////    MessageBox.Show("Photo not taken.");
            //////}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            //this.Enabled = false;

            string result = MsgBox.showConfirmation("Are you sure to clear?");

            if (result == "yes")
            {
                Clear();
            }

            this.Enabled = true;
            this.UseWaitCursor = false;
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            ImageCodecInfo jpgCodec = ImageCodecInfo.GetImageEncoders().Where(codec => codec.FormatID.Equals(ImageFormat.Jpeg.Guid)).FirstOrDefault();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //MessageBox.Show(ms.Length.ToString());
            ms = new MemoryStream();

            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            System.Drawing.Imaging.Encoder myEncoder2 = System.Drawing.Imaging.Encoder.ColorDepth;
            System.Drawing.Imaging.Encoder myEncoder3 = System.Drawing.Imaging.Encoder.Compression;

            EncoderParameters myEncoderParameters = new EncoderParameters(2);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            EncoderParameter myEncoderParameter2 = new EncoderParameter(myEncoder2, 16L);
            EncoderParameter myEncoderParameter3 = new EncoderParameter(myEncoder3, (long)EncoderValue.CompressionLZW);

            myEncoderParameters.Param[0] = myEncoderParameter;
            myEncoderParameters.Param[1] = myEncoderParameter2;
            myEncoderParameters.Param[1] = myEncoderParameter3;

            imageIn.Save(ms, jpgCodec, myEncoderParameters);
            //MessageBox.Show(ms.Length.ToString());
            return ms.ToArray();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

        private void dtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            mtb1.Text = dtpIssueDate.Value.ToString("dd-MM-yyyy");
        }

        private void dtpExpireDate_ValueChanged(object sender, EventArgs e)
        {
            mtb2.Text = dtpExpireDate.Value.ToString("dd-MM-yyyy");
        }

        private void mtb1_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtb1.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpIssueDate.Value = d;
            }
            catch (Exception ex) { }
        }

        private void mtb2_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                //this.Text = mtb1.Text + "_" + mtb1.Text.Length.ToString();
                string[] str = mtb2.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpExpireDate.Value = d;
            }
            catch (Exception ex)
            {

            }
        }

        private void mtb1_Leave(object sender, EventArgs e)
        {

        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                frmDocumentZoom frm = new frmDocumentZoom();
                frm.pictureZoomBox.Image = pictureBox1.Image;
                frm.ShowDialog();
            }
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            if (gvDocument.Rows.Count > 0)
            {
                btnSave.DialogResult = DialogResult.OK;
            }
            else
            {
                btnSave.DialogResult = DialogResult.None;
            }
        }
    }


    public class DocumentGrid
    {
        public string documentType { get; set; }
        public string documentCode { get; set; }
        public string issuePlace { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expireDate { get; set; }





        private Document _obj;

        public DocumentGrid(Document obj)
        {
            _obj = obj;
        }

        public Document GetModel()
        {
            return _obj;
        }
    }
}
