#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Extensions
{
    /// <summary>
    /// Provides string extensions.
    /// </summary>
    public static class StringExtension
    {
        private const char One = '1';
        private const char Zero = '0';

        /// <summary>
        /// Determines is a string value contains a bracket.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        /// <returns>Returns a System.Boolean value indicating the result of the operation.</returns>
        public static bool ContainsBracket(this string value)
        {
            return ((value.Contains("(") == true) || (value.Contains(")") == true));
        }

        /// <summary>
        /// Converts a base 2 string value into a scalar.
        /// </summary>
        /// <param name="value">The base 2 string value to convert.</param>
        /// <returns>Returns a System.Int32 representing the result of the operation.</returns>
        public static uint FromBase2(this string value)
        {
            //  000
            //  x^2+x^1+x^0

            //  > but converting those Base2 values into Base10:
            //  >
            //  > (|010>+|001>+|110>+|101>)
            //  >
            //  > => (2^1 + 2^0 + (2^2 + 2^1) + (2^2 + 2^0))
            //  >
            //  > => (2 + 1 + 6 + 5)
            //  >
            //  > => 14
            //  >

            uint fromBinaryString = 0;

            if (String.IsNullOrEmpty(value) == false)
            {
                int iPower = value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    fromBinaryString += ((value[i] == One) ? (uint)(2.ToPower((value.Length - 1) - i)) : 0);
                }
            }

            return fromBinaryString;
        }

		/// <summary>
		/// Determines if a string value is a bracket.
		/// </summary>
		/// <param name="value">The string value to check.</param>
		/// <returns>Returns a System.Boolean value indicating the result of the operation.</returns>
		public static bool IsBracket(this string value)
        {
            return ((value == "(") || (value == ")"));
        }

        /// <summary>
        /// Removes any instances of brackets from a string value.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        /// <returns>Returns a string value representing the result of the operation.</returns>
        public static string RemoveBrackets(this string value)
        {
            return value.Replace("(", "").Replace(")", "");
        }
    }
}
