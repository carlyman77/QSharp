#region Using References

using System;

using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a Hadamard gate, used to perform Hadamard operations against a register.
    /// </summary>
    public class HadamardGate : SquareTwoMatrix
    {
        /// <summary>
        /// Constructs a new instance of the HadamardGate type.
        /// </summary>
        public HadamardGate()
            : base(1, 1, 1, -1, (double)((1 / 2.SquareRoot())))
        {
        }
    }
}