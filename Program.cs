using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Paint in Console";
            bool szinval = true;
            int szin = 0;
            string fj = "";
            string fb = "";
            string lj = "";
            string lb = "";
            string mv = "";
            string hv = "";
            int stilus = 0;
            bool yesstil = true;
            while (szinval)
            {
                Console.Write("A keretnek milyen szint szeretnél?(kérlek számot írj be): ");
                szin = int.Parse(Console.ReadLine()!);
                if (szin < 0 || szin > 15)
                {
                    Console.Write("Kérlek 0 és 15 közötti számot adj meg!");
                }
                else
                {
                    szinval = false;
                }
            }
            Console.WriteLine();
            while (yesstil)
            {
                Console.Write("Milyen stílusú legyen a keret?(─(0) vagy ═(1), a megfelelő számmal válassz): ");
                stilus = int.Parse(Console.ReadLine()!);
                if (stilus == 0)
                {
                    fj = "┌";
                    fb = "┐";
                    lj = "└";
                    lb = "┘";
                    mv = "─";
                    hv = "│";
                    yesstil = false;
                }
                else if (stilus == 1)
                {
                    fj = "╔";
                    fb = "╗";
                    lj = "╚";
                    lb = "╝";
                    mv = "═";
                    hv = "║";
                    yesstil = false;
                }
                else if (stilus != 0 && stilus != 1)
                {
                    Console.WriteLine("Nem jó számot adtál meg!");
                }
            }
            
            Console.WriteLine("Elszeretnél kezdeni rajzolni?");
            Console.Write("Y/N: ");

            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            Console.ForegroundColor = (ConsoleColor)szin;
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    if (i == 0 || i == Console.WindowHeight - 1)
                    {
                        if (i == 0 && j == 0)
                        {
                            Console.Write(fj);
                        }
                        else if (i == Console.WindowHeight - 1 && j == 0)
                        {
                            Console.Write(lj);
                        }
                        else if (i == 0 && j == Console.WindowWidth - 1)
                        {
                            Console.Write(fb);
                        }
                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                        {
                            Console.Write(lb);
                        }
                        else
                        {
                            Console.Write(mv);
                        }
                    }
                    else if (j == 0 || j == Console.WindowWidth - 1)
                    {
                        Console.Write(hv);
                    }

                    else
                    {
                        Console.Write(' ');
                    }
                        

                }
            }
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);


            Console.ForegroundColor = ConsoleColor.White;

            bool toggle = false;
            int back_color = 0;
            int forg_color = 15;
            do
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {/*
                    case ConsoleKey.B:
                        Console.SetCursorPosition(0, 0);
                        back_color++;
                        for (int i = 0; i < Console.WindowHeight; i++)
                        {
                            for (int j = 0; j < Console.WindowWidth; j++)
                            {
                                if (back_color > 15)
                                {
                                    back_color = 0;
                                }
                                
                                Console.BackgroundColor = (ConsoleColor)back_color;
                                Console.Write('█');
                            }
                        }
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;*/
                    case ConsoleKey.Q:
                        toggle = true;
                        break;
                    case ConsoleKey.R:
                        toggle = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (toggle == true)
                        {
                            Console.CursorTop++;
                        }
                        else if (toggle == false)
                        {
                            Console.Write('█');
                            Console.CursorTop++;
                            Console.CursorLeft--;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (toggle == true)
                        {
                            Console.CursorTop--;
                        }
                        else if (toggle == false)
                        {
                            Console.Write('█');
                            Console.CursorTop--;
                            Console.CursorLeft--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (toggle == true)
                        {
                            Console.CursorLeft--;
                        }
                        else if (toggle == false)
                        {
                            Console.Write('█');
                            Console.CursorLeft -= 2;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (toggle != true)
                        {
                            Console.Write('█');
                        }
                        else
                        {
                            Console.CursorLeft++;
                        }
                        break;
                    case ConsoleKey.U:
                        
                        if (forg_color >= 0)
                        {
                            Console.ForegroundColor = (ConsoleColor)forg_color;
                            forg_color--;
                            Console.CursorLeft--;
                        }
                        else
                        {
                            forg_color = 15;
                            Console.ForegroundColor = (ConsoleColor)forg_color;
                            Console.CursorLeft--;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.CursorLeft--;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case ConsoleKey.Delete:
                        Console.Clear();
                        Console.ForegroundColor = (ConsoleColor)szin;
                        for (int i = 0; i < Console.WindowHeight; i++)
                        {
                            for (int j = 0; j < Console.WindowWidth; j++)
                            {
                                if (i == 0 || i == Console.WindowHeight - 1)
                                {
                                    if (i == 0 && j == 0)
                                    {
                                        Console.Write(fj);
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == 0)
                                    {
                                        Console.Write(lj);
                                    }
                                    else if (i == 0 && j == Console.WindowWidth - 1)
                                    {
                                        Console.Write(fb);
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                                    {
                                        Console.Write(lb);
                                    }
                                    else
                                    {
                                        Console.Write(mv);
                                    }
                                }
                                else if (j == 0 || j == Console.WindowWidth - 1)
                                {
                                    Console.Write(hv);
                                }

                                else
                                {
                                    Console.Write(' ');
                                }


                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;

                    
                }

                if (Console.CursorLeft <= 0)
                {
                    Console.SetCursorPosition(1, Console.CursorTop);
                }
                else if (Console.CursorLeft >= Console.WindowWidth - 1)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 2, Console.CursorTop);
                }
                else if (Console.CursorTop <= 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft, 1);
                }
                else if (Console.CursorTop >= Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight - 2);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
