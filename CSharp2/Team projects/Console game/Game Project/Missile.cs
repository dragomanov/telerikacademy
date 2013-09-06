using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Missile
{
    private int[] pos = new int[2];
    private int[] oldPos = new int[2];
    private double[] directionSpeed = new double[2] { 2, 0 };
    private double[] subPos = new double[2];
    public bool updated = false;
    public bool destroyed = false;
    private Sprite sprite;

    public Missile(int col, int row, Sprite sprite)
    {
        pos[0] = oldPos[0] = col;
        pos[1] = oldPos[1] = row;
        this.sprite = sprite;
    }

    public void Update()
    {
        updated = false;
        destroyed = sprite.destroyed;

        for (int i = 0; i < 2; i++)
        {
            subPos[i] += directionSpeed[i];

            if (Math.Abs(subPos[i]) >= 1)
            {
                oldPos[i] = pos[i];
                pos[i] += (int)subPos[i];
                subPos[i] -= (int)subPos[i];
                updated = true;
            }
        }
    }

    public void Draw()
    {
        sprite.Erase(oldPos[0], oldPos[1]);
        sprite.Draw(pos[0], pos[1]);
    }
}
