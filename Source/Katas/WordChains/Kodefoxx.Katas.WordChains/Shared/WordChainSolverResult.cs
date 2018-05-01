using System;
using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.WordChains.Shared
{    
    /// <inheritdoc />
    public sealed class WordChainSolverResult : IWordChainSolverResult
    {
        /// <summary>
        /// Creates a new <see cref="WordChainSolverResult"/> object.
        /// </summary>
        /// <param name="wordChains">The collection of <see cref="IWordChain"/>s.</param>                
        public static IWordChainSolverResult New(IEnumerable<IWordChain> wordChains)
            => new WordChainSolverResult(wordChains);

        /// <summary>
        /// Creates a new <see cref="WordChainSolverResult"/>.
        /// </summary>
        /// <param name="wordChains">The collection of <see cref="IWordChain"/>s.</param>        
        private WordChainSolverResult(IEnumerable<IWordChain> wordChains)
        {
            _wordChains = WordChainCollectionOrEmptyIfNull(wordChains);
            Duration = CalculateDuration(_wordChains.Select(wordChain => wordChain.Duration));
        }

        /// <summary>
        /// Calculates the total duration of the all the <param name="wordChains"/> combined.
        /// </summary>
        /// <param name="wordChainDurations">The <see cref="TimeSpan"/>s used to store the duration of each <see cref="IWordChain"/>.</param>        
        private TimeSpan CalculateDuration(IEnumerable<TimeSpan> wordChainDurations)
            => wordChainDurations
                .Aggregate(
                    seed: TimeSpan.Zero,
                    func: (aggregate, nextTimeSpan) => aggregate.Add(nextTimeSpan)
                )
        ;

        private IReadOnlyList<IWordChain> WordChainCollectionOrEmptyIfNull(IEnumerable<IWordChain> wordChain)
            => (wordChain?.ToList() ?? new List<IWordChain>()).AsReadOnly();

        /// <summary>
        /// All the <see cref="IWordChain"/>s found.
        /// </summary> 
        private readonly IReadOnlyList<IWordChain> _wordChains;

        /// <inheritdoc />
        public TimeSpan Duration { get; }

        /// <inheritdoc />
        public IReadOnlyCollection<IWordChain> WordChains => _wordChains;

        /// <inheritdoc />
        public int AmountOfWordChains => _wordChains.Count;

        /// <inheritdoc />
        public bool ContainsAtLeastOneWordChain => _wordChains.Any();
    }
}
