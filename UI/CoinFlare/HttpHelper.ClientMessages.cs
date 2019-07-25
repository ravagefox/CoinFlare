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

using System.Text;
using System.Threading.Tasks;

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

        public static void CreateMarketBuy(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(placeBuy);
            ProcessRequest(s, endCallback);
        }

        public static void CreateMarketSell(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(placeSell);
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

        public static void CreateCancelBuy(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(cancelBuy);
            ProcessRequest(s, endCallback);
        }

        public static void CreateCancelSell(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(cancelSell);
            ProcessRequest(s, endCallback);
        }

        public static void CreateQuickBuy(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(quickBuy);
            ProcessRequest(s, endCallback);
        }

        public static void CreateQuickSell(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(quickSell);
            ProcessRequest(s, endCallback);
        }

        public static void CreateMyOrderRequest(DynamicEventHandler endCallback)
        {
            // Build the string and create a wait task.
            var s = new StringBuilder(myOrders);
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