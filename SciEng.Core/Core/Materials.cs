namespace SciEng.Core.Materials
{
    public sealed class Material
    {
        public double YoungsModulus { get; } //Pascals
        public double PoissonRatio { get; }
        public double YieldStrength { get; } //Pascals

        public Material(double youngsModulus, double poissonRatio, double yieldStrength)
        {
            Validation.RequirePositive(youngsModulus, nameof(youngsModulus));
            Validation.RequireInRange(poissonRatio, 0.0, 0.5, nameof(poissonRatio));
            Validation.RequirePositive(yieldStrength, nameof(yieldStrength));

            YoungsModulus = youngsModulus;
            PoissonRatio = poissonRatio;
            YieldStrength = yieldStrength;
        }
    }
}