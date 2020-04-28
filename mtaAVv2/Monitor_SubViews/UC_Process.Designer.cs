namespace Ladin.mtaAV.Monitor_SubViews
{
    partial class UC_Process
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_MonitorProcess = new Guna.UI.WinForms.GunaDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CancelScan = new Guna.UI.WinForms.GunaButton();
            this.btn_PauseScan = new Guna.UI.WinForms.GunaButton();
            this.btn_Scan = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel17 = new Guna.UI.WinForms.GunaLabel();
            this.cbx_LimitSize = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel16 = new Guna.UI.WinForms.GunaLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Virus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Scan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_File = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_DeleteFile = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MonitorProcess)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_MonitorProcess
            // 
            this.dgv_MonitorProcess.AllowUserToAddRows = false;
            this.dgv_MonitorProcess.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_MonitorProcess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_MonitorProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_MonitorProcess.BackgroundColor = System.Drawing.Color.White;
            this.dgv_MonitorProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_MonitorProcess.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_MonitorProcess.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MonitorProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_MonitorProcess.ColumnHeadersHeight = 40;
            this.dgv_MonitorProcess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Virus,
            this.Type_Scan,
            this.Create_Date,
            this.Check_File,
            this.btn_DeleteFile});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MonitorProcess.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_MonitorProcess.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_MonitorProcess.EnableHeadersVisualStyles = false;
            this.dgv_MonitorProcess.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_MonitorProcess.Location = new System.Drawing.Point(0, 71);
            this.dgv_MonitorProcess.Name = "dgv_MonitorProcess";
            this.dgv_MonitorProcess.ReadOnly = true;
            this.dgv_MonitorProcess.RowHeadersVisible = false;
            this.dgv_MonitorProcess.RowTemplate.Height = 40;
            this.dgv_MonitorProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_MonitorProcess.Size = new System.Drawing.Size(935, 325);
            this.dgv_MonitorProcess.TabIndex = 29;
            this.dgv_MonitorProcess.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.LightGrid;
            this.dgv_MonitorProcess.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_MonitorProcess.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_MonitorProcess.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_MonitorProcess.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_MonitorProcess.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_MonitorProcess.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_MonitorProcess.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_MonitorProcess.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.dgv_MonitorProcess.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_MonitorProcess.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_MonitorProcess.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_MonitorProcess.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_MonitorProcess.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_MonitorProcess.ThemeStyle.ReadOnly = true;
            this.dgv_MonitorProcess.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_MonitorProcess.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_MonitorProcess.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_MonitorProcess.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_MonitorProcess.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_MonitorProcess.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_MonitorProcess.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_MonitorProcess.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MonitorProcess_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_CancelScan);
            this.panel1.Controls.Add(this.btn_PauseScan);
            this.panel1.Controls.Add(this.btn_Scan);
            this.panel1.Controls.Add(this.gunaLabel17);
            this.panel1.Controls.Add(this.cbx_LimitSize);
            this.panel1.Controls.Add(this.gunaLabel16);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 71);
            this.panel1.TabIndex = 30;
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
            this.btn_CancelScan.Location = new System.Drawing.Point(746, 16);
            this.btn_CancelScan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CancelScan.Name = "btn_CancelScan";
            this.btn_CancelScan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_CancelScan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_CancelScan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_CancelScan.OnHoverImage = null;
            this.btn_CancelScan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_CancelScan.Size = new System.Drawing.Size(40, 40);
            this.btn_CancelScan.TabIndex = 33;
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
            this.btn_PauseScan.Location = new System.Drawing.Point(693, 16);
            this.btn_PauseScan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PauseScan.Name = "btn_PauseScan";
            this.btn_PauseScan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_PauseScan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_PauseScan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_PauseScan.OnHoverImage = null;
            this.btn_PauseScan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_PauseScan.Size = new System.Drawing.Size(40, 40);
            this.btn_PauseScan.TabIndex = 32;
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
            this.btn_Scan.Location = new System.Drawing.Point(638, 16);
            this.btn_Scan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Scan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Scan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Scan.OnHoverImage = null;
            this.btn_Scan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Scan.Size = new System.Drawing.Size(40, 40);
            this.btn_Scan.TabIndex = 31;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // gunaLabel17
            // 
            this.gunaLabel17.AutoSize = true;
            this.gunaLabel17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel17.Location = new System.Drawing.Point(258, 28);
            this.gunaLabel17.Name = "gunaLabel17";
            this.gunaLabel17.Size = new System.Drawing.Size(35, 23);
            this.gunaLabel17.TabIndex = 30;
            this.gunaLabel17.Text = "MB";
            // 
            // cbx_LimitSize
            // 
            this.cbx_LimitSize.BackColor = System.Drawing.Color.Transparent;
            this.cbx_LimitSize.BaseColor = System.Drawing.Color.White;
            this.cbx_LimitSize.BorderColor = System.Drawing.Color.Silver;
            this.cbx_LimitSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_LimitSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_LimitSize.FocusedColor = System.Drawing.Color.Empty;
            this.cbx_LimitSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbx_LimitSize.ForeColor = System.Drawing.Color.Black;
            this.cbx_LimitSize.FormattingEnabled = true;
            this.cbx_LimitSize.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.cbx_LimitSize.Location = new System.Drawing.Point(178, 25);
            this.cbx_LimitSize.Name = "cbx_LimitSize";
            this.cbx_LimitSize.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbx_LimitSize.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbx_LimitSize.Size = new System.Drawing.Size(74, 31);
            this.cbx_LimitSize.TabIndex = 29;
            // 
            // gunaLabel16
            // 
            this.gunaLabel16.AutoSize = true;
            this.gunaLabel16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel16.Location = new System.Drawing.Point(18, 28);
            this.gunaLabel16.Name = "gunaLabel16";
            this.gunaLabel16.Size = new System.Drawing.Size(154, 23);
            this.gunaLabel16.TabIndex = 28;
            this.gunaLabel16.Text = "Dung lượng tối đa:";
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Tên file";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Virus
            // 
            this.Virus.HeaderText = "Loại mã độc";
            this.Virus.Name = "Virus";
            this.Virus.ReadOnly = true;
            this.Virus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Virus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Type_Scan
            // 
            this.Type_Scan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Type_Scan.HeaderText = "Kiểu quét";
            this.Type_Scan.Name = "Type_Scan";
            this.Type_Scan.ReadOnly = true;
            // 
            // Create_Date
            // 
            this.Create_Date.HeaderText = "Thời gian";
            this.Create_Date.Name = "Create_Date";
            this.Create_Date.ReadOnly = true;
            // 
            // Check_File
            // 
            this.Check_File.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Check_File.HeaderText = "Kiểm tra động";
            this.Check_File.Image = global::Ladin.mtaAV.Properties.Resources.icons8_Telegram_App_32;
            this.Check_File.Name = "Check_File";
            this.Check_File.ReadOnly = true;
            this.Check_File.Width = 130;
            // 
            // btn_DeleteFile
            // 
            this.btn_DeleteFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btn_DeleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteFile.HeaderText = "Hủy";
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.ReadOnly = true;
            this.btn_DeleteFile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btn_DeleteFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btn_DeleteFile.Text = "X";
            this.btn_DeleteFile.UseColumnTextForButtonValue = true;
            this.btn_DeleteFile.Width = 80;
            // 
            // UC_Process
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_MonitorProcess);
            this.Name = "UC_Process";
            this.Size = new System.Drawing.Size(935, 396);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MonitorProcess)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaDataGridView dgv_MonitorProcess;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel17;
        private Guna.UI.WinForms.GunaComboBox cbx_LimitSize;
        private Guna.UI.WinForms.GunaLabel gunaLabel16;
        private Guna.UI.WinForms.GunaButton btn_PauseScan;
        private Guna.UI.WinForms.GunaButton btn_Scan;
        private Guna.UI.WinForms.GunaButton btn_CancelScan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Virus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Scan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Date;
        private System.Windows.Forms.DataGridViewImageColumn Check_File;
        private System.Windows.Forms.DataGridViewButtonColumn btn_DeleteFile;
    }
}
