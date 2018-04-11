namespace Kodefoxx.Katas.FourInARow.Board.Winning
{
    /// <summary>
    /// Represents the win state of the game.
    /// </summary>
    public sealed class WinState
    {
        /// <summary>
        /// Creates a new <see cref="WinState"/>.
        /// </summary>
        /// <param name="method">The method to win on.</param>
        /// <param name="winner">The winner.</param>
        internal WinState(WinMethod method, BoardSlotValue? winner = null)
        {
            Method = method;
            Winner = winner;
        }

        /// <summary>
        /// Determines the method how the winner has one.
        /// </summary>
        public WinMethod Method { get; }

        /// <summary>
        /// Determines the winner of the game.
        /// </summary>
        public BoardSlotValue? Winner { get; }

        /// <summary>
        /// Determines whether the game has a winner.
        /// </summary>
        public bool HasWinner 
            => Winner.HasValue;

        /// <summary>
        /// Determines whether the game is finished.
        /// </summary>
        public bool IsGameFinished
            => Method != WinMethod.None;
    }
}
