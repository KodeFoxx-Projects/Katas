using System.Collections.Generic;

namespace Kodefoxx.Katas.WordChains.Shared.WordsSanitizers
{
    /// <summary>
    /// Interface for a module/strategy that will take a collection of strings and sanitize them.
    /// </summary>
    public interface IWordsSanitizer
    {
        /// <summary>
        /// Sanitizes the the words.
        /// </summary>
        /// <param name="words">The collection of words to sanitize.</param>
        /// <returns>The <paramref name="words"/>, but sanitized.</returns>
        IEnumerable<string> SanitizeWords(IEnumerable<string> words);
    }
}
