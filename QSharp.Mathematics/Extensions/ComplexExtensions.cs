#region Using References

using System;
using System.Numerics;

#endregion

namespace QSharp.Mathematics.Extensions
{
    /// <summary>
    /// Provides System.Numerics.Complex type extensions.
    /// </summary>
    public static class ComplexExtensions
    {
        /// <summary>
        /// Calculates the mod square of the supplied value.
        /// </summary>
        /// <param name="value">The value to calculate.</param>
        /// <returns>Returns a System.Double representing the result of the operation.</returns>
        public static double ModSquare(this Complex value)
        {
            double modSquare = 0;
            double dValue = ((value.Real) * (value.Real)) + ((value.Imaginary) * (value.Imaginary));

            if (dValue > 0)
            {
                modSquare = dValue;
            }

            return modSquare;
        }

        /// <summary>
        /// Produces a complex product from two terms.
        /// </summary>
        /// <param name="value">The Complex type term.</param>
        /// <param name="coefficient">The coefficient Complex type term.</param>
        /// <returns>Returns a new System.Numerics.Complex type representing the result of the operation.</returns>
        public static Complex Multiply(this Complex value, Complex coefficient)
        {
            double a = value.Real;
            double bi = value.Imaginary;
            double c = coefficient.Real;
            double di = coefficient.Imaginary;

            //  (a + bi)(c + di)
            //  => a(c + di) + bi(c + di)
            //  => (ac + adi) + (cbi + bdi^2)
            //  => (ac + adi) + (cbi + bd(-1))
            //  => ac + adi + cbi + bd(-1)

            double ac = (a * c);
            double adi = (a * di);
            double cbi = (c * bi);
            double bd = ((bi * di) * -1);

            return new Complex((ac + bd), (adi + cbi));
        }
    }
}
