using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinearDataStructures
{
    [TestClass]
    public class LongestEqualSubsequenceTest
    {
        [TestMethod]
        public void EmptyListTest()
        {
            var sequence = new List<int>();
            var expected = new List<int>();
            List<int> actual = LongestEqualSubsequence.GetLongestSubsequence(sequence) as List<int>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleElementTest()
        {
            var sequence = new List<int>() { 5 };
            var expected = new List<int>() { 5 };
            List<int> actual = LongestEqualSubsequence.GetLongestSubsequence(sequence) as List<int>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllElementsTest()
        {
            var sequence = new List<int>() { 3, 3, 3, 3 };
            var expected = new List<int>() { 3, 3, 3, 3 };
            List<int> actual = LongestEqualSubsequence.GetLongestSubsequence(sequence) as List<int>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BeginningOfSequenceTest()
        {
            var sequence = new List<int>() { 2, 2, 10, 43 };
            var expected = new List<int>() { 2, 2 };
            List<int> actual = LongestEqualSubsequence.GetLongestSubsequence(sequence) as List<int>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfSequenceTest()
        {
            var sequence = new List<int>() { 2, 2, 10, 43, 43, 43 };
            var expected = new List<int>() { 43, 43, 43 };
            List<int> actual = LongestEqualSubsequence.GetLongestSubsequence(sequence) as List<int>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StandardSequenceTest()
        {
            var sequence = new List<int>() { 2, 10, 43, 43, 613, 43 };
            var expected = new List<int>() { 43, 43 };
            List<int> actual = LongestEqualSubsequence.GetLongestSubsequence(sequence) as List<int>;

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
