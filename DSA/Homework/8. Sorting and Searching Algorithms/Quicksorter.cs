namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }
        void QuickSort(IList<T> list, int first, int last)
        {
            int pivot, j, i;
            T temp;
            if (first < last)
            {
                pivot = first;
                i = first;
                j = last;

                while (i < j)
                {
                    while (list[i].CompareTo(list[pivot]) <= 0 && i < last)
                        i++;
                    while (list[j].CompareTo(list[pivot]) > 0)
                        j--;
                    if (i < j)
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }

                temp = list[pivot];
                list[pivot] = list[j];
                list[j] = temp;
                QuickSort(list, first, j - 1);
                QuickSort(list, j + 1, last);

            }
        }
    }
}

        