using System;

class BatGoikoTower
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int nextBeamLine = 2;
        int noBeamLines = 1;

        for (int currline = 1; currline <= lines; currline++)
        {
            string dots = new string('.', lines - currline);
            string middle;
            if (currline == nextBeamLine)
            {
                nextBeamLine += noBeamLines + 1;
                noBeamLines++;
                middle = new string('-', (currline - 1) * 2);
            }
            else
            {
                middle = new string('.', (currline - 1) * 2);
            }
            string tower = dots + '/' + middle +'\\' + dots;
            Console.WriteLine(tower);
        }
    }
}
