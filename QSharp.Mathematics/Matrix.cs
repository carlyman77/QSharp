#region Using References

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

using Maths = System.Math;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a matrix used in matrix algebra to manipulate against register.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Constructs a new instance of the Matrix type.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        public Matrix(uint rows, uint columns)
            : this(rows, columns, DefaultCoefficient, DefaultValue)
        {
        }

        /// <summary>
        /// Constructs a new instance of the Matrix type.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        /// <param name="coefficient">The matrix coefficient value.</param>
        public Matrix(uint rows, uint columns, double coefficient)
            : this(rows, columns, coefficient, DefaultValue)
        {
        }

        /// <summary>
        /// Constructs a new instance of the Matrix type.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        /// <param name="value">The default value of each matrix element.</param>
        public Matrix(uint rows, uint columns, int value)
            : this(rows, columns, DefaultCoefficient, value)
        {
        }

        /// <summary>
        /// Constructs a new instance of the Matrix type.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        /// <param name="coefficient">The matrix coefficient value.</param>
        /// <param name="value">The default value of each matrix element.</param>
        public Matrix(uint rows, uint columns, double coefficient, int value)
        {
            _columns = columns;
            _rows = rows;
            _coefficient = coefficient;
            _matrixMap = new Dictionary<MatrixCoordinate, Complex>();

            if (value != 0)
            {
                for (uint i = 0; i < _rows; i++)
                {
                    for (uint j = 0; j < _columns; j++)
                    {
                        _matrixMap.Add(new MatrixCoordinate(i, j), new Complex(value, 0));
                    }
                }
            }
        }

        /// <summary>
        /// The default matrix coefficient value.
        /// </summary>
        public const double DefaultCoefficient = 1.0;

        /// <summary>
        /// The default matrix element value.
        /// </summary>
        public const int DefaultValue = 0;

		internal const char One = '1';
		internal const char Zero = '0';

        private readonly double _coefficient;
        private readonly uint _columns;
        private readonly uint _rows;
        private Dictionary<MatrixCoordinate, Complex> _matrixMap;

        /// <summary>
        /// Gets the matrix coefficient value.
        /// </summary>
        public double Coefficient
        {
            get
            {
                return _coefficient;
            }
        }

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        public uint Columns
        {
            get
            {
                return _columns;
            }
        }

        /// <summary>
        /// Gets the number of rows.
        /// </summary>
        public uint Rows
        {
            get
            {
                return _rows;
            }
        }

        /// <summary>
        /// Gets the corresponding element from the matrix.
        /// </summary>
        /// <param name="row">The row of the element.</param>
        /// <param name="column">The column of the element.</param>
        /// <returns>Returns the System.Numerics.Complex value located at the corresponding element.</returns>
        public Complex this[uint row, uint column]
        {
            get
            {
                Complex complex = Complex.Zero;
                MatrixCoordinate matrixCoordinate = new MatrixCoordinate(row, column);

                if (_matrixMap.ContainsKey(matrixCoordinate) == true)
                {
                    complex = _matrixMap[matrixCoordinate];
                }
                
                return complex;
            }
            set
            {
				if (value != Complex.Zero)
				{
					_matrixMap[new MatrixCoordinate(row, column)] = value;
				}
            }
        }

        /// <summary>
        /// Applies the matrix to a register.
        /// </summary>
        /// <param name="register">The register to apply the matrix to.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public virtual ComputationalBasisState[] ApplyTo(Register register)
        {
            return new ComputationalBasisState[] { };
        }

        /// <summary>
        /// Performs a diagonal combine operation.
        /// </summary>
        /// <param name="value">The matrix to combine with.</param>
        /// <returns>Returns a matrix type representing the result of the operation.</returns>
        public Matrix Combine(Matrix value)
        {
            return Matrix.Combine(this, value);
        }

        /// <summary>
        /// Performs a diagonal combine operation.
        /// </summary>
        /// <param name="a">The Matrix to combine from.</param>
        /// <param name="b">The Matrix to combine with.</param>
        /// <returns>Returns a matrix type representing the result of the operation.</returns>
        public static Matrix Combine(Matrix a, Matrix b)
        {
            //  These matrices need to be the same size so they come out square
            if (a < b)
            {
                a = a.Tensor(new IdentityMatrix());
            }

            if (b < a)
            {
                b = b.Tensor(new IdentityMatrix());
            }

            uint rows = (a.Rows * 2);
            uint columns = (a.Columns * 2);

            Matrix combine = new Matrix(rows, columns);

            uint row = 0;
            uint column = 0;

            for (uint i = 0; i < a.Rows; i++)
            {
                column = 0;

                for (uint j = 0; j < a.Columns; j++)
                {
                    combine[row, column] = a[i, j];
                    column++;
                }

                row++;
            }

            for (uint i = 0; i < b.Rows; i++)
            {
                column = b.Columns;

                for (uint j = 0; j < b.Columns; j++)
                {
                    combine[row, column] = b[i, j];
                    column++;
                }

                row++;
            }

            return combine;
        }

        /// <summary>
        /// Determines object equality.
        /// </summary>
        /// <param name="value">The object to check against.</param>
        /// <returns>Returns true if the object's internals are the same, otherwise false.</returns>
        public override bool Equals(object value)
        {
            bool isEquals = false;
            Matrix matrixValue = value as Matrix;

            if (matrixValue != null)
            {
				isEquals = ((matrixValue._rows == this._rows) && (matrixValue._columns == this._columns) && (matrixValue._matrixMap.Count == this._matrixMap.Count));

				if (isEquals == true)
				{
					foreach (MatrixCoordinate oMatrixCoordinate in this._matrixMap.Keys)
					{
						isEquals = (this[oMatrixCoordinate.Row, oMatrixCoordinate.Column] == matrixValue[oMatrixCoordinate.Row, oMatrixCoordinate.Column]);

						if (isEquals == false)
						{
							break;
						}
					}
				}
            }

            return isEquals;
        }

        /// <summary>
        /// Generates a new instance of the Matrix type from a one-line notated matrix string, such as {{0, 1},{1, 0}}
        /// </summary>
        /// <param name="value">The string value containing a one-line notated matrix string, such as {{0, 1},{1, 0}}</param>
        /// <returns>Returns a new instance of the Matrix type, otherwise null.</returns>
        public static Matrix FromString(string value)
        {
            Matrix fromString = null;

            if (String.IsNullOrEmpty(value) == false)
            {
                //  {{0,1},{1,0}}
                //  {{1},{0}}
                //  {{0},{0}}

                string stringValue = value.Replace("{{", "").Replace("}}", "");
                uint rowCount = 0;
                uint columnCount = 0;

                string[] rows = stringValue.Split(new char[] { '}' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string stringRow in rows)
                {
                    string rowValue = stringRow.Replace("{", "").Replace("}", "");
                    if (rowValue.StartsWith(",") == true)
                    {
                        rowValue = rowValue.Substring(1);
                    }

                    if (columnCount == 0)
                    {
                        columnCount = Convert.ToUInt32(rowValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length);
                    }

                    rowCount++;
                }

                fromString = new Matrix(rowCount, columnCount);

                for (uint i = 0; i < rows.Length; i++)
                {
                    string rowValue = rows[i].Replace("{", "").Replace("}", "");
                    if (rowValue.StartsWith(",") == true)
                    {
                        rowValue = rowValue.Substring(1);
                    }

                    string[] columns = rowValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (uint j = 0; j < columns.Length; j++)
                    {
                        string sColumnValue = columns[j].ToLower();
                        double imaginaryValue = 0;

                        if (sColumnValue.Contains("i") == true)
                        {
                            imaginaryValue = 1;
                            sColumnValue = sColumnValue.Replace("i", "");

                            if (sColumnValue == "-")
                            {
                                sColumnValue = "-1";
                            }

                            if (String.IsNullOrEmpty(sColumnValue) == true)
                            {
                                sColumnValue = "1";
                            }
                        }

                        double dValue = Double.Parse(sColumnValue);
                        fromString[i, j] = new Complex(dValue, imaginaryValue);
                    }
                }
            }

            return fromString;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current type.</returns>
        public override int GetHashCode()
        {
            int getHashCode = _rows.GetHashCode() ^ _columns.GetHashCode() ^ _matrixMap.GetHashCode();

			foreach (MatrixCoordinate matrixCoordinate in this._matrixMap.Keys)
			{
				getHashCode = getHashCode ^ matrixCoordinate.Column.GetHashCode() ^ matrixCoordinate.Row.GetHashCode() ^ _matrixMap[matrixCoordinate].GetHashCode();
			}

            return getHashCode;
        }

        /// <summary>
        /// Halves a matrix.
        /// </summary>
        /// <returns>A new instance of the Matrix type, representing the result of the operation.</returns>
        public Matrix Halve()
        {
            return Halve(this);
        }

        /// <summary>
        /// Halves a matrix.
        /// </summary>
        /// <param name="value">The matrix type to perform the operation on.</param>
        /// <returns>Returns a new instance of the Matrix type, representing the result of the operation.</returns>
        public static Matrix Halve(Matrix value)
        {
            uint rows = (value.Rows / 2);
            uint columns = (value.Rows / 2);

            Matrix halve = new Matrix(rows, columns);

            for (uint i = 0; i < rows; i++)
            {
                for (uint j = 0; j < columns; j++)
                {
                    halve[i, j] = value[i, j];
                }
            }

            return halve;
        }

        /// <summary>
        /// Calculates if a matrix first quadrant contains non-zero elements.
        /// </summary>
        /// <returns>Returns true if the first quadrant contains only zero element, otherwise false.</returns>
        public bool IsFirstQuadrantEmpty()
        {
            bool isFirstQuadrantEmpty = true;

            for (uint i = 0; i < (_rows / 2); i++)
            {
                for (uint j = 0; j < (_columns / 2); j++)
                {
                   isFirstQuadrantEmpty = (this[i, j] == 0);

                    if (isFirstQuadrantEmpty == false)
                    {
                        i = (_rows + 1);
                        break;
                    }
                }
            }

            return isFirstQuadrantEmpty;
        }

        /// <summary>
        /// Calculates if a matrix identity elements contains non-zero elements.
        /// </summary>
        /// <returns>Returns true if the identity elements are zero-only elements, otherwise false.</returns>
        public bool IsIdentityEmpty()
        {
            bool isIdentityEmpty = true;

            for (uint i = 0; i < (_rows / 2); i++)
            {
                isIdentityEmpty = (this[i, i] == 0);

                if (isIdentityEmpty == false)
                {
                    i = (_rows + 1);
                    break;
                }
            }

            return isIdentityEmpty;
        }

        /// <summary>
        /// Manipulates an array of ComputationalBasisState types via matrix multiplication.
        /// </summary>
        /// <param name="stateVector">The array of ComputationalBasisState types to manipulate.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public ComputationalBasisState[] Multiply(ComputationalBasisState[] stateVector)
        {
            ComputationalBasisState[] computationalBasisStates = new ComputationalBasisState[_rows];
            Complex[] amplitudes = new Complex[_rows];
            
            for (uint i = 0; i < _rows; i++)
            {
                amplitudes[i] = stateVector[i].Amplitude;
            }

            for (uint i = 0; i < _rows; i++)
            {
                Complex rowAmplitude = 0;
				bool isIndex = false;
                uint index = 0;

                //  string sLabel = "";

                for (uint j = 0; j < _columns; j++)
                {
                    Complex amplitude = this[i, j];
                    Complex columnAmplitude = (amplitude.Real * amplitudes[j]);

                    if (amplitude.Imaginary != 0)
                    {
                        double dAmplitude = columnAmplitude.Real;
                        double imaginary = columnAmplitude.Imaginary;

                        if ((Maths.Abs(amplitude.Imaginary) == 1) && (Maths.Abs(columnAmplitude.Imaginary) == 1))
                        {
                            if (dAmplitude < 0)
                            {
                                dAmplitude *= -1;
                            }

                            imaginary = 0;
                        }
                        else
                        {
                            if (amplitude.Imaginary < 0)
                            {
                                dAmplitude *= amplitude.Imaginary;
                                imaginary = Maths.Pow(amplitude.Imaginary, 2);
                            }
                            else
                            {
                                imaginary = 1;
                            }
                        }

                        columnAmplitude = new Complex(dAmplitude, imaginary);
                    }

                    if ((columnAmplitude != 0) || (amplitude != 0))
                    {
						if ((isIndex == false) || (index < i))
                        {
                            index = j;
							isIndex = true;
                        }

						//	PRE UNSIGNED
						//	if ((iIndex == -1) || (iIndex < i))
						//	{
						//		iIndex = j;
						//	}

						//  if (String.IsNullOrEmpty(sLabel) == true)
						//  {
						//      sLabel = StateVector[j].AlgebraicValue;
						//  }
						//  else
						//  {
						//      sLabel = String.Format("{0} {1} {2}", sLabel, ((oColumnAmplitude.Real > 0) ? "+" : "-"), StateVector[j].AlgebraicValue);
						//  }
					}

                    rowAmplitude += columnAmplitude;
                }

                computationalBasisStates[i] = stateVector[index];
                computationalBasisStates[i].Amplitude = (rowAmplitude * _coefficient);
                computationalBasisStates[i].Index = i;
            }

            return computationalBasisStates;
        }

        /// <summary>
        /// Reflects a matrix.
        /// </summary>
        /// <returns>Returns a the current matrix type, representing the result of the operation.</returns>
        public Matrix Reflect()
        {
			if (_matrixMap.Count > 0)
			{
				Dictionary<MatrixCoordinate, Complex> newMatrixMap = new Dictionary<MatrixCoordinate, Complex>();

				foreach (MatrixCoordinate matrixCoordinate in _matrixMap.Keys)
				{
					newMatrixMap.Add(new MatrixCoordinate((_rows - (matrixCoordinate.Row + 1)), matrixCoordinate.Column), _matrixMap[matrixCoordinate]);
				}

				_matrixMap = newMatrixMap;
			}

			return this;
        }

        /// <summary>
        /// Produces a tensor product using this matrix as the left value, and the supplied value as the right value.
        /// </summary>
        /// <param name="matrix">The right matrix, tensor multiplied into every 1 position</param>
        /// <returns>Returns a new instance of the Matrix type representing the result of the operation, otherwise null.</returns>
        public Matrix Tensor(Matrix matrix)
        {
			//  X = {{0,1},{1,0}}
			//  I = {{1,0},{0,1}}

			//  0     1     2
			//  I (x) X (x) I
			//  (I (x) X) (x) I

			//  If there is a matrix on the left, then move to that.
			//  If there is a matrix on the right, then tensor with that

			//  0   1   2
			//  I   X   I
			//  Move to 1
			//  Tensor with 0

			//  0   1
			//  IX  I
			//  Move to 1
			//  Tensor with 0

			//  Matrix  =   Left
			//  this    =   Right

			//  Stopwatch stopwatch = Stopwatch.StartNew();

			Matrix tensor = new Matrix((matrix.Rows * _rows), (matrix.Columns * _columns), (this.Coefficient * matrix.Coefficient));

			foreach (MatrixCoordinate matrixCoordinate in this._matrixMap.Keys)
			{
				Complex value = this._matrixMap[matrixCoordinate];
				uint beginRow = matrixCoordinate.Row * (tensor.Rows / _rows);
				uint beginColumn = matrixCoordinate.Column * (tensor.Columns / _columns);

				foreach (MatrixCoordinate childMatrixCoordinate in matrix._matrixMap.Keys)
				{
					Complex childValue = matrix._matrixMap[childMatrixCoordinate];

					tensor[(beginRow + childMatrixCoordinate.Row), (beginColumn + childMatrixCoordinate.Column)] = (value * childValue);
				}
			}

			//  Console.WriteLine($"Execution time = {stopwatch.Elapsed.TotalSeconds} seconds");

			return tensor;
        }

        /// <summary>
        /// Converts this type into its corresponding string representation.
        /// </summary>
        /// <returns>Returns a string representation of the matrix internals.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            if ((_rows > 0) && (_columns > 0))
            {
                stringBuilder.AppendLine();

                for (uint i = 0; i < _rows; i++)
                {
                    stringBuilder.Append("{");
                    
                    for (uint j = 0; j < _columns; j++)
                    {
                        if (this[i, j].Imaginary != 0)
                        {
							if (this[i, j].Imaginary < 0)
							{
								stringBuilder.Append("-i");
							}
							else
							{
								if (j > 0)
								{
									stringBuilder.Append(" ");
								}

								stringBuilder.Append("i");
							}
                        }

                        if (this[i, j].Imaginary == 0)
                        {
                            if ((j > 0) && (this[i, j].Real >= 0.0))
                            {
                                stringBuilder.Append(" ");
                            }

                            stringBuilder.Append(this[i, j].Real.ToString());
                        }

                        if (j < (_columns - 1))
                        {
                            stringBuilder.Append(",");
                        }
                    }

                    stringBuilder.Append("}");

                    if (i < (_rows - 1))
                    {
                        stringBuilder.Append(",");
                    }

                    stringBuilder.AppendLine();
                }
            }

            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Multiplies matrix and register terms, producing a product of an array of ComputationalBasisState types.
        /// </summary>
        /// <param name="matrix">The matrix type value.</param>
        /// <param name="register">The register type value.</param>
        /// <returns>Returns an array of ComputationalBasisState representing the result of the operation.</returns>
        public static ComputationalBasisState[] operator *(Matrix matrix, Register register)
        {
            return matrix.Multiply(register.StateVector);
        }

        /// <summary>
        /// Multiplies two matrix terms, producing a product of a new matrix.
        /// </summary>
        /// <param name="a">The left matrix term.</param>
        /// <param name="b">The right matrix term.</param>
        /// <returns>Returns a new instance of the Matrix type representing the result of the operation, otherwise null.</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix multiply = null;

            //  {n x m} * {m x p} = {n * p}
            //  [3 x 2] * [2 * 3]
            //     = [2 x 2]

            //    {{1,2,3},{4,5,6}} * {{7,8},{9,10},{11,12}}

            //  {           {
            //  {1,2,3},    { 7, 8},
            //  {4,5,6}     { 9,10},
            //  }           {11,12}
            //              }

            //  ([0,0] * [0,0]) + ([0,1] * [1,0]) + ([0,2] + [2,0]) i = 0
            //  ([1,0] * [1,0]) + ([1,1] * [1,1]) + ([1,2] + [2,1]) i = 1

            //  (1 * 7) + (2 *  9) + (3 * 11)
            //  (4 * 8) + (5 * 10) + (5 * 12)

            //  {{0,-1, 2},{4,11,2}} * {{3,-1},{1,2},{6,1}}

            //  [Row,Column]

            //  {
            //  {0,-1, 2},  [0,0],[0,1],[0,2]
            //  {4,11, 2}   [1,0],[1,1],[1,2]
            //  }

            //  {
            //  {3,-1},     [0,0],[0,1]
            //  {1, 2},     [1,0],[1,1]
            //  {6, 1}      [2,0],[2,1[
            //  }

            //  {
            //  {A,B},
            //  {C,D},
            //  }

            //  A = (0 *  3) + (-1 * 1) + (2 * 6)
            //  B = (0 * -1) + (-1 * 2) + (2 * 1)
            //  C = (4 *  3) + (11 * 1) + (2 * 6)
            //  D = (4 * -1) + (11 * 2) + (2 * 1)


            if ((a.Columns == b.Rows))
            {
                multiply = new Matrix(a.Rows, b.Columns);

                for (uint row = 0; row < multiply._rows; row++)
                {
                    for (uint column = 0; column < multiply._columns; column++)
                    {
                        for (uint i = 0; i < a.Columns; i++)
                        {
                            multiply[row, column] += (a[row, i] * b[i, column]);
                        }
                    }
                }
            }

            return multiply;
        }

        /// <summary>
        /// Adds two matrices together.
        /// </summary>
        /// <param name="a">The left matrix term to add.</param>
        /// <param name="b">The right matrix term to add.</param>
        /// <returns>Returns a new instance of the Matrix type representing the result of the operation, otherwise null.</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix multiply = null;

            if ((a.Rows == b.Rows) && (a.Columns == b.Columns))
            {
                multiply = new Matrix(a.Rows, a.Columns);

                for (uint i = 0; i < multiply._rows; i++)
                {
                    for (uint j = 0; j < multiply._rows; j++)
                    {
                        multiply[i, j] = (a[i, j] + b[i, j]);
                    }
                }
            }

            return multiply;
        }

        /// <summary>
        /// Determines whether one matrix is less than another.
        /// </summary>
        /// <param name="a">The left matrix value.</param>
        /// <param name="b">The right matrix value.</param>
        /// <returns>Returns true of the number of rows and the number of columns in the left matrix are less than those in the right matrix.</returns>
        public static bool operator <(Matrix a, Matrix b)
        {
            bool isLessThan = false;

            if ((a != null) && (b != null))
            {
                isLessThan = ((a.Rows < b.Rows) && (a.Columns < b.Columns));
            }

            return isLessThan;
        }

        /// <summary>
        /// Determines whether one matrix is greater than another.
        /// </summary>
        /// <param name="a">The left matrix value.</param>
        /// <param name="b">The right matrix value.</param>
        /// <returns>Returns true of the number of rows and the number of columns in the left matrix are greater than those in the right matrix.</returns>
        public static bool operator >(Matrix a, Matrix b)
        {
            bool isGreaterThan = false;

            if ((a != null) && (b != null))
            {
                isGreaterThan = ((a.Rows > b.Rows) && (a.Columns > b.Columns));
            }

            return isGreaterThan;
        }
    }
}
