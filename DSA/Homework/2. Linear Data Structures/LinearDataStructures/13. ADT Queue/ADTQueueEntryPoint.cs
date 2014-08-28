using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class ADTQueueEntryPoint
    {
        static void Main(string[] args)
        {
            ADTQueue<int> queue = new ADTQueue<int>();
            Console.WriteLine("Count: {0}", queue.Count);
            queue.Enqueue(0);
            Console.WriteLine("Enqueue 0");
            queue.Enqueue(1);
            Console.WriteLine("Enqueue 1");
            queue.Enqueue(2);
            Console.WriteLine("Enqueue 2");
            queue.Enqueue(3);
            Console.WriteLine("Enqueue 3");
            Console.WriteLine("Count: {0}", queue.Count);
            Console.WriteLine("Dequeue: {0}", queue.Dequeue());
            Console.WriteLine("Count: {0}", queue.Count);
            Console.WriteLine("Peek: {0}", queue.Peek());           
            Console.WriteLine("Dequeue: {0}", queue.Dequeue());
            Console.WriteLine("Peek: {0}", queue.Peek());
            Console.WriteLine("Count: {0}", queue.Count);
        }
    }
}
