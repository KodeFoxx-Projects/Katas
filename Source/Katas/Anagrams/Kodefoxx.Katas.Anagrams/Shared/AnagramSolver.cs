using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kodefoxx.Katas.Anagrams.Shared
{
    /// <summary>
    /// Abstract base class for an anagram solver.
    /// </summary>
    public abstract class AnagramSolver : IAnagramSolver
    {        
        /// <inheritdocs/>
        public async Task<AnagramSolverResult> GetAnagrams(IEnumerable<string> words)
        {
            var sanitizedWords = SanitizeWordList(words);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var anagrams = await ExecuteGetAnagramsAlgorithm(sanitizedWords);

            stopWatch.Stop();

            return new AnagramSolverResult(anagrams, stopWatch.Elapsed);
        }

        /// <summary>
        /// Executes the actual algorithm of finding anagrams out of a word list.
        /// </summary>
        /// <param name="words">The enumerable of words to search through.</param>
        /// <returns>A list of anagrams.</returns>
        public abstract Task<IEnumerable<Anagram>> ExecuteGetAnagramsAlgorithm(IEnumerable<string> words);

        private List<string> SanitizeWordList(IEnumerable<string> words)
            => (words ?? new List<string>())
                .Where(word => !String.IsNullOrWhiteSpace(word))
                .Select(word => word.Trim().ToLowerInvariant())
                .ToList();
    }
}
