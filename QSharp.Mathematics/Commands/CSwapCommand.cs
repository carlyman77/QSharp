#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a CSwapCommand command that may be executed against a Register.
    /// </summary>
    public class CSwapCommand : TripleQubitCommand
    {
        /// <summary>
        /// Constructs a new instance of the CSwapCommand type.
        /// </summary>
        public CSwapCommand()
            : base(CSwap, "F")
        {
        }

        /// <summary>
        /// Constructs a new instance of the CSwapCommand type.
        /// </summary>
        /// <param name="control0">The first control qubit value processed by the command.</param>
        /// <param name="control1">The second control qubit value processed by the command.</param>
        /// <param name="target">The target qubit value processed by the command.</param>
        public CSwapCommand(int control0, int control1, int target)
            : base(CSwap, "F", control0, control1, target)
        {
        }

        internal const string CSwap = "CSWAP";

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
                register.StateVector = GateFactory.NewFredkinGate().ApplyTo(Control0, Control1, Target, register);
            }

            return commandResult;
        }
    }
}
