#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a Pauli-X (X) command that may be executed against a Register.
    /// </summary>
    public class PauliXCommand : SingleQubitCommand 
    {
        /// <summary>
        /// Constructs a new instance of the PauliXCommand type.
        /// </summary>
        public PauliXCommand()
            : base(PauliX)
        {
        }

        /// <summary>
        /// Constructs a new instance of the PauliXCommand type.
        /// </summary>
        /// <param name="index">The index of the qubit referenced in the operation.</param>
        public PauliXCommand(int index)
            : base(PauliX, index)
        {
        }

        internal const string PauliX = "X";

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
                register.StateVector = GateFactory.NewPauliXGate().ApplyTo(Index, register);
            }

            return commandResult;
        }
    }
}
