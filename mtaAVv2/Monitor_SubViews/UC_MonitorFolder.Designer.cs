namespace Ladin.mtaAV.Monitor_SubViews
{
    partial class UC_MonitorFolder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_FileDetect = new Guna.UI.WinForms.GunaDataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Virus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Scan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.dgv_Folder = new Guna.UI.WinForms.GunaDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SelectFolder = new Guna.UI.WinForms.GunaButton();
            this.ck_Shortcut = new Guna.UI.WinForms.GunaMediumRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName_Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_DeleteFolder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gunaMediumRadioButton1 = new Guna.UI.WinForms.GunaMediumRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FileDetect)).BeginInit();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Folder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_FileDetect
            // 
            this.dgv_FileDetect.AllowUserToAddRows = false;
            this.dgv_FileDetect.AllowUserToDeleteRows = false;
            this.dgv_FileDetect.AllowUserToOrderColumns = true;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_FileDetect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dgv_FileDetect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_FileDetect.BackgroundColor = System.Drawing.Color.White;
            this.dgv_FileDetect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_FileDetect.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_FileDetect.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FileDetect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgv_FileDetect.ColumnHeadersHeight = 40;
            this.dgv_FileDetect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Virus,
            this.Type_Scan,
            this.Create_Date});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(219)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(135)))), ((int)(((byte)(125)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FileDetect.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgv_FileDetect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_FileDetect.EnableHeadersVisualStyles = false;
            this.dgv_FileDetect.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(192)))), ((int)(((byte)(188)))));
            this.dgv_FileDetect.Location = new System.Drawing.Point(0, 158);
            this.dgv_FileDetect.Name = "dgv_FileDetect";
            this.dgv_FileDetect.ReadOnly = true;
            this.dgv_FileDetect.RowHeadersVisible = false;
            this.dgv_FileDetect.RowTemplate.Height = 40;
            this.dgv_FileDetect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FileDetect.Size = new System.Drawing.Size(935, 238);
            this.dgv_FileDetect.TabIndex = 31;
            this.dgv_FileDetect.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Alizarin;
            this.dgv_FileDetect.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(197)))));
            this.dgv_FileDetect.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_FileDetect.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_FileDetect.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_FileDetect.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_FileDetect.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_FileDetect.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(192)))), ((int)(((byte)(188)))));
            this.dgv_FileDetect.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.dgv_FileDetect.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_FileDetect.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_FileDetect.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_FileDetect.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_FileDetect.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_FileDetect.ThemeStyle.ReadOnly = true;
            this.dgv_FileDetect.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(219)))), ((int)(((byte)(216)))));
            this.dgv_FileDetect.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_FileDetect.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_FileDetect.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_FileDetect.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_FileDetect.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(135)))), ((int)(((byte)(125)))));
            this.dgv_FileDetect.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FILENAME";
            this.FileName.HeaderText = "Tên file";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Virus
            // 
            this.Virus.DataPropertyName = "VIRUS";
            this.Virus.HeaderText = "Loại mã độc";
            this.Virus.Name = "Virus";
            this.Virus.ReadOnly = true;
            this.Virus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Virus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Type_Scan
            // 
            this.Type_Scan.DataPropertyName = "TYPE_SCAN";
            this.Type_Scan.HeaderText = "Kiểu quét";
            this.Type_Scan.Name = "Type_Scan";
            this.Type_Scan.ReadOnly = true;
            // 
            // Create_Date
            // 
            this.Create_Date.DataPropertyName = "CREATE_DATE";
            this.Create_Date.HeaderText = "Thời gian";
            this.Create_Date.Name = "Create_Date";
            this.Create_Date.ReadOnly = true;
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.Controls.Add(this.groupBox1);
            this.gunaPanel1.Controls.Add(this.dgv_Folder);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(935, 158);
            this.gunaPanel1.TabIndex = 32;
            // 
            // dgv_Folder
            // 
            this.dgv_Folder.AllowUserToAddRows = false;
            this.dgv_Folder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(203)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Folder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgv_Folder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Folder.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Folder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Folder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Folder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Folder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgv_Folder.ColumnHeadersHeight = 40;
            this.dgv_Folder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FileName_Folder,
            this.btn_DeleteFolder});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(239)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(201)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Folder.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgv_Folder.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv_Folder.EnableHeadersVisualStyles = false;
            this.dgv_Folder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(231)))), ((int)(((byte)(201)))));
            this.dgv_Folder.Location = new System.Drawing.Point(274, 0);
            this.dgv_Folder.Name = "dgv_Folder";
            this.dgv_Folder.ReadOnly = true;
            this.dgv_Folder.RowHeadersVisible = false;
            this.dgv_Folder.RowTemplate.Height = 40;
            this.dgv_Folder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Folder.Size = new System.Drawing.Size(661, 158);
            this.dgv_Folder.TabIndex = 33;
            this.dgv_Folder.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Green;
            this.dgv_Folder.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(203)))));
            this.dgv_Folder.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Folder.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_Folder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_Folder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_Folder.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Folder.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(231)))), ((int)(((byte)(201)))));
            this.dgv_Folder.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.dgv_Folder.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_Folder.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Folder.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_Folder.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_Folder.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_Folder.ThemeStyle.ReadOnly = true;
            this.dgv_Folder.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(239)))), ((int)(((byte)(220)))));
            this.dgv_Folder.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Folder.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Folder.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_Folder.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_Folder.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(201)))), ((int)(((byte)(138)))));
            this.dgv_Folder.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Folder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Folder_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gunaMediumRadioButton1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ck_Shortcut);
            this.groupBox1.Controls.Add(this.gunaButton1);
            this.groupBox1.Controls.Add(this.btn_SelectFolder);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 158);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình";
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.AnimationHoverSpeed = 0.07F;
            this.btn_SelectFolder.AnimationSpeed = 0.03F;
            this.btn_SelectFolder.BaseColor = System.Drawing.Color.White;
            this.btn_SelectFolder.BorderColor = System.Drawing.Color.Black;
            this.btn_SelectFolder.BorderSize = 1;
            this.btn_SelectFolder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_SelectFolder.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_SelectFolder.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SelectFolder.ForeColor = System.Drawing.Color.DimGray;
            this.btn_SelectFolder.Image = global::Ladin.mtaAV.Properties.Resources.Delete_Bin_48px;
            this.btn_SelectFolder.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_SelectFolder.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_SelectFolder.Location = new System.Drawing.Point(195, 98);
            this.btn_SelectFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.OnHoverBaseColor = System.Drawing.Color.MistyRose;
            this.btn_SelectFolder.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_SelectFolder.OnHoverForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_SelectFolder.OnHoverImage = null;
            this.btn_SelectFolder.OnPressedColor = System.Drawing.Color.MistyRose;
            this.btn_SelectFolder.OnPressedDepth = 0;
            this.btn_SelectFolder.Size = new System.Drawing.Size(64, 45);
            this.btn_SelectFolder.TabIndex = 25;
            this.btn_SelectFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_SelectFolder.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // ck_Shortcut
            // 
            this.ck_Shortcut.BaseColor = System.Drawing.Color.White;
            this.ck_Shortcut.CheckedOffColor = System.Drawing.Color.Gray;
            this.ck_Shortcut.CheckedOnColor = System.Drawing.Color.PaleGreen;
            this.ck_Shortcut.FillColor = System.Drawing.Color.White;
            this.ck_Shortcut.Location = new System.Drawing.Point(30, 34);
            this.ck_Shortcut.Name = "ck_Shortcut";
            this.ck_Shortcut.Size = new System.Drawing.Size(20, 20);
            this.ck_Shortcut.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Phát hiện shortcut";
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BaseColor = System.Drawing.Color.White;
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.BorderSize = 1;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton1.ForeColor = System.Drawing.Color.DimGray;
            this.gunaButton1.Image = global::Ladin.mtaAV.Properties.Resources.Opened_Folder_48px;
            this.gunaButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.ImageSize = new System.Drawing.Size(40, 40);
            this.gunaButton1.Location = new System.Drawing.Point(125, 98);
            this.gunaButton1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.MistyRose;
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.MistyRose;
            this.gunaButton1.OnPressedDepth = 0;
            this.gunaButton1.Size = new System.Drawing.Size(55, 45);
            this.gunaButton1.TabIndex = 26;
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gunaButton1.Click += new System.EventHandler(this.btn_SelectFolder_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // FileName_Folder
            // 
            this.FileName_Folder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName_Folder.DataPropertyName = "FILENAME";
            this.FileName_Folder.FillWeight = 118.7817F;
            this.FileName_Folder.HeaderText = "Tên đường dẫn";
            this.FileName_Folder.Name = "FileName_Folder";
            this.FileName_Folder.ReadOnly = true;
            // 
            // btn_DeleteFolder
            // 
            this.btn_DeleteFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Red;
            this.btn_DeleteFolder.DefaultCellStyle = dataGridViewCellStyle27;
            this.btn_DeleteFolder.FillWeight = 81.21826F;
            this.btn_DeleteFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteFolder.HeaderText = "Xóa";
            this.btn_DeleteFolder.Name = "btn_DeleteFolder";
            this.btn_DeleteFolder.ReadOnly = true;
            this.btn_DeleteFolder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btn_DeleteFolder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btn_DeleteFolder.Text = "X";
            this.btn_DeleteFolder.UseColumnTextForButtonValue = true;
            this.btn_DeleteFolder.Width = 80;
            // 
            // gunaMediumRadioButton1
            // 
            this.gunaMediumRadioButton1.BaseColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton1.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaMediumRadioButton1.CheckedOnColor = System.Drawing.Color.PaleGreen;
            this.gunaMediumRadioButton1.FillColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton1.Location = new System.Drawing.Point(30, 63);
            this.gunaMediumRadioButton1.Name = "gunaMediumRadioButton1";
            this.gunaMediumRadioButton1.Size = new System.Drawing.Size(20, 20);
            this.gunaMediumRadioButton1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Không chọn";
            // 
            // UC_MonitorFolder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.dgv_FileDetect);
            this.Name = "UC_MonitorFolder";
            this.Size = new System.Drawing.Size(935, 396);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FileDetect)).EndInit();
            this.gunaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Folder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaDataGridView dgv_FileDetect;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Virus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Scan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Date;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI.WinForms.GunaDataGridView dgv_Folder;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Guna.UI.WinForms.GunaButton btn_SelectFolder;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaMediumRadioButton ck_Shortcut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName_Folder;
        private System.Windows.Forms.DataGridViewButtonColumn btn_DeleteFolder;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaMediumRadioButton gunaMediumRadioButton1;
    }
}
