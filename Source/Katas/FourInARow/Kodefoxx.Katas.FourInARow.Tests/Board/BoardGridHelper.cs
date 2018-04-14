using System.Collections.Generic;
using System.Linq;
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

        public static IBoardGrid ConvertIntegerArrayToBoard(int[,] integerArray)
        {
            var boardGridSlotValues = new BoardSlotValue[integerArray.GetLength(0), integerArray.GetLength(1)];

            foreach (var i in Enumerable.Range(0, integerArray.GetLength(0)))
            {
                foreach (var j in Enumerable.Range(0, integerArray.GetLength(1)))
                {
                    switch (integerArray[i, j])
                    {
                        case 1:
                            boardGridSlotValues[i, j] = BoardSlotValue.P1;
                            break;
                        case 2:
                            boardGridSlotValues[i, j] = BoardSlotValue.P2;
                            break;
                        default:
                            boardGridSlotValues[i, j] = BoardSlotValue.Empty;
                            break;
                    }
                }
            }

            var boardGrid = new BoardGrid(boardGridSlotValues);
            return boardGrid;
        }

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
                (
                    WinMethod: WinMethod.Draw,
                    Board: new BoardGrid(new[,]
                    {
                        {BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P2, BoardSlotValue.P2},
                        {BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P1, BoardSlotValue.P1},
                        {BoardSlotValue.P2, BoardSlotValue.P1, BoardSlotValue.P1, BoardSlotValue.P1},
                        {BoardSlotValue.P1, BoardSlotValue.P2, BoardSlotValue.P1, BoardSlotValue.P1}
                    })
                ),
                (
                    WinMethod: WinMethod.DiagonalBottomToTop,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 1, 0, 0},
                        {0, 0, 0, 1, 1, 0, 0},
                        {0, 0, 1, 1, 2, 0, 0},
                        {0, 1, 2, 2, 2, 0, 0},
                        {0, 2, 2, 1, 2, 0, 0}
                    })
                ),
                (
                    WinMethod: WinMethod.DiagonalBottomToTop,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 1, 1, 0},
                        {0, 0, 0, 1, 1, 2, 0},
                        {0, 0, 1, 1, 2, 1, 0},
                        {0, 2, 1, 2, 2, 2, 0},
                        {0, 2, 2, 1, 2, 2, 0}
                    })
                ),
            }
        );
    }
}
