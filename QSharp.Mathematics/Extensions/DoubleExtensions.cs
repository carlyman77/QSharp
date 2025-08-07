#region Using References

using System;

using Maths = System.Math;

#endregion

namespace QSharp.Mathematics.Extensions
{
    /// <summary>
    /// Provides System.Double type extensions.
    /// </summary>
    public static class DoubleExtensions
    {
        private const double DistributionValue = 2.147483648e9;
        private const int DefaultRoundDecimalPlaces = 10;

        /// <summary>
        /// Calculates the mod square of the supplied value.
        /// </summary>
        /// <param name="value">The value to calculate.</param>
        /// <returns>Returns a System.Double representing the result of the operation.</returns>
        public static double ModSquare(this double value)
        {
            return Maths.Pow(Maths.Abs(value), 2);
        }

        /// <summary>
        /// Rounds the value to the specified number of decimal places.
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <returns>Returns a System.Double value representing the result of the operation.</returns>
        public static double Round(this double value)
        {
            return Maths.Round(value, DefaultRoundDecimalPlaces);
        }

        /// <summary>
        /// Rounds the value to the specified number of decimal places.
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <param name="decimalPlaces">The number of decimal places to round the value to.</param>
        /// <returns>Returns a System.Double value representing the result of the operation.</returns>
        public static double Round(this double value, int decimalPlaces)
        {
            return Maths.Round(value, decimalPlaces);
        }

        /// <summary>
        /// Calculates the square of the supplied value.
        /// </summary>
        /// <param name="value">The value to calculate.</param>
        /// <returns>Returns a System.Double representing the result of the operation.</returns>
        public static double Square(this double value)
        {
            return (value * value);
        }

        /// <summary>
        /// Calculates the value raised to an exponent.
        /// </summary>
        /// <param name="value">The base value.</param>
        /// <param name="exponent">The exponent to raise the base to.</param>
        /// <returns>Returns a System.Double representing the result of the operation.</returns>
        public static double ToExponent(this double value, int exponent)
        {
            return Maths.Pow(value, exponent);
        }

        /// <summary>
        /// Generates a new random number between 0.0 and 1.0.
        /// </summary>
        /// <param name="value">A placeholder value, not used by the operation.</param>
        /// <returns>Returns a System.Double representing the result of the operation.</returns>
        public static double ToRandom(this double value)
        {
            Random random = new Random();

            return random.NextDouble();
        }

        /// <summary>
        /// Generates a new uniformly distributed random number between 0.0 and 1.0.
        /// </summary>
        /// <param name="value">A placeholder value, not used by the operation.</param>
        /// <returns>Returns a System.Double representing the result of the operation.</returns>
        public static double ToUniformlyDistributedRandom(this double value)
        {
            return ((double)(value.ToRandom()) / DistributionValue + 1) / 2;
        }
    }
}
