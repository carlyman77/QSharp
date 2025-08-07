#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;
using QSharp.Mathematics.Extensions;
using System.Numerics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class NormaliseTests : GateTests
    {
        #region Constructors

        #endregion

        #region Constants

        public const int DecimalRoundingPlaces = 10;

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
        public void NormaliseThreeQubitsN10()
        {
            Register oRegister = new Register(3);

            for (int i = 0; i < oRegister.Count; i++)
            {
                oRegister[i].Amplitude = new Complex(((i + 1) * 10), 0);
            }

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void NormaliseThreeQubitsNOther()
        {
            Register oRegister = new Register(3);

            oRegister[0].Amplitude = new Complex(0.1, 0);
            oRegister[1].Amplitude = new Complex(0.435, 0);
            oRegister[2].Amplitude = new Complex(0.546, 0);
            oRegister[3].Amplitude = new Complex(0.123, 0);
            oRegister[4].Amplitude = new Complex(0.234, 0);
            oRegister[5].Amplitude = new Complex(0.789, 0);
            oRegister[6].Amplitude = new Complex(0.712, 0);
            oRegister[7].Amplitude = new Complex(0.78234 , 0);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseTwoQubits0()
        {
            Register oRegister = new Register(2);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseTwoQubits1()
        {
            Register oRegister = new Register(2);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseTwoQubits3()
        {
            Register oRegister = new Register(2);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseThreeQubits0()
        {
            Register oRegister = new Register(3);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseThreeQubits1()
        {
            Register oRegister = new Register(2);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseThreeQubits3()
        {
            Register oRegister = new Register(2);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFourQubits0()
        {
            Register oRegister = new Register(4);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFourQubits1()
        {
            Register oRegister = new Register(4);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFourQubits3()
        {
            Register oRegister = new Register(4);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFiveQubits0()
        {
            Register oRegister = new Register(5);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFiveQubits1()
        {
            Register oRegister = new Register(5);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }

        [TestMethod]
        public void RandomNormaliseFiveQubits3()
        {
            Register oRegister = new Register(5);

            if (oRegister.IsNormalised() == false)
            {
                oRegister.Normalise();
            }

            Assert.IsTrue(oRegister.IsNormalised());
        }
        
        #endregion

        #region Delegates

        #endregion
    }
}
