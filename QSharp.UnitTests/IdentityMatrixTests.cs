#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class IdentityMatrixTests : GateTests
    {
        public IdentityMatrixTests()
        {
            _identityMatrix = new IdentityMatrix();
            _qubit = new Qubit(Alpha, Beta);
        }

        private IdentityMatrix _identityMatrix;
        private Qubit _qubit;

        [TestMethod]
        public void Identity()
        {
            //  Empty in here
        }
    }
}
