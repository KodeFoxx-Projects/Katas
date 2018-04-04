using System.Collections.Generic;

namespace Kodefoxx.Katas.FizzBuzz
{
    /// <summary>
    /// Generates a "FizzBuzz" sequence from 1 to 100.
    /// </summary>
    public interface IFizzBuzzGenerator
    {
        /// <summary>
        /// Generates a "FizzBuzz" sequence from 1 to 100.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/>, where the key is the order from 1 to 100.</returns>
        IDictionary<int, string> Generate();
    }
}
