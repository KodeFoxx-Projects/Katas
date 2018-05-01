using System;
using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.Shared;
using Kodefoxx.Katas.WordChains.Shared;
using Kodefoxx.Katas.WordChains.Tests.TestHelpers;
using Kodefoxx.Katas.WordChains.Tests.TestHelpers.AssertExtensions;
using Xunit;

namespace Kodefoxx.Katas.WordChains.Tests.Shared
{
    public sealed class WordChainSolverResultTests
    {
        [Fact]
        public void WordChainSolverResult_isof_type_IWordChainSolverResult()
            => Xssert
                .TheActualType<WordChainSolverResult>()
                .IsDerivedFromTheExpectedType<IWordChainSolverResult>()
        ;

        [Fact]
        public void New_produces_an_object_that_is_of_type_IWordChainSolverResult()
            => Xssert
                .TheActualType(actualTypeSelector: () =>
                    WordChainSolverResult.New(
                        wordChains: null
                    )
                )
                .IsDerivedFromTheExpectedType<IWordChainSolverResult>()
        ;

        [Theory,
         MemberData(nameof(Does_not_throw_an_exception_when_null_or_empty_IWordChain_collection_is_passed_TestData))]
        public void Does_not_throw_an_exception_when_null_or_empty_IWordChain_collection_is_passed(
            IEnumerable<IWordChain> wordChains
        ) => Assert.NotNull(WordChainSolverResult.New(wordChains));

        public static IEnumerable<object[]> Does_not_throw_an_exception_when_null_or_empty_IWordChain_collection_is_passed_TestData()
            => TestData.NullAndEmptyWordChainCollections
                .Select(wordChain => wordChain)
                .ToEnumerableOfArrayOfObject()
        ;

        [Theory,
         MemberData(nameof(Duration_is_TimeSpan_Zero_when_null_or_empty_IWordChain_collection_is_passed_TestData))]
        public void Duration_is_TimeSpan_Zero_when_null_or_empty_IWordChain_collection_is_passed(
            IEnumerable<IWordChain> wordChains
        ) => Assert.Equal(TimeSpan.Zero, WordChainSolverResult.New(wordChains).Duration);

        public static IEnumerable<object[]> Duration_is_TimeSpan_Zero_when_null_or_empty_IWordChain_collection_is_passed_TestData()
            => TestData.NullAndEmptyWordChainCollections
                .Select(wordChain => wordChain)
                .ToEnumerableOfArrayOfObject()
        ;

        [Theory,
         MemberData(nameof(Duration_is_calulcated_accordingly_for_a_given_IWordChain_collection_TestData))]
        public void Duration_is_calulcated_accordingly_for_a_given_IWordChain_collection(
            List<IWordChain> wordChains, TimeSpan expectedDuration)
        {            
            var sut = WordChainSolverResult.New(wordChains);

            Assert.Equal(expectedDuration, sut.Duration);
        }

        public static IEnumerable<object[]> Duration_is_calulcated_accordingly_for_a_given_IWordChain_collection_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new List<IWordChain>
                    {
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(1))
                    },
                    TimeSpan.FromSeconds(1)
                },

                new object[]
                {
                    new List<IWordChain>
                    {
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(1)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(5)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromMinutes(1))
                    },
                    new TimeSpan(hours: 0, minutes: 1, seconds: 6),
                },

                new object[]
                {
                    new List<IWordChain>
                    {
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromMilliseconds(505)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(5)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromMinutes(3))
                    },
                    new TimeSpan(hours: 0, minutes: 3, seconds: 5).Add(TimeSpan.FromMilliseconds(505)),
                }
            }
        ;

        [Theory,
         MemberData(nameof(IWordChain_collections_are_equivalent_as_those_that_where_passed_TestData))]
        public void IWordChain_collections_are_equivalent_as_those_that_where_passed(
            List<IWordChain> wordChains, int expectedAmountOfWordChains)
        {
            var sut = WordChainSolverResult.New(wordChains);

            Assert.Equal(expectedAmountOfWordChains, sut.AmountOfWordChains);
            Assert.Equal(wordChains, sut.WordChains);
        }
        public static IEnumerable<object[]> IWordChain_collections_are_equivalent_as_those_that_where_passed_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new List<IWordChain>
                    {
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(1))
                    },
                    1
                },

                new object[]
                {
                    new List<IWordChain>
                    {
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(1)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(5)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromMinutes(1))
                    },
                    3
                },

                new object[]
                {
                    new List<IWordChain>
                    {
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromMilliseconds(505)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromSeconds(5)),
                        WordChain.New(TestData.CreateListOfWordsEnumerable(10), TimeSpan.FromMinutes(3))
                    },
                    3
                }
            }
        ;
    }
}