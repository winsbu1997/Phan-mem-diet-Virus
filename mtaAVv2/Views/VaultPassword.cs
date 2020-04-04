using System;
using System.Windows.Forms;

namespace Ladin.mtaAV.Views
{
    public partial class VaultPassword : Form
    {
        public string password { get; set; }
        public VaultPassword()
        {
            InitializeComponent();
        }

        private void GunaButton1_Click(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text.Trim().Length >= 2)
            {
                password = gunaTextBox1.Text.Trim();
                this.Close();
            }
        }
    }
}
