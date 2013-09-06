using System;
using System.Linq;

class Bittris
{
    static bool Move(ref int shape, ref int shapeLine, char direction, ref int[] field, ref int score, int piecePoints)
    {
        bool moved = false;
        int cleanLine = field[shapeLine] ^ shape;
        bool canMoveLeft = ((shape << 1) & cleanLine) == 0 && shape < 128;
        bool canMoveRight = ((shape >> 1) & cleanLine) == 0 && ((shape & 1) == 0);

        if (direction == 'L' && canMoveLeft)
        {
            shape <<= 1;
        }
        else if (direction == 'R' && canMoveRight)
        {
            shape >>= 1;
        }

        if ((shape & field[shapeLine + 1]) != 0)
        {
            moved = false;
        }
        else
        {
            field[shapeLine] = cleanLine;
            field[shapeLine + 1] |= shape;
            shapeLine++;
            moved = true;
        }

        if (!moved || shapeLine == 3)
        {
            if (field[shapeLine] == 255)
            {
                piecePoints *= 10;

                for (int i = shapeLine; i > 0; i--)
                {
                    field[shapeLine] = field[shapeLine - 1];
                }
                field[0] = 0;
            }
            score += piecePoints;
        }

        return moved;
    }

    static void Main()
    {
        int moves = int.Parse(Console.ReadLine());
        int[] field = new int[4];
        int score = 0;
        int piece = 0;
        int piecePoints = 0;
        int shape = 0;
        int shapeLine = 0;
        bool hasLanded = false;
        bool running = true;

        for (int i = 0; i < moves; i++)
        {
            string input = Console.ReadLine();
            char direction = ' ';
            if (i % 4 == 0)
            {
                piece = int.Parse(input);
                piecePoints = Convert.ToString(piece, 2).Count(c => c == '1');
                shape = piece & 255;
                shapeLine = 0;
                field[0] = shape;
                hasLanded = false;
                continue;
            }
            else
            {
                direction = char.Parse(input);
            }

            if (!hasLanded && running)
            {
                hasLanded = !Move(ref shape, ref shapeLine, direction, ref field, ref score, piecePoints);
            }

            if (hasLanded && field[0] != 0)
            {
                running = false;
                continue;
            }

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(Convert.ToString(field[j], 2).Replace('0', '.').PadLeft(8, '.'));
            }
        }

        Console.WriteLine(score);
    }
}
