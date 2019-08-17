using System;
using System.Windows.Forms;

namespace LiteDBBrowser
{
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}