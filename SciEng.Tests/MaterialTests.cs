using SciEng.Core;
using SciEng.Core.Units;
using SciEng.Core.Materials;
using Xunit;
using System;

namespace SciEng.Tests
{
    public class MaterialTests
    {
        [Fact]
        public void InvalidPoissonRatio_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Material(200e9, 0.9, 300e6)
            );
        }
    }
}