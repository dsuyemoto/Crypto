using CryptoConverter;
using System;

namespace CryptoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ENCRYPT = "D1";
            const string DECRYPT = "D2";

            var converter = new Converter(
                Converter.ConverterType.Vignere,
                "suyemoto",
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                );

            ConsoleKeyInfo selection;

            do {
                Console.WriteLine("Press [1] to encrypt or [2] to decrypt");
                selection = Console.ReadKey();
                Console.WriteLine();
            } while (selection.Key.ToString() != ENCRYPT && selection.Key.ToString() != DECRYPT);

            string input = null;
            while (input == null)
            {
                if (selection.Key.ToString() == ENCRYPT)
                {
                    Console.WriteLine("Enter data to encrypt");
                    input = Console.ReadLine();
                    var encrypted = converter.Encrypt(input);
                    Console.WriteLine(encrypted);
                }
                if (selection.Key.ToString() == DECRYPT)
                {
                    Console.WriteLine("Enter data to decrypt");
                    input = Console.ReadLine();
                    var decrypted = converter.Decrypt(input);
                    Console.WriteLine(decrypted);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
