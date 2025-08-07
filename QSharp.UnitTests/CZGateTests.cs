#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class CZGateTests : GateTests
    {
        public CZGateTests()
        {
            _cZGate = new CZGate();
        }

        private readonly CZGate _cZGate;

        [TestMethod]
        public void CZGate2QubitControl0Target1()
        {
            //  AC AD BC BD
            //  1  0  0  0  AC
            //  0  1  0  0  AD
            //  0  0  1  0  BC
            //  0  0  0 -1 -BD

            //  CT
            //  01

            //  00  00
            //  01  01
            //  10  1-0
            //  11  1-1

            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  CZ(0, 1)
            register.StateVector = _cZGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            Assert.AreEqual(bd.Amplitude.Real, -1);

            //  ValidateComputationalStateVector(register.StateVector);

            //  CZ(0, 1)
            register.StateVector = _cZGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            Assert.AreEqual(bd.Amplitude.Real, 1);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CZGate2QubitControl1Target0()
        {
            //  TC
            //  01

            //  00   00
            //  01  -01
            //  10   10
            //  11  -11

            //  AC AD BC BD
            //  1, 0, 0, 0  AC
            //  0, 1, 0, 0  AD
            //  0, 0, 1, 0  BC
            //  0, 0, 0,-1  BD


            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  CZ(1, 0)
            register.StateVector = _cZGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            Assert.AreEqual(bd.Amplitude.Real, -1);

            //  CZ(1, 0)
            register.StateVector = _cZGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void CZGate3QubitControl0Target1()
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

            //  CT  CT
            //  012 012

            //  000 000
            //  001 001
            //  010 010
            //  011 011
            //  100 1-00
            //  101 1-01
            //  110 1-10
            //  111 1-11

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   0   0  -1   0   BDE
            //  0   0   0   0   0   0   0  -1   BDF

            //  CZ(0, 1)
            register.StateVector = _cZGate.ApplyTo(0, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(bde.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Real, -1);

            //  CZ(0, 1)
            register.StateVector = _cZGate.ApplyTo(0, 1, register);

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
        public void CZGate3QubitControl0Target2()
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

            //  C T
            //  012

            //  000 000
            //  001 001
            //  010 010
            //  011 011
            //  100 10-0
            //  101 10-1
            //  110 11-0
            //  111 11-1

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0  -1   0   0   BCF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   0   0  -1   BDF

            //  CZ(0, 2)
            register.StateVector = _cZGate.ApplyTo(0, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(bcf.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Real, -1);

            //  CZ(0, 2)
            register.StateVector = _cZGate.ApplyTo(0, 2, register);

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
        public void CZGate3QubitControl1Target0()
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

            //  TC
            //  012

            //  000  000
            //  001  001
            //  010 -010
            //  011 -011
            //  100  100
            //  101  101
            //  110 -110
            //  111 -111

            //  ??

            //  000 001 010 011 100 101 110 111
            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   0   0  -1   0  -BDE
            //  0   0   0   0   0   0   0  -1  -BDF

            //  CZ(1, 0)
            register.StateVector = _cZGate.ApplyTo(1, 0, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(bde.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Real, -1);

            //  CZ(1, 0)
            register.StateVector = _cZGate.ApplyTo(1, 0, register);

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
        public void CZGate3QubitControl1Target2()
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

            //   CT 
            //  012 

            //  000  000
            //  001  001
            //  010  01-0
            //  011  01-1
            //  100  100
            //  101  101
            //  110  11-0
            //  111  11-1

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE 
            //  0   1   0   0   0   0   0   0   ACF 
            //  0   0   1   0   0   0   0   0   ADE 
            //  0   0   0  -1   0   0   0   0   ADF 
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF 
            //  0   0   0   0   0   0   1   0   BDE 
            //  0   0   0   0   0   0   0  -1   BDF

            //  CZ(1, 2)
            register.StateVector = _cZGate.ApplyTo(1, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(adf.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Real, -1);

            //  CZ(1, 2)
            register.StateVector = _cZGate.ApplyTo(1, 2, register);

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
        public void CZGate3QubitControl2Target0()
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
            //  000  000
            //  001 -001
            //  010  010
            //  011 -011
            //  100  100
            //  101 -101
            //  110  110
            //  111 -111

            //  ??

            //  000 001 010 011 100 101 110 111
            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0  -1   0   0   BCF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   0   0  -1   BDF

            //  CZ(2, 0)
            register.StateVector = _cZGate.ApplyTo(2, 0, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(bcf.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Real, -1);

            //  CZ(2, 0)
            register.StateVector = _cZGate.ApplyTo(2, 0, register);

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
        public void CZGate3QubitControl2Target1()
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

            //  000  000
            //  001  0-01
            //  010  010
            //  011  0-11
            //  100  100
            //  101  1-01
            //  110  110
            //  111  1-11

            //  ??

            //  000 001 010 011 100 101 110 111
            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0  -1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   0   0  -1   BDF

            //  CZ(2, 1)
            register.StateVector = _cZGate.ApplyTo(2, 1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(adf.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Real, -1);

            //  CZ(2, 1)
            register.StateVector = _cZGate.ApplyTo(2, 1, register);

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
        public void CZGate4QubitControl0Target1()
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

            //  1000 1000
            //  1001 1001
            //  1010 1010
            //  1011 1011
            //  1100 1-100
            //  1101 1-101
            //  1110 1-110
            //  1111 1-111

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
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0   -1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    BDFH

            //  CZ(0, 1)
            register.StateVector = _cZGate.ApplyTo(0, 1, register);

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

            Assert.AreEqual(bdeg.Amplitude.Real, -1);
            Assert.AreEqual(bdeh.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Real, -1);

            //  CZ(0, 1)
            register.StateVector = _cZGate.ApplyTo(0, 1, register);

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
        public void CZGate4QubitControl0Target2()
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

            //  1000 1000
            //  1001 1001
            //  1010 10-10
            //  1011 10-11
            //  1100 1100
            //  1101 1101
            //  1110 11-10
            //  1111 11-11

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0   -1    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    0    0   -1    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    BDEH

            //  CZ(0, 2)
            register.StateVector = _cZGate.ApplyTo(0, 2, register);

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

            Assert.AreEqual(bcfg.Amplitude.Real, -1);
            Assert.AreEqual(bcfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Real, -1);

            //  CZ(0, 2)
            register.StateVector = _cZGate.ApplyTo(0, 2, register);

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
        public void CZGate4QubitControl0Target3()
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

            //  C  T  C  T
            //  0123  0123
                      
            //  0000  0000
            //  0001  0001
            //  0010  0010
            //  0011  0011
            //  0100  0100
            //  0101  0101
            //  0110  0110
            //  0111  0111

            //  1000  1000
            //  1001  100-1
            //  1010  1010
            //  1011  101-1
            //  1100  1100
            //  1101  110-1
            //  1110  1110
            //  1111  111-1

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0   -1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0   -1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    BDFH

            //  CZ(0, 3)
            register.StateVector = _cZGate.ApplyTo(0, 3, register);

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

            Assert.AreEqual(bceh.Amplitude.Real, -1);
            Assert.AreEqual(bcfh.Amplitude.Real, -1);
            Assert.AreEqual(bdeh.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Real, -1);

            //  CZ(0, 3)
            register.StateVector = _cZGate.ApplyTo(0, 3, register);

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
        public void CZGate4QubitControl1Target0()
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

            //  TC    TC
            //  0123  0123
                      
            //  0000  0000
            //  0001  0001
            //  0010  0010
            //  0011  0011
            //  0100  0100
            //  0101  0101
            //  0110  0110
            //  0111  0111

            //  1000  1000
            //  1001  1001
            //  1010  1010
            //  1011  1011
            //  1100 -1100
            //  1101 -1101
            //  1110 -1110
            //  1111 -1111

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0   -1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    BDFH

            //  CZ(1, 0)
            register.StateVector = _cZGate.ApplyTo(1, 0, register);

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

            Assert.AreEqual(bdeg.Amplitude.Real, -1);
            Assert.AreEqual(bdeh.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Real, -1);

            //  CZ(1, 0)
            register.StateVector = _cZGate.ApplyTo(1, 0, register);

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
        public void CZGate4QubitControl1Target2()
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

            //   CT    CT
            //  0123  0123
                      
            //  0000  0000
            //  0001  0001
            //  0010  0010
            //  0011  0011
            //  0100  0100
            //  0101  0101
            //  0110  01-10
            //  0111  01-11
                      
            //  1000  1000
            //  1001  1001
            //  1010  1010
            //  1011  1011
            //  1100  1100
            //  1101  1101
            //  1110  11-10
            //  1111  11-11

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0   -1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0   -1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    BDFH

            //  CZ(1, 2)
            register.StateVector = _cZGate.ApplyTo(1, 2, register);

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

            Assert.AreEqual(adfg.Amplitude.Real, -1);
            Assert.AreEqual(adfh.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Real, -1);

            //  CZ(1, 2)
            register.StateVector = _cZGate.ApplyTo(1, 2, register);

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
        public void CZGate4QubitControl1Target3()
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

            //  C  T  C  T
            //  0123  0123
            //  0000  0000
            //  0001  0001
            //  0010  0010
            //  0011  0011
            //  0100  0100
            //  0101  0101
            //  0110  0110
            //  0111  0111

            //  1000  1000
            //  1001  100-1
            //  1010  1010
            //  1011  101-1
            //  1100  1100
            //  1101  110-1
            //  1110  1110
            //  1111  111-1

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0   -1    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0   -1    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -1    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -1    BDFG

            //  CZ(0, 2)
            register.StateVector = _cZGate.ApplyTo(0, 3, register);

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

            Assert.AreEqual(bceh.Amplitude.Real, -1);
            Assert.AreEqual(bcfh.Amplitude.Real, -1);
            Assert.AreEqual(bdeh.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Real, -1);

            //  CZ(0, 1)
            register.StateVector = _cZGate.ApplyTo(0, 3, register);

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
