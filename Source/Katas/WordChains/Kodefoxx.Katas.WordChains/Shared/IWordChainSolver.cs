namespace Kodefoxx.Katas.WordChains.Shared
{
    /// <summary>
    /// Responsible for solving a word chain.
    /// </summary>
    public interface IWordChainSolver
    {
        /// <summary>
        /// Gets the word chains.
        /// </summary>
        /// <param name="wordList">The list of words (or dictionary) to be used.</param>
        /// <param name="startingWord">The word that marks the start of the <see cref="IWordChain"/>.</param>
        /// <param name="endingWord">The word that marks the end of the <see cref="IWordChain"/>.</param>
        /// <returns></returns>
        IWordChainSolverResult GetWordChains(IWordList wordList, string startingWord, string endingWord);
    }
}
