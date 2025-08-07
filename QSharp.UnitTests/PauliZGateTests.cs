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
        public PauliZGateTests()
        {
            _pauliZGate = new PauliZGate();
            _register = new Register(new Qubit[] { Qubit.OneValueQubit() });
        }

        private readonly PauliZGate _pauliZGate;
        private readonly Register _register;

        [TestMethod]
        public void ZGate()
        {
            //  > Initial state:
            //  > A|0> + B|1> = (0.687|0> + 0.727|1>)

            //  A   B
            //  1   0   A    = (1 * A) + (0 * B)
            //  0   -1  -B   = (0 * A) + (-1 * B)

            ComputationalBasisState a = _register.StateVector[0];
            ComputationalBasisState b = _register.StateVector[1];

            //  Z(0)
            _register.StateVector = _pauliZGate.ApplyTo(0, _register);

            //  A|0> mapped to A|0>
            //  B|1> mapped to -B|1>
            Assert.AreEqual(_register[0], a);
            Assert.AreEqual(_register[1], b);

            Assert.AreEqual(a.Amplitude.Real, 1);
            Assert.AreEqual(a.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oA.Amplitude.Phase, 0);
            //  Assert.AreEqual(oA.Amplitude.Magnitude, 1);

            Assert.AreEqual(b.Amplitude.Real, -1);
            Assert.AreEqual(b.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oB.Amplitude.Phase, 0);
            //  Assert.AreEqual(oB.Amplitude.Magnitude, -1);
            
            //  Reversible
            //  Y(0)
            _register.StateVector = _pauliZGate.ApplyTo(0, _register);

            //  A   -B
            //  1   0   A   = (1 * A) + (0 * B)
            //  0   -1  B   = (0 * A) + (-1 * -B)

            //  A|0> mapped to A|0>
            //  -B|1> mapped to B|1>
            Assert.AreEqual(_register[0], a);
            Assert.AreEqual(_register[1], b);

            Assert.AreEqual(a.Amplitude.Real, 1);
            Assert.AreEqual(a.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oA.Amplitude.Phase, 0);
            //  Assert.AreEqual(oA.Amplitude.Magnitude, 1);

            Assert.AreEqual(b.Amplitude.Real, 1);
            Assert.AreEqual(b.Amplitude.Imaginary, 0);
            //  Assert.AreEqual(oB.Amplitude.Phase, 0);
            //  Assert.AreEqual(oB.Amplitude.Magnitude, -1);
        }
    }
}
