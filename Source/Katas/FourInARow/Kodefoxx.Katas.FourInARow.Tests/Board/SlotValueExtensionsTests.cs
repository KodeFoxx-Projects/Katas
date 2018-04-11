using System.Collections.Generic;
using Kodefoxx.Katas.FourInARow.Board;
using Xunit;

namespace Kodefoxx.Katas.FourInARow.Tests.Board
{
    public sealed class SlotValueExtensionsTests
    {
        [Theory, MemberData(nameof(Can_convert_BoardSlotValue_to_BoardSize_TestData))]
        public void Can_convert_BoardSlotValue_to_BoardSize(
            BoardSlotValue[,] boardSlotValueArray, BoardSize expected
        ) => Assert.Equal(expected, boardSlotValueArray.ToBoardSize());

        public static IEnumerable<object[]> Can_convert_BoardSlotValue_to_BoardSize_TestData()
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
                    new BoardSize(3),
                },

                new object[]
                {
                    new [,]
                    {
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty }
                    },
                    new BoardSize(3, 4),
                },

                new object[]
                {
                    new [,]
                    {
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                        { BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty, BoardSlotValue.Empty },
                    },
                    new BoardSize(4, 3),
                },
            };
    }
}
