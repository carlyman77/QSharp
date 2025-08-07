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
        public MatrixTensorTests()
        {
            _hadamardGate = new HadamardGate();
            _identityMatrix = new IdentityMatrix();
            _pauliXGate = new PauliXGate();
            _pauliYGate = new PauliYGate();
            _pauliZGate = new PauliZGate();
            _toffoliGate = new ToffoliGate();
        }

        private readonly HadamardGate _hadamardGate;
        private readonly IdentityMatrix _identityMatrix;
        private readonly PauliXGate _pauliXGate;
        private readonly PauliYGate _pauliYGate;
        private readonly PauliZGate _pauliZGate;
        private readonly ToffoliGate _toffoliGate;

        [TestMethod]
        public void TensorIH()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_hadamardGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIHI()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_hadamardGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIH()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_hadamardGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorHII()
        {
            Matrix tensorMatrix = _hadamardGate.Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorHIII()
        {
            Matrix tensorMatrix = _hadamardGate.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIHII()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_hadamardGate).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIHI()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_hadamardGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIIH()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_hadamardGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 3;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
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

            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliXGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIY()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliYGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIZ()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliZGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorHI()
        {

            Matrix tensorMatrix = _hadamardGate.Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_hadamardGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
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

            Matrix tensorMatrix = _pauliXGate.Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
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

            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliXGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
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

            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_pauliXGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
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

            Matrix tensorMatrix = _pauliXGate.Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorXIII()
        {
            Matrix tensorMatrix = _pauliXGate.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIXII()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliXGate).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIXI()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_pauliXGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIIX()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_pauliXGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 3;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliXGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorYI()
        {
            Matrix tensorMatrix = _pauliYGate.Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIYI()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliYGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIY()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_pauliYGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorYII()
        {
            Matrix tensorMatrix = _pauliYGate.Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorYIII()
        {
            Matrix tensorMatrix = _pauliYGate.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIYII()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliYGate).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIYI()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_pauliYGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIIY()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_pauliYGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 3;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliYGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorZI()
        {
            Matrix tensorMatrix = _pauliZGate.Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 2;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIZI()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliZGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIZ()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_pauliZGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorZII()
        {
            Matrix tensorMatrix = _pauliZGate.Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorZIII()
        {
            Matrix tensorMatrix = _pauliZGate.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 0;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIZII()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_pauliZGate).Tensor(_identityMatrix).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 1;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIZI()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_pauliZGate).Tensor(_identityMatrix);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 2;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorIIIZ()
        {
            Matrix tensorMatrix = _identityMatrix.Tensor(_identityMatrix).Tensor(_identityMatrix).Tensor(_pauliZGate);
            Matrix matrix = new SquareOneMatrix(1);

            int index = 3;
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                matrix = ((i == index) ? matrix.Tensor(_pauliZGate) : matrix.Tensor(new IdentityMatrix()));
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorTTTTT()
        {
            Matrix tensorMatrix = _toffoliGate
                .Tensor(_toffoliGate)
                .Tensor(_toffoliGate)
                .Tensor(_toffoliGate)
                .Tensor(_toffoliGate);

            Matrix matrix = new SquareOneMatrix(1);

            int count = 5;

            for (int i = 0; i < count; i++)
            {
                matrix = matrix.Tensor(_toffoliGate);
            }

            Assert.AreEqual(tensorMatrix, matrix);
        }

        [TestMethod]
        public void TensorToffoliUpperBound()
        {
            //	Matrix matrix = new SquareOneMatrix(1);
            //	
            //	int count = 10;
            //	
            //	for (int i = 0; i < count; i++)
            //	{
            //		matrix = matrix.Tensor(oToffoliGate);
            //	}
        }
    }
}
