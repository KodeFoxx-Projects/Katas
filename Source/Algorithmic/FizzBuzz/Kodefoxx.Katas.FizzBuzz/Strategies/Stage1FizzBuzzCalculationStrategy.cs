namespace Kodefoxx.Katas.FizzBuzz.Strategies
{
    /// <inheritdoc />
    /// <summary>
    /// This strategy will output 
    /// - "Fizz" for every multiple of three, 
    /// - "Buzz" for every multiple of five
    /// - and "FizzBuzz" for every multiple of both three and five
    /// </summary>
    public sealed class Stage1FizzBuzzCalculationStrategy : IFizzBuzzCalculationStrategy
    {
        /// <inheritdoc />
        public string CalculateFizzBuzzStringRepresentation(int number)
        {
            if (number % (3 * 5) == 0) return "FizzBuzz";
            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";

            return number.ToString();
        }
    }
}
