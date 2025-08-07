#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;
using System.Diagnostics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class PauliXGateTests : GateTests
    {
        #region Constructors

        public PauliXGateTests()
        {
            oPauliXGate = new PauliXGate();
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private PauliXGate oPauliXGate;

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void PauliXGate1Qubit()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit() });

            //  > Initial state:
            //  > A|0> + B|1> = (0.687A|0> + 0.727B|1>)

            //  A   B
            //  0   1   = (0 * 0.687A|0>) + (1 * 0.727B|1>) = 0.727B|1>
            //  1   0   = (1 * 0.687A|0>) + (0 * 0.727B|1>) = 0.687A|0>

            //  (A|0> + B|1>) = (1A|0> + 2B|1>)
            //  (C|0> + D|1>) = (3A|0> + 4B|1>)

            //  ()AC|00> + ()AD|01> + ()BC|10> + ()BD|11>

            //  > X_1
            //  > (B|0>) = 0.727|0>
            //  > (A|1>) = 0.687|1>

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            //  X(0)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            //  A|0> mapped to A|1>
            //  B|1> mapped to B|0>
            Assert.AreEqual(oRegister[0], oB);
            Assert.AreEqual(oRegister[1], oA);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible
            //  X(0)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            //  B|0> mapped to B|1>
            //  A|1> mapped to A|0>
            Assert.AreEqual(oRegister[0], oA);
            Assert.AreEqual(oRegister[1], oB);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void PauliXGate2QubitPostion0()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A|00> + B|01> + C|10> + D|11>) = (0.687A|0> + 0.727B|1>)

            //  AC  AD  BC  BD
            //  0   0   1   0   BC
            //  0   0   0   1   BD
            //  1   0   0   0   AC
            //  0   1   0   0   AD

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  X(0)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oBC);
            Assert.AreEqual(oRegister[1], oBD);
            Assert.AreEqual(oRegister[2], oAC);
            Assert.AreEqual(oRegister[3], oAD);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  BC  BD  AC  AD
            //  0   0   1   0   AC
            //  0   0   0   1   AD
            //  1   0   0   0   BC
            //  0   1   0   0   BD

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void PauliXGate2QubitPostion1()
        {
            int iPosition = 1;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A|00> + B|01> + C|10> + D|11>) = (0.687A|0> + 0.727B|1>)

            //  AC  AD  BC  BD
            //  0   1   0   0   AD
            //  1   0   0   0   AC
            //  0   0   0   1   BD
            //  0   0   1   0   BC

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  X(1)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oAD);
            Assert.AreEqual(oRegister[1], oAC);
            Assert.AreEqual(oRegister[2], oBD);
            Assert.AreEqual(oRegister[3], oBC);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  AD  AC  BD  BC
            //  0   1   0   0   AC
            //  1   0   0   0   AD
            //  0   0   0   1   BC
            //  0   0   1   0   BD

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void PauliXGate3QubitPostion0()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B)(C + D)(E + F)
            //  (ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BCF|111>) = (0.687A|0> + 0.727B|1>)

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  000 001 010 011 100 101 110 111
            //  0   0   0   0   1   0   0   0   BCE 100
            //  0   0   0   0   0   1   0   0   BCF 101
            //  0   0   0   0   0   0   1   0   BDE 110
            //  0   0   0   0   0   0   0   1   BDF 111
            //  1   0   0   0   0   0   0   0   ACE 000
            //  0   1   0   0   0   0   0   0   ACF 011
            //  0   0   1   0   0   0   0   0   ADE 010
            //  0   0   0   1   0   0   0   0   ADF 011

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  X(0)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oBCE);
            Assert.AreEqual(oRegister[1], oBCF);
            Assert.AreEqual(oRegister[2], oBDE);
            Assert.AreEqual(oRegister[3], oBDF);
            Assert.AreEqual(oRegister[4], oACE);
            Assert.AreEqual(oRegister[5], oACF);
            Assert.AreEqual(oRegister[6], oADE);
            Assert.AreEqual(oRegister[7], oADF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  BCE BCF BDE BDF ACE ACF ADE ADF
            //  0   0   0   0   1   0   0   0   ACE
            //  0   0   0   0   0   1   0   0   ACF
            //  0   0   0   0   0   0   1   0   ADE
            //  0   0   0   0   0   0   0   1   ADF
            //  1   0   0   0   0   0   0   0   BCE
            //  0   1   0   0   0   0   0   0   BCF
            //  0   0   1   0   0   0   0   0   BDE
            //  0   0   0   1   0   0   0   0   BDF

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

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
        public void PauliXGate3QubitPostion1()
        {
            int iPosition = 1;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B)(C + D)(E + F)
            //  (ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BCF|111>)

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   0   0   0   0   1   0   BDE
            //  0   0   0   0   0   0   0   1   BDF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  X(1)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oADE);
            Assert.AreEqual(oRegister[1], oADF);
            Assert.AreEqual(oRegister[2], oACE);
            Assert.AreEqual(oRegister[3], oACF);
            Assert.AreEqual(oRegister[4], oBDE);
            Assert.AreEqual(oRegister[5], oBDF);
            Assert.AreEqual(oRegister[6], oBCE);
            Assert.AreEqual(oRegister[7], oBCF);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  ADE ADF ACE ACF BDE BDF BCE BCF
            //  0   0   1   0   0   0   0   0   ACE
            //  0   0   0   1   0   0   0   0   ACF
            //  1   0   0   0   0   0   0   0   ADE
            //  0   1   0   0   0   0   0   0   ADF
            //  0   0   0   0   0   0   1   0   BCE
            //  0   0   0   0   0   0   0   1   BCF
            //  0   0   0   0   1   0   0   0   BDE
            //  0   0   0   0   0   1   0   0   BDF

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

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
        public void PauliXGate3QubitPostion2()
        {
            int iPosition = 2;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B)(C + D)(E + F)
            //  (ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BCF|111>)

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0   1   0   0   0   0   0   0   ACF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   0   0   1   BDF
            //  0   0   0   0   0   0   1   0   BDE

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  X(2)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oACF);
            Assert.AreEqual(oRegister[1], oACE);
            Assert.AreEqual(oRegister[2], oADF);
            Assert.AreEqual(oRegister[3], oADE);
            Assert.AreEqual(oRegister[4], oBCF);
            Assert.AreEqual(oRegister[5], oBCE);
            Assert.AreEqual(oRegister[6], oBDF);
            Assert.AreEqual(oRegister[7], oBDE);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  ACF ACE ADF ADE BCF BCE BDF BDE
            //  0   1   0   0   0   0   0   0   ACE
            //  1   0   0   0   0   0   0   0   ACF
            //  0   0   0   1   0   0   0   0   ADE
            //  0   0   1   0   0   0   0   0   ADF
            //  0   0   0   0   0   1   0   0   BCE
            //  0   0   0   0   1   0   0   0   BCF
            //  0   0   0   0   0   0   0   1   BDE
            //  0   0   0   0   0   0   1   0   BDF

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

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
        public void PauliXGate4QubitPostion0()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH

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

            //  X(0)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oBCEG);
            Assert.AreEqual(oRegister[1], oBCEH);
            Assert.AreEqual(oRegister[2], oBCFG);
            Assert.AreEqual(oRegister[3], oBCFH);
            Assert.AreEqual(oRegister[4], oBDEG);
            Assert.AreEqual(oRegister[5], oBDEH);
            Assert.AreEqual(oRegister[6], oBDFG);
            Assert.AreEqual(oRegister[7], oBDFH);
            Assert.AreEqual(oRegister[8], oACEG);
            Assert.AreEqual(oRegister[9], oACEH);
            Assert.AreEqual(oRegister[10], oACFG);
            Assert.AreEqual(oRegister[11], oACFH);
            Assert.AreEqual(oRegister[12], oADEG);
            Assert.AreEqual(oRegister[13], oADEH);
            Assert.AreEqual(oRegister[14], oADFG);
            Assert.AreEqual(oRegister[15], oADFH);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFG ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    ACEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    ACEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    ACFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    ACFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    ADEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    ADEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    ADFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    ADFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    BCEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    BCEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    BCFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    BCFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    BDEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    BDEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    BDFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    BDFH

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

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
        public void PauliXGate4QubitPostion1()
        {
            int iPosition = 1;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
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

            //  X(1)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oADEG);
            Assert.AreEqual(oRegister[1], oADEH);
            Assert.AreEqual(oRegister[2], oADFG);
            Assert.AreEqual(oRegister[3], oADFH);
            Assert.AreEqual(oRegister[4], oACEG);
            Assert.AreEqual(oRegister[5], oACEH);
            Assert.AreEqual(oRegister[6], oACFG);
            Assert.AreEqual(oRegister[7], oACFH);
            Assert.AreEqual(oRegister[8], oBDEG);
            Assert.AreEqual(oRegister[9], oBDEH);
            Assert.AreEqual(oRegister[10], oBDFG);
            Assert.AreEqual(oRegister[11], oBDFH);
            Assert.AreEqual(oRegister[12], oBCEG);
            Assert.AreEqual(oRegister[13], oBCEH);
            Assert.AreEqual(oRegister[14], oBCFG);
            Assert.AreEqual(oRegister[15], oBCFH);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  ADEG ADEH ADFG ADFH ACEG ACEH ACFG ACFH BDEG BDEH BDFG BDFH BCEG BCEH BCFG BCFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
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

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

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
        public void PauliXGate4QubitPostion2()
        {
            int iPosition = 2;
            Register oRegister = new Register(new Qubit[] { new Qubit(1, 1), new Qubit(1, 1), new Qubit(1, 1), new Qubit(1, 1) });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH

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

            //  X(2)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oACFG);
            Assert.AreEqual(oRegister[1], oACFH);
            Assert.AreEqual(oRegister[2], oACEG);
            Assert.AreEqual(oRegister[3], oACEH);
            Assert.AreEqual(oRegister[4], oADFG);
            Assert.AreEqual(oRegister[5], oADFH);
            Assert.AreEqual(oRegister[6], oADEG);
            Assert.AreEqual(oRegister[7], oADEH);
            Assert.AreEqual(oRegister[8], oBCFG);
            Assert.AreEqual(oRegister[9], oBCFH);
            Assert.AreEqual(oRegister[10], oBCEG);
            Assert.AreEqual(oRegister[11], oBCEH);
            Assert.AreEqual(oRegister[12], oBDFG);
            Assert.AreEqual(oRegister[13], oBDFH);
            Assert.AreEqual(oRegister[14], oBDEG);
            Assert.AreEqual(oRegister[15], oBDEH);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  ACFG ACFH ACEG ACEH ADFG ADFH ADEG ADEH BCFG BCFH BCEG BCEH BDFG BDFH BDEG BDEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDFH

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

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
        public void PauliXGate4QubitPostion3()
        {
            int iPosition = 3;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG

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

            //  X(2)
            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oACEH);
            Assert.AreEqual(oRegister[1], oACEG);
            Assert.AreEqual(oRegister[2], oACFH);
            Assert.AreEqual(oRegister[3], oACFG);
            Assert.AreEqual(oRegister[4], oADEH);
            Assert.AreEqual(oRegister[5], oADEG);
            Assert.AreEqual(oRegister[6], oADFH);
            Assert.AreEqual(oRegister[7], oADFG);
            Assert.AreEqual(oRegister[8], oBCEH);
            Assert.AreEqual(oRegister[9], oBCEG);
            Assert.AreEqual(oRegister[10], oBCFH);
            Assert.AreEqual(oRegister[11], oBCFG);
            Assert.AreEqual(oRegister[12], oBDEH);
            Assert.AreEqual(oRegister[13], oBDEG);
            Assert.AreEqual(oRegister[14], oBDFH);
            Assert.AreEqual(oRegister[15], oBDFG);

            ValidateComputationalStateVector(oRegister.StateVector);

            //  Reversible

            //  ACEH ACEG ACFH ACFG ADEH ADEG ADFH ADFG BCEH BCEG BCFH BCFG BDEH BDEG BDFH BDFG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFH

            oRegister.StateVector = oPauliXGate.ApplyTo(iPosition, oRegister);

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
