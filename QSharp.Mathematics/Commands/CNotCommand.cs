#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a CNOT (Controlled NOT) command that may be executed against a Register.
    /// </summary>
    public class CNotCommand : DoubleQubitCommand
    {
        /// <summary>
        /// Constructs a new instance of the CNotCommand type.
        /// </summary>
        public CNotCommand()
            : base(CNot)
        {
        }

        /// <summary>
        /// Constructs a new instance of the CNotCommand type.
        /// </summary>
        /// <param name="control">The control qubit value processed by the command.</param>
        /// <param name="target">The target qubit value processed by the command.</param>
        public CNotCommand(int control, int target)
            : base(CNot, control, target)
        {
        }

        internal const string CNot = "CNOT";

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult commandResult = base.Execute(value, register);

            if (commandResult == null)
            {
                register.StateVector = GateFactory.NewCNotGate().ApplyTo(Control, Target, register);
            }

            return commandResult;
        }
    }
}
