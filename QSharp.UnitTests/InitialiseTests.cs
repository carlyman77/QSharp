#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class InitialiseTests : GateTests
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
        public void Initialise2Qubit1Zero()
        {
            double dA = 0.895605948166482;
            double dB = 0.444848272570342;
            double dC = 0.119824829065728;
            double dD = 0.992795049513931;

            Register oRegister = new Register(new Qubit[] { new Qubit(dA, dB), new Qubit(dC, dD) });

            //  oRegister.InitialiseToZero(1);
        }

        #endregion

        #region Delegates

        #endregion
    }
}
