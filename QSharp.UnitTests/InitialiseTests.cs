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
        [TestMethod]
        public void Initialise2Qubit1Zero()
        {
            double a = 0.895605948166482;
            double b = 0.444848272570342;
            double c = 0.119824829065728;
            double d = 0.992795049513931;

            Register register = new Register(new Qubit[] { new Qubit(a, b), new Qubit(c, d) });

            //  register.InitialiseToZero(1);
        }
    }
}
