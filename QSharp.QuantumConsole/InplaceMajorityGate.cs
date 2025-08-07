#region Using References

using System;

using QSharp.Mathematics;

#endregion

namespace QSharp.QuantumConsole
{
    public class InplaceMajorityGate : SquareEightMatrix
    {
        #region Constructors

        public InplaceMajorityGate()
        {
            /*
             * 
             0, 1, 2, 3, 4, 5, 6, 7
            {
            {1, 0, 0, 0, 0, 0, 0, 0},   0
            {0, 0, 0, 0, 0, 0, 0, 1},   1
            {0, 0, 1, 0, 0, 0, 0, 0},   2
            {0, 0, 0, 0, 0, 1, 0, 0},   3
            {0, 0, 0, 0, 1, 0, 0, 0},   4
            {0, 0, 0, 1, 0, 0, 0, 0},   5
            {0, 1, 0, 0, 0, 0, 0, 0},   6
            {0, 0, 0, 0, 0, 0, 1, 0}    7
            }
            */

            //  this[Row, Column] = Value

            this[0, 0] = 1;
            this[1, 7] = 1;
            this[2, 2] = 1;
            this[3, 5] = 1;
            this[4, 4] = 1;
            this[5, 3] = 1;
            this[6, 1] = 1;
            this[7, 6] = 1;
        }

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

        public override ComputationalBasisState[] ApplyTo(Register Register)
        {
            return ApplyTo(0, 1, 2, Register);
        }

        public override ComputationalBasisState[] ApplyTo(int Control1, int Control2, int Target, Register Register)
        {
            Matrix oMatrix = this;

            for (int i = 3; i < Register.Qubits.Length; i++)
            {
                oMatrix = oMatrix.Tensor(new IdentityMatrix());
            }

            return oMatrix * Register;
        }

        #endregion

        #region Delegates

        #endregion
    }
}
