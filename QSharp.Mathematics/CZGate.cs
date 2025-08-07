#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a CZ gate, used to perform Controlled Z operations against a register.
    /// </summary>
    public class CZGate : SquareFourMatrix
    {
        /// <summary>
        /// Constructs a new instance of the CNotGate type.
        /// </summary>
        public CZGate()
            : base(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1)
        {
        }

        /// <summary>
        /// Calculates the coefficient for a value.
        /// </summary>
        /// <param name="value">The value to calculate a coefficient for.</param>
        /// <returns>Returns 1 id the value is '0', otherwise -1.</returns>
        protected override int GetCoefficient(char value)
        {
            return ((value == Matrix.Zero) ? 1 : -1);
        }
    }
}
