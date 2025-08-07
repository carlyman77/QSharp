#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class PauliYGateTests : GateTests
    {
        public PauliYGateTests()
        {
            _pauliYGate = new PauliYGate();
        }

        private readonly PauliYGate _pauliYGate;

        [TestMethod]
        public void PauliYGate1Qubit()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit() });

            //  A   B
            //  0  -i   -Bi
            //  i   0   Ai

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            //  Y(0)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], b);
            Assert.AreEqual(register[1], a);

            Assert.AreEqual(a.Amplitude.Real, 1);
            Assert.AreEqual(a.Amplitude.Imaginary, 1);

            Assert.AreEqual(b.Amplitude.Real, -1);
            Assert.AreEqual(b.Amplitude.Imaginary, 1);

            //  Reversible

            //  -Bi Ai
            //  0  -i   A
            //  i   0   B

            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], a);
            Assert.AreEqual(register[1], b);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void PauliYGate2QubitPostion0()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  AC  AD  BC  BD
            //  0   0  -I   0   -BCi
            //  0   0   0  -I   -BDi
            //  I   0   0   0   ACi
            //  0   I   0   0   ADi

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  X(0)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], bc);
            Assert.AreEqual(register[1], bd);
            Assert.AreEqual(register[2], ac);
            Assert.AreEqual(register[3], ad);

            Assert.AreEqual(ac.Amplitude.Real, 1);
            Assert.AreEqual(ac.Amplitude.Imaginary, 1);

            Assert.AreEqual(ad.Amplitude.Real, 1);
            Assert.AreEqual(ad.Amplitude.Imaginary, 1);
            
            Assert.AreEqual(bc.Amplitude.Real, -1);
            Assert.AreEqual(bc.Amplitude.Imaginary, 1);
            
            Assert.AreEqual(bd.Amplitude.Real, -1);
            Assert.AreEqual(bd.Amplitude.Imaginary, 1);

            //  Reversible

            //  -BCi -BDi ACi ADi
            //  0    0   -I   0   AC
            //  0    0    0  -I   AD
            //  I    0    0   0   BC
            //  0    I    0   0   BD

            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void PauliYGate2QubitPostion1()
        {
            int position = 1;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  AC  AD  BC  BD
            //  0  -I   0   0   -ADi
            //  I   0   0   0   ACi
            //  0   0   0  -I   -BDi
            //  0   0   I   0   BCi

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  Y(1)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ad);
            Assert.AreEqual(register[1], ac);
            Assert.AreEqual(register[2], bd);
            Assert.AreEqual(register[3], bc);

            Assert.AreEqual(ac.Amplitude.Real, 1);
            Assert.AreEqual(ac.Amplitude.Imaginary, 1);

            Assert.AreEqual(ad.Amplitude.Real, -1);
            Assert.AreEqual(ad.Amplitude.Imaginary, 1);

            Assert.AreEqual(bc.Amplitude.Real, 1);
            Assert.AreEqual(bc.Amplitude.Imaginary, 1);

            Assert.AreEqual(bd.Amplitude.Real, -1);
            Assert.AreEqual(bd.Amplitude.Imaginary, 1);

            //  Reversible

            //  AD  AC  BD  BC
            //  0   1   0   0   AC
            //  1   0   0   0   AD
            //  0   0   0   1   BC
            //  0   0   1   0   BD

            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void PauliYGate3QubitPostion0()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0   0   0   0  -1   0   0   0   -BCEi
            //  0   0   0   0   0  -I   0   0   -BCFi
            //  0   0   0   0   0   0  -I   0   -BDEi
            //  0   0   0   0   0   0   0  -I   -BDFi
            //  I   0   0   0   0   0   0   0   ACEi
            //  0   I   0   0   0   0   0   0   ACFi
            //  0   0   I   0   0   0   0   0   ADEi
            //  0   0   0   I   0   0   0   0   ADFi

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  Y(0)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], bce);
            Assert.AreEqual(register[1], bcf);
            Assert.AreEqual(register[2], bde);
            Assert.AreEqual(register[3], bdf);
            Assert.AreEqual(register[4], ace);
            Assert.AreEqual(register[5], acf);
            Assert.AreEqual(register[6], ade);
            Assert.AreEqual(register[7], adf);

            Assert.AreEqual(ace.Amplitude.Real, 1);
            Assert.AreEqual(ace.Amplitude.Imaginary, 1);

            Assert.AreEqual(acf.Amplitude.Real, 1);
            Assert.AreEqual(acf.Amplitude.Imaginary, 1);

            Assert.AreEqual(ade.Amplitude.Real, 1);
            Assert.AreEqual(ade.Amplitude.Imaginary, 1);

            Assert.AreEqual(adf.Amplitude.Real, 1);
            Assert.AreEqual(adf.Amplitude.Imaginary, 1);

            Assert.AreEqual(bce.Amplitude.Real, -1);
            Assert.AreEqual(bce.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcf.Amplitude.Real, -1);
            Assert.AreEqual(bcf.Amplitude.Imaginary, 1);

            Assert.AreEqual(bde.Amplitude.Real, -1);
            Assert.AreEqual(bde.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdf.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Imaginary, 1);

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

            register.StateVector = _pauliYGate.ApplyTo(position, register);

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
        public void PauliYGate3QubitPostion1()
        {
            int position = 1;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0   0  -I   0   0   0   0   0   -ADEi
            //  0   0   0  -I   0   0   0   0   -ADFi
            //  I   0   0   0   0   0   0   0   ACEi
            //  0   I   0   0   0   0   0   0   ACFi
            //  0   0   0   0   0   0  -I   0   -BDEi
            //  0   0   0   0   0   0   0  -I   -BDFi
            //  0   0   0   0   I   0   0   0   BCEi
            //  0   0   0   0   0   I   0   0   BCFi

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  Y(1)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ade);
            Assert.AreEqual(register[1], adf);
            Assert.AreEqual(register[2], ace);
            Assert.AreEqual(register[3], acf);
            Assert.AreEqual(register[4], bde);
            Assert.AreEqual(register[5], bdf);
            Assert.AreEqual(register[6], bce);
            Assert.AreEqual(register[7], bcf);

            Assert.AreEqual(ace.Amplitude.Real, 1);
            Assert.AreEqual(ace.Amplitude.Imaginary, 1);

            Assert.AreEqual(acf.Amplitude.Real, 1);
            Assert.AreEqual(acf.Amplitude.Imaginary, 1);

            Assert.AreEqual(ade.Amplitude.Real, -1);
            Assert.AreEqual(ade.Amplitude.Imaginary, 1);

            Assert.AreEqual(adf.Amplitude.Real, -1);
            Assert.AreEqual(adf.Amplitude.Imaginary, 1);

            Assert.AreEqual(bce.Amplitude.Real, 1);
            Assert.AreEqual(bce.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcf.Amplitude.Real, 1);
            Assert.AreEqual(bcf.Amplitude.Imaginary, 1);

            Assert.AreEqual(bde.Amplitude.Real, -1);
            Assert.AreEqual(bde.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdf.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Imaginary, 1);

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

            register.StateVector = _pauliYGate.ApplyTo(position, register);

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
        public void PauliYGate3QubitPostion2()
        {
            int position = 2;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  0  -I   0   0   0   0   0   0   -ACFi
            //  I   0   0   0   0   0   0   0   ACEi
            //  0   0   0  -I   0   0   0   0   -ADFi
            //  0   0   I   0   0   0   0   0   ADEi
            //  0   0   0   0   0  -I   0   0   -BCFi
            //  0   0   0   0   I   0   0   0   BCEi
            //  0   0   0   0   0   0   0  -I   -BDFi
            //  0   0   0   0   0   0   I   0   BDEi

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  X(2)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], acf);
            Assert.AreEqual(register[1], ace);
            Assert.AreEqual(register[2], adf);
            Assert.AreEqual(register[3], ade);
            Assert.AreEqual(register[4], bcf);
            Assert.AreEqual(register[5], bce);
            Assert.AreEqual(register[6], bdf);
            Assert.AreEqual(register[7], bde);

            Assert.AreEqual(ace.Amplitude.Real, 1);
            Assert.AreEqual(ace.Amplitude.Imaginary, 1);

            Assert.AreEqual(acf.Amplitude.Real, -1);
            Assert.AreEqual(acf.Amplitude.Imaginary, 1);

            Assert.AreEqual(ade.Amplitude.Real, 1);
            Assert.AreEqual(ade.Amplitude.Imaginary, 1);

            Assert.AreEqual(adf.Amplitude.Real, -1);
            Assert.AreEqual(adf.Amplitude.Imaginary, 1);

            Assert.AreEqual(bce.Amplitude.Real, 1);
            Assert.AreEqual(bce.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcf.Amplitude.Real, -1);
            Assert.AreEqual(bcf.Amplitude.Imaginary, 1);

            Assert.AreEqual(bde.Amplitude.Real, 1);
            Assert.AreEqual(bde.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdf.Amplitude.Real, -1);
            Assert.AreEqual(bdf.Amplitude.Imaginary, 1);

            //  Reversible

            //  -ACFi ACEi -ADFi  ADEi -BCFi  BCEi -BDFi  BDEi
            //  0    -I     0     0     0     0     0     0   ACE
            //  I     0     0     0     0     0     0     0   ACF
            //  0     0     0    -I     0     0     0     0   ADE
            //  0     0     I     0     0     0     0     0   ADF
            //  0     0     0     0     0    -I     0     0   BCE
            //  0     0     0     0     I     0     0     0   BCF
            //  0     0     0     0     0     0     0    -I   BDE
            //  0     0     0     0     0     0     I     0   BDF

            register.StateVector = _pauliYGate.ApplyTo(position, register);

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
        public void PauliYGate4QubitPostion0()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  aceg + aceh + acfg + acfh + adeg + adeh + adfg + adfh + bceg + bceh + bcfg + bcfh + bdeg + bdeh + bdfg + bdfh

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0    0    0    0    0    0    0   -I    0    0    0    0    0    0    0    -BCEGi
            //  0    0    0    0    0    0    0    0    0   -I    0    0    0    0    0    0    -BCEHi
            //  0    0    0    0    0    0    0    0    0    0   -I    0    0    0    0    0    -BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0   -I    0    0    0    0    -BCFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0   -I    0    0    0    -BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -I    0    0    -BDEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -I    0    -BDFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -I    -BDFHi
            //  I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEHi
            //  0    0    I    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFGi
            //  0    0    0    I    0    0    0    0    0    0    0    0    0    0    0    0    ACFHi
            //  0    0    0    0    I    0    0    0    0    0    0    0    0    0    0    0    ADEGi
            //  0    0    0    0    0    I    0    0    0    0    0    0    0    0    0    0    ADEHi
            //  0    0    0    0    0    0    I    0    0    0    0    0    0    0    0    0    ADFGi
            //  0    0    0    0    0    0    0    I    0    0    0    0    0    0    0    0    ADFHi

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

            //  X(0)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], bceg);
            Assert.AreEqual(register[1], bceh);
            Assert.AreEqual(register[2], bcfg);
            Assert.AreEqual(register[3], bcfh);
            Assert.AreEqual(register[4], bdeg);
            Assert.AreEqual(register[5], bdeh);
            Assert.AreEqual(register[6], bdfg);
            Assert.AreEqual(register[7], bdfh);
            Assert.AreEqual(register[8], aceg);
            Assert.AreEqual(register[9], aceh);
            Assert.AreEqual(register[10], acfg);
            Assert.AreEqual(register[11], acfh);
            Assert.AreEqual(register[12], adeg);
            Assert.AreEqual(register[13], adeh);
            Assert.AreEqual(register[14], adfg);
            Assert.AreEqual(register[15], adfh);

            Assert.AreEqual(aceg.Amplitude.Real, 1);
            Assert.AreEqual(aceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(aceh.Amplitude.Real, 1);
            Assert.AreEqual(aceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfg.Amplitude.Real, 1);
            Assert.AreEqual(acfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfh.Amplitude.Real, 1);
            Assert.AreEqual(acfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeg.Amplitude.Real, 1);
            Assert.AreEqual(adeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeh.Amplitude.Real, 1);
            Assert.AreEqual(adeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfg.Amplitude.Real, 1);
            Assert.AreEqual(adfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfh.Amplitude.Real, 1);
            Assert.AreEqual(adfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceg.Amplitude.Real, -1);
            Assert.AreEqual(bceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceh.Amplitude.Real, -1);
            Assert.AreEqual(bceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfg.Amplitude.Real, -1);
            Assert.AreEqual(bcfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfh.Amplitude.Real, -1);
            Assert.AreEqual(bcfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeg.Amplitude.Real, -1);
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeh.Amplitude.Real, -1);
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfh.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 1);

            //  Reversible

            //  -BCEGi -BCEHi -BCFGi -BCFHi -BDEGi -BDEHi -BDFGi -BDFGi ACEGi  ACEHi  ACFGi  ACFHi  ADEGi  ADEHi  ADFGi  ADFHi
            //   0      0      0      0      0      0      0      0    -I      0      0      0      0      0      0      0     ACEG
            //   0      0      0      0      0      0      0      0     0     -I      0      0      0      0      0      0     ACEH
            //   0      0      0      0      0      0      0      0     0      0     -I      0      0      0      0      0     ACFG
            //   0      0      0      0      0      0      0      0     0      0      0     -I      0      0      0      0     ACFH
            //   0      0      0      0      0      0      0      0     0      0      0      0     -I      0      0      0     ADEG
            //   0      0      0      0      0      0      0      0     0      0      0      0      0     -I      0      0     ADEH
            //   0      0      0      0      0      0      0      0     0      0      0      0      0      0     -I      0     ADFG
            //   0      0      0      0      0      0      0      0     0      0      0      0      0      0      0     -I     ADFH
            //   I      0      0      0      0      0      0      0     0      0      0      0      0      0      0      0     BCEG
            //   0      I      0      0      0      0      0      0     0      0      0      0      0      0      0      0     BCEH
            //   0      0      I      0      0      0      0      0     0      0      0      0      0      0      0      0     BCFG
            //   0      0      0      I      0      0      0      0     0      0      0      0      0      0      0      0     BCFH
            //   0      0      0      0      I      0      0      0     0      0      0      0      0      0      0      0     BDEG
            //   0      0      0      0      0      I      0      0     0      0      0      0      0      0      0      0     BDEH
            //   0      0      0      0      0      0      I      0     0      0      0      0      0      0      0      0     BDFG
            //   0      0      0      0      0      0      0      I     0      0      0      0      0      0      0      0     BDFH

            register.StateVector = _pauliYGate.ApplyTo(position, register);

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
        public void PauliYGate4QubitPostion1()
        {
            int position = 1;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  aceg + aceh + acfg + acfh + adeg + adeh + adfg + adfh + bceg + bceh + bcfg + bcfh + bdeg + bdeh + bdfg + bdfh

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0    0    0   -I    0    0    0    0    0    0    0    0    0    0    0    -ADEGi
            //  0    0    0    0    0   -I    0    0    0    0    0    0    0    0    0    0    -ADEHi
            //  0    0    0    0    0    0   -I    0    0    0    0    0    0    0    0    0    -ADFGi
            //  0    0    0    0    0    0    0   -I    0    0    0    0    0    0    0    0    -ADFHi
            //  I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEHi
            //  0    0    I    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFGi
            //  0    0    0    I    0    0    0    0    0    0    0    0    0    0    0    0    ACFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0   -I    0    0    0    -BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -I    0    0    -BDEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -I    0    -BDFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -I    -BDFHi
            //  0    0    0    0    0    0    0    0    I    0    0    0    0    0    0    0    BCEGi
            //  0    0    0    0    0    0    0    0    0    I    0    0    0    0    0    0    BCEHi
            //  0    0    0    0    0    0    0    0    0    0    I    0    0    0    0    0    BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0    I    0    0    0    0    BCFHi

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

            //  X(1)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], adeg);
            Assert.AreEqual(register[1], adeh);
            Assert.AreEqual(register[2], adfg);
            Assert.AreEqual(register[3], adfh);
            Assert.AreEqual(register[4], aceg);
            Assert.AreEqual(register[5], aceh);
            Assert.AreEqual(register[6], acfg);
            Assert.AreEqual(register[7], acfh);
            Assert.AreEqual(register[8], bdeg);
            Assert.AreEqual(register[9], bdeh);
            Assert.AreEqual(register[10], bdfg);
            Assert.AreEqual(register[11], bdfh);
            Assert.AreEqual(register[12], bceg);
            Assert.AreEqual(register[13], bceh);
            Assert.AreEqual(register[14], bcfg);
            Assert.AreEqual(register[15], bcfh);

            Assert.AreEqual(aceg.Amplitude.Real, 1);
            Assert.AreEqual(aceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(aceh.Amplitude.Real, 1);
            Assert.AreEqual(aceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfg.Amplitude.Real, 1);
            Assert.AreEqual(acfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfh.Amplitude.Real, 1);
            Assert.AreEqual(acfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeg.Amplitude.Real, -1);
            Assert.AreEqual(adeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeh.Amplitude.Real, -1);
            Assert.AreEqual(adeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfg.Amplitude.Real, -1);
            Assert.AreEqual(adfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfh.Amplitude.Real, -1);
            Assert.AreEqual(adfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceg.Amplitude.Real, 1);
            Assert.AreEqual(bceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceh.Amplitude.Real, 1);
            Assert.AreEqual(bceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfg.Amplitude.Real, 1);
            Assert.AreEqual(bcfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfh.Amplitude.Real, 1);
            Assert.AreEqual(bcfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeg.Amplitude.Real, -1);
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeh.Amplitude.Real, -1);
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfh.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 1);

            //  Reversible

            //  -ADEGi -ADEHi -ADFGi -ADFHi  ACEGi  ACEHi  ACFGi  ACFHi -BDEGi -BDEHi -BDFGi -BDFHi  BCEGi  BCEHi  BCFGi  BCFHi
            //   0      0      0      0     -I      0      0      0      0      0      0      0      0      0      0      0     -ADEGi
            //   0      0      0      0      0     -I      0      0      0      0      0      0      0      0      0      0     -ADEHi
            //   0      0      0      0      0      0     -I      0      0      0      0      0      0      0      0      0     -ADFGi
            //   0      0      0      0      0      0      0     -I      0      0      0      0      0      0      0      0     -ADFHi
            //   I      0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEGi
            //   0      I      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEHi
            //   0      0      I      0      0      0      0      0      0      0      0      0      0      0      0      0     ACFGi
            //   0      0      0      I      0      0      0      0      0      0      0      0      0      0      0      0     ACFHi
            //   0      0      0      0      0      0      0      0      0      0      0      0     -I      0      0      0     -BDEGi
            //   0      0      0      0      0      0      0      0      0      0      0      0      0     -I      0      0     -BDEHi
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0     -I      0     -BDFGi
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     -I     -BDFHi
            //   0      0      0      0      0      0      0      0      I      0      0      0      0      0      0      0     BCEGi
            //   0      0      0      0      0      0      0      0      0      I      0      0      0      0      0      0     BCEHi
            //   0      0      0      0      0      0      0      0      0      0      I      0      0      0      0      0     BCFGi
            //   0      0      0      0      0      0      0      0      0      0      0      I      0      0      0      0     BCFHi

            register.StateVector = _pauliYGate.ApplyTo(position, register);

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
        public void PauliYGate4QubitPostion2()
        {
            int position = 2;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  aceg + aceh + acfg + acfh + adeg + adeh + adfg + adfh + bceg + bceh + bcfg + bcfh + bdeg + bdeh + bdfg + bdfh

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0    0   -I    0    0    0    0    0    0    0    0    0    0    0    0    0    -ACFGi
            //  0    0    0   -I    0    0    0    0    0    0    0    0    0    0    0    0    -ACFHi
            //  I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEHi
            //  0    0    0    0    0    0   -I    0    0    0    0    0    0    0    0    0    -ADFGi
            //  0    0    0    0    0    0    0   -I    0    0    0    0    0    0    0    0    -ADFHi
            //  0    0    0    0    I    0    0    0    0    0    0    0    0    0    0    0    ADEGi
            //  0    0    0    0    0    I    0    0    0    0    0    0    0    0    0    0    ADEHi
            //  0    0    0    0    0    0    0    0    0    0   -I    0    0    0    0    0    -BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0   -I    0    0    0    0    -BCFHi
            //  0    0    0    0    0    0    0    0    I    0    0    0    0    0    0    0    BCEGi
            //  0    0    0    0    0    0    0    0    0    I    0    0    0    0    0    0    BCEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0   -I    0    -BDFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -I    -BDFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    I    0    0    0    BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    I    0    0    BDEHi

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

            //  X(2)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], acfg);
            Assert.AreEqual(register[1], acfh);
            Assert.AreEqual(register[2], aceg);
            Assert.AreEqual(register[3], aceh);
            Assert.AreEqual(register[4], adfg);
            Assert.AreEqual(register[5], adfh);
            Assert.AreEqual(register[6], adeg);
            Assert.AreEqual(register[7], adeh);
            Assert.AreEqual(register[8], bcfg);
            Assert.AreEqual(register[9], bcfh);
            Assert.AreEqual(register[10], bceg);
            Assert.AreEqual(register[11], bceh);
            Assert.AreEqual(register[12], bdfg);
            Assert.AreEqual(register[13], bdfh);
            Assert.AreEqual(register[14], bdeg);
            Assert.AreEqual(register[15], bdeh);

            Assert.AreEqual(aceg.Amplitude.Real, 1);
            Assert.AreEqual(aceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(aceh.Amplitude.Real, 1);
            Assert.AreEqual(aceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfg.Amplitude.Real, -1);
            Assert.AreEqual(acfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfh.Amplitude.Real, -1);
            Assert.AreEqual(acfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeg.Amplitude.Real, 1);
            Assert.AreEqual(adeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeh.Amplitude.Real, 1);
            Assert.AreEqual(adeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfg.Amplitude.Real, -1);
            Assert.AreEqual(adfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfh.Amplitude.Real, -1);
            Assert.AreEqual(adfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceg.Amplitude.Real, 1);
            Assert.AreEqual(bceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceh.Amplitude.Real, 1);
            Assert.AreEqual(bceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfg.Amplitude.Real, -1);
            Assert.AreEqual(bcfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfh.Amplitude.Real, -1);
            Assert.AreEqual(bcfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeg.Amplitude.Real, 1);
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeh.Amplitude.Real, 1);
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfg.Amplitude.Real, -1);
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfh.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 1);

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

            register.StateVector = _pauliYGate.ApplyTo(position, register);

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
        public void PauliYGate4QubitPostion3()
        {
            int position = 3;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A + B) (x) (C + D) (x) (E + F) (x) (G + H)
            //  ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH + BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH

            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  0   -I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    -ACEHi
            //  I    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEGi
            //  0    0    0   -I    0    0    0    0    0    0    0    0    0    0    0    0    -ACFHi
            //  0    0    I    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFGi
            //  0    0    0    0    0   -I    0    0    0    0    0    0    0    0    0    0    -ADEHi
            //  0    0    0    0    I    0    0    0    0    0    0    0    0    0    0    0    ADEGi
            //  0    0    0    0    0    0    0   -I    0    0    0    0    0    0    0    0    -ADFHi
            //  0    0    0    0    0    0    I    0    0    0    0    0    0    0    0    0    ADFGi
            //  0    0    0    0    0    0    0    0    0   -I    0    0    0    0    0    0    -BCEHi
            //  0    0    0    0    0    0    0    0    I    0    0    0    0    0    0    0    BCEGi
            //  0    0    0    0    0    0    0    0    0    0    0   -I    0    0    0    0    -BCFHi
            //  0    0    0    0    0    0    0    0    0    0    I    0    0    0    0    0    BCFGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0   -I    0    0    -BDEHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    I    0    0    0    BDEGi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0   -I    -BDFHi
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    I    0    BDFGi

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

            //  X(2)
            register.StateVector = _pauliYGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], aceh);
            Assert.AreEqual(register[1], aceg);
            Assert.AreEqual(register[2], acfh);
            Assert.AreEqual(register[3], acfg);
            Assert.AreEqual(register[4], adeh);
            Assert.AreEqual(register[5], adeg);
            Assert.AreEqual(register[6], adfh);
            Assert.AreEqual(register[7], adfg);
            Assert.AreEqual(register[8], bceh);
            Assert.AreEqual(register[9], bceg);
            Assert.AreEqual(register[10], bcfh);
            Assert.AreEqual(register[11], bcfg);
            Assert.AreEqual(register[12], bdeh);
            Assert.AreEqual(register[13], bdeg);
            Assert.AreEqual(register[14], bdfh);
            Assert.AreEqual(register[15], bdfg);

            Assert.AreEqual(aceg.Amplitude.Real, 1);
            Assert.AreEqual(aceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(aceh.Amplitude.Real, -1);
            Assert.AreEqual(aceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfg.Amplitude.Real, 1);
            Assert.AreEqual(acfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(acfh.Amplitude.Real, -1);
            Assert.AreEqual(acfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeg.Amplitude.Real, 1);
            Assert.AreEqual(adeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adeh.Amplitude.Real, -1);
            Assert.AreEqual(adeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfg.Amplitude.Real, 1);
            Assert.AreEqual(adfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(adfh.Amplitude.Real, -1);
            Assert.AreEqual(adfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceg.Amplitude.Real, 1);
            Assert.AreEqual(bceg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bceh.Amplitude.Real, -1);
            Assert.AreEqual(bceh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfg.Amplitude.Real, 1);
            Assert.AreEqual(bcfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bcfh.Amplitude.Real, -1);
            Assert.AreEqual(bcfh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeg.Amplitude.Real, 1);
            Assert.AreEqual(bdeg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdeh.Amplitude.Real, -1);
            Assert.AreEqual(bdeh.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfg.Amplitude.Real, 1);
            Assert.AreEqual(bdfg.Amplitude.Imaginary, 1);

            Assert.AreEqual(bdfh.Amplitude.Real, -1);
            Assert.AreEqual(bdfh.Amplitude.Imaginary, 1);

            //  Reversible

            //  -ACEHi  ACEGi -ACFHi  ACFGi -ADEHi  ADEGi -ADFHi  ADFGi -BCEHi  BCEGi -BCFHi  BCFGi -BDEHi  BDEGi -BDFHi  BDFGi 
            //   0     -I      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEG
            //   I      0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     ACEH
            //   0      0      0     -I      0      0      0      0      0      0      0      0      0      0      0      0     ACFG
            //   0      0      I      0      0      0      0      0      0      0      0      0      0      0      0      0     ACFH
            //   0      0      0      0      0     -I      0      0      0      0      0      0      0      0      0      0     ADEG
            //   0      0      0      0      I      0      0      0      0      0      0      0      0      0      0      0     ADEH
            //   0      0      0      0      0      0      0     -I      0      0      0      0      0      0      0      0     ADFG
            //   0      0      0      0      0      0      I      0      0      0      0      0      0      0      0      0     ADFH
            //   0      0      0      0      0      0      0      0      0     -I      0      0      0      0      0      0     BCEG
            //   0      0      0      0      0      0      0      0      I      0      0      0      0      0      0      0     BCEH
            //   0      0      0      0      0      0      0      0      0      0      0     -I      0      0      0      0     BCFG
            //   0      0      0      0      0      0      0      0      0      0      I      0      0      0      0      0     BCFH
            //   0      0      0      0      0      0      0      0      0      0      0      0      0     -I      0      0     BDEG
            //   0      0      0      0      0      0      0      0      0      0      0      0      I      0      0      0     BDEH
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0      0     -I     BDFG
            //   0      0      0      0      0      0      0      0      0      0      0      0      0      0      I      0     BDFH

            register.StateVector = _pauliYGate.ApplyTo(position, register);

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
