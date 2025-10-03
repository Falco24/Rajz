using System.Diagnostics.Metrics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    if (i == 0 || i == Console.WindowHeight - 1)
                    {
                        if (i == 0 && j == 0)
                        {
                            Console.Write('╔');
                        }
                        else if (i == Console.WindowHeight - 1 && j == 0)
                        {
                            Console.Write('╚');
                        }
                        else if (i == 0 && j == Console.WindowWidth - 1)
                        {
                            Console.Write('╗');
                        }
                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                        {
                            Console.Write('╝');
                        }
                        else
                        {
                            Console.Write('═');
                        }
                    }
                    else if (j == 0 || j == Console.WindowWidth - 1)
                    {
                        Console.Write('║');
                    }

                    else
                    {
                        Console.Write(' ');
                    }
                        

                }
            }



            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            do
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        Console.Write('█');
                        Console.CursorTop++;
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Write('█');
                        Console.CursorTop--;
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Write('█');
                        Console.CursorLeft -= 2;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Write('█');
                        break;
                    case ConsoleKey.Spacebar:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case ConsoleKey.Delete:
                        Console.Clear();

                        for (int i = 0; i < Console.WindowHeight; i++)
                        {
                            for (int j = 0; j < Console.WindowWidth; j++)
                            {
                                if (i == 0 || i == Console.WindowHeight - 1)
                                {
                                    if (i == 0 && j == 0)
                                    {
                                        Console.Write('╔');
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == 0)
                                    {
                                        Console.Write('╚');
                                    }
                                    else if (i == 0 && j == Console.WindowWidth - 1)
                                    {
                                        Console.Write('╗');
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                                    {
                                        Console.Write('╝');
                                    }
                                    else
                                    {
                                        Console.Write('═');
                                    }
                                }
                                else if (j == 0 || j == Console.WindowWidth - 1)
                                {
                                    Console.Write('║');
                                }

                                else
                                {
                                    Console.Write(' ');
                                }


                            }
                        }

                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
