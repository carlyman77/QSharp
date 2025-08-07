#region Using References

using System;
using System.Linq;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a double-qubit command that may be executed against a Register.
    /// </summary>
    public class DoubleQubitCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the DoubleQubitCommand type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        protected DoubleQubitCommand(string commandValue)
            : base(commandValue)
        {
        }

        /// <summary>
        /// Constructs a new instance of the DoubleQubitCommand type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        /// <param name="shortHand">The text short-hand version of the command.
        /// <example>The shorthand text representation of a SWAP gate is S.</example>
        /// </param>
        protected DoubleQubitCommand(string commandValue, string shortHand)
            : base(commandValue, shortHand)
        {
        }

        /// <summary>
        /// Constructs a new instance of the DoubleQubitCommand type.
        /// </summary>
        /// <param name="commandValue">The text value of the command. This is usually corresponds to a gate or matrix operation.</param>
        /// <param name="control">The control qubit value processed by the command.</param>
        /// <param name="target">The target qubit value processed by the command.</param>
        protected DoubleQubitCommand(string commandValue, int control, int target)
            : this(commandValue)
        {
            _control = control;
            _target = target;
        }

        private int _control;
        private int _target;

        /// <summary>
        /// Gets the control qubit value processed by the command.
        /// </summary>
        public int Control
        {
            get
            {
                return _control;
            }
        }

        /// <summary>
        /// Gets the target qubit value processed by the command.
        /// </summary>
        public int Target
        {
            get
            {
                return _target;
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

            if (register.Qubits.Length < 2)
            {
                commandResult = new CommandResult(String.Format("The {0} command can only be used on a system containing 2 or more qubits.", CommandValue), false);
            }
            else
            {
                string[] values = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] iValues = new int[values.Length];
                bool isValidValues = true;

                for (int i = 0; i < values.Length; i++)
                {
                    int iValue = 0;
                    if (Int32.TryParse(values[i], out iValue) == true)
                    {
                        iValues[i] = iValue;
                    }
                    else
                    {
                        isValidValues = false;
                        break;
                    }
                }

                if ((isValidValues == true) && (iValues.Length == 2))
                {
                    _control = iValues[0];
                    _target = iValues[1];

                    if ((iValues.Length <= register.Qubits.Length) && (iValues.Min(m => (m)) >= 0) && ((iValues.Max(m => (m)) - 1) < register.Qubits.Length) && (_control != _target))
                    {
                    }
                    else
                    {
                        commandResult = new CommandResult(String.Format("Arguments for the {0} command were out of the expected range. Provided values were Control = {1} and Target = {2}.", CommandValue, _control, _target), false);
                    }
                }
                else
                {
                    commandResult = new CommandResult(String.Format("Arguments for the {0} command were not valid. 2 were expected, but {1} {2} provided.", CommandValue, iValues.Length, ((iValues.Length == 1) ? "was" : "were")), false);
                }
            }

            return commandResult;
        }
    }
}
