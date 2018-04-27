using System;
using System.Collections.Generic;

namespace Kodefoxx.Katas.WordChains.Shared
{
    /// <summary>
    /// Defines a chain of words.
    /// </summary>
    public interface IWordChain
    {
        /// <summary>
        /// The time it took to find the <see cref="IWordChain"/>.
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// Gets the word that marks the start of the <see cref="IWordChain"/>,
        /// and thus is the first <see cref="string"/> element to be encountered in the <see cref="Words"/> enrumerable.
        /// </summary>
        string StartingWord { get; }

        /// <summary>
        /// Gets the word that marks the end of the <see cref="IWordChain"/>,
        /// and thus is the last <see cref="string"/> element to be encountered in the <see cref="Words"/> enrumerable.
        /// </summary>
        string EndingWord { get; }

        /// <summary>
        /// Gets all the words inside the <see cref="IWordChain"/> in order
        /// and including both the <see cref="StartingWord"/> as the first element,
        /// and the <see cref="EndingWord"/> as the last element.
        /// </summary>
        IEnumerable<string> Words { get; }

        /// <summary>
        /// Gets the full length of the <see cref="IWordChain"/>,
        /// essentially the total number of words including the <see cref="StartingWord"/> and the <see cref="EndingWord"/>.
        /// </summary>
        int Length { get; }
    }
}
