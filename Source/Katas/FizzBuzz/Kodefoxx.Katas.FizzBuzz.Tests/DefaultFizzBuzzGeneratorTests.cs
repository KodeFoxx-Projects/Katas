using System;
using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.FizzBuzz.Strategies;
using Xunit;

namespace Kodefoxx.Katas.FizzBuzz.Tests
{
    public sealed class DefaultFizzBuzzGeneratorTests
    {
        #region Tests
        [Fact]
        public void Returns_hundred_values()
            => Assert.Equal(100, CreateSystemUnderTest().Generate().Keys.Count);

        [Fact]
        public void Returns_numbers_one_to_hundred()
            => Assert.Equal(5050, CreateSystemUnderTest().Generate().Keys.Sum());

        [Theory, MemberData(nameof(Multiples_of_three_should_have_the_value_Fizz_TestData))]
        public void Multiples_of_three_should_have_the_value_Fizz(int multipleOfThree)
            => Assert.Equal("Fizz", CreateSystemUnderTest().Generate()[multipleOfThree]);

        public static IEnumerable<object[]> Multiples_of_three_should_have_the_value_Fizz_TestData()
            => ToEnumerableOfObjectArray(
                GenerateMultiplesOf(3, IsNotAMultipleOfThreeAndFive)
        );

        [Theory, MemberData(nameof(Multiples_of_three_and_numbers_containing_three_should_have_the_value_Fizz_when_using_stage2_TestData))]
        public void Multiples_of_three_and_numbers_containing_three_should_have_the_value_Fizz_when_using_stage2(int multipleOfThree)
            => Assert.Equal("Fizz", CreateSystemUnderTest(new Stage2FizzBuzzCalculationStrategy()).Generate()[multipleOfThree]);

        public static IEnumerable<object[]> Multiples_of_three_and_numbers_containing_three_should_have_the_value_Fizz_when_using_stage2_TestData()
            => ToEnumerableOfObjectArray(
                GenerateMultiplesOf(3, number => IsNotAMultipleOfThreeAndFive(number) && ContainsTheNumberThree(number))
            );

        [Theory, MemberData(nameof(Multiples_of_five_should_have_the_value_Buzz_TestData))]
        public void Multiples_of_five_should_have_the_value_Buzz(int multipleOfFive)
            => Assert.Equal("Buzz", CreateSystemUnderTest().Generate()[multipleOfFive]);

        public static IEnumerable<object[]> Multiples_of_five_should_have_the_value_Buzz_TestData()
            => ToEnumerableOfObjectArray(
                GenerateMultiplesOf(5, IsNotAMultipleOfThreeAndFive)
        );

        [Theory, MemberData(nameof(Multiples_of_five_and_numbers_containing_five_should_have_the_value_Buzz_when_using_stage2_TestData))]
        public void Multiples_of_five_and_numbers_containing_five_should_have_the_value_Buzz_when_using_stage2(int multipleOfFive)
            => Assert.Equal("Buzz", CreateSystemUnderTest(new Stage2FizzBuzzCalculationStrategy()).Generate()[multipleOfFive]);

        public static IEnumerable<object[]> Multiples_of_five_and_numbers_containing_five_should_have_the_value_Buzz_when_using_stage2_TestData()
            => ToEnumerableOfObjectArray(
                GenerateMultiplesOf(3, number => IsNotAMultipleOfThreeAndFive(number) && ContainsTheNumberFive(number))
            );

        [Theory, MemberData(nameof(Multiples_of_three_and_five_should_have_the_value_FizzBuzz_TestData))]
        public void Multiples_of_three_and_five_should_have_the_value_FizzBuzz(int multipleOfFive)
            => Assert.Equal("FizzBuzz", CreateSystemUnderTest().Generate()[multipleOfFive]);

        public static IEnumerable<object[]> Multiples_of_three_and_five_should_have_the_value_FizzBuzz_TestData()
            => ToEnumerableOfObjectArray(
                GenerateMultiplesOf(1, IsAMultipleOfThreeAndFive)
            );
        #endregion

        #region Test Helper Functions
        /// <summary>
        /// Converts an enumerable of <typeparam name="TObject"></typeparam> to an enumerable of object[].
        /// </summary>        
        /// <param name="enumerable">The enumerable to convert.</param>
        /// <returns>An enumerable of object[].</returns>
        private static IEnumerable<object[]> ToEnumerableOfObjectArray<TObject>(IEnumerable<TObject> enumerable)
            => enumerable.Select(@object => new object[] { @object });

        /// <summary>
        /// Generates a sequence <see cref="int"/> that are multiples of <paramref name="multipleOf"/> between 1 and 100.
        /// </summary>
        /// <param name="multipleOf">The multiplier.</param>
        /// <param name="predicate">Decides whether or not to include a number, even if it is a valid multiple of.</param>
        /// <returns>A sequence <see cref="int"/> that are multiples of <paramref name="multipleOf"/> between 1 and 100.</returns>
        private static IEnumerable<int> GenerateMultiplesOf(int multipleOf, Func<int, bool> predicate = null)
            => Enumerable.Range(1, 100)
                .Where(number => number % multipleOf == 0)
                .Where(number => predicate?.Invoke(number) ?? true);

        /// <summary>
        /// Predicate that takes an <see cref="int"/> and determines whether it isn't a multiple of three and five.
        /// </summary>
        private static Func<int, bool> IsNotAMultipleOfThreeAndFive
            => number => !IsAMultipleOfThreeAndFive(number);

        /// <summary>
        /// Predicate that takes an <see cref="int"/> and determines whether it is a multiple of three and five.
        /// </summary>
        private static Func<int, bool> IsAMultipleOfThreeAndFive
            => number => number % (3 * 5) == 0;

        /// <summary>
        /// Predicate that takes an <see cref="int"/> and determines whether it contains the number three.
        /// </summary>
        private static Func<int, bool> ContainsTheNumberThree
            => number => number.ToString().Contains("3");

        /// <summary>
        /// Predicate that takes an <see cref="int"/> and determines whether it contains the number five.
        /// </summary>
        private static Func<int, bool> ContainsTheNumberFive
            => number => number.ToString().Contains("5");

        /// <summary>
        /// Creates a new <see cref="IFizzBuzzGenerator"/> instance.
        /// </summary>
        /// <returns>A new <see cref="IFizzBuzzGenerator"/> instance</returns>
        private IFizzBuzzGenerator CreateSystemUnderTest(IFizzBuzzCalculationStrategy fizzBuzzCalculationStrategy = null)
            => new DefaultFizzBuzzGenerator(fizzBuzzCalculationStrategy ?? new Stage1FizzBuzzCalculationStrategy());
        #endregion
    }
}
