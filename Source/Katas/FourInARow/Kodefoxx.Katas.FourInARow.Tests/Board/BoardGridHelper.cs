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

        public static IBoardGrid CreateFullBoard()
            => new BoardGrid(new[,]
            {
                {BoardSlotValue.PlayerOne, BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerOne, BoardSlotValue.PlayerTwo},
                {BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerOne, BoardSlotValue.PlayerTwo},
                {BoardSlotValue.PlayerOne, BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerOne},
                {BoardSlotValue.PlayerOne, BoardSlotValue.PlayerOne, BoardSlotValue.PlayerTwo, BoardSlotValue.PlayerTwo}
            })
        ;
    }
}
