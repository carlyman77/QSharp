#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a MEASURE command that may be executed against a Register.
    /// </summary>
    public class MeasureCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the MeasureCommand type.
        /// </summary>
        public MeasureCommand()
            : base(Measure)
        {
        }

        internal const string Measure = "MEASURE";

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult commandResult = base.Execute(value, register);

            //  measure in Z basis, measure in X 

            //  If you want to measure a specific qubit in a superposition,
            //  you calculate the total probability of all states in that superposition that have 0 on the qubit of interest,
            //  and the total probability of all states and that superposition that have 1 on the qubit of interest, randomly work out which one is observed,
            //  and delete all of the states not consistent with the measurement. You then normalise the remaining states.

            string errorMessage = "";

            if (String.IsNullOrEmpty(value) == false)
            {
                string basis = "";
                int index = -1;
                string[] valueParts = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (valueParts.Length == 2)
                {
                    basis = valueParts[0].ToUpper();

                    if ((String.IsNullOrEmpty(basis) == false) && (Int32.TryParse(valueParts[1], out index) == true) && (index >= 0) && (index < register.Qubits.Length) && ((basis == PauliXCommand.PauliX) || (basis == PauliZCommand.PauliZ)))
                    {
                        int iValue = register.Measure(basis, index);

                        commandResult = new CommandResult(String.Format("Measurement resulted in {0}", iValue), true);
                    }
                    else
                    {
                        errorMessage = "An argument of X or Z is expected.";
                    }
                }
                else
                {
                    errorMessage = String.Format("Arguments for the {0} command were not valid. 2 were expected, but {1} {2} provided.", CommandValue, valueParts.Length, ((valueParts.Length == 1) ? "was" : "were"));
                }
            }
            else
            {
                errorMessage = "An argument of X or Z is expected.";
            }

            if (String.IsNullOrEmpty(errorMessage) == false)
            {
                commandResult = new CommandResult(errorMessage, false);
            }

            return commandResult;
        }
    }
}
