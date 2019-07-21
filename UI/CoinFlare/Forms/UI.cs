using System;
using System.Windows.Forms;

namespace CoinFlare
{
    public partial class UI : Form
    {
        public UI()
        {
            this.InitializeComponent();
        }

        private void EXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CREATETRACKERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a tracker for Helix to watch.
        }
    }
}