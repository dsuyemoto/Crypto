using System;
using System.Security.Cryptography;
using System.Text;

namespace RandomNumberGenerator
{
    public class RNG
    {
        RNGCryptoServiceProvider rngCryptoSP;

        public RNG()
        {
            rngCryptoSP = new RNGCryptoServiceProvider();
        }

        public int GetNumber()
        {
            var number = Encoding.UTF8.GetBytes("1");

            rngCryptoSP.GetBytes(number);
            var value = number.GetValue(0);
            var ranNumber = value.ToString();

            return int.Parse(ranNumber);
        }
    }
}
