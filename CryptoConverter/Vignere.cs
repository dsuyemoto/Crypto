using System;
using System.Text;

namespace CryptoConverter
{
    public class Vignere : IConverter
    {
        char[] _keys;
        char[] _alphabet;

        public char[] KeystreamMirror { get; set; }

        public Vignere(string key, string alphabet)
        {
            _keys = key.ToCharArray();
            _alphabet = alphabet.ToCharArray();
        }

        public string Decrypt(string cipherText)
        {
            var cipherTextArray = cipherText.ToCharArray();
            var unencryptedArray = Translate(cipherTextArray, true);

            return new string(unencryptedArray);
        }

        public string Encrypt(string plainText)
        {
            var plainTextArray = plainText.ToCharArray();
            var encryptedArray = Translate(plainTextArray, false);

            return new string(encryptedArray);
        }
        
        private char[] Translate(char[] textArray, bool isEncrypted)
        {
            var keyspointer = 0;
            var translatedArray = new char[textArray.Length];

            for (var i = 0; i < textArray.Length; i++)
            {
                var keynumber = GetNumberFromAlphabet(_keys[keyspointer], _alphabet);
                if (isEncrypted) keynumber = keynumber * -1;
                translatedArray[i] = GetCharFromAlphabet(_alphabet, textArray[i], keynumber);
                keyspointer++;
                if (keyspointer == _keys.Length) keyspointer = 0;
            }

            return translatedArray;
        }

        public static char GetCharFromAlphabet(char[] alphabet, char character, int shift)
        {
            int encryptedCharPosition = GetNumberFromAlphabet(character, alphabet);

            if (encryptedCharPosition == -1) return character;

            var unencryptedPosition = encryptedCharPosition + shift;
            if (unencryptedPosition < alphabet.Length - 1)
                unencryptedPosition = unencryptedPosition + alphabet.Length;
            if (unencryptedPosition > alphabet.Length-1)
                unencryptedPosition = unencryptedPosition - alphabet.Length;

            return alphabet[unencryptedPosition];
        }

        private static int GetNumberFromAlphabet(char character, char[] alphabet)
        {
            for (var a = 0; a < alphabet.Length; a++)
            {
                if (character == alphabet[a])
                    return a;
            }

            return -1;
        }

        public bool Validator(string text, bool isEncrypted)
        {
            throw new NotImplementedException();
        }
    }
}
