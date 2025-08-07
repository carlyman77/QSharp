#region Using References

using System;

using QSharp.Mathematics.Commands;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a factory type that creates new instances of Matrix derived types.
    /// </summary>
    public static class GateFactory
    {
        /// <summary>
        /// Constructs a new instance of a Matrix derived type.
        /// </summary>
        /// <param name="value">The corresponding string value of the Matrix type to create.</param>
        /// <returns>Returns a newly constructed Matrix type for a matching string value, otherwise null.</returns>
        public static Matrix FromString(string value)
        {
            Matrix fromString = null;

            switch (value.ToUpper())
            {
                case CNotCommand.CNot:
                    fromString = new CNotGate();
                    break;

                case CZCommand.CZ:
                    fromString = new CZGate();
                    break;

                case "F":
                case CSwapCommand.CSwap:
                    fromString = new CSwapGate();
                    break;

                case "H":
                case HadamardCommand.Hadamard:
                    fromString = new HadamardGate();
                    break;

                case IdentityCommand.Identity:
                    fromString = new IdentityMatrix();
                    break;

                case PauliXCommand.PauliX:
                    fromString = new PauliXGate();
                    break;

                case PauliYCommand.PauliY:
                    fromString = new PauliYGate();
                    break;

                case PauliZCommand.PauliZ:
                    fromString = new PauliZGate();
                    break;

                case "S":
                case SwapCommand.Swap:
                    fromString = new SwapGate();
                    break;

                case ToffoliCommand.Toffoli:
                    fromString = new ToffoliGate();
                    break;
            }

            return fromString;
        }

        /// <summary>
        /// Constructs a new instance of a CNotGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct CNotGate type.</returns>
        public static CNotGate NewCNotGate()
        {
            return new CNotGate();
        }

        /// <summary>
        /// Constructs a new instance of a CZGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct CZGate type.</returns>
        public static CZGate NewCZGate()
        {
            return new CZGate();
        }

        /// <summary>
        /// Constructs a new instance of a FredkinGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct ToffoliGate type.</returns>
        public static CSwapGate NewFredkinGate()
        {
            return new CSwapGate();
        }

        /// <summary>
        /// Constructs a new instance of a HadamardGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct HadamardGate type.</returns>
        public static HadamardGate NewHadamardGate()
        {
            return new HadamardGate();
        }

        /// <summary>
        /// Constructs a new instance of a IdentityMatrix type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct IdentityMatrix type.</returns>
        public static IdentityMatrix NewIdentityMatrix()
        {
            return new IdentityMatrix();
        }

        /// <summary>
        /// Constructs a new instance of a PauliXGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct PauliXGate type.</returns>
        public static PauliXGate NewPauliXGate()
        {
            return new PauliXGate();
        }

        /// <summary>
        /// Constructs a new instance of a PauliYGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct PauliYGate type.</returns>
        public static PauliYGate NewPauliYGate()
        {
            return new PauliYGate();
        }

        /// <summary>
        /// Constructs a new instance of a PauliZGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct PauliZGate type.</returns>
        public static PauliZGate NewPauliZGate()
        {
            return new PauliZGate();
        }

        /// <summary>
        /// Constructs a new instance of a SwapGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct SwapGate type.</returns>
        public static SwapGate NewSwapGate()
        {
            return new SwapGate();

        }

        /// <summary>
        /// Constructs a new instance of a ToffoliGate type.
        /// </summary>
        /// <returns>Returns an instance of a newly construct ToffoliGate type.</returns>
        public static ToffoliGate NewToffoliGate()
        {
            return new ToffoliGate();
        }
    }
}