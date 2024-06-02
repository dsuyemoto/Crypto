using CryptoConverter;
using NUnit.Framework;

namespace CryptoConverterTests
{
    [TestFixture()]
    public class VignereTests
    {
        Converter _converter;

        const string KEY = "suyemoto";
        const string UNENCRYPTEDTEXT = "this is a test";
        const string ENCRYPTEDTEXT = "lbgw wl s rieh";
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        [SetUp]
        public void SetUp()
        {
            _converter = new Converter(Converter.ConverterType.Vignere, KEY, new Alphabet(Alphabet.AlphabetType.Latin));
        }

        [Test()]
        public void Encrypt_Conversion_AreEqualTest()
        {
            var encrypted = _converter.Encrypt(UNENCRYPTEDTEXT);

            Assert.AreEqual(ENCRYPTEDTEXT, encrypted);
        }

        [Test()]
        public void Decrypt_Conversion_AreEqualTest()
        {
            var unencrypted = _converter.Decrypt(ENCRYPTEDTEXT);

            Assert.AreEqual(UNENCRYPTEDTEXT, unencrypted);
        }

        [Test()]
        public void GetCharStream_Position_AreEqualTest()
        {
            var result = Vignere.GetCharFromAlphabet(ALPHABET.ToCharArray(), 'g', 25);

            Assert.AreEqual('f', result);
        }
    }
}
