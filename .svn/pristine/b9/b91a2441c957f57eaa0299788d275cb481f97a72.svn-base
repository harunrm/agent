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
using MISL.Ababil.Agent.Communication;


namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmDocuments : Form
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
        public frmDocuments()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            addDeleteButtons();
            addEditButtons();

        }
        public frmDocuments(Int32 docId, ActionType actionType)
        {
            InitializeComponent();
            lblDocName.Visible = false;
            if (actionType == ActionType.view)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                addDeleteButtons();
                addEditButtons();
                addDownloadButtons(docId);

                if (docId != 0) getDocumentListById(docId);
                changeEnabled(false);

            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                addDeleteButtons();
                addEditButtons();
                addDownloadButtons(docId);

                if (docId != 0) getDocumentListById(docId);

            }
        }
        private void frmDocument_Load(object sender, EventArgs e)
        {
            
            //getOwnerDocList(ownerID);
            getSetupData();

        }

        private void getSetupData()
        {
            DocumentServices docSeervices = new DocumentServices();
            docTypeList = docSeervices.getDocumentTypeList();

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
                    gvDocument.DataSource = docInfo.documents.Select(o => new DocumentsGrid(o) { docNumber = o.docNumber, issuePlace = o.issuePlace, issueDate = o.issueDate, expireDate = o.expireDate }).ToList();

                }
            }

        }
        private void changeEnabled(bool boolValue)
        {
            txtCode.Enabled = boolValue;
            txtFilePath.Enabled = boolValue;
            txtIssuePlace.Enabled = boolValue;
            btnAdd.Enabled = boolValue;
            btnBrowse.Enabled = boolValue;
            btnClear.Enabled = boolValue;
            btnSave.Enabled = boolValue;


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
            //if (docInfo.documents != null) docInfo.documents = docInfo.documents;

            //DocumentServices DocServices = new DocumentServices();
            //retrnMsg = DocServices.saveDocumentList(docInfo);

            //MessageBox.Show(retrnMsg);
            //if (retrnMsg != null) clearAllInputData();  

            //this.Close();
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
            doc.documentType = UtilityServices.genDocumentType(Convert.ToInt32(cmbDocTypeList.SelectedValue), cmbDocTypeList.SelectedText, null);
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


            if (docInfo.documents != null) docInfo.documents = docInfo.documents;

            DocumentServices DocServices = new DocumentServices();
            retrnMsg = DocServices.saveDocumentList(docInfo);

            //if (docList == null)
            //    docList = new List<Document>();
            //docList.Add(doc);

            //docInformation.documents.Add(doc);
            //docInfo = docInformation;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == "") { MessageBox.Show("Input Code."); return; }
                if (bytes == null) { txtFilePath.Text = ""; MessageBox.Show("Take a photo or Browse a file."); return; }
                if (IsEdit == true)
                {
                    if (docInfo.documents.Count > 0) docInfo.documents.Remove(docInfo.documents[docRowIndex]); IsEdit = false;
                }

                addDocumentToList();




                gvDocument.DataSource = null;
                gvDocument.DataSource = docInfo.documents.Select(o => new DocumentsGrid(o) { docNumber = o.docNumber, issuePlace = o.issuePlace, issueDate = o.issueDate, expireDate = o.expireDate }).ToList();
                Clear();
                pictureBox1.Image = null;
                bytes = null;
                lblDocName.Text = "";


            }
            catch (Exception ex)
            {

            }


        }
        private void Clear()
        {
            txtFilePath.Text = "";
            txtCode.Text = "";
            txtIssuePlace.Text = "";
            pictureBox1.Image = null;

        }
        void addDeleteButtons()
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            gvDocument.Columns.Add(btnDelete);
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.Width = 70;
            btnDelete.DisplayIndex = 0;
            btnDelete.UseColumnTextForButtonValue = true;
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
        void addEditButtons()
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            gvDocument.Columns.Add(btnEdit);
            btnEdit.HeaderText = "";
            btnEdit.Text = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.Width = 50;
            btnEdit.DisplayIndex = 1;
            btnEdit.UseColumnTextForButtonValue = true;

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
                    if (e.ColumnIndex == 0)
                    {
                        if (docInfo.documents[e.RowIndex].id != 0) docServices.deleteDocumentById(docInfo.documents[e.RowIndex].id.ToString());
                        //docInfo.documents.Remove(docInfo.documents[e.RowIndex]);
                        DocumentCom documentCom = new DocumentCom();
                        documentCom.deleteDocumentById(docInfo.documents[e.RowIndex].id.ToString());
                        //docServices.getDocumentFile(docInfo.documents[e.RowIndex].id.ToString());

                        gvDocument.DataSource = docInfo.documents.Select(o => new DocumentsGrid(o) { docNumber = o.docNumber, issuePlace = o.issuePlace, issueDate = o.issueDate, expireDate = o.expireDate }).ToList();
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
                                docData = docServices.getDocumentFile(docInfo.documents[e.RowIndex].id.ToString());
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
                Message.showInformation("Upload only JPG, PNG & PDF file.");

                bytes = null;
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Open Image";
                dlg.Filter = "All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = dlg.FileName;
                    string extn = Path.GetExtension(dlg.FileName).ToLower();
                    lblDocName.Text = extn;
                    if (extn == ".pdf")
                    {
                        bytes = System.IO.File.ReadAllBytes(dlg.FileName);

                        #region File size Calculation for '2048000 byte or 2MB'

                        FileStream fs = new FileStream(dlg.FileName, FileMode.Open);
                        BinaryReader br = new BinaryReader(fs);
                        if (br.BaseStream.Length > 100000) { MessageBox.Show("File size should not more than 100 KB."); return; }

                        #endregion



                    }
                    else if (extn == ".jpg" || extn == ".png")
                    {
                        #region Image file length check for '50000 byte or 50 KB'
                        MemoryStream ms = new MemoryStream();
                        Image img = new Bitmap(dlg.FileName);
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        if (ms.Length > 100000) { MessageBox.Show("Image file should be in 100 KB"); return; }
                        #endregion

                        pictureBox1.Image = new Bitmap(dlg.FileName);

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
            try
            {
                frmWebCam webCam = new frmWebCam();
                DialogResult dr = webCam.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    ImageConverter converter = new ImageConverter();
                    Image img = (Image)converter.ConvertFrom(webCam.getPhoto());

                    if (img != null)
                    {
                        pictureBox1.Image = img;
                        bytes = imageToByteArray(img);
                    }
                    else MessageBox.Show("Photo not taken.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Photo not taken.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmDocument_Load_1(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {

        }

        private void btnWebCam_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }

        private void frmDocuments_Click(object sender, EventArgs e)
        {

        }

    }

    public class DocumentsGrid
    {
        public string docNumber { get; set; }
        public string issuePlace { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expireDate { get; set; }





        private Document _obj;

        public DocumentsGrid(Document obj)
        {
            _obj = obj;
        }

        public Document GetModel()
        {
            return _obj;
        }
    }
}
