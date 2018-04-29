using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kodefoxx.Katas.WordChains.Tests.TestHelpers
{
    public static class TestData
    {
        public static IEnumerable<string> CreateListOfWordsEnumerable(int amountOfWords, int indexStartsAt = 1)
            => Enumerable.Range(indexStartsAt, (amountOfWords + indexStartsAt) - 1).Select(i => $"word{i}");

        public static FileInfo GetWordListFileInfo() => GetFileInfo("wordlist.txt");
        public static FileInfo GetEnglish3FileInfo() => GetFileInfo("english3.txt");
        public static FileInfo GetNederlands3FileInfo() => GetFileInfo("nederlands3.txt");
        public static (FileInfo FileInfo, IEnumerable<string> Words) GetFileInfoWithContents(FileInfo fileInfo)
            => (FileInfo: fileInfo, Words: File.ReadAllLines(fileInfo.FullName));
        public static IEnumerable<(FileInfo FileInfo, IEnumerable<string> Words)> GetFileInfosWithContents()
            => new List<(FileInfo FileInfo, IEnumerable<string> Words)>
            {
                GetFileInfoWithContents(GetWordListFileInfo()),
                GetFileInfoWithContents(GetEnglish3FileInfo()),
                GetFileInfoWithContents(GetNederlands3FileInfo())
            }
        ;
        private static FileInfo GetFileInfo(string fileName)
            => new FileInfo($"{Path.Combine(Directory.GetCurrentDirectory(), "TestHelpers", "WordLists", fileName)}");
    }
}