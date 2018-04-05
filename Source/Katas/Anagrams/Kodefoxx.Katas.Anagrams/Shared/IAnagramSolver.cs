using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kodefoxx.Katas.Anagrams.Shared
{
    /// <summary>
    /// Contract for an anagram solver.
    /// </summary>
    public interface IAnagramSolver
    {
        /// <summary>
        /// Takes an enumerable of words an finds the anagrams within.
        /// </summary>
        /// <param name="words">The set of words to find anagrams in.</param>
        /// <returns>An <see cref="AnagramSolverResult"/> containg the result of the solver algorithm.</returns>
        Task<AnagramSolverResult> GetAnagrams(IEnumerable<string> words);
    }
}
