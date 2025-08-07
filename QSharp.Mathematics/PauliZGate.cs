#region Using References

using System;
using System.Numerics;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a Pauli-Z gate, used to perform Z operations against a register.
    /// </summary>
    public class PauliZGate : SquareTwoMatrix
    {
        /// <summary>
        /// Constructs a new instance of the PauliZGate type.
        /// </summary>
        public PauliZGate()
            : base(new Complex(1, 0), new Complex(0, 0), new Complex(0, 0), new Complex(-1, 0))
        {
            //  A   B
            //  C   D
            //  1   0
            //  0   -1
        }
    }
}
