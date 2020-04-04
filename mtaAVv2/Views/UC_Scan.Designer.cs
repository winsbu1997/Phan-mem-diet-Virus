namespace Ladin.mtaAV.Views
{
    partial class UC_Scan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Scan));
            this.progressBar_Scan = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.lb_AllFile = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.checkFile = new Guna.UI.WinForms.GunaCheckBox();
            this.checkProcess = new Guna.UI.WinForms.GunaCheckBox();
            this.checkFolder = new Guna.UI.WinForms.GunaCheckBox();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.gunaLabel8 = new Guna.UI.WinForms.GunaLabel();
            this.lb_CountMacro = new Guna.UI.WinForms.GunaLabel();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaLabel10 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel7 = new Guna.UI.WinForms.GunaLabel();
            this.lb_CountVirus = new Guna.UI.WinForms.GunaLabel();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.txt = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.gunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.gunaLinePanel1 = new Guna.UI.WinForms.GunaLinePanel();
            this.lbwe = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel11 = new Guna.UI.WinForms.GunaLabel();
            this.sw_DynamicScan = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.sw_SmartScan = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.lb_LocationFileScan = new Guna.UI.WinForms.GunaLabel();
            this.btn_CancelScan = new Guna.UI.WinForms.GunaButton();
            this.btn_PauseScan = new Guna.UI.WinForms.GunaButton();
            this.btn_Scan = new Guna.UI.WinForms.GunaButton();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.gunaPanel2.SuspendLayout();
            this.gunaLinePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar_Scan
            // 
            this.progressBar_Scan.AnimationSpeed = 0.6F;
            this.progressBar_Scan.BaseColor = System.Drawing.Color.White;
            this.progressBar_Scan.Font = new System.Drawing.Font("Segoe UI Semilight", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar_Scan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(155)))));
            this.progressBar_Scan.IdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar_Scan.IdleOffset = 21;
            this.progressBar_Scan.Image = null;
            this.progressBar_Scan.ImageSize = new System.Drawing.Size(52, 52);
            this.progressBar_Scan.Location = new System.Drawing.Point(454, 90);
            this.progressBar_Scan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar_Scan.Name = "progressBar_Scan";
            this.progressBar_Scan.ProgressMaxColor = System.Drawing.Color.DeepPink;
            this.progressBar_Scan.ProgressMinColor = System.Drawing.Color.DeepPink;
            this.progressBar_Scan.ProgressOffset = 20;
            this.progressBar_Scan.ProgressThickness = 13;
            this.progressBar_Scan.Size = new System.Drawing.Size(408, 376);
            this.progressBar_Scan.TabIndex = 3;
            this.progressBar_Scan.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit;
            this.progressBar_Scan.UseProgressPercentText = true;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel1.Location = new System.Drawing.Point(411, 522);
            this.gunaLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(198, 28);
            this.gunaLabel1.TabIndex = 4;
            this.gunaLabel1.Text = "Tổng số tập tin quét: ";
            // 
            // lb_AllFile
            // 
            this.lb_AllFile.AutoSize = true;
            this.lb_AllFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AllFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_AllFile.Location = new System.Drawing.Point(613, 522);
            this.lb_AllFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_AllFile.Name = "lb_AllFile";
            this.lb_AllFile.Size = new System.Drawing.Size(24, 28);
            this.lb_AllFile.TabIndex = 5;
            this.lb_AllFile.Text = "...";
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel3.Location = new System.Drawing.Point(411, 561);
            this.gunaLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(90, 28);
            this.gunaLabel3.TabIndex = 6;
            this.gunaLabel3.Text = "Quét file:";
            // 
            // checkFile
            // 
            this.checkFile.BaseColor = System.Drawing.Color.White;
            this.checkFile.CheckedOffColor = System.Drawing.Color.Gray;
            this.checkFile.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkFile.FillColor = System.Drawing.Color.White;
            this.checkFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkFile.Location = new System.Drawing.Point(21, 86);
            this.checkFile.Margin = new System.Windows.Forms.Padding(2);
            this.checkFile.Name = "checkFile";
            this.checkFile.Size = new System.Drawing.Size(114, 31);
            this.checkFile.TabIndex = 0;
            this.checkFile.Text = "Quét File";
            // 
            // checkProcess
            // 
            this.checkProcess.BaseColor = System.Drawing.Color.White;
            this.checkProcess.CheckedOffColor = System.Drawing.Color.Gray;
            this.checkProcess.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkProcess.FillColor = System.Drawing.Color.White;
            this.checkProcess.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkProcess.Location = new System.Drawing.Point(21, 194);
            this.checkProcess.Margin = new System.Windows.Forms.Padding(2);
            this.checkProcess.Name = "checkProcess";
            this.checkProcess.Size = new System.Drawing.Size(166, 31);
            this.checkProcess.TabIndex = 3;
            this.checkProcess.Text = "Quét tiến trình";
            // 
            // checkFolder
            // 
            this.checkFolder.BaseColor = System.Drawing.Color.White;
            this.checkFolder.CheckedOffColor = System.Drawing.Color.Gray;
            this.checkFolder.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkFolder.FillColor = System.Drawing.Color.White;
            this.checkFolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFolder.Location = new System.Drawing.Point(21, 138);
            this.checkFolder.Margin = new System.Windows.Forms.Padding(2);
            this.checkFolder.Name = "checkFolder";
            this.checkFolder.Size = new System.Drawing.Size(159, 31);
            this.checkFolder.TabIndex = 4;
            this.checkFolder.Text = "Quét thư mục";
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel4.Location = new System.Drawing.Point(9, 38);
            this.gunaLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(139, 30);
            this.gunaLabel4.TabIndex = 5;
            this.gunaLabel4.Text = "Chế độ quét";
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.Controls.Add(this.gunaLabel8);
            this.gunaPanel1.Controls.Add(this.lb_CountMacro);
            this.gunaPanel1.Controls.Add(this.gunaPictureBox2);
            this.gunaPanel1.Controls.Add(this.gunaLabel10);
            this.gunaPanel1.Controls.Add(this.gunaLabel7);
            this.gunaPanel1.Controls.Add(this.lb_CountVirus);
            this.gunaPanel1.Controls.Add(this.gunaPictureBox1);
            this.gunaPanel1.Controls.Add(this.txt);
            this.gunaPanel1.Controls.Add(this.gunaLabel5);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 399);
            this.gunaPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(382, 238);
            this.gunaPanel1.TabIndex = 7;
            // 
            // gunaLabel8
            // 
            this.gunaLabel8.AutoSize = true;
            this.gunaLabel8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel8.Location = new System.Drawing.Point(111, 123);
            this.gunaLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel8.Name = "gunaLabel8";
            this.gunaLabel8.Size = new System.Drawing.Size(100, 28);
            this.gunaLabel8.TabIndex = 14;
            this.gunaLabel8.Text = "đối tượng";
            // 
            // lb_CountMacro
            // 
            this.lb_CountMacro.AutoSize = true;
            this.lb_CountMacro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CountMacro.Location = new System.Drawing.Point(71, 123);
            this.lb_CountMacro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CountMacro.Name = "lb_CountMacro";
            this.lb_CountMacro.Size = new System.Drawing.Size(36, 28);
            this.lb_CountMacro.TabIndex = 13;
            this.lb_CountMacro.Text = "64";
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = global::Ladin.mtaAV.Properties.Resources.Error_48px;
            this.gunaPictureBox2.Location = new System.Drawing.Point(12, 129);
            this.gunaPictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(45, 41);
            this.gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gunaPictureBox2.TabIndex = 12;
            this.gunaPictureBox2.TabStop = false;
            // 
            // gunaLabel10
            // 
            this.gunaLabel10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel10.Location = new System.Drawing.Point(72, 151);
            this.gunaLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel10.Name = "gunaLabel10";
            this.gunaLabel10.Size = new System.Drawing.Size(292, 39);
            this.gunaLabel10.TabIndex = 11;
            this.gunaLabel10.Text = "Danh sách file tài liệu chứa macro nguy hiểm";
            // 
            // gunaLabel7
            // 
            this.gunaLabel7.AutoSize = true;
            this.gunaLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel7.Location = new System.Drawing.Point(107, 47);
            this.gunaLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel7.Name = "gunaLabel7";
            this.gunaLabel7.Size = new System.Drawing.Size(100, 28);
            this.gunaLabel7.TabIndex = 10;
            this.gunaLabel7.Text = "đối tượng";
            // 
            // lb_CountVirus
            // 
            this.lb_CountVirus.AutoSize = true;
            this.lb_CountVirus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CountVirus.Location = new System.Drawing.Point(71, 47);
            this.lb_CountVirus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CountVirus.Name = "lb_CountVirus";
            this.lb_CountVirus.Size = new System.Drawing.Size(36, 28);
            this.lb_CountVirus.TabIndex = 9;
            this.lb_CountVirus.Text = "64";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = global::Ladin.mtaAV.Properties.Resources.Spam_48px;
            this.gunaPictureBox1.Location = new System.Drawing.Point(10, 47);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(45, 43);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gunaPictureBox1.TabIndex = 8;
            this.gunaPictureBox1.TabStop = false;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(72, 77);
            this.txt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(302, 23);
            this.txt.TabIndex = 7;
            this.txt.Text = "Danh sách đối tượng nghi nhiễm virus";
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel5.Location = new System.Drawing.Point(5, 6);
            this.gunaLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(93, 30);
            this.gunaLabel5.TabIndex = 6;
            this.gunaLabel5.Text = "Kết quả";
            // 
            // gunaPanel2
            // 
            this.gunaPanel2.Controls.Add(this.checkFolder);
            this.gunaPanel2.Controls.Add(this.checkFile);
            this.gunaPanel2.Controls.Add(this.gunaLabel4);
            this.gunaPanel2.Controls.Add(this.checkProcess);
            this.gunaPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel2.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.gunaPanel2.Name = "gunaPanel2";
            this.gunaPanel2.Size = new System.Drawing.Size(382, 260);
            this.gunaPanel2.TabIndex = 8;
            // 
            // gunaLinePanel1
            // 
            this.gunaLinePanel1.Controls.Add(this.lbwe);
            this.gunaLinePanel1.Controls.Add(this.gunaLabel11);
            this.gunaLinePanel1.Controls.Add(this.sw_DynamicScan);
            this.gunaLinePanel1.Controls.Add(this.sw_SmartScan);
            this.gunaLinePanel1.Controls.Add(this.gunaPanel2);
            this.gunaLinePanel1.Controls.Add(this.gunaPanel1);
            this.gunaLinePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaLinePanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gunaLinePanel1.LineColor = System.Drawing.Color.Black;
            this.gunaLinePanel1.LineStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaLinePanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaLinePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaLinePanel1.Name = "gunaLinePanel1";
            this.gunaLinePanel1.Size = new System.Drawing.Size(382, 637);
            this.gunaLinePanel1.TabIndex = 11;
            // 
            // lbwe
            // 
            this.lbwe.AutoSize = true;
            this.lbwe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwe.Location = new System.Drawing.Point(80, 344);
            this.lbwe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbwe.Name = "lbwe";
            this.lbwe.Size = new System.Drawing.Size(107, 28);
            this.lbwe.TabIndex = 12;
            this.lbwe.Text = "Quét động";
            // 
            // gunaLabel11
            // 
            this.gunaLabel11.AutoSize = true;
            this.gunaLabel11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel11.Location = new System.Drawing.Point(80, 288);
            this.gunaLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel11.Name = "gunaLabel11";
            this.gunaLabel11.Size = new System.Drawing.Size(162, 28);
            this.gunaLabel11.TabIndex = 11;
            this.gunaLabel11.Text = "Quét thông minh";
            // 
            // sw_DynamicScan
            // 
            this.sw_DynamicScan.BackColor = System.Drawing.Color.Transparent;
            this.sw_DynamicScan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sw_DynamicScan.BackgroundImage")));
            this.sw_DynamicScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sw_DynamicScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sw_DynamicScan.Location = new System.Drawing.Point(21, 347);
            this.sw_DynamicScan.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.sw_DynamicScan.Name = "sw_DynamicScan";
            this.sw_DynamicScan.OffColor = System.Drawing.Color.Gray;
            this.sw_DynamicScan.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.sw_DynamicScan.Size = new System.Drawing.Size(43, 25);
            this.sw_DynamicScan.TabIndex = 10;
            this.sw_DynamicScan.Value = false;
            // 
            // sw_SmartScan
            // 
            this.sw_SmartScan.BackColor = System.Drawing.Color.Transparent;
            this.sw_SmartScan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sw_SmartScan.BackgroundImage")));
            this.sw_SmartScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sw_SmartScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sw_SmartScan.Location = new System.Drawing.Point(21, 291);
            this.sw_SmartScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sw_SmartScan.Name = "sw_SmartScan";
            this.sw_SmartScan.OffColor = System.Drawing.Color.Gray;
            this.sw_SmartScan.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.sw_SmartScan.Size = new System.Drawing.Size(43, 25);
            this.sw_SmartScan.TabIndex = 9;
            this.sw_SmartScan.Value = false;
            // 
            // lb_LocationFileScan
            // 
            this.lb_LocationFileScan.AutoSize = true;
            this.lb_LocationFileScan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_LocationFileScan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_LocationFileScan.Location = new System.Drawing.Point(505, 561);
            this.lb_LocationFileScan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_LocationFileScan.Name = "lb_LocationFileScan";
            this.lb_LocationFileScan.Size = new System.Drawing.Size(24, 28);
            this.lb_LocationFileScan.TabIndex = 15;
            this.lb_LocationFileScan.Text = "...";
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
            this.btn_CancelScan.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_CancelScan.Location = new System.Drawing.Point(748, 13);
            this.btn_CancelScan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CancelScan.Name = "btn_CancelScan";
            this.btn_CancelScan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_CancelScan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_CancelScan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_CancelScan.OnHoverImage = null;
            this.btn_CancelScan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_CancelScan.Size = new System.Drawing.Size(168, 42);
            this.btn_CancelScan.TabIndex = 14;
            this.btn_CancelScan.Text = "Hủy quét";
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
            this.btn_PauseScan.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_PauseScan.Location = new System.Drawing.Point(569, 13);
            this.btn_PauseScan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PauseScan.Name = "btn_PauseScan";
            this.btn_PauseScan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_PauseScan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_PauseScan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_PauseScan.OnHoverImage = null;
            this.btn_PauseScan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_PauseScan.Size = new System.Drawing.Size(175, 42);
            this.btn_PauseScan.TabIndex = 13;
            this.btn_PauseScan.Text = "Tạm dừng";
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
            this.btn_Scan.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Scan.Location = new System.Drawing.Point(390, 13);
            this.btn_Scan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Scan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Scan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Scan.OnHoverImage = null;
            this.btn_Scan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Scan.Size = new System.Drawing.Size(175, 42);
            this.btn_Scan.TabIndex = 12;
            this.btn_Scan.Text = "Chạy quét";
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // UC_Scan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lb_LocationFileScan);
            this.Controls.Add(this.btn_CancelScan);
            this.Controls.Add(this.btn_PauseScan);
            this.Controls.Add(this.btn_Scan);
            this.Controls.Add(this.gunaLinePanel1);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.progressBar_Scan);
            this.Controls.Add(this.lb_AllFile);
            this.Controls.Add(this.gunaLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name = "UC_Scan";
            this.Size = new System.Drawing.Size(935, 637);
            this.Load += new System.EventHandler(this.UC_Scan_Load);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.gunaPanel2.ResumeLayout(false);
            this.gunaPanel2.PerformLayout();
            this.gunaLinePanel1.ResumeLayout(false);
            this.gunaLinePanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal Guna.UI.WinForms.GunaCircleProgressBar progressBar_Scan;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel lb_AllFile;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaCheckBox checkFile;
        private Guna.UI.WinForms.GunaCheckBox checkProcess;
        private Guna.UI.WinForms.GunaCheckBox checkFolder;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel8;
        private Guna.UI.WinForms.GunaLabel lb_CountMacro;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private Guna.UI.WinForms.GunaLabel gunaLabel10;
        private Guna.UI.WinForms.GunaLabel gunaLabel7;
        private Guna.UI.WinForms.GunaLabel lb_CountVirus;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaLabel txt;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private Guna.UI.WinForms.GunaPanel gunaPanel2;
        private Guna.UI.WinForms.GunaLinePanel gunaLinePanel1;
        private Guna.UI.WinForms.GunaLabel lbwe;
        private Guna.UI.WinForms.GunaLabel gunaLabel11;
        private Bunifu.Framework.UI.BunifuiOSSwitch sw_DynamicScan;
        private Bunifu.Framework.UI.BunifuiOSSwitch sw_SmartScan;
        private Guna.UI.WinForms.GunaButton btn_Scan;
        private Guna.UI.WinForms.GunaButton btn_PauseScan;
        private Guna.UI.WinForms.GunaButton btn_CancelScan;
        private Guna.UI.WinForms.GunaLabel lb_LocationFileScan;
    }
}
