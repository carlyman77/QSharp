#region Using References

using System;
using System.Numerics;
using System.Text;

using Maths = System.Math;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a quantum bit type.
    /// </summary>
    public class Qubit
    {
        /// <summary>
        /// Constructs a new instance of the Qubit type.
        /// </summary>
        public Qubit()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Constructs a new instance of the Qubit type.
        /// </summary>
        /// <param name="a">The |0&gt; value.</param>
        /// <param name="b">The |1&gt; value.</param>
        public Qubit(double a, double b)
            : this(a, 0, b, 0)
        {
        }

        /// <summary>
        /// 
        /// Constructs a new instance of the Qubit type.
        /// </summary>
        /// <param name="a">The |0&gt; real value.</param>
        /// <param name="bi">The |0&gt; imaginary value.</param>
        /// <param name="c">The |1&gt; real value.</param>
        /// <param name="di">The |1&gt; imaginary value.</param>
        public Qubit(double a, double bi, double c, double di)
            : this(new Complex(a, bi), new Complex(c, di))
        {
        }

        /// <summary>
        /// Constructs a new instance of the Qubit type.
        /// </summary>
        /// <param name="alpha">The |0&gt; complex value.</param>
        /// <param name="beta">The |1&gt; complex value.</param>
        public Qubit(Complex alpha, Complex beta)
        {
            _alpha = alpha;
            _beta = beta;

            _alphaLabel = GetNextLabel();
            _betaLabel = GetNextLabel();
        }

        private Complex _alpha;
        private string _alphaLabel;
        private Complex _beta;
        private string _betaLabel;
        private static int _counter;
        private static Random _random;

        /// <summary>
        /// Gets the |0&gt; real value.
        /// </summary>
        public double A
        {
            get
            {
                return _alpha.Real;
            }
        }

        /// <summary>
        /// Gets or sets the |0&gt; complex value.
        /// </summary>
        public Complex Alpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                _alpha = value;
            }
        }

        /// <summary>
        /// Gets or sets the |0&gt; label.
        /// </summary>
        public string AlphaLabel
        {
            get
            {
                return _alphaLabel;
            }
            set
            {
                _alphaLabel = value;
            }
        }

        /// <summary>
        /// Gets or sets the |1&gt; complex value.
        /// </summary>
        public Complex Beta
        {
            get
            {
                return _beta;
            }
            set
            {
                _beta = value;
            }
        }

        /// <summary>
        /// Gets the |1&gt; label.
        /// </summary>
        public string BetaLabel
        {
            get
            {
                return _betaLabel;
            }
            set
            {
                _betaLabel = value;
            }
        }

        /// <summary>
        /// Gets the |0&gt; imaginary value.
        /// </summary>
        public double BI
        {
            get
            {
                return _alpha.Imaginary;
            }
        }

        /// <summary>
        /// Gets the |1&gt; real value.
        /// </summary>
        public double C
        {
            get
            {
                return _beta.Real;
            }
        }

        /// <summary>
        /// Gets the |1&gt; imaginary value.
        /// </summary>
        public double DI
        {
            get
            {
                return _beta.Imaginary;
            }
        }

		/// <summary>
		/// Gets the next label value in the sequence.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>Returns a string representing the result of the operation</returns>
		public static string GetLabel(int value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			int iValue = value;

			do
			{
				int remainder = (iValue % 26);

				if (remainder == 0)
				{
					iValue = iValue / 26 - 1;
					//	remainder = 26;
				}
				else
				{
					iValue /= 26;
				}

				stringBuilder.Append((char)(remainder + 65));
			}
			while (iValue > 0);

			return stringBuilder.ToString();
		}

		/// <summary>
		/// Gets the next label value in the sequence.
		/// </summary>
		/// <returns>Returns a string representing the result of the operation</returns>
		public static string GetNextLabel()
        {
			return GetLabel(_counter++);
		}

		/// <summary>
		/// Gets a new qubit instance where |0&gt; = 1 and |1&gt; = 1.
		/// </summary>
		/// <returns>Returns a new instance of the Qubit type.</returns>
		public static Qubit OneValueQubit()
        {
            return new Qubit(1, 1);
        }

        /// <summary>
        /// Gets a new qubit instance where |0&gt; and |1&gt; values are random complex numbers between 0.0 and 1.0.
        /// </summary>
        /// <returns>Returns a new instance of the Qubit type.</returns>
        public static Qubit RandomQubit()
        {
            //  |a^2|+|b^2| = 1
            if (_random == null)
            {
                _random = new Random();
            }

            double alpha = _random.NextDouble();
            double beta = 1 - alpha;

            //  a = 0.8 => 0.64
            //  b = 0.6 => 0.36

            alpha = Maths.Sqrt(alpha);
            beta = Maths.Sqrt(beta);

            return new Qubit(new Complex(alpha, 0), new Complex(beta, 0));
        }

        /// <summary>
        /// Gets an array of new qubit instances where each |0&gt; and |1&gt; values are random complex numbers between 0.0 and 1.0.
        /// </summary>
        /// <param name="count">The number of qubits to create.</param>
        /// <returns>Returns an array of new instances of the Qubit type representing the result of the operation.</returns>
        public static Qubit[] RandomQubits(int count)
        {
            Qubit[] randomQubits = new Qubit[count];

            for (int i = 0; i < count; i++)
            {
                randomQubits[i] = RandomQubit();
            }

            return randomQubits;
        }

        internal static void ResetCounters()
        {
            _counter = 0;
        }

        /// <summary>
        /// Gets a new qubit instance where |0&gt; = 0 and |1&gt; = 0.
        /// </summary>
        /// <returns>Returns a new instance of the Qubit type representing the result of the operation.</returns>
        public static Qubit ZeroValueQubit()
        {
            return new Qubit(0, 0);
        }

        /// <summary>
        /// Converts this type into its corresponding string representation.
        /// </summary>
        /// <returns>Returns a string representation of the matrix internals.</returns>
        public override string ToString()
        {
            string toString = "";

            if ((_alpha.Imaginary == 0) && (_beta.Imaginary == 0))
            {
                toString = String.Format("{{{{{0}}}, {{{1}}}}}", _alpha.Real.ToString("0.000"), _beta.Real.ToString("0.000"));
            }
            else
            {
                string sAlpha = "";
                if (_alpha.Imaginary == 1)
                {
                    sAlpha = String.Format("{0}i", _alpha.Real.ToString("0.###"));
                }
                else
                {
                    sAlpha = String.Format("({0}, {1})", _alpha.Real.ToString("0.###"), _alpha.Imaginary.ToString("0.###"));
                }

                string sBeta = "";
                if (_beta.Imaginary == 1)
                {
                    sBeta = String.Format("{0}i", _beta.Real.ToString("0.###"));
                }
                else
                {
                    sBeta = String.Format("({0}, {1})", _beta.Real.ToString("0.###"), _beta.Imaginary.ToString("0.###"));
                }

                toString = String.Format("{{{{{0}}}, {{{1}}}}}", sAlpha, sBeta);
            }

            return toString;
        }

        /// <summary>
        /// Multiplies a qubit |0&gt; |1&gt; values by the supplied and scalar term, producing a product of a new Qubit type.
        /// </summary>
        /// <param name="qubit">The qubit type value.</param>
        /// <param name="value">The scalar coefficient value.</param>
        /// <returns>Returns a new instance of the Qubit type representing the result of the operation.</returns>
        public static Qubit operator *(Qubit qubit, double value)
        {
            return new Qubit((qubit.Alpha * value), (qubit.Beta * value));
        }

        /// <summary>
        /// Multiplies a qubit |0&gt; |1&gt; values by the supplied and scalar term, producing a product of a new Qubit type.
        /// </summary>
        /// <param name="qubit">The qubit type value.</param>
        /// <param name="value">The scalar coefficient value.</param>
        /// <returns>Returns a new instance of the Qubit type representing the result of the operation.</returns>
        public static Qubit operator *(Qubit qubit, int value)
        {
            return (qubit * (double)(value));
        }
    }
}