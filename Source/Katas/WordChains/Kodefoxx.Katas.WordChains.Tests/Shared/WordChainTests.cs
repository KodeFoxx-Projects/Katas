using System;
using System.Linq;
using Kodefoxx.Katas.WordChains.Shared;
using Kodefoxx.Katas.WordChains.Tests.TestHelpers;
using Xunit;
using Kodefoxx.Katas.WordChains.Tests.TestHelpers.AssertExtensions;

namespace Kodefoxx.Katas.WordChains.Tests.Shared
{
    public sealed class WordChainTests
    {
        [Fact]
        public void WordChain_is_of_type_IWordChain()
            => Xssert
                .TheActualType<WordChain>()
                .IsDerivedFromTheExpectedType<IWordChain>()
        ;

        [Fact]
        public void New_produces_an_object_that_is_of_type_IWordChain()
            => Xssert
                .TheActualType(actualTypeSelector: () =>
                    WordChain.New(
                        words: TestData.CreateListOfWordsEnumerable(2),
                        duration: TimeSpan.Zero
                    )                    
                )
                .IsDerivedFromTheExpectedType<IWordChain>()
        ;

        [Fact]
        public void Throws_ArgumentNullException_when_words_parameter_is_null()
            => Xssert.ThrowsArgumentNullException(
                testCode: () => WordChain.New(words: null, duration: TimeSpan.Zero),
                expectedParameterName: "words"
            )
        ;

        [Theory,         
         InlineData(0),
         InlineData(1)]
        public void Throws_ArgumentOutOfRangeException_when_words_parameter_holds_less_than_two_words(int amountOfWords)
            => Xssert.ThrowsArgumentOutOfRangeException(
                testCode: () =>
                {
                    var words = TestData.CreateListOfWordsEnumerable(amountOfWords);
                    WordChain.New(words: words, duration: TimeSpan.Zero);
                },
                expectedParameterName: "words",
                expectedMessageContains: $"The parameter 'words' should at least contain 2 words, in stead of the provided amount of '{amountOfWords}' words."
            )
        ;

        [Fact]
        public void StartingWord_is_the_same_as_the_first_word_in_the_given_list()
            => Assert.Equal("word1", WordChain.New(TestData.CreateListOfWordsEnumerable(20), TimeSpan.Zero).StartingWord);

        [Fact]
        public void EndingWord_is_the_same_as_the_last_word_in_the_given_list()
            => Assert.Equal("word20", WordChain.New(TestData.CreateListOfWordsEnumerable(20), TimeSpan.Zero).EndingWord);

        [Fact]
        public void Words_contains_the_same_elements_as_the_given_list()
        {
            var words = TestData.CreateListOfWordsEnumerable(20).ToList();

            var sut = WordChain.New(words, TimeSpan.Zero);

            Assert.Equal(words.Count, sut.Words.Count());
            Assert.All(sut.Words, word => Assert.Contains(word, words));
        }

        [Theory,
         InlineData(5),
         InlineData(15),
         InlineData(30)]
        public void Length_reflects_the_number_of_words_in_the_chain(int amountOfWords)
            => Assert.Equal(amountOfWords, WordChain.New(TestData.CreateListOfWordsEnumerable(amountOfWords), TimeSpan.Zero).Length);
    }    
}
