using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CoinFlare.Properties;
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

        [DefaultValue(prefixAsk + "$0.00")]
        [Browsable(true)]
        public string Ask
        {
            get => this.askText.Text.Replace(prefixAsk, "");
            set
            {
                if (double.TryParse(value, out var result))
                {
                    this.askText.Text = prefixAsk + result.ToString();
                }
                else
                {
                    throw new InvalidCastException(
                        "The value specified could not be parsed to a double.");
                }
            }
        }

        [DefaultValue(prefixBid + "0.00")]
        [Browsable(false)]
        public string Bid
        {
            get => this.bidText.Text.Replace(prefixBid, "");
            set
            {
                if (double.TryParse(value, out var result))
                {
                    this.bidText.Text = prefixBid + result.ToString();
                }
                else
                {
                    throw new InvalidCastException(
                        "The value specified could not be parsed to a double.");
                }
            }
        }

        [DefaultValue(prefixLast + "0.00")]
        [Browsable(false)]
        public string Last
        {
            get => this.lastText.Text.Replace(prefixLast, "");
            set
            {
                if (double.TryParse(value, out var result))
                {
                    this.lastText.Text = prefixLast + result.ToString();
                }
                else
                {
                    throw new InvalidCastException(
                        "The value specified could not be parsed to a double.");
                }
            }
        }

        [Browsable(false)]
        public new string Name
        {
            get { return headerText.Text ?? string.Empty; }
            set
            {
                if (headerText == null) return;

                if (headerText.Text != value)
                {
                    headerText.Text = value;
                }
            }
        }

        [Browsable(false)]
        public new Image BackgroundImage
        {
            get { return iconImage.BackgroundImage; }
            set
            {
                if (iconImage.BackgroundImage != value)
                {
                    iconImage.BackgroundImage = value;
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

        private readonly Label headerText, askText, lastText, bidText;
        private readonly Button sellButton, buyButton;
        private readonly PictureBox iconImage;


        private const string prefixBid = "BID: $";
        private const string prefixLast = "LAST: $";
        private const string prefixAsk = "ASK: $";


        public CryptoControl()
        {
            this.InitializeComponent();

            this.headerText = new Label
            {
                Text = "Name",
                Width = this.Width,
                Dock = DockStyle.Top,
            };
            this.askText = new Label()
            {
                Text = prefixAsk + "0.00000",
                Width = this.Width,
                Dock = DockStyle.Top,
            };
            this.lastText = new Label()
            {
                Text = prefixLast + "0.00000",
                Width = this.Width,
                Dock = DockStyle.Top,
            };
            this.bidText = new Label()
            {
                Text = prefixBid + "0.00000", 
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
            this.iconImage = new PictureBox()
            {
                Width = Height,
                Height = Height,
                Dock = DockStyle.Left,
                BackgroundImage = Resources.placeholder142x142,
                BackgroundImageLayout = ImageLayout.Zoom,
            };

            this.Controls.Add(this.bidText);
            this.Controls.Add(this.lastText);
            this.Controls.Add(this.askText);

            this.Controls.Add(this.headerText);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.sellButton);

            this.Controls.Add(this.iconImage);

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
            return double.Parse(this.Ask);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}