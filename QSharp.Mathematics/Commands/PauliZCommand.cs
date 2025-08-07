#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a Pauli-Z (Z) command that may be executed against a Register.
    /// </summary>
    public class PauliZCommand : SingleQubitCommand
    {
        /// <summary>
        /// Constructs a new instance of the PauliZCommand type.
        /// </summary>
        public PauliZCommand()
            : base(PauliZ)
        {
        }

        /// <summary>
        /// Constructs a new instance of the PauliXCommand type.
        /// </summary>
        /// <param name="index">The index of the qubit referenced in the operation.</param>
        public PauliZCommand(int index)
            : base(PauliZ, index)
        {
        }

        internal const string PauliZ = "Z";

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult oCommandResult = base.Execute(value, register);

            if (oCommandResult == null)
            {
                register.StateVector = GateFactory.NewPauliZGate().ApplyTo(Index, register);
            }

            return oCommandResult;
        }
    }
}
