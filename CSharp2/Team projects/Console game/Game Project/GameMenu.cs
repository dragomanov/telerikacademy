using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum GameMenuChoices
{
    NewGame,
    ContinueGame,
    Credits,
    Quit
};

class GameMenu
{
    static string[] menu;
    static int index = 0;
    public static string spritePath = "MenuSprite.txt";
    static int spriteHeight = 7;
    private static Sprite[] menuSprites = new Sprite[4];

    public GameMenuChoices MenuChoice()
    {

        Initialize();
        DrawMenu();

        while (!GetKeyboardState())
        {
            DrawMenu();
        }
        if (GameMenu.index == 0)
        {
            return GameMenuChoices.NewGame;
        }
        if (GameMenu.index == 1)
        {
            return GameMenuChoices.ContinueGame;
        }
        if (GameMenu.index == 2)
        {
            return GameMenuChoices.Credits;
        }
        if (GameMenu.index == 3)
        {
            return GameMenuChoices.Quit;
        }
        return MenuChoice();
        
    }

    static void Initialize()
    {
        menu = new string[] { "Start", "Options", "Credits", "Exit" };
        for (int i = 0; i < menu.Length; i++)
        {
            string[] sprite = new string[spriteHeight];
            for (int j = 0; j < spriteHeight; j++)
            {
                sprite[j] = GameSource.sprites["MenuItems"][i * spriteHeight + j];
            }
            menuSprites[i] = new Sprite(sprite, ConsoleColor.Red);
        }
    }

    static bool GetKeyboardState()
    {
        ConsoleKeyInfo info = Console.ReadKey(true);
        if (info.Key == ConsoleKey.DownArrow)
        {
            if (index < menu.Length - 1)
            {
                index++;
            }
            else if (index == 3)
            {
                index = 0;
            }
        }
        if (info.Key == ConsoleKey.UpArrow)
        {
            if (index > 0)
            {
                index--;
            }
            else if (index == 0)
            {
                index = 3;
            }
        }
        if (info.Key == ConsoleKey.Enter)
        {
            
            return true;
        }

        return false;
    }

    static void DrawMenu()
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < menu.Length; i++)
        {
            if (i == index)
            {
                menuSprites[i].color = ConsoleColor.Blue;
            }
            else
            {
                menuSprites[i].color = ConsoleColor.White;
            }
            menuSprites[i].Draw((GameSource.winWidth - menuSprites[i].width) / 2, i * spriteHeight + (GameSource.winHeight / 2) - spriteHeight * 2);
        }
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
