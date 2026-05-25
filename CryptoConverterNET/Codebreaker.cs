using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConverterNET
{
    internal class Codebreaker
    {
        public static string Decrypt(string cipherText)
        {
            var key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var cryptoservice = new CryptoService(CryptoService.CryptoType.MonoAlphabetic, key, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");

            var words = cipherText.Split(' ');
            var decryptedWords = new string[words.Length];
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var decryptedWord = cryptoservice.Decrypt(word);
                decryptedWords[i] = decryptedWord;
            }
            


        }

    }
}
