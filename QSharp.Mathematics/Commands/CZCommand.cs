#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a CZ (Controlled Z) command that may be executed against a Register.
    /// </summary>
    public class CZCommand : DoubleQubitCommand
    {
        /// <summary>
        /// Constructs a new instance of the CZCommand type.
        /// </summary>
        public CZCommand()
            : base(CZ)
        {
        }

        /// <summary>
        /// Constructs a new instance of the CZCommand type.
        /// </summary>
        /// <param name="control">The control qubit value processed by the command.</param>
        /// <param name="target">The target qubit value processed by the command.</param>
        public CZCommand(int control, int target)
            : base(CZ, control, target)
        {
        }

        internal const string CZ = "CZ";

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
                register.StateVector = GateFactory.NewCZGate().ApplyTo(Control, Target, register);
            }

            return commandResult;
        }
    }
}
