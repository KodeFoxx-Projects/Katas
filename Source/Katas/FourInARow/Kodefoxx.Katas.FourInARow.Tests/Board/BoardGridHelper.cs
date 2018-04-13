using System.Collections.Generic;
using Kodefoxx.Katas.FourInARow.Board;
using Kodefoxx.Katas.FourInARow.Winning;

namespace Kodefoxx.Katas.FourInARow.Tests.Board
{
    public static class BoardGridHelper
    {
        public static IBoardGrid CreateFourByFourBoard()
            => new BoardGrid(new[,]
            {
                {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty},
                {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty},
                {BoardSlotValue.Empty, BoardSlotValue.P2, BoardSlotValue.P2, BoardSlotValue.Empty},
                {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P2}
            });

        public static IBoardGrid CreateFullBoard()
            => new BoardGrid(new[,]
            {
                {BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P1, BoardSlotValue.P2},
                {BoardSlotValue.P2, BoardSlotValue.P2, BoardSlotValue.P1, BoardSlotValue.P2},
                {BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P2, BoardSlotValue.P1},
                {BoardSlotValue.P1, BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P2}
            });

        public static (BoardSlotValue Winner, IEnumerable<(WinMethod WinMethod, IBoardGrid Board)> Boards)
            CreateWinningBoardGridForPlayerOne() => (
            Winner: BoardSlotValue.P1,
            Boards: new List<(WinMethod WinMethod, IBoardGrid Board)> {
                (
                    WinMethod: WinMethod.None,
                    Board: new BoardGrid(new[,]
                    {
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty}
                    })
                ),
                (
                    WinMethod: WinMethod.None,
                    Board: new BoardGrid(new[,]
                    {
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.P2, BoardSlotValue.P2, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P2}
                    })
                ),
                (
                    WinMethod: WinMethod.Row,
                    Board: new BoardGrid(new[,]
                    {
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.P1, BoardSlotValue.P1, BoardSlotValue.P1, BoardSlotValue.P1}
                    })
                ),
                (
                    WinMethod: WinMethod.Column,
                    Board: new BoardGrid(new[,]
                    {
                        {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty}
                    })
                ),
                (
                    WinMethod: WinMethod.DiagonalTopToBottom,
                    Board: new BoardGrid(new[,]
                    {
                        {BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1}
                    })
                ),
                (
                    WinMethod: WinMethod.DiagonalBottomToTop,
                    Board: new BoardGrid(new[,]
                    {
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1},
                        {BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty},
                        {BoardSlotValue.Empty, BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty},
                        {BoardSlotValue.P1, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty}
                    })
                ),
            }
        );        
}
}
