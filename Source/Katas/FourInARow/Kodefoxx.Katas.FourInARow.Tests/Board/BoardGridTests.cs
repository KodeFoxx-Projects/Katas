using System.Collections.Generic;
using Kodefoxx.Katas.FourInARow.Board;
using Xunit;

namespace Kodefoxx.Katas.FourInARow.Tests.Board
{
    public sealed class BoardGridTests
    {
        [Theory, MemberData(nameof(Constructor_generates_new_board_based_on_given_BoardSize_TestData))]
        public void Constructor_generates_new_board_based_on_given_BoardSize(
            BoardSize expectedSize)
        {
            var sut = new BoardGrid(expectedSize.Width, expectedSize.Height);
            Assert.Equal(sut.Columns * sut.Rows, sut.State.Count);
        }

        public static IEnumerable<object[]> Constructor_generates_new_board_based_on_given_BoardSize_TestData()
            => new List<object[]>
            {
                new object[] { new BoardSize(8, 8) },
                new object[] { new BoardSize(6, 8) },
                new object[] { new BoardSize(8, 6) },
            }
        ;

        [Fact]
        public void Rows_map_to_height()
            => Assert.Equal(2, new BoardGrid(width: 8, height: 2).Rows);

        [Fact]
        public void Columns_map_to_width()
            => Assert.Equal(8, new BoardGrid(width: 8, height: 2).Columns);

        [Fact]
        public void Constructor_generates_new_empty_board()
        {
            var sut = new BoardGrid(8, 8);
            Assert.All(sut.State, boardSlot => Assert.Equal(BoardSlotValue.Empty, boardSlot.Value));
        }

        [Theory, MemberData(nameof(Constructor_generates_a_board_based_on_given_BoardSlotValue_array_TestData))]
        public void Constructor_generates_a_board_based_on_given_BoardSlotValue_array(
            BoardSlotValue[,] boardSlotValues, BoardSize expectedSize)
        {
            var sut = new BoardGrid(boardSlotValues);

            Assert.Equal(expectedSize, sut.ToBoardSize());
            Assert.Equal(expectedSize.Height, sut.Rows);
            Assert.Equal(expectedSize.Width, sut.Columns);
        }

        public static IEnumerable<object[]> Constructor_generates_a_board_based_on_given_BoardSlotValue_array_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new [,]
                    {
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty }
                    },
                    new BoardSize(3, 3) // 3 columns, 3 rows
                },

                new object[]
                {
                    new [,]
                    {
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty }
                    },
                    new BoardSize(3, 2) // 3 columns, 2 rows
                },

                new object[]
                {
                    new [,]
                    {
                        { BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty }
                    },
                    new BoardSize(2, 3) // 2 columns, 3 rows
                },
            }
        ;        
    }
}
