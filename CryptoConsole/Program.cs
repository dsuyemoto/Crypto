using CryptoConverterNET;
using System;

namespace CryptoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ENCRYPT = "D1";
            const string DECRYPT = "D2";
            const string EXIT = "D3";

            var converter = new CryptoService(
                CryptoService.CryptoType.Vignere,
                "suyemoto",
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                );

            ConsoleKeyInfo selection;

            do {
                Console.WriteLine("Press [1] to encrypt or [2] to decrypt or [3] to exit");
                selection = Console.ReadKey();
                Console.WriteLine();
                string input = null;
                if (selection.Key.ToString() == ENCRYPT)
                {
                    Console.WriteLine("Enter data to encrypt:");
                    input = Console.ReadLine();
                    var encrypted = converter.Encrypt(input);
                    Console.WriteLine(encrypted);
                }
                if (selection.Key.ToString() == DECRYPT)
                {
                    Console.WriteLine("Enter data to decrypt:");
                    input = Console.ReadLine();
                    var decrypted = converter.Decrypt(input);
                    Console.WriteLine(decrypted);
                }
            } while (selection.Key.ToString() != EXIT);
        }
    }
}
