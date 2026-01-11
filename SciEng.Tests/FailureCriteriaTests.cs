using SciEng.Core;
using SciEng.Core.Units;
using System;
using Xunit;

namespace SciEng.Tests
{
    public class FailureCriteriaTests
    {
        [Fact]
        public void VonMises_ReducesToUniaxialStress()
        {
            var s = Units.MPa(300);

            var vm = FailureCriteria.VonMises(
                s, Units.Pa(0), Units.Pa(0),
                Units.Pa(0), Units.Pa(0), Units.Pa(0)
            );

            Assert.Equal(300, vm.MegaPascals, precision: 1);
        }
    }
}