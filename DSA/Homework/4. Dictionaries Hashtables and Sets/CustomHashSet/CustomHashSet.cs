using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomHashSet
{
    class CustomHashSet<T>
    {
        private CustomHashTable<T, bool> set;
        private int count;

        public CustomHashSet()
        {
            this.count = 0;
            this.set = new CustomHashTable<T, bool>();
        }

        public CustomHashTable<T, bool> Set
        {
            get { return this.set; }
        }
        public int Count
        {
            get { return this.count; }
        }

        public void Add(T element)
        {
            this.set.Add(element, true);
            this.count++;
        }
        public void Remove(T element)
        {
            this.set.Remove(element);
            this.count--;
        }
        public T Find(T element)
        {
            bool result = this.set.Find(element);
            if (result)
            {
                return element;
            }
            else
            {
                throw new KeyNotFoundException(string.Format("There is NO element with value = {0}", element));
            }
        }
        public void Clear()
        {
            this.set = new CustomHashTable<T, bool>();
            this.count = 0;
        }

        public void Union(CustomHashSet<T> otherSet)
        {
            foreach (KeyValuePair<T, bool> element in otherSet.Set)
            {
                this.set[element.Key] = true;
            }
            this.count = this.set.Count;
        }
        public void Intersect(CustomHashSet<T> otherSet)
        {
            List<T> toRemove = new List<T>(Math.Min(this.Count, otherSet.Count));
            foreach (KeyValuePair<T, bool> element in this.set)
            {
                if (!otherSet.Set.Find(element.Key))
                {
                    toRemove.Add(element.Key);
                }
            }
            foreach (T element in toRemove)
            {
                this.Remove(element);
            }
            this.count = this.set.Count;
        }
    }
}
