namespace CryptoConverter
{
    public interface IConverter
    {
        string Decrypt(string cipherText);
        string Encrypt(string plainText);
        bool Validator(string text, bool isEncrypted);
    }
}