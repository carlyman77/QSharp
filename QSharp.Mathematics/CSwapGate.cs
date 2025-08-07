#region Using References

using System;

using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a CSwap (Fredkin) gate, used to perform Controlled SWAP operations against a register.
    /// </summary>
    public class CSwapGate : SquareEightMatrix
    {
        /// <summary>
        /// Constructs a new instance of the CSwapGate type.
        /// </summary>
        public CSwapGate()
            : this(DefaultCoefficient)
        {
        }

        /// <summary>
        /// Constructs a new instance of the CSwapGate type.
        /// </summary>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public CSwapGate(double coefficient)
            : base(coefficient)
        {
            for (uint i = 0; i < 5; i++)
            {
                this[i, i] = 1;
            }

            this[5, 6] = 1;
            this[6, 5] = 1;
            this[7, 7] = 1;
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="control">The control qubit value.</param>
        /// <param name="target0">The first target value.</param>
        /// <param name="target1">The second target value.</param>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public override ComputationalBasisState[] ApplyTo(int control, int target0, int target1, Register register)
        {
            Matrix matrix = new SquareMatrix((uint)(register.StateVector.Length), 0);

            for (uint i = 0; i < register.StateVector.Length; i++)
            {
                int iControl = -1;
                int iTarget0 = -1;
                int iTarget1 = -1;
                string binaryIndex = register.StateVector[i].BinaryIndex;
                char[] binaryBits = binaryIndex.ToCharArray();

                if ((control < binaryBits.Length) && (control < binaryBits.Length) && (target0 < binaryBits.Length) && (target1 < binaryBits.Length))
                {
                    iControl = ((int)(binaryBits[control]) - 48);
                    iTarget0 = ((int)(binaryBits[target0]) - 48);
                    iTarget1 = ((int)(binaryBits[target1]) - 48);
                }

                if ((iControl == 1) && (iTarget0 < binaryBits.Length) && (iTarget1 < binaryBits.Length))
                {
                    char temp = binaryBits[target0];

                    binaryBits[target0] = binaryBits[target1];
                    binaryBits[target1] = temp;
                }

                string newBinaryIndex = new string(binaryBits);
                uint column = newBinaryIndex.FromBase2();

                matrix[i, column] = 1;
            }

            return matrix * register;
        }
    }
}
