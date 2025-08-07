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
        #region Constructors

        public CNotGateTests()
        {
            oCNotGate = new CNotGate();
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private CNotGate oCNotGate;

        #endregion

        #region Properties

        #endregion

        #region Methods

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

            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBD);
            Assert.AreEqual(oRegister[3], oBC);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            ValidateComputationalStateVector(oRegister.StateVector);
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


            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  CNOT(1, 0)
            oRegister.StateVector = oCNotGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oBD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oAD);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(1, 0)
            oRegister.StateVector = oCNotGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CNotGate3QubitControl0Target1()
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
            oRegister.StateVector = oCNotGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBDE);
            Assert.AreEqual(oRegister[5], oBDF);
            Assert.AreEqual(oRegister[6], oBCE);
            Assert.AreEqual(oRegister[7], oBCF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 1, oRegister);

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
        public void CNotGate3QubitControl0Target2()
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
            oRegister.StateVector = oCNotGate.ApplyTo(0, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCF);
            Assert.AreEqual(oRegister[5], oBCE);
            Assert.AreEqual(oRegister[6], oBDF);
            Assert.AreEqual(oRegister[7], oBDE);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 2)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 2, oRegister);

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
        public void CNotGate3QubitControl1Target0()
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
            oRegister.StateVector = oCNotGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oBDE);
            Assert.AreEqual(oRegister[3], oBDF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oADE);
            Assert.AreEqual(oRegister[7], oADF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(1, 0)
            oRegister.StateVector = oCNotGate.ApplyTo(1, 0, oRegister);

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
        public void CNotGate3QubitControl1Target2()
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
            oRegister.StateVector = oCNotGate.ApplyTo(1, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADF);
            Assert.AreEqual(oRegister[3], oADE);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDF);
            Assert.AreEqual(oRegister[7], oBDE);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(1, 2)
            oRegister.StateVector = oCNotGate.ApplyTo(1, 2, oRegister);

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
        public void CNotGate3QubitControl2Target0()
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
            oRegister.StateVector = oCNotGate.ApplyTo(2, 0, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oBCF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oBDF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oACF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oADF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(2, 0)
            oRegister.StateVector = oCNotGate.ApplyTo(2, 0, oRegister);

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
        public void CNotGate3QubitControl2Target1()
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
            oRegister.StateVector = oCNotGate.ApplyTo(2, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oADF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oACF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBDF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBCF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(2, 0)
            oRegister.StateVector = oCNotGate.ApplyTo(2, 1, oRegister);

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
        public void CNotGate4QubitControl0Target1()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACEG = oRegister.StateVector[0];
            ComputationalBasisState oACEH = oRegister.StateVector[1];
            ComputationalBasisState oACFG = oRegister.StateVector[2];
            ComputationalBasisState oACFH = oRegister.StateVector[3];
            ComputationalBasisState oADEG = oRegister.StateVector[4];
            ComputationalBasisState oADEH = oRegister.StateVector[5];
            ComputationalBasisState oADFG = oRegister.StateVector[6];
            ComputationalBasisState oADFH = oRegister.StateVector[7];
            ComputationalBasisState oBCEG = oRegister.StateVector[8];
            ComputationalBasisState oBCEH = oRegister.StateVector[9];
            ComputationalBasisState oBCFG = oRegister.StateVector[10];
            ComputationalBasisState oBCFH = oRegister.StateVector[11];
            ComputationalBasisState oBDEG = oRegister.StateVector[12];
            ComputationalBasisState oBDEH = oRegister.StateVector[13];
            ComputationalBasisState oBDFG = oRegister.StateVector[14];
            ComputationalBasisState oBDFH = oRegister.StateVector[15];

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
            oRegister.StateVector = oCNotGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBDEG);
            Assert.AreEqual(oRegister[9], oBDEH);
            Assert.AreEqual(oRegister[10], oBDFG);
            Assert.AreEqual(oRegister[11], oBDFH);
            Assert.AreEqual(oRegister[12], oBCEG);
            Assert.AreEqual(oRegister[13], oBCEH);
            Assert.AreEqual(oRegister[14], oBCFG);
            Assert.AreEqual(oRegister[15], oBCFH);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oBDEG);
            Assert.AreEqual(oRegister[13], oBDEH);
            Assert.AreEqual(oRegister[14], oBDFG);
            Assert.AreEqual(oRegister[15], oBDFH);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl0Target2()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACEG = oRegister.StateVector[0];
            ComputationalBasisState oACEH = oRegister.StateVector[1];
            ComputationalBasisState oACFG = oRegister.StateVector[2];
            ComputationalBasisState oACFH = oRegister.StateVector[3];
            ComputationalBasisState oADEG = oRegister.StateVector[4];
            ComputationalBasisState oADEH = oRegister.StateVector[5];
            ComputationalBasisState oADFG = oRegister.StateVector[6];
            ComputationalBasisState oADFH = oRegister.StateVector[7];
            ComputationalBasisState oBCEG = oRegister.StateVector[8];
            ComputationalBasisState oBCEH = oRegister.StateVector[9];
            ComputationalBasisState oBCFG = oRegister.StateVector[10];
            ComputationalBasisState oBCFH = oRegister.StateVector[11];
            ComputationalBasisState oBDEG = oRegister.StateVector[12];
            ComputationalBasisState oBDEH = oRegister.StateVector[13];
            ComputationalBasisState oBDFG = oRegister.StateVector[14];
            ComputationalBasisState oBDFH = oRegister.StateVector[15];

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
            oRegister.StateVector = oCNotGate.ApplyTo(0, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCFG);
            Assert.AreEqual(oRegister[9], oBCFH);
            Assert.AreEqual(oRegister[10], oBCEG);
            Assert.AreEqual(oRegister[11], oBCEH);
            Assert.AreEqual(oRegister[12], oBDFG);
            Assert.AreEqual(oRegister[13], oBDFH);
            Assert.AreEqual(oRegister[14], oBDEG);
            Assert.AreEqual(oRegister[15], oBDEH);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oBDEG);
            Assert.AreEqual(oRegister[13], oBDEH);
            Assert.AreEqual(oRegister[14], oBDFG);
            Assert.AreEqual(oRegister[15], oBDFH);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl0Target3()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACEG = oRegister.StateVector[0];
            ComputationalBasisState oACEH = oRegister.StateVector[1];
            ComputationalBasisState oACFG = oRegister.StateVector[2];
            ComputationalBasisState oACFH = oRegister.StateVector[3];
            ComputationalBasisState oADEG = oRegister.StateVector[4];
            ComputationalBasisState oADEH = oRegister.StateVector[5];
            ComputationalBasisState oADFG = oRegister.StateVector[6];
            ComputationalBasisState oADFH = oRegister.StateVector[7];
            ComputationalBasisState oBCEG = oRegister.StateVector[8];
            ComputationalBasisState oBCEH = oRegister.StateVector[9];
            ComputationalBasisState oBCFG = oRegister.StateVector[10];
            ComputationalBasisState oBCFH = oRegister.StateVector[11];
            ComputationalBasisState oBDEG = oRegister.StateVector[12];
            ComputationalBasisState oBDEH = oRegister.StateVector[13];
            ComputationalBasisState oBDFG = oRegister.StateVector[14];
            ComputationalBasisState oBDFH = oRegister.StateVector[15];

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
            oRegister.StateVector = oCNotGate.ApplyTo(0, 3, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEH);
            Assert.AreEqual(oRegister[9], oBCEG);
            Assert.AreEqual(oRegister[10], oBCFH);
            Assert.AreEqual(oRegister[11], oBCFG);
            Assert.AreEqual(oRegister[12], oBDEH);
            Assert.AreEqual(oRegister[13], oBDEG);
            Assert.AreEqual(oRegister[14], oBDFH);
            Assert.AreEqual(oRegister[15], oBDFG);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 3, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oBDEG);
            Assert.AreEqual(oRegister[13], oBDEH);
            Assert.AreEqual(oRegister[14], oBDFG);
            Assert.AreEqual(oRegister[15], oBDFH);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl1Target0()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACEG = oRegister.StateVector[0];
            ComputationalBasisState oACEH = oRegister.StateVector[1];
            ComputationalBasisState oACFG = oRegister.StateVector[2];
            ComputationalBasisState oACFH = oRegister.StateVector[3];
            ComputationalBasisState oADEG = oRegister.StateVector[4];
            ComputationalBasisState oADEH = oRegister.StateVector[5];
            ComputationalBasisState oADFG = oRegister.StateVector[6];
            ComputationalBasisState oADFH = oRegister.StateVector[7];
            ComputationalBasisState oBCEG = oRegister.StateVector[8];
            ComputationalBasisState oBCEH = oRegister.StateVector[9];
            ComputationalBasisState oBCFG = oRegister.StateVector[10];
            ComputationalBasisState oBCFH = oRegister.StateVector[11];
            ComputationalBasisState oBDEG = oRegister.StateVector[12];
            ComputationalBasisState oBDEH = oRegister.StateVector[13];
            ComputationalBasisState oBDFG = oRegister.StateVector[14];
            ComputationalBasisState oBDFH = oRegister.StateVector[15];

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
            oRegister.StateVector = oCNotGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oBDEG);
            Assert.AreEqual(oRegister[5], oBDEH);
            Assert.AreEqual(oRegister[6], oBDFG);
            Assert.AreEqual(oRegister[7], oBDFH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oADEG);
            Assert.AreEqual(oRegister[13], oADEH);
            Assert.AreEqual(oRegister[14], oADFG);
            Assert.AreEqual(oRegister[15], oADFH);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(1, 0)
            oRegister.StateVector = oCNotGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oBDEG);
            Assert.AreEqual(oRegister[13], oBDEH);
            Assert.AreEqual(oRegister[14], oBDFG);
            Assert.AreEqual(oRegister[15], oBDFH);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl1Target2()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACEG = oRegister.StateVector[0];
            ComputationalBasisState oACEH = oRegister.StateVector[1];
            ComputationalBasisState oACFG = oRegister.StateVector[2];
            ComputationalBasisState oACFH = oRegister.StateVector[3];
            ComputationalBasisState oADEG = oRegister.StateVector[4];
            ComputationalBasisState oADEH = oRegister.StateVector[5];
            ComputationalBasisState oADFG = oRegister.StateVector[6];
            ComputationalBasisState oADFH = oRegister.StateVector[7];
            ComputationalBasisState oBCEG = oRegister.StateVector[8];
            ComputationalBasisState oBCEH = oRegister.StateVector[9];
            ComputationalBasisState oBCFG = oRegister.StateVector[10];
            ComputationalBasisState oBCFH = oRegister.StateVector[11];
            ComputationalBasisState oBDEG = oRegister.StateVector[12];
            ComputationalBasisState oBDEH = oRegister.StateVector[13];
            ComputationalBasisState oBDFG = oRegister.StateVector[14];
            ComputationalBasisState oBDFH = oRegister.StateVector[15];

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
            oRegister.StateVector = oCNotGate.ApplyTo(1, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADFG);
            Assert.AreEqual(oRegister[5], oADFH);
            Assert.AreEqual(oRegister[6], oADEG);
            Assert.AreEqual(oRegister[7], oADEH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oBDFG);
            Assert.AreEqual(oRegister[13], oBDFH);
            Assert.AreEqual(oRegister[14], oBDEG);
            Assert.AreEqual(oRegister[15], oBDEH);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(1, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oBDEG);
            Assert.AreEqual(oRegister[13], oBDEH);
            Assert.AreEqual(oRegister[14], oBDFG);
            Assert.AreEqual(oRegister[15], oBDFH);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CNotGate4QubitControl1Target3()
        {
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oACEG = oRegister.StateVector[0];
            ComputationalBasisState oACEH = oRegister.StateVector[1];
            ComputationalBasisState oACFG = oRegister.StateVector[2];
            ComputationalBasisState oACFH = oRegister.StateVector[3];
            ComputationalBasisState oADEG = oRegister.StateVector[4];
            ComputationalBasisState oADEH = oRegister.StateVector[5];
            ComputationalBasisState oADFG = oRegister.StateVector[6];
            ComputationalBasisState oADFH = oRegister.StateVector[7];
            ComputationalBasisState oBCEG = oRegister.StateVector[8];
            ComputationalBasisState oBCEH = oRegister.StateVector[9];
            ComputationalBasisState oBCFG = oRegister.StateVector[10];
            ComputationalBasisState oBCFH = oRegister.StateVector[11];
            ComputationalBasisState oBDEG = oRegister.StateVector[12];
            ComputationalBasisState oBDEH = oRegister.StateVector[13];
            ComputationalBasisState oBDFG = oRegister.StateVector[14];
            ComputationalBasisState oBDFH = oRegister.StateVector[15];

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
            oRegister.StateVector = oCNotGate.ApplyTo(0, 3, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEH);
            Assert.AreEqual(oRegister[9], oBCEG);
            Assert.AreEqual(oRegister[10], oBCFH);
            Assert.AreEqual(oRegister[11], oBCFG);
            Assert.AreEqual(oRegister[12], oBDEH);
            Assert.AreEqual(oRegister[13], oBDEG);
            Assert.AreEqual(oRegister[14], oBDFH);
            Assert.AreEqual(oRegister[15], oBDFG);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  CNOT(0, 1)
            oRegister.StateVector = oCNotGate.ApplyTo(0, 3, oRegister);

            Assert.AreEqual(oRegister[0], oACEG);
            Assert.AreEqual(oRegister[1], oACEH);
            Assert.AreEqual(oRegister[2], oACFG);
            Assert.AreEqual(oRegister[3], oACFH);
            Assert.AreEqual(oRegister[4], oADEG);
            Assert.AreEqual(oRegister[5], oADEH);
            Assert.AreEqual(oRegister[6], oADFG);
            Assert.AreEqual(oRegister[7], oADFH);
            Assert.AreEqual(oRegister[8], oBCEG);
            Assert.AreEqual(oRegister[9], oBCEH);
            Assert.AreEqual(oRegister[10], oBCFG);
            Assert.AreEqual(oRegister[11], oBCFH);
            Assert.AreEqual(oRegister[12], oBDEG);
            Assert.AreEqual(oRegister[13], oBDEH);
            Assert.AreEqual(oRegister[14], oBDFG);
            Assert.AreEqual(oRegister[15], oBDFH);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        #endregion

        #region Delegates

        #endregion
    }
}
