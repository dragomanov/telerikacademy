using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class Bank
    {
        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }

        public Bank()
        {
            this.Customers = new List<Customer>();
            this.Accounts = new List<Account>();
        }
    }
}
