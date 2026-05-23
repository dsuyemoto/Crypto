using CryptoConverterNET;

namespace CryptoConverterTests
{
    [TestFixture()]
    public class SubstitutionMonoAlphabeticTests
    {
        SubstitutionMonoAlphabetic _monoAlphabetic;

        const string KEY = "zyxwvutsrqponmlkjihgfedcbaZYXWVUTSRQPONMLKJIHGFEDCBA";
        const string UNENCRYPTEDTEXT = "Please encyrpt this!";
        const string ENCRYPTEDTEXT = "Kovzhv vmxbikg gsrh!";
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        [SetUp]
        public void Setup()
        {
            _monoAlphabetic = new SubstitutionMonoAlphabetic(KEY, ALPHABET);
        }

        [Test()]
        public void Encrypt_AreEqualTest()
        { 
            var encrypted = _monoAlphabetic.Encrypt(UNENCRYPTEDTEXT);

            Assert.That(encrypted, Is.EqualTo(ENCRYPTEDTEXT));
        }

        [Test()]
        public void Decrypt_AreEqualTest()
        {
            var unencrypted = _monoAlphabetic.Decrypt(ENCRYPTEDTEXT);

            Assert.That(unencrypted, Is.EqualTo(UNENCRYPTEDTEXT));
        }

        [Test()]
        public void KeysAlphabet_NotEqual_ThrowsExceptionTest()
        {
            Assert.Throws<Exception>(() => new CryptoService(CryptoService.CryptoType.MonoAlphabetic, KEY, "1234"));                                                                                                                                                                      
        }
    }
}
