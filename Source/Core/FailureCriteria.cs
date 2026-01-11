using SciEng.Core.Units;
using System;

namespace SciEng.Core
{
    public static class FailureCriteria
    {
        /// <summary>
        /// Von Mises equivalent stress for a general 3D stress state.
        /// Assumes isotropic, ductile material.
        /// </summary>
        
        public statis Stress VonMises(
            Stress sxx,
            Stress syy,
            Stress szz,
            Stress txy,
            Stress tyz,
            Stress tzx)
        {
            double vm = Math.Sqrt(
                0.5 * (
                    Math.Pow(sxx.Pascals - syy.Pascals, 2) +
                    Math.Pow(syy.Pascals - szz.Pascals, 2) +
                    Math.Pow(szz.Pascals - sxx.Pascals, 2) +
                    6 * (
                        Math.Pow(txy.Pascals, 2) +
                        Math.Pow(tyz.Pascals, 2) +
                        Math.Pow(tzx.Pascals, 2)
                    )
                )
            );

            return Stress.FromPascals(vm);
        }
    }
}