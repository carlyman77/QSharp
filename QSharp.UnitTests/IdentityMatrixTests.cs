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
        #region Constructors

        public IdentityMatrixTests()
        {
            oIdentityMatrix = new IdentityMatrix();
            oQubit = new Qubit(Alpha, Beta);
        }

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private IdentityMatrix oIdentityMatrix;
        private Qubit oQubit;

        #endregion

        #region Properties

        #endregion

        #region Methods

        [TestMethod]
        public void Identity()
        {
        }

        #endregion

        #region Delegates

        #endregion
    }
}
