using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.FizzBuzz
{
    /// <inheritdoc />
    public sealed class DefaultFizzBuzzGenerator : IFizzBuzzGenerator
    {
        private readonly IFizzBuzzCalculationStrategy _fizzBuzzCalculationStrategy;

        public DefaultFizzBuzzGenerator(IFizzBuzzCalculationStrategy fizzBuzzCalculationStrategy)
            => _fizzBuzzCalculationStrategy = fizzBuzzCalculationStrategy;

        /// <inheritdoc />
        public IDictionary<int, string> Generate()
            => Enumerable.Range(1, 100)
                .ToDictionary(
                    keySelector: number => number, 
                    elementSelector: number => _fizzBuzzCalculationStrategy.CalculateFizzBuzzStringRepresentation(number)
                )
        ;        
    }
}
