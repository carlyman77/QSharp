#region Using References

using System;
using System.Linq;

using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a NORMALISE command that may be executed against a Register.
    /// </summary>
    public class NormaliseCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the NormaliseCommand type.
        /// </summary>
        public NormaliseCommand()
            : base(Normalise)
        {
        }

        internal const string Normalise = "NORMALISE";

        private double _stateVectorValueAfter;
        private double _stateVectorValueBefore;

        /// <summary>
        /// Gets the normalised state vector value.
        /// </summary>
        public double StateVectorValueAfter
        {
            get
            {
                return _stateVectorValueAfter;
            }
        }

        /// <summary>
        /// Gets the summed state vector value prior to the operation.
        /// </summary>
        public double StateVectorValueBefore
        {
            get
            {
                return _stateVectorValueBefore;
            }
        }

        /// <summary>
        /// Executes the value via the command against a Register.
        /// </summary>
        /// <param name="value">The value to execute.</param>
        /// <param name="register">The Register to execute the command against.</param>
        /// <returns>Returns a CommandResult type representing the result of the operation.</returns>
        public override CommandResult Execute(string value, Register register)
        {
            CommandResult commandResult = base.Execute(value, register);

            if (register.IsNormalised() == false)
            {
                _stateVectorValueBefore = register.StateVector.Sum(m => (m.Amplitude.Real));

                register.Normalise();
                
                _stateVectorValueAfter = register.StateVector.Sum(m => (m.Amplitude.Real));

                if (_stateVectorValueAfter.Round(10) == ((double)(1.0)).Round(10))
                {
                    commandResult = new CommandResult(String.Format("Normalisation cmoplete, register taken from {0} to {1}.", _stateVectorValueBefore.ToString("0.000"), _stateVectorValueAfter.ToString("0.000")), true);
                }
                else
                {
                    commandResult = new CommandResult(String.Format("Normalisation failed, register taken from {0} to {1}.", _stateVectorValueBefore.ToString("0.000"), _stateVectorValueAfter.ToString("0.000")), true);
                }
            }
            else
            {
                commandResult = new CommandResult("Normalisation not required.", true);
            }

            return commandResult;
        }
    }
}
