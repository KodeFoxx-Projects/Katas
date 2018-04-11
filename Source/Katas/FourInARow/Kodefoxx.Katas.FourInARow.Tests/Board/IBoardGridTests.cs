using System.Collections.Generic;
using Kodefoxx.Katas.FourInARow.Board;
using Kodefoxx.Katas.FourInARow.Board.Exceptions;
using Xunit;

namespace Kodefoxx.Katas.FourInARow.Tests.Board
{
    public sealed class IBoardGridTests
    {        
        [Theory, MemberData(nameof(Can_detect_when_a_column_is_full_TestData))]
        public void Can_detect_when_a_column_is_full(IBoardGrid boardGrid, int columnIndex, bool expected)
            => Assert.Equal(expected, boardGrid.IsColumnFull(columnIndex));

        public static IEnumerable<object[]> Can_detect_when_a_column_is_full_TestData()
        {            
            return new List<object[]>
            {
                new object[]
                {
                    BoardGridHelper.CreateFourByFourBoard(), 1, false
                },

                new object[]
                {
                    BoardGridHelper.CreateFourByFourBoard(), 2, false
                },

                new object[]
                {
                    BoardGridHelper.CreateFourByFourBoard(), 3, true
                },

                new object[]
                {
                    BoardGridHelper.CreateFourByFourBoard(), 4, false
                },
            };
        }

        [Fact]
        public void Throws_ColumnIsFullException_when_trying_to_add_to_a_full_column()
        {
            var sut = BoardGridHelper.CreateFourByFourBoard();
            var columnIndex = 3;
            var exception = Assert.Throws<ColumnIsFullException>(
                () => sut.DropValueIntoColumn(BoardSlotValue.PlayerOne, columnIndex)
            );
            Assert.Equal(columnIndex, exception.ColumnIndex);
        }

        [Theory,
         InlineData(0),
         InlineData(5)]
        public void Throws_ColumnDoesntExistFullException_when_trying_to_add_to_a_column_that_does_not_exist(int columnIndex)
        {
            var sut = BoardGridHelper.CreateFourByFourBoard();
            var exception = Assert.Throws<ColumnDoesntExistException>(
                () => sut.DropValueIntoColumn(BoardSlotValue.PlayerOne, columnIndex)
            );
            Assert.Equal(columnIndex, exception.ColumnIndex);
        }        
    }
}
