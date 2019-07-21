// Source: Contributor
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

namespace CoinFlare
{
    public partial struct Contributor
    {

        // TODO: move contributors to a secure database hosted at
        // Crexium to ensure contributors get their share from users.
        internal static readonly Contributor[] Contributors = new[]
        {
            // Insert your contributor Id, and you will be subject to receiving
            // a contribution benefit from users.
            new Contributor()
            {
                EmailAddress = "ravagefox@live.com",
                WalletIds = new string[]
                {
                    "rBgnUKAEiFhCRLPoYNPPe3JUWayRjP6Ayg", // XRP
                    "1P8yYstqFpdf5voYT71cXeMuLQNytV2ayk", // BTC
                    "0x2f28a5f2c956ab82df4316408f0e59db4af09dc3", // ETH
                    "ME48kkGFoYD7cbsu65jo9xErXEw66PhkS6", // LTC
                },
                MemberSince = new DateTime(2019, 07, 18),
            },

            // Create a new ID
        };

    }
}