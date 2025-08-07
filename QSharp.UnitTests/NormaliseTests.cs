#region Using References

using System;
using System.Numerics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class NormaliseTests : GateTests
    {
        public const int DecimalRoundingPlaces = 10;

        [TestMethod]
        public void NormaliseThreeQubitsN10()
        {
            Register register = new Register(3);

            for (int i = 0; i < register.Count; i++)
            {
                register[i].Amplitude = new Complex(((i + 1) * 10), 0);
            }

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void NormaliseThreeQubitsNOther()
        {
            Register register = new Register(3);

            register[0].Amplitude = new Complex(0.1, 0);
            register[1].Amplitude = new Complex(0.435, 0);
            register[2].Amplitude = new Complex(0.546, 0);
            register[3].Amplitude = new Complex(0.123, 0);
            register[4].Amplitude = new Complex(0.234, 0);
            register[5].Amplitude = new Complex(0.789, 0);
            register[6].Amplitude = new Complex(0.712, 0);
            register[7].Amplitude = new Complex(0.78234 , 0);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseTwoQubits0()
        {
            Register register = new Register(2);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseTwoQubits1()
        {
            Register register = new Register(2);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseTwoQubits3()
        {
            Register register = new Register(2);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseThreeQubits0()
        {
            Register register = new Register(3);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseThreeQubits1()
        {
            Register register = new Register(2);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseThreeQubits3()
        {
            Register register = new Register(2);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFourQubits0()
        {
            Register register = new Register(4);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFourQubits1()
        {
            Register register = new Register(4);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFourQubits3()
        {
            Register register = new Register(4);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFiveQubits0()
        {
            Register register = new Register(5);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFiveQubits1()
        {
            Register register = new Register(5);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFiveQubits3()
        {
            Register register = new Register(5);

            if (register.IsNormalised() == false)
            {
                register.Normalise();
            }

            Assert.IsTrue(register.IsNormalised());
        }
    }
}
