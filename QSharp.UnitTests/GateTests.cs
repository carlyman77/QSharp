#region Using References

using System;

using QSharp.Mathematics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace QSharp.UnitTests
{
    public class GateTests
    {
        public const double Alpha = 0.687;
        public const double Beta = 0.727;

        protected void ValidatePefectQubitState(Qubit qubit, int state)
        {
            switch (state)
            {
                case 0:
                    ValidateZeroState(qubit);
                    break;

                case 1:
                    ValidateOneState(qubit);
                    break;
            }
        }

        protected void ValidateOneState(Qubit qubit)
        {
            Assert.AreEqual(qubit.Alpha, 0);
            Assert.AreEqual(qubit.Beta, 1);
        }

        protected void ValidateZeroState(Qubit qubit)
        {
            Assert.AreEqual(qubit.Alpha, 1);
            Assert.AreEqual(qubit.Beta, 0);
        }

        protected void ValidateComputationalStateVector(ComputationalBasisState[] computationalBasisStates)
        {
            ValidateComputationalStateVector(computationalBasisStates, 1);
        }

        protected void ValidateComputationalStateVector(ComputationalBasisState[] computationalBasisStates, double real)
        {
            ValidateComputationalStateVector(computationalBasisStates, 1, 0);
        }

        protected void ValidateComputationalStateVector(ComputationalBasisState[] computationalBasisStates, double real, double imaginary)
        {
            foreach (ComputationalBasisState computationalBasisState in computationalBasisStates)
            {
                Assert.AreEqual(computationalBasisState.Amplitude.Real, real);
                Assert.AreEqual(computationalBasisState.Amplitude.Imaginary, imaginary);
            }
        }
    }
}
