using System.Windows.Forms;

namespace CoinFlare
{
    /// <summary>
    /// Creates a dialog that allows the user to input a numeric decimal number.
    /// </summary>
    public partial class InputDialog : Form
    {

        /// <summary>
        /// Gets the input text that was typed by the user.
        /// </summary>
        public string UserInput => this.textBox1.Text;


        public InputDialog()
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