using System;
using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.Anagrams.Shared
{
    /// <summary>
    /// A definition of an anagram.
    /// </summary>
    public sealed class Anagram
    {
        /// <summary>
        /// Constructs a new anagram.
        /// </summary>
        /// <param name="words">The words of the anagram.</param>
        public Anagram(IEnumerable<string> words)
            => _words = words?.ToList() ?? new List<string>();
        
        /// <summary>
        /// Constructs a new anagram based on a single word.
        /// </summary>
        /// <param name="word">The (first) word of the anagram.</param>
        public Anagram(string word) : this(new List<string> { word }) { }

        /// <summary>
        /// The words of the anagram.
        /// </summary>
        public IReadOnlyList<string> Words => _words;

        private readonly List<string> _words;

        /// <summary>
        /// Adds a word to the list if it doesn't exist already.
        /// </summary>
        /// <param name="word">The word to add.</param>
        public void AddWord(string word)
        {
            if(!_words.Contains(word))
                _words.Add(word);
        }

        /// <summary>
        /// The amount of words the anagram contains.
        /// </summary>
        public int Count => Words.Count;

        /// <summary>
        /// The string representiation of the anagram.
        /// </summary>        
        public override string ToString()
            => String.Join(", ", Words.OrderBy(w => w));
    }
}
