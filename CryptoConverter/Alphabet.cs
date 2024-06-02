using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoConverter
{
    public class Alphabet
    {
        public enum AlphabetType
        {
            Latin
        }

        public Alphabet(AlphabetType alphabetType)
        {
            Characters = "abcdefghijklmnopqrstuvwxyz";
        }

        public string Characters { get; set; } 
    }
}
