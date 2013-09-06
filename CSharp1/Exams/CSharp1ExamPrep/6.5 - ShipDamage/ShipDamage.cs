using System;

class ShipDamage
{
    static bool hitsCorner(int sx1, int sy1, int sx2, int sy2, int cx, int cy)
    {
        if ((cx == sx1 && cy == sy1) || (cx == sx2 && cy == sy2) || (cx == sx1 && cy == sy2) || (cx == sx2 && cy == sy1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool hitsSide(int sx1, int sy1, int sx2, int sy2, int cx, int cy)
    {
        if ((cx == sx1 || cx == sx2) && Math.Min(sy1, sy2) < cy && cy < Math.Max(sy1, sy2))
        {
            return true;
        }
        else if ((cy == sy1 || cy == sy2) && Math.Min(sx1, sx2) < cx && cx < Math.Max(sx1, sx2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool hitsInternal(int sx1, int sy1, int sx2, int sy2, int cx, int cy)
    {
        if (Math.Min(sx1, sx2) < cx && cx < Math.Max(sx1, sx2) && Math.Min(sy1, sy2) < cy && cy < Math.Max(sy1, sy2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());

        int h = int.Parse(Console.ReadLine());

        int damageDone = 0;
        for (int i = 0; i < 3; i++)
        {
            int cx = int.Parse(Console.ReadLine());
            int cy = int.Parse(Console.ReadLine());

            int landX = cx;
            int landY = h + Math.Abs(h - cy);

            if (hitsCorner(sx1, sy1, sx2, sy2, landX, landY))
            {
                damageDone += 25;
            }
            else if (hitsSide(sx1, sy1, sx2, sy2, landX, landY))
            {
                damageDone += 50;
            }
            else if (hitsInternal(sx1, sy1, sx2, sy2, landX, landY))
            {
                damageDone += 100;
            }
        }

        Console.WriteLine(damageDone + "%");
    }
}
