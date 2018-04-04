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
                    elementSelector: number => number.ToString()
                )
        ;
    }
}
