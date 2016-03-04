namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmAgentCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgentCreation));
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbPostCode = new System.Windows.Forms.ComboBox();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.cmbThana = new System.Windows.Forms.ComboBox();
            this.txtAgentLocation = new System.Windows.Forms.TextBox();
            this.gvAccontInformation = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblSelectedAccount = new System.Windows.Forms.Label();
            this.btnCloseAgentInfo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbAccountNo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.tabPageAccInfo = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearAgentInfo = new System.Windows.Forms.Button();
            this.tabPageAgentInfo = new System.Windows.Forms.TabPage();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDivision = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.tabAgentCreation = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblfingerprintResult = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.gvUsers = new System.Windows.Forms.DataGridView();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFingerPrint = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPageSubAgent = new System.Windows.Forms.TabPage();
            this.dgvSubAgent = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccontInformation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageAccInfo.SuspendLayout();
            this.tabPageAgentInfo.SuspendLayout();
            this.tabAgentCreation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.tabPageSubAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(68, 294);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Postal Code :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(94, 267);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 17;
            this.label22.Text = "Thana :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(93, 240);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 15;
            this.label23.Text = "District :";
            // 
            // cmbPostCode
            // 
            this.cmbPostCode.FormattingEnabled = true;
            this.cmbPostCode.Location = new System.Drawing.Point(140, 291);
            this.cmbPostCode.Name = "cmbPostCode";
            this.cmbPostCode.Size = new System.Drawing.Size(219, 21);
            this.cmbPostCode.TabIndex = 20;
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(140, 237);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(219, 21);
            this.cmbDistrict.TabIndex = 16;
            this.cmbDistrict.SelectedIndexChanged += new System.EventHandler(this.cmbDistrict_SelectedIndexChanged);
            // 
            // cmbThana
            // 
            this.cmbThana.FormattingEnabled = true;
            this.cmbThana.Location = new System.Drawing.Point(140, 264);
            this.cmbThana.Name = "cmbThana";
            this.cmbThana.Size = new System.Drawing.Size(219, 21);
            this.cmbThana.TabIndex = 18;
            // 
            // txtAgentLocation
            // 
            this.txtAgentLocation.Location = new System.Drawing.Point(140, 121);
            this.txtAgentLocation.Multiline = true;
            this.txtAgentLocation.Name = "txtAgentLocation";
            this.txtAgentLocation.Size = new System.Drawing.Size(219, 84);
            this.txtAgentLocation.TabIndex = 12;
            // 
            // gvAccontInformation
            // 
            this.gvAccontInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccontInformation.Location = new System.Drawing.Point(26, 147);
            this.gvAccontInformation.Name = "gvAccontInformation";
            this.gvAccontInformation.Size = new System.Drawing.Size(594, 182);
            this.gvAccontInformation.TabIndex = 2;
            this.gvAccontInformation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAccontInformation_CellContentClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Account Name :";
            // 
            // txtAgentName
            // 
            this.txtAgentName.Location = new System.Drawing.Point(140, 95);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(219, 20);
            this.txtAgentName.TabIndex = 10;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(140, 35);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(66, 20);
            this.txtCustomerId.TabIndex = 1;
            this.txtCustomerId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerId_KeyDown);
            this.txtCustomerId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerId_KeyPress);
            // 
            // lblSelectedAccount
            // 
            this.lblSelectedAccount.AutoSize = true;
            this.lblSelectedAccount.Location = new System.Drawing.Point(26, 131);
            this.lblSelectedAccount.Name = "lblSelectedAccount";
            this.lblSelectedAccount.Size = new System.Drawing.Size(103, 13);
            this.lblSelectedAccount.TabIndex = 1;
            this.lblSelectedAccount.Text = "Selected Accounts :";
            // 
            // btnCloseAgentInfo
            // 
            this.btnCloseAgentInfo.Location = new System.Drawing.Point(572, 390);
            this.btnCloseAgentInfo.Name = "btnCloseAgentInfo";
            this.btnCloseAgentInfo.Size = new System.Drawing.Size(75, 23);
            this.btnCloseAgentInfo.TabIndex = 3;
            this.btnCloseAgentInfo.Text = "Close";
            this.btnCloseAgentInfo.UseVisualStyleBackColor = true;
            this.btnCloseAgentInfo.Click += new System.EventHandler(this.btnCloseAgentInfo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Email :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(410, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnAccountInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mobile No :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Select Account No :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(276, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbAccountNo
            // 
            this.cmbAccountNo.FormattingEnabled = true;
            this.cmbAccountNo.Location = new System.Drawing.Point(119, 22);
            this.cmbAccountNo.Name = "cmbAccountNo";
            this.cmbAccountNo.Size = new System.Drawing.Size(135, 21);
            this.cmbAccountNo.TabIndex = 1;
            this.cmbAccountNo.SelectedIndexChanged += new System.EventHandler(this.cmbAccountNo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cmbAccountNo);
            this.groupBox1.Controls.Add(this.lblAccountName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(61, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Accounts";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(119, 57);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(0, 13);
            this.lblAccountName.TabIndex = 4;
            // 
            // tabPageAccInfo
            // 
            this.tabPageAccInfo.Controls.Add(this.groupBox1);
            this.tabPageAccInfo.Controls.Add(this.lblSelectedAccount);
            this.tabPageAccInfo.Controls.Add(this.gvAccontInformation);
            this.tabPageAccInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccInfo.Name = "tabPageAccInfo";
            this.tabPageAccInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccInfo.Size = new System.Drawing.Size(647, 346);
            this.tabPageAccInfo.TabIndex = 1;
            this.tabPageAccInfo.Text = "Account Information";
            this.tabPageAccInfo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Agent/Business Location :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Agent/Business Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Id :";
            // 
            // btnClearAgentInfo
            // 
            this.btnClearAgentInfo.Location = new System.Drawing.Point(491, 390);
            this.btnClearAgentInfo.Name = "btnClearAgentInfo";
            this.btnClearAgentInfo.Size = new System.Drawing.Size(75, 23);
            this.btnClearAgentInfo.TabIndex = 2;
            this.btnClearAgentInfo.Text = "Clear";
            this.btnClearAgentInfo.UseVisualStyleBackColor = true;
            this.btnClearAgentInfo.Click += new System.EventHandler(this.btnClearAgentInfo_Click);
            // 
            // tabPageAgentInfo
            // 
            this.tabPageAgentInfo.Controls.Add(this.lblCustomerName);
            this.tabPageAgentInfo.Controls.Add(this.btnSearch);
            this.tabPageAgentInfo.Controls.Add(this.label6);
            this.tabPageAgentInfo.Controls.Add(this.label9);
            this.tabPageAgentInfo.Controls.Add(this.cmbDivision);
            this.tabPageAgentInfo.Controls.Add(this.lblEmail);
            this.tabPageAgentInfo.Controls.Add(this.lblMobileNo);
            this.tabPageAgentInfo.Controls.Add(this.label20);
            this.tabPageAgentInfo.Controls.Add(this.label22);
            this.tabPageAgentInfo.Controls.Add(this.label23);
            this.tabPageAgentInfo.Controls.Add(this.cmbPostCode);
            this.tabPageAgentInfo.Controls.Add(this.cmbDistrict);
            this.tabPageAgentInfo.Controls.Add(this.cmbThana);
            this.tabPageAgentInfo.Controls.Add(this.txtAgentLocation);
            this.tabPageAgentInfo.Controls.Add(this.txtAgentName);
            this.tabPageAgentInfo.Controls.Add(this.txtCustomerId);
            this.tabPageAgentInfo.Controls.Add(this.label5);
            this.tabPageAgentInfo.Controls.Add(this.label4);
            this.tabPageAgentInfo.Controls.Add(this.label3);
            this.tabPageAgentInfo.Controls.Add(this.label2);
            this.tabPageAgentInfo.Controls.Add(this.label1);
            this.tabPageAgentInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageAgentInfo.Name = "tabPageAgentInfo";
            this.tabPageAgentInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAgentInfo.Size = new System.Drawing.Size(647, 346);
            this.tabPageAgentInfo.TabIndex = 0;
            this.tabPageAgentInfo.Text = "Agent Information";
            this.tabPageAgentInfo.UseVisualStyleBackColor = true;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(382, 38);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerName.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(212, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Customer Name :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Division :";
            // 
            // cmbDivision
            // 
            this.cmbDivision.FormattingEnabled = true;
            this.cmbDivision.Location = new System.Drawing.Point(140, 212);
            this.cmbDivision.Name = "cmbDivision";
            this.cmbDivision.Size = new System.Drawing.Size(219, 21);
            this.cmbDivision.TabIndex = 14;
            this.cmbDivision.SelectedIndexChanged += new System.EventHandler(this.cmbDivision_SelectedIndexChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(387, 66);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 13);
            this.lblEmail.TabIndex = 8;
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(142, 66);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(0, 13);
            this.lblMobileNo.TabIndex = 6;
            // 
            // tabAgentCreation
            // 
            this.tabAgentCreation.Controls.Add(this.tabPageAgentInfo);
            this.tabAgentCreation.Controls.Add(this.tabPageAccInfo);
            this.tabAgentCreation.Controls.Add(this.tabPage1);
            this.tabAgentCreation.Controls.Add(this.tabPageSubAgent);
            this.tabAgentCreation.Location = new System.Drawing.Point(12, 12);
            this.tabAgentCreation.Name = "tabAgentCreation";
            this.tabAgentCreation.SelectedIndex = 0;
            this.tabAgentCreation.Size = new System.Drawing.Size(655, 372);
            this.tabAgentCreation.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblfingerprintResult);
            this.tabPage1.Controls.Add(this.btnAddUser);
            this.tabPage1.Controls.Add(this.gvUsers);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnFingerPrint);
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(647, 346);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblfingerprintResult
            // 
            this.lblfingerprintResult.AutoSize = true;
            this.lblfingerprintResult.Location = new System.Drawing.Point(122, 94);
            this.lblfingerprintResult.Name = "lblfingerprintResult";
            this.lblfingerprintResult.Size = new System.Drawing.Size(0, 13);
            this.lblfingerprintResult.TabIndex = 4;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(371, 60);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(105, 23);
            this.btnAddUser.TabIndex = 6;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // gvUsers
            // 
            this.gvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsers.Location = new System.Drawing.Point(3, 122);
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.Size = new System.Drawing.Size(644, 218);
            this.gvUsers.TabIndex = 7;
            this.gvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvUsers_CellContentClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(122, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(190, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Password ;";
            // 
            // btnFingerPrint
            // 
            this.btnFingerPrint.Location = new System.Drawing.Point(371, 25);
            this.btnFingerPrint.Name = "btnFingerPrint";
            this.btnFingerPrint.Size = new System.Drawing.Size(105, 23);
            this.btnFingerPrint.TabIndex = 5;
            this.btnFingerPrint.Text = "Capture Fingerprint";
            this.btnFingerPrint.UseVisualStyleBackColor = true;
            this.btnFingerPrint.Click += new System.EventHandler(this.btnFingerPrint_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(122, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(190, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(55, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "User Name :";
            // 
            // tabPageSubAgent
            // 
            this.tabPageSubAgent.Controls.Add(this.dgvSubAgent);
            this.tabPageSubAgent.Location = new System.Drawing.Point(4, 22);
            this.tabPageSubAgent.Name = "tabPageSubAgent";
            this.tabPageSubAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSubAgent.Size = new System.Drawing.Size(647, 346);
            this.tabPageSubAgent.TabIndex = 3;
            this.tabPageSubAgent.Tag = "tabPageSubAgent";
            this.tabPageSubAgent.Text = "Sub Agent";
            this.tabPageSubAgent.UseVisualStyleBackColor = true;
            // 
            // dgvSubAgent
            // 
            this.dgvSubAgent.AllowUserToAddRows = false;
            this.dgvSubAgent.AllowUserToDeleteRows = false;
            this.dgvSubAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubAgent.Location = new System.Drawing.Point(4, 5);
            this.dgvSubAgent.Name = "dgvSubAgent";
            this.dgvSubAgent.Size = new System.Drawing.Size(639, 335);
            this.dgvSubAgent.TabIndex = 18;
            this.dgvSubAgent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubAgent_CellContentClick);
            // 
            // frmAgentCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 421);
            this.Controls.Add(this.btnCloseAgentInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClearAgentInfo);
            this.Controls.Add(this.tabAgentCreation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgentCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agent Creation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgentCreation_FormClosing);
            this.Load += new System.EventHandler(this.frmAgentCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccontInformation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageAccInfo.ResumeLayout(false);
            this.tabPageAccInfo.PerformLayout();
            this.tabPageAgentInfo.ResumeLayout(false);
            this.tabPageAgentInfo.PerformLayout();
            this.tabAgentCreation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.tabPageSubAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubAgent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbPostCode;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.ComboBox cmbThana;
        private System.Windows.Forms.TextBox txtAgentLocation;
        private System.Windows.Forms.DataGridView gvAccontInformation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblSelectedAccount;
        private System.Windows.Forms.Button btnCloseAgentInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbAccountNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TabPage tabPageAccInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearAgentInfo;
        private System.Windows.Forms.TabPage tabPageAgentInfo;
        private System.Windows.Forms.TabControl tabAgentCreation;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDivision;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnFingerPrint;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView gvUsers;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblfingerprintResult;
        private System.Windows.Forms.TabPage tabPageSubAgent;
        private System.Windows.Forms.DataGridView dgvSubAgent;
    }
}