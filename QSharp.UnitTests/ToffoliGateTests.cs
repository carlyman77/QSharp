#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class ToffoliGateTests : GateTests
    {
        public ToffoliGateTests()
        {
            oToffoliGate = new ToffoliGate();
        }

        private readonly ToffoliGate oToffoliGate;

        [TestMethod]
        public void ToffoliGate3QubitControl0Control1Target2()
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

            //  CCT CCT
            //  000 000
            //  001 001
            //  010 010
            //  011 011
            //  100 100
            //  101 101
            //  110 111
            //  111 110

            //  ACE ACF ADE ADF BCE BCF BDE BDF
            //  1   0   0   0   0   0   0   0   ACE
            //  0   1   0   0   0   0   0   0   ACF
            //  0   0   1   0   0   0   0   0   ADE
            //  0   0   0   1   0   0   0   0   ADF
            //  0   0   0   0   1   0   0   0   BCE
            //  0   0   0   0   0   1   0   0   BCF
            //  0   0   0   0   0   0   0   1   BDF
            //  0   0   0   0   0   0   1   0   BDE

            //  TOFFOLI(0, 1, 2)
            register.StateVector = oToffoliGate.ApplyTo(0, 1, 2, register);

            Assert.AreEqual(register[0], ace);
            Assert.AreEqual(register[1], acf);
            Assert.AreEqual(register[2], ade);
            Assert.AreEqual(register[3], adf);
            Assert.AreEqual(register[4], bce);
            Assert.AreEqual(register[5], bcf);
            Assert.AreEqual(register[6], bdf);
            Assert.AreEqual(register[7], bde);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(0, 1, 2)
            register.StateVector = oToffoliGate.ApplyTo(0, 1, 2, register);

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
        public void ToffoliGate4QubitControl0Control1Target2()
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

            //  CCT  CCT
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
            //  1100 1110
            //  1101 1111
            //  1110 1100
            //  1111 1101

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
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH

            //  TOFFOLI(0, 1, 2)
            register.StateVector = oToffoliGate.ApplyTo(0, 1, 2, register);

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
            Assert.AreEqual(register[12], bdfg);
            Assert.AreEqual(register[13], bdfh);
            Assert.AreEqual(register[14], bdeg);
            Assert.AreEqual(register[15], bdeh);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(0, 1, 2)
            register.StateVector = oToffoliGate.ApplyTo(0, 1, 2, register);

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
        public void ToffoliGate4QubitControl0Control1Target3()
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

            //  CC T CC T
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
            //  1100 1101
            //  1101 1100
            //  1110 1111
            //  1111 1110

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
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG

            //  TOFFOLI(0, 1, 3)
            register.StateVector = oToffoliGate.ApplyTo(0, 1, 3, register);

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
            Assert.AreEqual(register[12], bdeh);
            Assert.AreEqual(register[13], bdeg);
            Assert.AreEqual(register[14], bdfh);
            Assert.AreEqual(register[15], bdfg);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(0, 1, 3)
            register.StateVector = oToffoliGate.ApplyTo(0, 1, 3, register);

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
        public void ToffoliGate4QubitControl0Control2Target1()
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

            //  CTC  CTC
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
            //  1010 1110
            //  1011 1111
            //  1100 1100
            //  1101 1101
            //  1110 1010
            //  1111 1011

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
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH

            //  TOFFOLI(0, 2, 1)
            register.StateVector = oToffoliGate.ApplyTo(0, 2, 1, register);

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
            Assert.AreEqual(register[10], bdfg);
            Assert.AreEqual(register[11], bdfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bcfg);
            Assert.AreEqual(register[15], bcfh);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(0, 2, 1)
            register.StateVector = oToffoliGate.ApplyTo(0, 2, 1, register);

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
        public void ToffoliGate4QubitControl0Control2Target3()
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

            //  C CT C CT
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
            //  1010 1011
            //  1011 1010
            //  1100 1100
            //  1101 1101
            //  1110 1111
            //  1111 1110

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
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG

            //  TOFFOLI(0, 2, 3)
            register.StateVector = oToffoliGate.ApplyTo(0, 2, 3, register);

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
            Assert.AreEqual(register[10], bcfh);
            Assert.AreEqual(register[11], bcfg);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfh);
            Assert.AreEqual(register[15], bdfg);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(0, 2, 3)
            register.StateVector = oToffoliGate.ApplyTo(0, 2, 3, register);

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
        public void ToffoliGate4QubitControl0Control3Target2()
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

            //  C TC C TC
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
            //  1001 1011
            //  1010 1010
            //  1011 1001
            //  1100 1100
            //  1101 1111
            //  1110 1110
            //  1111 1101

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH

            //  TOFFOLI(0, 3, 2)
            register.StateVector = oToffoliGate.ApplyTo(0, 3, 2, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bcfh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bceh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdfh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdeh);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(0, 3, 2)
            register.StateVector = oToffoliGate.ApplyTo(0, 3, 2, register);

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
        public void ToffoliGate4QubitControl1Control2Target0()
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

            //  TCC  TCC
            //  0123 0123

            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0100
            //  0101 0101
            //  0110 1110
            //  0111 1111

            //  1000 1000
            //  1001 1001
            //  1010 1010
            //  1011 1011
            //  1100 1100
            //  1101 1101
            //  1110 0110
            //  1111 0111

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH

            //  TOFFOLI(1, 2, 0)
            register.StateVector = oToffoliGate.ApplyTo(1, 2, 0, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], bdfg);
            Assert.AreEqual(register[7], bdfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], adfg);
            Assert.AreEqual(register[15], adfh);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(1, 2, 0)
            register.StateVector = oToffoliGate.ApplyTo(1, 2, 0, register);

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
        public void ToffoliGate4QubitControl1Control2Target3()
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

            //   CCT  CCT
            //  0123 0123

            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0100
            //  0101 0101
            //  0110 0111
            //  0111 0110

            //  1000 1000
            //  1001 1001
            //  1010 1010
            //  1011 1011
            //  1100 1100
            //  1101 1101
            //  1110 1111
            //  1111 1110

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFH

            //  TOFOLLI(1, 2, 3)
            register.StateVector = oToffoliGate.ApplyTo(1, 2, 3, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfh);
            Assert.AreEqual(register[7], adfg);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfh);
            Assert.AreEqual(register[15], bdfg);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFOLLI(1, 2, 3)
            register.StateVector = oToffoliGate.ApplyTo(1, 2, 3, register);

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
        public void ToffoliGate4QubitControl1Control3Target2()
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

            //   CTC  CTC
            //  0123 0123

            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0011
            //  0100 0100
            //  0101 0111
            //  0110 0110
            //  0111 0101

            //  1000 1000
            //  1001 1001
            //  1010 1010
            //  1011 1011
            //  1100 1100
            //  1101 1111
            //  1110 1110
            //  1111 1101

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH

            //  TOFFOLI(1, 3, 2)
            register.StateVector = oToffoliGate.ApplyTo(1, 3, 2, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], acfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adfh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], adeh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bcfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdfh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bdeh);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(1, 3, 2)
            register.StateVector = oToffoliGate.ApplyTo(1, 3, 2, register);

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
        public void ToffoliGate4QubitControl2Control3Target1()
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

            //   TCC  TCC
            //  0123 0123

            //  0000 0000
            //  0001 0001
            //  0010 0010
            //  0011 0111
            //  0100 0100
            //  0101 0101
            //  0110 0110
            //  0111 0011

            //  1000 1000
            //  1001 1001
            //  1010 1010
            //  1011 1111
            //  1100 1100
            //  1101 1101
            //  1110 1110
            //  1111 1011

            //  0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111
            //  ACEG ACEH ACFG ACFH ADEG ADEH ADFG ADFH BCEG BCEH BCFG BCFH BDEG BDEH BDFG BDFH
            //  1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEG
            //  0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    ACEH
            //  0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    ACFG
            //  0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    ADFH
            //  0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    ADEG
            //  0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    ADEH
            //  0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    ADFG
            //  0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    ACFH
            //  0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    BCEG
            //  0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    BCEH
            //  0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    BCFG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    BDFH
            //  0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    BDEG
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    BDEH
            //  0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    BDFG
            //  0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    BCFH

            //  TOFFOLI(2, 3, 1)
            register.StateVector = oToffoliGate.ApplyTo(2, 3, 1, register);

            Assert.AreEqual(register[0], aceg);
            Assert.AreEqual(register[1], aceh);
            Assert.AreEqual(register[2], acfg);
            Assert.AreEqual(register[3], adfh);
            Assert.AreEqual(register[4], adeg);
            Assert.AreEqual(register[5], adeh);
            Assert.AreEqual(register[6], adfg);
            Assert.AreEqual(register[7], acfh);
            Assert.AreEqual(register[8], bceg);
            Assert.AreEqual(register[9], bceh);
            Assert.AreEqual(register[10], bcfg);
            Assert.AreEqual(register[11], bdfh);
            Assert.AreEqual(register[12], bdeg);
            Assert.AreEqual(register[13], bdeh);
            Assert.AreEqual(register[14], bdfg);
            Assert.AreEqual(register[15], bcfh);

            ValidateComputationalStateVector(register.StateVector);

            //  TOFFOLI(2, 3, 1)
            register.StateVector = oToffoliGate.ApplyTo(2, 3, 1, register);

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

