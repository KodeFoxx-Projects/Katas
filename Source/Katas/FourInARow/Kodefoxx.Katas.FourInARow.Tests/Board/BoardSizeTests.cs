using System.Collections.Generic;
using Kodefoxx.Katas.FourInARow.Board;
using Xunit;

namespace Kodefoxx.Katas.FourInARow.Tests.Board
{    
    public sealed class BoardSizeTests
    {
        [Theory, MemberData(nameof(Equals_correctly_detects_whether_they_are_the_same_TestData))]
        public void Equals_correctly_detects_whether_they_are_the_same(
            BoardSize subjectA, BoardSize subjectB, bool expected
        ) => Assert.Equal(expected, subjectA.Equals(subjectB));

        public static IEnumerable<object[]> Equals_correctly_detects_whether_they_are_the_same_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new BoardSize(8, 8),
                    new BoardSize(8, 8),
                    true
                },                

                new object[]
                {
                    new BoardSize(1, 1),
                    null,                    
                    false
                },

                new object[]
                {
                    new BoardSize(1, 1),
                    new BoardSize(1, 2), 
                    false
                },
            };
    }
}
