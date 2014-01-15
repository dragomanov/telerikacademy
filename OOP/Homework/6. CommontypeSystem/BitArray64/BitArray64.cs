using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public ulong Number
        {
            get { return number; }
            set { number = value; }
        }

        public BitArray64(ulong num)
        {
            this.number = num;
        }

        public override bool Equals(object obj)
        {
            BitArray64 comparer = obj as BitArray64;
            if (comparer == null) return false;
            else return this.number == comparer.number;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.number.ToString();
        }

        public static implicit operator BitArray64(ulong num)
        {
            return new BitArray64(num);
        }

        public static bool operator ==(BitArray64 u1, BitArray64 u2)
        {
            return ReferenceEquals(u1, u2);
        }
        public static bool operator !=(BitArray64 u1, BitArray64 u2)
        {
            return !ReferenceEquals(u1, u2);
        }

        public ulong this[int index]
        {
            get { return number >> index & 1; }
            set 
            {
                ulong mask;
                if (value == 0)
                {
                    mask = ~(value << index);
                    number &= mask; 
                }
                else
                {
                    mask = value << index;
                    number |= mask;
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
			{
                yield return (int) this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
