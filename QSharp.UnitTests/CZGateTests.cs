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
        #region Constructors

        public CZGateTests()
        {
            oCZGate = new CZGate();
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private CZGate oCZGate;

        #endregion

        #region Properties

        #endregion

        #region Methods

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

            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  CZ(0, 1)
            oRegister.StateVector = oCZGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            Assert.AreEqual(oBD.Amplitude.Real, -1);

            //  ValidateComputationalStateVector(oRegister.StateVector);

            //  CZ(0, 1)
            oRegister.StateVector = oCZGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            Assert.AreEqual(oBD.Amplitude.Real, 1);

            ValidateComputationalStateVector(oRegister.StateVector);
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


            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  CZ(1, 0)
            oRegister.StateVector = oCZGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            Assert.AreEqual(oBD.Amplitude.Real, -1);

            //  CZ(1, 0)
            oRegister.StateVector = oCZGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void CZGate3QubitControl0Target1()
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
            oRegister.StateVector = oCZGate.ApplyTo(0, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oBDE.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Real, -1);

            //  CZ(0, 1)
            oRegister.StateVector = oCZGate.ApplyTo(0, 1, oRegister);

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
        public void CZGate3QubitControl0Target2()
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
            //  

            //  CZ(0, 2)
            oRegister.StateVector = oCZGate.ApplyTo(0, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oBCF.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Real, -1);

            //  CZ(0, 2)
            oRegister.StateVector = oCZGate.ApplyTo(0, 2, oRegister);

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
        public void CZGate3QubitControl1Target0()
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
            oRegister.StateVector = oCZGate.ApplyTo(1, 0, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oBDE.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Real, -1);

            //  CZ(1, 0)
            oRegister.StateVector = oCZGate.ApplyTo(1, 0, oRegister);

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
        public void CZGate3QubitControl1Target2()
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
            oRegister.StateVector = oCZGate.ApplyTo(1, 2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oADF.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Real, -1);

            //  CZ(1, 2)
            oRegister.StateVector = oCZGate.ApplyTo(1, 2, oRegister);

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
        public void CZGate3QubitControl2Target0()
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
            oRegister.StateVector = oCZGate.ApplyTo(2, 0, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oBCF.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Real, -1);

            //  CZ(2, 0)
            oRegister.StateVector = oCZGate.ApplyTo(2, 0, oRegister);

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
        public void CZGate3QubitControl2Target1()
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
            oRegister.StateVector = oCZGate.ApplyTo(2, 1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oADF.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Real, -1);

            //  CZ(2, 1)
            oRegister.StateVector = oCZGate.ApplyTo(2, 1, oRegister);

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
        public void CZGate4QubitControl0Target1()
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
            oRegister.StateVector = oCZGate.ApplyTo(0, 1, oRegister);

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

            Assert.AreEqual(oBDEG.Amplitude.Real, -1);
            Assert.AreEqual(oBDEH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Real, -1);

            //  CZ(0, 1)
            oRegister.StateVector = oCZGate.ApplyTo(0, 1, oRegister);

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
        public void CZGate4QubitControl0Target2()
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
            oRegister.StateVector = oCZGate.ApplyTo(0, 2, oRegister);

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

            Assert.AreEqual(oBCFG.Amplitude.Real, -1);
            Assert.AreEqual(oBCFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Real, -1);

            //  CZ(0, 2)
            oRegister.StateVector = oCZGate.ApplyTo(0, 2, oRegister);

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
        public void CZGate4QubitControl0Target3()
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
            oRegister.StateVector = oCZGate.ApplyTo(0, 3, oRegister);

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

            Assert.AreEqual(oBCEH.Amplitude.Real, -1);
            Assert.AreEqual(oBCFH.Amplitude.Real, -1);
            Assert.AreEqual(oBDEH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Real, -1);

            //  CZ(0, 3)
            oRegister.StateVector = oCZGate.ApplyTo(0, 3, oRegister);

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
        public void CZGate4QubitControl1Target0()
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
            oRegister.StateVector = oCZGate.ApplyTo(1, 0, oRegister);

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

            Assert.AreEqual(oBDEG.Amplitude.Real, -1);
            Assert.AreEqual(oBDEH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Real, -1);

            //  CZ(1, 0)
            oRegister.StateVector = oCZGate.ApplyTo(1, 0, oRegister);

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
        public void CZGate4QubitControl1Target2()
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
            oRegister.StateVector = oCZGate.ApplyTo(1, 2, oRegister);

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

            Assert.AreEqual(oADFG.Amplitude.Real, -1);
            Assert.AreEqual(oADFH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Real, -1);

            //  CZ(1, 2)
            oRegister.StateVector = oCZGate.ApplyTo(1, 2, oRegister);

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
        public void CZGate4QubitControl1Target3()
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
            oRegister.StateVector = oCZGate.ApplyTo(0, 3, oRegister);

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

            Assert.AreEqual(oBCEH.Amplitude.Real, -1);
            Assert.AreEqual(oBCFH.Amplitude.Real, -1);
            Assert.AreEqual(oBDEH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Real, -1);

            //  CZ(0, 1)
            oRegister.StateVector = oCZGate.ApplyTo(0, 3, oRegister);

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
