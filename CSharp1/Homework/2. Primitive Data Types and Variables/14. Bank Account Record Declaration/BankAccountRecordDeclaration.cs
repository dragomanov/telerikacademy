using System;

class BankAccountRecordDeclaration
{
    static void Main()
    {
        string fullName = "John Ding Doe";
        decimal balance = 9999999999999999999999999999M;
        string bankName = "FIB";
        string IBAN = "BG97FIBBSFCB1234567890";
        string BIC = "FIBB";
        decimal[] CCNumber = {1234567812345678M, 1234123412341234M, 09870987098709870M};
        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}", fullName, balance, bankName, IBAN, BIC, CCNumber[0], CCNumber[1], CCNumber[2]);
    }
}
