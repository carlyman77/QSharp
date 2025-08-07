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
        [TestMethod]
        public void CombineIIWithXI()
        {
            IdentityMatrix identityMatrix = new IdentityMatrix();
            PauliXGate pauliXGate = new PauliXGate();

            //  I (x) I
            Matrix matrixA = identityMatrix.Tensor(identityMatrix);

            //  I (x) X
            //  Control (x) Target
            Matrix matrixB = pauliXGate.Tensor(identityMatrix);
            Matrix combineMatrix = matrixA.Combine(matrixB);

            Matrix testMatrix = new SquareMatrix(8, 0);

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

            testMatrix[0, 0] = 1;
            testMatrix[1, 1] = 1;
            testMatrix[2, 2] = 1;
            testMatrix[3, 3] = 1;
            testMatrix[4, 6] = 1;
            testMatrix[5, 7] = 1;
            testMatrix[6, 4] = 1;
            testMatrix[7, 5] = 1;

            Assert.AreEqual(combineMatrix, testMatrix);    
        }

        [TestMethod]
        public void CombineIWithX()
        {
            IdentityMatrix identityMatrix = new IdentityMatrix();
            PauliXGate pauliXGate = new PauliXGate();

            //  This is the same as a CNOT gate
            Matrix combineMatrix = identityMatrix.Combine(pauliXGate);
            CNotGate cNotGate = new CNotGate();

            Assert.AreEqual(combineMatrix, cNotGate);
        }

        [TestMethod]
        public void CombineIWithXWithI()
        {
            IdentityMatrix identityMatrix = new IdentityMatrix();
            PauliXGate pauliXGate = new PauliXGate();

            Matrix combineMatrix = identityMatrix.Combine(pauliXGate).Combine(identityMatrix);
            Matrix testMatrix = new SquareMatrix(8, 0);

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

            testMatrix[0, 0] = 1;
            testMatrix[1, 1] = 1;
            testMatrix[2, 3] = 1;
            testMatrix[3, 2] = 1;
            testMatrix[4, 4] = 1;
            testMatrix[5, 5] = 1;
            testMatrix[6, 6] = 1;
            testMatrix[7, 7] = 1;

            Assert.AreEqual(combineMatrix, testMatrix);        
        }
    }
}
