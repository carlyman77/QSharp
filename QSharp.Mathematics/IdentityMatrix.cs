#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes an Identity matrix, used to perform Identity operations against a register.
    /// </summary>
    public class IdentityMatrix : SquareTwoMatrix
    {
        /// <summary>
        /// Constructs a new instance of the IdentityMatrix type.
        /// </summary>
        public IdentityMatrix()
            : base(1, 0, 0, 1)
        {
            //  A   B
            //  B   C
            //  1   0
            //  0   1
        }
    }
}