#region Using References

using System;
using System.Numerics;

using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a square matrix, where the number of rows and the number of columns are equal to 4, used for double-qubit operations.
    /// </summary>
    public class SquareFourMatrix : SquareMatrix
    {
        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="b">The B element value: {{0, 0, 0, 0},{0, B, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0, C, 0},{0, 0, 0, 0},{0, 0, C, 0},{0, 0, 0, 0}}</param>
        /// <param name="d">The D element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, D}}</param>
        /// <param name="e">The E element value: {{E, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="f">The F element value: {{0, 0, 0, 0},{0, F, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="g">The G element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, G, 0},{0, 0, 0, 0}}</param>
        /// <param name="h">The H element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, H}}</param>
        /// <param name="i">The I element value: {{I, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="j">The J element value: {{0, 0, 0, 0},{0, J, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="k">The K element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, K, 0},{0, 0, 0, 0}}</param>
        /// <param name="l">The L element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, )},{0, 0, 0, L}}</param>
        /// <param name="m">The M element value: {{M, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="n">The N element value: {{0, 0, 0, 0},{0, N, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="o">The O element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, O, 0},{0, 0, 0, 0}}</param>
        /// <param name="p">The P element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, P}}</param>
        public SquareFourMatrix(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m, double n, double o, double p)
            : this(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, 1)
        {
            //  A B C D
            //  E F G H
            //  I J K L
            //  M N O P
        }

        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="b">The B element value: {{0, 0, 0, 0},{0, B, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0, C, 0},{0, 0, 0, 0},{0, 0, C, 0},{0, 0, 0, 0}}</param>
        /// <param name="d">The D element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, D}}</param>
        /// <param name="e">The E element value: {{E, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="f">The F element value: {{0, 0, 0, 0},{0, F, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="g">The G element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, G, 0},{0, 0, 0, 0}}</param>
        /// <param name="h">The H element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, H}}</param>
        /// <param name="i">The I element value: {{I, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="j">The J element value: {{0, 0, 0, 0},{0, J, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="k">The K element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, K, 0},{0, 0, 0, 0}}</param>
        /// <param name="l">The L element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, )},{0, 0, 0, L}}</param>
        /// <param name="m">The M element value: {{M, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="n">The N element value: {{0, 0, 0, 0},{0, N, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="o">The O element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, O, 0},{0, 0, 0, 0}}</param>
        /// <param name="p">The P element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, P}}</param>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public SquareFourMatrix(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m, double n, double o, double p, double coefficient)
            : this(
                new Complex(a, 0), new Complex(b, 0), new Complex(c, 0), new Complex(d, 0),
                new Complex(e, 0), new Complex(f, 0), new Complex(g, 0), new Complex(h, 0),
                new Complex(i, 0), new Complex(j, 0), new Complex(k, 0), new Complex(l, 0),
                new Complex(m, 0), new Complex(n, 0), new Complex(o, 0), new Complex(p, 0),
                coefficient)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="b">The B element value: {{0, 0, 0, 0},{0, B, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0, C, 0},{0, 0, 0, 0},{0, 0, C, 0},{0, 0, 0, 0}}</param>
        /// <param name="d">The D element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, D}}</param>
        /// <param name="e">The E element value: {{E, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="f">The F element value: {{0, 0, 0, 0},{0, F, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="g">The G element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, G, 0},{0, 0, 0, 0}}</param>
        /// <param name="h">The H element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, H}}</param>
        /// <param name="i">The I element value: {{I, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="j">The J element value: {{0, 0, 0, 0},{0, J, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="k">The K element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, K, 0},{0, 0, 0, 0}}</param>
        /// <param name="l">The L element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, )},{0, 0, 0, L}}</param>
        /// <param name="m">The M element value: {{M, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="n">The N element value: {{0, 0, 0, 0},{0, N, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="o">The O element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, O, 0},{0, 0, 0, 0}}</param>
        /// <param name="p">The P element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, P}}</param>
        public SquareFourMatrix(Complex a, Complex b, Complex c, Complex d, Complex e, Complex f, Complex g, Complex h, Complex i, Complex j, Complex k, Complex l, Complex m, Complex n, Complex o, Complex p)
            : this(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, 1)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SquareTwoMatrix type.
        /// </summary>
        /// <param name="a">The A element value: {{A, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="b">The B element value: {{0, 0, 0, 0},{0, B, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="c">The C element value: {{0, 0, C, 0},{0, 0, 0, 0},{0, 0, C, 0},{0, 0, 0, 0}}</param>
        /// <param name="d">The D element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, D}}</param>
        /// <param name="e">The E element value: {{E, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="f">The F element value: {{0, 0, 0, 0},{0, F, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="g">The G element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, G, 0},{0, 0, 0, 0}}</param>
        /// <param name="h">The H element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, H}}</param>
        /// <param name="i">The I element value: {{I, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="j">The J element value: {{0, 0, 0, 0},{0, J, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="k">The K element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, K, 0},{0, 0, 0, 0}}</param>
        /// <param name="l">The L element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, )},{0, 0, 0, L}}</param>
        /// <param name="m">The M element value: {{M, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="n">The N element value: {{0, 0, 0, 0},{0, N, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0}}</param>
        /// <param name="o">The O element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, O, 0},{0, 0, 0, 0}}</param>
        /// <param name="p">The P element value: {{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, 0},{0, 0, 0, P}}</param>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public SquareFourMatrix(Complex a, Complex b, Complex c, Complex d, Complex e, Complex f, Complex g, Complex h, Complex i, Complex j, Complex k, Complex l, Complex m, Complex n, Complex o, Complex p, double coefficient)
            : base(4, coefficient)
        {
            this[0, 0] = a;
            this[0, 1] = b;
            this[0, 2] = c;
            this[0, 3] = d;
            this[1, 0] = e;
            this[1, 1] = f;
            this[1, 2] = g;
            this[1, 3] = h;
            this[2, 0] = i;
            this[2, 1] = j;
            this[2, 2] = k;
            this[2, 3] = l;
            this[3, 0] = m;
            this[3, 1] = n;
            this[3, 2] = o;
            this[3, 3] = p;
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public override ComputationalBasisState[] ApplyTo(Register register)
        {
            return ApplyTo(0, 1, register);
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="control">The control qubit value.</param>
        /// <param name="target">The target qubit value.</param>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public virtual ComputationalBasisState[] ApplyTo(int control, int target, Register register)
        {
            Matrix matrix = new SquareMatrix((uint)(register.StateVector.Length), 0);

            //  Work out what happened, then construct the matrix
            for (uint i = 0; i < register.StateVector.Length; i++)
            {
                int iControl = -1;
                int iTarget = -1;
                string binaryIndex = register.StateVector[i].BinaryIndex;
                char[] binaryBits = binaryIndex.ToCharArray();

                if ((control < binaryBits.Length) && (target < binaryBits.Length))
                {
                    iControl = ((int)(binaryBits[control]) - 48);
                    iTarget = ((int)(binaryBits[target]) - 48);
                }

                double coefficient = 1;

                if ((iControl == 1) && (iTarget > -1) && (iTarget < binaryBits.Length))
                {
                    binaryBits[target] = GetValue(binaryBits[target]);
                    coefficient = GetCoefficient(binaryBits[target]);
                }

                string newBinaryIndex = new string(binaryBits);
                uint column = newBinaryIndex.FromBase2();

                matrix[i, column] = (1 * coefficient);
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