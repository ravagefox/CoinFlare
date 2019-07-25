// Source: CryptoTask
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

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinFlare
{
    public class CryptoTask
    {

        private const float percentage = .01f;


        public string TokenId { get; }

        public decimal StartAmount { get; set; }

        public decimal FinalAmount { get; set; }


        public CryptoTask(string coinType)
        {
            this.TokenId = coinType;
        }

        public void BeginWait(params Contributor[] contributors)
        {
            var ca = this.StartAmount - this.FinalAmount;
            ca *= (decimal)percentage;

            var ps = this.GetPayees(contributors);
            ca /= ps.Count;

            Task.Run(async () =>
            {
                // Wait until the final amount does not equal the starting amount
                // to process the transaction to all the contributors.
                await TaskEx.WaitUntil(() => { return FinalAmount != StartAmount; });

                // Send the generous donation to all the contributors
                // specified.
                foreach (var payee in ps)
                {
                    HttpHelper.CreateSendOrder(this.TokenId, payee, (float)ca, (result) =>
                    {
                        // Do something with resulting data.
                    });
                }
            });
        }


        private List<Contributor> GetPayees(Contributor[] contributors)
        {
            var p = new List<Contributor>();
            foreach (var c in contributors)
            {
                Parallel.ForEach(c.WalletIds, (walletId) =>
                {
                    if (string.Compare(walletId.Key.ToLower(), this.TokenId.ToLower()) == 0)
                    {
                        p.Add(c);
                    }
                });
            }

            return p;
        }
    }
}