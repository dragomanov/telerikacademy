/*
 * 12. Implement the ADT stack as auto-resizable array. 
 * Resize the capacity on demand (when no space is available to add / insert a new element).
 */

using System;
using System.Collections.Generic;

namespace LinearDataStructures
{
    class ADTStackEntryPoint
    {
        static void Main(string[] args)
        {
            ADTStack<int> stackTest = new ADTStack<int>();
            Console.WriteLine("Count: {0}", stackTest.Count);
            Console.WriteLine("Capacity: {0}", stackTest.Capacity);
            stackTest.Push(0);
            stackTest.Push(1);
            stackTest.Push(2);
            Console.WriteLine(stackTest.Peek());
            stackTest.Push(3);
            stackTest.Push(4);
            Console.WriteLine(stackTest.Pop());
            Console.WriteLine("Count: {0}", stackTest.Count);
            Console.WriteLine("Capacity: {0}", stackTest.Capacity);
            Console.WriteLine(stackTest.Pop());
            Console.WriteLine(stackTest.Pop());
            Console.WriteLine(stackTest.Pop());
            Console.WriteLine(stackTest.Pop());
            Console.WriteLine("Count: {0}", stackTest.Count);
            Console.WriteLine("Capacity: {0}", stackTest.Capacity);
        }
    }
}
