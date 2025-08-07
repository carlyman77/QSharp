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
        [TestMethod]
        public void Measure1QubitX0Test0()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureX(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitX0Test1()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureX(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitX0Test2()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureX(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure1QubitX0Test3()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureX(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitX0Test0()
        {
            int measureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            //  double[] dPrbabilities = new double[2]
            //  {
            //      (ac.Amplitude.ModSquare() + ad.Amplitude.ModSquare()),
            //      (bc.Amplitude.ModSquare() + bd.Amplitude.ModSquare())
            //  };

            int state = register.MeasureX(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (bc + bd)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitX1Test0()
        {
            int measureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            int state = register.MeasureX(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test0()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test1()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test2()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure1QubitZ0Test3()
        {
            int measureIndex = 0;

            double dA = 0.641;
            double dB = 0.768;

            Register register = new Register(new Qubit[] { new Qubit(dA, dB) });

            ComputationalBasisState a = register.StateVector[0];
            ComputationalBasisState b = register.StateVector[1];

            Assert.AreEqual(a.Amplitude.Real.Round(10), dA);
            Assert.AreEqual(b.Amplitude.Real.Round(10), dB);

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                Assert.IsTrue(register.StateVector[0].Amplitude != 0);
                Assert.AreEqual(register.StateVector[1].Amplitude, 0);
            }
            else
            {
                Assert.AreEqual(register.StateVector[0].Amplitude, 0);
                Assert.IsTrue(register.StateVector[1].Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test0()
        {
            int measureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            //  double[] dPrbabilities = new double[2]
            //  {
            //      (ac.Amplitude.ModSquare() + ad.Amplitude.ModSquare()),
            //      (bc.Amplitude.ModSquare() + bd.Amplitude.ModSquare())
            //  };

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test1()
        {
            int measureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            //  double[] dPrbabilities = new double[2]
            //  {
            //      (ac.Amplitude.ModSquare() + ad.Amplitude.ModSquare()),
            //      (bc.Amplitude.ModSquare() + bd.Amplitude.ModSquare())
            //  };

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test2()
        {
            int measureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            //  double[] dPrbabilities = new double[2]
            //  {
            //      (ac.Amplitude.ModSquare() + ad.Amplitude.ModSquare()),
            //      (bc.Amplitude.ModSquare() + bd.Amplitude.ModSquare())
            //  };

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ0Test3()
        {
            int measureIndex = 0;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 01) => (AC + AD)
            //  P_1 = (10 + 11) => (BC + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            //  double[] dPrbabilities = new double[2]
            //  {
            //      (ac.Amplitude.ModSquare() + ad.Amplitude.ModSquare()),
            //      (bc.Amplitude.ModSquare() + bd.Amplitude.ModSquare())
            //  };

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 01) => (AC + AD)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (10 + 11) => (BC + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ1Test0()
        {
            int measureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.IsTrue(bd.Amplitude != 0);
            } 
        }

        [TestMethod]
        public void Measure2QubitZ1Test1()
        {
            int measureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure2QubitZ1Test2()
        {
            int measureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure2QubitZ1Test3()
        {
            int measureIndex = 1;

            double dA = 0.520;
            double dB = 0.854;
            double dC = 0.641;
            double dD = 0.768;

            double dac = (dA * dC);
            double dad = (dA * dD);
            double dbc = (dB * dC);
            double dbd = (dB * dD);

            Register register = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            ComputationalBasisState ac = register.StateVector[0];
            ComputationalBasisState ad = register.StateVector[1];
            ComputationalBasisState bc = register.StateVector[2];
            ComputationalBasisState bd = register.StateVector[3];

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //   M
            //  00
            //  01
            //  10
            //  11

            //  P_0 = (00 + 10) => (AC + BC)
            //  P_1 = (01 + 11) => (AD + BD)

            Assert.AreEqual(ac.Amplitude.Real.Round(10), dac.Round(10));
            Assert.AreEqual(ad.Amplitude.Real.Round(10), dad.Round(10));
            Assert.AreEqual(bc.Amplitude.Real.Round(10), dbc.Round(10));
            Assert.AreEqual(bd.Amplitude.Real.Round(10), dbd.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (00 + 10) => (AC + BC)
                Assert.IsTrue(ac.Amplitude != 0);
                Assert.AreEqual(ad.Amplitude, 0);
                Assert.IsTrue(bc.Amplitude != 0);
                Assert.AreEqual(bd.Amplitude, 0);
            }
            else
            {
                //  P_1 = (01 + 11) => (AD + BD)
                Assert.AreEqual(ac.Amplitude, 0);
                Assert.IsTrue(ad.Amplitude != 0);
                Assert.AreEqual(bc.Amplitude, 0);
                Assert.IsTrue(bd.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitX0Test0()
        {
            int measureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureX(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ0Test0()
        {
            int measureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ0Test1()
        {
            int measureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ0Test2()
        {
            int measureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure3QubitZ0Test3()
        {
            int measureIndex = 0;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 010 + 011) => (ACE + ACF + ADE + ADF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (100 + 101 + 110 + 111) => (BCE + BCF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test0()
        {
            int measureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test1()
        {
            int measureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test2()
        {
            int measureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ1Test3()
        {
            int measureIndex = 1;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 001 + 100 + 101) => (ACE + ACF + BCE + BCF)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (010 + 011 + 110 + 111) => (ADE + ADF + BDE + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ2Test0()
        {
            int measureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ2Test1()
        {
            int measureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure3QubitZ2Test2()
        {
            int measureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }
        
        [TestMethod]
        public void Measure3QubitZ2Test3()
        {
            int measureIndex = 2;

            double dA = 0.71393431776757943;
            double dB = 0.700212674773701;
            double dC = 0.870669007926644;
            double dD = 0.491869371516497;
            double dE = 0.627403547723271;
            double dF = 0.778694284237564;

            double dace = (dA * dC * dE);
            double dacf = (dA * dC * dF);
            double dade = (dA * dD * dE);
            double dadf = (dA * dD * dF);
            double dbce = (dB * dC * dE);
            double dbcf = (dB * dC * dF);
            double dbde = (dB * dD * dE);
            double dbdf = (dB * dD * dF);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF)
            });

            ComputationalBasisState ace = register.StateVector[0];
            ComputationalBasisState acf = register.StateVector[1];
            ComputationalBasisState ade = register.StateVector[2];
            ComputationalBasisState adf = register.StateVector[3];
            ComputationalBasisState bce = register.StateVector[4];
            ComputationalBasisState bcf = register.StateVector[5];
            ComputationalBasisState bde = register.StateVector[6];
            ComputationalBasisState bdf = register.StateVector[7];

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

            Assert.AreEqual(ace.Amplitude.Real.Round(10), dace.Round(10));
            Assert.AreEqual(acf.Amplitude.Real.Round(10), dacf.Round(10));
            Assert.AreEqual(ade.Amplitude.Real.Round(10), dade.Round(10));
            Assert.AreEqual(adf.Amplitude.Real.Round(10), dadf.Round(10));
            Assert.AreEqual(bce.Amplitude.Real.Round(10), dbce.Round(10));
            Assert.AreEqual(bcf.Amplitude.Real.Round(10), dbcf.Round(10));
            Assert.AreEqual(bde.Amplitude.Real.Round(10), dbde.Round(10));
            Assert.AreEqual(bdf.Amplitude.Real.Round(10), dbdf.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (000 + 010 + 100 + 110) => (ACE + ADE + BCE + BDE)
                Assert.IsTrue(ace.Amplitude != 0);
                Assert.AreEqual(acf.Amplitude, 0);
                Assert.IsTrue(ade.Amplitude != 0);
                Assert.AreEqual(adf.Amplitude, 0);
                Assert.IsTrue(bce.Amplitude != 0);
                Assert.AreEqual(bcf.Amplitude, 0);
                Assert.IsTrue(bde.Amplitude != 0);
                Assert.AreEqual(bdf.Amplitude, 0);
            }
            else
            {
                //  P_1 = (001 + 011 + 101 + 111) => (ACF + ADF + BCF + BDF)
                Assert.AreEqual(ace.Amplitude, 0);
                Assert.IsTrue(acf.Amplitude != 0);
                Assert.AreEqual(ade.Amplitude, 0);
                Assert.IsTrue(adf.Amplitude != 0);
                Assert.AreEqual(bce.Amplitude, 0);
                Assert.IsTrue(bcf.Amplitude != 0);
                Assert.AreEqual(bde.Amplitude, 0);
                Assert.IsTrue(bdf.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test0()
        {
            int measureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test1()
        {
            int measureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test2()
        {
            int measureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ0Test3()
        {
            int measureIndex = 0;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 0100 + 0101 + 0110 + 0111) => (ACEG + ACEH + ACFG + ACFH + ADEG + ADEH + ADFG + ADFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (1000 + 1001 + 1010 + 1011 + 1100 + 1101 + 1110 + 1111) => (BCEG + BCEH + BCFG + BCFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test0()
        {
            int measureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test1()
        {
            int measureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test2()
        {
            int measureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ1Test3()
        {
            int measureIndex = 1;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0010 + 0011 + 1000 + 1001 + 1010 + 1011) => (ACEG + ACEH + ACFG + ACFH + BCEG + BCEH + BCFG + BCFH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0100 + 0101 + 0110 + 0111 + 1100 + 1101 + 1110 + 1111) => (ADEG + ADEH + ADFG + ADFH + BDEG + BDEH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test0()
        {
            int measureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test1()
        {
            int measureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test2()
        {
            int measureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ2Test3()
        {
            int measureIndex = 2;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0001 + 0100 + 0101 + 1000 + 1001 + 1100 + 1101) => (ACEG + ACEH + ADEG + ADEH + BCEG + BCEH + BDEG + BDEH)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0010 + 0011 + 0110 + 0111 + 1010 + 1011 + 1110 + 1111) => (ACFG + ACFH + ADFG + ADFH + BCFG + BCFH + BDFG + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test0()
        {
            int measureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test1()
        {
            int measureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test2()
        {
            int measureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }

        [TestMethod]
        public void Measure4QubitZ3Test3()
        {
            int measureIndex = 3;

            double dA = 0.384054324124933;
            double dB = 0.923310498218742;
            double dC = 0.683827115303116;
            double dD = 0.729644075132677;
            double dE = 0.983654779818102;
            double dF = 0.180064638785637;
            double dG = 0.662784430422039;
            double dH = 0.748810255532156;

            double daceg = (dA * dC * dE * dG);
            double daceh = (dA * dC * dE * dH);
            double dacfg = (dA * dC * dF * dG);
            double dacfh = (dA * dC * dF * dH);
            double dadeg = (dA * dD * dE * dG);
            double dadeh = (dA * dD * dE * dH);
            double dadfg = (dA * dD * dF * dG);
            double dadfh = (dA * dD * dF * dH);
            double dbceg = (dB * dC * dE * dG);
            double dbceh = (dB * dC * dE * dH);
            double dbcfg = (dB * dC * dF * dG);
            double dbcfh = (dB * dC * dF * dH);
            double dbdeg = (dB * dD * dE * dG);
            double dbdeh = (dB * dD * dE * dH);
            double dbdfg = (dB * dD * dF * dG);
            double dbdfh = (dB * dD * dF * dH);

            Register register = new Register(new Qubit[]
            {
                new Qubit(dA, dB),
                new Qubit(dC, dD),
                new Qubit(dE, dF),
                new Qubit(dG, dH)
            });

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

            Assert.AreEqual(aceg.Amplitude.Real.Round(10), daceg.Round(10));
            Assert.AreEqual(aceh.Amplitude.Real.Round(10), daceh.Round(10));
            Assert.AreEqual(acfg.Amplitude.Real.Round(10), dacfg.Round(10));
            Assert.AreEqual(acfh.Amplitude.Real.Round(10), dacfh.Round(10));
            Assert.AreEqual(adeg.Amplitude.Real.Round(10), dadeg.Round(10));
            Assert.AreEqual(adeh.Amplitude.Real.Round(10), dadeh.Round(10));
            Assert.AreEqual(adfg.Amplitude.Real.Round(10), dadfg.Round(10));
            Assert.AreEqual(adfh.Amplitude.Real.Round(10), dadfh.Round(10));
            Assert.AreEqual(bceg.Amplitude.Real.Round(10), dbceg.Round(10));
            Assert.AreEqual(bceh.Amplitude.Real.Round(10), dbceh.Round(10));
            Assert.AreEqual(bcfg.Amplitude.Real.Round(10), dbcfg.Round(10));
            Assert.AreEqual(bcfh.Amplitude.Real.Round(10), dbcfh.Round(10));
            Assert.AreEqual(bdeg.Amplitude.Real.Round(10), dbdeg.Round(10));
            Assert.AreEqual(bdeh.Amplitude.Real.Round(10), dbdeh.Round(10));
            Assert.AreEqual(bdfg.Amplitude.Real.Round(10), dbdfg.Round(10));
            Assert.AreEqual(bdfh.Amplitude.Real.Round(10), dbdfh.Round(10));

            int state = register.MeasureZ(measureIndex);
            ValidatePefectQubitState(register.Qubits[measureIndex], state);

            if (state == 0)
            {
                //  P_0 = (0000 + 0010 + 0100 + 0110 + 1000 + 1010 + 1100 + 1110) => (ACEG + ACFG + ADEG + ADFG + BCEG + BCFG + BDEG + BDFG)
                Assert.IsTrue(aceg.Amplitude != 0);
                Assert.AreEqual(aceh.Amplitude, 0);
                Assert.IsTrue(acfg.Amplitude != 0);
                Assert.AreEqual(acfh.Amplitude, 0);
                Assert.IsTrue(adeg.Amplitude != 0);
                Assert.AreEqual(adeh.Amplitude, 0);
                Assert.IsTrue(adfg.Amplitude != 0);
                Assert.AreEqual(adfh.Amplitude, 0);
                Assert.IsTrue(bceg.Amplitude != 0);
                Assert.AreEqual(bceh.Amplitude, 0);
                Assert.IsTrue(bcfg.Amplitude != 0);
                Assert.AreEqual(bcfh.Amplitude, 0);
                Assert.IsTrue(bdeg.Amplitude != 0);
                Assert.AreEqual(bdeh.Amplitude, 0);
                Assert.IsTrue(bdfg.Amplitude != 0);
                Assert.AreEqual(bdfh.Amplitude, 0);
            }
            else
            {
                //  P_1 = (0001 + 0011 + 0101 + 0111 + 1001 + 1011 + 1101 + 1111) => (ACEH + ACFH + ADEH + ADFH + BCEH + BCFH + BDEH + BDFH)
                Assert.AreEqual(aceg.Amplitude, 0);
                Assert.IsTrue(aceh.Amplitude != 0);
                Assert.AreEqual(acfg.Amplitude, 0);
                Assert.IsTrue(acfh.Amplitude != 0);
                Assert.AreEqual(adeg.Amplitude, 0);
                Assert.IsTrue(adeh.Amplitude != 0);
                Assert.AreEqual(adfg.Amplitude, 0);
                Assert.IsTrue(adfh.Amplitude != 0);
                Assert.AreEqual(bceg.Amplitude, 0);
                Assert.IsTrue(bceh.Amplitude != 0);
                Assert.AreEqual(bcfg.Amplitude, 0);
                Assert.IsTrue(bcfh.Amplitude != 0);
                Assert.AreEqual(bdeg.Amplitude, 0);
                Assert.IsTrue(bdeh.Amplitude != 0);
                Assert.AreEqual(bdfg.Amplitude, 0);
                Assert.IsTrue(bdfh.Amplitude != 0);
            }
        }
    }
}
