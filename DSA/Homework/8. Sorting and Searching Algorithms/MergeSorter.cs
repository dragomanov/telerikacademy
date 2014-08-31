namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            List<T> sortedCollection;
            sortedCollection = MergeSort((List<T>)collection);
            collection = sortedCollection;

        }
        private List<T> MergeSort(List<T> list)
        {
            if (list.Count == 1)
                return list;
            int middle = list.Count / 2;
            List<T> left = new List<T>();
            for (int i = 0; i < middle; i++)
            {
                left.Add(list[i]);
            }
            List<T> right = new List<T>();
            for (int j = middle; j < list.Count; j++)
            {
                right.Add(list[j]);
            }
            left = MergeSort(left);
            right = MergeSort(right);

            int leftptr = 0;
            int rightptr = 0;

            List<T> sorted = new List<T>();
            for (int k = 0; k < list.Count; k++)
            {
                if ((rightptr == right.Count) || ((leftptr < left.Count) && (left[leftptr].CompareTo(right[rightptr]) <= 0)))
                {
                    sorted.Insert(k,left[leftptr]);
                    leftptr++;
                }
                else if ((leftptr == left.Count) || ((rightptr < right.Count) && (right[rightptr].CompareTo(left[leftptr]) <= 0)))
                {
                    sorted.Insert(k, right[rightptr]);
                    rightptr++;
                }
            }
            return sorted;
        }


    }
}
