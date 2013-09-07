using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerShip
{
    enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    };

    private int[] pos = new int[2];
    private int[] oldPos = new int[2];
    private Direction direction = Direction.None;
    public bool updated = false;
    public static string spritePath = "PlayerShipSprite.txt";
    private Sprite sprite;

    public PlayerShip(int col = 0, int row = 0)
    {
        pos[0] = oldPos[0] = col;
        pos[1] = oldPos[1] = row;
        sprite = new Sprite(GameSource.sprites["PlayerShip"], ConsoleColor.White);
        sprite.Draw(col, row);
    }

    public void Move(string newDirection)
    {
        switch (newDirection)
        {
            case "Up":
                direction = Direction.Up;
                break;
            case "Down":
                direction = Direction.Down;
                break;
            case "Left":
                direction = Direction.Left;
                break;
            case "Right":
                direction = Direction.Right;
                break;
        }
    }

    public void Shoot(List<Missile> missiles)
    {
        missiles.Add(new Missile(pos[0] + sprite.width, pos[1] + sprite.height / 2, new Sprite(new string[] { "*" }, ConsoleColor.DarkGreen)));
        missiles[missiles.Count - 1].Draw();
    }

    public void Collide(List<Enemy> objects)
    {
        foreach (Enemy obj in new List<Enemy>(objects))
        {
            int startRow = Math.Max(pos[1], obj.pos[1]);
            int endRow = Math.Min(pos[1] + sprite.height, obj.pos[1] + obj.sprite.height);
            for (int curRow = startRow; curRow < endRow; curRow++)
            {
                if (sprite.sprite[endRow - curRow - 1].TrimEnd().Length + pos[1] >= obj.pos[1])
                {
                    obj.sprite.Erase(obj.pos[0], obj.pos[1]);
                    objects.Remove(obj);
                }
            }
        }
    }

    public void Update()
    {
        updated = false;
        oldPos = (int[])pos.Clone();

        if (direction == Direction.Up && pos[1] > 0)
        {
            pos[1]--;
        }
        else if (direction == Direction.Down && pos[1] < GameSource.winHeight - sprite.height)
        {
            pos[1]++;
        }
        else if (direction == Direction.Left && pos[0] > 0)
        {
            pos[0]--;
        }
        else if (direction == Direction.Right && pos[0] < GameSource.winWidth - sprite.width)
        {
            pos[0]++;
        }

        if (direction != Direction.None)
        {
            updated = true;
        }

        direction = Direction.None;

    }

    public void Draw()
    {
        sprite.Erase(oldPos[0], oldPos[1]);
        sprite.Draw(pos[0], pos[1]);

    }
}
