using System;
using System.Collections;
using NUnit.Framework;

namespace CustomCollections.Tests
{
	[TestFixture]
	public class MedianSliderTest
	{
		private MedianSlider medianSlider;
		private const int MedianSliderSize = 5;

		private readonly ArrayList simpleFloatSet = new ArrayList{9.8f, 1.2f, 0.3f, 4.5f, 0.48f};
		
		private const int SmallerSetSize = 4;
		private const int MaxLargerSetSize = 20;
		
		private readonly Random random = new Random();

		[SetUp]
		public void BeforeEach()
		{
			medianSlider = new MedianSlider(MedianSliderSize);
		}

		[Test]
		public void TestGetMedianOnSetSmallerThanSliderSize()
		{
			ArrayList smallerSet = GetSubset(SmallerSetSize);

			for (var i = 0; i < SmallerSetSize; i++)
			{
				medianSlider.Insert((float) smallerSet[i]);
				
				Assert.AreEqual(i + 1, medianSlider.Count);

				float actualMedian = medianSlider.GetMedianValue();
				var expectedMedian = (float) smallerSet[i];
				Assert.AreEqual(expectedMedian, actualMedian);
			}
		}

		private ArrayList GetSubset(int setSize)
		{
			return simpleFloatSet.GetRange(0, setSize);
		}
		
		[Test]
		public void TestGetMedianOnSetEqualToSliderSize()
		{
			ArrayList equalSet = GetSubset(MedianSliderSize);

			LoadSlider(equalSet);
			
			float expectedMedian = GetExpectedMedian(equalSet);
			float actualMedian = medianSlider.GetMedianValue();
			
			Assert.AreEqual(expectedMedian, actualMedian);
		}

		private float GetExpectedMedian(ArrayList listOfFloats)
		{
			listOfFloats.Sort();
			return (float) listOfFloats[listOfFloats.Count / 2];
		}

		private void LoadSlider(IEnumerable listOfFloats)
		{
			foreach (float element in listOfFloats)
			{
				medianSlider.Insert(element);
			}
		}

		[Test]
		public void TestGetMedianOnSetsLargerThanSliderSize()
		{
			for (var listSize = MedianSliderSize; listSize <= MaxLargerSetSize; listSize++)
			{
				var randomFloatList = GenerateListOfRandomFloats(listSize);
				TestGetMedianOnLargerSet(listSize, randomFloatList);
			}
		}

		private void TestGetMedianOnLargerSet(int listSize, ArrayList listOfFloats)
		{
			for (var i = 0; i < MedianSliderSize - 1; i++)
			{
				medianSlider.Insert((float) listOfFloats[i]);
			}

			for (var i = MedianSliderSize - 1; i < listSize; i++)
			{
				medianSlider.Insert((float) listOfFloats[i]);

				ArrayList sliderFloats = GetExpectedSliderFloats(i, listOfFloats);
				
				float expectedMedian = GetExpectedMedian(sliderFloats);
				float actualMedian = medianSlider.GetMedianValue();
				Assert.AreEqual(expectedMedian, actualMedian);
			}

			medianSlider.Clear();
		}

		private ArrayList GetExpectedSliderFloats(int index, ArrayList listOfFloats)
		{
			var sliderFloats = new ArrayList();

			var firstIndex = index - MedianSliderSize + 1;
			var lastIndex = index + 1;
			for (var i = firstIndex; i < lastIndex; i++)
			{
				sliderFloats.Add(listOfFloats[i]);
			}

			return sliderFloats;
		}

		private ArrayList GenerateListOfRandomFloats(int count)
		{
			var list = new ArrayList();
			
			for (var i = 0; i < count; i++)
			{
				var randomFloat = (float) random.NextDouble() + random.Next(360);
				list.Add(randomFloat);
			}

			return list;
		}
	}
}