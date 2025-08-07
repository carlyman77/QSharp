#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a TOFFOLI command that may be executed against a Register.
    /// </summary>
    public class ToffoliCommand : TripleQubitCommand
    {
        /// <summary>
        /// Constructs a new instance of the ToffoliCommand type.
        /// </summary>
        public ToffoliCommand()
            : base(Toffoli, "T")
        {
        }

        /// <summary>
        /// Constructs a new instance of the ToffoliCommand type.
        /// </summary>
        /// <param name="control0">The first control qubit index.</param>
        /// <param name="control1">The second control qubit index.</param>
        /// <param name="target">The target qubit value processed by the command.</param>
        public ToffoliCommand(int control0, int control1, int target)
            : base(Toffoli, "T", control0, control1, target)
        {
        }

        internal const string Toffoli = "TOFFOLI";

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
                register.StateVector = GateFactory.NewToffoliGate().ApplyTo(Control0, Control1, Target, register);
            }

            return commandResult;
        }
    }
}
