using System;

namespace LinearDataStructures
{
    public class ADTStack<T>
    {
        private T[] array;
        private int count;
        private int capacity;

        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public ADTStack()
        {
            this.count = 0;
            this.capacity = 4;
            this.array = new T[this.capacity];
        }

        public void Push(T element)
        {
            if (this.count == this.capacity)
            {
                this.IncreaseCapacity();
            }
            
            this.array[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            this.count--;
            return this.array[this.count];
        }

        public T Peek()
        {
            return this.array[this.count - 1];
        }

        private void IncreaseCapacity()
        {
            this.capacity *= 2;
            T[] newArray = new T[this.capacity];
            this.array.CopyTo(newArray, 0);
            this.array = newArray;
        }
    }
}
