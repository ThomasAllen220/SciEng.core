namespace SciEng.Core.Units
{
    public readonly struct Force
    {
        public double Newtons { get; }

        public Force(double newtons)
        {
            Validation.RequirePositive(newtons, nameof(newtons));
            Newtons = newtons;
        }

        public static Force FromNewtons(double value) => new(value);
        public static Force FromKiloNewtons(double value) => new(value * 1_000);
    }

    public readonly struct Area
    {
        public double SquareMetres { get; }

        public Area(double squareMetres)
        {
            Validation.RequirePositive(squareMetres, nameof(squareMetres));
            SquareMetres = squareMetres;
        }

        public static Area FromSquareMetres(double value) => new(value);
        public static Area FromSquareMillimetres(double value) => new(value * 1e-6);
    }

    public readonly struct Stress
    {
        public double Pascals { get; }

        public Stress(double pascals)
        {
            Validation.RequirePositiveOrZero(pascals, nameof(pascals));
            Pascals = pascals;
        }

        public double MegaPascals => Pascals / 1e6;

        public static Stress FromPascals(double value) => new(value);
    }

    /// <summary>
    /// Internal convenience extensions for fluent unit creation.
    /// Intended for use within solution-level engineering code.
    /// </summary>
    
    internal static class UnitExtensions
    {
        public static Force N(this double value) => Force.FromNewtons(value);
        public static Force kN(this double value) => Force.FromKiloNewtons(value);

        public static Area m2(this double value) => Area.FromSquareMetres(value);
        public static Area mm2(this double value) => Area.FromSquareMillimeres(value);

        public static Stress Pa(this double value) => Stress.FromPascals(value);
        public static Stress MPa(this double value) => Stress.FromPascals(value * 1e6);
    }
}