using CryptoConverterNET;

namespace CryptoConverterTests
{
    [TestFixture()]
    class SubstitutionPolyAlphabeticTests
    {
        const string UNENCRYPTEDTEXT = "ABCDEFGH";
        const string ENCRYPTEDTEXT = "ZYXWVUTS";

        CryptoService _converter;
        const string KEY = "ZYXWVUTSRQPONMLKJIHGFEDCBA";
        const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        [SetUp]
        public void Setup()
        {
            _converter = new CryptoService(CryptoService.CryptoType.PolyAlphabetic, KEY, ALPHABET);
        }

        [Test()]
        public void Encrypt_Conversion_AreEqualTest()
        {
            var encrypted = _converter.Encrypt(UNENCRYPTEDTEXT);

            Assert.That(encrypted, Is.EqualTo(ENCRYPTEDTEXT));
        }

        [Test()]
        public void Validator_Unencrypted_TrueTest()
        {
            Assert.That(_converter.Validator(ALPHABET, false), Is.True);
        }

        [Test()]
        public void Validator_Encrypted_TrueTest()
        {
            Assert.That(_converter.Validator(KEY, true), Is.True);
        }

        [Test()]
        public void Decrypt_Conversion_AreEqualTest()
        {
            var unencrypted = _converter.Decrypt(ENCRYPTEDTEXT);

            Assert.That(unencrypted, Is.EqualTo(UNENCRYPTEDTEXT));
        }
    }
}
