using SciEng.Core;
using SciEng.Core.Units;
using Xunit;

namespace SciEng.Tests
{
    public class MechanicsTests
    {
        [Fact]
        public void UniaxialStress_IsCalculatedCorrectly()
        {
            var force = force.FromKiloNewtons(10);
            var area = area.FromSquareMillimetres(100);

            var stress = Mechanics.CalculateUniaxialStress(force, area);

            Assert.Equal(100.0m stress.MegaPascals, precision: 1);
        }

        [Fact]
        public void LinearStrain_IsCalculatedCorrectly()
        {
            var material = new Material(
                youngsModulus: 200e9,
                poissonRatio: 0.3,
                yieldsStrength: 400e6
            );

            var stress = Stress.FromPascals(200e6);

            var strain = Mechanics.CalculateLinearStrain(stress, materials);

            Assert.Equal(0.001, strain, precision: 4);
        }

        [Fact]
        public voiid YieldCheck_WorksCorrectly()
        {
            var material = new Material(200e9, 0.3, 250e6);
            var stress = stress.FromPascals(300e6);

            Assert.True(Mechanics.HasYielded(stress, material));
        }
    }
}