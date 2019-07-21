// Source: Crypto
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlare
{
    [Serializable]
    public struct Crypto
    {
        public float Ask { get; }

        public float Bid { get; }

        public float Last { get; }

        public DateTime Time { get; }


        private readonly string name;


        public Crypto(string token, dynamic data)
        {
            this.name = token;
            this.Ask = data.ask;
            this.Bid = data.bid;
            this.Last = data.last;
            this.Time = DateTime.Now;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Crypto))
                return false;

            return ((Crypto)obj).GetHashCode() == this.GetHashCode();
        }

        public override string ToString()
        {
            return name;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(this.Ask).GetHashCode() +
                      Convert.ToInt32(this.Bid).GetHashCode() +
                      Convert.ToInt32(this.Last).GetHashCode() +
                      Convert.ToInt32(this.Time.ToBinary()).GetHashCode() +
                      name.GetHashCode();
        }

        public static bool operator ==(Crypto lhs, Crypto rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Crypto lhs, Crypto rhs)
        {
            return !(lhs == rhs);
        }
    }
}
