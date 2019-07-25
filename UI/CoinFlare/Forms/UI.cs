using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using CoinFlare.Controls;
using CoinFlare.Properties;
using Newtonsoft.Json.Linq;

namespace CoinFlare
{
    public partial class UI : Form
    {

        private readonly Timer refreshTimer;

        public UI()
        {
            this.InitializeComponent();

            this.refreshTimer = new Timer();
            this.refreshTimer.Tick += new EventHandler(this.OnRefresh);
            this.refreshTimer.Interval = 10000;
            this.refreshTimer.Start();

            HttpHelper.CreateMyOrderRequest((result) =>
            {
                Console.WriteLine(result.ToString());
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

                    foreach (var control in this.flowLayoutPanel1.Controls)
                    {
                        if (control is CryptoControl ctrl)
                        {
                            if (string.Compare(crypto.ToString().ToLower(), ctrl.Name.ToLower()) == 0)
                            {
                                ctrl.Ask = crypto.Ask.ToString();
                                ctrl.Bid = crypto.Bid.ToString();
                                ctrl.Last = crypto.Last.ToString();
                                break;
                            }
                        }
                    }
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
            using (var cBox = new ComboDialog())
            {
                this.FillValues(cBox.Items);

                if (cBox.ShowDialog() == DialogResult.OK)
                {
                    if (cBox.SelectedItem != null)
                    {
                        // Create a new control and insert it into the system.
                        var ctrl = new CryptoControl();
                        var selectedItem = (Crypto)cBox.SelectedItem;
                        ctrl.Ask = selectedItem.Ask.ToString();
                        ctrl.Bid = selectedItem.Bid.ToString();
                        ctrl.Last = selectedItem.Last.ToString();
                        ctrl.Text = selectedItem.ToString().ToUpper();

                        SetIconImage(ref ctrl, selectedItem);

                        if (!this.refreshTimer.Enabled)
                            this.refreshTimer.Start();

                        this.flowLayoutPanel1.Controls.Add(ctrl);

                        // TODO: incorporate a tracker for Helix...
                    }
                }
            }
        }

        private void SetIconImage(ref CryptoControl ctrl, Crypto selectedItem)
        {
            const string resourcePath = "Resources/";
            if (!Directory.Exists(resourcePath))
            {
                ctrl.BackgroundImage = Resources.placeholder142x142;
                return;
            }

            var files = Directory.GetFiles(resourcePath);
            for (var i = 0; i < files.Length; i++)
            {
                var fName = Path.GetFileName(files[i]);
                if (string.Compare(fName.ToLower(), selectedItem.ToString().ToLower()) == 0)
                {
                    var img = Image.FromStream(
                        File.OpenRead(resourcePath + files[i]));
                    ctrl.BackgroundImage = img;

                    return;
                }
            }
        }

        private void FillValues(ComboBox.ObjectCollection collection)
        {
            collection.Clear();
            HttpHelper.CreateCryptoData((result) =>
            {
                if (result is WebException) return;

                var priceData = result.prices;
                // Download and fill the combo box with token data.
                foreach (var token in priceData)
                {
                    JProperty property = token;
                    var crypto = new Crypto(property.Name.ToUpper(), result.prices[property.Name]);
                    collection.Add(crypto);
                }
            });
        }
    }
}