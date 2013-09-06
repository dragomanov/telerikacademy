using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Enemy
{
    private int[] pos = new int[2];
    private int[] oldPos = new int[2];
    private double[] directionSpeed = new double[2] { 0, 0 };
    private double[] subPos = new double[2];
    public bool updated = false;
    public bool destroyed = false;
    public static string spritePath = "EnemyShipsSprite.txt";
    private Sprite sprite;

    public Enemy(int col, int row, string[] sprite, double[] directionSpeed)
    {
        pos[0] = oldPos[0] = col;
        pos[1] = oldPos[1] = row;
        this.directionSpeed = (double[])directionSpeed.Clone();
        this.sprite = new Sprite(sprite, ConsoleColor.DarkCyan);
        this.sprite.Draw(col, row);
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
