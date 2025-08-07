#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a Toffoli gate, used to perform doubly-Controlled NOT operations against a register.
    /// </summary>
    public class ToffoliGate : SquareEightMatrix
    {
        /// <summary>
        /// Constructs a new instance of the ToffoliGate type.
        /// </summary>
        public ToffoliGate()
            : this(DefaultCoefficient)
        {
        }

        /// <summary>
        /// Constructs a new instance of the ToffoliGate type.
        /// </summary>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public ToffoliGate(double coefficient)
            : base(coefficient)
        {
            for (uint i = 0; i < (Rows - 2); i++)
            {
                this[i, i] = 1;
            }

            this[6, 7] = 1;
            this[7, 6] = 1;
        }

        /// <summary>
        /// Calculates the value for a value. This is a gate specific operation.
        /// </summary>
        /// <param name="value">The value to base the operation from.</param>
        /// <returns>Returns a System.Char representing the result of the operation.</returns>
        protected override char GetValue(char value)
        {
            return ((value == Matrix.Zero) ? Matrix.One : Matrix.Zero);
        }
    }
}
