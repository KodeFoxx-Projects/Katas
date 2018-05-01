using System;
using System.Collections.Generic;

namespace Kodefoxx.Katas.WordChains.Shared
{
    /// <summary>
    /// Holds the result procuded by the <see cref="IWordChainSolver"/>.
    /// </summary>
    public interface IWordChainSolverResult
    {
        /// <summary>
        /// The time it took to calculate the <see cref="IWordChainSolverResult"/>.
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// Gets the <see cref="IWordChain"/>s that were found.
        /// </summary>
        IReadOnlyCollection<IWordChain> WordChains { get; }

        /// <summary>
        /// Gets the amount of <see cref="IWordChain"/>s found.
        /// </summary>
        int AmountOfWordChains { get; }

        /// <summary>
        /// Determines whether at the <see cref="IWordChainSolverResult"/> contains at least one <see cref="IWordChain"/>.
        /// </summary>
        bool ContainsAtLeastOneWordChain { get; }
    }    
}