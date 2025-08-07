#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;
using QSharp.Mathematics.Extensions;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class MeasureTests : GateTests
    {
        #region Constructors

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void Measure1QubitX0Test0()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureX(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitX0Test1()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureX(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitX0Test2()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureX(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure1QubitX0Test3()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureX(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitX0Test0()
        {
            int iMeasureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            //  double[] dProbabilities = new double[2]
            //  {
            //      (oAC.Amplitude.ModSquare() + oAD.Amplitude.ModSquare()),
            //      (oBC.Amplitude.ModSquare() + oBD.Amplitude.ModSquare())
            //  };

            int iState = oRegister.MeasureX(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitX1Test0()
        {
            int iMeasureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            int iState = oRegister.MeasureX(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test0()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test1()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test2()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test3()
        {
            int iMeasureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState oA = oRegister.StateVector[0];
            ComputationalBasisState oB = oRegister.StateVector[1];

            Assert.AreEqual(oA.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(oB.Amplitude.Real.Round(10), dB);

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                Assert.IsTrue(oRegister.StateVector[0].Amplitude != 0);
                Assert.AreEqual(oRegister.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(oRegister.StateVector[0].Amplitude, 0);
                Assert.IsTrue(oRegister.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test0()
        {
            int iMeasureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            //  double[] dProbabilities = new double[2]
            //  {
            //      (oAC.Amplitude.ModSquare() + oAD.Amplitude.ModSquare()),
            //      (oBC.Amplitude.ModSquare() + oBD.Amplitude.ModSquare())
            //  };

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test1()
        {
            int iMeasureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            //  double[] dProbabilities = new double[2]
            //  {
            //      (oAC.Amplitude.ModSquare() + oAD.Amplitude.ModSquare()),
            //      (oBC.Amplitude.ModSquare() + oBD.Amplitude.ModSquare())
            //  };

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test2()
        {
            int iMeasureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            //  double[] dProbabilities = new double[2]
            //  {
            //      (oAC.Amplitude.ModSquare() + oAD.Amplitude.ModSquare()),
            //      (oBC.Amplitude.ModSquare() + oBD.Amplitude.ModSquare())
            //  };

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test3()
        {
            int iMeasureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            //  double[] dProbabilities = new double[2]
            //  {
            //      (oAC.Amplitude.ModSquare() + oAD.Amplitude.ModSquare()),
            //      (oBC.Amplitude.ModSquare() + oBD.Amplitude.ModSquare())
            //  };

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ1Test0()
        {
            int iMeasureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            } 
        }

        [TestMethod]
        public void Measure2QubitZ1Test1()
        {
            int iMeasureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure2QubitZ1Test2()
        {
            int iMeasureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ1Test3()
        {
            int iMeasureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dAC = (dA * dC);
            double dAD = (dA * dD);
            double dBC = (dB * dC);
            double dBD = (dB * dD);

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState oAC = oRegister.StateVector[0];
            ComputationalBasisState oAD = oRegister.StateVector[1];
            ComputationalBasisState oBC = oRegister.StateVector[2];
            ComputationalBasisState oBD = oRegister.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(oAC.Amplitude.Real.Round(10), dAC.Round(10));
            Assert.AreEqual(oAD.Amplitude.Real.Round(10), dAD.Round(10));
            Assert.AreEqual(oBC.Amplitude.Real.Round(10), dBC.Round(10));
            Assert.AreEqual(oBD.Amplitude.Real.Round(10), dBD.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(oAC.Amplitude != 0);
                Assert.AreEqual(oAD.Amplitude, 0);
                Assert.IsTrue(oBC.Amplitude != 0);
                Assert.AreEqual(oBD.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(oAC.Amplitude, 0);
                Assert.IsTrue(oAD.Amplitude != 0);
                Assert.AreEqual(oBC.Amplitude, 0);
                Assert.IsTrue(oBD.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitX0Test0()
        {
            int iMeasureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //  M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
            //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureX(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ0Test0()
        {
            int iMeasureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //  M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
            //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ0Test1()
        {
            int iMeasureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //  M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
            //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ0Test2()
        {
            int iMeasureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //  M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
            //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure3QubitZ0Test3()
        {
            int iMeasureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //  M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
            //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test0()
        {
            int iMeasureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //   M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
            //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test1()
        {
            int iMeasureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //   M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
            //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test2()
        {
            int iMeasureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //   M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
            //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test3()
        {
            int iMeasureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //   M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
            //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ2Test0()
        {
            int iMeasureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //    M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
            //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ2Test1()
        {
            int iMeasureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //    M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
            //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ2Test2()
        {
            int iMeasureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //    M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
            //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure3QubitZ2Test3()
        {
            int iMeasureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dACE = (dA * dC * dE);
            double dACF = (dA * dC * dF);
            double dADE = (dA * dD * dE);
            double dADF = (dA * dD * dF);
            double dBCE = (dB * dC * dE);
            double dBCF = (dB * dC * dF);
            double dBDE = (dB * dD * dE);
            double dBDF = (dB * dD * dF);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState oACE = oRegister.StateVector[0];
            ComputationalBasisState oACF = oRegister.StateVector[1];
            ComputationalBasisState oADE = oRegister.StateVector[2];
            ComputationalBasisState oADF = oRegister.StateVector[3];
            ComputationalBasisState oBCE = oRegister.StateVector[4];
            ComputationalBasisState oBCF = oRegister.StateVector[5];
            ComputationalBasisState oBDE = oRegister.StateVector[6];
            ComputationalBasisState oBDF = oRegister.StateVector[7];

            //  ACE|000> + ACF|001> + ADE|010> + ADF|011> + BCE|100> + BCF|101> + BDE|110> + BDF|111>

            //    M
            //  000
            //  001
            //  010
            //  011
            //  100
            //  101
            //  110
            //  111

            //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
            //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)

            Assert.AreEqual(oACE.Amplitude.Real.Round(10), dACE.Round(10));
            Assert.AreEqual(oACF.Amplitude.Real.Round(10), dACF.Round(10));
            Assert.AreEqual(oADE.Amplitude.Real.Round(10), dADE.Round(10));
            Assert.AreEqual(oADF.Amplitude.Real.Round(10), dADF.Round(10));
            Assert.AreEqual(oBCE.Amplitude.Real.Round(10), dBCE.Round(10));
            Assert.AreEqual(oBCF.Amplitude.Real.Round(10), dBCF.Round(10));
            Assert.AreEqual(oBDE.Amplitude.Real.Round(10), dBDE.Round(10));
            Assert.AreEqual(oBDF.Amplitude.Real.Round(10), dBDF.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(oACE.Amplitude != 0);
                Assert.AreEqual(oACF.Amplitude, 0);
                Assert.IsTrue(oADE.Amplitude != 0);
                Assert.AreEqual(oADF.Amplitude, 0);
                Assert.IsTrue(oBCE.Amplitude != 0);
                Assert.AreEqual(oBCF.Amplitude, 0);
                Assert.IsTrue(oBDE.Amplitude != 0);
                Assert.AreEqual(oBDF.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(oACE.Amplitude, 0);
                Assert.IsTrue(oACF.Amplitude != 0);
                Assert.AreEqual(oADE.Amplitude, 0);
                Assert.IsTrue(oADF.Amplitude != 0);
                Assert.AreEqual(oBCE.Amplitude, 0);
                Assert.IsTrue(oBCF.Amplitude != 0);
                Assert.AreEqual(oBDE.Amplitude, 0);
                Assert.IsTrue(oBDF.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test0()
        {
            int iMeasureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //  M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
            //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test1()
        {
            int iMeasureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //  M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
            //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test2()
        {
            int iMeasureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //  M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
            //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test3()
        {
            int iMeasureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //  M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
            //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test0()
        {
            int iMeasureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //   M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
            //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test1()
        {
            int iMeasureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //   M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
            //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test2()
        {
            int iMeasureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //   M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
            //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test3()
        {
            int iMeasureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //   M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
            //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test0()
        {
            int iMeasureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //    M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
            //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test1()
        {
            int iMeasureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //    M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
            //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test2()
        {
            int iMeasureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //    M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
            //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test3()
        {
            int iMeasureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //    M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
            //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test0()
        {
            int iMeasureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //     M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
            //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test1()
        {
            int iMeasureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //     M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
            //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test2()
        {
            int iMeasureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //     M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
            //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test3()
        {
            int iMeasureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double dACEG = (dA * dC * dE * dG);
            double dACEH = (dA * dC * dE * dH);
            double dACFG = (dA * dC * dF * dG);
            double dACFH = (dA * dC * dF * dH);
            double dADEG = (dA * dD * dE * dG);
            double dADEH = (dA * dD * dE * dH);
            double dADFG = (dA * dD * dF * dG);
            double dADFH = (dA * dD * dF * dH);
            double dBCEG = (dB * dC * dE * dG);
            double dBCEH = (dB * dC * dE * dH);
            double dBCFG = (dB * dC * dF * dG);
            double dBCFH = (dB * dC * dF * dH);
            double dBDEG = (dB * dD * dE * dG);
            double dBDEH = (dB * dD * dE * dH);
            double dBDFG = (dB * dD * dF * dG);
            double dBDFH = (dB * dD * dF * dH);

            Register oRegister = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            //  ACEG|0000> + ACEH|0001> + ACFG|0010> + ACFH|0011> + ADEG|0100> + ADEH|0101> + ADFG|0110> + ADFH|0111> + 
            //  BCEG|1000> + BCEH|1001> + BCFG|1010> + BCFH|1011> + BDEG|1100> + BDEH|1101> + BDFG|1110> + BDFH|1111>

            //     M
            //  0000
            //  0001
            //  0010
            //  0011
            //  0100
            //  0101
            //  0110
            //  0111
            //  1000
            //  1001
            //  1010
            //  1011
            //  1100
            //  1101
            //  1110
            //  1111

            //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
            //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)

            Assert.AreEqual(oACEG.Amplitude.Real.Round(10), dACEG.Round(10));
            Assert.AreEqual(oACEH.Amplitude.Real.Round(10), dACEH.Round(10));
            Assert.AreEqual(oACFG.Amplitude.Real.Round(10), dACFG.Round(10));
            Assert.AreEqual(oACFH.Amplitude.Real.Round(10), dACFH.Round(10));
            Assert.AreEqual(oADEG.Amplitude.Real.Round(10), dADEG.Round(10));
            Assert.AreEqual(oADEH.Amplitude.Real.Round(10), dADEH.Round(10));
            Assert.AreEqual(oADFG.Amplitude.Real.Round(10), dADFG.Round(10));
            Assert.AreEqual(oADFH.Amplitude.Real.Round(10), dADFH.Round(10));
            Assert.AreEqual(oBCEG.Amplitude.Real.Round(10), dBCEG.Round(10));
            Assert.AreEqual(oBCEH.Amplitude.Real.Round(10), dBCEH.Round(10));
            Assert.AreEqual(oBCFG.Amplitude.Real.Round(10), dBCFG.Round(10));
            Assert.AreEqual(oBCFH.Amplitude.Real.Round(10), dBCFH.Round(10));
            Assert.AreEqual(oBDEG.Amplitude.Real.Round(10), dBDEG.Round(10));
            Assert.AreEqual(oBDEH.Amplitude.Real.Round(10), dBDEH.Round(10));
            Assert.AreEqual(oBDFG.Amplitude.Real.Round(10), dBDFG.Round(10));
            Assert.AreEqual(oBDFH.Amplitude.Real.Round(10), dBDFH.Round(10));

            int iState = oRegister.MeasureZ(iMeasureIndex);
            ValidatePefectQubitState(oRegister.Qubits[iMeasureIndex], iState);

            if (iState == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(oACEG.Amplitude != 0);
                Assert.AreEqual(oACEH.Amplitude, 0);
                Assert.IsTrue(oACFG.Amplitude != 0);
                Assert.AreEqual(oACFH.Amplitude, 0);
                Assert.IsTrue(oADEG.Amplitude != 0);
                Assert.AreEqual(oADEH.Amplitude, 0);
                Assert.IsTrue(oADFG.Amplitude != 0);
                Assert.AreEqual(oADFH.Amplitude, 0);
                Assert.IsTrue(oBCEG.Amplitude != 0);
                Assert.AreEqual(oBCEH.Amplitude, 0);
                Assert.IsTrue(oBCFG.Amplitude != 0);
                Assert.AreEqual(oBCFH.Amplitude, 0);
                Assert.IsTrue(oBDEG.Amplitude != 0);
                Assert.AreEqual(oBDEH.Amplitude, 0);
                Assert.IsTrue(oBDFG.Amplitude != 0);
                Assert.AreEqual(oBDFH.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(oACEG.Amplitude, 0);
                Assert.IsTrue(oACEH.Amplitude != 0);
                Assert.AreEqual(oACFG.Amplitude, 0);
                Assert.IsTrue(oACFH.Amplitude != 0);
                Assert.AreEqual(oADEG.Amplitude, 0);
                Assert.IsTrue(oADEH.Amplitude != 0);
                Assert.AreEqual(oADFG.Amplitude, 0);
                Assert.IsTrue(oADFH.Amplitude != 0);
                Assert.AreEqual(oBCEG.Amplitude, 0);
                Assert.IsTrue(oBCEH.Amplitude != 0);
                Assert.AreEqual(oBCFG.Amplitude, 0);
                Assert.IsTrue(oBCFH.Amplitude != 0);
                Assert.AreEqual(oBDEG.Amplitude, 0);
                Assert.IsTrue(oBDEH.Amplitude != 0);
                Assert.AreEqual(oBDFG.Amplitude, 0);
                Assert.IsTrue(oBDFH.Amplitude != 0);
            }
        }

        #endregion

        #region Delegates

        #endregion
    }
}
