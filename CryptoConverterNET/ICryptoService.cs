namespace CryptoConverterNET
{
    public interface ICryptoService
    {
        string Decrypt(string cipherText);
        string Encrypt(string plainText);
        bool Validator(string text, bool isEncrypted);
    }
}