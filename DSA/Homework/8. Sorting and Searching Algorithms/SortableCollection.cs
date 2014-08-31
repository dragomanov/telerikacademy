namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public int LinearSearch(T item)
        {
            dynamic founded=null;
            foreach (T toSearchFor in this.Items) 
            {
                if (toSearchFor.CompareTo(item) == 0)
                {
                    founded = toSearchFor;
                    break;
                }
            }
            if (founded == null) 
            {
                throw new KeyNotFoundException("Given key " + item + " wasnt found in the given collection!");
            } 
            return this.Items.IndexOf(founded);
        }

        public int BinarySearch(T item)
        {
            dynamic founded = null;
            int iMin = 0;
            int iMax = this.Items.Count-1;
            founded = BinarySearcher(this.Items,item,iMin,iMax);
            if (founded == null || founded ==-1)
            {
                throw new KeyNotFoundException("Given key "+item+" wasnt found in the given collection!");
            } 
            return this.Items.IndexOf(founded);

        }
        public T BinarySearcher(IList<T> list,T searchForWhat, int minIndex, int maxIndex) 
        {
            dynamic result = null;
            if (minIndex > maxIndex)
            {
                return result;
            }
            else 
            {
                int middleIndex = minIndex + maxIndex / 2;
                if (searchForWhat.CompareTo(list[middleIndex]) > 0) 
                {
                    result = BinarySearcher(list, searchForWhat, minIndex + 1, maxIndex);
                }
                else if (searchForWhat.CompareTo(list[middleIndex]) < 0)
                {
                    result = BinarySearcher(list, searchForWhat, minIndex, minIndex - 1);
                }
                else 
                {
                    result = (dynamic) list[middleIndex];
                }
            }
            return result;
        }
        public void Shuffle()
        {
            Random newRand = new Random();
            for (int i = this.Items.Count; i > 1; i--)
            {
                int j = newRand.Next(i); 
                T tmp = this.Items[j];
                this.Items[j] = this.Items[i - 1];
                this.Items[i - 1] = tmp;
            }


        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
