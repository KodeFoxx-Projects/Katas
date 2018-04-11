using Kodefoxx.Katas.FourInARow.Board;
using Kodefoxx.Katas.FourInARow.Players;

namespace Kodefoxx.Katas.FourInARow
{
    /// <summary>
    /// Represents an four in a row game.
    /// </summary>
    public interface IFourInARowGame
    {
        Player PlayerOne { get; }
        Player PlayerTwo { get; }
        IReadOnlyBoardGrid Board { get; }
    }
}
