using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class Test
    {
        static void Main(string[] args)
        {
            Bank pib = new Bank();
            pib.Customers.Add(new IndividualCustomer("Pesho"));
            pib.Accounts.Add(new MortgageAccount(pib.Customers[0], 1000, 0.01m));
            Console.WriteLine(pib.Accounts[0].CalculateInterest(7));
        }
    }
}
