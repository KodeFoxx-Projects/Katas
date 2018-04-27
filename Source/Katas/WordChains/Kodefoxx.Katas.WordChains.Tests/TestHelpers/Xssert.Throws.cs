using System;
using Xunit;

namespace Kodefoxx.Katas.WordChains.Tests.TestHelpers
{
    // Holds methods that build on Assert.Throws.
    public static partial class Xssert
    {
        /// <summary>
        /// Verifies that the exact <see cref="Exception"/> is thrown (and not a derived <see cref="Exception"/> type),
        /// and if the first test succeeded <see cref="assertException"/> is called with the thrown <typeparamref name="TException"/>
        /// to undergo further assertions.
        /// </summary>
        /// <typeparam name="TException">The type of <see cref="Exception"/>.</typeparam>
        /// <param name="testCode">A delegate to the code to be tested.</param>
        /// <param name="assertException">A delegate to further assert the resulting <typeparamref name="TException"/>.</param>
        public static void Throws<TException>(Action testCode, Action<TException> assertException)
            where TException : Exception
        => assertException(Assert.Throws<TException>(testCode: testCode));

        /// <summary>
        /// Verifies that an <see cref="ArgumentNullException"/> is thrown (and not a derived <see cref="ArgumentNullException"/> type),
        /// and tests whether the <paramref name="expectedParameterName"/> is equal to the value
        /// of the <see cref="ArgumentNullException"/>'s ParamName property.
        /// </summary>
        /// <param name="testCode">A delegate to the code to be tested.</param>
        /// <param name="expectedParameterName">The expected value of the <see cref="ArgumentNullException"/>'s ParamName property.</param>
        public static void ThrowsArgumentNullException(Action testCode, string expectedParameterName)
            => ThrowsArgumentNullException<ArgumentNullException>(
                testCode: testCode,
                expectedParameterName: expectedParameterName
            )
        ;

        /// <summary>
        /// Verifies that an <typeparamref name="TArgumentNullException"/> is thrown (and not a derived <typeparamref name="TArgumentNullException"/> type),
        /// and tests whether the <paramref name="expectedParameterName"/> is equal to the value
        /// of the <typeparamref name="TArgumentNullException"/>'s ParamName property.
        /// </summary>
        /// <typeparam name="TArgumentNullException">The type of <see cref="ArgumentNullException"/>.</typeparam>
        /// <param name="testCode">A delegate to the code to be tested.</param>
        /// <param name="expectedParameterName">The expected value of the <see cref="ArgumentNullException"/>'s ParamName property.</param>
        public static void ThrowsArgumentNullException<TArgumentNullException>(
            Action testCode, string expectedParameterName)
            where TArgumentNullException : ArgumentNullException
            => Throws<TArgumentNullException>(
                testCode: testCode,
                assertException: exception => Assert.Equal(expectedParameterName, exception.ParamName)
            )
        ;

        /// <summary>
        /// Verifies that an <see cref="ArgumentOutOfRangeException"/> is thrown (and not a derived <see cref="ArgumentOutOfRangeException"/> type),
        /// <para>Optionally tests whether the <paramref name="expectedParameterName"/> is equal to the value of the <see cref="ArgumentOutOfRangeException"/>'s ParamName property;
        /// as well as optionally tests whether the <paramref name="expectedMessageContains"/> is contained as sub-string in the <see cref="ArgumentOutOfRangeException"/>'s Message property.</para>
        /// </summary>
        /// <param name="testCode">A delegate to the code to be tested.</param>
        /// <param name="expectedParameterName">The expected value of the <typeparamref name="TArgumentOutOfRangeException"/>'s ParamName property.</param>
        /// <param name="expectedMessageContains">The expected sub-string of the <typeparamref name="TArgumentOutOfRangeException"/>'s Message property.</param>
        public static void ThrowsArgumentOutOfRangeException(Action testCode, 
            string expectedParameterName = null, string expectedMessageContains = null)
            => ThrowsArgumentOutOfRangeException<ArgumentOutOfRangeException>(
                testCode: testCode,
                expectedParameterName: expectedParameterName,
                expectedMessageContains: expectedMessageContains
            )
        ;

        /// <summary>
        /// Verifies that an <typeparamref name="TArgumentOutOfRangeException"/> is thrown (and not a derived <typeparamref name="TArgumentOutOfRangeException"/> type),
        /// <para>Optionally tests whether the <paramref name="expectedParameterName"/> is equal to the value of the <typeparamref name="TArgumentOutOfRangeException"/>'s ParamName property;
        /// as well as optionally tests whether the <paramref name="expectedMessageContains"/> is contained as sub-string in the <typeparamref name="TArgumentOutOfRangeException"/>'s Message property.</para>
        /// </summary>
        /// <typeparam name="TArgumentOutOfRangeException">The type of <see cref="ArgumentOutOfRangeException"/>.</typeparam>
        /// <param name="testCode">A delegate to the code to be tested.</param>
        /// <param name="expectedParameterName">The expected value of the <typeparamref name="TArgumentOutOfRangeException"/>'s ParamName property.</param>
        /// <param name="expectedMessageContains">The expected sub-string of the <typeparamref name="TArgumentOutOfRangeException"/>'s Message property.</param>
        public static void ThrowsArgumentOutOfRangeException<TArgumentOutOfRangeException>(
            Action testCode, string expectedParameterName = null, string expectedMessageContains = null)
            where TArgumentOutOfRangeException : ArgumentOutOfRangeException
            => Throws<TArgumentOutOfRangeException>(
                testCode: testCode,
                assertException: exception =>
                {
                    if(expectedParameterName != null)
                        Assert.Equal(expectedParameterName, exception.ParamName);
                    if(expectedMessageContains != null)
                        Assert.Contains(expectedMessageContains, exception.Message);
                }
            )
        ;
    }
}
