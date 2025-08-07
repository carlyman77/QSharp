#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class MatrixTensorTests
    {
        #region Constructors

        public MatrixTensorTests()
        {
            oHadamardGate = new HadamardGate();
            oIdentityMatrix = new IdentityMatrix();
            oPauliXGate = new PauliXGate();
            oPauliYGate = new PauliYGate();
            oPauliZGate = new PauliZGate();
			oToffoliGate = new ToffoliGate();

		}

        #endregion

        #region Constants

        #endregion

        #region Events

        #endregion

        #region Enumerations

        #endregion

        #region Fields

        private HadamardGate oHadamardGate;
        private IdentityMatrix oIdentityMatrix;
        private PauliXGate oPauliXGate;
        private PauliYGate oPauliYGate;
		private PauliZGate oPauliZGate;
		private ToffoliGate oToffoliGate;

		#endregion

		#region Properties

		#endregion

		#region Methods

		[TestMethod]
        public void TensorIH()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oHadamardGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIHI()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oHadamardGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIH()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oHadamardGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorHII()
        {
            Matrix oTensorMatrix = oHadamardGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorHIII()
        {
            Matrix oTensorMatrix = oHadamardGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIHII()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oHadamardGate).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIHI()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oHadamardGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIIH()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oHadamardGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 3;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIX()
        {
            //  X = {{0,1},{1,0}}
            //  I = {{1,0},{0,1}}

            //  0     1
            //  I (x) X

            //  If there is a matrix on the left, then move to that.
            //  If there is a matrix on the right, then tensor with that

            //  {{1,0},{0,1}} (x) {{0,1},{1,0}} => 
            //  {
            //  {0,1,0,0},
            //  {1,0,0,0},
            //  {0,0,0,1},
            //  {0,0,1,1}
            //  }

            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliXGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIY()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliYGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIZ()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliZGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorHI()
        {

            Matrix oTensorMatrix = oHadamardGate.Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oHadamardGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorXI()
        {
            //  X = {{0,1},{1,0}}
            //  I = {{1,0},{0,1}}

            //  0     1     2
            //  I (x) X (x) I
            //  (I (x) X) (x) I

            //  If there is a matrix on the left, then move to that.
            //  If there is a matrix on the right, then tensor with that

            //  0   1   2
            //  I   X   I
            //  Move to 1
            //  Tensor with 0

            //  0   1
            //  IX  I
            //  Move to 1
            //  Tensor with 0

            //  {{1,0},{0,1}} (x) {{0,1},{1,0}} => 
            //  {
            //  {0,0,1,0},
            //  {0,0,0,1},
            //  {1,0,0,0},
            //  {0,1,0,0}
            //  }

            Matrix oTensorMatrix = oPauliXGate.Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIXI()
        {
            //  X = {{0,1},{1,0}}
            //  I = {{1,0},{0,1}}

            //  0     1     2
            //  I (x) X (x) I
            //  (I (x) X) (x) I

            //  If there is a matrix on the left, then move to that.
            //  If there is a matrix on the right, then tensor with that
            
            //  0   1   2
            //  I   X   I
            //  Move to 1
            //  Tensor with 0

            //  0   1
            //  IX  I
            //  Move to 1
            //  Tensor with 0

            //  {{1,0},{0,1}} * {{0,1},{1,0}} * {{1,0},{0,1}} => 
            //  {{0,1,0,0},{1,0,0,0},{0,0,0,1},{0,0,1,1}} * {{1,0},{0,1}} => 
            //  {
            //  {0,0,1,0,0,0,0,0},
            //  {0,0,0,1,0,0,0,0},
            //  {1,0,0,0,0,0,0,0},
            //  {0,1,0,0,0,0,0,0},
            //  {0,0,0,0,0,0,1,0},
            //  {0,0,0,0,0,0,0,1},
            //  {0,0,0,0,1,0,0,0},
            //  {0,0,0,0,0,1,0,0}
            //  }

            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliXGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIX()
        {
            //  X = {{0,1},{1,0}}
            //  I = {{1,0},{0,1}}

            //  0     1     2
            //  I (x) I (x) X
            //  (I (x) I) (x) X

            //  {{1,0},{0,1}} * {{1,0},{0,1}} * {{0,1},{1,0}} => 
            //  {{1,0,0,0},{0,1,0,0},{0,0,1,0},{0,0,0,1} * {{0,1},{1,0}} => 
            //  {
            //  {0,1,0,0,0,0,0,0},
            //  {1,0,0,0,0,0,0,0},
            //  {0,0,0,1,0,0,0,0},
            //  {0,0,1,0,0,0,0,0},
            //  {0,0,0,0,0,1,0,0},
            //  {0,0,0,0,1,0,0,0},
            //  {0,0,0,0,0,0,0,1},
            //  {0,0,0,0,0,0,1,0}
            //  }

            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oPauliXGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 3;
            
            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorXII()
        {
            //  X = {{0,1},{1,0}}
            //  I = {{1,0},{0,1}}

            //  X (x) I (x) I
            //  1      0      2
            //  (I (x) X) (x) I)

            //  {{0,1},{1,0}} * {{1,0},{0,1}} * {{1,0},{0,1}} => 
            //  {{0,0,1,0},{0,0,0,1},{1,0,0,0},{0,1,0,0}} * {{1,0},{0,1}} =>
            //  {
            //  {0,0,0,0,1,0,0,0},
            //  {0,0,0,0,0,1,0,0},
            //  {0,0,0,0,0,0,1,0}
            //  {0,0,0,0,0,0,0,1},
            //  {1,0,0,0,0,0,0,0},
            //  {0,1,0,0,0,0,0,0},
            //  {0,0,1,0,0,0,0,0},
            //  {0,0,0,1,0,0,0,0}
            //  }

            Matrix oTensorMatrix = oPauliXGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorXIII()
        {
            Matrix oTensorMatrix = oPauliXGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIXII()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliXGate).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIXI()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oPauliXGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIIX()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oPauliXGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 3;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliXGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorYI()
        {
            Matrix oTensorMatrix = oPauliYGate.Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIYI()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliYGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIY()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oPauliYGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorYII()
        {
            Matrix oTensorMatrix = oPauliYGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorYIII()
        {
            Matrix oTensorMatrix = oPauliYGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIYII()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliYGate).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIYI()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oPauliYGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIIY()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oPauliYGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 3;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliYGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorZI()
        {
            Matrix oTensorMatrix = oPauliZGate.Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 2;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIZI()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliZGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIZ()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oPauliZGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorZII()
        {
            Matrix oTensorMatrix = oPauliZGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 3;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorZIII()
        {
            Matrix oTensorMatrix = oPauliZGate.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 0;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIZII()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oPauliZGate).Tensor(oIdentityMatrix).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 1;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIZI()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oPauliZGate).Tensor(oIdentityMatrix);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 2;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

        [TestMethod]
        public void TensorIIIZ()
        {
            Matrix oTensorMatrix = oIdentityMatrix.Tensor(oIdentityMatrix).Tensor(oIdentityMatrix).Tensor(oPauliZGate);
            Matrix oMatrix = new SquareOneMatrix(1);

            int iIndex = 3;
            int iCount = 4;

            for (int i = 0; i < iCount; i++)
            {
                oMatrix = ((i == iIndex) ? oMatrix.Tensor(oPauliZGate) : oMatrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(oTensorMatrix, oMatrix);
        }

		[TestMethod]
		public void TensorTTTTT()
		{
			Matrix oTensorMatrix = oToffoliGate
				.Tensor(oToffoliGate)
				.Tensor(oToffoliGate)
				.Tensor(oToffoliGate)
				.Tensor(oToffoliGate);

			Matrix oMatrix = new SquareOneMatrix(1);

			int iCount = 5;

			for (int i = 0; i < iCount; i++)
			{
				oMatrix = oMatrix.Tensor(oToffoliGate);
			}

			Assert.AreEqual(oTensorMatrix, oMatrix);
		}

		[TestMethod]
		public void TensorToffoliUpperBound()
		{
			//	Matrix oMatrix = new SquareOneMatrix(1);
			//	
			//	int iCount = 10;
			//	
			//	for (int i = 0; i < iCount; i++)
			//	{
			//		oMatrix = oMatrix.Tensor(oToffoliGate);
			//	}
		}

		#endregion

		#region Delegates

		#endregion
		}
}
