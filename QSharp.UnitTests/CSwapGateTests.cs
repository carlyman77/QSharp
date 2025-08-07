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
        public CSwapGateTests()
        {
            _cSwapGate = new CSwapGate();
        }

        private readonly CSwapGate _cSwapGate;

        [TestMethod]
        public void CSwap3QubitControl0Target1Target2()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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
            register.StateVector = _cSwapGate.ApplyTo(0, 1, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bde);
            Assert.AreEqual(register[6], bcf);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);

            //  CSWAP(0, 1, 2)
            register.StateVector = _cSwapGate.ApplyTo(0, 1, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CSwap3QubitControl0Target2Target1()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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
            register.StateVector = _cSwapGate.ApplyTo(0, 2, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bde);
            Assert.AreEqual(register[6], bcf);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);

            //  CSWAP(0, 1, 2)
            register.StateVector = _cSwapGate.ApplyTo(0, 2, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CSwap3QubitControl1Target0Target2()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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
            register.StateVector = _cSwapGate.ApplyTo(1, 0, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], bde);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], adf);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);

            //  CSWAP(0, 1, 2)
            register.StateVector = _cSwapGate.ApplyTo(1, 0, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CSwap3QubitControl2Target0Target1()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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
            register.StateVector = _cSwapGate.ApplyTo(2, 0, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], bcf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], adf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);

            //  CSWAP(2, 0, 1)
            register.StateVector = _cSwapGate.ApplyTo(2, 0, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            ValidateComputationalStateVector(register.StateVector);
        }
    }
}
