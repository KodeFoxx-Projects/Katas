using System;
using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.WordChains.Shared.WordLists;
using Kodefoxx.Katas.WordChains.Shared.WordsSanitizers;
using Kodefoxx.Katas.WordChains.Tests.TestHelpers;
using Xunit;

namespace Kodefoxx.Katas.WordChains.Tests.Shared.WordLists
{
    public sealed class WordListTests
    {
        [Theory,
         MemberData(nameof(Sanitizer_returns_equal_amount_of_words_TestData))]
        public void Sanitizer_returns_equal_amount_of_words(
            List<string> inputWords,            
            Func<IEnumerable<string>, IEnumerable<string>> wordsSanitizerFunction)
        {            
            var sut = new WordList(inputWords.ToList(), wordsSanitizerFunction);

            Assert.Equal(inputWords.Count, sut.Words.Count());            
        }

        public static IEnumerable<object[]> Sanitizer_returns_equal_amount_of_words_TestData()
            // Words with a null implementation of the sanitizer
            => TestData
                .GetFileInfosWithContents()
                .Select(fileInfoWithContents => fileInfoWithContents.Words.ToList())
                .Select(words => new object[] { words, null })
            .Concat(
               // Words with a concrete implementation of the sanitizer
               TestData
                .GetFileInfosWithContents()
                .Select(fileInfoWithContents => fileInfoWithContents.Words.ToList())
                .Select(words => new object[]
                   {
                       words,
                       new Func<IEnumerable<string>, IEnumerable<string>>(
                           new TrimmedAndLowerCaseWordsSanitizer().SanitizeWords
                       )
                   }
                )
            )
        ;

        [Theory,
         MemberData(nameof(Sanitizer_returns_words_sanitized_by_sanitizer_function_TestData))]
        public void Sanitizer_returns_words_sanitized_by_sanitizer_function(
            Func<IEnumerable<string>, IEnumerable<string>> wordsSanitizerFunction,
            List<string> inputWords, List<string> expectedWords)
        {
            var sut = new WordList(inputWords, wordsSanitizerFunction);

            Assert.Equal(expectedWords, sut.Words);
        }

        public static IEnumerable<object[]> Sanitizer_returns_words_sanitized_by_sanitizer_function_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new Func<IEnumerable<string>, IEnumerable<string>>(words => words.Select(word => word.ToUpper())),
                    new List<string> { "One", "  Two", "three", "  Four " },
                    new List<string> { "ONE", "  TWO", "THREE", "  FOUR " }
                },
                new object[]
                {
                    new Func<IEnumerable<string>, IEnumerable<string>>(new TrimmedAndLowerCaseWordsSanitizer().SanitizeWords),
                    new List<string> { "One", "Two", "three", "  Four " },
                    new List<string> { "one", "two", "three", "four" }
                },
                new object[]
                {
                    null,
                    new List<string> { "One", "Two", "three", "  Four " },
                    new List<string> { "One", "Two", "three", "  Four " },
                },
            }
        ;
    }
}