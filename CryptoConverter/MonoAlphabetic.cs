using System.Collections.Generic;

namespace CryptoConverter
{
    public class MonoAlphabetic : Substitution
    {

        public MonoAlphabetic(string key, string alphabet) : base(key, alphabet)
        {
        }

        public override string Decrypt(string cipherText)
        {
            CreateUnencryptedTable();
            return Lookup(cipherText);
        }

        public override string Encrypt(string plainText)
        {
            CreateEncryptedTable();
            return Lookup(plainText);
        }

        protected override void CreateEncryptedTable()
        {
            if (_keys.Length < _pairs.Length)
                _keys = GetKeystream(GetUniqueKey(_keys));
            base.CreateEncryptedTable();
        }

        protected override void CreateUnencryptedTable()
        {
            if (_keys.Length < _pairs.Length)
                _keys = GetKeystream(GetUniqueKey(_keys));
            base.CreateUnencryptedTable();
        }

        private char[] GetUniqueKey(char[] keys)
        {
            var list = new List<char>();
            foreach (var keychar in keys)
                if (!list.Contains(keychar))
                    list.Add(keychar);
            return list.ToArray();
        }

        private char[] GetKeystream(char[] uniquekey)
        {
            var rightKey = new string(_pairs);
            foreach (var key in uniquekey)
                rightKey = rightKey.Replace(key.ToString(), "");

            return (new string(uniquekey) + rightKey).ToCharArray();
        }

    }
}
