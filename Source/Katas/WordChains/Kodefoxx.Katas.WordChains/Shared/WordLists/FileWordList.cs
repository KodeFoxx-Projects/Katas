using System;
using System.Collections.Generic;
using System.IO;
using Kodefoxx.Katas.WordChains.Shared.WordsSanitizers;

namespace Kodefoxx.Katas.WordChains.Shared.WordLists
{
    /// <inheritdoc />
    public class FileWordList : WordList
    {
        /// <summary>
        /// Creates a new <see cref="FileWordList"/>.
        /// </summary>
        /// <param name="wordFile">The <see cref="FileInfo"/> object to load the words from.</param>
        /// <param name="wordsSanitizer">The <see cref="IWordsSanitizer"/> to use on the words loaded from the <paramref name="wordFile"/>.</param>
        public FileWordList(FileInfo wordFile, IWordsSanitizer wordsSanitizer) 
            : this(wordFile, wordsSanitizer.SanitizeWords) { }

        /// <summary>
        /// Creates a new <see cref="FileWordList"/>.
        /// </summary>
        /// <param name="wordFile">The <see cref="FileInfo"/> object to load the words from.</param>
        /// <param name="wordsSanitizerFunction">An optional function to use on the words loaded from the <paramref name="wordFile"/> to preprocess (sanitize) them.</param>
        public FileWordList(FileInfo wordFile, Func<IEnumerable<string>, IEnumerable<string>> wordsSanitizerFunction = null)
            : base(File.ReadAllLines(wordFile.FullName), wordsSanitizerFunction) { }        
    }
}