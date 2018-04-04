namespace Kodefoxx.Katas.FizzBuzz
{
    /// <summary>
    /// Defines a strategy for calculating which representation the number has in the "FizzBuzz" sequence.
    /// </summary>
    public interface IFizzBuzzCalculationStrategy
    {
        /// <summary>
        /// Calculates which representation the number has in the "FizzBuzz" sequence.
        /// </summary>
        /// <param name="number">The number to be translated to it's "FizzBuzz" sequence value.</param>
        /// <returns>A <see cref="string"/> holding the "FizzBuzz" sequence value for the given <paramref name="number"/>.</returns>
        string CalculateFizzBuzzStringRepresentation(int number);
    }
}
