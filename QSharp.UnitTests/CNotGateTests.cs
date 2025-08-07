#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class CNotGateTests : GateTests
    {
        public CNotGateTests()
        {
            _cNotGate = new CNotGate();
        }

        private readonly CNotGate _cNotGate;

        [TestMethod]
        public void CNotGate2QubitControl0Target1()
        {
            //  (A + B) (x) (C + D)

            //  01  01  01  01
            //  AC  AD  BC  BD
            //  00  01  10  11

            //       C  T
            //  CNOT(0, 1)

            //  01  01  01  01
            //  AC  AD  BC  BD
            //  00  01  10  11
            //  00  01  11  10

            //  00  01
            //  I   X

            //  I (c) X

            //  AC  AD  BC  BD
            //  1   0   0   0
            //  0   1   0   0
            //  0   0   0   1
            //  0   0   1   0


            //  0, 00: (1, 0) -> 0
            //  1, 01: (2, 0) -> 3
            //  2, 10: (3, 0) -> 2
            //  3, 11: (4, 0) -> 1

            //  0, 00: (1, 0)
            //  1, 01: (4, 0)
            //  2, 10: (3, 0)
            //  3, 11: (2, 0)

            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bd);
            Assert.AreEqual(register[3], bc);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CNotGate2QubitControl1Target0()
        {
            //  (A + B) (x) (C + D)
            
            //  01  01  01  01
            //  AC  AD  BC  BD
            //  00  01  10  11

            //       C  T
            //  CNOT(1, 0)

            //  If:
            //   - Control(position 1) is 1 then
            //   - Target (position 2) is flipped
            //       - from 0 to 1
            //       - from 1 to 0

            //      f*      f*
            //  TC  TC  TC  TC
            //  01  01  01  01
            //  AC  AD  BC  BD
            //  00  01  10  11
            //  00  11  10  01

            //  AC  AD  BC  BD
            //  1   0   0   0   AC  Unchanged
            //  0   0   0   1   BD  Flipped with AD
            //  0   0   1   0   BC  Unchanged
            //  0   1   0   0   AD  Flipped with BD


            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  CNOT(1, 0)
            register.StateVector = _cNotGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], bd);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], ad);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(1, 0)
            register.StateVector = _cNotGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CNotGate3QubitControl0Target1()
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

            //  000 000
            //  001 001
            //  010 010
            //  011 011
            //  100 110
            //  101 111
            //  110 100
            //  111 111

            //  00  01
            //  II  XI

            //  (I (x) I) (c) (X (x) I)

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   0   0   1   0   BCE
            //  0   0   0   0   0   0   0   1   BCF
            //  0   0   0   0   1   0   0   0   BDE
            //  0   0   0   0   0   1   0   0   BDF

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bde);
            Assert.AreEqual(register[5], bdf);
            Assert.AreEqual(register[6], bce);
            Assert.AreEqual(register[7], bcf);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 1, register);

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
        public void CNotGate3QubitControl0Target2()
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

            //  00  01
            //  II  IX

            //  (I (x) I) (c) (I (x) X)

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   0   0   1   BDF
            //  0   0   0   0   0   0   1   0   BDE
            //  

            //  CNOT(0, 2)
            register.StateVector = _cNotGate.ApplyTo(0, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bcf);
            Assert.AreEqual(register[5], bce);
            Assert.AreEqual(register[6], bdf);
            Assert.AreEqual(register[7], bde);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 2)
            register.StateVector = _cNotGate.ApplyTo(0, 2, register);

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
        public void CNotGate3QubitControl1Target0()
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

            //  012
            //  000 000
            //  001 001
            //  010 110
            //  011 111
            //  100 100
            //  101 101
            //  110 010
            //  111 011

            //  ??

            //  000 001 010 011 100 101 110 111
            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   0   0   1   BDF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF

            //  CNOT(1, 0)
            register.StateVector = _cNotGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], bde);
            Assert.AreEqual(register[3], bdf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], ade);
            Assert.AreEqual(register[7], adf);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(1, 0)
            register.StateVector = _cNotGate.ApplyTo(1, 0, register);

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
        public void CNotGate3QubitControl1Target2()
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

            //   CT  CT
            //  012 012

            //  000 000
            //  001 001
            //  010 011
            //  011 010
            //  100 100
            //  101 101
            //  110 111
            //  111 110

            //  (I (c) X) (c) (I (c) X)

            //  000 001 010 011 100 101 110 111
            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE 000
            //  0   1   0   0   0   0   0   0   ACF 001
            //  0   0   0   1   0   0   0   0   ADF 011
            //  0   0   1   0   0   0   0   0   ADE 010
            //  0   0   0   0   1   0   0   0   BCE 100
            //  0   0   0   0   0   1   0   0   BCF 101
            //  0   0   0   0   0   0   0   1   BDF 111
            //  0   0   0   0   0   0   1   0   BDE 110

            //  CNOT(1, 2)
            register.StateVector = _cNotGate.ApplyTo(1, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], adf);
            Assert.AreEqual(register[3], ade);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bdf);
            Assert.AreEqual(register[7], bde);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(1, 2)
            register.StateVector = _cNotGate.ApplyTo(1, 2, register);

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
        public void CNotGate3QubitControl2Target0()
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

            //  T C
            //  012
            //  000 000
            //  001 101
            //  010 010
            //  011 111
            //  100 100
            //  101 001
            //  110 110
            //  111 011

            //  ??

            //  000 001 010 011 100 101 110 111
            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   0   0   0   0   1   0   0   BCE
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   0   0   0   0   1   BDF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   1   0   0   0   0   ADF

            //  CNOT(2, 0)
            register.StateVector = _cNotGate.ApplyTo(2, 0, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], bcf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], bdf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], acf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], adf);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(2, 0)
            register.StateVector = _cNotGate.ApplyTo(2, 0, register);

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
        public void CNotGate3QubitControl2Target1()
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

            //   TC
            //  012
            //  000 000
            //  001 011
            //  010 010
            //  011 001
            //  100 100
            //  101 111
            //  110 110
            //  111 101

            //  ??

            //  000 001 010 011 100 101 110 111
            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   0   0   1   BDF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   1   0   0   BCF

            //  CNOT(2, 0)
            register.StateVector = _cNotGate.ApplyTo(2, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], adf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], acf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bdf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bcf);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(2, 0)
            register.StateVector = _cNotGate.ApplyTo(2, 1, register);

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
        public void CNotGate4QubitControl0Target1()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState aceg = register.StateVector[0];
            ComputationalBasisState aceh = register.StateVector[1];
            ComputationalBasisState acfg = register.StateVector[2];
            ComputationalBasisState acfh = register.StateVector[3];
            ComputationalBasisState adeg = register.StateVector[4];
            ComputationalBasisState adeh = register.StateVector[5];
            ComputationalBasisState adfg = register.StateVector[6];
            ComputationalBasisState adfh = register.StateVector[7];
            ComputationalBasisState bceg = register.StateVector[8];
            ComputationalBasisState bceh = register.StateVector[9];
            ComputationalBasisState bcfg = register.StateVector[10];
            ComputationalBasisState bcfh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  CT   CT
            //  0123 0123
            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0100
            //  0101 0101
            //  0110 0110
            //  0111 0111

            //  1000 1100
            //  1001 1101
            //  1010 1110
            //  1011 1111
            //  1100 1000
            //  1101 1001
            //  1110 1010
            //  1111 1011

            //  00  01
            //  III XII

            //  III (c) XII
            //  (I (x) I (x) I) (c) (X (x) I (x) I)

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bdeg);
            Assert.AreEqual(register[9], bdeh);
            Assert.AreEqual(register[10], bdfg);
            Assert.AreEqual(register[11], bdfh);
            Assert.AreEqual(register[12], bceg);
            Assert.AreEqual(register[13], bceh);
            Assert.AreEqual(register[14], bcfg);
            Assert.AreEqual(register[15], bcfh);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl0Target2()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState aceg = register.StateVector[0];
            ComputationalBasisState aceh = register.StateVector[1];
            ComputationalBasisState acfg = register.StateVector[2];
            ComputationalBasisState acfh = register.StateVector[3];
            ComputationalBasisState adeg = register.StateVector[4];
            ComputationalBasisState adeh = register.StateVector[5];
            ComputationalBasisState adfg = register.StateVector[6];
            ComputationalBasisState adfh = register.StateVector[7];
            ComputationalBasisState bceg = register.StateVector[8];
            ComputationalBasisState bceh = register.StateVector[9];
            ComputationalBasisState bcfg = register.StateVector[10];
            ComputationalBasisState bcfh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  C T  C T
            //  0123 0123
            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0100
            //  0101 0101
            //  0110 0110
            //  0111 0111

            //  1000 1010
            //  1001 1011
            //  1010 1000
            //  1011 1001
            //  1100 1110
            //  1101 1111
            //  1110 1100
            //  1111 1101

            //  00  01
            //  III IXI

            //  III (x) IXI
            //  (I (x) I (x) I) (x) (I (x) X (x) I)

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH

            //  CNOT(0, 2)
            register.StateVector = _cNotGate.ApplyTo(0, 2, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bcfg);
            Assert.AreEqual(register[9], bcfh);
            Assert.AreEqual(register[10], bceg);
            Assert.AreEqual(register[11], bceh);
            Assert.AreEqual(register[12], bdfg);
            Assert.AreEqual(register[13], bdfh);
            Assert.AreEqual(register[14], bdeg);
            Assert.AreEqual(register[15], bdeh);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 2, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl0Target3()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState aceg = register.StateVector[0];
            ComputationalBasisState aceh = register.StateVector[1];
            ComputationalBasisState acfg = register.StateVector[2];
            ComputationalBasisState acfh = register.StateVector[3];
            ComputationalBasisState adeg = register.StateVector[4];
            ComputationalBasisState adeh = register.StateVector[5];
            ComputationalBasisState adfg = register.StateVector[6];
            ComputationalBasisState adfh = register.StateVector[7];
            ComputationalBasisState bceg = register.StateVector[8];
            ComputationalBasisState bceh = register.StateVector[9];
            ComputationalBasisState bcfg = register.StateVector[10];
            ComputationalBasisState bcfh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  C  T C  T
            //  0123 0123
            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0100
            //  0101 0101
            //  0110 0110
            //  0111 0111

            //  1000 1001
            //  1001 1000
            //  1010 1011
            //  1011 1010
            //  1100 1101
            //  1101 1100
            //  1110 1111
            //  1111 1110

            //  01  10
            //  III IIX

            //  III (x) IIX
            //  (I (x) I (x) I) (x) (I (x) I (x) X)

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG

            //  CNOT(0, 2)
            register.StateVector = _cNotGate.ApplyTo(0, 3, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceh);
            Assert.AreEqual(register[9], bceg);
            Assert.AreEqual(register[10], bcfh);
            Assert.AreEqual(register[11], bcfg);
            Assert.AreEqual(register[12], bdeh);
            Assert.AreEqual(register[13], bdeg);
            Assert.AreEqual(register[14], bdfh);
            Assert.AreEqual(register[15], bdfg);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 3, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl1Target0()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState aceg = register.StateVector[0];
            ComputationalBasisState aceh = register.StateVector[1];
            ComputationalBasisState acfg = register.StateVector[2];
            ComputationalBasisState acfh = register.StateVector[3];
            ComputationalBasisState adeg = register.StateVector[4];
            ComputationalBasisState adeh = register.StateVector[5];
            ComputationalBasisState adfg = register.StateVector[6];
            ComputationalBasisState adfh = register.StateVector[7];
            ComputationalBasisState bceg = register.StateVector[8];
            ComputationalBasisState bceh = register.StateVector[9];
            ComputationalBasisState bcfg = register.StateVector[10];
            ComputationalBasisState bcfh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  TC   TC
            //  0123 0123

            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 1100
            //  0101 1101
            //  0110 1110
            //  0111 1111

            //  1000 1000
            //  1001 1001
            //  1010 1010
            //  1011 1011
            //  1100 0100
            //  1101 0101
            //  1110 0110
            //  1111 0111

            //  00  01  10  11
            //  II  XI  II  XI

            //  II (c) XI (c) II (c) XI

            //  ((I (x) I) (c) (X (x) I)) (c) ((I (x) I) (c) (X (x) I))

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH

            //  CNOT(1, 0)
            register.StateVector = _cNotGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], bdeg);
            Assert.AreEqual(register[5], bdeh);
            Assert.AreEqual(register[6], bdfg);
            Assert.AreEqual(register[7], bdfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], adeg);
            Assert.AreEqual(register[13], adeh);
            Assert.AreEqual(register[14], adfg);
            Assert.AreEqual(register[15], adfh);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(1, 0)
            register.StateVector = _cNotGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl1Target2()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState aceg = register.StateVector[0];
            ComputationalBasisState aceh = register.StateVector[1];
            ComputationalBasisState acfg = register.StateVector[2];
            ComputationalBasisState acfh = register.StateVector[3];
            ComputationalBasisState adeg = register.StateVector[4];
            ComputationalBasisState adeh = register.StateVector[5];
            ComputationalBasisState adfg = register.StateVector[6];
            ComputationalBasisState adfh = register.StateVector[7];
            ComputationalBasisState bceg = register.StateVector[8];
            ComputationalBasisState bceh = register.StateVector[9];
            ComputationalBasisState bcfg = register.StateVector[10];
            ComputationalBasisState bcfh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //   CT   CT
            //  0123 0123

            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0110
            //  0101 0111
            //  0110 0100
            //  0111 0101

            //  1000 1000
            //  1001 1001
            //  1010 1010
            //  1011 1011
            //  1100 1110
            //  1101 1111
            //  1110 1100
            //  1111 1101

            //  00  01  10  11
            //  II  XI  II  XI

            //  II (c) XI (c) II (c) XI

            //  ((I (x) I) (c) (X (x) I)) (c) ((I (x) I) (c) (X (x) I))

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH

            //  CNOT(1, 2)
            register.StateVector = _cNotGate.ApplyTo(1, 2, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adfg);
            Assert.AreEqual(register[5], adfh);
            Assert.AreEqual(register[6], adeg);
            Assert.AreEqual(register[7], adeh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdfg);
            Assert.AreEqual(register[13], bdfh);
            Assert.AreEqual(register[14], bdeg);
            Assert.AreEqual(register[15], bdeh);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(1, 2, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl1Target3()
        {
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState aceg = register.StateVector[0];
            ComputationalBasisState aceh = register.StateVector[1];
            ComputationalBasisState acfg = register.StateVector[2];
            ComputationalBasisState acfh = register.StateVector[3];
            ComputationalBasisState adeg = register.StateVector[4];
            ComputationalBasisState adeh = register.StateVector[5];
            ComputationalBasisState adfg = register.StateVector[6];
            ComputationalBasisState adfh = register.StateVector[7];
            ComputationalBasisState bceg = register.StateVector[8];
            ComputationalBasisState bceh = register.StateVector[9];
            ComputationalBasisState bcfg = register.StateVector[10];
            ComputationalBasisState bcfh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  C  T C  T
            //  0123 0123
            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0100
            //  0101 0101
            //  0110 0110
            //  0111 0111

            //  1000 1001
            //  1001 1000
            //  1010 1011
            //  1011 1010
            //  1100 1101
            //  1101 1100
            //  1110 1111
            //  1111 1110

            //  00  01
            //  III IIX

            //  (I (x) I (x) I) (c) (I (x) I (x) X)

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG

            //  CNOT(0, 2)
            register.StateVector = _cNotGate.ApplyTo(0, 3, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceh);
            Assert.AreEqual(register[9], bceg);
            Assert.AreEqual(register[10], bcfh);
            Assert.AreEqual(register[11], bcfg);
            Assert.AreEqual(register[12], bdeh);
            Assert.AreEqual(register[13], bdeg);
            Assert.AreEqual(register[14], bdfh);
            Assert.AreEqual(register[15], bdfg);

            ValidateComputationalStateVector(register.StateVector);

            //  CNOT(0, 1)
            register.StateVector = _cNotGate.ApplyTo(0, 3, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            ValidateComputationalStateVector(register.StateVector);
        }
    }
}
