#region Using References

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace QSharp.Mathematics.Commands
{
    /// <summary>
    /// Describes a parser type used for parsing and text commands against a register.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Constructs a new instance of the Parser type.
        /// </summary>
        /// <param name="command">The text command value to parse.</param>
        /// <example>
        /// Commands may be single:
        /// CNOT(0, 1);
        /// Commands can be executed in sequence:
        /// CNOT(0, 1);H(0);Z(1);
        /// </example>
        public Parser(string command)
        {
            _command = command;
        }

        private string _command;

        /// <summary>
        /// Executes the commands against a register.
        /// </summary>
        /// <param name="register">The Register type to execute the commands against.</param>
        /// <returns>Returns a new ParseResult type, further describing the results of the operation.</returns>
        public ParseResult Parse(Register register)
        {
            bool isValid = true;
            StringBuilder parseResultMessageStringBuilder = new StringBuilder();
            string translatedCommand = "";
            List<Command> commandList = new List<Command>();

            if (String.IsNullOrEmpty(_command) == false)
            {
                _command = _command.Replace(", ", ",").Replace(" ,", ",").Replace(Environment.NewLine, "").Replace(" ", "");

                if (_command.EndsWith(";") == false)
                {
                    _command = String.Format("{0};", _command);
                }

                string[] commands = _command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string commandPart in commands)
                {
                    string gate = "";
                    string value = "";

                    if ((commandPart.Contains("(") == true) && (commandPart.Contains(")") == true))
                    {
                        gate = commandPart.Substring(0, commandPart.IndexOf("("));
                        value = commandPart.Replace("(", "").Replace(gate, "");

                        if (value.Contains(")") == true)
                        {
                            value = value.Substring(0, value.IndexOf(")"));
                        }

                        Command command = CommandFactory.FromString(gate);

                        if (command != null)
                        {
                            CommandResult commandResult = command.Execute(value, register);
                            commandList.Add(command);

                            if (commandResult != null)
                            {
                                isValid = commandResult.IsValid;

                                parseResultMessageStringBuilder.AppendLine(commandResult.Message);
                            }
                        }
                        else
                        {
                            isValid = false;
                            parseResultMessageStringBuilder.AppendLine("Command not recognised.");
                        }
                    }
                    else
                    {
                        if ((commandPart.StartsWith("{{") == true) && (commandPart.EndsWith("}}") == true))
                        {
                            //  {{0,1},{1,0}} * {{1},{0}} + {{0},{0}}

                            Matrix outputMatrix = null;

                            string[] matrixParts = commandPart.Split(new char[] { '*', '+' });
                            foreach (string matrixPart in matrixParts)
                            {
                                Matrix parsedMatrix = Matrix.FromString(matrixPart);

                                if (outputMatrix == null)
                                {
                                    outputMatrix = parsedMatrix;
                                }
                                else
                                {
                                    outputMatrix = (outputMatrix * parsedMatrix);
                                }
                            }

                            if (outputMatrix != null)
                            {
                                isValid = true;
                                parseResultMessageStringBuilder.AppendLine();
                                parseResultMessageStringBuilder.AppendLine(outputMatrix.ToString());
                            }
                        }
                        else
                        {
                            isValid = false;
                            parseResultMessageStringBuilder.AppendLine("Command not recognised.");
                        }
                    }
                }
            }
            else
            {
                isValid = false;
                parseResultMessageStringBuilder.AppendLine("No command specified.");
            }

            if (String.IsNullOrEmpty(translatedCommand) == false)
            {
                translatedCommand = translatedCommand.Trim();
            }

            //  TODO
            //  QuantumCircuit oQuantumCircuit = new QuantumCircuit(Register, oCommandList);
            //  
            //  int iWidth = 400;
            //  int iHeight = 100;
            //  
            //  Bitmap oReturnBitmap = oQuantumCircuit.ToBitmap(iWidth, iHeight);

            //  oReturnBitmap.Save("Diagram.jpg", ImageFormat.Jpeg);

            return new ParseResult(isValid, parseResultMessageStringBuilder.ToString(), translatedCommand, commandList);
        }
    }
}
