using System;
using System.Linq;
using Kodefoxx.Katas.WordChains.Shared;
using Kodefoxx.Katas.WordChains.Tests.TestHelpers;
using Xunit;

namespace Kodefoxx.Katas.WordChains.Tests.Shared
{
    public sealed class WordChainTests
    {
        [Fact]
        public void WordChain_is_of_type_IWordChain()
            => Xssert.TheActualType<WordChain>().IsDerivedFromTheExpectedType<IWordChain>()
        ;

        [Fact]
        public void New_produces_an_object_that_is_of_type_IWordChain()
            => Xssert
                .TheActualType(actualType: 
                    WordChain.New(
                        words: Enumerable.Range(0, 2).Select(i => $"word{i}"),
                        duration: TimeSpan.Zero
                    )
                    .GetType()
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
                    var words = Enumerable.Range(0, amountOfWords).Select(i => $"word{i}");
                    WordChain.New(words: words, duration: TimeSpan.Zero);
                },
                expectedParameterName: "words",
                expectedMessageContains: $"The parameter 'words' should at least contain 2 words, in stead of the provided amount of '{amountOfWords}' words."
            )
        ;
    }    
}
