namespace CryptoConverterNET
{
    public class Substitution : ICryptoService
    {
        Dictionary<char, char> _keytable;
        protected char[] _keys;
        protected char[] _pairs;

        public Substitution(string key, string alphabet)
        {
            _keytable = new Dictionary<char, char>();
            _keys = key.ToCharArray();
            _pairs = alphabet.ToCharArray();
        }

        public virtual string Decrypt(string cipherText)
        {
            CreateUnencryptedTable();
            return Lookup(cipherText);
        }

        public virtual string Encrypt(string plainText)
        {
            CreateEncryptedTable();
            return Lookup(plainText);
        }

        public bool Validator(string plaintext, bool isEncrypted = false)
        {
            
            if (isEncrypted)
                CreateEncryptedTable();
            else
                CreateUnencryptedTable();

            if (!CheckValidKeys(plaintext)) return false;

            return true;
        }

        protected virtual void CreateEncryptedTable()
        {
            if (_keys.Length != _pairs.Length) 
                throw new Exception($"Length of keys and pairs do not match : keys={_keys.Length}, pairs={_pairs.Length}");

            _keytable = new Dictionary<char, char>();

            for (var i = 0; i < _keys.Length; i++)
                _keytable.Add(_pairs[i], _keys[i]);
        }

        protected virtual void CreateUnencryptedTable()
        {
            if (_keys.Length != _pairs.Length)
                throw new Exception($"Length of keys and pairs do not match : keys={_keys.Length}, pairs={_pairs.Length}");

            _keytable = new Dictionary<char, char>();

            for (var i = 0; i < _keys.Length; i++)
                _keytable.Add(_keys[i], _pairs[i]);
        }

        protected string Lookup(string text)
        {
            var lookupText = text.ToCharArray();
            var result = new char[text.Length];

            for (var i = 0; i < text.Length; i++)
            {
                char found;
                if (_keytable.TryGetValue(lookupText[i], out found))
                {
                    result[i] = found;
                }
                else
                {
                    result[i] = lookupText[i];
                }
            }

            return new string(result);
        }

        private bool CheckValidKeys(string plaintext)
        {
            var text = plaintext.ToCharArray();

            foreach (var character in text)
                if (!_keytable.ContainsKey(character)) return false;

            return true;
        }
    }
}
