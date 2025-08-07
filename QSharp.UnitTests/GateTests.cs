#region Using References

using System;

using QSharp.Mathematics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace QSharp.UnitTests
{
    public class GateTests
    {
        #region Constructors

        #endregion

        #region Constants

        public const double Alpha = 0.687;
        public const double Beta = 0.727;

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Methods

        protected void ValidatePefectQubitState(Qubit Qubit, int State)
        {
            switch (State)
            {
                case 0:
                    ValidateZeroState(Qubit);
                    break;

                case 1:
                    ValidateOneState(Qubit);
                    break;
            }
        }

        protected void ValidateOneState(Qubit Qubit)
        {
            Assert.AreEqual(Qubit.Alpha, 0);
            Assert.AreEqual(Qubit.Beta, 1);
        }

        protected void ValidateZeroState(Qubit Qubit)
        {
            Assert.AreEqual(Qubit.Alpha, 1);
            Assert.AreEqual(Qubit.Beta, 0);
        }

        protected void ValidateComputationalStateVector(ComputationalBasisState[] ComputationalBasisStates)
        {
            ValidateComputationalStateVector(ComputationalBasisStates, 1);
        }

        protected void ValidateComputationalStateVector(ComputationalBasisState[] ComputationalBasisStates, double Real)
        {
            ValidateComputationalStateVector(ComputationalBasisStates, 1, 0);
        }

        protected void ValidateComputationalStateVector(ComputationalBasisState[] ComputationalBasisStates, double Real, double Imaginary)
        {
            foreach (ComputationalBasisState oComputationalBasisState in ComputationalBasisStates)
            {
                Assert.AreEqual(oComputationalBasisState.Amplitude.Real, Real);
                Assert.AreEqual(oComputationalBasisState.Amplitude.Imaginary, Imaginary);
            }
        }

        #endregion

        #region Delegates

        #endregion
    }
}
