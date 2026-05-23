using CryptoConverterNET;

namespace CryptoConverterTests
{
    [TestFixture()]
    public class VignereTests
    {
        CryptoService _converter;

        const string KEY = "suyemoto";
        const string UNENCRYPTEDTEXT = "this is a test";
        const string ENCRYPTEDTEXT = "lbgw wl s rieh";
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        [SetUp]
        public void SetUp()
        {
            _converter = new CryptoService(CryptoService.CryptoType.Vignere, KEY, ALPHABET);
        }

        [Test()]
        public void Encrypt_Conversion_AreEqualTest()
        {
            var encrypted = _converter.Encrypt(UNENCRYPTEDTEXT);

            Assert.That(encrypted, Is.EqualTo(ENCRYPTEDTEXT));
        }

        [Test()]
        public void Decrypt_Conversion_AreEqualTest()
        {
            var unencrypted = _converter.Decrypt(ENCRYPTEDTEXT);

            Assert.That(unencrypted, Is.EqualTo(UNENCRYPTEDTEXT));
        }

        [Test()]
        public void GetCharStream_Position_AreEqualTest()
        {
            var result = Vignere.GetCharFromAlphabet(ALPHABET.ToCharArray(), 'g', 25);

            Assert.That(result, Is.EqualTo('f'));
        }
    }
}
