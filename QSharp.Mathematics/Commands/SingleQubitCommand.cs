#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a single-qubit command that may be executed against a Register.
    /// </summary>
    public class SingleQubitCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the SingleQubitCommand type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        protected SingleQubitCommand(string commandValue)
            : base(commandValue)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SingleQubitCommand type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        /// <param name="shortHand">The text short-hand version of the command.
        /// <example>The shorthand text representation of a SWAP gate is S.</example>
        /// </param>
        protected SingleQubitCommand(string commandValue, string shortHand)
            : base(commandValue, shortHand)
        {
        }

        /// <summary>
        /// Constructs a new instance of the SingleQubitCommand type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        /// <param name="index">The index of the qubit referenced in the operation.</param>
        protected SingleQubitCommand(string commandValue, int index)
            : this(commandValue, "")
        {
        }

        /// <summary>
        /// Constructs a new instance of the SingleQubitCommand type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        /// <param name="shortHand">The text short-hand version of the command.</param>
        /// <param name="index">The index of the qubit referenced in the operation.</param>
        protected SingleQubitCommand(string commandValue, string shortHand, int index)
            : this(commandValue, shortHand)
        {
            _index = index;
        }

        private int _index;

        /// <summary>
        /// Gets the index of the qubit referenced in the operation.
        /// </summary>
        public int Index
        {
            get
            {
                return _index;
            }
        }

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult commandResult = base.Execute(value, register);

            if (register.Qubits.Length < 1)
            {
                commandResult = new CommandResult(String.Format("The {0} command can only be used on a system containing 1 or more qubits.", CommandValue), false);
            }
            else
            {
                if ((Int32.TryParse(value, out _index) == true) && (_index >= 0) && (_index < register.Qubits.Length))
                {
                }
                else
                {
                    commandResult = new CommandResult(String.Format("No qubit was found at position '{0}'.", _index), false);
                }
            }

            return commandResult;
        }
    }
}