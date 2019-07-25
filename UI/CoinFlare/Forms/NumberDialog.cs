using System.Windows.Forms;

namespace CoinFlare
{
    /// <summary>
    /// Creates a dialog that allows the user to input a numeric decimal number.
    /// </summary>
    public partial class NumberDialog : Form
    {
        /// <summary>
        /// Gets the value that was set by the user.
        /// </summary>
        public decimal Numeric1 => this.numericUpDown1.Value;

        /// <summary>
        /// Gets the second value that was set by the user.
        /// </summary>
        public decimal Numeric2 => this.numericUpDown2.Value;

        public NumberDialog()
        {
            this.InitializeComponent();
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            // Forces the dialog result.
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            // Forces the dialog result.
            this.DialogResult = DialogResult.Cancel;
        }
    }
}