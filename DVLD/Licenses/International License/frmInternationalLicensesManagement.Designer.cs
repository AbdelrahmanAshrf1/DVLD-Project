namespace DVLD.Licenses.International_License
{
    partial class frmInternationalLicensesManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInternationalLicensesManagement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddNewInternationalLicense = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.cbFilteredBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsInternationalLicense = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.cmsShowPersonDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvInternationalLicensesInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.backgroundPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.cmsInternationalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesInfo)).BeginInit();
            this.backgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNewInternationalLicense
            // 
            this.btnAddNewInternationalLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewInternationalLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewInternationalLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewInternationalLicense.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewInternationalLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewInternationalLicense.FillColor = System.Drawing.Color.White;
            this.btnAddNewInternationalLicense.FillColor2 = System.Drawing.Color.White;
            this.btnAddNewInternationalLicense.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddNewInternationalLicense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(53)))), ((int)(((byte)(242)))));
            this.btnAddNewInternationalLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewInternationalLicense.Location = new System.Drawing.Point(841, 603);
            this.btnAddNewInternationalLicense.Name = "btnAddNewInternationalLicense";
            this.btnAddNewInternationalLicense.Size = new System.Drawing.Size(113, 32);
            this.btnAddNewInternationalLicense.TabIndex = 25;
            this.btnAddNewInternationalLicense.Tag = "0";
            this.btnAddNewInternationalLicense.Text = "Add";
            this.btnAddNewInternationalLicense.Click += new System.EventHandler(this.btnAddNewInternationalLicense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(391, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 49);
            this.label1.TabIndex = 23;
            this.label1.Text = "International Licenses";
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
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1519, -2);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(107, 82);
            this.guna2ControlBox1.TabIndex = 23;
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
            "Int.License ID",
            "Application ID",
            "Driver ID",
            "L.License ID",
            "Issue Date",
            "Expiration Date",
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
            // cmsInternationalLicense
            // 
            this.cmsInternationalLicense.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsShowPersonDetailsItem,
            this.cmsShowLicenseDetails,
            this.editToolStripMenuItem1});
            this.cmsInternationalLicense.Name = "cmsPeople";
            this.cmsInternationalLicense.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsInternationalLicense.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsInternationalLicense.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsInternationalLicense.RenderStyle.ColorTable = null;
            this.cmsInternationalLicense.RenderStyle.RoundedEdges = true;
            this.cmsInternationalLicense.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsInternationalLicense.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsInternationalLicense.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsInternationalLicense.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsInternationalLicense.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsInternationalLicense.Size = new System.Drawing.Size(269, 82);
            // 
            // cmsShowPersonDetailsItem
            // 
            this.cmsShowPersonDetailsItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsShowPersonDetailsItem.Image = ((System.Drawing.Image)(resources.GetObject("cmsShowPersonDetailsItem.Image")));
            this.cmsShowPersonDetailsItem.Name = "cmsShowPersonDetailsItem";
            this.cmsShowPersonDetailsItem.Size = new System.Drawing.Size(268, 26);
            this.cmsShowPersonDetailsItem.Text = "Show Person Details";
            this.cmsShowPersonDetailsItem.Click += new System.EventHandler(this.cmsShowPersonDetailsItem_Click);
            // 
            // cmsShowLicenseDetails
            // 
            this.cmsShowLicenseDetails.Image = ((System.Drawing.Image)(resources.GetObject("cmsShowLicenseDetails.Image")));
            this.cmsShowLicenseDetails.Name = "cmsShowLicenseDetails";
            this.cmsShowLicenseDetails.Size = new System.Drawing.Size(268, 26);
            this.cmsShowLicenseDetails.Tag = "0";
            this.cmsShowLicenseDetails.Text = "Show License Details";
            this.cmsShowLicenseDetails.Click += new System.EventHandler(this.cmsShowLicenseDetails_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem1.Image")));
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(268, 26);
            this.editToolStripMenuItem1.Tag = "1";
            this.editToolStripMenuItem1.Text = "Show Person License History";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // dgvInternationalLicensesInfo
            // 
            this.dgvInternationalLicensesInfo.AllowUserToAddRows = false;
            this.dgvInternationalLicensesInfo.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesInfo.AllowUserToOrderColumns = true;
            this.dgvInternationalLicensesInfo.AllowUserToResizeColumns = false;
            this.dgvInternationalLicensesInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvInternationalLicensesInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInternationalLicensesInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(30)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicensesInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalLicensesInfo.ColumnHeadersHeight = 30;
            this.dgvInternationalLicensesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvInternationalLicensesInfo.ContextMenuStrip = this.cmsInternationalLicense;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLicensesInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInternationalLicensesInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.dgvInternationalLicensesInfo.Location = new System.Drawing.Point(54, 148);
            this.dgvInternationalLicensesInfo.MultiSelect = false;
            this.dgvInternationalLicensesInfo.Name = "dgvInternationalLicensesInfo";
            this.dgvInternationalLicensesInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicensesInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalLicensesInfo.RowHeadersVisible = false;
            this.dgvInternationalLicensesInfo.RowHeadersWidth = 51;
            this.dgvInternationalLicensesInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInternationalLicensesInfo.RowTemplate.Height = 24;
            this.dgvInternationalLicensesInfo.Size = new System.Drawing.Size(1019, 435);
            this.dgvInternationalLicensesInfo.TabIndex = 24;
            this.dgvInternationalLicensesInfo.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.DeepPurple;
            this.dgvInternationalLicensesInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.dgvInternationalLicensesInfo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvInternationalLicensesInfo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvInternationalLicensesInfo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvInternationalLicensesInfo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvInternationalLicensesInfo.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(30)))), ((int)(((byte)(109)))));
            this.dgvInternationalLicensesInfo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.dgvInternationalLicensesInfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.dgvInternationalLicensesInfo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInternationalLicensesInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            this.dgvInternationalLicensesInfo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInternationalLicensesInfo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvInternationalLicensesInfo.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvInternationalLicensesInfo.ThemeStyle.ReadOnly = true;
            this.dgvInternationalLicensesInfo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.dgvInternationalLicensesInfo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInternationalLicensesInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F);
            this.dgvInternationalLicensesInfo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInternationalLicensesInfo.ThemeStyle.RowsStyle.Height = 24;
            this.dgvInternationalLicensesInfo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.dgvInternationalLicensesInfo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            this.txtFilterBy.Location = new System.Drawing.Point(348, 91);
            this.txtFilterBy.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.PlaceholderText = "";
            this.txtFilterBy.SelectedText = "";
            this.txtFilterBy.Size = new System.Drawing.Size(173, 26);
            this.txtFilterBy.TabIndex = 20;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.Controls.Add(this.btnAddNewInternationalLicense);
            this.backgroundPanel.Controls.Add(this.btnCancel);
            this.backgroundPanel.Controls.Add(this.dgvInternationalLicensesInfo);
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
            this.backgroundPanel.TabIndex = 25;
            // 
            // frmInternationalLicensesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1110, 653);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.backgroundPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInternationalLicensesManagement";
            this.Text = "frmInternationalLicensesManagement";
            this.Load += new System.EventHandler(this.frmInternationalLicensesManagement_Load);
            this.cmsInternationalLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesInfo)).EndInit();
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnAddNewInternationalLicense;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsActive;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilteredBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonDetailsItem;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsInternationalLicense;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInternationalLicensesInfo;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterBy;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel backgroundPanel;
    }
}