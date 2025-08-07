#region Using References

using System;

using QSharp.Mathematics;
using QSharp.Mathematics.Commands;
using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.QuantumConsole
{
    public class Program
    {
		private const int NumberOfQubits = 3;

		private static bool isShowAlgebraicValues;
        private static bool isShowCoefficientValues;

        public static void Main(string[] arguments)
        {
            Console.WriteLine();
            Console.WriteLine("Quantum Console including QSharp Mathematics library v1.0");
            Console.WriteLine("Written by carlyman@outlook.com");
            Console.WriteLine("Copyright (c) 2014-{0} ELIASdigital", DateTime.Today.Year);

            CommandFactory.Register(new ClearRegisterCommand());

            Register register = new Register(NumberOfQubits);

            WriteMainMenu();
            Console.WriteLine();
            Console.WriteLine("Register initialised with {0} qubits, {1} basis states", register.Qubits.Length, register.Count);

            WriteQubits(register);
            WriteComputationalBasisStates(register);

            bool isOptionSelected = false;
            bool isExit = false;

            while (isExit == false)
            {
                string value = "";
                int option = 0;

                while (isOptionSelected == false)
                {
                    Console.WriteLine();
                    Console.Write(">> ");
                    value = Console.ReadLine();

                    switch (value)
                    {
                        case "9":
                        case "exit":
                        case "EXIT":
                            isExit = true;
                            isOptionSelected = true;
                            break;

                        case "?":
                            WriteMainMenu();
                            break;

                        default:
                            if (Int32.TryParse(value, out option) == true)
                            {
                                isOptionSelected = true;
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(value) == false)
                                {
                                    Parser parser = new Parser(value);
                                    ParseResult parseResult = parser.Parse(register);

                                    if (parseResult.IsValid == false)
                                    {
                                        Console.WriteLine();
                                        Console.Write(parseResult.Message);
                                    }
                                    else
                                    {
                                        if (String.IsNullOrEmpty(parseResult.Message) == false)
                                        {
                                            Console.WriteLine();
                                            Console.Write("Parser message: {0}", parseResult.Message);
                                        }

                                        if (String.IsNullOrEmpty(parseResult.TranslatedCommand) == false)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Translated command: {0}", parseResult.TranslatedCommand);
                                        }

                                        WriteComputationalBasisStates(register);
                                    }
                                }
                            }
                            break;
                    }
                }

                switch (option)
                {
                    case 1:
                        WriteQubits(register);
                        WriteComputationalBasisStates(register);
                        option = 0;
                        isOptionSelected = false;
                        value = "";
                        break;

                    case 2:
                        register = new Register(NumberOfQubits);
                        WriteQubits(register);
                        WriteComputationalBasisStates(register);
                        option = 0;
                        isOptionSelected = false;
                        value = "";
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Setting algebraic display from {0} to {1}", isShowAlgebraicValues, !isShowAlgebraicValues);
                        isShowAlgebraicValues = !isShowAlgebraicValues;
                        WriteQubits(register);
                        WriteComputationalBasisStates(register);
                        option = 0;
                        isOptionSelected = false;
                        value = "";
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Setting coefficient display from {0} to {1}", isShowCoefficientValues, !isShowCoefficientValues);
                        isShowCoefficientValues = !isShowCoefficientValues;
                        WriteQubits(register);
                        WriteComputationalBasisStates(register);
                        option = 0;
                        isOptionSelected = false;
                        value = "";
                        break;

                    case 9:
                        isExit = true;
                        break;

                    default:
                        option = 0;
                        isOptionSelected = false;
                        value = "";
                        break;
                }
            }

            Console.WriteLine();
        }

		private static void WriteComputationalBasisStates(Register register)
        {
            Console.WriteLine();

            foreach (ComputationalBasisState computationalBasisState in register)
            {
                string sBinaryString = computationalBasisState.Index.ToBase2(register.Qubits.Length);

                Console.Write(computationalBasisState.ToString(isShowAlgebraicValues, isShowCoefficientValues));

                if (computationalBasisState != register[register.Count - 1])
                {
                    Console.Write(" + ");
                }
            }

            Console.WriteLine();
        }

        private static void WriteMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Display register");
            Console.WriteLine("2. New random register");
            Console.WriteLine("3. Toggle algebraic display (currently: {0})", isShowAlgebraicValues);
            Console.WriteLine("4. Toggle coefficient display (currently: {0})", isShowCoefficientValues);
            //  Console.WriteLine("4. Delete a matrix");
            //  Console.WriteLine("5. Load matrices from a file");
            //  Console.WriteLine("6. Parse a matrix file");
            Console.WriteLine("9. Exit");
            Console.WriteLine("?. Display menu");
        }

        private static void WriteQubits(Register register)
        {
            Console.WriteLine();

            for (int i = 0; i < register.Qubits.Length; i++)
            {
                Console.Write("({0}|0> + {1}|1>)", register.Qubits[i].AlphaLabel, register.Qubits[i].BetaLabel);

                if (i < (register.Qubits.Length - 1))
                {
                    Console.Write(" (x) ");
                }
            }

            Console.WriteLine();
        }
    }
}