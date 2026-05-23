namespace CryptoConverterNET
{
    public class CryptoService : ICryptoService
    {
        ICryptoService _converter;

        public enum CryptoType
        {
            Vignere,
            MonoAlphabetic,
            PolyAlphabetic
        }

        public CryptoService(CryptoType converter, string keys, string alphabet)
        {
            if (converter == CryptoType.Vignere)
                _converter = new Vignere(keys, alphabet);
            if (converter == CryptoType.PolyAlphabetic)
                _converter = new Substitution(keys, alphabet);
            if (converter == CryptoType.MonoAlphabetic)
                _converter = new SubstitutionMonoAlphabetic(keys, alphabet);
        }

        public string Encrypt(string unencryptedText)
        {
            return _converter.Encrypt(unencryptedText);
        }

        public string Decrypt(string encryptedText)
        {
            return _converter.Decrypt(encryptedText);
        }

        public bool Validator(string text, bool isEncrypted)
        {
            return _converter.Validator(text, isEncrypted);
        }
    }
}
