using NUnit.Framework;


namespace CustomCollections.Tests
{
	[TestFixture]
	public class EnhancedArrayListTest
	{
		private const int ExpectedListSize = 5;
		private readonly int[] integerList = {1, 2, 3, 4, 5};
		private readonly float[] floatList = {5.9f, 1.1f, 2.3f, 0.65f, 4.2f};

		private EnhancedArrayList enhancedArrayList;

		[SetUp]
		public void BeforeEach()
		{
			enhancedArrayList = new EnhancedArrayList();
		}

		[Test]
		public void TestAddIntegers()
		{
			AddIntegers();
			AssertIntegersAreSame();
		}

		private void AddIntegers()
		{
			foreach (var integer in integerList)
			{
				enhancedArrayList.Add(integer);
			}
		}

		private void AssertIntegersAreSame()
		{
			int actualSize = AssertListsAreSameSize();

			for (var i = 0; i < actualSize; i++)
			{
				Assert.AreEqual(integerList[i], enhancedArrayList[i]);
			}
		}
		
		private int AssertListsAreSameSize()
		{
			int actualSize = enhancedArrayList.Count;
			Assert.AreEqual(ExpectedListSize, actualSize);

			return actualSize;
		}
		
		[Test]
		public void TestAddFloats()
		{
			AddFloats();
			AssertFloatsAreSame();
		}

		private void AddFloats()
		{
			foreach (var floatNumber in floatList)
			{
				enhancedArrayList.Add(floatNumber);
			}
		}

		private void AssertFloatsAreSame()
		{
			int actualSize = AssertListsAreSameSize();

			for (var i = 0; i < actualSize; i++)
			{
				Assert.AreEqual(floatList[i], enhancedArrayList[i]);
			}
		}

		[Test]
		public void TestPopFirst()
		{
			AddFloats();

			// Make sure that the initial size of the list is correct
			int expectedSize = ExpectedListSize;
			Assert.AreEqual(expectedSize, enhancedArrayList.Count);
			
			for (var i = 0; i < ExpectedListSize; i++)
			{
				enhancedArrayList.PopFirst();
				
				/* Make sure that when the first element is popped, the list just contains the later
				   elements and has decreased in size by 1 */
				expectedSize--;
				Assert.AreEqual(expectedSize, enhancedArrayList.Count);
				
				for (var j = 0; j < expectedSize; j++)
				{
					Assert.AreEqual(floatList[j + i + 1], enhancedArrayList[j]);
				}
			}
			
			Assert.IsEmpty(enhancedArrayList);
		}

		[Test]
		public void TestGetLast()
		{
			AddFloats();

			for (var i = 0; i < ExpectedListSize; i++)
			{
				var lastFloat = enhancedArrayList.GetLast();
				
				Assert.AreEqual(enhancedArrayList[enhancedArrayList.Count - 1], lastFloat);
				
				enhancedArrayList.RemoveAt(enhancedArrayList.Count - 1);
			}
			
			Assert.IsEmpty(enhancedArrayList);
		}

		[Test]
		public void TestGetSorted()
		{
			AddFloats();
			
			var sortedList = enhancedArrayList.GetSorted();
			enhancedArrayList.Sort();
			
			CollectionAssert.AreEqual(enhancedArrayList, sortedList);
		}
	}
}
