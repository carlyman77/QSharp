#region Using References

using System;
using System.Numerics;
using System.Text;

using QSharp.Mathematics.Extensions;

using Maths = System.Math;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a computational basis state element of a state vector, used to describe entanglement, amplitudes etc.
    /// </summary>
    public class ComputationalBasisState
    {
        /// <summary>
        /// Constructs a new instance of the ComputationalBasisState type.
        /// </summary>
        /// <param name="register">The register this element participates in.</param>
        /// <param name="index">The index of the element.</param>
        public ComputationalBasisState(Register register, uint index)
            : this(register, 1.0, index)
        {
        }

        /// <summary>
        /// Constructs a new instance of the ComputationalBasisState type.
        /// </summary>
        /// <param name="Register">The register this element participates in.</param>
        /// <param name="Value">The complex amplitude value.</param>
        /// <param name="Index">The index of the element.</param>
        public ComputationalBasisState(Register Register, Complex Value, uint Index)
        {
            _amplitude = Value;
            _register = Register;
            _index = Index;
            _binaryIndex = _index.ToBase2(Register.Qubits.Length);

            for (int i = 0; i < Register.Qubits.Length; i++)
            {
                if (_binaryIndex[i] == Matrix.Zero)
                {
                    _algebraicValue += Register.Qubits[i].AlphaLabel;
                    _amplitude *= Register.Qubits[i].Alpha;
                }
                else
                {
                    _algebraicValue += Register.Qubits[i].BetaLabel;
                    _amplitude *= Register.Qubits[i].Beta;
                }
            }
        }

        private readonly string _algebraicValue;
        private Complex _amplitude;
        private string _binaryIndex;
        private uint _index;
        private readonly Register _register;

        /// <summary>
        /// Gets the algebraic value.
        /// </summary>
        public string AlgebraicValue
        {
            get
            {
                return _algebraicValue;
            }
        }

        /// <summary>
        /// Gets or sets the complex amplitude value.
        /// </summary>
        public Complex Amplitude
        {
            get
            {
                return _amplitude;
            }
            set
            {
                _amplitude = value;
            }
        }

        /// <summary>
        /// Gets the binary index value.
        /// </summary>
        public string BinaryIndex
        {
            get
            {
                return _binaryIndex;
            }
        }

        /// <summary>
        /// Gets or sets the index value.
        /// </summary>
        public uint Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                _binaryIndex = _index.ToBase2(_register.Qubits.Length);
            }
        }

        /// <summary>
        /// Determines object equality.
        /// </summary>
        /// <param name="value">The object to check against.</param>
        /// <returns>Returns true if the object's internals are the same, otherwise false.</returns>
        public override bool Equals(object value)
        {
            bool isEquals = false;
            ComputationalBasisState computationalBasisState = value as ComputationalBasisState;

            if (computationalBasisState != null)
            {
                isEquals =
                (
                    (computationalBasisState._index == _index) &&
                    (computationalBasisState._amplitude == _amplitude) &&
                    (computationalBasisState._binaryIndex == _binaryIndex) &&
                    (computationalBasisState._algebraicValue == _algebraicValue)
                );
            }

            return isEquals;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current type.</returns>
        public override int GetHashCode()
        {
            return _index.GetHashCode() ^ _amplitude.GetHashCode() ^ _binaryIndex.GetHashCode() ^ _algebraicValue.GetHashCode();
        }

        /// <summary>
        /// Converts this type into its corresponding string representation.
        /// </summary>
        /// <returns>Returns a string representation of the computational basis state internals.</returns>
        public override string ToString()
        {
            return ToString(true, true);
        }

        /// <summary>
        /// Converts this type into its corresponding string representation.
        /// </summary>
        /// <param name="isShowAlgebraicValues">Specifies whether to display algebraic values.</param>
        /// <param name="isShowCoefficientValues">Specifies whether to display coefficient values.</param>
        /// <returns>Returns a string representation of the computational basis state internals.</returns>
        public string ToString(bool isShowAlgebraicValues, bool isShowCoefficientValues)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (_amplitude.Real < 0)
            {
                stringBuilder.Append("-");
            }

            if (_amplitude.Imaginary != 0)
            {
                stringBuilder.AppendFormat("{0}i", ((_amplitude.Imaginary < 0) ? "-" : ""));
            }

            if (isShowCoefficientValues == true)
            {
                if (_amplitude.Real != 0)
                {
                    stringBuilder.Append(Maths.Abs(_amplitude.Real).ToString("0.000"));
                }
            }

            if (isShowAlgebraicValues == true)
            {
                if (isShowCoefficientValues == true)
                {
                    stringBuilder.Append(" ");
                }

                stringBuilder.Append(_algebraicValue);
            }


            stringBuilder.AppendFormat("|{0}>", _binaryIndex);

            return stringBuilder.ToString();
        }
    }
}
