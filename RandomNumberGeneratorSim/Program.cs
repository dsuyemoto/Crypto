using RandomNumberGenerator;
using System;

namespace RandomNumberGeneratorSim
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new RNG();

            var count = int.Parse(args[0]);

            for(var number = 0;number < count; number++)
            {
                Console.WriteLine("{0} : {1}", number, rng.GetNumber());
            }

            Console.Read();
        }
    }
}
