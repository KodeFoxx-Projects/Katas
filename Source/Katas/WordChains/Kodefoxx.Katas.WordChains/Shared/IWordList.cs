using System.Collections.Generic;

namespace Kodefoxx.Katas.WordChains.Shared
{
    /// <summary>
    /// Holds a list of words in lower-case, essentially a dictionary.
    /// </summary>
    public interface IWordList
    {
        /// <summary>
        /// Gets the words in lower-case.
        /// </summary>
        IEnumerable<string> Words { get; }
    }
}