using System;

namespace Kodefoxx.Katas.FizzBuzz.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzzGenerator = new DefaultFizzBuzzGenerator();

            foreach (var fizzBuzzValue in fizzBuzzGenerator.Generate())
                Console.WriteLine($"{fizzBuzzValue.Key:000}: \"{fizzBuzzValue.Value}\"");                

            Console.ReadLine();
        }
    }
}
