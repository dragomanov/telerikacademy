using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class GameSource
{
    public static readonly int winWidth = 120;
    public static readonly int winHeight = 50;
    public static readonly Dictionary<string, string[]> sprites = new Dictionary<string,string[]>();

    static void Main()
    {
        // Initializes sprites in dictionary
        sprites.Add("PlayerShip", File.ReadAllLines(PlayerShip.spritePath));
        sprites.Add("EnemyShips", File.ReadAllLines(Enemy.spritePath));
        sprites.Add("MenuItems", File.ReadAllLines(GameMenu.spritePath));

        // Sets console window properties
        Console.CursorVisible = false;
        Console.SetWindowSize(winWidth, winHeight);
        Console.SetBufferSize(winWidth, winHeight);

        GameMenuChoices choice;
        GameMenu menu = new GameMenu();
        do
        {
            choice = menu.MenuChoice();
            if (choice == GameMenuChoices.NewGame)
            {
                Game newGame = new Game();
                newGame.StartGame();
            }
            else if (choice == GameMenuChoices.ContinueGame)
            {
                // TODO:
                Console.WriteLine("Continue");
            }
            else if (choice == GameMenuChoices.Credits)
            {
                // TODO: 
                Console.WriteLine("Creators");
            }
            else if (choice == GameMenuChoices.Quit)
            {
                // TODO: 
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Do you really want to quit the game?");
                Console.SetCursorPosition(Console.WindowWidth / 2, (Console.WindowHeight / 2)+1);
                Console.Write("Y/N: ");
                string choiceToQuit = Console.ReadLine();
                if ((choiceToQuit == "Y" || choiceToQuit == "y"))
                {
                    Environment.Exit(0);
                    
                }
                else
                {
                    Console.Clear(); choice = menu.MenuChoice();
                    Console.SetCursorPosition(0, 0);
                   
                }
            }
            Console.Clear();
        } while (true); 
    }
}
