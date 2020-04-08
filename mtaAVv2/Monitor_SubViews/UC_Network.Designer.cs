namespace Ladin.mtaAV.Monitor_SubViews
{
    partial class UC_Network
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlNetwork = new Guna.UI.WinForms.GunaPanel();
            this.gunaPanel3 = new Guna.UI.WinForms.GunaPanel();
            this.dgv_NetworkFile = new Guna.UI.WinForms.GunaDataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Virus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Scan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw = new Guna.UI.WinForms.GunaLabel();
            this.cbx_CardNetwork = new Guna.UI.WinForms.GunaComboBox();
            this.btn_CancelScan = new Guna.UI.WinForms.GunaButton();
            this.btn_PauseScan = new Guna.UI.WinForms.GunaButton();
            this.btn_Scan = new Guna.UI.WinForms.GunaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.btnDeleteFile = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel18 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel17 = new Guna.UI.WinForms.GunaLabel();
            this.gunaComboBox2 = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel16 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel15 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel14 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel13 = new Guna.UI.WinForms.GunaLabel();
            this.gunaMediumRadioButton3 = new Guna.UI.WinForms.GunaMediumRadioButton();
            this.gunaMediumRadioButton2 = new Guna.UI.WinForms.GunaMediumRadioButton();
            this.gunaMediumRadioButton1 = new Guna.UI.WinForms.GunaMediumRadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlNetwork.SuspendLayout();
            this.gunaPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NetworkFile)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNetwork
            // 
            this.pnlNetwork.BackColor = System.Drawing.Color.White;
            this.pnlNetwork.Controls.Add(this.gunaPanel3);
            this.pnlNetwork.Controls.Add(this.groupBox1);
            this.pnlNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNetwork.Location = new System.Drawing.Point(0, 0);
            this.pnlNetwork.Name = "pnlNetwork";
            this.pnlNetwork.Size = new System.Drawing.Size(935, 396);
            this.pnlNetwork.TabIndex = 24;
            // 
            // gunaPanel3
            // 
            this.gunaPanel3.Controls.Add(this.dgv_NetworkFile);
            this.gunaPanel3.Controls.Add(this.dw);
            this.gunaPanel3.Controls.Add(this.cbx_CardNetwork);
            this.gunaPanel3.Controls.Add(this.btn_CancelScan);
            this.gunaPanel3.Controls.Add(this.btn_PauseScan);
            this.gunaPanel3.Controls.Add(this.btn_Scan);
            this.gunaPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanel3.Location = new System.Drawing.Point(284, 0);
            this.gunaPanel3.Name = "gunaPanel3";
            this.gunaPanel3.Size = new System.Drawing.Size(651, 396);
            this.gunaPanel3.TabIndex = 23;
            // 
            // dgv_NetworkFile
            // 
            this.dgv_NetworkFile.AllowUserToAddRows = false;
            this.dgv_NetworkFile.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_NetworkFile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_NetworkFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_NetworkFile.BackgroundColor = System.Drawing.Color.White;
            this.dgv_NetworkFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_NetworkFile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_NetworkFile.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_NetworkFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_NetworkFile.ColumnHeadersHeight = 40;
            this.dgv_NetworkFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Virus,
            this.Type_Scan,
            this.Create_Date});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(219)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(135)))), ((int)(((byte)(125)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NetworkFile.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_NetworkFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_NetworkFile.EnableHeadersVisualStyles = false;
            this.dgv_NetworkFile.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(192)))), ((int)(((byte)(188)))));
            this.dgv_NetworkFile.Location = new System.Drawing.Point(0, 66);
            this.dgv_NetworkFile.Name = "dgv_NetworkFile";
            this.dgv_NetworkFile.ReadOnly = true;
            this.dgv_NetworkFile.RowHeadersVisible = false;
            this.dgv_NetworkFile.RowTemplate.Height = 40;
            this.dgv_NetworkFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_NetworkFile.Size = new System.Drawing.Size(651, 330);
            this.dgv_NetworkFile.TabIndex = 28;
            this.dgv_NetworkFile.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Alizarin;
            this.dgv_NetworkFile.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(197)))));
            this.dgv_NetworkFile.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_NetworkFile.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_NetworkFile.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_NetworkFile.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_NetworkFile.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_NetworkFile.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(192)))), ((int)(((byte)(188)))));
            this.dgv_NetworkFile.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.dgv_NetworkFile.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_NetworkFile.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_NetworkFile.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_NetworkFile.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_NetworkFile.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_NetworkFile.ThemeStyle.ReadOnly = true;
            this.dgv_NetworkFile.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(219)))), ((int)(((byte)(216)))));
            this.dgv_NetworkFile.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_NetworkFile.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_NetworkFile.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_NetworkFile.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_NetworkFile.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(135)))), ((int)(((byte)(125)))));
            this.dgv_NetworkFile.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            // dw
            // 
            this.dw.AutoSize = true;
            this.dw.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dw.Location = new System.Drawing.Point(162, 23);
            this.dw.Name = "dw";
            this.dw.Size = new System.Drawing.Size(145, 23);
            this.dw.TabIndex = 27;
            this.dw.Text = "Chọn Card mạng:";
            // 
            // cbx_CardNetwork
            // 
            this.cbx_CardNetwork.BackColor = System.Drawing.Color.Transparent;
            this.cbx_CardNetwork.BaseColor = System.Drawing.Color.White;
            this.cbx_CardNetwork.BorderColor = System.Drawing.Color.Silver;
            this.cbx_CardNetwork.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_CardNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_CardNetwork.FocusedColor = System.Drawing.Color.Empty;
            this.cbx_CardNetwork.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbx_CardNetwork.ForeColor = System.Drawing.Color.Black;
            this.cbx_CardNetwork.FormattingEnabled = true;
            this.cbx_CardNetwork.Location = new System.Drawing.Point(319, 20);
            this.cbx_CardNetwork.Name = "cbx_CardNetwork";
            this.cbx_CardNetwork.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbx_CardNetwork.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbx_CardNetwork.Size = new System.Drawing.Size(319, 31);
            this.cbx_CardNetwork.TabIndex = 26;
            // 
            // btn_CancelScan
            // 
            this.btn_CancelScan.AnimationHoverSpeed = 0.07F;
            this.btn_CancelScan.AnimationSpeed = 0.03F;
            this.btn_CancelScan.BaseColor = System.Drawing.Color.White;
            this.btn_CancelScan.BorderColor = System.Drawing.Color.Black;
            this.btn_CancelScan.BorderSize = 1;
            this.btn_CancelScan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_CancelScan.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_CancelScan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelScan.ForeColor = System.Drawing.Color.DimGray;
            this.btn_CancelScan.Image = global::Ladin.mtaAV.Properties.Resources.Cancel_48px;
            this.btn_CancelScan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_CancelScan.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_CancelScan.Location = new System.Drawing.Point(106, 18);
            this.btn_CancelScan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CancelScan.Name = "btn_CancelScan";
            this.btn_CancelScan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_CancelScan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_CancelScan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_CancelScan.OnHoverImage = null;
            this.btn_CancelScan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_CancelScan.Size = new System.Drawing.Size(40, 40);
            this.btn_CancelScan.TabIndex = 25;
            this.btn_CancelScan.Click += new System.EventHandler(this.btn_CancelScan_Click);
            // 
            // btn_PauseScan
            // 
            this.btn_PauseScan.AnimationHoverSpeed = 0.07F;
            this.btn_PauseScan.AnimationSpeed = 0.03F;
            this.btn_PauseScan.BaseColor = System.Drawing.Color.White;
            this.btn_PauseScan.BorderColor = System.Drawing.Color.Black;
            this.btn_PauseScan.BorderSize = 1;
            this.btn_PauseScan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_PauseScan.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_PauseScan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PauseScan.ForeColor = System.Drawing.Color.DimGray;
            this.btn_PauseScan.Image = global::Ladin.mtaAV.Properties.Resources.Stop_Squared_48px;
            this.btn_PauseScan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_PauseScan.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_PauseScan.Location = new System.Drawing.Point(62, 18);
            this.btn_PauseScan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PauseScan.Name = "btn_PauseScan";
            this.btn_PauseScan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_PauseScan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_PauseScan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_PauseScan.OnHoverImage = null;
            this.btn_PauseScan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_PauseScan.Size = new System.Drawing.Size(40, 40);
            this.btn_PauseScan.TabIndex = 24;
            this.btn_PauseScan.Click += new System.EventHandler(this.btn_PauseScan_Click);
            // 
            // btn_Scan
            // 
            this.btn_Scan.AnimationHoverSpeed = 0.07F;
            this.btn_Scan.AnimationSpeed = 0.03F;
            this.btn_Scan.BaseColor = System.Drawing.Color.White;
            this.btn_Scan.BorderColor = System.Drawing.Color.Black;
            this.btn_Scan.BorderSize = 1;
            this.btn_Scan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Scan.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Scan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Scan.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Scan.Image = global::Ladin.mtaAV.Properties.Resources.Play_48px;
            this.btn_Scan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Scan.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Scan.Location = new System.Drawing.Point(16, 18);
            this.btn_Scan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Scan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Scan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Scan.OnHoverImage = null;
            this.btn_Scan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Scan.Size = new System.Drawing.Size(40, 40);
            this.btn_Scan.TabIndex = 23;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.gunaPanel1);
            this.groupBox1.Controls.Add(this.gunaLabel18);
            this.groupBox1.Controls.Add(this.gunaLabel17);
            this.groupBox1.Controls.Add(this.gunaComboBox2);
            this.groupBox1.Controls.Add(this.gunaLabel16);
            this.groupBox1.Controls.Add(this.gunaLabel15);
            this.groupBox1.Controls.Add(this.gunaLabel14);
            this.groupBox1.Controls.Add(this.gunaLabel13);
            this.groupBox1.Controls.Add(this.gunaMediumRadioButton3);
            this.groupBox1.Controls.Add(this.gunaMediumRadioButton2);
            this.groupBox1.Controls.Add(this.gunaMediumRadioButton1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 396);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình";
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.Controls.Add(this.btnDeleteFile);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gunaPanel1.Location = new System.Drawing.Point(3, 351);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(278, 42);
            this.gunaPanel1.TabIndex = 29;
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.AnimationHoverSpeed = 0.07F;
            this.btnDeleteFile.AnimationSpeed = 0.03F;
            this.btnDeleteFile.BaseColor = System.Drawing.Color.White;
            this.btnDeleteFile.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteFile.BorderSize = 1;
            this.btnDeleteFile.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteFile.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteFile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFile.ForeColor = System.Drawing.Color.DimGray;
            this.btnDeleteFile.Image = global::Ladin.mtaAV.Properties.Resources.Cancel_48px;
            this.btnDeleteFile.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDeleteFile.Location = new System.Drawing.Point(76, 0);
            this.btnDeleteFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDeleteFile.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDeleteFile.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDeleteFile.OnHoverImage = null;
            this.btnDeleteFile.OnPressedColor = System.Drawing.Color.Black;
            this.btnDeleteFile.Size = new System.Drawing.Size(202, 42);
            this.btnDeleteFile.TabIndex = 18;
            this.btnDeleteFile.Text = "Xóa dữ liệu";
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // gunaLabel18
            // 
            this.gunaLabel18.AutoSize = true;
            this.gunaLabel18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel18.Location = new System.Drawing.Point(6, 129);
            this.gunaLabel18.Name = "gunaLabel18";
            this.gunaLabel18.Size = new System.Drawing.Size(132, 23);
            this.gunaLabel18.TabIndex = 28;
            this.gunaLabel18.Text = "Chọn giao thức:";
            // 
            // gunaLabel17
            // 
            this.gunaLabel17.AutoSize = true;
            this.gunaLabel17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel17.Location = new System.Drawing.Point(246, 60);
            this.gunaLabel17.Name = "gunaLabel17";
            this.gunaLabel17.Size = new System.Drawing.Size(35, 23);
            this.gunaLabel17.TabIndex = 27;
            this.gunaLabel17.Text = "MB";
            // 
            // gunaComboBox2
            // 
            this.gunaComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox2.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox2.BorderColor = System.Drawing.Color.Silver;
            this.gunaComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaComboBox2.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox2.FormattingEnabled = true;
            this.gunaComboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10"});
            this.gunaComboBox2.Location = new System.Drawing.Point(166, 52);
            this.gunaComboBox2.Name = "gunaComboBox2";
            this.gunaComboBox2.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaComboBox2.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox2.Size = new System.Drawing.Size(74, 31);
            this.gunaComboBox2.TabIndex = 26;
            // 
            // gunaLabel16
            // 
            this.gunaLabel16.AutoSize = true;
            this.gunaLabel16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel16.Location = new System.Drawing.Point(3, 55);
            this.gunaLabel16.Name = "gunaLabel16";
            this.gunaLabel16.Size = new System.Drawing.Size(154, 23);
            this.gunaLabel16.TabIndex = 25;
            this.gunaLabel16.Text = "Dung lượng tối đa:";
            // 
            // gunaLabel15
            // 
            this.gunaLabel15.AutoSize = true;
            this.gunaLabel15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel15.Location = new System.Drawing.Point(63, 230);
            this.gunaLabel15.Name = "gunaLabel15";
            this.gunaLabel15.Size = new System.Drawing.Size(58, 20);
            this.gunaLabel15.TabIndex = 24;
            this.gunaLabel15.Text = "Smb v2";
            // 
            // gunaLabel14
            // 
            this.gunaLabel14.AutoSize = true;
            this.gunaLabel14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel14.Location = new System.Drawing.Point(63, 198);
            this.gunaLabel14.Name = "gunaLabel14";
            this.gunaLabel14.Size = new System.Drawing.Size(30, 20);
            this.gunaLabel14.TabIndex = 23;
            this.gunaLabel14.Text = "Ftp";
            // 
            // gunaLabel13
            // 
            this.gunaLabel13.AutoSize = true;
            this.gunaLabel13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel13.Location = new System.Drawing.Point(63, 169);
            this.gunaLabel13.Name = "gunaLabel13";
            this.gunaLabel13.Size = new System.Drawing.Size(39, 20);
            this.gunaLabel13.TabIndex = 22;
            this.gunaLabel13.Text = "Http";
            // 
            // gunaMediumRadioButton3
            // 
            this.gunaMediumRadioButton3.BaseColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton3.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaMediumRadioButton3.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaMediumRadioButton3.FillColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton3.Location = new System.Drawing.Point(34, 198);
            this.gunaMediumRadioButton3.Name = "gunaMediumRadioButton3";
            this.gunaMediumRadioButton3.Size = new System.Drawing.Size(20, 20);
            this.gunaMediumRadioButton3.TabIndex = 21;
            // 
            // gunaMediumRadioButton2
            // 
            this.gunaMediumRadioButton2.BaseColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton2.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaMediumRadioButton2.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaMediumRadioButton2.FillColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton2.Location = new System.Drawing.Point(34, 230);
            this.gunaMediumRadioButton2.Name = "gunaMediumRadioButton2";
            this.gunaMediumRadioButton2.Size = new System.Drawing.Size(20, 20);
            this.gunaMediumRadioButton2.TabIndex = 20;
            // 
            // gunaMediumRadioButton1
            // 
            this.gunaMediumRadioButton1.BaseColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton1.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaMediumRadioButton1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaMediumRadioButton1.FillColor = System.Drawing.Color.White;
            this.gunaMediumRadioButton1.Location = new System.Drawing.Point(34, 169);
            this.gunaMediumRadioButton1.Name = "gunaMediumRadioButton1";
            this.gunaMediumRadioButton1.Size = new System.Drawing.Size(20, 20);
            this.gunaMediumRadioButton1.TabIndex = 19;
            // 
            // UC_Network
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlNetwork);
            this.Name = "UC_Network";
            this.Size = new System.Drawing.Size(935, 396);
            this.pnlNetwork.ResumeLayout(false);
            this.gunaPanel3.ResumeLayout(false);
            this.gunaPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NetworkFile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gunaPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel pnlNetwork;
        private Guna.UI.WinForms.GunaPanel gunaPanel3;
        private Guna.UI.WinForms.GunaDataGridView dgv_NetworkFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Virus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Scan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Date;
        private Guna.UI.WinForms.GunaLabel dw;
        private Guna.UI.WinForms.GunaComboBox cbx_CardNetwork;
        private Guna.UI.WinForms.GunaButton btn_CancelScan;
        private Guna.UI.WinForms.GunaButton btn_PauseScan;
        private Guna.UI.WinForms.GunaButton btn_Scan;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI.WinForms.GunaLabel gunaLabel18;
        private Guna.UI.WinForms.GunaLabel gunaLabel17;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox2;
        private Guna.UI.WinForms.GunaLabel gunaLabel16;
        private Guna.UI.WinForms.GunaLabel gunaLabel15;
        private Guna.UI.WinForms.GunaLabel gunaLabel14;
        private Guna.UI.WinForms.GunaLabel gunaLabel13;
        private Guna.UI.WinForms.GunaMediumRadioButton gunaMediumRadioButton3;
        private Guna.UI.WinForms.GunaMediumRadioButton gunaMediumRadioButton2;
        private Guna.UI.WinForms.GunaMediumRadioButton gunaMediumRadioButton1;
        private Guna.UI.WinForms.GunaButton btnDeleteFile;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}
