#region Using References

using System;
using System.Numerics;

using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a SWAP gate, used to perform SWAP (S) operations against a register.
    /// </summary>
    public class SwapGate : SquareFourMatrix
    {
        /// <summary>
        /// Constructs a new instance of the SwapGate type.
        /// </summary>
        public SwapGate()
            : base(1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1)
        {
        }

        /// <summary>
        /// Performs a swap operation on two qubits.
        /// </summary>
        /// <param name="qubit1">The left qubit value.</param>
        /// <param name="qubit2">The right qubit value.</param>
        /// <returns>Returns an array of qubits representing the result of the operation.</returns>
        public Qubit[] ApplyTo(Qubit qubit1, Qubit qubit2)
        {
            //  Yes, we always operate on the qubits.
            //  Physically you can only operate on the qubits.
            //  This can result in manipulation of the complete state vector when simulating this action in a classical computer.

            //  |00> + |01> + |10> + |11>
            //  |AC> + |AD> + |BC> + |BD>

            //  {
            //  {1,0,0,0},
            //  {0,0,1,0},
            //  {0,1,0,0}
            //  {0,0,0,1}
            //  }

            //  (A + B)(C + D) = AC + AD + BC + BD

            //  AC  AD  BC  BD
            //  1,  0,  0,  0   AC
            //  0,  0,  1,  0   BC
            //  0,  1,  0,  0   AD
            //  0,  0,  0,  1   BD

            //  Rearrange to decompose:
            //  CA + CB + DA + DB = (C + D)(A + B)

            //  Complex oAC = Qubit1.Alpha; //  not affected
            //  Complex oAD = Qubit1.Beta;
            //  Complex oBC = Qubit2.Alpha;
            //  Complex oBD = Qubit2.Beta; //   not affected

            Complex ac = (1.Multiply(qubit1.Alpha) + 0.Multiply(qubit1.Beta) + 0.Multiply(qubit2.Alpha) + 0.Multiply(qubit2.Beta));
            Complex ad = (0.Multiply(qubit1.Alpha) + 0.Multiply(qubit1.Beta) + 1.Multiply(qubit2.Alpha) + 0.Multiply(qubit2.Beta));
            Complex bc = (0.Multiply(qubit1.Alpha) + 1.Multiply(qubit1.Beta) + 0.Multiply(qubit2.Alpha) + 0.Multiply(qubit2.Beta));
            Complex bd = (0.Multiply(qubit1.Alpha) + 0.Multiply(qubit1.Beta) + 0.Multiply(qubit2.Alpha) + 1.Multiply(qubit2.Beta));

            string alpha1Label = qubit1.AlphaLabel;
            string beta1Label = qubit1.BetaLabel;
            string alpha2Label = qubit2.AlphaLabel;
            string beta2Label = qubit2.BetaLabel;

            qubit1.Alpha = ac; //  unchanged
            qubit1.Beta = ad;
            qubit2.Alpha = bc;
            qubit2.Beta = bd;  //  unchanged

            qubit1.AlphaLabel = alpha2Label;
            qubit1.BetaLabel = beta2Label;
            qubit2.AlphaLabel = alpha1Label;
            qubit2.BetaLabel = beta1Label;

            return new Qubit[] { qubit1, qubit2 };
        }
    }
}
