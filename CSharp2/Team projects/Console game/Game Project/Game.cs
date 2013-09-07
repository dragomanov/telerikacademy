using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Game
{
    int fps = 0;
    DateTime start;
    private bool isRunning = false;
    private bool isPaused = false;
    private int score = 0;
    private static readonly int winWidth = GameSource.winWidth;
    private static readonly int winHeight = GameSource.winHeight;
    public readonly Dictionary<string, string[]> sprites = new Dictionary<string, string[]>();
    private Thread drawThread;
    private PlayerShip player;
    private List<Enemy> enemies = new List<Enemy>();
    public List<Missile> playerMissiles = new List<Missile>();
    public Random rng;

    public Game()
    {
        drawThread = new Thread(UpdateAndDraw);
        rng = new Random();
        sprites = GameSource.sprites;
    }

    public void StartGame()
    {
        DateTime start = DateTime.Now;
        Console.Clear();
        player = new PlayerShip(0, (winHeight - sprites["PlayerShip"].Length) / 2);
        string[] enemySprite = sprites["EnemyShips"];
        enemies.Add(new Enemy(17, 25, enemySprite, new double[] { 0, 0 }));
        this.isRunning = true;
        drawThread.Start();
        while (isRunning || isPaused)
        {
            ConsoleKeyInfo inKey = Console.ReadKey(true);
            if (inKey.Key == ConsoleKey.Pause || inKey.Key == ConsoleKey.P)
            {
                if (isPaused)
                {
                    UnpauseGame();
                }
                else
                {
                    PauseGame();
                }
            }
            else if (inKey.Key == ConsoleKey.Escape)
            {
                isRunning = false;
            }
            else if (inKey.Key == ConsoleKey.UpArrow)
            {
                player.Move("Up");
            }
            else if (inKey.Key == ConsoleKey.DownArrow)
            {
                player.Move("Down");
            }
            else if (inKey.Key == ConsoleKey.LeftArrow)
            {
                player.Move("Left");
            }
            else if (inKey.Key == ConsoleKey.RightArrow)
            {
                player.Move("Right");
            }
            else if (inKey.Key == ConsoleKey.Spacebar)
            {
                player.Shoot(playerMissiles);
            }
        }

        EndGame();
    }

    private void PauseGame()
    {
        isRunning = false;
        isPaused = true;
        drawThread.Suspend();
    }

    private void UnpauseGame()
    {
        isRunning = true;
        isPaused = false;
        drawThread.Resume();
    }

    // Called when game ends (displays score and waits for keypress to return to the menu)
    private void EndGame()
    {
        // TODO: Display more information and present it in a nice way (centered?)
        Console.Clear();
        Console.WriteLine("Score: {0}", score);
        Console.ReadKey(true);
    }


    // Updates all objects' states in the game
    private void Update()
    {
        player.Update();
        player.Collide(enemies);

        foreach (var enemy in new List<Enemy>(enemies))
        {
            enemy.Update();
            if (enemy.destroyed)
            {
                enemies.Remove(enemy);
            }
        }

        foreach (var missile in new List<Missile>(playerMissiles))
        {
            missile.Update();
            if (missile.destroyed)
            {
                playerMissiles.Remove(missile);
            }
        }
    }

    // Draws all objects in the game
    private void Draw()
    {
        if (player.updated)
        {
            player.Draw();
        }

        foreach (var enemy in enemies)
        {
            if (enemy.updated)
            {
                enemy.Draw();
            }
        }

        foreach (var missile in new List<Missile>(playerMissiles))
        {
            if (missile.updated)
            {
                missile.Draw();
            }
        }
    }

    // Used by the separate thread to call the Update and Draw methods
    private void UpdateAndDraw()
    {
        while (isRunning || isPaused)
        {
            if (isRunning)
            {
                Update();
                Draw();
            }
            fps++;
            if ((DateTime.Now - start).Seconds >= 1)
            {
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0:00} fps", fps);
                Console.ResetColor();
                fps = 0;
                start = DateTime.Now;
                string[] enemySprite = sprites["EnemyShips"];
                //enemies.Add(new Enemy(winWidth - 1, rng.Next(winHeight - enemySprite.Length), enemySprite, new double[] { -(rng.Next(4, 12) / 10.0), 0 }));
            }
            Thread.Sleep(20);
        }
    }
}