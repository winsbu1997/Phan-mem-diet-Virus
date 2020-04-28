namespace Ladin.mtaAV.Views
{
    partial class UC_Quarantine
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
            this.btn_Delete = new Guna.UI.WinForms.GunaButton();
            this.btn_Quarantine = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.dgv_Quarantine = new Guna.UI.WinForms.GunaDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkRow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FILENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIRUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_SCAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quarantineBinding = new System.Windows.Forms.BindingSource(this.components);
            this.ckb_All = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Quarantine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quarantineBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Delete
            // 
            this.btn_Delete.AnimationHoverSpeed = 0.07F;
            this.btn_Delete.AnimationSpeed = 0.03F;
            this.btn_Delete.BaseColor = System.Drawing.Color.White;
            this.btn_Delete.BorderColor = System.Drawing.Color.Black;
            this.btn_Delete.BorderSize = 1;
            this.btn_Delete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Delete.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Delete.Image = global::Ladin.mtaAV.Properties.Resources.Cancel_48px;
            this.btn_Delete.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Delete.Location = new System.Drawing.Point(770, 584);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.OnHoverBaseColor = System.Drawing.Color.MistyRose;
            this.btn_Delete.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Delete.OnHoverForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Delete.OnHoverImage = null;
            this.btn_Delete.OnPressedColor = System.Drawing.Color.MistyRose;
            this.btn_Delete.OnPressedDepth = 0;
            this.btn_Delete.Size = new System.Drawing.Size(139, 40);
            this.btn_Delete.TabIndex = 16;
            this.btn_Delete.Text = "Xóa ";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Quarantine
            // 
            this.btn_Quarantine.AnimationHoverSpeed = 0.07F;
            this.btn_Quarantine.AnimationSpeed = 0.03F;
            this.btn_Quarantine.BaseColor = System.Drawing.Color.White;
            this.btn_Quarantine.BorderColor = System.Drawing.Color.Black;
            this.btn_Quarantine.BorderSize = 1;
            this.btn_Quarantine.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Quarantine.FocusedColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Quarantine.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quarantine.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Quarantine.Image = global::Ladin.mtaAV.Properties.Resources.Encrypt_48px;
            this.btn_Quarantine.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Quarantine.Location = new System.Drawing.Point(609, 584);
            this.btn_Quarantine.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Quarantine.Name = "btn_Quarantine";
            this.btn_Quarantine.OnHoverBaseColor = System.Drawing.Color.MistyRose;
            this.btn_Quarantine.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Quarantine.OnHoverForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Quarantine.OnHoverImage = null;
            this.btn_Quarantine.OnPressedColor = System.Drawing.Color.MistyRose;
            this.btn_Quarantine.OnPressedDepth = 0;
            this.btn_Quarantine.Size = new System.Drawing.Size(141, 40);
            this.btn_Quarantine.TabIndex = 15;
            this.btn_Quarantine.Text = "Cách Ly";
            this.btn_Quarantine.Click += new System.EventHandler(this.btn_Quarantine_Click);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(44, 12);
            this.gunaLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(0, 20);
            this.gunaLabel1.TabIndex = 17;
            // 
            // dgv_Quarantine
            // 
            this.dgv_Quarantine.AllowUserToAddRows = false;
            this.dgv_Quarantine.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Quarantine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Quarantine.AutoGenerateColumns = false;
            this.dgv_Quarantine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Quarantine.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Quarantine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Quarantine.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Quarantine.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Quarantine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Quarantine.ColumnHeadersHeight = 40;
            this.dgv_Quarantine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.checkRow,
            this.FILENAME,
            this.VIRUS,
            this.TYPE_SCAN,
            this.CREATE_DATE});
            this.dgv_Quarantine.DataSource = this.quarantineBinding;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Quarantine.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Quarantine.EnableHeadersVisualStyles = false;
            this.dgv_Quarantine.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_Quarantine.Location = new System.Drawing.Point(15, 35);
            this.dgv_Quarantine.Name = "dgv_Quarantine";
            this.dgv_Quarantine.RowHeadersVisible = false;
            this.dgv_Quarantine.RowTemplate.Height = 40;
            this.dgv_Quarantine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Quarantine.Size = new System.Drawing.Size(894, 544);
            this.dgv_Quarantine.TabIndex = 18;
            this.dgv_Quarantine.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.LightGrid;
            this.dgv_Quarantine.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Quarantine.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Quarantine.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_Quarantine.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_Quarantine.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_Quarantine.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Quarantine.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_Quarantine.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.dgv_Quarantine.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Quarantine.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Quarantine.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_Quarantine.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_Quarantine.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_Quarantine.ThemeStyle.ReadOnly = false;
            this.dgv_Quarantine.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Quarantine.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Quarantine.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Quarantine.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_Quarantine.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_Quarantine.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_Quarantine.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // checkRow
            // 
            this.checkRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checkRow.FalseValue = "false";
            this.checkRow.FillWeight = 121.8274F;
            this.checkRow.HeaderText = "";
            this.checkRow.Name = "checkRow";
            this.checkRow.TrueValue = "true";
            this.checkRow.Width = 50;
            // 
            // FILENAME
            // 
            this.FILENAME.DataPropertyName = "FILENAME";
            this.FILENAME.FillWeight = 92.7242F;
            this.FILENAME.HeaderText = "Tên file";
            this.FILENAME.Name = "FILENAME";
            this.FILENAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FILENAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VIRUS
            // 
            this.VIRUS.DataPropertyName = "VIRUS";
            this.VIRUS.FillWeight = 92.7242F;
            this.VIRUS.HeaderText = "Loại mã độc";
            this.VIRUS.Name = "VIRUS";
            this.VIRUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VIRUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TYPE_SCAN
            // 
            this.TYPE_SCAN.DataPropertyName = "TYPE_SCAN";
            this.TYPE_SCAN.FillWeight = 92.7242F;
            this.TYPE_SCAN.HeaderText = "Kiểu quét";
            this.TYPE_SCAN.Name = "TYPE_SCAN";
            // 
            // CREATE_DATE
            // 
            this.CREATE_DATE.DataPropertyName = "CREATE_DATE";
            this.CREATE_DATE.HeaderText = "Thời gian";
            this.CREATE_DATE.Name = "CREATE_DATE";
            this.CREATE_DATE.Visible = false;
            // 
            // quarantineBinding
            // 
            this.quarantineBinding.DataSource = typeof(Ladin.mtaAV.Model.QUARANTINES);
            // 
            // ckb_All
            // 
            this.ckb_All.AutoSize = true;
            this.ckb_All.Location = new System.Drawing.Point(38, 48);
            this.ckb_All.Name = "ckb_All";
            this.ckb_All.Size = new System.Drawing.Size(18, 17);
            this.ckb_All.TabIndex = 19;
            this.ckb_All.UseVisualStyleBackColor = true;
            this.ckb_All.CheckedChanged += new System.EventHandler(this.ckb_All_CheckedChanged);
            // 
            // UC_Quarantine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ckb_All);
            this.Controls.Add(this.dgv_Quarantine);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Quarantine);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Name = "UC_Quarantine";
            this.Size = new System.Drawing.Size(935, 637);
            this.Load += new System.EventHandler(this.UC_Quarantine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Quarantine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quarantineBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI.WinForms.GunaButton btn_Delete;
        private Guna.UI.WinForms.GunaButton btn_Quarantine;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.BindingSource quarantineBinding;
        private Guna.UI.WinForms.GunaDataGridView dgv_Quarantine;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn VIRUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_SCAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE;
        private System.Windows.Forms.CheckBox ckb_All;
    }
}
