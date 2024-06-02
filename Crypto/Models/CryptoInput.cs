using CryptoConverter;

namespace Crypto.Models
{
    public class CryptoInput
    {
        public string Key { get; set; }
        public string Data { get; set; }
        public Alphabet Alphabet { get; set; }
        public bool IsEncrypted { get; set; }

        public CryptoInput()
        {
            
        }
    }
}
