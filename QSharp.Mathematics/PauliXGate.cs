#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a Pauli-X gate, used to perform NOT (X) operations against a register.
    /// </summary>
    public class PauliXGate : SquareTwoMatrix
    {
        /// <summary>
        /// Constructs a new instance of the PauliXGate type.
        /// </summary>
        public PauliXGate()
            : base(0, 1, 1, 0)
        {
            //  A   B
            //  C   D
            //  0   1
            //  1   0
        }
    }
}
