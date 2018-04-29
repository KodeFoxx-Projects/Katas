using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.WordChains.Shared.WordsSanitizers
{
    /// <summary>
    /// A <see cref="IWordsSanitizer"/> that trims and lower-cases each inputted word.
    /// </summary>
    public sealed class TrimmedAndLowerCaseWordsSanitizer : IWordsSanitizer
    {
        /// <summary>
        /// Trims and lower-cases each inputted word.
        /// </summary>
        /// <param name="words">The <see cref="words"/> to trim and lower-case.</param>        
        public IEnumerable<string> SanitizeWords(IEnumerable<string> words)
            => words.Select(word => word.Trim().ToLower());
    }
}
