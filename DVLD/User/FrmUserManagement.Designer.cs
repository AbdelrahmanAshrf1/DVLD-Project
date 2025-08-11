namespace DVLD
{
    partial class FrmUserManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManagement));
            this.txtFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvUsersInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsPeople = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.cmsShowDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.callPhoneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilteredBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.backgroundPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).BeginInit();
            this.cmsPeople.SuspendLayout();
            this.backgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(24)))), ((int)(((byte)(185)))));
            this.txtFilterBy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(24)))), ((int)(((byte)(185)))));
            this.txtFilterBy.BorderRadius = 10;
            this.txtFilterBy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterBy.DefaultText = "";
            this.txtFilterBy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterBy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterBy.Location = new System.Drawing.Point(348, 90);
            this.txtFilterBy.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.PlaceholderText = "";
            this.txtFilterBy.SelectedText = "";
            this.txtFilterBy.Size = new System.Drawing.Size(173, 26);
            this.txtFilterBy.TabIndex = 20;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNumber.ForeColor = System.Drawing.Color.White;
            this.lblRecordsNumber.Location = new System.Drawing.Point(152, 612);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(26, 23);
            this.lblRecordsNumber.TabIndex = 18;
            this.lblRecordsNumber.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 612);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "# Records :";
            // 
            // dgvUsersInfo
            // 
            this.dgvUsersInfo.AllowUserToAddRows = false;
            this.dgvUsersInfo.AllowUserToDeleteRows = false;
            this.dgvUsersInfo.AllowUserToOrderColumns = true;
            this.dgvUsersInfo.AllowUserToResizeColumns = false;
            this.dgvUsersInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvUsersInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsersInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(30)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsersInfo.ColumnHeadersHeight = 30;
            this.dgvUsersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvUsersInfo.ContextMenuStrip = this.cmsPeople;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsersInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.dgvUsersInfo.Location = new System.Drawing.Point(55, 147);
            this.dgvUsersInfo.MultiSelect = false;
            this.dgvUsersInfo.Name = "dgvUsersInfo";
            this.dgvUsersInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsersInfo.RowHeadersVisible = false;
            this.dgvUsersInfo.RowHeadersWidth = 51;
            this.dgvUsersInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUsersInfo.RowTemplate.Height = 24;
            this.dgvUsersInfo.Size = new System.Drawing.Size(1019, 435);
            this.dgvUsersInfo.TabIndex = 19;
            this.dgvUsersInfo.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.DeepPurple;
            this.dgvUsersInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvUsersInfo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvUsersInfo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvUsersInfo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvUsersInfo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvUsersInfo.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(30)))), ((int)(((byte)(109)))));
            this.dgvUsersInfo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.dgvUsersInfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.dgvUsersInfo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsersInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            this.dgvUsersInfo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsersInfo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvUsersInfo.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvUsersInfo.ThemeStyle.ReadOnly = true;
            this.dgvUsersInfo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.dgvUsersInfo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsersInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            this.dgvUsersInfo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsersInfo.ThemeStyle.RowsStyle.Height = 24;
            this.dgvUsersInfo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.dgvUsersInfo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUsersInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsersInfo_CellContentClick);
            // 
            // cmsPeople
            // 
            this.cmsPeople.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsShowDetailsItem,
            this.addNewPersonToolStripMenuItem1,
            this.addNewPersonToolStripMenuItem2,
            this.editToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.sendEmailToolStripMenuItem1,
            this.callPhoneToolStripMenuItem1});
            this.cmsPeople.Name = "cmsPeople";
            this.cmsPeople.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsPeople.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsPeople.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsPeople.RenderStyle.ColorTable = null;
            this.cmsPeople.RenderStyle.RoundedEdges = true;
            this.cmsPeople.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsPeople.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsPeople.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsPeople.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsPeople.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsPeople.Size = new System.Drawing.Size(198, 198);
            // 
            // cmsShowDetailsItem
            // 
            this.cmsShowDetailsItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsShowDetailsItem.Image = ((System.Drawing.Image)(resources.GetObject("cmsShowDetailsItem.Image")));
            this.cmsShowDetailsItem.Name = "cmsShowDetailsItem";
            this.cmsShowDetailsItem.Size = new System.Drawing.Size(197, 26);
            this.cmsShowDetailsItem.Text = "Show Details";
            this.cmsShowDetailsItem.Click += new System.EventHandler(this.cmsShowDetailsItem_Click);
            // 
            // addNewPersonToolStripMenuItem1
            // 
            this.addNewPersonToolStripMenuItem1.Name = "addNewPersonToolStripMenuItem1";
            this.addNewPersonToolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // addNewPersonToolStripMenuItem2
            // 
            this.addNewPersonToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("addNewPersonToolStripMenuItem2.Image")));
            this.addNewPersonToolStripMenuItem2.Name = "addNewPersonToolStripMenuItem2";
            this.addNewPersonToolStripMenuItem2.Size = new System.Drawing.Size(197, 26);
            this.addNewPersonToolStripMenuItem2.Tag = "0";
            this.addNewPersonToolStripMenuItem2.Text = "Add New User";
            this.addNewPersonToolStripMenuItem2.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem2_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem1.Image")));
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.editToolStripMenuItem1.Tag = "1";
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem1.Image")));
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItem1.Text = "Change Password";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 6);
            // 
            // sendEmailToolStripMenuItem1
            // 
            this.sendEmailToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("sendEmailToolStripMenuItem1.Image")));
            this.sendEmailToolStripMenuItem1.Name = "sendEmailToolStripMenuItem1";
            this.sendEmailToolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.sendEmailToolStripMenuItem1.Text = "Send Email";
            this.sendEmailToolStripMenuItem1.Click += new System.EventHandler(this.featureNotImplementedYet);
            // 
            // callPhoneToolStripMenuItem1
            // 
            this.callPhoneToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("callPhoneToolStripMenuItem1.Image")));
            this.callPhoneToolStripMenuItem1.Name = "callPhoneToolStripMenuItem1";
            this.callPhoneToolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.callPhoneToolStripMenuItem1.Text = "Call Phone";
            this.callPhoneToolStripMenuItem1.Click += new System.EventHandler(this.featureNotImplementedYet);
            // 
            // cbFilteredBy
            // 
            this.cbFilteredBy.AutoRoundedCorners = true;
            this.cbFilteredBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(24)))), ((int)(((byte)(185)))));
            this.cbFilteredBy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(24)))), ((int)(((byte)(185)))));
            this.cbFilteredBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilteredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilteredBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilteredBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilteredBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cbFilteredBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbFilteredBy.ItemHeight = 20;
            this.cbFilteredBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Username",
            "Person ID",
            "Full Name",
            "Is Active"});
            this.cbFilteredBy.Location = new System.Drawing.Point(156, 90);
            this.cbFilteredBy.Name = "cbFilteredBy";
            this.cbFilteredBy.Size = new System.Drawing.Size(173, 26);
            this.cbFilteredBy.StartIndex = 0;
            this.cbFilteredBy.TabIndex = 15;
            this.cbFilteredBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbFilteredBy.SelectedIndexChanged += new System.EventHandler(this.cbFilteredBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter by";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(2035, -4);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(107, 82);
            this.guna2ControlBox1.TabIndex = 11;
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cbIsActive.BorderRadius = 12;
            this.cbIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbIsActive.ItemHeight = 20;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(369, 90);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(112, 26);
            this.cbIsActive.StartIndex = 0;
            this.cbIsActive.TabIndex = 21;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.Controls.Add(this.btnAdd);
            this.backgroundPanel.Controls.Add(this.btnCancel);
            this.backgroundPanel.Controls.Add(this.label1);
            this.backgroundPanel.Controls.Add(this.cbFilteredBy);
            this.backgroundPanel.Controls.Add(this.lblRecordsNumber);
            this.backgroundPanel.Controls.Add(this.label2);
            this.backgroundPanel.Controls.Add(this.label3);
            this.backgroundPanel.Controls.Add(this.txtFilterBy);
            this.backgroundPanel.Controls.Add(this.cbIsActive);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(115)))));
            this.backgroundPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(10)))), ((int)(((byte)(203)))));
            this.backgroundPanel.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(29)))), ((int)(((byte)(228)))));
            this.backgroundPanel.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(72)))), ((int)(((byte)(255)))));
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(1110, 653);
            this.backgroundPanel.TabIndex = 22;
            // 
            // btnAdd
            // 
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.White;
            this.btnAdd.FillColor2 = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(53)))), ((int)(((byte)(242)))));
            this.btnAdd.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdd.Location = new System.Drawing.Point(841, 603);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 32);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Tag = "0";
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.FillColor2 = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(53)))), ((int)(((byte)(242)))));
            this.btnCancel.Location = new System.Drawing.Point(960, 603);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 32);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 12F);
            this.label1.Location = new System.Drawing.Point(443, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 49);
            this.label1.TabIndex = 23;
            this.label1.Text = "Manage Users";
            // 
            // FrmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1110, 653);
            this.ControlBox = false;
            this.Controls.Add(this.dgvUsersInfo);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.backgroundPanel);
            this.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmUserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).EndInit();
            this.cmsPeople.ResumeLayout(false);
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtFilterBy;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem callPhoneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUsersInfo;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsPeople;
        private System.Windows.Forms.ToolStripMenuItem cmsShowDetailsItem;
        private System.Windows.Forms.ToolStripSeparator addNewPersonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilteredBy;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsActive;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel backgroundPanel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAdd;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
    }
}