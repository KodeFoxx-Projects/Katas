using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kodefoxx.Katas.Shared;
using Kodefoxx.Katas.WordChains.Shared.WordLists;
using Kodefoxx.Katas.WordChains.Tests.TestHelpers;
using Xunit;

namespace Kodefoxx.Katas.WordChains.Tests.Shared.WordLists
{
    public sealed class FileWordListTests
    {
        [Theory, 
         MemberData(nameof(Number_of_words_is_the_same_as_in_the_file_TestData))]
        public void Number_of_words_is_the_same_as_in_the_file(FileInfo fileInfo)
        {            
            var expectedWords = File.ReadAllLines(fileInfo.FullName);

            var sut = new FileWordList(fileInfo);            
            
            Assert.Equal(expectedWords, sut.Words);
        }

        public static IEnumerable<object[]> Number_of_words_is_the_same_as_in_the_file_TestData()
            => TestData
                .GetFileInfosWithContents()
                .Select(fileInfoWithContents => fileInfoWithContents.FileInfo)
                .ToEnumerableOfArrayOfObject()
        ;
    }
}
