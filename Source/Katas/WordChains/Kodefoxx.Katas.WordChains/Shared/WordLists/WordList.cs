using System;
using System.Collections.Generic;
using Kodefoxx.Katas.WordChains.Shared.WordsSanitizers;

namespace Kodefoxx.Katas.WordChains.Shared.WordLists
{
    /// <inheritdoc />
    public class WordList : IWordList
    {
        /// <summary>
        /// Creates a new <see cref="WordList"/> object.
        /// </summary>
        /// <param name="words">The words in the list.</param>
        /// <param name="wordsSanitizer">The <see cref="IWordsSanitizer"/> to use on the collection of <paramref name="words"/>.</param>
        public WordList(IEnumerable<string> words, IWordsSanitizer wordsSanitizer)
            : this(words, wordsSanitizer.SanitizeWords) { }

        /// <summary>
        /// Creates a new <see cref="WordList"/> object.
        /// </summary>
        /// <param name="words">The words in the list.</param>
        /// <param name="wordsSanitizerFunction">An optional function to use on the collection of <paramref name="words"/> to preprocess (sanitize) them.</param>
        public WordList(IEnumerable<string> words, Func<IEnumerable<string>, IEnumerable<string>> wordsSanitizerFunction = null)
            => Words = wordsSanitizerFunction?.Invoke(words) ?? words;

        /// <inheritdoc />
        public IEnumerable<string> Words { get; }
    }
}