using SciEng.Core;
using Xunit;

namespace SciEng.Tests
{
    public class MaterialTests
    {
        [Fact]
        public void InvalidPoissonRatio_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new MaterialTests(200e9, 0.9, 300e6)
            );
        }
    }
}