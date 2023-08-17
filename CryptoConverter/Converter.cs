namespace CryptoConverter
{
    public class Converter : IConverter
    {
        IConverter _converter;

        public enum ConverterType
        {
            Vignere,
            MonoAlphabetic,
            Substitution
        }

        public Converter(ConverterType converter, string keys, string alphabet)
        {
            if (converter == ConverterType.Vignere)
                _converter = new Vignere(keys, alphabet);
            if (converter == ConverterType.Substitution)
                _converter = new Substitution(keys, alphabet);
            if (converter == ConverterType.MonoAlphabetic)
                _converter = new MonoAlphabetic(keys, alphabet);
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
