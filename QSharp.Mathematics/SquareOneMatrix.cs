#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a square matrix, where the number of rows and the number of columns are equal to 1.
    /// </summary>
    public class SquareOneMatrix : SquareMatrix
    {
        /// <summary>
        /// Constructs a new instance of the SquareOneMatrix type.
        /// </summary>
        /// <param name="value">The default value of each matrix element.</param>
        public SquareOneMatrix(int value)
            : base(1, value)
        {
        }
    }
}
