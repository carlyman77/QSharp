#region Using References

using System;
using System.Linq;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a TENSOR command that may be executed against a Register.
    /// </summary>
    public class TensorCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the TensorCommand type.
        /// </summary>
        public TensorCommand()
            : base(Tensor)
        {
        }

        internal const string Tensor = "TENSOR";

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult commandResult = base.Execute(value, register);

            string[] tensorMatrixNames = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tensorMatrixNames.Length)
            {
                case 1:
                    commandResult = new CommandResult("More than one value is required to perform a tensor operation.", false);
                    break;

                default:
                    int toffolis = tensorMatrixNames.Select(m => (m.ToUpper())).Count(m => (m == ToffoliCommand.Toffoli));
                    if (commandResult == null)
                    {
                        Matrix matrix = new SquareOneMatrix(1);

                        foreach (string tensorMatrixName in tensorMatrixNames)
                        {
                            if (matrix == null)
                            {
                                break;
                            }

                            Matrix tensorMatrix = GateFactory.FromString(tensorMatrixName);
                            if (tensorMatrix != null)
                            {
                                matrix = matrix.Tensor(tensorMatrix);
                            }
                            else
                            {
                                commandResult = new CommandResult(String.Format("Unrecognised tensor matrix value of '{0}' specified.", tensorMatrixName), false);
                                matrix = null;
                            }
                        }

                        if (matrix != null)
                        {
                            commandResult = new CommandResult(matrix.ToString(), false);
                        }
                    }
                    break;
            }

            return commandResult;
        }
    }
}
