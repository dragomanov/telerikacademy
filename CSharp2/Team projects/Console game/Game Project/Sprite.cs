using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sprite
{
    private string[] sprite;
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
        Console.ForegroundColor = color;
        Console.BackgroundColor = backColor;

        destroyed = true;
        for (int curRow = 0; curRow < height; curRow++)
        {
            if ((curRow + row >= 0) && (curRow + row < GameSource.winHeight))
            {
                for (int curCol = 0; curCol < sprite[curRow].Length; curCol++)
                {
                    if ((curCol + col >= 0) && (curCol + col < GameSource.winWidth) && (sprite[curRow][curCol] != ' '))
                    {
                        Console.SetCursorPosition(col + curCol, row + curRow);
                        Console.Write(@sprite[curRow].Trim());
                        destroyed = false;
                        break;
                    }
                }
            }
        }

        Console.ResetColor();
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
                        Console.Write(new string(' ', sprite[curRow].Trim().Length));
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
