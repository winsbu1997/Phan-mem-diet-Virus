﻿namespace Ladin.mtaAV.Views
{
    partial class Reprot_DynamicScan
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
            this.gunaPanel4 = new Guna.UI.WinForms.GunaPanel();
            this.dgv_DynamicResult = new Guna.UI.WinForms.GunaDataGridView();
            this.Engine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_Malware = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_SingleFile = new System.Windows.Forms.Label();
            this.gunaLabel6 = new Guna.UI.WinForms.GunaLabel();
            this.gunaPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DynamicResult)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanel4
            // 
            this.gunaPanel4.BackColor = System.Drawing.Color.White;
            this.gunaPanel4.Controls.Add(this.dgv_DynamicResult);
            this.gunaPanel4.Controls.Add(this.lb_SingleFile);
            this.gunaPanel4.Controls.Add(this.gunaLabel6);
            this.gunaPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanel4.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel4.Name = "gunaPanel4";
            this.gunaPanel4.Size = new System.Drawing.Size(800, 450);
            this.gunaPanel4.TabIndex = 25;
            // 
            // dgv_DynamicResult
            // 
            this.dgv_DynamicResult.AllowUserToAddRows = false;
            this.dgv_DynamicResult.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_DynamicResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DynamicResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DynamicResult.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DynamicResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DynamicResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DynamicResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DynamicResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DynamicResult.ColumnHeadersHeight = 40;
            this.dgv_DynamicResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Engine,
            this.Is_Malware});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DynamicResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DynamicResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_DynamicResult.EnableHeadersVisualStyles = false;
            this.dgv_DynamicResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_DynamicResult.Location = new System.Drawing.Point(0, 55);
            this.dgv_DynamicResult.Name = "dgv_DynamicResult";
            this.dgv_DynamicResult.ReadOnly = true;
            this.dgv_DynamicResult.RowHeadersVisible = false;
            this.dgv_DynamicResult.RowTemplate.Height = 40;
            this.dgv_DynamicResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DynamicResult.Size = new System.Drawing.Size(800, 395);
            this.dgv_DynamicResult.TabIndex = 23;
            this.dgv_DynamicResult.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.LightGrid;
            this.dgv_DynamicResult.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DynamicResult.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_DynamicResult.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_DynamicResult.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_DynamicResult.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_DynamicResult.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DynamicResult.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_DynamicResult.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.dgv_DynamicResult.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_DynamicResult.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.dgv_DynamicResult.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_DynamicResult.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_DynamicResult.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_DynamicResult.ThemeStyle.ReadOnly = true;
            this.dgv_DynamicResult.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DynamicResult.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DynamicResult.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.dgv_DynamicResult.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_DynamicResult.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_DynamicResult.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgv_DynamicResult.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // Engine
            // 
            this.Engine.DataPropertyName = "Engine";
            this.Engine.FillWeight = 92.7242F;
            this.Engine.HeaderText = "Engine";
            this.Engine.Name = "Engine";
            this.Engine.ReadOnly = true;
            this.Engine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Engine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Is_Malware
            // 
            this.Is_Malware.DataPropertyName = "Is_Malware";
            this.Is_Malware.FillWeight = 92.7242F;
            this.Is_Malware.HeaderText = "Là mã độc";
            this.Is_Malware.Name = "Is_Malware";
            this.Is_Malware.ReadOnly = true;
            this.Is_Malware.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Is_Malware.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lb_SingleFile
            // 
            this.lb_SingleFile.AutoSize = true;
            this.lb_SingleFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SingleFile.Location = new System.Drawing.Point(103, 15);
            this.lb_SingleFile.Name = "lb_SingleFile";
            this.lb_SingleFile.Size = new System.Drawing.Size(0, 20);
            this.lb_SingleFile.TabIndex = 24;
            // 
            // gunaLabel6
            // 
            this.gunaLabel6.AutoSize = true;
            this.gunaLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel6.Location = new System.Drawing.Point(7, 8);
            this.gunaLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel6.Name = "gunaLabel6";
            this.gunaLabel6.Size = new System.Drawing.Size(200, 28);
            this.gunaLabel6.TabIndex = 22;
            this.gunaLabel6.Text = "Kết quả từ các Engine";
            // 
            // Reprot_DynamicScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gunaPanel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Reprot_DynamicScan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.gunaPanel4.ResumeLayout(false);
            this.gunaPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DynamicResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel4;
        private Guna.UI.WinForms.GunaDataGridView dgv_DynamicResult;
        private System.Windows.Forms.Label lb_SingleFile;
        private Guna.UI.WinForms.GunaLabel gunaLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Engine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Is_Malware;
    }
}