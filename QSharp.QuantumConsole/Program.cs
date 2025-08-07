#region Using References

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using QSharp.Mathematics;
using QSharp.Mathematics.Commands;
using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.QuantumConsole
{
    public class Program
    {
		#region Constructors

		#endregion

		#region Constants

		private const int NumberOfQubits = 10;

		#endregion

		#region Events

		#endregion

		#region Enumerations

		#endregion

		#region Fields

		private static bool bIsShowAlgebraicValues;
        private static bool bIsShowCoefficientValues;

        #endregion

        #region Properties

        #endregion

        #region Methods

        public static void Main(string[] Arguments)
        {
            Console.WriteLine();
            Console.WriteLine("Quantum Console including QSharp Mathematics library v1.0");
            Console.WriteLine("Written by carlyman@outlook.com");
            Console.WriteLine("Copyright (c) 2014-{0} ELIASdigital", DateTime.Today.Year);

            QSharp.Mathematics.Commands.CommandFactory.Register(new ClearRegisterCommand());

            Register oRegister = new Register(NumberOfQubits);

            WriteMainMenu();
            Console.WriteLine();

            Console.WriteLine("Register initialised with {0} qubits, {1} basis states", oRegister.Qubits.Length, oRegister.Count);

            WriteQubits(oRegister);
            WriteComputationalBasisStates(oRegister);

            //  BEGIN HACK
            //	UnmajorityAddGate oUnmajorityAddGate = new UnmajorityAddGate();
            //	//  Console.WriteLine(oUnmajorityAddGate.ToString());
			//	
            //	//  Matrix oMatrix = (oUnmajorityAddGate.Tensor(new IdentityMatrix()));
            //	//  Console.WriteLine(oMatrix);
			//	
            //	oRegister.StateVector = oUnmajorityAddGate.ApplyTo(oRegister);

            //  List<Command> oCommands = new List<Command>(new Command[]
            //  {
            //      //  MAJ
            //      //  new CNotCommand(2, 1),
            //      //  new CNotCommand(2, 0),
            //      //  new ToffoliCommand(0, 1, 2)
            //      //  UMA
            //      new CNotCommand(0, 2),
            //      new CNotCommand(2, 0),
            //      new CNotCommand(0, 1)
            //  });
            //  
            //  QuantumCircuit oQuantumCircuit = new QuantumCircuit(oRegister, oCommands);
            //  
            //  using (Bitmap oBitmap = oQuantumCircuit.ToBitmap(200, 100))
            //  {
            //      oBitmap.Save("UMA.bmp");
            //  }

            bool bIsOptionSelected = false;
            bool bIsExit = false;

            while (bIsExit == false)
            {
                string sValue = "";
                int iOption = 0;

                while (bIsOptionSelected == false)
                {
                    Console.WriteLine();
                    Console.Write(">> ");
                    sValue = Console.ReadLine();

                    switch (sValue)
                    {
                        case "9":
                        case "exit":
                        case "EXIT":
                            bIsExit = true;
                            bIsOptionSelected = true;
                            break;

                        case "?":
                            WriteMainMenu();
                            break;

                        default:
                            if (Int32.TryParse(sValue, out iOption) == true)
                            {
                                bIsOptionSelected = true;
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(sValue) == false)
                                {
                                    Parser oParser = new Parser(sValue);
                                    ParseResult oParseResult = oParser.Parse(oRegister);

                                    if (oParseResult.IsValid == false)
                                    {
                                        Console.WriteLine();
                                        Console.Write(oParseResult.Message);
                                    }
                                    else
                                    {
                                        if (String.IsNullOrEmpty(oParseResult.Message) == false)
                                        {
                                            Console.WriteLine();
                                            Console.Write("Parser message: {0}", oParseResult.Message);
                                        }

                                        if (String.IsNullOrEmpty(oParseResult.TranslatedCommand) == false)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Translated command: {0}", oParseResult.TranslatedCommand);
                                        }

                                        WriteComputationalBasisStates(oRegister);
                                    }
                                }
                            }
                            break;
                    }
                }

                switch (iOption)
                {
                    case 1:
                        WriteQubits(oRegister);
                        WriteComputationalBasisStates(oRegister);
                        iOption = 0;
                        bIsOptionSelected = false;
                        sValue = "";
                        break;

                    case 2:
                        oRegister = new Register(NumberOfQubits);
                        WriteQubits(oRegister);
                        WriteComputationalBasisStates(oRegister);
                        iOption = 0;
                        bIsOptionSelected = false;
                        sValue = "";
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Setting algebraic display from {0} to {1}", bIsShowAlgebraicValues, !bIsShowAlgebraicValues);
                        bIsShowAlgebraicValues = !bIsShowAlgebraicValues;
                        WriteQubits(oRegister);
                        WriteComputationalBasisStates(oRegister);
                        iOption = 0;
                        bIsOptionSelected = false;
                        sValue = "";
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Setting coefficient display from {0} to {1}", bIsShowCoefficientValues, !bIsShowCoefficientValues);
                        bIsShowCoefficientValues = !bIsShowCoefficientValues;
                        WriteQubits(oRegister);
                        WriteComputationalBasisStates(oRegister);
                        iOption = 0;
                        bIsOptionSelected = false;
                        sValue = "";
                        break;

                    case 9:
                        bIsExit = true;
                        break;

                    default:
                        iOption = 0;
                        bIsOptionSelected = false;
                        sValue = "";
                        break;
                }
            }

            Console.WriteLine();
        }

		private static void RippleCarryAddition()
		{
			/*
			The basic idea is to start with our least significant bit (right-most bit), and perform mod 2 addition.
			If there is anything left over (remainder), it gets carried into the next most significant bit, and is then used in that calculation.
			
			So Cin is the carry in value from the previous calculation, Cout is the carry out value from the current calculation,
			A and B are their respective bits, S is the current calculation under mod 2.

			  3 2 1 0
			A 0 1 1 0
			B 0 0 1 1
			
			Index 0:
			Cin = 0
			A = 0
			B = 1
			S = 1
			Cout = 0
			
			Index 1:
			Cin = 0
			A = 1
			B = 1
			S = 0
			Cout = 1
			
			Index 2:
			Cin = 1
			A = 1
			B = 0
			S = 1
			S + Cin = (1 + 1) = 0
			Cout = 1
			
			Index 3:
			Cin = 1
			A = 0
			B = 0
			S = 0
			S + Cin - (0 + 1) = 1
			Cout = 0
			
			   3 2 1 0
			A  0 1 1 0
			B  0 0 1 1
			
					 *
			   3 2 1 0
			Ci 0 0 0 0
			A  0 1 1 0
			B  0 0 1 1
			S  0 0 0 1
			Co 0 0 0 0
			
				   *
			   3 2 1 0
			Ci 0 0 0 0
			A  0 1 1 0
			B  0 0 1 1
			S  0 0 0 1
			Co 0 0 1 0
			
				 *
			   3 2 1 0
			Ci 0 1 0 0
			A  0 1 1 0
			B  0 0 1 1
			S  0 0 0 1
			Co 0 1 1 0
			
			   *
			   3 2 1 0
			Ci 1 1 0 0
			A  0 1 1 0
			B  0 0 1 1
			S  1 0 0 1
			Co 0 1 1 0
			
			
			  1  1
			A 0 1 1 0
			B 0 0 1 1
			1 0 0 1
			*/
		}

		private static void WriteComputationalBasisStates(Register Register)
        {
            Console.WriteLine();

            foreach (ComputationalBasisState oComputationalBasisState in Register)
            {
                string sBinaryString = oComputationalBasisState.Index.ToBase2(Register.Qubits.Length);

                Console.Write(oComputationalBasisState.ToString(bIsShowAlgebraicValues, bIsShowCoefficientValues));

                if (oComputationalBasisState != Register[Register.Count - 1])
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
            Console.WriteLine("3. Toggle algebraic display (currently: {0})", bIsShowAlgebraicValues);
            Console.WriteLine("4. Toggle coefficient display (currently: {0})", bIsShowCoefficientValues);
            //  Console.WriteLine("4. Delete a matrix");
            //  Console.WriteLine("5. Load matrices from a file");
            //  Console.WriteLine("6. Parse a matrix file");
            Console.WriteLine("9. Exit");
            Console.WriteLine("?. Display menu");
        }

        private static void WriteQubits(Register Register)
        {
            Console.WriteLine();

            for (int i = 0; i < Register.Qubits.Length; i++)
            {
                Console.Write("({0}|0> + {1}|1>)", Register.Qubits[i].AlphaLabel, Register.Qubits[i].BetaLabel);

                if (i < (Register.Qubits.Length - 1))
                {
                    Console.Write(" (x) ");
                }
            }

            Console.WriteLine();
        }

        #endregion

        #region Delegates

        #endregion
    }
}