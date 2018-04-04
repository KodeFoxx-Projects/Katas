using System.Linq;
using Xunit;

namespace Kodefoxx.Katas.FizzBuzz.Tests
{
    public sealed class DefaultFizzBuzzGeneratorTests
    {
        [Fact]
        public void Returns_hundred_values()
            => Assert.Equal(100, CreateSystemUnderTest().Generate().Keys.Count);

        [Fact]
        public void Returns_numbers_one_to_hundred()
            => Assert.Equal(5050, CreateSystemUnderTest().Generate().Keys.Sum());

        private IFizzBuzzGenerator CreateSystemUnderTest()
            => new DefaultFizzBuzzGenerator();        
    }
}
