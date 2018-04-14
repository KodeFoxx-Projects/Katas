using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.FourInARow.Board;
using Kodefoxx.Katas.FourInARow.Winning;

namespace Kodefoxx.Katas.FourInARow.Tests.Board
{
    public static class BoardGridHelper
    {
        public static IBoardGrid CreateFourByFourBoard()
            => ConvertIntegerArrayToBoard(new[,]
            {
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 2, 2, 0},
                {0, 1, 2, 2}
            });

        public static IBoardGrid CreateFullBoard()
            => ConvertIntegerArrayToBoard(new[,]
            {
                {1, 2, 1, 2},
                {2, 2, 1, 2},
                {1, 2, 2, 1},
                {1, 1, 2, 2}
            });        

        public static (BoardSlotValue Winner, IEnumerable<(WinMethod WinMethod, IBoardGrid Board)> Boards)
            CreateWinningBoardGridForPlayerOne() => (
            Winner: BoardSlotValue.P1,
            Boards: new List<(WinMethod WinMethod, IBoardGrid Board)> {
                (
                    WinMethod: WinMethod.None,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {0, 0, 0, 0},
                        {0, 0, 0, 0},
                        {0, 0, 0, 0},
                        {0, 0, 0, 0}
                    })
                ),
                (
                    WinMethod: WinMethod.None,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {0, 0, 1, 0},
                        {0, 0, 1, 0},
                        {0, 2, 2, 0},
                        {0, 1, 2, 2}
                    })
                ),
                (
                    WinMethod: WinMethod.Row,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {0, 0, 0, 0},
                        {0, 0, 0, 0},
                        {0, 0, 0, 0},
                        {1, 1, 1, 1}
                    })
                ),
                (
                    WinMethod: WinMethod.Column,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {0, 1, 0, 0},
                        {0, 1, 0, 0},
                        {0, 1, 0, 0},
                        {0, 1, 0, 0}
                    })
                ),
                (
                    WinMethod: WinMethod.DiagonalTopToBottom,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {1, 0, 0, 0},
                        {0, 1, 0, 0},
                        {0, 0, 1, 0},
                        {0, 0, 0, 1}
                    })
                ),
                (
                    WinMethod: WinMethod.DiagonalBottomToTop,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {0, 0, 0, 1},
                        {0, 0, 1, 0},
                        {0, 1, 0, 0},
                        {1, 0, 0, 0}
                    })
                ),
                (
                    WinMethod: WinMethod.Draw,
                    Board: ConvertIntegerArrayToBoard(new[,]
                    {
                        {1, 2, 2, 2},
                        {1, 2, 1, 1},
                        {2, 1, 1, 1},
                        {1, 2, 1, 1}
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

        /// <summary>
        /// Converts a 2d <see cref="int"/> <paramref name="integerArray"/> to a 2d <see cref="BoardSlotValue"/> array and makes a <see cref="IBoardGrid"/> out of it.
        /// </summary>
        /// <param name="integerArray">The 2d array of <see cref="int"/>s</param>        
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
    }
}
