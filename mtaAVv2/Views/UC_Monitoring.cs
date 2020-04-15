using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Ladin.mtaAV.Views
{
    public partial class UC_Monitoring : System.Windows.Forms.UserControl
    {
        public UC_Monitoring()
        {
            InitializeComponent();
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(pnlMain, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(uC_Network1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(uC_MonitorFolder1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
            pnlMain.BringToFront();
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            uC_MonitorFolder1.BringToFront();
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            uC_Network1.BringToFront();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            uC_Process1.BringToFront();
        }

        private void btnRansomware_Click(object sender, EventArgs e)
        {
            pnlMain.BringToFront();
        }
    }
}
