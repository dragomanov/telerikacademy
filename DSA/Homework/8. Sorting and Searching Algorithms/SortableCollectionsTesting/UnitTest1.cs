using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SortingHomework;
namespace SortableCollectionsTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1SectionSortMethod() //small collections
        {

            var collection = new SortableCollection<int>(new[] { 22, 13 });
            collection.Sort(new SelectionSorter<int>());
            var testCollection = new SortableCollection<int>(new[] { 13, 22 });
            Assert.Equals(collection,testCollection);
        }
        [TestMethod]
        public void Test2SectionSortMethod() //for medium collections
        {

            var collection1 = new SortableCollection<int>(new[] { 22, 13, 23, 45, -55, 90, 100, 101, -12, 55, 44 });
            collection1.Sort(new SelectionSorter<int>());
            var testCollection = new SortableCollection<int>(new[] { -55, -12, 13, 22, 23, 44, 45, 55, 90, 100, 101 });
            Assert.Equals(testCollection, collection1);
        }
        [TestMethod]
        public void Test3SectionSortMethod() //for string collections
        {

            var collection1 = new SortableCollection<string>(new[] { "aaaa", "cccc", "dddd", "cccc", "caaa", "aacc", "bbdd", "ccff", "eerr", "rrtt", "assdd" });
            collection1.Sort(new SelectionSorter<string>());
            var testCollection = new SortableCollection<int>(new[] { -55, -12, 13, 22, 23, 44, 45, 55, 90, 100, 101 });
            Assert.Equals(testCollection, collection1);
        }
    }
}
