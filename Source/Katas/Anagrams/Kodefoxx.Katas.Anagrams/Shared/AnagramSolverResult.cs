using System;
using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.Anagrams.Shared
{
    /// <summary>
    /// Defines the result of the anagram solver.
    /// </summary>
    public sealed class AnagramSolverResult
    {
        /// <summary>
        /// Creates a new <see cref="AnagramSolverResult"/> instance.
        /// </summary>
        /// <param name="anagrams">The list of anagrams found.</param>
        /// <param name="duration">The time it took to find the anagrams.</param>
        public AnagramSolverResult(IEnumerable<Anagram> anagrams, TimeSpan duration)
        {
            Anagrams = anagrams?.ToList() ?? new List<Anagram>();
            Duration = duration;
        }

        /// <summary>
        /// The list of anagrams found.
        /// </summary>
        public List<Anagram> Anagrams { get; }

        /// <summary>
        /// The amount of anagrams found.
        /// </summary>
        public int Count => Anagrams.Count;

        /// <summary>
        /// The time it took to find the anagrams.
        /// </summary>
        public TimeSpan Duration { get; }
    }
}
