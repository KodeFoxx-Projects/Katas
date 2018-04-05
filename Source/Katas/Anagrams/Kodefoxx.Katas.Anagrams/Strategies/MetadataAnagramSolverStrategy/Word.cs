using System;
using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.Anagrams.Strategies.MetadataAnagramSolverStrategy
{
    /// <summary>
    /// Defines a word.
    /// </summary>
    public sealed class Word
    {
        /// <summary>
        /// Creates a new word.
        /// </summary>
        /// <param name="word">The word to create metadata for.</param>        
        public Word(string word) => Text = word;

        /// <summary>
        /// The textual representation of the word.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The length of the word.
        /// </summary>
        public int Length => Text.Length;

        /// <summary>
        /// The letters of the word.
        /// </summary>
        public List<char> Letters => Text.ToCharArray().ToList();

        /// <summary>
        /// The unique letters of the word.
        /// </summary>
        public List<char> UniqueLetters => Letters.Distinct().ToList();

        /// <summary>
        /// The unique letters sortable key.
        /// </summary>
        public string UniqueLettersSortKey => String.Join("", UniqueLetters.OrderBy(c => c));
    }
}
