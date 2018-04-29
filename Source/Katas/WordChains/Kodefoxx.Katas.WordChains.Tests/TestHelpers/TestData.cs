using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.WordChains.Tests.TestHelpers
{
    public static class TestData
    {
        public static IEnumerable<string> CreateListOfWordsEnumerable(int amountOfWords, int indexStartsAt = 1)
            => Enumerable.Range(indexStartsAt, (amountOfWords + indexStartsAt) - 1).Select(i => $"word{i}");
    }
}
