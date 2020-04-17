using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {

        //SET WINDOW METHOD
        public static void WindowSize(int x, int y)
        {
            Console.SetWindowSize(x, y);
        }

        //SET CURSOR METHOD
        public static void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        //DRAW BOX METHOD
        public static void DrawBox()
        {
            SetCursor(5, 5);
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");  // x =  5 - 44 (6-43)
                                                                        // y = 5 - 41 (6-40)
            for (int i = 6; i< 41; i++)
            {
                SetCursor(5, i);
                 Console.Write("X");
                SetCursor(44, i);
                  Console.Write("X");
            }

            SetCursor(5, 41);
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        }



        public static void Main(string[] args)
        {
            WindowSize(100,45);          
            Console.Clear();
            Console.CursorVisible = false;
            DrawBox();

            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Random rand = new Random();
            int snakeX = 15;
            int snakeY = 15;
            int foodX;
            int foodY;
            int thread = 300;
            int parts = 1;


            //Generate First FOOD
            // x = 5 - 44(6 - 43)
            // y = 5 - 41(6 - 40)


            foodX = rand.Next(8, 40);
            foodY = rand.Next(8, 38);

            SetCursor(foodX, foodY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("*");


            while (true)
            {
                SetCursor(snakeX, snakeY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("o");

                System.Threading.Thread.Sleep(thread);


                while (Console.KeyAvailable)
                    cki = Console.ReadKey(true);


                    if (cki.Key == ConsoleKey.W || cki.Key == ConsoleKey.UpArrow)
                    {
                        SetCursor(snakeX, snakeY);
                        Console.WriteLine(" ");
                        snakeY--;
                    }
                    if (cki.Key == ConsoleKey.S || cki.Key == ConsoleKey.DownArrow)
                    {
                        SetCursor(snakeX, snakeY);
                        Console.WriteLine(" ");
                        snakeY++;

                    }
                    if (cki.Key == ConsoleKey.A || cki.Key == ConsoleKey.LeftArrow)
                    {
                        SetCursor(snakeX, snakeY);
                        Console.WriteLine(" ");
                        snakeX--;
                    }
                    if (cki.Key == ConsoleKey.D || cki.Key == ConsoleKey.RightArrow)
                    {
                        SetCursor(snakeX, snakeY);
                        Console.WriteLine(" ");
                        snakeX++;
                    }

                //Generate new FOOD if eaten
                if (foodY == snakeY)
                {
                    if (foodX == snakeX)
                    {
                        foodX = rand.Next(8, 40);
                        foodY = rand.Next(8, 38);
                        SetCursor(foodX, foodY);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("*");
                        thread = thread - 10;
                        parts++;
                    }
                }

            }

            //Console.ReadLine();
        }

    }
}
