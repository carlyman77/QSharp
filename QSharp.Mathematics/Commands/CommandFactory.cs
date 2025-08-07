#region Using References

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a factory type that creates new instances of Command derived types.
    /// </summary>
    public static class CommandFactory
    {
        static CommandFactory()
        {
            _registeredCommands = new List<Command>();
        }

        private static List<Command> _registeredCommands;

        /// <summary>
        /// Constructs a new instance of a Command derived type.
        /// </summary>
        /// <param name="value">The corresponding string value of the Command type to create.</param>
        /// <returns>Returns a newly constructed Command type for a matching string value, otherwise null.</returns>
        public static Command FromString(string value)
        {
            Command fromString = null;

            if (String.IsNullOrEmpty(value) == false)
            {
                string sValue = value.ToUpper();

                switch (sValue)
                {
                    case CNotCommand.CNot:
                        fromString = new CNotCommand();
                        break;

                    case CombineCommand.Combine:
                        fromString = new CombineCommand();
                        break;

                    case CZCommand.CZ:
                        fromString = new CZCommand();
                        break;

                    case ExplainCommand.Explain:
                        fromString = new ExplainCommand();
                        break;

                    case CSwapCommand.CSwap:
                    case "F":
                        fromString = new CSwapCommand();
                        break;

                    case "H":
                    case HadamardCommand.Hadamard:
                        fromString = new HadamardCommand();
                        break;

                    case IdentityCommand.Identity:
                        fromString = new IdentityCommand();
                        break;

                    case InitialiseCommand.Initialise:
                        fromString = new InitialiseCommand();
                        break;

                    case MeasureCommand.Measure:
                        fromString = new MeasureCommand();
                        break;

                    case NormaliseCommand.Normalise:
                        fromString = new NormaliseCommand();
                        break;

                    case PauliXCommand.PauliX:
                        fromString = new PauliXCommand();
                        break;

                    case PauliYCommand.PauliY:
                        fromString = new PauliYCommand();
                        break;

                    case PauliZCommand.PauliZ:
                        fromString = new PauliZCommand();
                        break;

                    case PrintCommand.Print:
                        fromString = new PrintCommand();
                        break;

                    case "S":
                    case SwapCommand.Swap:
                        fromString = new SwapCommand();
                        break;

                    case TensorCommand.Tensor:
                        fromString = new TensorCommand();
                        break;

                    case ToffoliCommand.Toffoli:
                        fromString = new ToffoliCommand();
                        break;

                    default:
                        fromString = _registeredCommands
                            .Where(m => ((m.ShortHand.ToUpper() == sValue) || (m.Value.ToUpper() == sValue)))
                            .SingleOrDefault();
                        break;
                }
            }

            return fromString;
        }

        /// <summary>
        /// Registers a Command type with the factory.
        /// </summary>
        /// <param name="command">The Command type to register.</param>
        public static void Register(Command command)
        {
            if (_registeredCommands.Contains(command) == false)
            {
                _registeredCommands.Add(command);
            }
        }
    }
}