#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a PRINT command that may be executed against a Register.
    /// </summary>
    internal class PrintCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the PrintCommand type.
        /// </summary>
        public PrintCommand()
            : base(Print)
        {
        }

        internal const string Print = "PRINT";

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult commandResult = base.Execute(value, register);
            Matrix matrix = GateFactory.FromString(value);

            if (matrix != null)
            {
                commandResult = new CommandResult(matrix.ToString(), false);
            }

            return commandResult;
        }
    }
}
