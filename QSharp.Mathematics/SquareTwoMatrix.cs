#region Using References

using System;
using System.Numerics;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a square matrix, where the number of rows and the number of columns are equal to 2, used for single-qubit operations.
    /// </summary>
    public class SquareTwoMatrix : SquareMatrix
    {
        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0},{0, 0}}</param>
        /// <param name="b">The B element value: {{0, B},{0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0},{C, 0}}</param>
        /// <param name="d">The D element value: {{0, 0},{0, D}}</param>
        public SquareTwoMatrix(double a, double b, double c, double d)
            : this(a, b, c, d, 1)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0},{0, 0}}</param>
        /// <param name="b">The B element value: {{0, B},{0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0},{C, 0}}</param>
        /// <param name="d">The D element value: {{0, 0},{0, D}}</param>
        /// <param name="Coefficient">The matrix coefficient value.</param>
        public SquareTwoMatrix(double a, double b, double c, double d, double Coefficient)
            : this(new Complex(a, 0), new Complex(b, 0), new Complex(c, 0), new Complex(d, 0), Coefficient)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0},{0, 0}}</param>
        /// <param name="b">The B element value: {{0, B},{0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0},{C, 0}}</param>
        /// <param name="d">The D element value: {{0, 0},{0, D}}</param>
        public SquareTwoMatrix(Complex a, Complex b, Complex c, Complex d)
            : this(a, b, c, d, 1)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0},{0, 0}}</param>
        /// <param name="b">The B element value: {{0, B},{0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0},{C, 0}}</param>
        /// <param name="d">The D element value: {{0, 0},{0, D}}</param>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public SquareTwoMatrix(Complex a, Complex b, Complex c, Complex d, double coefficient)
            : base(2, coefficient)
        {
            this[0, 0] = a;
            this[0, 1] = b;
            this[1, 0] = c;
            this[1, 1] = d;
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public override ComputationalBasisState[] ApplyTo(Register register)
        {
            return ApplyTo(0, register);
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="index">The qubit index used in the operation.</param>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public virtual ComputationalBasisState[] ApplyTo(int index, Register register)
        {
            Matrix matrix = new SquareOneMatrix(1);

            for (int i = 0; i < register.Qubits.Length; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(this) : matrix.Tensor(new IdentityMatrix()));
            }

            return matrix * register;
        }
    }
}
