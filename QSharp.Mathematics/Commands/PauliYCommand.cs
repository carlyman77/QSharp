#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a Pauli-Y (Y) command that may be executed against a Register.
    /// </summary>
    public class PauliYCommand : SingleQubitCommand
    {
        /// <summary>
        /// Constructs a new instance of the PauliYCommand type.
        /// </summary>
        public PauliYCommand()
            : base(PauliY)
        {
        }

        /// <summary>
        /// Constructs a new instance of the PauliXCommand type.
        /// </summary>
        /// <param name="index">The index of the qubit referenced in the operation.</param>
        public PauliYCommand(int index)
            : base(PauliY, index)
        {
        }

        internal const string PauliY = "Y";

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
                register.StateVector = GateFactory.NewPauliYGate().ApplyTo(Index, register);
            }

            return commandResult;
        }
    }
}
