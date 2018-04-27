using System.Collections.Generic;
using Kodefoxx.Katas.Anagrams.Shared;
using Kodefoxx.Katas.Anagrams.Strategies.MetadataAnagramSolverStrategy;
using Kodefoxx.Katas.Anagrams.Tests.Shared;
using Xunit;

namespace Kodefoxx.Katas.Anagrams.Tests.Strategies.MetadataAnagramSolverStrategy
{
    public sealed class MetadataAnagramSolverTests
    {
        [Theory, MemberData(nameof(Can_find_anagrams_inside_a_given_list_TestData))]
        public async void Can_find_anagrams_inside_a_given_list(
            List<string> wordList, AnagramSolverResult expectedAnagramSolverResult)
        {
            var sut = CreateSystemUnderTest();
            var actual = await sut.GetAnagrams(wordList);

            Assert.Equal(
                expectedAnagramSolverResult.Count, 
                actual.Count
            );
        }

        public static IEnumerable<object[]> Can_find_anagrams_inside_a_given_list_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    TestData.WordListContainingOnlyAnagrams,
                    TestData.AnagramSolverResultBasedOnWordListContainingOnlyAnagrams
                },

                new object[]
                {
                    TestData.WordListContainingNoAnagrams,
                    TestData.EmptyAnagramSolverResult
                },

                new object[]
                {
                    TestData.WordListContainingBothAnagramsAndNone,
                    TestData.AnagramSolverResultBasedOnWordListContainingOnlyAnagrams
                },
            }
        ;

        [Fact]
        public async void Returns_empty_anagram_result_when_no_anagrams_were_found()
        {
            var sut = CreateSystemUnderTest();
            var actual = await sut.GetAnagrams(TestData.WordListContainingNoAnagrams);

            Assert.NotNull(actual);
            Assert.Empty(actual.Anagrams);
            Assert.Equal(0, actual.Count);
        }        

        private IAnagramSolver CreateSystemUnderTest()
            => new MetadataAnagramSolver();
    }
}
