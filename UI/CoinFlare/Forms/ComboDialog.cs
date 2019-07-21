using System.Windows.Forms;

namespace CoinFlare
{
    /// <summary>
    /// Creates a dialog that allows the user to input a numeric decimal number.
    /// </summary>
    public partial class ComboDialog : Form
    {

        public ComboDialog()
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