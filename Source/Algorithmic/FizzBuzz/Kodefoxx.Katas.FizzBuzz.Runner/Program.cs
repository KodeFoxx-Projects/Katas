using System;
using Kodefoxx.Katas.FizzBuzz.Strategies;

namespace Kodefoxx.Katas.FizzBuzz.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintFizzBuzzGeneratorOutput("Stage 1", new DefaultFizzBuzzGenerator(new Stage1FizzBuzzCalculationStrategy()));
            PrintFizzBuzzGeneratorOutput("Stage 2", new DefaultFizzBuzzGenerator(new Stage2FizzBuzzCalculationStrategy()));

            Console.ReadLine();
        }

        private static void PrintFizzBuzzGeneratorOutput(string header, DefaultFizzBuzzGenerator fizzBuzzGenerator)
        {
            PrintHeader(header);
            foreach (var fizzBuzzValue in fizzBuzzGenerator.Generate())
                Console.WriteLine($" - {fizzBuzzValue.Key:000}: \"{fizzBuzzValue.Value}\"");
            PrintFooter();
        }

        private static void PrintHeader(string header)
        {
            Console.WriteLine("//");
            Console.WriteLine($"/// {header}");
        }

        private static void PrintFooter()
        {
            Console.WriteLine("///");
            Console.WriteLine("//");
            Console.WriteLine();
        }
    }
}
