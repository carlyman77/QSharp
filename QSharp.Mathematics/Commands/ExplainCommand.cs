#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes an EXPLAIN command that may be executed against a Register.
    /// </summary>
    public class ExplainCommand : Command
    {
        /// <summary>
        /// Constructs a new instance of the ExplainCommand type.
        /// </summary>
        public ExplainCommand()
            : base(Explain)
        {
        }

        internal const string Explain = "EXPLAIN";
    }
}
