using SciEng.Core.Units;
using SciEng.Core.Materials;

namespace SciEng.Core
{
    public static class Mechanics
    {
        /// <summary>
        /// Calculates uniaxial stress assuming uniform cross-section.
        /// σ = F / A
        /// </summary>

        public static Stress CalculateUniaxialStress(Force force, Area area)
        {
            var stressPa = force.Newtons / area.SquareMetres;
            return stressPa.Pa();
        }

        /// <summary>
        /// Calculates linear elastic strain.
        /// ε = σ / E
        /// </summary>
         
        public static double CalculateLinearStrain(Stress stress, Material material)
        {
            return stress.Pascals / material.YoungsModulus;
        }

        /// <summary>
        /// Checks if material has yielded under uniaxial stress.
        /// </summary>
        
        public static bool HasYielded(Stress stress, Material material)
        {
            return stress.Pascals >= material.YieldStrength;
        }
    }
}