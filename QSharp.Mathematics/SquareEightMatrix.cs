#region Using References

using System;
using System.Numerics;

using QSharp.Mathematics.Extensions;

using Maths = System.Math;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a square matrix, where the number of rows and the number of columns are equal to 8, used for triple-qubit operations.
    /// </summary>
    public class SquareEightMatrix : SquareMatrix
    {
        /// <summary>
        /// Constructs a new instance of the SquareEightMatrix type.
        /// </summary>
        public SquareEightMatrix()
            : base(8, DefaultCoefficient)
        {
            //  0  1  2  3  4  5  6  7
            //  A0 B0 C0 D0 E0 F0 G0 H0
            //  A1 B1 C1 D1 E1 F1 G1 H1
            //  A2 B2 C2 D2 E2 F2 G2 H2
            //  A3 B3 C3 D3 E3 F3 G3 H3
            //  A4 B4 C4 D4 E4 F4 G4 H4
            //  A5 B5 C5 D5 E5 F5 G5 H5
            //  A6 B6 C6 D6 E6 F6 G6 H6
            //  A7 B7 C7 D7 E7 F7 G7 H7
        }

        /// <summary>
        /// Constructs a new instance of the SquareEightMatrix type.
        /// </summary>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public SquareEightMatrix(double coefficient)
            : base(8, coefficient)
        {
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public override ComputationalBasisState[] ApplyTo(Register register)
        {
            return ApplyTo(0, 1, 2, register);
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="control1">The first control qubit value.</param>
        /// <param name="control2">The second control qubit value.</param>
        /// <param name="target">The target control qubit value.</param>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public virtual ComputationalBasisState[] ApplyTo(int control1, int control2, int target, Register register)
        {
            Matrix matrix = new SquareMatrix((uint)(register.StateVector.Length), 0);

            for (uint i = 0; i < register.StateVector.Length; i++)
            {
                int iControl1 = -1;
                int iControl2 = -1;
                int iTarget = -1;
                string binaryIndex = register.StateVector[i].BinaryIndex;
                char[] binaryBits = binaryIndex.ToCharArray();

                if ((control1 < binaryBits.Length) && (control1 < binaryBits.Length) && (target < binaryBits.Length))
                {
                    iControl1 = ((int)(binaryBits[control1]) - 48);
                    iControl2 = ((int)(binaryBits[control2]) - 48);
                    iTarget = ((int)(binaryBits[target]) - 48);
                }

                if ((iControl1 == 1) && (iControl2 == 1) && (iTarget > -1) && (iTarget < binaryBits.Length))
                {
                    binaryBits[target] = GetValue(binaryBits[target]);
                }

                string newBinaryIndex = new string(binaryBits);
                uint column = newBinaryIndex.FromBase2();

                matrix[i, column] = 1;
            }

            return matrix * register;
        }

        /// <summary>
        /// Calculates the coefficient for a value. This is a gate specific operation.
        /// </summary>
        /// <param name="value">The value to calculate a coefficient for.</param>
        /// <returns>Returns a scalar coefficient value.</returns>
        protected virtual int GetCoefficient(char value)
        {
            return 1;
        }

        /// <summary>
        /// Calculates the value for a value. This is a gate specific operation.
        /// </summary>
        /// <param name="value">The value to base the operation from.</param>
        /// <returns>Returns a System.Char representing the result of the operation.</returns>
        protected virtual char GetValue(char value)
        {
            return value;
        }
    }
}
