#region Using References

using System;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a result of a command operation.
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// Constructs a new instance of the CommandResult type.
        /// </summary>
        public CommandResult()
            : this(true)
        {
        }

        /// <summary>
        /// Constructs a new instance of the CommandResult type.
        /// </summary>
        /// <param name="isValid">A Boolean indication of whether the operation was valid.</param>
        public CommandResult(bool isValid)
            : this("", isValid)
        {
        }

        /// <summary>
        /// Constructs a new instance of the CommandResult type.
        /// </summary>
        /// <param name="message">Additional messaging information.</param>
        public CommandResult(string message)
            : this(message, true)
        {
        }
        
        /// <summary>
        /// Constructs a new instance of the CommandResult type.
        /// </summary>
        /// <param name="message">Additional messaging information.</param>
        /// <param name="isValid">A Boolean indication of whether the operation was valid.</param>
        public CommandResult(string message, bool isValid)
        {
            _message = message;
            _isValid = isValid;
        }

        private readonly bool _isValid;
        private readonly string _message;

        /// <summary>
        /// Gets a Boolean value indicating the validity of the operation.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
        }

        /// <summary>
        /// Gets any additional messaging information.
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
