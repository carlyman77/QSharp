#region Using References

using System;
using System.Numerics;
using System.Text;

#endregion

namespace QSharp.Mathematics.Extensions
{
    /// <summary>
    /// Provides System.Int32 type extensions.
    /// </summary>
    public static class Int32Extensions
    {
        /// <summary>
        /// Produces a complex product from two terms.
        /// </summary>
        /// <param name="value">The scalar value term.</param>
        /// <param name="coefficient">The coefficient Complex type term.</param>
        /// <returns>Returns a new System.Numerics.Complex type representing the result of the operation.</returns>
        public static Complex Multiply(this int value, Complex coefficient)
        {
            double a = value;
            double bi = 0;
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

        /// <summary>
        /// Calculates the square root.
        /// </summary>
        /// <param name="value">The value used by the operation.</param>
        /// <returns>Returns a System.Double value representing the result of the operation.</returns>
        public static double SquareRoot(this int value)
        {
            return Math.Sqrt(value);
        }

        /// <summary>
        /// Converts a scalar value into its base 2 string representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>Returns a string value representing the result of the operation.</returns>
        public static string ToBase2(this int value)
        {
			StringBuilder stringBuilder = new StringBuilder(((value == 0) ? "0" : ""));

            while (value > 0)
            {
                int iValue = (int)(value % 2);
				stringBuilder.Insert(0, iValue);
                value /= 2;
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts a scalar value into its base 2 string representation, padding the result as required.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="size">A value indicating the length of leading padding required.</param>
        /// <returns>Returns a string value representing the result of the operation.</returns>
        public static string ToBase2(this int value, int size)
        {
            StringBuilder stringBuilder = new StringBuilder(ToBase2(value));
            
            while (stringBuilder.Length < size)
            {
				stringBuilder.Insert(0, 0);
            }

			return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts a scalar value into its base 26 representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>Returns a string value representing the result of the operation.</returns>
        public static string ToBase26(this int value)
        {
            return Convert.ToString((char)(0 + 65));
        }

        /// <summary>
        /// Converts a scalar value into its char representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>Returns a System.Char value representing the result of the operation.</returns>
        public static char ToChar(this int value)
        {
            return (char)(value + 48);
        }

        /// <summary>
        /// Raises a scalar value to the specified exponent.
        /// </summary>
        /// <param name="value">The value to raise.</param>
        /// <param name="exponent">The exponent value.</param>
        /// <returns>Returns a System.Int32 value representing the result of the operation.</returns>
        public static int ToPower(this int value, int exponent)
        {
            int power = 0;

            switch (exponent)
            {
                case 0:
                    power = 1;
                    break;

                case 1:
                    power = value;
                    break;

                default:
                    power = value;
                    exponent--;

                    while (exponent-- > 0)
                    {
                        power *= value;
                    }
                    break;
            }

            return power;
        }

        /// <summary>
        /// Converts a scalar into a qubit index string value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="length">The length the calculated string value should conform to.</param>
        /// <returns>Returns a string value representing the result of the operation.</returns>
        public static string ToQubitIndex(this int value, int length)
        {
            string toQubitIndex = "";

            for (int i = 0; i < length; i++)
            {
                toQubitIndex += ((i == value) ? "1" : "0");
            }

            return toQubitIndex;
        }
    }
}
