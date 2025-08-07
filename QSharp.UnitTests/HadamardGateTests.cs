#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;
using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class HadamardGateTests : GateTests
    {
        #region Constructors

        public HadamardGateTests()
        {
            oHadamardGate = new HadamardGate();
            dOneRootTwo = (1 / 2.SquareRoot());
        }

        #endregion

        #region Constants

        public const int DecimalRoundingPlaces = 10;

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields
        
        private HadamardGate oHadamardGate;
        private double dOneRootTwo;

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void HadamardGate1Qubit()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            //  A   B
            //  1   1   A + B
            //  1  -1   A - B

            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

            Assert.AreEqual(oRegister[0], oA);
            Assert.AreEqual(oRegister[1], oB);

            Assert.AreEqual(oA.Amplitude.Real, ((dQubit1Alpha + dQubit1Beta) * dOneRootTwo));
            Assert.AreEqual(oA.Amplitude.Imaginary, 0);

            Assert.AreEqual(oB.Amplitude.Real, ((dQubit1Alpha - dQubit1Beta) * dOneRootTwo));
            Assert.AreEqual(oB.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

            Assert.AreEqual(oRegister[0], oA);
            Assert.AreEqual(oRegister[1], oB);

            Assert.AreEqual(oA.Amplitude.Real.Round(DecimalRoundingPlaces), dQubit1Alpha);
            Assert.AreEqual(oA.Amplitude.Imaginary, 0);

            Assert.AreEqual(oB.Amplitude.Real.Round(DecimalRoundingPlaces), dQubit1Beta);
            Assert.AreEqual(oB.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate2QubitPosition0()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  (A + B) (x) (C + D)

            //  AC 0.594
            //  AD 0.098
            //  BC 0.445
            //  BD 0.074

            double dAC = oAC.Amplitude.Real;
            double dAD = oAD.Amplitude.Real;
            double dBC = oBC.Amplitude.Real;
            double dBD = oBD.Amplitude.Real;

            //  AC  AD  BC  BD
            //  1   0   1   0   AC + BC
            //  0   1   0   1   AD + BD
            //  1   0  -1   0   AC - BC
            //  0   1   0  -1   AD - BD

            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), ((dAC + dBC) * dOneRootTwo).Round(10));
            Assert.AreEqual(oAC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oAD.Amplitude.Real.Round(10), ((dAD + dBD) * dOneRootTwo).Round(10));
            Assert.AreEqual(oAD.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBC.Amplitude.Real.Round(10), ((dAC - dBC) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBD.Amplitude.Real.Round(10), ((dAD - dBD) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBD.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            Assert.AreEqual(oAC.Amplitude.Real.Round(DecimalRoundingPlaces), dAC.Round(10));
            Assert.AreEqual(oAC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oAD.Amplitude.Real.Round(DecimalRoundingPlaces), dAD.Round(10));
            Assert.AreEqual(oAD.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBC.Amplitude.Real.Round(DecimalRoundingPlaces), dBC.Round(10));
            Assert.AreEqual(oBC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBD.Amplitude.Real.Round(DecimalRoundingPlaces), dBD.Round(10));
            Assert.AreEqual(oBD.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate2QubitPosition1()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  (A + B) (x) (C + D)

            //  AC 0.594
            //  AD 0.098
            //  BC 0.445
            //  BD 0.074

            double dAC = oAC.Amplitude.Real;
            double dAD = oAD.Amplitude.Real;
            double dBC = oBC.Amplitude.Real;
            double dBD = oBD.Amplitude.Real;

            //  AC  AD  BC  BD
            //  1   1   0   0   AC + AD
            //  1  -1   0   0   AC - AD
            //  0   0   1   1   BC + BD
            //  0   0   1  -1   BC - BD

            //  H(1)
            oRegister.StateVector = oHadamardGate.ApplyTo(1, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), ((dAC + dAD) * dOneRootTwo).Round(10));
            Assert.AreEqual(oAC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oAD.Amplitude.Real.Round(10), ((dAC - dAD) * dOneRootTwo).Round(10));
            Assert.AreEqual(oAD.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBC.Amplitude.Real.Round(10), ((dBC + dBD) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBD.Amplitude.Real.Round(10), ((dBC - dBD) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBD.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(1, oRegister);

            Assert.AreEqual(oRegister[0], oAC);
            Assert.AreEqual(oRegister[1], oAD);
            Assert.AreEqual(oRegister[2], oBC);
            Assert.AreEqual(oRegister[3], oBD);

            Assert.AreEqual(oAC.Amplitude.Real.Round(DecimalRoundingPlaces), dAC.Round(10));
            Assert.AreEqual(oAC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oAD.Amplitude.Real.Round(DecimalRoundingPlaces), dAD.Round(10));
            Assert.AreEqual(oAD.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBC.Amplitude.Real.Round(DecimalRoundingPlaces), dBC.Round(10));
            Assert.AreEqual(oBC.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBD.Amplitude.Real.Round(DecimalRoundingPlaces), dBD.Round(10));
            Assert.AreEqual(oBD.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate3QubitPosition0()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;
            double dQubit3Alpha = 0.032;
            double dQubit3Beta = -0.47;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta), new Qubit(dQubit3Alpha, dQubit3Beta) });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  (A + B) (x) (C + D) (x) (E + F)

            double dACE = oACE.Amplitude.Real;
            double dACF = oACF.Amplitude.Real;
            double dADE = oADE.Amplitude.Real;
            double dADF = oADF.Amplitude.Real;
            double dBCE = oBCE.Amplitude.Real;
            double dBCF = oBCF.Amplitude.Real;
            double dBDE = oBDE.Amplitude.Real;
            double dBDF = oBDF.Amplitude.Real;

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   1   0   0   0   ACE + BCE
            //  0   1   0   0   0   1   0   0   ACF + BCF
            //  0   0   1   0   0   0   1   0   ADE + BDE
            //  0   0   0   1   0   0   0   1   ADF + BDF
            //  1   0   0   0  -1   0   0   0   ACE - BCE
            //  0   1   0   0   0  -1   0   0   ACF - BCF
            //  0   0   1   0   0   0  -1   0   ADE - BDE
            //  0   0   0   1   0   0   0  -1   ADF - BCF

            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), ((dACE + dBCE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACF.Amplitude.Real.Round(10), ((dACF + dBCF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADE.Amplitude.Real.Round(10), ((dADE + dBDE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADF.Amplitude.Real.Round(10), ((dADF + dBDF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), ((dACE - dBCE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), ((dACF - dBCF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), ((dADE - dBDE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), ((dADF - dBDF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oACF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oADF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate3QubitPosition1()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;
            double dQubit3Alpha = 0.032;
            double dQubit3Beta = -0.47;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta), new Qubit(dQubit3Alpha, dQubit3Beta) });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  (A + B) (x) (C + D) (x) (E + F)

            double dACE = oACE.Amplitude.Real;
            double dACF = oACF.Amplitude.Real;
            double dADE = oADE.Amplitude.Real;
            double dADF = oADF.Amplitude.Real;
            double dBCE = oBCE.Amplitude.Real;
            double dBCF = oBCF.Amplitude.Real;
            double dBDE = oBDE.Amplitude.Real;
            double dBDF = oBDF.Amplitude.Real;

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   1   0   0   0   0   0   ACE + ADE
            //  0   1   0   1   0   0   0   0   ACF + ADF
            //  1   0  -1   0   0   0   0   0   ACE - ADE
            //  0   1   0  -1   0   0   0   0   ACF - ADF
            //  0   0   0   0   1   0   1   0   BCE + BDE
            //  0   0   0   0   0   1   0   1   BCF + BDF
            //  0   0   0   0   1   0  -1   0   BCE - BDE
            //  0   0   0   0   0   1   0  -1   BCF - BDF

            //  H(1)
            oRegister.StateVector = oHadamardGate.ApplyTo(1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), ((dACE + dADE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACF.Amplitude.Real.Round(10), ((dACF + dADF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADE.Amplitude.Real.Round(10), ((dACE - dADE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADF.Amplitude.Real.Round(10), ((dACF - dADF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), ((dBCE + dBDE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), ((dBCF + dBDF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), ((dBCE - dBDE) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), ((dBCF - dBDF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(1)
            oRegister.StateVector = oHadamardGate.ApplyTo(1, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oACF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oADF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate3QubitPosition2()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;
            double dQubit3Alpha = 0.032;
            double dQubit3Beta = -0.47;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta), new Qubit(dQubit3Alpha, dQubit3Beta) });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  (A + B) (x) (C + D) (x) (E + F)

            double dACE = oACE.Amplitude.Real;
            double dACF = oACF.Amplitude.Real;
            double dADE = oADE.Amplitude.Real;
            double dADF = oADF.Amplitude.Real;
            double dBCE = oBCE.Amplitude.Real;
            double dBCF = oBCF.Amplitude.Real;
            double dBDE = oBDE.Amplitude.Real;
            double dBDF = oBDF.Amplitude.Real;

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   1   0   0   0   0   0   0   ACE + ACF
            //  1  -1   0   0   0   0   0   0   ACE - ACF
            //  0   0   1   1   0   0   0   0   ADE + ADF
            //  0   0   1  -1   0   0   0   0   ADE - ADF
            //  0   0   0   0   1   1   0   0   BCE + BCF
            //  0   0   0   0   1  -1   0   0   BCE - BCF
            //  0   0   0   0   0   0   1   1   BDE + BDF
            //  0   0   0   0   0   0   1  -1   BDE - BDF

            //  H(2)
            oRegister.StateVector = oHadamardGate.ApplyTo(2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), ((dACE + dACF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACF.Amplitude.Real.Round(10), ((dACE - dACF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADE.Amplitude.Real.Round(10), ((dADE + dADF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADF.Amplitude.Real.Round(10), ((dADE - dADF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), ((dBCE + dBCF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), ((dBCE - dBCF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), ((dBDE + dBDF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), ((dBDE - dBDF) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(2)
            oRegister.StateVector = oHadamardGate.ApplyTo(2, oRegister);

            Assert.AreEqual(oRegister[0], oACE);
            Assert.AreEqual(oRegister[1], oACF);
            Assert.AreEqual(oRegister[2], oADE);
            Assert.AreEqual(oRegister[3], oADF);
            Assert.AreEqual(oRegister[4], oBCE);
            Assert.AreEqual(oRegister[5], oBCF);
            Assert.AreEqual(oRegister[6], oBDE);
            Assert.AreEqual(oRegister[7], oBDF);

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oACF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oADF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition0()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;
            double dQubit3Alpha = 0.032;
            double dQubit3Beta = -0.417;
            double dQubit4Alpha = 0.432;
            double dQubit4Beta = -0.902343;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta), new Qubit(dQubit3Alpha, dQubit3Beta), new Qubit(dQubit4Alpha, dQubit4Beta) });

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

            //  (A + B) (x) (C + D) (x) (E + F)

            double dACEG = oACEG.Amplitude.Real;
            double dACEH = oACEH.Amplitude.Real;
            double dACFG = oACFG.Amplitude.Real;
            double dACFH = oACFH.Amplitude.Real;
            double dADEG = oADEG.Amplitude.Real;
            double dADEH = oADEH.Amplitude.Real;
            double dADFG = oADFG.Amplitude.Real;
            double dADFH = oADFH.Amplitude.Real;
            double dBCEG = oBCEG.Amplitude.Real;
            double dBCEH = oBCEH.Amplitude.Real;
            double dBCFG = oBCFG.Amplitude.Real;
            double dBCFH = oBCFH.Amplitude.Real;
            double dBDEG = oBDEG.Amplitude.Real;
            double dBDEH = oBDEH.Amplitude.Real;
            double dBDFG = oBDFG.Amplitude.Real;
            double dBDFH = oBDFH.Amplitude.Real;

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    ACEG + BCEG
            //  0    1    0    0    0    0    0    0    0    1    0    0    0    0    0    0    ACEH + BCEH
            //  0    0    1    0    0    0    0    0    0    0    1    0    0    0    0    0    ACFG + BCFG
            //  0    0    0    1    0    0    0    0    0    0    0    1    0    0    0    0    ACFH + BCFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    1    0    0    0    ADEG + BDEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    1    0    0    ADEH + BDEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    1    0    ADFG + BDFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    1    ADFH + BDFH
            //  1    0    0    0    0    0    0    0   -1    0    0    0    0    0    0    0    ACEG - BCEG
            //  0    1    0    0    0    0    0    0    0   -1    0    0    0    0    0    0    ACEH - BCEH
            //  0    0    1    0    0    0    0    0    0    0   -1    0    0    0    0    0    ACFG - BCFG
            //  0    0    0    1    0    0    0    0    0    0    0   -1    0    0    0    0    ACFH - BCFH
            //  0    0    0    0    1    0    0    0    0    0    0    0   -1    0    0    0    ADEG - BDEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0   -1    0    0    ADEH - BDEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0   -1    0    ADFG - BDFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0   -1    ADFH - BDFH

            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), ((dACEG + dBCEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), ((dACEH + dBCEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), ((dACFG + dBCFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), ((dACFH + dBCFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), ((dADEG + dBDEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), ((dADEH + dBDEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), ((dADFG + dBDFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), ((dADFH + dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), ((dACEG - dBCEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), ((dACEH - dBCEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), ((dACFG - dBCFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), ((dACFH - dBCFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), ((dADEG - dBDEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), ((dADEH - dBDEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), ((dADFG - dBDFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), ((dADFH - dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(0, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition1()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;
            double dQubit3Alpha = 0.032;
            double dQubit3Beta = -0.417;
            double dQubit4Alpha = 0.432;
            double dQubit4Beta = -0.902343;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta), new Qubit(dQubit3Alpha, dQubit3Beta), new Qubit(dQubit4Alpha, dQubit4Beta) });

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

            //  (A + B) (x) (C + D) (x) (E + F)

            double dACEG = oACEG.Amplitude.Real;
            double dACEH = oACEH.Amplitude.Real;
            double dACFG = oACFG.Amplitude.Real;
            double dACFH = oACFH.Amplitude.Real;
            double dADEG = oADEG.Amplitude.Real;
            double dADEH = oADEH.Amplitude.Real;
            double dADFG = oADFG.Amplitude.Real;
            double dADFH = oADFH.Amplitude.Real;
            double dBCEG = oBCEG.Amplitude.Real;
            double dBCEH = oBCEH.Amplitude.Real;
            double dBCFG = oBCFG.Amplitude.Real;
            double dBCFH = oBCFH.Amplitude.Real;
            double dBDEG = oBDEG.Amplitude.Real;
            double dBDEH = oBDEH.Amplitude.Real;
            double dBDFG = oBDFG.Amplitude.Real;
            double dBDFH = oBDFH.Amplitude.Real;

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ACEG + ADEG
            //  0    1    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ACEH + ADEH
            //  0    0    1    0    0    0    1    0    0    0    0    0    0    0    0    0    ACFG + ADFG
            //  0    0    0    1    0    0    0    1    0    0    0    0    0    0    0    0    ACFH + ADFH
            //  1    0    0    0   -1    0    0    0    0    0    0    0    0    0    0    0    ACEG - ADEG
            //  0    1    0    0    0   -1    0    0    0    0    0    0    0    0    0    0    ACEH - ADEH
            //  0    0    1    0    0    0   -1    0    0    0    0    0    0    0    0    0    ACFG - ADFG
            //  0    0    0    1    0    0    0   -1    0    0    0    0    0    0    0    0    ACFH - ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    1    0    0    0    BCEG + NDEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    1    0    0    BCEH + BDEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    1    0    BCFG + BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    1    BCFH + BDFH
            //  0    0    0    0    0    0    0    0    1    0    0    0   -1    0    0    0    BCEG - BDEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0   -1    0    0    BCEH - BDEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0   -1    0    BCFG - BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0   -1    BCFH - BDFH

            //  H(1)
            oRegister.StateVector = oHadamardGate.ApplyTo(1, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), ((dACEG + dADEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), ((dACEH + dADEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), ((dACFG + dADFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), ((dACFH + dADFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), ((dACEG - dADEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), ((dACEH - dADEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), ((dACFG - dADFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), ((dACFH - dADFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), ((dBCEG + dBDEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), ((dBCEH + dBDEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), ((dBCFG + dBDFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), ((dBCFH + dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), ((dBCEG - dBDEG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), ((dBCEH - dBDEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), ((dBCFG - dBDFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), ((dBCFH - dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            oRegister.StateVector = oHadamardGate.ApplyTo(1, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition2()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;
            double dQubit3Alpha = 0.032;
            double dQubit3Beta = -0.417;
            double dQubit4Alpha = 0.432;
            double dQubit4Beta = -0.902343;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta), new Qubit(dQubit3Alpha, dQubit3Beta), new Qubit(dQubit4Alpha, dQubit4Beta) });

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

            //  (A + B) (x) (C + D) (x) (E + F)

            double dACEG = oACEG.Amplitude.Real;
            double dACEH = oACEH.Amplitude.Real;
            double dACFG = oACFG.Amplitude.Real;
            double dACFH = oACFH.Amplitude.Real;
            double dADEG = oADEG.Amplitude.Real;
            double dADEH = oADEH.Amplitude.Real;
            double dADFG = oADFG.Amplitude.Real;
            double dADFH = oADFH.Amplitude.Real;
            double dBCEG = oBCEG.Amplitude.Real;
            double dBCEH = oBCEH.Amplitude.Real;
            double dBCFG = oBCFG.Amplitude.Real;
            double dBCFH = oBCFH.Amplitude.Real;
            double dBDEG = oBDEG.Amplitude.Real;
            double dBDEH = oBDEH.Amplitude.Real;
            double dBDFG = oBDFG.Amplitude.Real;
            double dBDFH = oBDFH.Amplitude.Real;

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG + ACFG
            //  0    1    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACEH + ACFH
            //  1    0   -1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG - ACFG
            //  0    1    0   -1    0    0    0    0    0    0    0    0    0    0    0    0    ACEH - ACFH
            //  0    0    0    0    1    0    1    0    0    0    0    0    0    0    0    0    ADEG + ADFG
            //  0    0    0    0    0    1    0    1    0    0    0    0    0    0    0    0    ADEH + ADFH
            //  0    0    0    0    1    0   -1    0    0    0    0    0    0    0    0    0    ADEG - ADFG
            //  0    0    0    0    0    1    0   -1    0    0    0    0    0    0    0    0    ADEH - ADFH
            //  0    0    0    0    0    0    0    0    1    0    1    0    0    0    0    0    BCEG + BCFG
            //  0    0    0    0    0    0    0    0    0    1    0    1    0    0    0    0    BCEH + BCFH
            //  0    0    0    0    0    0    0    0    1    0   -1    0    0    0    0    0    BCEG - BCFG
            //  0    0    0    0    0    0    0    0    0    1    0   -1    0    0    0    0    BCEH - BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    1    0    BDEG + BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    1    BDEH + BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0   -1    0    BDEG - BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0   -1    BDEH - BDFH

            //  H(2)
            oRegister.StateVector = oHadamardGate.ApplyTo(2, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), ((dACEG + dACFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), ((dACEH + dACFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), ((dACEG - dACFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), ((dACEH - dACFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), ((dADEG + dADFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), ((dADEH + dADFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), ((dADEG - dADFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), ((dADEH - dADFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), ((dBCEG + dBCFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), ((dBCEH + dBCFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), ((dBCEG - dBCFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), ((dBCEH - dBCFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), ((dBDEG + dBDFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), ((dBDEH + dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), ((dBDEG - dBDFG) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), ((dBDEH - dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(2)
            oRegister.StateVector = oHadamardGate.ApplyTo(2, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition3()
        {
            double dQubit1Alpha = 0.8;
            double dQubit1Beta = 0.6;
            double dQubit2Alpha = 0.742;
            double dQubit2Beta = 0.123;
            double dQubit3Alpha = 0.032;
            double dQubit3Beta = -0.417;
            double dQubit4Alpha = 0.432;
            double dQubit4Beta = -0.902343;

            Register oRegister = new Register(new Qubit[] { new Qubit(dQubit1Alpha, dQubit1Beta), new Qubit(dQubit2Alpha, dQubit2Beta), new Qubit(dQubit3Alpha, dQubit3Beta), new Qubit(dQubit4Alpha, dQubit4Beta) });

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

            //  (A + B) (x) (C + D) (x) (E + F)

            double dACEG = oACEG.Amplitude.Real;
            double dACEH = oACEH.Amplitude.Real;
            double dACFG = oACFG.Amplitude.Real;
            double dACFH = oACFH.Amplitude.Real;
            double dADEG = oADEG.Amplitude.Real;
            double dADEH = oADEH.Amplitude.Real;
            double dADFG = oADFG.Amplitude.Real;
            double dADFH = oADFH.Amplitude.Real;
            double dBCEG = oBCEG.Amplitude.Real;
            double dBCEH = oBCEH.Amplitude.Real;
            double dBCFG = oBCFG.Amplitude.Real;
            double dBCFH = oBCFH.Amplitude.Real;
            double dBDEG = oBDEG.Amplitude.Real;
            double dBDEH = oBDEH.Amplitude.Real;
            double dBDFG = oBDFG.Amplitude.Real;
            double dBDFH = oBDFH.Amplitude.Real;

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG + ACEH
            //  1   -1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG - ACEH
            //  0    0    1    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFG + ACFH
            //  0    0    1   -1    0    0    0    0    0    0    0    0    0    0    0    0    ACFG - ACFG
            //  0    0    0    0    1    1    0    0    0    0    0    0    0    0    0    0    ADEG + ADEH
            //  0    0    0    0    1   -1    0    0    0    0    0    0    0    0    0    0    ADEG - ADEH
            //  0    0    0    0    0    0    1    1    0    0    0    0    0    0    0    0    ADFG + ADFH
            //  0    0    0    0    0    0    1   -1    0    0    0    0    0    0    0    0    ADFG - ADFH
            //  0    0    0    0    0    0    0    0    1    1    0    0    0    0    0    0    BCEG + BCEH
            //  0    0    0    0    0    0    0    0    1   -1    0    0    0    0    0    0    BCEG - BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    1    0    0    0    0    BCFG + BCFH
            //  0    0    0    0    0    0    0    0    0    0    1   -1    0    0    0    0    BCFG - BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    1    0    0    BDEG + BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1   -1    0    0    BDEG - BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    1    BDFG + BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1   -1    BDFG - BDFH

            //  H(3)
            oRegister.StateVector = oHadamardGate.ApplyTo(3, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), ((dACEG + dACEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), ((dACEG - dACEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), ((dACFG + dACFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), ((dACFG - dACFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), ((dADEG + dADEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), ((dADEG - dADEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), ((dADFG + dADFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), ((dADFG - dADFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), ((dBCEG + dBCEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), ((dBCEG - dBCEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), ((dBCFG + dBCFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), ((dBCFG - dBCFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), ((dBDEG + dBDEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), ((dBDEG - dBDEH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), ((dBDFG + dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), ((dBDFG - dBDFH) * dOneRootTwo).Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(3)
            oRegister.StateVector = oHadamardGate.ApplyTo(3, oRegister);

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

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Imaginary, 0);

            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Imaginary, 0);
        }

        #endregion

        #region Delegates

        #endregion
    }
}
