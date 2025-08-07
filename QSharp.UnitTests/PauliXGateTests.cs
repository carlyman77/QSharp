#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class PauliXGateTests : GateTests
    {
        public PauliXGateTests()
        {
            _pauliXGate = new PauliXGate();
        }

        private readonly PauliXGate _pauliXGate;

        [TestMethod]
        public void PauliXGate1Qubit()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit() });

            //  > Initial state:
            //  > A|0> + B|1> = (0.687A|0> + 0.727B|1>)

            //  A   B
            //  0   1   = (0 * 0.687A|0>) + (1 * 0.727B|1>) = 0.727B|1>
            //  1   0   = (1 * 0.687A|0>) + (0 * 0.727B|1>) = 0.687A|0>

            //  (A|0> + B|1>) = (1A|0> + 2B|1>)
            //  (C|0> + D|1>) = (3A|0> + 4B|1>)

            //  (AC|00> + AD|01> + BC|10> + BD|11>)

            //  > X_1
            //  > (B|0>) = 0.727|0>
            //  > (A|1>) = 0.687|1>

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            //  X(0)
            register.StateVector = _pauliXGate.ApplyTo(position, register);

            //  A|0> mapped to A|1>
            //  B|1> mapped to B|0>
            Assert.AreEqual(register[0], b);
            Assert.AreEqual(register[1], a);

            ValidateComputationalStateVector(register.StateVector);

            //  Reversible
            //  X(0)
            register.StateVector = _pauliXGate.ApplyTo(position, register);

            //  B|0> mapped to B|1>
            //  A|1> mapped to A|0>
            Assert.AreEqual(register[0], a);
            Assert.AreEqual(register[1], b);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void PauliXGate2QubitPostion0()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A|00> + B|01> + C|10> + D|11>) = (0.687A|0> + 0.727B|1>)

            //  AC  AD  BC  BD
            //  0   0   1   0   BC
            //  0   0   0   1   BD
            //  1   0   0   0   AC
            //  0   1   0   0   AD

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  X(0)
            register.StateVector = _pauliXGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], bc);
            Assert.AreEqual(register[1], bd);
            Assert.AreEqual(register[2], ac);
            Assert.AreEqual(register[3], ad);

            ValidateComputationalStateVector(register.StateVector);

            //  Reversible

            //  BC  BD  AC  AD
            //  0   0   1   0   AC
            //  0   0   0   1   AD
            //  1   0   0   0   BC
            //  0   1   0   0   BD

            register.StateVector = _pauliXGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void PauliXGate2QubitPostion1()
        {
            int position = 1;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit() });

            //  (A|00> + B|01> + C|10> + D|11>) = (0.687A|0> + 0.727B|1>)

            //  AC  AD  BC  BD
            //  0   1   0   0   AD
            //  1   0   0   0   AC
            //  0   0   0   1   BD
            //  0   0   1   0   BC

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  X(1)
            register.StateVector = _pauliXGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ad);
            Assert.AreEqual(register[1], ac);
            Assert.AreEqual(register[2], bd);
            Assert.AreEqual(register[3], bc);

            ValidateComputationalStateVector(register.StateVector);

            //  Reversible

            //  AD  AC  BD  BC
            //  0   1   0   0   AC
            //  1   0   0   0   AD
            //  0   0   0   1   BC
            //  0   0   1   0   BD

            register.StateVector = _pauliXGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ac);
            Assert.AreEqual(register[1], ad);
            Assert.AreEqual(register[2], bc);
            Assert.AreEqual(register[3], bd);

            ValidateComputationalStateVector(register.StateVector);
        }

        [TestMethod]
        public void PauliXGate3QubitPostion0()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

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

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  X(0)
            register.StateVector = _pauliXGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], bce);
            Assert.AreEqual(register[1], bcf);
            Assert.AreEqual(register[2], bde);
            Assert.AreEqual(register[3], bdf);
            Assert.AreEqual(register[4], ace);
            Assert.AreEqual(register[5], acf);
            Assert.AreEqual(register[6], ade);
            Assert.AreEqual(register[7], adf);

            ValidateComputationalStateVector(register.StateVector);

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

            register.StateVector = _pauliXGate.ApplyTo(position, register);

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
        public void PauliXGate3QubitPostion1()
        {
            int position = 1;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

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

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  X(1)
            register.StateVector = _pauliXGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], ade);
            Assert.AreEqual(register[1], adf);
            Assert.AreEqual(register[2], ace);
            Assert.AreEqual(register[3], acf);
            Assert.AreEqual(register[4], bde);
            Assert.AreEqual(register[5], bdf);
            Assert.AreEqual(register[6], bce);
            Assert.AreEqual(register[7], bcf);

            ValidateComputationalStateVector(register.StateVector);

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

            register.StateVector = _pauliXGate.ApplyTo(position, register);

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
        public void PauliXGate3QubitPostion2()
        {
            int position = 2;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

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

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

            //  X(2)
            register.StateVector = _pauliXGate.ApplyTo(position, register);

            Assert.AreEqual(register[0], acf);
            Assert.AreEqual(register[1], ace);
            Assert.AreEqual(register[2], adf);
            Assert.AreEqual(register[3], ade);
            Assert.AreEqual(register[4], bcf);
            Assert.AreEqual(register[5], bce);
            Assert.AreEqual(register[6], bdf);
            Assert.AreEqual(register[7], bde);

            ValidateComputationalStateVector(register.StateVector);

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

            register.StateVector = _pauliXGate.ApplyTo(position, register);

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
        public void PauliXGate4QubitPostion0()
        {
            int position = 0;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

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
            register.StateVector = _pauliXGate.ApplyTo(position, register);

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

            ValidateComputationalStateVector(register.StateVector);

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

            register.StateVector = _pauliXGate.ApplyTo(position, register);

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
        public void PauliXGate4QubitPostion1()
        {
            int position = 1;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

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
            register.StateVector = _pauliXGate.ApplyTo(position, register);

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

            ValidateComputationalStateVector(register.StateVector);

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

            register.StateVector = _pauliXGate.ApplyTo(position, register);

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
        public void PauliXGate4QubitPostion2()
        {
            int position = 2;
            Register register = new Register(new Qubit[] { new Qubit(1, 1), new Qubit(1, 1), new Qubit(1, 1), new Qubit(1, 1) });

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
            register.StateVector = _pauliXGate.ApplyTo(position, register);

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

            ValidateComputationalStateVector(register.StateVector);

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

            register.StateVector = _pauliXGate.ApplyTo(position, register);

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
        public void PauliXGate4QubitPostion3()
        {
            int position = 3;
            Register register = new Register(new Qubit[] { Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit(), Qubit.OneValueQubit() });

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
            register.StateVector = _pauliXGate.ApplyTo(position, register);

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

            ValidateComputationalStateVector(register.StateVector);

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

            register.StateVector = _pauliXGate.ApplyTo(position, register);

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
