#region Using References

using System;
using System.Collections.Generic;
using System.Drawing;

using QSharp.Mathematics.Commands;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Produces a quantum circuit diagram from a list of commands, used to visualise an operation performed against a register.
    /// </summary>
    public class QuantumCircuit
    {
        /// <summary>
        /// Constructs a new instance of the QuantumCircuit type.
        /// </summary>
        /// <param name="register">The register type value.</param>
        /// <param name="commands">A list of commands performed on the register.</param>
        public QuantumCircuit(Register register, List<Command> commands)
        {
            _register = register;
            _commands = commands;
        }

        private readonly List<Command> _commands;
        private readonly Register _register;

        private static void DrawControl(Graphics graphics, Brush brush, Pen pen, int x, int y, int size)
        {
            FillCircle(graphics, Brushes.Black, x, y, size);
            DrawCircle(graphics, Pens.Black, x, y, size);
        }

        private static void DrawCircle(Graphics graphics, Pen pen, int x, int y, int size)
        {
            graphics.DrawEllipse(pen, new Rectangle(new Point(x, y), new Size(size, size)));
        }

        private static void DrawLine(Graphics graphics, Pen pen, int fromX, int fromY, int toX, int toY)
        {
            graphics.DrawLine(pen, new Point(fromX, fromY), new Point(toX, toY));
        }

        private static void DrawSquare(Graphics graphics, Pen pen, int x, int y, int size)
        {
            graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(x, y), new Size(size, size)));
        }

        private static void FillCircle(Graphics graphics, Brush brush, int x, int y, int size)
        {
            graphics.FillEllipse(brush, new Rectangle(new Point(x, y), new Size(size, size)));
        }

        private static void FillSquare(Graphics graphics, Brush brush, int x, int y, int size)
        {
            graphics.FillRectangle(brush, new Rectangle(new Point(x, y), new Size(size, size)));
        }

        /// <summary>
        /// Converts the register and list of commands to an image.
        /// </summary>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        /// <returns>Returns a System.Drawing.Bitmap type representing the result of the operation.</returns>
        public Bitmap ToBitmap(int width, int height)
        {
            Bitmap toBitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(toBitmap))
            {
                graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));

                int heightSpacing = (height / (_register.Qubits.Length + 1));
                int widthSpacing = (width / (_commands.Count + 1));

                List<int> quantumWireHeights = new List<int>();
                List<int> quantumWireWidths = new List<int>();

                for (int i = 0; i < _register.Qubits.Length; i++)
                {
                    quantumWireHeights.Add((i + 1) * heightSpacing);
                }

                for (int i = 0; i < _commands.Count; i++)
                {
                    quantumWireWidths.Add((i + 1) * widthSpacing);
                }

                for (int i = 0; i < _register.Qubits.Length; i++)
                {
                    quantumWireHeights.Add((i + 1) * heightSpacing);
                    graphics.DrawString(i.ToString(), new Font("Verdana", 10), Brushes.Black, new PointF(0, (quantumWireHeights[i] - 8)));
                    DrawLine(graphics, Pens.DarkGray, 12, quantumWireHeights[i], (width - 2), quantumWireHeights[i]);
                }

                int artefactSize = (height / 13);
                for (int i = 0; i < _commands.Count; i++)
                {
                    Command command = _commands[i];

                    if (command is CNotCommand)
                    {
                        CNotCommand cNotCommand = (CNotCommand)(command);

                        //  Control
                        DrawControl(graphics, Brushes.Black, Pens.Black, (quantumWireWidths[i] - 5), (quantumWireHeights[cNotCommand.Control] - 5), 10);

                        DrawLine(graphics, Pens.Black, quantumWireWidths[i], quantumWireHeights[cNotCommand.Control], quantumWireWidths[i], quantumWireHeights[cNotCommand.Target]);

                        // Target
                        DrawCircle(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[cNotCommand.Target] - artefactSize), (artefactSize * 2));
                        DrawLine(graphics, Pens.Black, quantumWireWidths[i], (quantumWireHeights[cNotCommand.Target] - artefactSize), quantumWireWidths[i], (quantumWireHeights[cNotCommand.Target] + artefactSize));
                        DrawLine(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), quantumWireHeights[cNotCommand.Target], (quantumWireWidths[i] + artefactSize), quantumWireHeights[cNotCommand.Target]);
                    }

                    if (command is CZCommand)
                    {
                        CZCommand cZCommand = (CZCommand)(command);

                        //  Control
                        DrawControl(graphics, Brushes.Black, Pens.Black, (quantumWireWidths[i] - 5), (quantumWireHeights[cZCommand.Control] - 5), 10);

                        DrawLine(graphics, Pens.Black, quantumWireWidths[i], quantumWireHeights[cZCommand.Control], quantumWireWidths[i], quantumWireHeights[cZCommand.Target]);

                        // Target
                        FillSquare(graphics, Brushes.White, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[cZCommand.Target] - artefactSize), (artefactSize * 2));
                        DrawSquare(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[cZCommand.Target] - artefactSize), (artefactSize * 2));

                        graphics.DrawString("Z", new Font("Verdana", 10), Brushes.Black, new PointF((quantumWireWidths[i] - 6), (quantumWireHeights[cZCommand.Target] - 8)));

                        //  DrawCircle(oGraphics, Pens.Black, (oQuantumWireWidths[i] - iArtefactSize), (oQuantumWireHeights[oCZCommand.Target] - iArtefactSize), (iArtefactSize * 2));
                        //  DrawLine(oGraphics, Pens.Black, oQuantumWireWidths[i], (oQuantumWireHeights[oCZCommand.Target] - iArtefactSize), oQuantumWireWidths[i], (oQuantumWireHeights[oCZCommand.Target] + iArtefactSize));
                        //  DrawLine(oGraphics, Pens.Black, (oQuantumWireWidths[i] - iArtefactSize), oQuantumWireHeights[oCZCommand.Target], (oQuantumWireWidths[i] + iArtefactSize), oQuantumWireHeights[oCZCommand.Target]);
                    }

                    if ((command is HadamardCommand) || (command is IdentityCommand) || (command is PauliYCommand) || (command is PauliZCommand))
                    {
                        int index = Int32.Parse(command.Value);

                        FillSquare(graphics, Brushes.White, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[index] - artefactSize), (artefactSize * 2));
                        DrawSquare(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[index] - artefactSize), (artefactSize * 2));

                        graphics.DrawString(command.ShortHand, new Font("Verdana", 10), Brushes.Black, new PointF((quantumWireWidths[i] - 6), (quantumWireHeights[index] - 8)));
                    }

                    //  if (oCommand is IdentityCommand)
                    //  {
                    //  }

                    if (command is PauliXCommand)
                    {
                        int index = Int32.Parse(command.Value);

                        DrawCircle(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[index] - artefactSize), (artefactSize * 2));
                        DrawLine(graphics,Pens.Black, quantumWireWidths[i], (quantumWireHeights[index] - artefactSize), quantumWireWidths[i], (quantumWireHeights[index] + artefactSize));
                        DrawLine(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), quantumWireHeights[index], (quantumWireWidths[i] + artefactSize), quantumWireHeights[index]);
                    }

                    //  if (oCommand is PauliYCommand)
                    //  {
                    //  }
                    //  
                    //  if (oCommand is PauliZCommand)
                    //  {
                    //  }

                    if (command is SwapCommand)
                    {
                        SwapCommand swapCommand = (SwapCommand)(command);

                        DrawLine(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[swapCommand.Index0] + artefactSize), (quantumWireWidths[i] + artefactSize), (quantumWireHeights[swapCommand.Index0] - artefactSize));
                        DrawLine(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[swapCommand.Index0] - artefactSize), (quantumWireWidths[i] + artefactSize), (quantumWireHeights[swapCommand.Index0] + artefactSize));

                        DrawLine(graphics, Pens.Black, quantumWireWidths[i], quantumWireHeights[swapCommand.Index0], quantumWireWidths[i], quantumWireHeights[swapCommand.Index1]);

                        DrawLine(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[swapCommand.Index1] + artefactSize), (quantumWireWidths[i] + artefactSize), (quantumWireHeights[swapCommand.Index1] - artefactSize));
                        DrawLine(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[swapCommand.Index1] - artefactSize), (quantumWireWidths[i] + artefactSize), (quantumWireHeights[swapCommand.Index1] + artefactSize));
                    }

                    if (command is ToffoliCommand)
                    {
                        ToffoliCommand toffoliCommand = (ToffoliCommand)(command);

                        //  Control0
                        DrawControl(graphics, Brushes.Black, Pens.Black, (quantumWireWidths[i] - 5), (quantumWireHeights[toffoliCommand.Control0] - 5), 10);

                        //  Control1
                        DrawControl(graphics, Brushes.Black, Pens.Black, (quantumWireWidths[i] - 5), (quantumWireHeights[toffoliCommand.Control1] - 5), 10);

                        DrawLine(graphics, Pens.Black, quantumWireWidths[i], quantumWireHeights[0], quantumWireWidths[i], quantumWireHeights[quantumWireHeights.Count - 1]);

                        // Target
                        DrawCircle(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), (quantumWireHeights[toffoliCommand.Target] - artefactSize), (artefactSize * 2));
                        DrawLine(graphics, Pens.Black, quantumWireWidths[i], (quantumWireHeights[toffoliCommand.Target] - artefactSize), quantumWireWidths[i], (quantumWireHeights[toffoliCommand.Target] + artefactSize));
                        DrawLine(graphics, Pens.Black, (quantumWireWidths[i] - artefactSize), quantumWireHeights[toffoliCommand.Target], (quantumWireWidths[i] + artefactSize), quantumWireHeights[toffoliCommand.Target]);
                    }
                }
            }

            return toBitmap;
        }
    }
}