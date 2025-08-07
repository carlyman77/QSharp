#region Using References

using System;
using System.Numerics;

using QSharp.Mathematics;
using QSharp.Mathematics.Commands;

#endregion

namespace QSharp.QuantumConsole
{
    public class ClearRegisterCommand : Command
    {
        public ClearRegisterCommand()
            : base("CLEAR")
        {
        }

        public override CommandResult Execute(string Value, Register Register)
        {
            CommandResult oCommandResult = base.Execute(Value, Register);

            if (oCommandResult == null)
            {
                foreach (ComputationalBasisState oComputationalBasisState in Register.StateVector)
                {
                    oComputationalBasisState.Amplitude = new Complex();
                }
            }

            return oCommandResult;
        }
    }
}
