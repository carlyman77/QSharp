#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class PauliZGateTests : GateTests
    {
        #region Constructors

        public PauliZGateTests()
        {
            oPauliZGate = new PauliZGate();
            oRegister = new Register(new Qubit[] { Qubit.OneValueQubit() });
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private PauliZGate oPauliZGate;
        private Register oRegister;

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void ZGate()
        {
            //  > Initial state:
            //  > A|0> + B|1> = (0.687|0> + 0.727|1>)

            //  A   B
            //  1   0   A    = (1 * A) + (0 * B)
            //  0   -1  -B   = (0 * A) + (-1 * B)

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            //  Z(0)
            oRegister.StateVector = oPauliZGate.ApplyTo(0, oRegister);

            //  A|0> mapped to A|0>
            //  B|1> mapped to -B|1>
            Assert.AreEqual(oRegister[0], oA);
            Assert.AreEqual(oRegister[1], oB);

            Assert.AreEqual(oA.Amplitude.Real, 1);
            Assert.AreEqual(oA.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oA.Amplitude.Phase, 0);
            //  Assert.AreEqual(oA.Amplitude.Magnitude, 1);

            Assert.AreEqual(oB.Amplitude.Real, -1);
            Assert.AreEqual(oB.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oB.Amplitude.Phase, 0);
            //  Assert.AreEqual(oB.Amplitude.Magnitude, -1);
            
            //  Reversible
            //  Y(0)
            oRegister.StateVector = oPauliZGate.ApplyTo(0, oRegister);

            //  A   -B
            //  1   0   A   = (1 * A) + (0 * B)
            //  0   -1  B   = (0 * A) + (-1 * -B)

            //  A|0> mapped to A|0>
            //  -B|1> mapped to B|1>
            Assert.AreEqual(oRegister[0], oA);
            Assert.AreEqual(oRegister[1], oB);

            Assert.AreEqual(oA.Amplitude.Real, 1);
            Assert.AreEqual(oA.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oA.Amplitude.Phase, 0);
            //  Assert.AreEqual(oA.Amplitude.Magnitude, 1);

            Assert.AreEqual(oB.Amplitude.Real, 1);
            Assert.AreEqual(oB.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oB.Amplitude.Phase, 0);
            //  Assert.AreEqual(oB.Amplitude.Magnitude, -1);
        }

        #endregion

        #region Delegates

        #endregion
    }
}
