using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodefoxx.Katas.Anagrams.Shared;

namespace Kodefoxx.Katas.Anagrams.Strategies.MetadataAnagramSolverStrategy
{
    
    /// <inheritdocs />
    /// <summary>
    /// Makes a list of words and adds metadata to it to facilitate searching for anagrams and reporting back.
    /// Optimizations:
    ///  - Filters out the words that are only one letter long.
    /// </summary>    
    public sealed class MetadataAnagramSolver : AnagramSolver
    {
        public override Task<IEnumerable<Anagram>> ExecuteGetAnagramsAlgorithm(IEnumerable<string> words)
        {
            var wordsBiggerThanOneLetter = GetWordsBiggerThanOneLetter(words);
            var wordsWithMetaData = CreateWordsWithMetaData(wordsBiggerThanOneLetter);            
            var anagrams = GetAnagramsByWordsWithMetadata(wordsWithMetaData);

            return Task.FromResult(anagrams.AsEnumerable());
        }        

        private List<string> GetWordsBiggerThanOneLetter(IEnumerable<string> words)
            => words
                .Where(w => w.Length > 1)
                .ToList()
        ;

        private List<Word> CreateWordsWithMetaData(IEnumerable<string> words)
            => words
                .Select(word => new Word(word))
                .ToList()
        ;

        private List<Anagram> GetAnagramsByWordsWithMetadata(List<Word> wordsWithMetaData)
        {
            var anagramDictionary = new Dictionary<string, Anagram>();

            foreach (var word in wordsWithMetaData)
            {
                if (!anagramDictionary.ContainsKey(word.LettersSortKey))                
                    anagramDictionary.Add(word.LettersSortKey, new Anagram(word.Text));                
                else                
                    anagramDictionary[word.LettersSortKey].AddWord(word.Text);                             
            }

            return GetAnagramsContainingMoreThanOneWord(anagramDictionary);
        }                

        private List<Anagram> GetAnagramsContainingMoreThanOneWord(Dictionary<string, Anagram> anagramDictionary) 
            => anagramDictionary
                .Where(kvp => kvp.Value.Count > 1)
                .Select(kvp => kvp.Value)
                .ToList()
        ;
    }
}
