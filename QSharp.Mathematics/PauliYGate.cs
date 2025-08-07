#region Using References

using System;
using System.Numerics;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a Pauli-Y gate, used to perform Y operations against a register.
    /// </summary>
    public class PauliYGate : SquareTwoMatrix
    {
        /// <summary>
        /// Constructs a new instance of the PauliYGate type.
        /// </summary>
        public PauliYGate()
            : base(new Complex(0, 0), new Complex(1, -1), new Complex(1, 1), new Complex(0, 0))
        {
            //  A   B
            //  C   D
            //  0   -i
            //  i   0
        }
    }
}