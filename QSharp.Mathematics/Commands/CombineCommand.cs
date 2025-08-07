#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a COMBINE command that may be executed against a Register.
    /// </summary>
    public class CombineCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the CombineCommand type.
        /// </summary>
        public CombineCommand()
            : base(Combine)
        {
        }

        internal const string Combine = "COMBINE";

		/// <summary>
		/// Executes the value via the command against a Register.
		/// </summary>
		/// <param name="value">The value to execute.</param>
		/// <param name="register">The Register to execute the command against.</param>
		/// <returns>Returns a CommandResult type representing the result of the operation.</returns>
		public override CommandResult Execute(string value, Register register)
		{
			CommandResult commandResult = base.Execute(value, register);
			string[] combineMatrices = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

			switch (combineMatrices.Length)
			{
				case 1:
					commandResult = new CommandResult("More than one value is required to perform a combine operation.", false);
					break;

				default:
					Matrix matrix = null;

					foreach (string sMatrix in combineMatrices)
					{
						if (matrix == null)
						{
							matrix = GateFactory.FromString(sMatrix);
						}
						else
						{
							Matrix combine = GateFactory.FromString(sMatrix);

							while (combine < matrix)
							{
								combine = combine.Tensor(GateFactory.NewIdentityMatrix());
							}

							while (matrix < combine)
							{
								matrix = matrix.Tensor(GateFactory.NewIdentityMatrix());
							}

							matrix = matrix.Combine(combine);
						}
					}

					commandResult = new CommandResult(matrix.ToString(), false);
					break;
			}

			return commandResult;
		}
    }
}
