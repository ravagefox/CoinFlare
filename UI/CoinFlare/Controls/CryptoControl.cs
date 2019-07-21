using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace CoinFlare.Controls
{
    public partial class CryptoControl : UserControl
    {
        #region Properties
        [Browsable(false)]
        public new Size Size { get => base.Size; set => base.Size = value; }

        [Browsable(false)]
        public new Size MinimumSize { get => base.MinimumSize; set => base.MinimumSize = value; }

        [Browsable(false)]
        public new Size MaximumSize { get => base.MaximumSize; set => base.MaximumSize = value; }

        [Browsable(false)]
        public new BorderStyle BorderStyle { get => base.BorderStyle; set => base.BorderStyle = value; }

        [Browsable(false)]
        public new bool DoubleBuffered => true;

        [DefaultValue(nameof(CryptoControl))]
        [Browsable(true)]
        public new string Text
        {
            get => this.headerText.Text;
            set => this.headerText.Text = value;
        }

        [DefaultValue("0.00")]
        [Browsable(true)]
        public string Price
        {
            get => this.priceText.Text.Replace("$", "");
            set
            {
                if (double.TryParse(value, out var result))
                {
                    this.priceText.Text = "$" + result.ToString();
                }
                else
                {
                    throw new InvalidCastException(
                        "The value specified could not be parsed to a double.");
                }
            }
        }
        #endregion

        public event EventHandler SellClick
        {
            add { sellButton.Click += value; }
            remove { sellButton.Click -= value; }
        }

        public event EventHandler BuyClick
        {
            add { buyButton.Click += value; }
            remove { buyButton.Click -= value; }
        }

        private readonly Label headerText;
        private readonly Label priceText;
        private readonly Button sellButton, buyButton;



        public CryptoControl()
        {
            this.InitializeComponent();

            this.headerText = new Label
            {
                Text = "Name",
                Width = this.Width,
                Dock = DockStyle.Top,
            };
            this.priceText = new Label()
            {
                Text = "0.00000",
                Width = this.Width,
                Dock = DockStyle.Top,
            };
            this.sellButton = new Button()
            {
                Text = "SELL",
                Width = 221,
                Height = 25,
                Dock = DockStyle.Bottom,
            };
            this.buyButton = new Button()
            {
                Text = "BUY",
                Width = 221,
                Height = 25,
                Dock = DockStyle.Bottom,
            };

            this.Controls.Add(this.priceText);
            this.Controls.Add(this.headerText);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.sellButton);

            BuyClick += new EventHandler(this.OnBuyClick);
            SellClick += new EventHandler(this.OnSellClick);
        }

        protected virtual void OnSellClick(object sender, EventArgs e)
        {
            using (var numberDialog = new NumberDialog())
            {
                if (numberDialog.ShowDialog() == DialogResult.OK)
                {
                    HttpHelper.CreateMarketSell((result) =>
                    {
                        if (result is Exception)
                        {
                            this.ShowError(result as Exception);
                        }
                        else if (result is JObject)
                        {
                            Console.WriteLine(result.ToString());
                            // Do something useful with the data.
                        }
                    });
                }
            }
        }

        protected virtual void OnBuyClick(object sender, EventArgs e)
        {
            using (var numberDialog = new NumberDialog())
            {
                if (numberDialog.ShowDialog() == DialogResult.OK)
                {
                    var numeric = numberDialog.Numeric;
                    HttpHelper.CreateMarketBuy((result) =>
                    {
                        if (result is Exception)
                        {
                            this.ShowError(result as Exception);
                        }
                        else if (result is JObject)
                        {
                            Console.WriteLine(result.ToString());
                            // Do something useful with the data.
                        }
                    });
                }
            }
        }


        public new void Dispose()
        {
            BuyClick -= OnBuyClick;
            SellClick -= OnSellClick;

            base.Dispose();
        }

        private void ShowError(Exception exception)
        {
            MessageBox.Show(exception.Message,
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
        }

        public double GetPrice()
        {
            return double.Parse(this.Price);
        }
    }
}