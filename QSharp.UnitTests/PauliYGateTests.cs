#region Using References

using System;
using System.Numerics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class PauliYGateTests : GateTests
    {
        #region Constructors

        public PauliYGateTests()
        {
            oPauliYGate = new PauliYGate();
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private PauliYGate oPauliYGate;

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void PauliYGate1Qubit()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit() });

            //  A   B
            //  0  -i   -Bi
            //  i   0   Ai

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            //  Y(0)
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oB);
            Assert.AreEqual(oRegister[1], oA);

            Assert.AreEqual(oA.Amplitude.Real, 1);
            Assert.AreEqual(oA.Amplitude.Imaginary, 1);

            Assert.AreEqual(oB.Amplitude.Real, -1);
            Assert.AreEqual(oB.Amplitude.Imaginary, 1);

            //  Reversible

            //  -Bi Ai
            //  0  -i   A
            //  i   0   B

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oA);
            Assert.AreEqual(oRegister[1], oB);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void PauliYGate2QubitPostion0()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  AC  AD  BC  BD
            //  0   0  -i   0   -BCi
            //  0   0   0  -i   -BDi
            //  i   0   0   0   ACi
            //  0   i   0   0   ADi

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  X(0)
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oBC);
            Assert.AreEqual(oRegister[1], oBD);
            Assert.AreEqual(oRegister[2], oAC);
            Assert.AreEqual(oRegister[3], oAD);

            Assert.AreEqual(oAC.Amplitude.Real, 1);
            Assert.AreEqual(oAC.Amplitude.Imaginary, 1);

            Assert.AreEqual(oAD.Amplitude.Real, 1);
            Assert.AreEqual(oAD.Amplitude.Imaginary, 1);
            
            Assert.AreEqual(oBC.Amplitude.Real, -1);
            Assert.AreEqual(oBC.Amplitude.Imaginary, 1);
            
            Assert.AreEqual(oBD.Amplitude.Real, -1);
            Assert.AreEqual(oBD.Amplitude.Imaginary, 1);

            //  Reversible

            //  -BCi -BDi ACi ADi
            //  0    0   -i   0   AC
            //  0    0    0  -i   AD
            //  i    0    0   0   BC
            //  0    i    0   0   BD

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void PauliYGate2QubitPostion1()
        {
            int iPosition = 1;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  AC  AD  BC  BD
            //  0  -i   0   0   -ADi
            //  i   0   0   0   ACi
            //  0   0   0  -i   -BDi
            //  0   0   i   0   BCi

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  Y(1)
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oAD);
            Assert.AreEqual(oRegister[1], oAC);
            Assert.AreEqual(oRegister[2], oBD);
            Assert.AreEqual(oRegister[3], oBC);

            Assert.AreEqual(oAC.Amplitude.Real, 1);
            Assert.AreEqual(oAC.Amplitude.Imaginary, 1);

            Assert.AreEqual(oAD.Amplitude.Real, -1);
            Assert.AreEqual(oAD.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBC.Amplitude.Real, 1);
            Assert.AreEqual(oBC.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBD.Amplitude.Real, -1);
            Assert.AreEqual(oBD.Amplitude.Imaginary, 1);

            //  Reversible

            //  AD  AC  BD  BC
            //  0   1   0   0   AC
            //  1   0   0   0   AD
            //  0   0   0   1   BC
            //  0   0   1   0   BD

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            ValidateComputationalStateVector(oRegister.StateVector);
        }

        [TestMethod]
        public void PauliYGate3QubitPostion0()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0   0   0   0  -1   0   0   0   -BCEi
            //  0   0   0   0   0  -i   0   0   -BCFi
            //  0   0   0   0   0   0  -i   0   -BDEi
            //  0   0   0   0   0   0   0  -i   -BDFi
            //  i   0   0   0   0   0   0   0   ACEi
            //  0   i   0   0   0   0   0   0   ACFi
            //  0   0   i   0   0   0   0   0   ADEi
            //  0   0   0   i   0   0   0   0   ADFi

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  Y(0)
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oBCE);
            Assert.AreEqual(oRegister[1], oBCF);
            Assert.AreEqual(oRegister[2], oBDE);
            Assert.AreEqual(oRegister[3], oBDF);
            Assert.AreEqual(oRegister[4], oACE);
            Assert.AreEqual(oRegister[5], oACF);
            Assert.AreEqual(oRegister[6], oADE);
            Assert.AreEqual(oRegister[7], oADF);

            Assert.AreEqual(oACE.Amplitude.Real, 1);
            Assert.AreEqual(oACE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACF.Amplitude.Real, 1);
            Assert.AreEqual(oACF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADE.Amplitude.Real, 1);
            Assert.AreEqual(oADE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADF.Amplitude.Real, 1);
            Assert.AreEqual(oADF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCE.Amplitude.Real, -1);
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCF.Amplitude.Real, -1);
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDE.Amplitude.Real, -1);
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDF.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 1);

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

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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
        public void PauliYGate3QubitPostion1()
        {
            int iPosition = 1;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0   0  -i   0   0   0   0   0   -ADEi
            //  0   0   0  -i   0   0   0   0   -ADFi
            //  i   0   0   0   0   0   0   0   ACEi
            //  0   i   0   0   0   0   0   0   ACFi
            //  0   0   0   0   0   0  -i   0   -BDEi
            //  0   0   0   0   0   0   0  -i   -BDFi
            //  0   0   0   0   i   0   0   0   BCEi
            //  0   0   0   0   0   i   0   0   BCFi

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  Y(1)
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oADE);
            Assert.AreEqual(oRegister[1], oADF);
            Assert.AreEqual(oRegister[2], oACE);
            Assert.AreEqual(oRegister[3], oACF);
            Assert.AreEqual(oRegister[4], oBDE);
            Assert.AreEqual(oRegister[5], oBDF);
            Assert.AreEqual(oRegister[6], oBCE);
            Assert.AreEqual(oRegister[7], oBCF);

            Assert.AreEqual(oACE.Amplitude.Real, 1);
            Assert.AreEqual(oACE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACF.Amplitude.Real, 1);
            Assert.AreEqual(oACF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADE.Amplitude.Real, -1);
            Assert.AreEqual(oADE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADF.Amplitude.Real, -1);
            Assert.AreEqual(oADF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCE.Amplitude.Real, 1);
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCF.Amplitude.Real, 1);
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDE.Amplitude.Real, -1);
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDF.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 1);

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

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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
        public void PauliYGate3QubitPostion2()
        {
            int iPosition = 2;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0  -i   0   0   0   0   0   0   -ACFi
            //  i   0   0   0   0   0   0   0   ACEi
            //  0   0   0  -i   0   0   0   0   -ADFi
            //  0   0   i   0   0   0   0   0   ADEi
            //  0   0   0   0   0  -i   0   0   -BCFi
            //  0   0   0   0   i   0   0   0   BCEi
            //  0   0   0   0   0   0   0  -i   -BDFi
            //  0   0   0   0   0   0   i   0   BDEi

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  X(2)
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

            Assert.AreEqual(oRegister[0], oACF);
            Assert.AreEqual(oRegister[1], oACE);
            Assert.AreEqual(oRegister[2], oADF);
            Assert.AreEqual(oRegister[3], oADE);
            Assert.AreEqual(oRegister[4], oBCF);
            Assert.AreEqual(oRegister[5], oBCE);
            Assert.AreEqual(oRegister[6], oBDF);
            Assert.AreEqual(oRegister[7], oBDE);

            Assert.AreEqual(oACE.Amplitude.Real, 1);
            Assert.AreEqual(oACE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACF.Amplitude.Real, -1);
            Assert.AreEqual(oACF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADE.Amplitude.Real, 1);
            Assert.AreEqual(oADE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADF.Amplitude.Real, -1);
            Assert.AreEqual(oADF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCE.Amplitude.Real, 1);
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCF.Amplitude.Real, -1);
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDE.Amplitude.Real, 1);
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDF.Amplitude.Real, -1);
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 1);

            //  Reversible

            //  -ACFi ACEi -ADFi  ADEi -BCFi  BCEi -BDFi  BDEi
            //  0    -i     0     0     0     0     0     0   ACE
            //  i     0     0     0     0     0     0     0   ACF
            //  0     0     0    -i     0     0     0     0   ADE
            //  0     0     i     0     0     0     0     0   ADF
            //  0     0     0     0     0    -i     0     0   BCE
            //  0     0     0     0     i     0     0     0   BCF
            //  0     0     0     0     0     0     0    -i   BDE
            //  0     0     0     0     0     0     i     0   BDF

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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
        public void PauliYGate4QubitPostion0()
        {
            int iPosition = 0;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0    0    0    0    0    0    0   -i    0    0    0    0    0    0    0    -BCEGi
            //  0    0    0    0    0    0    0    0    0   -i    0    0    0    0    0    0    -BCEHi
            //  0    0    0    0    0    0    0    0    0    0   -i    0    0    0    0    0    -BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0   -i    0    0    0    0    -BCFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0   -i    0    0    0    -BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -i    0    0    -BDEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -i    0    -BDFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -i    -BDFHi
            //  i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEHi
            //  0    0    i    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFGi
            //  0    0    0    i    0    0    0    0    0    0    0    0    0    0    0    0    ACFHi
            //  0    0    0    0    i    0    0    0    0    0    0    0    0    0    0    0    ADEGi
            //  0    0    0    0    0    i    0    0    0    0    0    0    0    0    0    0    ADEHi
            //  0    0    0    0    0    0    i    0    0    0    0    0    0    0    0    0    ADFGi
            //  0    0    0    0    0    0    0    i    0    0    0    0    0    0    0    0    ADFHi

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
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real, 1);
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACEH.Amplitude.Real, 1);
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFG.Amplitude.Real, 1);
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFH.Amplitude.Real, 1);
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEG.Amplitude.Real, 1);
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEH.Amplitude.Real, 1);
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFG.Amplitude.Real, 1);
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFH.Amplitude.Real, 1);
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEG.Amplitude.Real, -1);
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEH.Amplitude.Real, -1);
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFG.Amplitude.Real, -1);
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFH.Amplitude.Real, -1);
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEG.Amplitude.Real, -1);
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEH.Amplitude.Real, -1);
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 1);

            //  Reversible

            //  -BCEGi -BCEHi -BCFGi -BCFHi -BDEGi -BDEHi -BDFGi -BDFGi ACEGi  ACEHi  ACFGi  ACFHi  ADEGi  ADEHi  ADFGi  ADFHi
            //   0      0      0      0      0      0      0      0    -i      0      0      0      0      0      0      0     ACEG
            //   0      0      0      0      0      0      0      0     0     -i      0      0      0      0      0      0     ACEH
            //   0      0      0      0      0      0      0      0     0      0     -i      0      0      0      0      0     ACFG
            //   0      0      0      0      0      0      0      0     0      0      0     -i      0      0      0      0     ACFH
            //   0      0      0      0      0      0      0      0     0      0      0      0     -i      0      0      0     ADEG
            //   0      0      0      0      0      0      0      0     0      0      0      0      0     -i      0      0     ADEH
            //   0      0      0      0      0      0      0      0     0      0      0      0      0      0     -i      0     ADFG
            //   0      0      0      0      0      0      0      0     0      0      0      0      0      0      0     -i     ADFH
            //   i      0      0      0      0      0      0      0     0      0      0      0      0      0      0      0     BCEG
            //   0      i      0      0      0      0      0      0     0      0      0      0      0      0      0      0     BCEH
            //   0      0      i      0      0      0      0      0     0      0      0      0      0      0      0      0     BCFG
            //   0      0      0      i      0      0      0      0     0      0      0      0      0      0      0      0     BCFH
            //   0      0      0      0      i      0      0      0     0      0      0      0      0      0      0      0     BDEG
            //   0      0      0      0      0      i      0      0     0      0      0      0      0      0      0      0     BDEH
            //   0      0      0      0      0      0      i      0     0      0      0      0      0      0      0      0     BDFG
            //   0      0      0      0      0      0      0      i     0      0      0      0      0      0      0      0     BDFH

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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
        public void PauliYGate4QubitPostion1()
        {
            int iPosition = 1;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0    0    0   -i    0    0    0    0    0    0    0    0    0    0    0    -ADEGi
            //  0    0    0    0    0   -i    0    0    0    0    0    0    0    0    0    0    -ADEHi
            //  0    0    0    0    0    0   -i    0    0    0    0    0    0    0    0    0    -ADFGi
            //  0    0    0    0    0    0    0   -i    0    0    0    0    0    0    0    0    -ADFHi
            //  i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEHi
            //  0    0    i    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFGi
            //  0    0    0    i    0    0    0    0    0    0    0    0    0    0    0    0    ACFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0   -i    0    0    0    -BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -i    0    0    -BDEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -i    0    -BDFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -i    -BDFHi
            //  0    0    0    0    0    0    0    0    i    0    0    0    0    0    0    0    BCEGi
            //  0    0    0    0    0    0    0    0    0    i    0    0    0    0    0    0    BCEHi
            //  0    0    0    0    0    0    0    0    0    0    i    0    0    0    0    0    BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0    i    0    0    0    0    BCFHi

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
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real, 1);
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACEH.Amplitude.Real, 1);
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFG.Amplitude.Real, 1);
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFH.Amplitude.Real, 1);
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEG.Amplitude.Real, -1);
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEH.Amplitude.Real, -1);
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFG.Amplitude.Real, -1);
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFH.Amplitude.Real, -1);
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEG.Amplitude.Real, 1);
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEH.Amplitude.Real, 1);
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFG.Amplitude.Real, 1);
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFH.Amplitude.Real, 1);
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEG.Amplitude.Real, -1);
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEH.Amplitude.Real, -1);
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 1);

            //  Reversible

            //  -ADEGi -ADEHi -ADFGi -ADFHi  ACEGi  ACEHi  ACFGi  ACFHi -BDEGi -BDEHi -BDFGi -BDFHi  BCEGi  BCEHi  BCFGi  BCFHi
            //   0      0      0      0     -i      0      0      0      0      0      0      0      0      0      0      0     -ADEGi
            //   0      0      0      0      0     -i      0      0      0      0      0      0      0      0      0      0     -ADEHi
            //   0      0      0      0      0      0     -i      0      0      0      0      0      0      0      0      0     -ADFGi
            //   0      0      0      0      0      0      0     -i      0      0      0      0      0      0      0      0     -ADFHi
            //   i      0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEGi
            //   0      i      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEHi
            //   0      0      i      0      0      0      0      0      0      0      0      0      0      0      0      0     ACFGi
            //   0      0      0      i      0      0      0      0      0      0      0      0      0      0      0      0     ACFHi
            //   0      0      0      0      0      0      0      0      0      0      0      0     -i      0      0      0     -BDEGi
            //   0      0      0      0      0      0      0      0      0      0      0      0      0     -i      0      0     -BDEHi
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0     -i      0     -BDFGi
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     -i     -BDFHi
            //   0      0      0      0      0      0      0      0      i      0      0      0      0      0      0      0     BCEGi
            //   0      0      0      0      0      0      0      0      0      i      0      0      0      0      0      0     BCEHi
            //   0      0      0      0      0      0      0      0      0      0      i      0      0      0      0      0     BCFGi
            //   0      0      0      0      0      0      0      0      0      0      0      i      0      0      0      0     BCFHi

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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
        public void PauliYGate4QubitPostion2()
        {
            int iPosition = 2;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0   -i    0    0    0    0    0    0    0    0    0    0    0    0    0    -ACFGi
            //  0    0    0   -i    0    0    0    0    0    0    0    0    0    0    0    0    -ACFHi
            //  i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEHi
            //  0    0    0    0    0    0   -i    0    0    0    0    0    0    0    0    0    -ADFGi
            //  0    0    0    0    0    0    0   -i    0    0    0    0    0    0    0    0    -ADFHi
            //  0    0    0    0    i    0    0    0    0    0    0    0    0    0    0    0    ADEGi
            //  0    0    0    0    0    i    0    0    0    0    0    0    0    0    0    0    ADEHi
            //  0    0    0    0    0    0    0    0    0    0   -i    0    0    0    0    0    -BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0   -i    0    0    0    0    -BCFHi
            //  0    0    0    0    0    0    0    0    i    0    0    0    0    0    0    0    BCEGi
            //  0    0    0    0    0    0    0    0    0    i    0    0    0    0    0    0    BCEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -i    0    -BDFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -i    -BDFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    i    0    0    0    BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    i    0    0    BDEHi

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
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real, 1);
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACEH.Amplitude.Real, 1);
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFG.Amplitude.Real, -1);
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFH.Amplitude.Real, -1);
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEG.Amplitude.Real, 1);
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEH.Amplitude.Real, 1);
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFG.Amplitude.Real, -1);
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFH.Amplitude.Real, -1);
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEG.Amplitude.Real, 1);
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEH.Amplitude.Real, 1);
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFG.Amplitude.Real, -1);
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFH.Amplitude.Real, -1);
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEG.Amplitude.Real, 1);
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEH.Amplitude.Real, 1);
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFG.Amplitude.Real, -1);
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 1);

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

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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
        public void PauliYGate4QubitPostion3()
        {
            int iPosition = 3;
            Register oRegister = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0   -i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    -ACEHi
            //  i    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    0    0   -i    0    0    0    0    0    0    0    0    0    0    0    0    -ACFHi
            //  0    0    i    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFGi
            //  0    0    0    0    0   -i    0    0    0    0    0    0    0    0    0    0    -ADEHi
            //  0    0    0    0    i    0    0    0    0    0    0    0    0    0    0    0    ADEGi
            //  0    0    0    0    0    0    0   -i    0    0    0    0    0    0    0    0    -ADFHi
            //  0    0    0    0    0    0    i    0    0    0    0    0    0    0    0    0    ADFGi
            //  0    0    0    0    0    0    0    0    0   -i    0    0    0    0    0    0    -BCEHi
            //  0    0    0    0    0    0    0    0    i    0    0    0    0    0    0    0    BCEGi
            //  0    0    0    0    0    0    0    0    0    0    0   -i    0    0    0    0    -BCFHi
            //  0    0    0    0    0    0    0    0    0    0    i    0    0    0    0    0    BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -i    0    0    -BDEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    i    0    0    0    BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -i    -BDFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    i    0    BDFGi

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
            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real, 1);
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACEH.Amplitude.Real, -1);
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFG.Amplitude.Real, 1);
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oACFH.Amplitude.Real, -1);
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEG.Amplitude.Real, 1);
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADEH.Amplitude.Real, -1);
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFG.Amplitude.Real, 1);
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oADFH.Amplitude.Real, -1);
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEG.Amplitude.Real, 1);
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCEH.Amplitude.Real, -1);
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFG.Amplitude.Real, 1);
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBCFH.Amplitude.Real, -1);
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEG.Amplitude.Real, 1);
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDEH.Amplitude.Real, -1);
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFG.Amplitude.Real, 1);
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 1);

            Assert.AreEqual(oBDFH.Amplitude.Real, -1);
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 1);

            //  Reversible

            //  -ACEHi  ACEGi -ACFHi  ACFGi -ADEHi  ADEGi -ADFHi  ADFGi -BCEHi  BCEGi -BCFHi  BCFGi -BDEHi  BDEGi -BDFHi  BDFGi 
            //   0     -i      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEG
            //   i      0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEH
            //   0      0      0     -i      0      0      0      0      0      0      0      0      0      0      0      0     ACFG
            //   0      0      i      0      0      0      0      0      0      0      0      0      0      0      0      0     ACFH
            //   0      0      0      0      0     -i      0      0      0      0      0      0      0      0      0      0     ADEG
            //   0      0      0      0      i      0      0      0      0      0      0      0      0      0      0      0     ADEH
            //   0      0      0      0      0      0      0     -i      0      0      0      0      0      0      0      0     ADFG
            //   0      0      0      0      0      0      i      0      0      0      0      0      0      0      0      0     ADFH
            //   0      0      0      0      0      0      0      0      0     -i      0      0      0      0      0      0     BCEG
            //   0      0      0      0      0      0      0      0      i      0      0      0      0      0      0      0     BCEH
            //   0      0      0      0      0      0      0      0      0      0      0     -i      0      0      0      0     BCFG
            //   0      0      0      0      0      0      0      0      0      0      i      0      0      0      0      0     BCFH
            //   0      0      0      0      0      0      0      0      0      0      0      0      0     -i      0      0     BDEG
            //   0      0      0      0      0      0      0      0      0      0      0      0      i      0      0      0     BDEH
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     -i     BDFG
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0      i      0     BDFH

            oRegister.StateVector = oPauliYGate.ApplyTo(iPosition, oRegister);

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
