using System;

class EmployeeRecordDeclaration
{
    static void Main()
    {
        string firstName = "Antoni";
        string lastName = "Dragomanov";
        byte age = 26;
        char gender = 'M'; // or bool isMale; for smaller size
        uint id = 27560000;
        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", firstName, lastName, age, gender, id);
    }
}
