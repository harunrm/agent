using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.CommentUI
{
    public partial class CommentItem : UserControl
    {
        public bool _editable = false;
        public frmCommentUI _parent;

        public CommentItem()
        {
            InitializeComponent();
        }

        public bool Editable
        {
            get
            {
                return _editable;
            }
            set
            {
                _editable = value;
                btnEdit.Visible = value;
                btnDelete.Visible = value;
            }
        }

        private void CommentItem_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.DodgerBlue, 0, this.Height - 1, this.Width, Height - 1);
            e.Graphics.DrawLine(Pens.DodgerBlue, 0, this.Height - 2, this.Width, Height - 2);
        }

        private void CommentItem_Enter(object sender, EventArgs e)
        {

        }

        private void CommentItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DodgerBlue;
        }

        private void CommentItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void lblComment_Resize(object sender, EventArgs e)
        {
            lblUserName.Top = lblStage.Top = lblDateTime.Top = lblComment.Top + lblComment.Height + 6;
            this.Height = lblUserName.Top + lblUserName.Height + 13;
        }

        private void CommentItem_Load(object sender, EventArgs e)
        {
            lblUserName.Top = lblStage.Top = lblDateTime.Top = lblComment.Top + lblComment.Height + 6;
            this.Height = lblUserName.Top + lblUserName.Height + 13;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _parent._commentDraft = null;
            this.Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_parent != null)
            {
                _parent.txtComment.Text = lblComment.Text;
                this.Dispose();
            }
        }
    }
}