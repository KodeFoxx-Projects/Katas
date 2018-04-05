namespace Kodefoxx.Katas.FizzBuzz.Strategies
{
    /// <inheritdoc />
    /// <summary>
    /// This strategy will output 
    /// - "Fizz" for every multiple of three; or of the number contains "3",
    /// - "Buzz" for every multiple of five; or if the number contains "5"
    /// - and "FizzBuzz" for every multiple of both three and five 
    /// </summary>
    public sealed class Stage2FizzBuzzCalculationStrategy : IFizzBuzzCalculationStrategy
    {
        /// <inheritdoc />
        public string CalculateFizzBuzzStringRepresentation(int number)
        {
            if (number % (3 * 5) == 0) return "FizzBuzz";

            if (number.ToString().Contains("3")) return "Fizz";
            if (number.ToString().Contains("5")) return "Buzz";

            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";

            return number.ToString();
        }
    }
}
