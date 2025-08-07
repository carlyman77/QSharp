#region Using References

using System;
using System.Linq;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a SWAP (S) command that may be executed against a Register.
    /// </summary>
    public class SwapCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the SwapCommand type.
        /// </summary>
        public SwapCommand()
            : base(Swap, "S")
        {
        }

        internal const string Swap = "SWAP";

        private int _index0;
        private int _index1;

        /// <summary>
        /// Gets the first qubit index.
        /// </summary>
        public int Index0
        {
            get
            {
                return _index0;
            }
        }

        /// <summary>
        /// Gets the second qubit index.
        /// </summary>
        public int Index1
        {
            get
            {
                return _index1;
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
            base.Execute(value, register);

            int[] values = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(m => ((Int32.Parse(m)))).ToArray<int>();

            if ((values.Length == 2) && (values.Length <= register.Qubits.Length) && ((values.Max(m => (m)) - 1) < register.Qubits.Length))
            {
                _index0 = values[0];
                _index1 = values[1];

                Qubit[] swapResults = GateFactory.NewSwapGate().ApplyTo(register.Qubits[_index0], register.Qubits[_index1]);

                register.Qubits[_index0] = swapResults[0];
                register.Qubits[_index1] = swapResults[1];
            }

            return null;
        }
    }
}
