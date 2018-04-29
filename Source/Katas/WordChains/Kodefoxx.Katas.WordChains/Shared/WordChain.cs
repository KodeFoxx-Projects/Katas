using System;
using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.WordChains.Shared
{
    /// <inheritdoc />
    public sealed class WordChain : IWordChain
    {
        /// <summary>
        /// Creates a new <see cref="WordChain"/> object.
        /// </summary>
        /// <param name="words">All the words inside the <see cref="IWordChain"/> in order
        /// and including both the <see cref="StartingWord"/> as the first element,
        /// and the <see cref="EndingWord"/> as the last element.</param>
        /// <param name="duration">The time it took to find the <see cref="IWordChain"/>.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="words"/> is null.</exception>
        /// /// <exception cref="ArgumentOutOfRangeException">When <paramref name="words"/> is smaller than two.</exception>
        public static IWordChain New(IEnumerable<string> words, TimeSpan duration)
            => new WordChain(words, duration);        

        /// <summary>
        /// Creates a new <see cref="WordChain"/> object.
        /// </summary>
        /// <param name="words">All the words inside the <see cref="IWordChain"/> in order
        /// and including both the <see cref="StartingWord"/> as the first element,
        /// and the <see cref="EndingWord"/> as the last element.</param>
        /// <param name="duration">The time it took to find the <see cref="IWordChain"/>.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="words"/> is null.</exception>
        /// /// <exception cref="ArgumentOutOfRangeException">When <paramref name="words"/> is smaller than two.</exception>
        private WordChain(IEnumerable<string> words, TimeSpan duration)
        {
            _words = words?.ToList()?.AsReadOnly();
            Duration = duration;

            if (_words == null)
                throw new ArgumentNullException(nameof(words));
            if (_words.Count < 2)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(words), 
                    message: $"The parameter '{nameof(words)}' should at least contain 2 words, in stead of the provided amount of '{_words.Count}' words."
                )
            ;
        }

        /// <summary>
        /// All the words inside the <see cref="IWordChain"/> in order
        /// and including both the <see cref="StartingWord"/> as the first element,
        /// and the <see cref="EndingWord"/> as the last element.
        /// </summary>
        private readonly IReadOnlyList<string> _words;

        /// <inheritdoc />
        public TimeSpan Duration { get; }

        /// <inheritdoc />
        public string StartingWord => _words.First();

        /// <inheritdoc />
        public string EndingWord => _words.Last();

        /// <inheritdoc />
        public IEnumerable<string> Words => _words;

        /// <inheritdoc />
        public int Length => _words.Count;
    }
}
