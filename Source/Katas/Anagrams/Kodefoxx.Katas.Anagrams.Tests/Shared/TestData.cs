using System;
using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.Anagrams.Shared;

namespace Kodefoxx.Katas.Anagrams.Tests.Shared
{
    public static class TestData
    {
        public static AnagramSolverResult AnagramSolverResultBasedOnWordListContainingOnlyAnagrams
            => new AnagramSolverResult(
                anagrams: new List<Anagram>
                {
                    new Anagram(new []{ "kinship", "pinkish", }),
                    new Anagram(new []{ "enlist", "inlets", "listen", "silent", }),
                    new Anagram(new []{ "boaster", "boaters", "borates", }),
                    new Anagram(new []{ "fresher", "refresh", }),
                    new Anagram(new []{ "sinks", "skins", }),
                    new Anagram(new []{ "knits","stink", }),
                    new Anagram(new []{ "rots", "sort" }),
                },
                duration: TimeSpan.Zero
            )
        ;

        public static List<string> WordListContainingOnlyAnagrams
            => AnagramSolverResultBasedOnWordListContainingOnlyAnagrams
                .Anagrams
                .SelectMany(anagram => anagram.Words)
                .ToList()
        ;

        public static AnagramSolverResult EmptyAnagramSolverResult
            => new AnagramSolverResult(new List<Anagram>(), TimeSpan.Zero);

        public static List<string> WordListContainingNoAnagrams
            => new List<string>
            {
                "morph",
                "darkness",
                "festival"
            }
        ;

        public static List<string> WordListContainingBothAnagramsAndNone
            => WordListContainingNoAnagrams
                .Concat(WordListContainingOnlyAnagrams)
                .ToList()
        ;
    }
}
