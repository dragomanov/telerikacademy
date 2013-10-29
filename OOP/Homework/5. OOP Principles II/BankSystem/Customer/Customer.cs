using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    abstract class Customer
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            this.Name = name;
        }
    }
}
