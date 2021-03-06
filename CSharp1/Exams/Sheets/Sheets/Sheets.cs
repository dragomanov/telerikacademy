﻿using System;

class Carpet_4
{
    static void Main()
    {
        string TopRhombs = "";
        string BottomRhombs = "";
        int NumLines = int.Parse(Console.ReadLine());
        int Midpoint = NumLines / 2;
        string[] Lines = new string[NumLines + 1];
        for (int Line = 1; Line <= NumLines; Line++)
        {
            if (Line <= Midpoint)
            {
                if (Line % 2 == 1)
                    TopRhombs = TopRhombs.Insert(Line - 1, "/\\");
                else
                    TopRhombs = TopRhombs.Insert(Line - 1, "  ");

                Lines[Line] = TopRhombs;
                string Dots = new String('.', Midpoint - Line);
                Lines[Line] = Dots + Lines[Line] + Dots;
            }
            else
            {
                int RLine = NumLines + Midpoint + 1 - Line;
                if (RLine % 2 == 0)
                    BottomRhombs = BottomRhombs.Insert(Line - Midpoint - 1, "\\/");
                else
                    BottomRhombs = BottomRhombs.Insert(Line - Midpoint - 1, "  ");

                Lines[RLine] = BottomRhombs;
                string Dots = new String('.', RLine - Midpoint - 1);
                Lines[RLine] = Dots + Lines[RLine] + Dots;
            }

        }

        for (int Line = 1; Line <= NumLines; Line++)
        {
            Console.WriteLine(Lines[Line]);
        }
    }
}
