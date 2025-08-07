#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a square matrix, where the number of rows matches the number of columns.
    /// </summary>
    public class SquareMatrix : Matrix
    {
		/// <summary>
		/// Constructs a new instance of the SquareMatrix type.
		/// </summary>
		/// <param name="size">The number of rows and columns.</param>
		/// <param name="value">The default value of each matrix element.</param>
		public SquareMatrix(uint size, int value)
            : base(size, size, value)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SquareMatrix type.
        /// </summary>
        /// <param name="size">The number of rows and columns.</param>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public SquareMatrix(uint size, double coefficient)
            : base(size, size,  coefficient)
        {
        }
    }
}
