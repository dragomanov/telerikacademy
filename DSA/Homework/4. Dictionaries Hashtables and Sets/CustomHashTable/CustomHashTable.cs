using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CustomHashSet
{
    public class CustomHashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int defaultCapacity = 16;

        private LinkedList<KeyValuePair<K, V>>[] table;
        private int count;
        private int currentCapacity;

        public CustomHashTable()
            : this(defaultCapacity)
        { }
        public CustomHashTable(int capacity)
        {
            this.currentCapacity = capacity;
            this.table = new LinkedList<KeyValuePair<K, V>>[capacity];
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }
        public int CurrentCapacity
        {
            get { return this.currentCapacity; }
        }
        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                if (this.FindKey(key))
                {
                    this.Remove(key);
                    this.Add(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }
        public List<K> Keys
        {
            get
            {
                List<K> result = new List<K>();
                foreach (LinkedList<KeyValuePair<K, V>> chain in this.table)
                {
                    if (chain != null)
                    {
                        foreach (KeyValuePair<K, V> pair in chain)
                        {
                            result.Add(pair.Key);
                        }
                    }
                }
                return result;
            }
        }

        private void AutoGrow()
        {
            int newCapacity = 2 * this.table.Length;
            LinkedList<KeyValuePair<K, V>>[] oldTable = this.table;
            this.currentCapacity = newCapacity;
            this.table = new LinkedList<KeyValuePair<K, V>>[newCapacity];
            foreach (LinkedList<KeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<K, V> pair in oldChain)
                    {
                        int index = this.CalcIndex(pair.Key);
                        if (this.table[index] == null)
                        {
                            this.table[index] = new LinkedList<KeyValuePair<K, V>>();
                            this.table[index].AddFirst(pair);
                        }
                        else
                        {
                            this.table[index].AddLast(pair);
                        }
                    }
                }
            }
        }
        private int CalcIndex(K key)
        {
            int index = key.GetHashCode();
            index = Math.Abs(index % this.table.Length);
            return index;
        }
        private bool FindKey(K key)
        {
            int index = this.CalcIndex(key);
            if (this.table[index] != null)
            {
                foreach (KeyValuePair<K, V> pair in table[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void Add(K key, V value)
        {
            KeyValuePair<K, V> pair = new KeyValuePair<K, V>(key, value);
            if (this.count + 1 > this.currentCapacity * 0.75)
            {
                this.AutoGrow();
            }
            int index = this.CalcIndex(key);
            if (this.table[index] == null)
            {
                this.table[index] = new LinkedList<KeyValuePair<K, V>>();
                this.table[index].AddFirst(pair);
            }
            else
            {
                this.table[index].AddLast(pair);
            }
            this.count++;
        }
        public void Remove(K key)
        {
            int index = this.CalcIndex(key);
            KeyValuePair<K, V> toRemove = new KeyValuePair<K, V>();
            if (this.table[index] != null)
            {
                foreach (KeyValuePair<K, V> pair in table[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        toRemove = pair;
                    }
                }
            }
            this.table[index].Remove(toRemove);
            this.count--;
        }
        public V Find(K key)
        {
            int index = this.CalcIndex(key);
            if (this.table[index] != null)
            {
                foreach (KeyValuePair<K, V> pair in table[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
                throw new KeyNotFoundException(string.Format("There is NO element with key = {0}", key));
            }
            else
            {
                throw new KeyNotFoundException(string.Format("There is NO element with key = {0}", key));
            }
        }
        public void Clear()
        {
            this.currentCapacity = defaultCapacity;
            this.table = new LinkedList<KeyValuePair<K, V>>[defaultCapacity];
            this.count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<K, V>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, V> pair in chain)
                    {
                        yield return pair;
                    }
                }
            }
        }
    }
}
