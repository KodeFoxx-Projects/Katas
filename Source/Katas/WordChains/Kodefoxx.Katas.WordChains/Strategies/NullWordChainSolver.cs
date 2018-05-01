using System.Collections.Generic;
using Kodefoxx.Katas.WordChains.Shared;
using Kodefoxx.Katas.WordChains.Shared.WordLists;

namespace Kodefoxx.Katas.WordChains.Strategies
{    
    /// <inheritdoc />
    public sealed class NullWordChainSolver : WordChainSolver
    {
        /// <inheritdoc />
        protected override (bool CanContinue, IEnumerable<string> NewlyFoundWordChain) TryGetWordChains(
            IWordList wordList, string startingWord, string endingWord,
            IReadOnlyCollection<IWordChain> foundWordChains
        ) => (CanContinue: false, NewlyFoundWordChain: null);
    }
}
