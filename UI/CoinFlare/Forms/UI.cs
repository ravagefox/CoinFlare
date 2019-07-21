using System;
using System.Net;
using System.Windows.Forms;
using CoinFlare.Controls;
using Newtonsoft.Json.Linq;

namespace CoinFlare
{
    public partial class UI : Form
    {

        private readonly Timer refreshTimer;
        private ComboDialog comboDialog;

        public UI()
        {
            this.InitializeComponent();
            this.refreshTimer = new Timer();
            this.refreshTimer.Tick += new EventHandler(OnRefresh);
            this.refreshTimer.Interval = 10000;
            this.refreshTimer.Start();

            comboDialog = new ComboDialog();

            HttpHelper.CreateCryptoData((result) =>
            {
                if (result is WebException) return;

                var priceData = result.prices;
                // Download and fill the combo box with token data.
                foreach (var token in priceData)
                {
                    JProperty property = token;

                    var crypto = new Crypto(property.Name, result.prices[property.Name]);
                    comboDialog.Items.Add(crypto);
                }
            });
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            if (this.flowLayoutPanel1.Controls.Count == 0) return;

            HttpHelper.CreateCryptoData((result) =>
            {
                var priceData = result.prices;
                foreach (var token in priceData)
                {
                    JProperty property = token;
                    
                    // Update the coin currency
                    var crypto = new Crypto(property.Name, result.prices[property.Name]);
                    var ctrl = this.flowLayoutPanel1.Controls[crypto.ToString()] as CryptoControl;
                    ctrl.Price = crypto.Ask.ToString();
                }
            });
        }

        private void EXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CREATETRACKERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a tracker for Helix to watch.
            using (comboDialog = new ComboDialog())
            {
                if (comboDialog.ShowDialog() == DialogResult.OK)
                {
                    if (comboDialog.SelectedItem != null)
                    {
                        // Create a new control and insert it into the system.
                        var ctrl = new CryptoControl();
                        var selectedItem = (Crypto)comboDialog.SelectedItem;
                        ctrl.Price = selectedItem.Ask.ToString();
                        ctrl.Text = selectedItem.ToString();

                        if (!this.refreshTimer.Enabled)
                            this.refreshTimer.Start();

                        this.flowLayoutPanel1.Controls.Add(ctrl);

                        // TODO: incorporate a tracker for Helix...
                    }
                }
            }
        }
    }
}