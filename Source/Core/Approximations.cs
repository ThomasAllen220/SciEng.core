using System;
using SciEng.Core.Units;

namespace SciEng.Core
{
    /// <summary>
    /// Engineering approximations for early-stage design exploration.
    /// These methods prioritise speed and transparency over fidelity.
    /// </summary>
    
    public static class Approximations
    {
        internal static class BeamDeflection
        {
            /// <summary>
            /// Cantilever beam with end load.
            /// Euler-Bernoulli beam theory.
            /// 
            /// δ = F L³ / (3 E I)
            /// 
            /// Assumptions:
            /// -Linear elastic material
            /// -Small deflections
            /// -Uniform cross-section
            /// </summary>
            
            public static double CantileverEndload(
                Force force, 
                double length,
                double secondMomentOfArea,
                Material material)
            {
                Validation.RequirePositive(length, nameof(length));
                Validation.RequirePositive(secondMomentOfArea, nameof(secondMomentOfArea));
#
                return force.Newtons * Math.Pow(length, 3)
                    / (3 * material.YoungsModulus * secondMomentOfArea);
            }
        }
    }
}