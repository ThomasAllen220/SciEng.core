using System;

namespace SciEng.Core
{
    internal static class Validation
    {
        public static void RequirePositive(double value, string name)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(name, "Value must be positive.");
        }

        public static void RequirePositiveOrZero(double value, string name)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(name, "Value must be zero or positive.");
        }

        public static void RequireInRange(double value, double min, double max, string name)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(
                    name,
                    $"Value must be between {min} and {max}."
                    );
        }
    }
}