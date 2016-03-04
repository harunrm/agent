using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.CommentUI
{
    public partial class frmCommentUI : MetroForm
    {
        public List<CommentDto> _comments = new List<CommentDto>();
        public CommentDto _commentDraft = new CommentDto();
        private CommentDto _commentDtoDraft = new CommentDto();
        Packet _receivedPacket;
        string _stage = "";

        public frmCommentUI()
        {
            InitializeComponent();
        }

        public frmCommentUI(Packet packet, CommentDto commentDraft, List<CommentDto> comments, string stage)
        {
            InitializeComponent();
            _commentDraft = commentDraft;
            _comments = comments;
            _stage = stage;
            LoadCommentFromDto();
        }

        private void LoadCommentFromDto()
        {
            pnlComments.Controls.Clear();

            for (int i = 0; i < _comments.Count; i++)
            {
                CommentItem commentItemTmp = new CommentItem();
                commentItemTmp.Editable = false;
                commentItemTmp.lblComment.Text = _comments[i].comment;
                commentItemTmp.lblUserName.Text = _comments[i].commentUser;
                commentItemTmp.lblStage.Text = _comments[i].stage;
                commentItemTmp.lblDateTime.Text = _comments[i].commentDate;
                //commentItemTmp.Dock = DockStyle.Top;

                pnlComments.Controls.Add(commentItemTmp);
            }

            if (_commentDraft != null)
            {
                if (!string.IsNullOrEmpty(_commentDraft.comment))
                {
                    CommentItem commentItem = new CommentItem();
                    commentItem.Editable = true;
                    commentItem.lblComment.Text = _commentDraft.comment;
                    commentItem.lblUserName.Text = _commentDraft.commentUser;
                    commentItem.lblStage.Text = _commentDraft.stage;
                    if (string.IsNullOrEmpty(_commentDraft.commentDate))
                    {
                        //commentItem.lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        commentItem.lblDateTime.Text = SessionInfo.currentDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        commentItem.lblDateTime.Text = _commentDraft.commentDate;
                    }

                    commentItem._parent = this;
                    pnlComments.Controls.Add(commentItem);
                }
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            CommentDto commentDto = new CommentDto();
            commentDto.comment = txtComment.Text;
            commentDto.commentUser = SessionInfo.username;
            commentDto.stage = _stage;

            _commentDraft = commentDto;

            LoadCommentFromDto();

            txtComment.Text = "";
            txtComment.Focus();
        }

        private void frmCommentUI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                this.Close();
            }
        }

        private void frmCommentUI_Deactivate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                this.Close();
            }
        }
    }
}