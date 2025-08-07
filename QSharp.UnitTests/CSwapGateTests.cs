#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class CSwapGateTests : GateTests
    {
        #region Constructors

        public CSwapGateTests()
        {
            oCSwapGate = new CSwapGate();
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private CSwapGate oCSwapGate;

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void CSwap3QubitControl0Target1Target2()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  CTT CTT
            //  012 012

            //  000 000
            //  001 001
            //  010 010
            //  011 011
            //  100 100
            //  101 110
            //  110 101
            //  111 111

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  000 001 010 011 100 101 110 111

            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   0   0   0   1   BDF

            //  CSWAP(0, 1, 2)
            oRegister.StateVector = oCSwapGate.ApplyTo(0, 1, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBDE);
            Assert.AreEqual(oRegister[6], oBCF);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CSWAP(0, 1, 2)
            oRegister.StateVector = oCSwapGate.ApplyTo(0, 1, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CSwap3QubitControl0Target2Target1()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  CTT CTT
            //  012 012

            //  000 000
            //  001 001
            //  010 010
            //  011 011
            //  100 100
            //  101 110
            //  110 101
            //  111 111

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  000 001 010 011 100 101 110 111

            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   0   0   0   1   BDF

            //  CSWAP(0, 1, 2)
            oRegister.StateVector = oCSwapGate.ApplyTo(0, 2, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBDE);
            Assert.AreEqual(oRegister[6], oBCF);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CSWAP(0, 1, 2)
            oRegister.StateVector = oCSwapGate.ApplyTo(0, 2, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CSwap3QubitControl1Target0Target2()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  TCT TCT
            //  012 012

            //  000 000
            //  001 001
            //  010 010
            //  011 110
            //  100 100
            //  101 101
            //  110 011
            //  111 111

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  000 001 010 011 100 101 110 111

            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   0   0   0   1   BDF

            //  CSWAP(1, 0, 2)
            oRegister.StateVector = oCSwapGate.ApplyTo(1, 0, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oBDE);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oADF);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CSWAP(0, 1, 2)
            oRegister.StateVector = oCSwapGate.ApplyTo(1, 0, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CSwap3QubitControl2Target0Target1()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  TTC TTC
            //  012 012

            //  000 000
            //  001 001
            //  010 010
            //  011 101
            //  100 100
            //  101 011
            //  110 110
            //  111 111

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  000 001 010 011 100 101 110 111

            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   0   0   1   BDF

            //  CSWAP(2, 0, 1)
            oRegister.StateVector = oCSwapGate.ApplyTo(2, 0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oBCF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oADF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CSWAP(2, 0, 1)
            oRegister.StateVector = oCSwapGate.ApplyTo(2, 0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        #endregion

        #region Delegates

        #endregion
    }
}
