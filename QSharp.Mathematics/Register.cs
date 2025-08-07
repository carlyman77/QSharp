#region Using References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using QSharp.Mathematics.Extensions;

using Maths = System.Math;

#endregion

namespace QSharp.Mathematics
{
    /// <summary>
    /// Describes a register, used to manage a sequence of computational basis states.
    /// </summary>
    public class Register : IList<ComputationalBasisState>
    {
        /// <summary>
        /// Constructs a new instance of the Register type.
        /// </summary>
        /// <param name="count">The number of random qubits used to create the register.</param>
        public Register(int count)
            : this(Qubit.RandomQubits(count))
        {
        }

        /// <summary>
        /// Constructs a new instance of the Register type.
        /// </summary>
        /// <param name="qubits">An array of qubits used to create the register.</param>
        public Register(Qubit[] qubits)
        {
            Qubit.ResetCounters();

			_computationalBasisStates = new List<ComputationalBasisState>();
            _qubits = qubits;

            for (uint i = 0; i < 2.ToPower(_qubits.Length); i++)
            {
                _computationalBasisStates.Add(new ComputationalBasisState(this, i));
            }
        }

        private List<ComputationalBasisState> _computationalBasisStates;
        private readonly Qubit[] _qubits;

        /// <summary>
        /// Gets the number of computational basis states managed by the register.
        /// </summary>
        public int Count
        {
            get
            {
                return _computationalBasisStates.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the contents of the register are read only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the array of qubits.
        /// </summary>
        public Qubit[] Qubits
        {
            get
            {
                return _qubits;
            }
        }

        /// <summary>
        /// Gets or sets an array of computational basis states.
        /// </summary>
        public ComputationalBasisState[] StateVector
        {
            get
            {
                return _computationalBasisStates.ToArray();
            }
            set
            {
                _computationalBasisStates = value.ToList<ComputationalBasisState>();
            }
        }

        /// <summary>
        /// Gets or sets a computational basis state via an index.
        /// </summary>
        /// <param name="index">The corresponding index.</param>
        /// <returns>Returns the value located at the corresponding index.</returns>
        public ComputationalBasisState this[int index]
        {
            get
            {
                return _computationalBasisStates[index];
            }
            set
            {
                _computationalBasisStates[index] = value;
            }
        }

        /// <summary>
        /// Adds an element into the register. Note that ad-hoc element addition and deletion is not supported.
        /// </summary>
        /// <param name="computationalBasisState">The ComputationalBasisState type value to add.</param>
        public void Add(ComputationalBasisState computationalBasisState)
        {
            //  Ad-hoc element manipulation now disabled
            //  _computationalBasisStates.Add(ComputationalBasisState);

            throw new NotSupportedException("Ad-hoc element addition and deletion is not supported.");
        }

        /// <summary>
        /// Clears the register. Note that ad-hoc element addition and deletion is not supported.
        /// </summary>
        public void Clear()
        {
            //  Ad-hoc element manipulation now disabled
            //  _computationalBasisStates.Clear();

            throw new NotSupportedException("Ad-hoc element addition and deletion is not supported.");
        }

        /// <summary>
        /// Determines whether the register contains the specified value.
        /// </summary>
        /// <param name="computationalBasisState">The ComputationalBasisState type value to check.</param>
        /// <returns>Returns a Boolean value representing the result of the operation.</returns>
        public bool Contains(ComputationalBasisState computationalBasisState)
        {
            return _computationalBasisStates.Contains(computationalBasisState);
        }

        /// <summary>
        /// Copies elements from one array to another.
        /// </summary>
        /// <param name="array">The array to copy into.</param>
        /// <param name="arrayIndex">The index from which the copy operation should commence.</param>
        public void CopyTo(ComputationalBasisState[] array, int arrayIndex)
        {
            _computationalBasisStates.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets an enumerator of the computational basis states contained in the register.
        /// </summary>
        /// <returns>Returns a collection enumerator.</returns>
        public IEnumerator<ComputationalBasisState> GetEnumerator()
        {
            return _computationalBasisStates.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator of the computational basis states contained in the register.
        /// </summary>
        /// <returns>Returns a collection enumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _computationalBasisStates.GetEnumerator();
        }

        /// <summary>
        /// Determines the index of the specified element.
        /// </summary>
        /// <param name="computationalBasisState">The element to locate.</param>
        /// <returns>Returns a System.Int32 representing the result of the operation.</returns>
        public int IndexOf(ComputationalBasisState computationalBasisState)
        {
            return _computationalBasisStates.IndexOf(computationalBasisState);
        }

        /*
        public void InitialiseToPlus(int Qubit)
        {
            //  TODO
        }

        public void InitialiseToZero(int Qubit)
        {
            //  TODO

            //  INITIALISE(0, 1);

            //  This should only initialise qubit 1 to 0.
            //  The correct way to do this is to measure qubit 1, and then flip the result (apply X) if you don't get 0.
            //  In short, you need to code up measurement before you code up initialisation.

            int result = MeasureZ(Qubit);

            if (result != 0)
            {
                PauliXGate pauliXGate = new PauliXGate();
                _computationalBasisStates = pauliXGate.ApplyTo(Qubit, this).ToList<ComputationalBasisState>();
            }
        }
        */

        /// <summary>
        /// Inserts an element into the register.
        /// </summary>
        /// <param name="Index">The index at which to insert the element.</param>
        /// <param name="computationalBasisState">The element to insert.</param>
        public void Insert(int Index, ComputationalBasisState computationalBasisState)
        {
            //  Ad-hoc element manipulation now disabled
            //  _computationalBasisStates.Insert(index, computationalBasisState);

            throw new NotSupportedException("Ad-hoc register manipulation is not supported.");
        }

        /// <summary>
        /// Determines if the state vector is normalised.
        /// </summary>
        /// <returns>Returns true if the state vector is normalised, otherwise false.</returns>
        public bool IsNormalised()
        {
            double stateVectorAmplitude = _computationalBasisStates.Sum(m => (Maths.Pow(Maths.Abs(m.Amplitude.Real), 2)));

            return (stateVectorAmplitude.Round(10) == 1.0);
        }

        /// <summary>
        /// Performs a measurement on the register.
        /// </summary>
        /// <param name="basis">The basis to measure, either X or Z.</param>
        /// <param name="qubit">The qubit to measure.</param>
        /// <returns>Returns a System.Int32 representing the result of the operation.</returns>
        public int Measure(string basis, int qubit)
        {
            int measure = -1;

            switch (basis.ToUpper())
            {
                case "X":
                    measure = MeasureX(qubit);
                    break;

                case "Z":
                    measure = MeasureZ(qubit);
                    break;
            }

            return measure;
        }

        /// <summary>
        /// Performs an X measurement on the register.
        /// </summary>
        /// <param name="qubit">The qubit to measure.</param>
        /// <returns>Returns a System.Int32 representing the result of the operation.</returns>
        public int MeasureX(int qubit)
        {
            HadamardGate hadamardGate = new HadamardGate();

            _computationalBasisStates = hadamardGate.ApplyTo(qubit, this).ToList<ComputationalBasisState>();

            return MeasureZ(qubit);
        }

        /// <summary>
        /// Performs a Z measurement on the register.
        /// </summary>
        /// <param name="qubit">The qubit to measure.</param>
        /// <returns>Returns a System.Int32 representing the result of the operation.</returns>
        public int MeasureZ(int qubit)
        {
            int state = 0; //  State actually means whether we measure |0> or |1>, where 0 -> |0> and 1 -> |1>

            //  AC|00> + AD|01> + BC|10> + BD|11>

            //  Measure 0 on Q_0, two states that have a 0 in the first (0) position: AC|00>, AD|01> which is |AC|^2 + |AD|^2.
            //  Measure 1 on Q_0, two states that have a 1 in the first (0) position: BC|10>, BD|11> which is |BC|^2 + |BD|^2.
            //  Measure 0 on Q_1, two states that have a 0 in the second (1) position: AC|00>, BC|10> which is |AC|^2 + |BC|^2.
            //  Measure 1 on Q_1, two states that have a 1 in the second (1) position: AD|01>, BD|11> which is |AD|^2 + |BD|^2.

            //  The pattern then becomes:
            //  If what you are measuring is in the corresponding qubit position, then that state is involved in the calculation
            //  (e.g., measure 0 on qubit 0, include all states that have a 0 in position 0).

            double[] probabilities = new double[2];
            foreach (ComputationalBasisState computationalBasisState in _computationalBasisStates)
            {
                for (int j = 0; j < probabilities.Length; j++)
                {
                    char value = j.ToChar();
                    if (value == computationalBasisState.BinaryIndex[qubit])
                    {
                        probabilities[j] += computationalBasisState.Amplitude.ModSquare();
                    }
                }
            }

            double measurementValue = ((double)(0)).ToRandom();    //  This random number helps determine which outcome occurred
            double probability = probabilities[0];

            while (probability < measurementValue)
            {
                probability += (probabilities[++state]);    //  Exit once the summed value is greater than the measurement value - the state is now set to |0> or |1>
            }

            //  Adjust the measured qubit:
            //   - If we measured |0>, then the qubit is taken to (A|1> + B|0>)
            //   - If we measured |1>, then the qubit is taken to (A|0> + B|1>)

            _qubits[qubit].Alpha = ((state == 0) ? 1 : 0);
            _qubits[qubit].Beta = ((state == 1) ? 1 : 0);

            //  Update all amplitude values
            //   - If the value in the binary index matches the state, then that basis state is involved in the measurement
            //   - If the value does not match, then that amplitude is set to 0
            char cState = state.ToChar();
            foreach (ComputationalBasisState computationalBasisState in _computationalBasisStates)
            {
                if (computationalBasisState.BinaryIndex[qubit] != cState)
                {
                    computationalBasisState.Amplitude = 0;
                }
            }

            //  Normalise the state vector
            if (IsNormalised() == false)
            {
                Normalise();
            }

            return state;
        }

        /// <summary>
        /// Normalises the state vector.
        /// </summary>
        public void Normalise()
        {
            //  Take any state vector, sum the absolute values squared of all amplitudes
            //  take the square root of this value, divide all amplitudes by this value
            //  this gives you a normalised state vector.

            double values = _computationalBasisStates.Sum(m => (Maths.Pow(Maths.Abs(m.Amplitude.Real), 2)));
            double squareRoot = Maths.Sqrt(values);

            foreach (ComputationalBasisState computationalBasisState in _computationalBasisStates)
            {
                double value = (computationalBasisState.Amplitude.Real / squareRoot);

                computationalBasisState.Amplitude = new Complex(value, computationalBasisState.Amplitude.Imaginary);
            }
        }

        /// <summary>
        /// Removes an element from the register. Note that ad-hoc element addition and deletion is not supported.
        /// </summary>
        /// <param name="index">The index of the element to remove.</param>
        public void RemoveAt(int index)
        {
            //  Ad-hoc element manipulation now disabled
            //  _computationalBasisStates.RemoveAt(index);

            throw new NotSupportedException("Ad-hoc element addition and deletion is not supported.");
        }

        /// <summary>
        /// Removes an element from the register. Note that ad-hoc element addition and deletion is not supported.
        /// </summary>
        /// <param name="computationalBasisState">The element to remove.</param>
        /// <returns>Returns true if the operation succeeded, otherwise false.</returns>
        public bool Remove(ComputationalBasisState computationalBasisState)
        {
            //  Ad-hoc element manipulation now disabled
            //  return _computationalBasisStates.Remove(computationalBasisState);

            return false;
        }

        /// <summary>
        /// Resets the register, setting |0&gt; to 1, and all other values to 0;
        /// </summary>
        public void Reset()
        {
            foreach (ComputationalBasisState computationalBasisState in _computationalBasisStates)
            {
                computationalBasisState.Amplitude = ((computationalBasisState.Index == 0) ? 1 : 0);
            }
        }
    }
}
