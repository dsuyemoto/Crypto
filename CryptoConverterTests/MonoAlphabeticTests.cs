using CryptoConverter;
using NUnit.Framework;

namespace CryptoConverterTests
{
    [TestFixture()]
    public class MonoAlphabeticTests
    {
        MonoAlphabetic _monoAlphabetic;

        const string KEYNAME = "suyemoto";
        const string UNENCRYPTEDTEXT = "please encyrpt this!";
        const string ENCRYPTEDTEXT = "jfmsnm mhyxljp pabn!";
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        [SetUp]
        public void Setup()
        {
            _monoAlphabetic = new MonoAlphabetic(KEYNAME, ALPHABET);
        }

        [Test()]
        public void Encrypt_AreEqualTest()
        { 
            var encrypted = _monoAlphabetic.Encrypt(UNENCRYPTEDTEXT);

            Assert.AreEqual(ENCRYPTEDTEXT, encrypted);
        }

        [Test()]
        public void Decrypt_AreEqualTest()
        {
            var unencrypted = _monoAlphabetic.Decrypt(ENCRYPTEDTEXT);

            Assert.AreEqual(UNENCRYPTEDTEXT, unencrypted);
        }
    }
}
