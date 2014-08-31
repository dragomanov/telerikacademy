namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private IList<T> sortedCollection;

        public IList<T> SortedCollection
        {
            get { return sortedCollection; }
            set { sortedCollection = value; }
        }
        public void ReplacePlaces(int indexOne, int indexTwo, IList<T> list) 
        {
            dynamic tempIndex=list[indexOne];
            list[indexOne] = list[indexTwo];
            list[indexTwo] = tempIndex;
        }
        public void Sort(IList<T> collection)
        {
            int minIndex = 0;
           for (int index1 = 0; index1 < collection.Count-1;index1++)
            {
                minIndex = index1;
                for (int index2 = index1; index2 < collection.Count; index2++)
                {
                    if (collection[index2].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = index2;
                    }
                    index2++;
                }
                if (minIndex != index1)
                {
                    ReplacePlaces(minIndex, index1, collection);
                }
            }
        }
    }
}
