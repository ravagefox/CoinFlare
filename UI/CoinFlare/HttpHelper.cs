// Source: HttpHelper
/* 
   ---------------------------------------------------------------
                        CREXIUM ENTERTAINMENT
   ---------------------------------------------------------------

     The software is provided 'AS IS', without warranty of any kind,
   express or implied, including but not limited to the warrenties
   of merchantability, fitness for a particular purpose and
   noninfringement. In no event shall the authors or copyright
   holders be liable for any claim, damages, or other liability,
   whether in an action of contract, tort, or otherwise, arising
   from, out of or in connection with the software or the use of
   other dealings in the software.
*/

using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using CoinFlare.Properties;
using Newtonsoft.Json;

namespace CoinFlare
{
    public delegate void DynamicEventHandler(dynamic resultObject);

    internal static partial class HttpHelper
    {
        private static WebClient client;

        #region URLs

        // Full Access Api Urls
        internal static readonly string apiUrl = Settings.Default.ApiUrlBase + "/api";
        internal static readonly string pubapiUrl = Settings.Default.ApiUrlBase + "/pubapi";
        internal static readonly string latest = pubapiUrl + "/latest";
        internal static readonly string orderHistory = apiUrl + "/orders/history";
        internal static readonly string depositCoin = apiUrl + "/my/coin/deposit";
        internal static readonly string sendCoin = apiUrl + "/my/coin/send";
        internal static readonly string quickBuy = apiUrl + "/quote/buy";
        internal static readonly string quickSell = apiUrl + "/quote/sell";
        internal static readonly string myBalances = apiUrl + "/my/balances";
        internal static readonly string myOrders = apiUrl + "/my/orders";
        internal static readonly string placeBuy = apiUrl + "/my/buy";
        internal static readonly string placeSell = apiUrl + "/my/sell";
        internal static readonly string cancelSell = apiUrl + "/my/sell/cancel";
        internal static readonly string cancelBuy = apiUrl + "/my/buy/cancel";

        // Readonly API Urls
        internal static readonly string readonlyUrl = apiUrl + "/ro/my";
        internal static readonly string readonlyMyDeposits = readonlyUrl + "/deposits";
        internal static readonly string readonlyMyWithdrawals = readonlyUrl + "/withdrawals";
        internal static readonly string readonlyMyTransactions = readonlyUrl + "/transactions";
        internal static readonly string readonlyMyOpenTransactions = readonlyMyTransactions + "/open";
        internal static readonly string readonlyMySendReceive = readonlyUrl + "/sendreceive";

        private static readonly Dictionary<string, DynamicEventHandler> ClientMessages;

        #endregion

        static HttpHelper()
        {
            var secretHash = GetHash(Settings.Default.MySecret);

            if (client == null)
            {
                client = new WebClient();
            }

            client.Headers.Clear();
            client.Headers.Add("method", "POST");
            client.Headers.Add("key", Settings.Default.MyApiKey);
            client.Headers.Add("sign", secretHash);

            if (ClientMessages == null)
            {
                ClientMessages = new Dictionary<string, DynamicEventHandler>();
            }
        }

        public static void CreateClientMessage(string urlCallId, bool overrideExsisting, DynamicEventHandler eventHandler)
        {
            if (overrideExsisting)
            {
                if (ClientMessages.ContainsKey(urlCallId))
                    ClientMessages[urlCallId] = eventHandler;
            }
            else
            {
                if (!ClientMessages.ContainsKey(urlCallId))
                    ClientMessages.Add(urlCallId, eventHandler);
            }
        }

        public static void RemoveMessage(string urlCallId)
        {
            if (ClientMessages.ContainsKey(urlCallId))
                ClientMessages.Remove(urlCallId);
        }

        private static string GetHash(string mySecret)
        {
            var sha = HMAC.Create();
            var builder = new StringBuilder();
            var data = sha.ComputeHash(Encoding.UTF8.GetBytes(mySecret));

            foreach (var b in data)
                builder.Append(b.ToString("X2"));

            return builder.ToString();
        }

        public static dynamic GetData(string url)
        {
            try
            {
                // NOTE -->
                // Crucify me for choosing not to have an async operation
                // as the data is not a straight forward object that can't just
                // be assimilated into the environment easily.
                //
                // Using async would make this a little more complex than
                // it really needs to be.
                // <-- END NOTE

                Console.WriteLine(url);
                var data = client.DownloadString(url);

                return JsonConvert.DeserializeObject(data);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return exception;
            }
        }

    }
}