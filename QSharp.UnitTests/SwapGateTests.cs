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
        public SwapGateTests()
        {
            _swapGate = new SwapGate();
            _qubit1 = new Qubit(_alpha1, _beta1);
            _qubit2 = new Qubit(_alpha2, _beta2);
        }

        private readonly double _alpha1 = 0.687;
        private readonly double _alpha2 = 0.342;
        private readonly double _beta1 = 0.727;
        private readonly double _beta2 = 0.239;
        private readonly Qubit _qubit1;
        private readonly Qubit _qubit2;
        private readonly SwapGate _swapGate;

        [TestMethod]
        public void SwapGate()
        {
            Qubit[] results = _swapGate.ApplyTo(_qubit1, _qubit2);

            Assert.AreEqual(results[0].Alpha, _alpha1);
            Assert.AreEqual(results[0].Beta, _alpha2);
            Assert.AreEqual(results[1].Alpha, _beta1);
            Assert.AreEqual(results[1].Beta, _beta2);

            //  Assert.AreEqual(oQubit.Alpha, ((Alpha + Beta) / Math.Sqrt(2)));
            //  Assert.AreEqual(oQubit.Beta, ((Alpha - Beta) / Math.Sqrt(2)));
        }
    }
}
