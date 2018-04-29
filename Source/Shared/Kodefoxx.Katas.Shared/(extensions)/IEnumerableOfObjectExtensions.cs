using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.Shared
{
    /// <summary>
    /// Extension methods for use on <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class IEnumerableOfObjectExtensions
    {
        /// <summary>
        /// Converts an enumerable to an enumerable of array of objects.
        /// </summary>
        /// <typeparam name="TObject">The type of object to wrap in an object[].</typeparam>
        /// <param name="enumarable">The enumerable to convert.</param>        
        public static IEnumerable<object[]> ToEnumerableOfArrayOfObject<TObject>(this IEnumerable<TObject> enumarable)
            => enumarable?.Select(@object => new object[] {@object}) ?? new List<object[]>();
    }
}
