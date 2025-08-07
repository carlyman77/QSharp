#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class MatrixCombineTests
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
        public void CombineIIWithXI()
        {
            IdentityMatrix oIdentityMatrix = new IdentityMatrix();
            PauliXGate oPauliXGate = new PauliXGate();

            //  I (x) I
            Matrix oMatrixA = oIdentityMatrix.Tensor(oIdentityMatrix);

            //  I (x) X
            //  Control (x) Target
            Matrix oMatrixB = oPauliXGate.Tensor(oIdentityMatrix);
            Matrix oCombineMatrix = oMatrixA.Combine(oMatrixB);

            Matrix oTestMatrix = new SquareMatrix(8, 0);

            //  {
            //  {1, 0, 0, 0, 0, 0, 0, 0}
            //  {0, 1, 0, 0, 0, 0, 0, 0}
            //  {0, 0, 1, 0, 0, 0, 0, 0}
            //  {0, 0, 0, 1, 0, 0, 0, 0}
            //  {0, 0, 0, 0, 0, 0, 1, 0}
            //  {0, 0, 0, 0, 0, 0, 0, 1}
            //  {0, 0, 0, 0, 1, 0, 0, 0}
            //  {0, 0, 0, 0, 0, 1, 0, 0}
            //  }

            oTestMatrix[0, 0] = 1;
            oTestMatrix[1, 1] = 1;
            oTestMatrix[2, 2] = 1;
            oTestMatrix[3, 3] = 1;
            oTestMatrix[4, 6] = 1;
            oTestMatrix[5, 7] = 1;
            oTestMatrix[6, 4] = 1;
            oTestMatrix[7, 5] = 1;

            Assert.AreEqual(oCombineMatrix, oTestMatrix);    
        }

        [TestMethod]
        public void CombineIWithX()
        {
            IdentityMatrix oIdentityMatrix = new IdentityMatrix();
            PauliXGate oPauliXGate = new PauliXGate();

            //  This is the same as a CNOT gate
            Matrix oCombineMatrix = oIdentityMatrix.Combine(oPauliXGate);
            CNotGate oCNotGate = new CNotGate();

            Assert.AreEqual(oCombineMatrix, oCNotGate);
        }

        [TestMethod]
        public void CombineIWithXWithI()
        {
            IdentityMatrix oIdentityMatrix = new IdentityMatrix();
            PauliXGate oPauliXGate = new PauliXGate();

            Matrix oCombineMatrix = oIdentityMatrix.Combine(oPauliXGate).Combine(oIdentityMatrix);
            Matrix oTestMatrix = new SquareMatrix(8, 0);

            //  {
            //  {1, 0, 0, 0, 0, 0, 0, 0}
            //  {0, 1, 0, 0, 0, 0, 0, 0}
            //  {0, 0, 0, 1, 0, 0, 0, 0}
            //  {0, 0, 1, 0, 0, 0, 0, 0}
            //  {0, 0, 0, 0, 1, 0, 0, 0}
            //  {0, 0, 0, 0, 0, 1, 0, 0}
            //  {0, 0, 0, 0, 0, 0, 1, 0}
            //  {0, 0, 0, 0, 0, 0, 0, 1}
            //  }

            oTestMatrix[0, 0] = 1;
            oTestMatrix[1, 1] = 1;
            oTestMatrix[2, 3] = 1;
            oTestMatrix[3, 2] = 1;
            oTestMatrix[4, 4] = 1;
            oTestMatrix[5, 5] = 1;
            oTestMatrix[6, 6] = 1;
            oTestMatrix[7, 7] = 1;

            Assert.AreEqual(oCombineMatrix, oTestMatrix);        
        }

        #endregion

        #region Delegates

        #endregion
    }
}
