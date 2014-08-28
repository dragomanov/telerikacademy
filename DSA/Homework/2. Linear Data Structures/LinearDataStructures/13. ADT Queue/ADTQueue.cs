using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class ADTQueue<T>
    {
        LinkedList2<T> queue;
        private int count;

        public int Count
        {
            get { return this.count; }
        }

        public ADTQueue()
        {
            this.count = 0;
            this.queue = new LinkedList2<T>();
        }

        public void Enqueue(T element)
        {
            this.count++;
            this.queue.AddLast(element);
        }

        public T Dequeue()
        {
            this.count--;
            return queue.RemoveFirst();
        }

        public T Peek()
        {
            return this.queue.First;
        }
    }
}
