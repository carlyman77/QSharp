#region Using References

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using QSharp.Mathematics;

#endregion

namespace QSharp.UnitTests
{
    [TestClass]
    public class QubitTests
    {
        [TestMethod]
        public void CheckQubitLabelsForAlphabet()
        {
			for (int i = 0; i < 26; i++)
			{
				string exepectedLabel = ((char)(i + 65)).ToString();
				string label = Qubit.GetNextLabel();

				Assert.AreEqual(exepectedLabel, label);
			}
		}

		[TestMethod]
		public void CheckQubitLabelsForAlphabetExtended()
		{
			string expectedLabel = "";
			string label = "";

			expectedLabel = "Z";
			label = Qubit.GetLabel(25);

			Assert.AreEqual(expectedLabel, label);

			expectedLabel = "AA";
			label = Qubit.GetLabel(26);

			Assert.AreEqual(expectedLabel, label);

			expectedLabel = "AB";
			label = Qubit.GetLabel(27);

			Assert.AreEqual(expectedLabel, label);

			//	Something to test out later
			//	var list = new LinkedList<int>();
			//	list.AddFirst((number - 1) % 26);
			//	while ((number = --number / 26 - 1) > 0) list.AddFirst(number % 26);
			//	return new string(list.Select(s => (char)(s + 65)).ToArray());
		}
	}
}

