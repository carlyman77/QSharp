#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes an IDENTITY (I) command that may be executed against a Register.
    /// </summary>
    internal class IdentityCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the IdentityCommand type.
        /// </summary>
        public IdentityCommand()
            : base(Identity)
        {
        }

        internal const string Identity = "I";

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
                //  Nothing really happens
                commandResult = new CommandResult();
            }

            return commandResult;
        }
    }
}
