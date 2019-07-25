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

using System.Linq;
using System.Text;

namespace CoinFlare
{
    internal static partial class HttpHelper
    {
        #region MSG_METHODS
        // NOTE --> 
        // The methods below are unorthadox, as you could just simply create a
        // readonly dictionary and use references, or you could serialize methods
        // to import from external libraries, but this is easy to use as the client
        // isn't receiving too much data...
        // <-- END NOTE

        public static void CreateMarketBuy(string coinType, float amount, float buyValue, DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(placeBuy);
            s.Append("&cointype=" + coinType);
            s.Append("&amount=" + amount);
            s.Append("&rate=" + buyValue);

            ProcessRequest(s, endCallback);
        }

        public static void CreateMarketSell(string coinType, float amount, float sellValue, DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(placeSell);
            s.Append("&cointype=" + coinType);
            s.Append("&amount=" + amount);
            s.Append("&rate=" + sellValue);

            ProcessRequest(s, endCallback);
        }

        public static void CreateCryptoData(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(latest);
            ProcessRequest(s, endCallback);
        }

        public static void CreateBalanceRequest(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(myBalances);
            ProcessRequest(s, endCallback);
        }

        public static void CreateCancelBuy(string buyId, DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(cancelBuy);
            s.Append("&id=" + buyId);

            ProcessRequest(s, endCallback);
        }

        public static void CreateCancelSell(string sellId, DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(cancelSell);
            s.Append("&id=" + sellId);

            ProcessRequest(s, endCallback);
        }

        public static void CreateQuickBuy(string coinType, float amount, DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(quickBuy);
            s.Append("&coinType=" + coinType);
            s.Append("&amount=" + amount);

            ProcessRequest(s, endCallback);
        }

        public static void CreateQuickSell(string coinType, float amount, DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(quickSell);
            s.Append("&cointype=" + coinType);
            s.Append("&amount=" + amount);

            ProcessRequest(s, endCallback);
        }

        public static void CreateMyOrderRequest(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(myOrders);
            ProcessRequest(s, endCallback);
        }

        public static void CreateSendOrder(string coinType, Contributor contributor, float amount, DynamicEventHandler endCallback)
        {
            var s = new StringBuilder(sendCoin);
            s.Append("&cointype=" + coinType);
            s.Append("&destination=" + contributor.WalletIds.Where(
                id => id.Key.ToLower() == coinType.ToLower()).FirstOrDefault());
            s.Append("&amount=" + amount);

            ProcessRequest(s, endCallback);
        }
        #endregion

        private static void ProcessRequest(StringBuilder s, DynamicEventHandler endCallback)
        {
            var data = GetData(s.ToString());
            if (ClientMessages.ContainsKey(s.ToString()))
            {
                if (data != null)
                {
                    ClientMessages[s.ToString()]?.Invoke(data);
                }
            }
            else
            {
                if (data != null)
                {
                    endCallback?.Invoke(data);
                }
            }
        }
    }
}