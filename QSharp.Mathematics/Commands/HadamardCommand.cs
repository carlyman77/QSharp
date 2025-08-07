#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a HADAMARD (H) command that may be executed against a Register.
    /// </summary>
    public class HadamardCommand : SingleQubitCommand
    {
        /// <summary>
        /// Constructs a new instance of the HadamardCommand type.
        /// </summary>
        public HadamardCommand()
            : base(Hadamard, "H")
        {
        }

        /// <summary>
        /// Constructs a new instance of the HadamardCommand type.
        /// </summary>
        /// <param name="index">The index of the qubit referenced in the operation.</param>
        public HadamardCommand(int index)
            : base(Hadamard, "H", index)
        {
        }

        internal const string Hadamard = "HADAMARD";

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
                register.StateVector = GateFactory.NewHadamardGate().ApplyTo(Index, register);
            }

            return commandResult;
        }
    }
}
