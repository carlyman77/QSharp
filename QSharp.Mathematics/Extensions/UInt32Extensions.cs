#region Using References

using System;
using System.Text;

#endregion

namespace QSharp.Mathematics.Extensions
{
    /// <summary>
    /// Provides System.UInt32 type extensions.
    /// </summary>
    public static class UInt32Extensions
    {
        /// <summary>
        /// Converts a scalar value into its base 2 string representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>Returns a string value representing the result of the operation.</returns>
        public static string ToBase2(this uint value)
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
        public static string ToBase2(this uint value, int size)
        {
            StringBuilder stringBuilder = new StringBuilder(ToBase2(value));
            
            while (stringBuilder.Length < size)
            {
				stringBuilder.Insert(0, 0);
            }

            return stringBuilder.ToString();
        }
    }
}
