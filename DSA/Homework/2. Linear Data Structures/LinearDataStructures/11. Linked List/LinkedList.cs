using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructures
{
    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Previous { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }

    public class LinkedList2<T> : IEnumerable<T>
    {
        private LinkedListNode<T> Head { get; set; }
        private LinkedListNode<T> Tail { get; set; }

        public T First
        {
            get { return this.Head.Value; }
        }

        public T Last
        {
            get { return this.Tail.Value; }
        }

        public void AddLast(T value)
        {
            var newNode = new LinkedListNode<T>()
            {
                Value = value
            };

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
                newNode.Previous = this.Tail;
                this.Tail = newNode;
            }
        }

        public T RemoveFirst()
        {
            T value = this.Head.Value;
            this.Head = this.Head.Next;
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
