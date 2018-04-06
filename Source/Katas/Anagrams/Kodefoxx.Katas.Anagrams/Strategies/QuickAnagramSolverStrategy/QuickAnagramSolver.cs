using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodefoxx.Katas.Anagrams.Shared;

namespace Kodefoxx.Katas.Anagrams.Strategies.QuickAnagramSolverStrategy
{
    /// <inheritdocs />
    /// <summary>
    /// Quicker implementation which holds the basics of the metadata, but without extra object instantiation.
    /// Optimizations:
    ///  - Filters out the words that are only one letter long.
    /// </summary>   
    public sealed class QuickAnagramSolver : AnagramSolver
    {
        public override Task<IEnumerable<Anagram>> ExecuteGetAnagramsAlgorithm(IEnumerable<string> words)
        {
            var wordsLongerThanOneLetter = words.Where(word => word.Length > 1).ToList();

            var anagramsDictionary = new Dictionary<string, List<string>>();
            foreach (var word in wordsLongerThanOneLetter)
            {
                var key = CreateAnagramKey(word);
                if(!anagramsDictionary.ContainsKey(key))
                    anagramsDictionary.Add(key, new List<string>() { word });
                else
                    anagramsDictionary[key].Add(word);
            }

            return Task.FromResult(CreateListOfAnagrams(anagramsDictionary).AsEnumerable());
        }

        private List<Anagram> CreateListOfAnagrams(Dictionary<string, List<string>> anagramsDictionary)
            => anagramsDictionary.Values.Where(list => list.Distinct().Count() > 1)
                .Select(list => new Anagram(list))
                .ToList()
        ;

        private string CreateAnagramKey(string word)
            => String.Join("", word.ToCharArray().OrderBy(c => c).ToList())
        ;
    }
}
