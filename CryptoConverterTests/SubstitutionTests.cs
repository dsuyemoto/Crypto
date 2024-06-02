using CryptoConverter;
using NUnit.Framework;

namespace CryptoConverterTests
{
    [TestFixture()]
    class SubstitutionTests
    {
        const string UNENCRYPTEDTEXT = "ABCDEFGH";
        const string ENCRYPTEDTEXT = "ZYXWVUTS";

        Converter _converter;
        const string KEYS = "ZYXWVUTSRQPONMLKJIHGFEDCBA";
        const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        [SetUp]
        public void Setup()
        {
            _converter = new Converter(Converter.ConverterType.Substitution, KEYS, new Alphabet(Alphabet.AlphabetType.Latin));
        }

        [Test()]
        public void Encrypt_Conversion_AreEqualTest()
        {
            var encrypted = _converter.Encrypt(UNENCRYPTEDTEXT);

            Assert.AreEqual(ENCRYPTEDTEXT, encrypted);
        }

        [Test()]
        public void Validator_Unencrypted_TrueTest()
        {
            Assert.IsTrue(_converter.Validator(ALPHABET, false));
        }

        [Test()]
        public void Validator_Encrypted_TrueTest()
        {
            Assert.IsTrue(_converter.Validator(KEYS, true));
        }

        [Test()]
        public void Decrypt_Conversion_AreEqualTest()
        {
            var unencrypted = _converter.Decrypt(ENCRYPTEDTEXT);

            Assert.AreEqual(UNENCRYPTEDTEXT, unencrypted);
        }
    }
}
