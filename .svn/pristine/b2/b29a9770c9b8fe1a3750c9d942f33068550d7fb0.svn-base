using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.LocalStorageService;
using MISL.Ababil.Agent.LocalStorageService.Models;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms.CacheUI
{
    public partial class frmCacheUpdateAdministration : MetroForm
    {
        GUI gui = new GUI();
        List<CacheInformation> _cacheInformationList = new List<CacheInformation>();

        public frmCacheUpdateAdministration()
        {
            InitializeComponent();
            gui = new GUI(this);
        }

        public class CacheInformationGrid
        {
            public string objectName { get; set; }

            public string description { get; set; }

            public long lastUpdateTime { get; set; }

            //public DataGridViewButtonCell

            private CacheInformation _obj;

            public CacheInformationGrid(CacheInformation obj)
            {
                _obj = obj;
            }

            public CacheInformation GetModel()
            {
                return _obj;
            }
        }

        private void LoadCacheInformation()
        {
            ProgressUIManager.ShowProgress(this);
            try
            {
                _cacheInformationList = new List<CacheInformation>();
                LocalStorage localStorage = new LocalStorage();
                localStorage.LoadRemoteCacheInformation(ref _cacheInformationList);
                dgvCacheInfo.DataSource = null;
                dgvCacheInfo.Columns.Clear();
                dgvCacheInfo.DataSource = _cacheInformationList.Select(o => new CacheInformationGrid(o)
                {
                    objectName = o.objectName,
                    description = o.description,
                    lastUpdateTime = o.lastUpdateTime
                }).ToList();
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Text = "Update";
                buttonColumn.UseColumnTextForButtonValue = true;
                dgvCacheInfo.Columns.Add(buttonColumn);
                ProgressUIManager.CloseProgress();
            }
            catch
            {
                ProgressUIManager.CloseProgress();
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // LoadCacheInformation();
            gui.RefreshOwnerForm();
        }

        private void dgvCacheInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCacheInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Update")
                {
                    long dateTime = DateTime.Now.ToUnixTime(); // UtilityServices.GetLongDate(SessionInfo.currentDate);
                    dgvCacheInfo.Rows[e.RowIndex].Cells[2].Value = dateTime;
                    _cacheInformationList[e.RowIndex].lastUpdateTime = dateTime;

                    LocalStorage localStorage = new LocalStorage();
                    localStorage.SaveRemoteCacheInformation(ref _cacheInformationList);

                    gui.RefreshOwnerForm();
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Message.showConfirmation("Are you sure to update?") == "yes")
            {
                for (int i = 0; i < _cacheInformationList.Count; i++)
                {
                    long dateTime = DateTime.Now.ToUnixTime();
                    dgvCacheInfo.Rows[i].Cells[2].Value = dateTime;
                    _cacheInformationList[i].lastUpdateTime = dateTime;
                }

                LocalStorage localStorage = new LocalStorage();
                localStorage.SaveRemoteCacheInformation(ref _cacheInformationList);
            }
            gui.RefreshOwnerForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCacheUpdateAdministration_Load(object sender, EventArgs e)
        {
            LoadCacheInformation();
        }

        private void frmCacheUpdateAdministration_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }
}