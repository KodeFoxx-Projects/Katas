using System;
using Xunit;

namespace Kodefoxx.Katas.WordChains.Tests.TestHelpers.AssertExtensions
{
    // Holds methods that build on Assert.IsOfType and Assert.IsNotOfType
    public static partial class Xssert
    {
        /// <summary>
        /// Selects a type and marks it as the system under test.
        /// </summary>
        /// <typeparam name="TActual">The type that is under test.</typeparam>        
        public static TypeAssertion TheActualType<TActual>()
            => TheActualType(typeof(TActual));

        /// <summary>
        /// Selects a type and marks it as the system under test.
        /// </summary>
        /// <param name="actualType">The type that is under test.</param>        
        public static TypeAssertion TheActualType(Type actualType)
            => new TypeAssertion(actualType);

        /// <summary>
        /// Selects a type and marks it as the system under test.
        /// </summary>
        /// <param name="actualTypeSelector">The lambda / function that is responsible for generating an object whom's <see cref="Type"/> will be selected.</param>        
        public static TypeAssertion TheActualType(Func<object> actualTypeSelector)
            => new TypeAssertion(actualTypeSelector()?.GetType() ?? typeof(object));        

        /// <summary>
        /// Holds chainable methods that build on <see cref="Assert"/>.IsOfType and <see cref="Assert"/>.IsNotOfType.
        /// </summary>
        public sealed class TypeAssertion
        {
            /// <summary>
            /// Holds the actual type to be.
            /// </summary>
            private readonly Type _actualType;

            /// <summary>
            /// Creates a new <see cref="TypeAssertion"/> object.
            /// </summary>
            /// <param name="actualType"></param>
            internal TypeAssertion(Type actualType)
                => _actualType = actualType;

            /// <summary>
            /// Verifies that the actual type is exactly as the <typeparamref name="TExpected"/> type (and not a derived type).
            /// </summary>
            /// <typeparam name="TExpected">The expected <see cref="Type"/>.</typeparam>
            public void IsExactlyOfExpectedType<TExpected>()
                => IsExactlyOfTheExpectedType(typeof(TExpected));

            /// <summary>
            /// Verifies that the actual type is exactly as the <paramref name="expectedType"/> type (and not a derived type).
            /// </summary>
            /// <param name="expectedType">The expected <see cref="Type"/>.</param>
            public void IsExactlyOfTheExpectedType(Type expectedType)
                => Assert.IsType(expectedType, _actualType);

            /// <summary>
            /// Verifies that the actual type is not exactly as the <typeparamref name="TExpected"/> type.
            /// </summary>
            /// <typeparam name="TExpected">The expected <see cref="Type"/>.</typeparam>
            public void IsNotExactlyOfExpectedType<TExpected>()
                => IsNotExactlyOfTheExpectedType(typeof(TExpected));

            /// <summary>
            /// Verifies that the actual type is not exactly as the <paramref name="expectedType"/> type.
            /// </summary>
            /// <param name="expectedType">The expected <see cref="Type"/>.</param>
            public void IsNotExactlyOfTheExpectedType(Type expectedType)
                => Assert.IsNotType(expectedType, _actualType);

            /// <summary>
            /// Verifies that the actual type is derived (and therefore assignable) to the <typeparamref name="TExpected"/> type.
            /// </summary>
            /// <typeparam name="TExpected">The expected <see cref="Type"/>.</typeparam>
            public void IsDerivedFromTheExpectedType<TExpected>()
                => IsDerivedFromTheType(typeof(TExpected));

            /// <summary>
            /// Verifies that the actual type is derived (and therefore assignable) to the <paramref name="expectedType"/> type.
            /// </summary>
            /// <param name="expectedType">The expected <see cref="Type"/>.</param>
            public void IsDerivedFromTheType(Type expectedType)
                => Assert.True(expectedType.IsAssignableFrom(_actualType));

            /// <summary>
            /// Verifies that the actual type is not derived (and therefore not assignable) to the <typeparamref name="TExpected"/> type.
            /// </summary>
            /// <typeparam name="TExpected">The expected <see cref="Type"/>.</typeparam>
            public void IsNotDerivedFromTheExpectedType<TExpected>()
                => IsNotDerivedFromTheType(typeof(TExpected));

            /// <summary>
            /// Verifies that the actual type is not derived (and therefore not assignable) to the <paramref name="expectedType"/> type.
            /// </summary>
            /// <param name="expectedType">The expected <see cref="Type"/>.</param>
            public void IsNotDerivedFromTheType(Type expectedType)
                => Assert.False(expectedType.IsAssignableFrom(_actualType));
        }
    }
}
