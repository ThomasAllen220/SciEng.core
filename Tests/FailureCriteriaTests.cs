using SciEng.Core;
using System;

namespace SciEng.Tests
{
    public class FailureCriteriaTests
    {
        [Fact]
        public void VonMises_ReducesToUniaxialStress()
        {
            var s = 300.MPa();

            var vm = FailureCriteria.VonMises(
                s, 0.Pa(), 0.Pa(),
                0.Pa(), 0.Pa(), 0.Pa()
            );

            Assert.Equal(300, vm.MegaPascals, precision: 1);
        }
    }
}