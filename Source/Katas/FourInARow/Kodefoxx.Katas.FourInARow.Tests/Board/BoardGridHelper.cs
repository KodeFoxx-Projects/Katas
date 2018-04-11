using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Tests.Board
{
    public static class BoardGridHelper
    {
        public static IBoardGrid CreateFourByFourBoard()
            => new BoardGrid(new[,]
            {
                {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.PlayerOne, BoardSlotValue.Empty},
                {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.PlayerOne, BoardSlotValue.Empty},
                {BoardSlotValue.Empty, BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerTwo, BoardSlotValue.Empty},
                {BoardSlotValue.Empty, BoardSlotValue.PlayerOne, BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerTwo}
            })
        ;
    }
}
