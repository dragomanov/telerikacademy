using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sprite
{
    public string[] sprite;
    public ConsoleColor color;
    public ConsoleColor backColor;
    public int height;
    public int width;
    public bool destroyed = false;

    public Sprite(string[] sprite, ConsoleColor color)
    {
        this.sprite = sprite;
        this.color = color;
        backColor = ConsoleColor.Black;
        height = sprite.Length;
        width = sprite.Max(s => s.Length);
    }

    // Draws the sprite image at the given sprite coordinates
    public void Draw(int col, int row)
    {
        if (col < -width || col >= GameSource.winWidth)
        {
            destroyed = true;
            return;
        }

        Console.ForegroundColor = color;
        if (Console.BackgroundColor != backColor) Console.BackgroundColor = backColor;
        string[] subSprite = (string[])sprite.Clone();

        if (col < 0)
        {
            for (int curRow = 0; curRow < sprite.Length; curRow++)
            {
                subSprite[curRow] = Math.Abs(col) >= subSprite[curRow].Length ? "" : subSprite[curRow].Substring(Math.Abs(col));
            }
            col = 0;
        }
        else if (col + width >= GameSource.winWidth)
        {
            for (int curRow = 0; curRow < sprite.Length; curRow++)
            {
                 subSprite[curRow] = subSprite[curRow].Substring(0, Math.Min(GameSource.winWidth - col, subSprite[curRow].Length));
            }
        }

        for (int curRow = 0; curRow < height; curRow++)
        {
            if ((curRow + row >= 0) && (curRow + row < GameSource.winHeight) && subSprite[curRow].Trim() != "")
            {
                for (int curCol = 0; curCol < subSprite[curRow].Length; curCol++)
                {
                    if ((curCol + col >= 0) && (curCol + col < GameSource.winWidth) && (subSprite[curRow][curCol] != ' '))
                    {
                        Console.SetCursorPosition(col + curCol, row + curRow);
                        Console.Write(subSprite[curRow].Trim());
                        break;
                    }
                }
            }
        }
    }

    // Erases the sprite image at the given sprite coordinates
    public void Erase(int col, int row)
    {
        Console.ForegroundColor = Console.BackgroundColor;

        for (int curRow = 0; curRow < height; curRow++)
        {
            if ((curRow + row >= 0) && (curRow + row < GameSource.winHeight))
            {
                for (int curCol = 0; curCol < sprite[curRow].Length; curCol++)
                {
                    if ((curCol + col >= 0) && (curCol + col < GameSource.winWidth) && (sprite[curRow][curCol] != ' '))
                    {
                        Console.SetCursorPosition(col + curCol, row + curRow);
                        Console.Write(new string(' ', Math.Min(sprite[curRow].Trim().Length, GameSource.winWidth - col - curCol)));
                        break;
                    }
                }
            }
        }
    }

    public void Move(int fromCol, int fromRow, int toCol, int toRow)
    {
        Console.MoveBufferArea(fromCol, fromRow, width, height, toCol, toRow);
    }
}
