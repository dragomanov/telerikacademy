﻿using System;

class FormulaBit1_5
{
    byte Row = 0;
    byte Col = 7;
    char Direction = 'S';       // 'S' = South, 'W' = West, 'N' = North
    char PrevDirection = 'N';
    byte TrackLength = 1;
    byte NumTurns = 0;
    string[] Grid = new string[8];

    public bool Move()
    {
        switch (Direction)
        {
            case 'S':
                if (this.Row < 7 && this.Grid[this.Row + 1][this.Col] == '0')
                {
                    this.Row++;
                    break;
                }
                else if (this.Col > 0 && this.Grid[this.Row][this.Col - 1] == '0')
                {
                    this.Col--;
                    this.Direction = 'W';
                    this.PrevDirection = 'S';
                    this.NumTurns++;
                    break;
                }
                else
                    return false;
            case 'W':
                if (this.Col > 0 && this.Grid[this.Row][this.Col - 1] == '0')
                {
                    this.Col--;
                    break;
                }
                else if (this.Row < 7 && this.PrevDirection == 'N' && this.Grid[this.Row + 1][this.Col] == '0')
                {
                    this.Row++;
                    this.Direction = 'S';
                    this.PrevDirection = 'W';
                    this.NumTurns++;
                    break;
                }
                else if (this.Row > 0 && this.PrevDirection == 'S' && this.Grid[this.Row - 1][this.Col] == '0')
                {
                    this.Row--;
                    this.Direction = 'N';
                    this.PrevDirection = 'W';
                    this.NumTurns++;
                    break;
                }
                else
                    return false;
            case 'N':
                if (this.Row > 0 && this.Grid[this.Row - 1][this.Col] == '0')
                {
                    this.Row--;
                    break;
                }
                else if (this.Col > 0 && this.Grid[this.Row][this.Col - 1] == '0')
                {
                    this.Col--;
                    this.Direction = 'W';
                    this.PrevDirection = 'N';
                    this.NumTurns++;
                    break;
                }
                else
                    return false;
            default:
                Console.WriteLine("How did we get here? :/");
                return false;
        }
        TrackLength++;
        return true;
    }

    static void Main()
    {
        FormulaBit1_5 Formula = new FormulaBit1_5();
        for (int i = 0; i < 8; i++)
        {
            Formula.Grid[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        }

        if (Formula.Grid[1][7] == '1')
        {
            Formula.Direction = 'W';
        }

        do
        {
            if (!Formula.Move())
            {
                Console.WriteLine("No {0}", Formula.TrackLength);
                return;
            }
        } while (Formula.Row != 7 || Formula.Col != 0);

        Console.WriteLine("{0} {1}", Formula.TrackLength, Formula.NumTurns);
    }
}
