using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.FizzBuzz
{
    /// <inheritdoc />
    public sealed class DefaultFizzBuzzGenerator : IFizzBuzzGenerator
    {
        /// <inheritdoc />
        public IDictionary<int, string> Generate()
            => Enumerable.Range(1, 100)
                .ToDictionary(
                    keySelector: number => number, 
                    elementSelector: CalculateFizzBuzzPresentation
                )
        ;

        /// <summary>
        /// Calculates which representation the number has in the "FizzBuzz" sequence.
        /// </summary>
        /// <param name="number">The number to be translated to it's "FizzBuzz" sequence value.</param>
        /// <returns>A <see cref="string"/> holding the "FizzBuzz" sequence value for the given <paramref name="number"/>.</returns>
        private string CalculateFizzBuzzPresentation(int number)
        {
            if (number % (3 * 5) == 0) return "FizzBuzz";
            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";

            return number.ToString();
        }
    }
}
