#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class SwapGateTests : GateTests
    {
        #region Constructors

        public SwapGateTests()
        {
            oSwapGate = new SwapGate();
            oQubit1 = new Qubit(dAlpha1, dBeta1);
            oQubit2 = new Qubit(dAlpha2, dBeta2);
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private double dAlpha1 = 0.687;
        private double dAlpha2 = 0.342;
        private double dBeta1 = 0.727;
        private double dBeta2 = 0.239;
        private Qubit oQubit1;
        private Qubit oQubit2;
        private SwapGate oSwapGate;

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void SwapGate()
        {
            Qubit[] oResults = oSwapGate.ApplyTo(oQubit1, oQubit2);

            Assert.AreEqual(oResults[0].Alpha, dAlpha1);
            Assert.AreEqual(oResults[0].Beta, dAlpha2);
            Assert.AreEqual(oResults[1].Alpha, dBeta1);
            Assert.AreEqual(oResults[1].Beta, dBeta2);

            //  Assert.AreEqual(oQubit.Alpha, ((Alpha + Beta) / Math.Sqrt(2)));
            //  Assert.AreEqual(oQubit.Beta, ((Alpha - Beta) / Math.Sqrt(2)));
        }

        #endregion

        #region Delegates

        #endregion
    }
}
