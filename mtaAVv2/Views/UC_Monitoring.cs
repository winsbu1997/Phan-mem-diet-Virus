using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ladin.mtaAV.Views
{
    public partial class UC_Monitoring : System.Windows.Forms.UserControl
    {
        public UC_Monitoring()
        {
            InitializeComponent();
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(pnlBody, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
        }
    }
}
