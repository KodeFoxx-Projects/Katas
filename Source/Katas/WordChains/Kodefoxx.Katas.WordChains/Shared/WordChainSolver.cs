using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Kodefoxx.Katas.WordChains.Shared.WordLists;

namespace Kodefoxx.Katas.WordChains.Shared
{    
    /// <inheritdoc />
    public abstract class WordChainSolver : IWordChainSolver
    {
        /// <summary>
        /// Gets the <see cref="IWordChain"/>s already found.
        /// </summary>
        private readonly ICollection<IWordChain> _wordChains;

        /// <summary>
        /// Creates a new <see cref="WordChainSolver"/>.
        /// </summary>
        protected WordChainSolver()
            => _wordChains = new List<IWordChain>();

        /// <inheritdoc />
        public IWordChainSolverResult GetWordChains(IWordList wordList, string startingWord, string endingWord)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = TryGetWordChains(wordList, startingWord, endingWord, _wordChains.ToList().AsReadOnly());

            while (result.CanContinue)
            {
                if (result.NewlyFoundWordChain != null)
                {
                    stopwatch.Stop();

                    _wordChains.Add(WordChain.New(result.NewlyFoundWordChain, stopwatch.Elapsed));

                    stopwatch.Start();
                    result = TryGetWordChains(wordList, startingWord, endingWord, _wordChains.ToList().AsReadOnly());
                }
                else                
                    stopwatch.Stop();                
            }

            return WordChainSolverResult.New(_wordChains);
        }

        /// <summary>
        /// Tries to get a word chain from the given wordlist.
        /// </summary>
        /// <param name="wordList">The list of words (or dictionary) to be used.</param>
        /// <param name="startingWord">The word that marks the start of the <see cref="IWordChain"/>.</param>
        /// <param name="endingWord">The word that marks the end of the <see cref="IWordChain"/>.</param>
        /// <param name="foundWordChains">The <see cref="IWordChain"/>s that were already found.</param>        
        protected abstract (bool CanContinue, IEnumerable<string> NewlyFoundWordChain) TryGetWordChains(IWordList wordList, string startingWord, string endingWord, 
            IReadOnlyCollection<IWordChain> foundWordChains);
    }
}
