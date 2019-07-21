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
    [Serializable]
    public partial struct Contributor
    {
        public string[] WalletIds { get; internal set; }

        public DateTime MemberSince { get; internal set; }

        public string EmailAddress { get; internal set; }

        public string[] Tags { get; internal set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Contributor))
                return false;

            return ((Contributor)obj).GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            var walletIdHashSet = 0;
            for (var i = 0; i < this.WalletIds.Length; i++)
            {
                walletIdHashSet |= this.WalletIds[i].GetHashCode();
            }
            for (var i = 0; i < this.Tags.Length; i++)
            {
                walletIdHashSet |= this.Tags[i].GetHashCode();
            }

            return this.WalletIds.GetHashCode() +
                      this.EmailAddress.GetHashCode() +
                      walletIdHashSet;
        }

        public override string ToString()
        {
            return this.EmailAddress;
        }


        public static bool operator ==(Contributor lhs, Contributor rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Contributor lhs, Contributor rhs)
        {
            return !(lhs == rhs);
        }
    }
}