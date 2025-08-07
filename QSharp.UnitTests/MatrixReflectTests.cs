#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class MatrixReflectTests
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
        public void Reflect2x2()
        {
            Matrix oMatrix = new IdentityMatrix();
            oMatrix.Reflect();

			Matrix oTestMatrix = new Matrix(2, 2)
			{
				[0, 0] = 0,
				[0, 1] = 1,
				[1, 0] = 1,
				[1, 1] = 0
			};

			// {
			// {0, 1},
			// {1, 0}
			// }

            Assert.AreEqual(oMatrix, oTestMatrix);
        }

		[TestMethod]
		public void Reflect4x4()
		{
			Matrix oMatrix = new IdentityMatrix().Tensor(new IdentityMatrix());
			oMatrix.Reflect();

			Matrix oTestMatrix = new Matrix(4, 4)
			{
				[0, 0] = 0,
				[0, 1] = 0,
				[0, 2] = 0,
				[0, 3] = 1,
				[1, 0] = 0,
				[1, 1] = 0,
				[1, 2] = 1,
				[1, 3] = 0,
				[2, 0] = 0,
				[2, 1] = 1,
				[2, 2] = 0,
				[2, 3] = 0,
				[3, 0] = 1,
				[3, 1] = 0,
				[3, 2] = 0,
				[3, 3] = 0,
			};

			Assert.AreEqual(oMatrix, oTestMatrix);
		}

		#endregion

		#region Delegates

		#endregion
	}
}
