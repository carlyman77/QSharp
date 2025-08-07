#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a CNOT gate, used to perform singly-Controlled NOT operations against a register.
    /// </summary>
    public class CNotGate : SquareFourMatrix
    {
        /// <summary>
        /// Constructs a new instance of the CNotGate type.
        /// </summary>
        public CNotGate()
            : base(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0)
        {
        }

        /// <summary>
        /// Calculates the value for a value.
        /// </summary>
        /// <param name="value">The value to base the operation from.</param>
        /// <returns>Returns '0' of the value is '1', otherwise '0'.</returns>
        protected override char GetValue(char value)
        {
            return ((value == Matrix.Zero) ? Matrix.One : Matrix.Zero);
        }
    }
}
