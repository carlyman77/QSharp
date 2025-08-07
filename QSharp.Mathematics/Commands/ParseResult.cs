#region Using References

using System;
using System.Collections.Generic;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes the results of a parser operation.
    /// </summary>
    public class ParseResult
    {
        /// <summary>
        /// Constructs a new instance of the ParseResult type.
        /// </summary>
        public ParseResult()
            : this(true)
        {
        }

        /// <summary>
        /// Constructs a new instance of the ParseResult type.
        /// </summary>
        /// <param name="isValid">A Boolean indication of whether the operation was valid.</param>
        public ParseResult(bool isValid)
            : this(isValid, "", "")
        {
        }

        /// <summary>
        /// Constructs a new instance of the ParseResult type.
        /// </summary>
        /// <param name="isValid">A Boolean indication of whether the operation was valid.</param>
        /// <param name="Message">Additional messaging information.</param>
        /// <param name="translatedCommand">The original command text, if it was modified by the parser.</param>
        public ParseResult(bool isValid, string message, string translatedCommand)
        {
            _isValid = isValid;
            _message = Message;
            _translatedCommand = translatedCommand;
        }

        /// <summary>
        /// Constructs a new instance of the ParseResult type.
        /// </summary>
        /// <param name="isValid">A Boolean indication of whether the operation was valid.</param>
        /// <param name="message">Additional messaging information.</param>
        /// <param name="translatedCommand">The original command text, if it was modified by the parser.</param>
        /// <param name="commands">A list of Command types that were executed in the operation.</param>
        public ParseResult(bool isValid, string message, string translatedCommand, List<Command> commands)
            : this(isValid, message, translatedCommand)
        {
            _commands = commands;
        }

        private readonly List<Command> _commands;
        private readonly bool _isValid;
        private readonly string _message;
        private readonly string _translatedCommand;

        /// <summary>
        /// Get the list of Command types that were executed in the operation.
        /// </summary>
        public List<Command> Commands
        {
            get
            {
                return _commands;
            }
        }

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
        /// Gets additional messaging information.
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }
        }

        /// <summary>
        /// Gets the original command text, if it was modified by the parser. 
        /// </summary>
        public string TranslatedCommand
        {
            get
            {
                return _translatedCommand;
            }
        }
    }
}