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
        public HadamardGateTests()
        {
            _hadamardGate = new HadamardGate();
            _oneRootTwo = (1 / 2.SquareRoot());
        }

        public const int DecimalRoundingPlaces = 10;
        
        private readonly HadamardGate _hadamardGate;
        private readonly double _oneRootTwo;

        [TestMethod]
        public void HadamardGate1Qubit()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            //  A   B
            //  1   1   A + B
            //  1  -1   A - B

            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

            Assert.AreEqual(register[0], a);
            Assert.AreEqual(register[1], b);

            Assert.AreEqual(a.Amplitude.Real, ((qubit1Alpha + qubit1Beta) * _oneRootTwo));
            Assert.AreEqual(a.Amplitude.Imaginary, 0);

            Assert.AreEqual(b.Amplitude.Real, ((qubit1Alpha - qubit1Beta) * _oneRootTwo));
            Assert.AreEqual(b.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

            Assert.AreEqual(register[0], a);
            Assert.AreEqual(register[1], b);

            Assert.AreEqual(a.Amplitude.Real.Round(DecimalRoundingPlaces), qubit1Alpha);
            Assert.AreEqual(a.Amplitude.Imaginary, 0);

            Assert.AreEqual(b.Amplitude.Real.Round(DecimalRoundingPlaces), qubit1Beta);
            Assert.AreEqual(b.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate2QubitPosition0()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  (A + B) (x) (C + D)

            //  AC 0.594
            //  AD 0.098
            //  BC 0.445
            //  BD 0.074

            double dAC = ac.Amplitude.Real;
            double dAD = ad.Amplitude.Real;
            double dBC = bc.Amplitude.Real;
            double dBD = bd.Amplitude.Real;

            //  AC  AD  BC  BD
            //  1   0   1   0   AC + BC
            //  0   1   0   1   AD + BD
            //  1   0  -1   0   AC - BC
            //  0   1   0  -1   AD - BD

            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            Assert.AreEqual(ac.Amplitude.Real.Round(10), ((dAC + dBC) * _oneRootTwo).Round(10));
            Assert.AreEqual(ac.Amplitude.Imaginary, 0);

            Assert.AreEqual(ad.Amplitude.Real.Round(10), ((dAD + dBD) * _oneRootTwo).Round(10));
            Assert.AreEqual(ad.Amplitude.Imaginary, 0);

            Assert.AreEqual(bc.Amplitude.Real.Round(10), ((dAC - dBC) * _oneRootTwo).Round(10));
            Assert.AreEqual(bc.Amplitude.Imaginary, 0);

            Assert.AreEqual(bd.Amplitude.Real.Round(10), ((dAD - dBD) * _oneRootTwo).Round(10));
            Assert.AreEqual(bd.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            Assert.AreEqual(ac.Amplitude.Real.Round(DecimalRoundingPlaces), dAC.Round(10));
            Assert.AreEqual(ac.Amplitude.Imaginary, 0);

            Assert.AreEqual(ad.Amplitude.Real.Round(DecimalRoundingPlaces), dAD.Round(10));
            Assert.AreEqual(ad.Amplitude.Imaginary, 0);

            Assert.AreEqual(bc.Amplitude.Real.Round(DecimalRoundingPlaces), dBC.Round(10));
            Assert.AreEqual(bc.Amplitude.Imaginary, 0);

            Assert.AreEqual(bd.Amplitude.Real.Round(DecimalRoundingPlaces), dBD.Round(10));
            Assert.AreEqual(bd.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate2QubitPosition1()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  (A + B) (x) (C + D)

            //  AC 0.594
            //  AD 0.098
            //  BC 0.445
            //  BD 0.074

            double dAC = ac.Amplitude.Real;
            double dAD = ad.Amplitude.Real;
            double dBC = bc.Amplitude.Real;
            double dBD = bd.Amplitude.Real;

            //  AC  AD  BC  BD
            //  1   1   0   0   AC + AD
            //  1  -1   0   0   AC - AD
            //  0   0   1   1   BC + BD
            //  0   0   1  -1   BC - BD

            //  H(1)
            register.StateVector = _hadamardGate.ApplyTo(1, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            Assert.AreEqual(ac.Amplitude.Real.Round(10), ((dAC + dAD) * _oneRootTwo).Round(10));
            Assert.AreEqual(ac.Amplitude.Imaginary, 0);

            Assert.AreEqual(ad.Amplitude.Real.Round(10), ((dAC - dAD) * _oneRootTwo).Round(10));
            Assert.AreEqual(ad.Amplitude.Imaginary, 0);

            Assert.AreEqual(bc.Amplitude.Real.Round(10), ((dBC + dBD) * _oneRootTwo).Round(10));
            Assert.AreEqual(bc.Amplitude.Imaginary, 0);

            Assert.AreEqual(bd.Amplitude.Real.Round(10), ((dBC - dBD) * _oneRootTwo).Round(10));
            Assert.AreEqual(bd.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(1, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            Assert.AreEqual(ac.Amplitude.Real.Round(DecimalRoundingPlaces), dAC.Round(10));
            Assert.AreEqual(ac.Amplitude.Imaginary, 0);

            Assert.AreEqual(ad.Amplitude.Real.Round(DecimalRoundingPlaces), dAD.Round(10));
            Assert.AreEqual(ad.Amplitude.Imaginary, 0);

            Assert.AreEqual(bc.Amplitude.Real.Round(DecimalRoundingPlaces), dBC.Round(10));
            Assert.AreEqual(bc.Amplitude.Imaginary, 0);

            Assert.AreEqual(bd.Amplitude.Real.Round(DecimalRoundingPlaces), dBD.Round(10));
            Assert.AreEqual(bd.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate3QubitPosition0()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;
            double qubit3Alpha = 0.032;
            double qubit3Beta = -0.47;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta), new Qubit(qubit3Alpha, qubit3Beta) });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcd = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  (A + B) (x) (C + D) (x) (E + F)

            double dace = ace.Amplitude.Real;
            double dacf = acf.Amplitude.Real;
            double dade = ade.Amplitude.Real;
            double dadf = adf.Amplitude.Real;
            double dbce = bce.Amplitude.Real;
            double dbcd = bcd.Amplitude.Real;
            double dbde = bde.Amplitude.Real;
            double dbdf = bdf.Amplitude.Real;

            //  ACE ACF ADE ADF BCE BCD BDE BDF
            //  1   0   0   0   1   0   0   0   ACE + BCE
            //  0   1   0   0   0   1   0   0   ACF + BCD
            //  0   0   1   0   0   0   1   0   ADE + BDE
            //  0   0   0   1   0   0   0   1   ADF + BDF
            //  1   0   0   0  -1   0   0   0   ACE - BCE
            //  0   1   0   0   0  -1   0   0   ACF - BCD
            //  0   0   1   0   0   0  -1   0   ADE - BDE
            //  0   0   0   1   0   0   0  -1   ADF - BCD

            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcd);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(ace.Amplitude.Real.Round(10), ((dace + dbce) * _oneRootTwo).Round(10));
            Assert.AreEqual(ace.Amplitude.Imaginary, 0);

            Assert.AreEqual(acf.Amplitude.Real.Round(10), ((dacf + dbcd) * _oneRootTwo).Round(10));
            Assert.AreEqual(acf.Amplitude.Imaginary, 0);

            Assert.AreEqual(ade.Amplitude.Real.Round(10), ((dade + dbde) * _oneRootTwo).Round(10));
            Assert.AreEqual(ade.Amplitude.Imaginary, 0);

            Assert.AreEqual(adf.Amplitude.Real.Round(10), ((dadf + dbdf) * _oneRootTwo).Round(10));
            Assert.AreEqual(adf.Amplitude.Imaginary, 0);

            Assert.AreEqual(bce.Amplitude.Real.Round(10), ((dace - dbce) * _oneRootTwo).Round(10));
            Assert.AreEqual(bce.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcd.Amplitude.Real.Round(10), ((dacf - dbcd) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcd.Amplitude.Imaginary, 0);

            Assert.AreEqual(bde.Amplitude.Real.Round(10), ((dade - dbde) * _oneRootTwo).Round(10));
            Assert.AreEqual(bde.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdf.Amplitude.Real.Round(10), ((dadf - dbdf) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdf.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcd);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(ace.Amplitude.Imaginary, 0);

            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(acf.Amplitude.Imaginary, 0);

            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(ade.Amplitude.Imaginary, 0);

            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(adf.Amplitude.Imaginary, 0);

            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bce.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcd.Amplitude.Real.Round(10), dbcd.Round(10));
            Assert.AreEqual(bcd.Amplitude.Imaginary, 0);

            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bde.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));
            Assert.AreEqual(bdf.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate3QubitPosition1()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;
            double qubit3Alpha = 0.032;
            double qubit3Beta = -0.47;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta), new Qubit(qubit3Alpha, qubit3Beta) });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcd = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  (A + B) (x) (C + D) (x) (E + F)

            double dace = ace.Amplitude.Real;
            double dacf = acf.Amplitude.Real;
            double dade = ade.Amplitude.Real;
            double dadf = adf.Amplitude.Real;
            double dbce = bce.Amplitude.Real;
            double dbcd = bcd.Amplitude.Real;
            double dbde = bde.Amplitude.Real;
            double dbdf = bdf.Amplitude.Real;

            //  ACE ACF ADE ADF BCE BCD BDE BDF
            //  1   0   1   0   0   0   0   0   ACE + ADE
            //  0   1   0   1   0   0   0   0   ACF + ADF
            //  1   0  -1   0   0   0   0   0   ACE - ADE
            //  0   1   0  -1   0   0   0   0   ACF - ADF
            //  0   0   0   0   1   0   1   0   BCE + BDE
            //  0   0   0   0   0   1   0   1   BCD + BDF
            //  0   0   0   0   1   0  -1   0   BCE - BDE
            //  0   0   0   0   0   1   0  -1   BCD - BDF

            //  H(1)
            register.StateVector = _hadamardGate.ApplyTo(1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcd);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(ace.Amplitude.Real.Round(10), ((dace + dade) * _oneRootTwo).Round(10));
            Assert.AreEqual(ace.Amplitude.Imaginary, 0);

            Assert.AreEqual(acf.Amplitude.Real.Round(10), ((dacf + dadf) * _oneRootTwo).Round(10));
            Assert.AreEqual(acf.Amplitude.Imaginary, 0);

            Assert.AreEqual(ade.Amplitude.Real.Round(10), ((dace - dade) * _oneRootTwo).Round(10));
            Assert.AreEqual(ade.Amplitude.Imaginary, 0);

            Assert.AreEqual(adf.Amplitude.Real.Round(10), ((dacf - dadf) * _oneRootTwo).Round(10));
            Assert.AreEqual(adf.Amplitude.Imaginary, 0);

            Assert.AreEqual(bce.Amplitude.Real.Round(10), ((dbce + dbde) * _oneRootTwo).Round(10));
            Assert.AreEqual(bce.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcd.Amplitude.Real.Round(10), ((dbcd + dbdf) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcd.Amplitude.Imaginary, 0);

            Assert.AreEqual(bde.Amplitude.Real.Round(10), ((dbce - dbde) * _oneRootTwo).Round(10));
            Assert.AreEqual(bde.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdf.Amplitude.Real.Round(10), ((dbcd - dbdf) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdf.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(1)
            register.StateVector = _hadamardGate.ApplyTo(1, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcd);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(ace.Amplitude.Imaginary, 0);

            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(acf.Amplitude.Imaginary, 0);

            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(ade.Amplitude.Imaginary, 0);

            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(adf.Amplitude.Imaginary, 0);

            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bce.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcd.Amplitude.Real.Round(10), dbcd.Round(10));
            Assert.AreEqual(bcd.Amplitude.Imaginary, 0);

            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bde.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));
            Assert.AreEqual(bdf.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate3QubitPosition2()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;
            double qubit3Alpha = 0.032;
            double qubit3Beta = -0.47;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta), new Qubit(qubit3Alpha, qubit3Beta) });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcd = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  (A + B) (x) (C + D) (x) (E + F)

            double dace = ace.Amplitude.Real;
            double dacf = acf.Amplitude.Real;
            double dade = ade.Amplitude.Real;
            double dadf = adf.Amplitude.Real;
            double dbce = bce.Amplitude.Real;
            double dbcd = bcd.Amplitude.Real;
            double dbde = bde.Amplitude.Real;
            double dbdf = bdf.Amplitude.Real;

            //  ACE ACF ADE ADF BCE BCD BDE BDF
            //  1   1   0   0   0   0   0   0   ACE + ACF
            //  1  -1   0   0   0   0   0   0   ACE - ACF
            //  0   0   1   1   0   0   0   0   ADE + ADF
            //  0   0   1  -1   0   0   0   0   ADE - ADF
            //  0   0   0   0   1   1   0   0   BCE + BCD
            //  0   0   0   0   1  -1   0   0   BCE - BCD
            //  0   0   0   0   0   0   1   1   BDE + BDF
            //  0   0   0   0   0   0   1  -1   BDE - BDF

            //  H(2)
            register.StateVector = _hadamardGate.ApplyTo(2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcd);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(ace.Amplitude.Real.Round(10), ((dace + dacf) * _oneRootTwo).Round(10));
            Assert.AreEqual(ace.Amplitude.Imaginary, 0);

            Assert.AreEqual(acf.Amplitude.Real.Round(10), ((dace - dacf) * _oneRootTwo).Round(10));
            Assert.AreEqual(acf.Amplitude.Imaginary, 0);

            Assert.AreEqual(ade.Amplitude.Real.Round(10), ((dade + dadf) * _oneRootTwo).Round(10));
            Assert.AreEqual(ade.Amplitude.Imaginary, 0);

            Assert.AreEqual(adf.Amplitude.Real.Round(10), ((dade - dadf) * _oneRootTwo).Round(10));
            Assert.AreEqual(adf.Amplitude.Imaginary, 0);

            Assert.AreEqual(bce.Amplitude.Real.Round(10), ((dbce + dbcd) * _oneRootTwo).Round(10));
            Assert.AreEqual(bce.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcd.Amplitude.Real.Round(10), ((dbce - dbcd) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcd.Amplitude.Imaginary, 0);

            Assert.AreEqual(bde.Amplitude.Real.Round(10), ((dbde + dbdf) * _oneRootTwo).Round(10));
            Assert.AreEqual(bde.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdf.Amplitude.Real.Round(10), ((dbde - dbdf) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdf.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(2)
            register.StateVector = _hadamardGate.ApplyTo(2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcd);
            Assert.AreEqual(register[6], bde);
            Assert.AreEqual(register[7], bdf);

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(ace.Amplitude.Imaginary, 0);

            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(acf.Amplitude.Imaginary, 0);

            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(ade.Amplitude.Imaginary, 0);

            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(adf.Amplitude.Imaginary, 0);

            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bce.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcd.Amplitude.Real.Round(10), dbcd.Round(10));
            Assert.AreEqual(bcd.Amplitude.Imaginary, 0);

            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bde.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));
            Assert.AreEqual(bdf.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition0()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;
            double qubit3Alpha = 0.032;
            double qubit3Beta = -0.417;
            double qubit4Alpha = 0.432;
            double qubit4Beta = -0.902343;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta), new Qubit(qubit3Alpha, qubit3Beta), new Qubit(qubit4Alpha, qubit4Beta) });

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
            ComputationalBasisState bcdg = register.StateVector[10];
            ComputationalBasisState bcdh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  (A + B) (x) (C + D) (x) (E + F)

            double daceg = aceg.Amplitude.Real;
            double daceh = aceh.Amplitude.Real;
            double dacfg = acfg.Amplitude.Real;
            double dacfh = acfh.Amplitude.Real;
            double dadeg = adeg.Amplitude.Real;
            double dadeh = adeh.Amplitude.Real;
            double dadfg = adfg.Amplitude.Real;
            double dadfh = adfh.Amplitude.Real;
            double dbceg = bceg.Amplitude.Real;
            double dbceh = bceh.Amplitude.Real;
            double dbcdg = bcdg.Amplitude.Real;
            double dbcdh = bcdh.Amplitude.Real;
            double dbdeg = bdeg.Amplitude.Real;
            double dbdeh = bdeh.Amplitude.Real;
            double dbdfg = bdfg.Amplitude.Real;
            double dbdfh = bdfh.Amplitude.Real;

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCDG BCDH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    ACEG + BCEG
            //  0    1    0    0    0    0    0    0    0    1    0    0    0    0    0    0    ACEH + BCEH
            //  0    0    1    0    0    0    0    0    0    0    1    0    0    0    0    0    ACFG + BCDG
            //  0    0    0    1    0    0    0    0    0    0    0    1    0    0    0    0    ACFH + BCDH
            //  0    0    0    0    1    0    0    0    0    0    0    0    1    0    0    0    ADEG + BDEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    1    0    0    ADEH + BDEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    1    0    ADFG + BDFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    1    ADFH + BDFH
            //  1    0    0    0    0    0    0    0   -1    0    0    0    0    0    0    0    ACEG - BCEG
            //  0    1    0    0    0    0    0    0    0   -1    0    0    0    0    0    0    ACEH - BCEH
            //  0    0    1    0    0    0    0    0    0    0   -1    0    0    0    0    0    ACFG - BCDG
            //  0    0    0    1    0    0    0    0    0    0    0   -1    0    0    0    0    ACFH - BCDH
            //  0    0    0    0    1    0    0    0    0    0    0    0   -1    0    0    0    ADEG - BDEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0   -1    0    0    ADEH - BDEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0   -1    0    ADFG - BDFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0   -1    ADFH - BDFH

            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), ((daceg + dbceg) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), ((daceh + dbceh) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), ((dacfg + dbcdg) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), ((dacfh + dbcdh) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), ((dadeg + dbdeg) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), ((dadeh + dbdeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), ((dadfg + dbdfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), ((dadfh + dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), ((daceg - dbceg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), ((daceh - dbceh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), ((dacfg - dbcdg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), ((dacfh - dbcdh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), ((dadeg - dbdeg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), ((dadeh - dbdeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), ((dadfg - dbdfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), ((dadfh - dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(0, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), dbcdg.Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), dbcdh.Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition1()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;
            double qubit3Alpha = 0.032;
            double qubit3Beta = -0.417;
            double qubit4Alpha = 0.432;
            double qubit4Beta = -0.902343;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta), new Qubit(qubit3Alpha, qubit3Beta), new Qubit(qubit4Alpha, qubit4Beta) });

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
            ComputationalBasisState bcdg = register.StateVector[10];
            ComputationalBasisState bcdh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  (A + B) (x) (C + D) (x) (E + F)

            double daceg = aceg.Amplitude.Real;
            double daceh = aceh.Amplitude.Real;
            double dacfg = acfg.Amplitude.Real;
            double dacfh = acfh.Amplitude.Real;
            double dadeg = adeg.Amplitude.Real;
            double dadeh = adeh.Amplitude.Real;
            double dadfg = adfg.Amplitude.Real;
            double dadfh = adfh.Amplitude.Real;
            double dbceg = bceg.Amplitude.Real;
            double dbceh = bceh.Amplitude.Real;
            double dbcdg = bcdg.Amplitude.Real;
            double dbcdh = bcdh.Amplitude.Real;
            double dbdeg = bdeg.Amplitude.Real;
            double dbdeh = bdeh.Amplitude.Real;
            double dbdfg = bdfg.Amplitude.Real;
            double dbdfh = bdfh.Amplitude.Real;

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCDG BCDH BDEG BDEH BDFG BDFH
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
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    1    0    BCDG + BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    1    BCDH + BDFH
            //  0    0    0    0    0    0    0    0    1    0    0    0   -1    0    0    0    BCEG - BDEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0   -1    0    0    BCEH - BDEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0   -1    0    BCDG - BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0   -1    BCDH - BDFH

            //  H(1)
            register.StateVector = _hadamardGate.ApplyTo(1, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), ((daceg + dadeg) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), ((daceh + dadeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), ((dacfg + dadfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), ((dacfh + dadfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), ((daceg - dadeg) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), ((daceh - dadeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), ((dacfg - dadfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), ((dacfh - dadfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), ((dbceg + dbdeg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), ((dbceh + dbdeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), ((dbcdg + dbdfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), ((dbcdh + dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), ((dbceg - dbdeg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), ((dbceh - dbdeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), ((dbcdg - dbdfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), ((dbcdh - dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(0)
            register.StateVector = _hadamardGate.ApplyTo(1, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), dbcdg.Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), dbcdh.Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition2()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;
            double qubit3Alpha = 0.032;
            double qubit3Beta = -0.417;
            double qubit4Alpha = 0.432;
            double qubit4Beta = -0.902343;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta), new Qubit(qubit3Alpha, qubit3Beta), new Qubit(qubit4Alpha, qubit4Beta) });

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
            ComputationalBasisState bcdg = register.StateVector[10];
            ComputationalBasisState bcdh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  (A + B) (x) (C + D) (x) (E + F)

            double daceg = aceg.Amplitude.Real;
            double daceh = aceh.Amplitude.Real;
            double dacfg = acfg.Amplitude.Real;
            double dacfh = acfh.Amplitude.Real;
            double dadeg = adeg.Amplitude.Real;
            double dadeh = adeh.Amplitude.Real;
            double dadfg = adfg.Amplitude.Real;
            double dadfh = adfh.Amplitude.Real;
            double dbceg = bceg.Amplitude.Real;
            double dbceh = bceh.Amplitude.Real;
            double dbcdg = bcdg.Amplitude.Real;
            double dbcdh = bcdh.Amplitude.Real;
            double dbdeg = bdeg.Amplitude.Real;
            double dbdeh = bdeh.Amplitude.Real;
            double dbdfg = bdfg.Amplitude.Real;
            double dbdfh = bdfh.Amplitude.Real;

            //  aceg aceh acfg acfh adeg adeh adfg adfh bceg bceh bcdg bcdh bdeg bdeh bdfg bdfh
            //  1    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    aceg + acfg
            //  0    1    0    1    0    0    0    0    0    0    0    0    0    0    0    0    aceh + acfh
            //  1    0   -1    0    0    0    0    0    0    0    0    0    0    0    0    0    aceg - acfg
            //  0    1    0   -1    0    0    0    0    0    0    0    0    0    0    0    0    aceh - acfh
            //  0    0    0    0    1    0    1    0    0    0    0    0    0    0    0    0    adeg + adfg
            //  0    0    0    0    0    1    0    1    0    0    0    0    0    0    0    0    adeh + adfh
            //  0    0    0    0    1    0   -1    0    0    0    0    0    0    0    0    0    adeg - adfg
            //  0    0    0    0    0    1    0   -1    0    0    0    0    0    0    0    0    adeh - adfh
            //  0    0    0    0    0    0    0    0    1    0    1    0    0    0    0    0    bceg + bcdg
            //  0    0    0    0    0    0    0    0    0    1    0    1    0    0    0    0    bceh + bcdh
            //  0    0    0    0    0    0    0    0    1    0   -1    0    0    0    0    0    bceg - bcdg
            //  0    0    0    0    0    0    0    0    0    1    0   -1    0    0    0    0    bceh - bcdh
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    1    0    bdeg + bdfh
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    1    bdeh + bdfh
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0   -1    0    bdeg - bdfh
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0   -1    bdeh - bdfh

            //  H(2)
            register.StateVector = _hadamardGate.ApplyTo(2, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), ((daceg + dacfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), ((daceh + dacfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), ((daceg - dacfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), ((daceh - dacfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), ((dadeg + dadfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), ((dadeh + dadfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), ((dadeg - dadfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), ((dadeh - dadfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), ((dbceg + dbcdg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), ((dbceh + dbcdh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), ((dbceg - dbcdg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), ((dbceh - dbcdh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), ((dbdeg + dbdfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), ((dbdeh + dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), ((dbdeg - dbdfg) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), ((dbdeh - dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(2)
            register.StateVector = _hadamardGate.ApplyTo(2, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), dbcdg.Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), dbcdh.Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);
        }

        [TestMethod]
        public void HadamardGate4QubitPosition3()
        {
            double qubit1Alpha = 0.8;
            double qubit1Beta = 0.6;
            double qubit2Alpha = 0.742;
            double qubit2Beta = 0.123;
            double qubit3Alpha = 0.032;
            double qubit3Beta = -0.417;
            double qubit4Alpha = 0.432;
            double qubit4Beta = -0.902343;

            Register register = new Register(new Qubit[] { new Qubit(qubit1Alpha, qubit1Beta), new Qubit(qubit2Alpha, qubit2Beta), new Qubit(qubit3Alpha, qubit3Beta), new Qubit(qubit4Alpha, qubit4Beta) });

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
            ComputationalBasisState bcdg = register.StateVector[10];
            ComputationalBasisState bcdh = register.StateVector[11];
            ComputationalBasisState bdeg = register.StateVector[12];
            ComputationalBasisState bdeh = register.StateVector[13];
            ComputationalBasisState bdfg = register.StateVector[14];
            ComputationalBasisState bdfh = register.StateVector[15];

            //  (A + B) (x) (C + D) (x) (E + F)

            double daceg = aceg.Amplitude.Real;
            double daceh = aceh.Amplitude.Real;
            double dacfg = acfg.Amplitude.Real;
            double dacfh = acfh.Amplitude.Real;
            double dadeg = adeg.Amplitude.Real;
            double dadeh = adeh.Amplitude.Real;
            double dadfg = adfg.Amplitude.Real;
            double dadfh = adfh.Amplitude.Real;
            double dbceg = bceg.Amplitude.Real;
            double dbceh = bceh.Amplitude.Real;
            double dbcdg = bcdg.Amplitude.Real;
            double dbcdh = bcdh.Amplitude.Real;
            double dbdeg = bdeg.Amplitude.Real;
            double dbdeh = bdeh.Amplitude.Real;
            double dbdfg = bdfg.Amplitude.Real;
            double dbdfh = bdfh.Amplitude.Real;

            //  aceg aceh acfg acfh adeg adeh adfg adfh bceg bceh bcdg bcdh bdeg bdeh bdfg bdfh
            //  1    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    aceg + aceh
            //  1   -1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    aceg - aceh
            //  0    0    1    1    0    0    0    0    0    0    0    0    0    0    0    0    acfg + acfh
            //  0    0    1   -1    0    0    0    0    0    0    0    0    0    0    0    0    acfg - acfg
            //  0    0    0    0    1    1    0    0    0    0    0    0    0    0    0    0    adeg + adeh
            //  0    0    0    0    1   -1    0    0    0    0    0    0    0    0    0    0    adeg - adeh
            //  0    0    0    0    0    0    1    1    0    0    0    0    0    0    0    0    adfg + adfh
            //  0    0    0    0    0    0    1   -1    0    0    0    0    0    0    0    0    adfg - adfh
            //  0    0    0    0    0    0    0    0    1    1    0    0    0    0    0    0    bceg + bceh
            //  0    0    0    0    0    0    0    0    1   -1    0    0    0    0    0    0    bceg - bceh
            //  0    0    0    0    0    0    0    0    0    0    1    1    0    0    0    0    bcdg + bcdh
            //  0    0    0    0    0    0    0    0    0    0    1   -1    0    0    0    0    bcdg - bcdh
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    1    0    0    bdeg + bdeh
            //  0    0    0    0    0    0    0    0    0    0    0    0    1   -1    0    0    bdeg - bdeh
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    1    bdfg + bdfh
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1   -1    bdfg - bdfh

            //  H(3)
            register.StateVector = _hadamardGate.ApplyTo(3, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), ((daceg + daceh) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), ((daceg - daceh) * _oneRootTwo).Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), ((dacfg + dacfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), ((dacfg - dacfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), ((dadeg + dadeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), ((dadeg - dadeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), ((dadfg + dadfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), ((dadfg - dadfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), ((dbceg + dbceh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), ((dbceg - dbceh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), ((dbcdg + dbcdh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), ((dbcdg - dbcdh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), ((dbdeg + dbdeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), ((dbdeg - dbdeh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), ((dbdfg + dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), ((dbdfg - dbdfh) * _oneRootTwo).Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);

            //  Reversible
            //  H(3)
            register.StateVector = _hadamardGate.ApplyTo(3, register);

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
            Assert.AreEqual(register[10], bcdg);
            Assert.AreEqual(register[11], bcdh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdfh);

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(aceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(acfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(adfh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bceh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdg.Amplitude.Real.Round(10), dbcdg.Round(10));
            Assert.AreEqual(bcdg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bcdh.Amplitude.Real.Round(10), dbcdh.Round(10));
            Assert.AreEqual(bcdh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 0);

            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 0);
        }
    }
}
