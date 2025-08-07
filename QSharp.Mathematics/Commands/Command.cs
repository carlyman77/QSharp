#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a command that may be executed against a Register.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Constructs a new instance of the Command type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        protected Command(string commandValue)
        {
            _commandValue = commandValue;
        }

        /// <summary>
        /// Constructs a new instance of the Command type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        /// <param name="shortHand">The text short-hand version of the command.
        /// <example>The shorthand text representation of a SWAP gate is S.</example>
        /// </param>
        protected Command(string commandValue, string shortHand)
            : this(commandValue)
        {
            _shortHand = shortHand;
        }

        private readonly string _commandValue;
        private Register _register;
        private string _shortHand;
        private string _value;

        /// <summary>
        /// Gets the text value of the command. This is usually corresponds to a gate or matrix operation.
        /// </summary>
        public string CommandValue
        {
            get
            {
                return _commandValue;
            }
        }

        /// <summary>
        /// Gets the Register value used by the command.
        /// </summary>
        public Register Register
        {
            get
            {
                return _register;
            }
        }

        /// <summary>
        /// Gets the text short-hand version of the command.
        /// </summary>
        public string ShortHand
        {
            get
            {
                if (String.IsNullOrEmpty(_shortHand) == true)
                {
                    _shortHand = _commandValue;
                }

                return _shortHand;
            }
        }

        /// <summary>
        /// Gets the value processed by the command.
        /// </summary>
        public string Value
        {
            get
            {
                return _value;
            }
        }

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public virtual CommandResult Execute(string value, Register register)
        {
            _value = value;
            _register = register;

            return null;
        }
    }
}
