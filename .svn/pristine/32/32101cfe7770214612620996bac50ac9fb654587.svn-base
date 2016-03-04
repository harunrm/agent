using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.menu;

namespace MISL.Ababil.Agent.UI.forms.security
{
    public partial class MenuActionManagement : Form
    {

        private MenuService menuService;
        private DataTable dataTable;
        private long menuActionId;
        private int localId;
        private bool newItem;

        public MenuActionManagement()
        {
            InitializeComponent();

            menuService = new MenuService();

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;

            this.dataTable = new DataTable();
            this.dataTable.Columns.Add("Id", typeof(long));
            this.dataTable.Columns.Add("Name", typeof(String));
            this.dataTable.Columns.Add("Action", typeof(String));
            this.dataTable.Columns.Add("Local Id", typeof(Boolean));
            this.menuItemGridView.DataSource = dataTable;
            this.menuItemGridView.Columns.Insert(4,editButtonColumn);
            this.menuItemGridView.Columns.Insert(5, deleteButtonColumn);

            this.menuItemGridView.Columns["Edit"].Width = 50;
            this.menuItemGridView.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            this.menuItemGridView.Columns["Delete"].Width = 50;
            this.menuItemGridView.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            this.menuItemGridView.Columns["Name"].Width = 100;
            this.menuItemGridView.Columns["Name"].ReadOnly = true;
            this.menuItemGridView.Columns["Action"].ReadOnly = true;

            this.menuItemGridView.Columns["Id"].Visible = false;
            this.menuItemGridView.Columns["Local Id"].Visible = false;

            this.menuItemGridView.AllowUserToAddRows = false;

            this.menuActionId = 0;
            this.localId = 0;
            this.newItem = true;

            List<MislbdMenuAction> menuActions = menuService.GetMenuActions();
            if (menuActions != null)
            {
                foreach (MislbdMenuAction action in menuActions)
                {
                    dataTable.Rows.Add(action.id, action.name, action.action, ++localId);
                }
            }
        }

        private void SaveMenuAction()
        {


            if (String.IsNullOrEmpty(menuItemNameTextBox.Text))
            {
                return;
            }

            if (String.IsNullOrEmpty(menuItemActionTextBox.Text))
            {
                return;
            }

            
            localId++;

            MislbdMenuAction action = new MislbdMenuAction();
            action.id = menuActionId;
            action.action = menuItemActionTextBox.Text;
            action.name = menuItemNameTextBox.Text;

            menuService.SaveMenuAction(action);

            if (newItem) {
                dataTable.Rows.Add(action.id, action.name, action.action, localId);
            }
            else
            {
                DataRow[] updatedActions = dataTable.Select("Id = " + action.id);
                updatedActions[0]["Name"] = action.name;
                updatedActions[0]["Action"] = action.action;
            }

            menuActionId = 0;
            newItem = true;
            menuItemNameTextBox.Text = String.Empty;
            menuItemActionTextBox.Text = String.Empty;

        }

        private void DeleteMenuAction(int rowIndex)
        {
            try
            {
                DataRow delRow = dataTable.Rows[rowIndex];
                long menuActionId = (long)delRow["Id"];
                menuService.DeleteMenuAction(menuActionId);

                dataTable.Rows.Remove(delRow);
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveMenuAction();
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void menuItemGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == menuItemGridView.Columns["Edit"].Index)
            {
                DataRow editRow = dataTable.Rows[e.RowIndex];
                menuActionId = (long) editRow["Id"];
                menuItemActionTextBox.Text = editRow["Action"].ToString();
                menuItemNameTextBox.Text = editRow["Name"].ToString();
                newItem = false;
            }
            
            else if (e.ColumnIndex == menuItemGridView.Columns["Delete"].Index)
            {
                DeleteMenuAction(e.RowIndex);   
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            menuActionId = 0;
            menuItemActionTextBox.Text = String.Empty;
            menuItemNameTextBox.Text = String.Empty;
            newItem = true;
            menuItemGridView.ClearSelection();
        }
    }
}
