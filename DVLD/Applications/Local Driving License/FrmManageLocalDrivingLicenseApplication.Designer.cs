namespace DVLD
{
    partial class FrmManageLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageLocalDrivingLicenseApplication));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsApplications = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.cmsItem1ShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsItem2EditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem3DeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem4CancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsItem5ScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsItem6SIssueLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.cmsItem7ShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsItem8ShowPersonHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.backgroundPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.dgvLocalDrivingLicenseApplications = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFilteredBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddNewLocalDrivingLicenseApplication = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cmsApplications.SuspendLayout();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem1ShowApplicationDetails,
            this.addNewPersonToolStripMenuItem1,
            this.cmsItem2EditApplication,
            this.cmsItem3DeleteApplication,
            this.cmsItem4CancelApplication,
            this.toolStripMenuItem2,
            this.cmsItem5ScheduleTests,
            this.toolStripMenuItem1,
            this.cmsItem6SIssueLicense,
            this.showLicenseToolStripMenuItem,
            this.cmsItem7ShowLicense,
            this.toolStripMenuItem3,
            this.cmsItem8ShowPersonHistory});
            this.cmsApplications.Name = "cmsPeople";
            this.cmsApplications.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsApplications.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsApplications.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsApplications.RenderStyle.ColorTable = null;
            this.cmsApplications.RenderStyle.RoundedEdges = true;
            this.cmsApplications.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsApplications.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsApplications.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsApplications.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsApplications.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsApplications.Size = new System.Drawing.Size(294, 270);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // cmsItem1ShowApplicationDetails
            // 
            this.cmsItem1ShowApplicationDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsItem1ShowApplicationDetails.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem1ShowApplicationDetails.Image")));
            this.cmsItem1ShowApplicationDetails.Name = "cmsItem1ShowApplicationDetails";
            this.cmsItem1ShowApplicationDetails.Size = new System.Drawing.Size(293, 26);
            this.cmsItem1ShowApplicationDetails.Text = "Show Application Details";
            this.cmsItem1ShowApplicationDetails.Click += new System.EventHandler(this.cmsItem1ShowApplicationDetails_Click);
            // 
            // addNewPersonToolStripMenuItem1
            // 
            this.addNewPersonToolStripMenuItem1.Name = "addNewPersonToolStripMenuItem1";
            this.addNewPersonToolStripMenuItem1.Size = new System.Drawing.Size(290, 6);
            // 
            // cmsItem2EditApplication
            // 
            this.cmsItem2EditApplication.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem2EditApplication.Image")));
            this.cmsItem2EditApplication.Name = "cmsItem2EditApplication";
            this.cmsItem2EditApplication.Size = new System.Drawing.Size(293, 26);
            this.cmsItem2EditApplication.Tag = "0";
            this.cmsItem2EditApplication.Text = "Edit Application";
            this.cmsItem2EditApplication.Click += new System.EventHandler(this.cmsItem2EditApplication_Click);
            // 
            // cmsItem3DeleteApplication
            // 
            this.cmsItem3DeleteApplication.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem3DeleteApplication.Image")));
            this.cmsItem3DeleteApplication.Name = "cmsItem3DeleteApplication";
            this.cmsItem3DeleteApplication.Size = new System.Drawing.Size(293, 26);
            this.cmsItem3DeleteApplication.Tag = "1";
            this.cmsItem3DeleteApplication.Text = "Delete Application";
            this.cmsItem3DeleteApplication.Click += new System.EventHandler(this.cmsItem3DeleteApplication_Click);
            // 
            // cmsItem4CancelApplication
            // 
            this.cmsItem4CancelApplication.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem4CancelApplication.Image")));
            this.cmsItem4CancelApplication.Name = "cmsItem4CancelApplication";
            this.cmsItem4CancelApplication.Size = new System.Drawing.Size(293, 26);
            this.cmsItem4CancelApplication.Text = "Cancel Application";
            this.cmsItem4CancelApplication.Click += new System.EventHandler(this.cmsItem4CancelApplication_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(290, 6);
            // 
            // cmsItem5ScheduleTests
            // 
            this.cmsItem5ScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.cmsItem5ScheduleTests.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem5ScheduleTests.Image")));
            this.cmsItem5ScheduleTests.Name = "cmsItem5ScheduleTests";
            this.cmsItem5ScheduleTests.Size = new System.Drawing.Size(293, 26);
            this.cmsItem5ScheduleTests.Text = "Schedule Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleVisionTestToolStripMenuItem.Image")));
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleWrittenTestToolStripMenuItem.Image")));
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule WrittenTest";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleStreetTestToolStripMenuItem.Image")));
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule StreetTest";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(290, 6);
            // 
            // cmsItem6SIssueLicense
            // 
            this.cmsItem6SIssueLicense.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem6SIssueLicense.Image")));
            this.cmsItem6SIssueLicense.Name = "cmsItem6SIssueLicense";
            this.cmsItem6SIssueLicense.Size = new System.Drawing.Size(293, 26);
            this.cmsItem6SIssueLicense.Text = "Issue Driving License (First time)";
            this.cmsItem6SIssueLicense.Click += new System.EventHandler(this.cmsItem6SIssueLicense_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(290, 6);
            // 
            // cmsItem7ShowLicense
            // 
            this.cmsItem7ShowLicense.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem7ShowLicense.Image")));
            this.cmsItem7ShowLicense.Name = "cmsItem7ShowLicense";
            this.cmsItem7ShowLicense.Size = new System.Drawing.Size(293, 26);
            this.cmsItem7ShowLicense.Text = "Show License";
            this.cmsItem7ShowLicense.Click += new System.EventHandler(this.cmsItem7ShowLicense_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(290, 6);
            // 
            // cmsItem8ShowPersonHistory
            // 
            this.cmsItem8ShowPersonHistory.Image = ((System.Drawing.Image)(resources.GetObject("cmsItem8ShowPersonHistory.Image")));
            this.cmsItem8ShowPersonHistory.Name = "cmsItem8ShowPersonHistory";
            this.cmsItem8ShowPersonHistory.Size = new System.Drawing.Size(293, 26);
            this.cmsItem8ShowPersonHistory.Text = "Show Person License History";
            this.cmsItem8ShowPersonHistory.Click += new System.EventHandler(this.cmsItem8ShowPersonHistory_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1511, -16);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(578, 132);
            this.guna2ControlBox1.TabIndex = 24;
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.Transparent;
            this.backgroundPanel.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.backgroundPanel.Controls.Add(this.lblRecordsNumber);
            this.backgroundPanel.Controls.Add(this.txtFilterValue);
            this.backgroundPanel.Controls.Add(this.label5);
            this.backgroundPanel.Controls.Add(this.label6);
            this.backgroundPanel.Controls.Add(this.cbFilteredBy);
            this.backgroundPanel.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.backgroundPanel.Controls.Add(this.label1);
            this.backgroundPanel.Controls.Add(this.btnCancel);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(115)))));
            this.backgroundPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(10)))), ((int)(((byte)(203)))));
            this.backgroundPanel.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(29)))), ((int)(((byte)(228)))));
            this.backgroundPanel.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(72)))), ((int)(((byte)(255)))));
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(1110, 653);
            this.backgroundPanel.TabIndex = 25;
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplications.AllowUserToResizeColumns = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvLocalDrivingLicenseApplications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicenseApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(30)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeight = 30;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsApplications;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicenseApplications.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocalDrivingLicenseApplications.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(55, 147);
            this.dgvLocalDrivingLicenseApplications.MultiSelect = false;
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicenseApplications.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLocalDrivingLicenseApplications.RowHeadersVisible = false;
            this.dgvLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseApplications.RowTemplate.Height = 24;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1019, 435);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 19;
            this.dgvLocalDrivingLicenseApplications.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.DeepPurple;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(30)))), ((int)(((byte)(109)))));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.RowsStyle.Height = 24;
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.dgvLocalDrivingLicenseApplications.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            // txtFilterValue
            // 
            this.txtFilterValue.BorderRadius = 10;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtFilterValue.ForeColor = System.Drawing.Color.Gray;
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Location = new System.Drawing.Point(348, 90);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PlaceholderText = "";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(173, 26);
            this.txtFilterValue.TabIndex = 10;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(51, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Filter by";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(51, 612);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "# Records :";
            // 
            // cbFilteredBy
            // 
            this.cbFilteredBy.AutoRoundedCorners = true;
            this.cbFilteredBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFilteredBy.BorderColor = System.Drawing.Color.Transparent;
            this.cbFilteredBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilteredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilteredBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilteredBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilteredBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cbFilteredBy.ForeColor = System.Drawing.Color.Gray;
            this.cbFilteredBy.ItemHeight = 20;
            this.cbFilteredBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.ID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilteredBy.Location = new System.Drawing.Point(156, 90);
            this.cbFilteredBy.Name = "cbFilteredBy";
            this.cbFilteredBy.Size = new System.Drawing.Size(173, 26);
            this.cbFilteredBy.StartIndex = 0;
            this.cbFilteredBy.TabIndex = 4;
            this.cbFilteredBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbFilteredBy.SelectedIndexChanged += new System.EventHandler(this.cbFilteredBy_SelectedIndexChanged);
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewLocalDrivingLicenseApplication.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewLocalDrivingLicenseApplication.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewLocalDrivingLicenseApplication.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewLocalDrivingLicenseApplication.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewLocalDrivingLicenseApplication.FillColor = System.Drawing.Color.White;
            this.btnAddNewLocalDrivingLicenseApplication.FillColor2 = System.Drawing.Color.White;
            this.btnAddNewLocalDrivingLicenseApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddNewLocalDrivingLicenseApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(53)))), ((int)(((byte)(242)))));
            this.btnAddNewLocalDrivingLicenseApplication.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(842, 603);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(113, 32);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 6;
            this.btnAddNewLocalDrivingLicenseApplication.Tag = "0";
            this.btnAddNewLocalDrivingLicenseApplication.Text = "Add";
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(319, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License Applications";
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
            this.btnCancel.Location = new System.Drawing.Point(961, 603);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmManageLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1110, 653);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.guna2ControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmManageLocalDrivingLicenseApplication";
            this.Text = "FrmManageLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.FrmManageLDLA_Load);
            this.cmsApplications.ResumeLayout(false);
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem cmsItem1ShowApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator addNewPersonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsItem2EditApplication;
        private System.Windows.Forms.ToolStripMenuItem cmsItem3DeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem cmsItem4CancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmsItem5ScheduleTests;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel backgroundPanel;
        private System.Windows.Forms.Label lblRecordsNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilteredBy;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsItem6SIssueLicense;
        private System.Windows.Forms.ToolStripSeparator showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem7ShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem cmsItem8ShowPersonHistory;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}