#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes an INITIALISE command that may be executed against a Register.
    /// </summary>
    public class InitialiseCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the InitialiseCommand type.
        /// </summary>
        public InitialiseCommand()
            : base(Initialise)
        {
        }

        internal const string Initialise = "INITIALISE";

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult commandResult = base.Execute(value, register);

            if (String.IsNullOrEmpty(value) == false)
            {
                string[] valueParts = value.ToUpper().Replace(" ", "").Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                bool isValidCommand = true;
                string command = "";
                int index = 0;

                switch (valueParts.Length)
                {
                    case 1:
                        command = valueParts[0];
                        break;

                    case 2:
                        command = valueParts[0];
                        isValidCommand = Int32.TryParse(valueParts[1], out index);
                        break;
                }

                if ((isValidCommand == true) && (String.IsNullOrEmpty(command) == false) && (index >= 0) && (index < register.Qubits.Length))
                {
                    switch (command)
                    {
                        case "0":
                            //  TODO
                            //  Register.InitialiseToZero(iIndex);
                            //  oCommandResult = new CommandResult(String.Format("Register initialised to 0 using qubit {0}.", iIndex), true);
                            break;

                        case "+":
                            //  TODO
                            //  Register.InitialiseToPlus(iIndex);
                            //  oCommandResult = new CommandResult(String.Format("Register initialised to + using qubit {0}.", iIndex), true);
                            break;
                    }
                }
            }

            return commandResult;
        }
    }
}
