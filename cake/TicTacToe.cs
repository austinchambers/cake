using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    class GameState
    {
        private const int GRID_X = 3;
        private const int GRID_Y = 3;
        public char[,] grid = new char[GRID_X, GRID_Y];
        private char[,] cursor = new char[GRID_X, GRID_Y];
        private int currentX = 0;
        private int currentY = 0;
        private bool firstPlayer = true;

        public GameState()
        {
            SetCursor(0, 0);
        }

        public void MoveUp()
        {
            currentY = (currentY - 1) % 3;
            if (currentY < 0) currentY = 2;
            SetCursor(currentX, currentY);
        }

        public void MoveDown()
        {
            currentY = (currentY + 1) % 3;
            SetCursor(currentX, currentY);
        }

        public void MoveLeft()
        {
            currentX = (currentX - 1) % 3;
            if (currentX < 0) currentX = 2;
            SetCursor(currentX, currentY);
        }

        public void MoveRight()
        {
            currentX = (currentX + 1) % 3;
            SetCursor(currentX, currentY);
        }

        public void SetCursor(int posX, int posY)
        {
            cursor.Populate<char>(' ');
            cursor[posX, posY] = '-';
        }

        public void Write(char playerChar, int posX, int posY)
        {
            grid[posX, posY] = playerChar;
        }

        public void ClearGrids()
        {
            grid.Populate<char>(' ');
            cursor.Populate<char>(' ');
        }

        public void DrawGrid()
        {
            Console.Clear();

            Console.WriteLine(String.Format("-------------"));
            Console.WriteLine(String.Format("|{3}{0}{3}|{4}{1}{4}|{5}{2}{5}|", grid[0, 0], grid[1, 0], grid[2, 0], cursor[0, 0], cursor[1, 0], cursor[2, 0]));
            Console.WriteLine(String.Format("-------------"));
            Console.WriteLine(String.Format("|{3}{0}{3}|{4}{1}{4}|{5}{2}{5}|", grid[0, 1], grid[1, 1], grid[2, 1], cursor[0, 1], cursor[1, 1], cursor[2, 1]));
            Console.WriteLine(String.Format("-------------"));
            Console.WriteLine(String.Format("|{3}{0}{3}|{4}{1}{4}|{5}{2}{5}|", grid[0, 2], grid[1, 2], grid[2, 2], cursor[0, 2], cursor[1, 2], cursor[2, 2]));
            Console.WriteLine(String.Format("-------------"));
            Console.WriteLine(String.Format("Player: {0}", firstPlayer ? 'x' : 'o'));
        }

        public void Place()
        {
            grid[currentX, currentY] = firstPlayer ? 'x' : 'o';
            firstPlayer = !firstPlayer;
        }
    }

    class TicTacToe
    {

        // Start the game. 
        public static void Start()
        {
            GameState thisGame = new GameState();
            // 1. Draw grid

            bool doLoop = true;
            while (doLoop) {
                thisGame.DrawGrid();

                var keyVal = Console.ReadKey(false).Key;
                if (keyVal == ConsoleKey.UpArrow)
                {
                    thisGame.MoveUp();
                }
                else if (keyVal == ConsoleKey.DownArrow)
                {
                    thisGame.MoveDown();
                }
                else if (keyVal == ConsoleKey.LeftArrow)
                {
                    thisGame.MoveLeft();
                }
                else if (keyVal == ConsoleKey.RightArrow)
                {
                    thisGame.MoveRight();
                }
                else if (keyVal == ConsoleKey.Spacebar)
                {
                    thisGame.Place();
                }
                else if (keyVal == ConsoleKey.Escape)
                {
                    return;
                }
                System.Threading.Thread.Sleep(50);
            }
            // 2. Evaluate Input
            // 3. Update. 
        }    
    }


}
