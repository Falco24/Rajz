using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    internal class Program
    {
        /*
         Kéne még (ha nem vagyok segghülye): 
        -> háttérszín változtatás
        -> ablak nagyságának kiírása és változtatására lehetőség
        -> rendes menü indításnál és vissza lépési lehetőség menübe
        -> kurzor/szín változtatás
        -> nagyobb brush méretek ha esetleg rájönnék hogyan
        -> (talán) lapokat csinálni mint a domi v fáljba mentés
        -> undo lehetőség
        -> adatok megjelenítése (pl. aktuális szín, ecset, háttérszín, stb)
        -> alkalmazkodó keret az ablakhoz
        -> akár több border lehetőség
        -> --------> alex egy buzi !!4! <-------- 
         */
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);
            Console.Title = "Paint in Console";
            bool szinval = true;
            int szinbor = 0;
            char fj = ' ';
            char fb = ' ';
            char lj = ' ';
            char lb = ' ';
            char mv = ' ';
            char hv = ' ';
            char mhv = ' ';
            char mvv = ' ';
            char brush = ' ';
            int stilus = 0;
            bool yesstil = true;
            bool ybrush = true;

            Console.WriteLine($"Console magassága: {Console.WindowHeight}, szélessége: {Console.WindowWidth}");
            
            Console.WriteLine();

            while (szinval)
            {
                Console.Write("A keretnek milyen szint szeretnél?(kérlek számot írj be): ");
                szinbor = int.Parse(Console.ReadLine()!);
                if (szinbor < 0 || szinbor > 15)
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
                    fj = '┌';
                    fb = '┐';
                    lj = '└';
                    lb = '┘';
                    mv = '─';
                    hv = '│';
                    mhv = '┬';
                    mvv = '┴';
                    yesstil = false;
                }
                else if (stilus == 1)
                {
                    fj = '╔';
                    fb = '╗';
                    lj = '╚';
                    lb = '╝';
                    mv = '═';
                    hv = '║';
                    mhv = '╦';
                    mvv = '╩';
                    yesstil = false;
                }
                else if (stilus != 0 && stilus != 1)
                {
                    Console.WriteLine("Nem jó számot adtál meg!");
                }
            }

            Console.WriteLine();

            while (ybrush)
            {
                Console.Write("Kérlek válassz egy karaktert ecsetnek 1-9 között(█,░,▒,▓,■,▲,►,▼,◄): ");
                int brush_choice = int.Parse(Console.ReadLine()!);
                switch (brush_choice)
                {
                    case 1:
                        brush = '█';
                        ybrush = false;
                        break;
                    case 2:
                        brush = '░';
                        ybrush = false;
                        break;
                    case 3:
                        brush = '▒';
                        ybrush = false;
                        break;
                    case 4:
                        brush = '▓';
                        ybrush = false;
                        break;
                    case 5:
                        brush = '■';
                        ybrush = false;
                        break;
                    case 6:
                        brush = '▲';
                        ybrush = false;
                        break;
                    case 7:
                        brush = '►';
                        ybrush = false;
                        break;
                    case 8:
                        brush = '▼';
                        ybrush = false;
                        break;
                    case 9:
                        brush = '◄';
                        ybrush = false;
                        break;
                    default:
                        Console.WriteLine("Nem jó számot adtál meg!");
                        break;
                }
            }

            Console.WriteLine();

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

            Console.ForegroundColor = (ConsoleColor)szinbor;
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
                        else if (i == 0 && j == Console.WindowWidth - 20)
                        {
                            Console.Write(mhv);
                        }
                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                        {
                            Console.Write(lb);
                        }
                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 20)
                        {
                            Console.Write(mvv);
                        }
                        else
                        {
                            Console.Write(mv);
                        }
                    }
                    else if (j == 0 || j == Console.WindowWidth - 20)
                    {
                        Console.Write(hv);
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
            //int back_color = 0;
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
                            Console.Write(brush);
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
                            Console.Write(brush);
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
                            Console.Write(brush);
                            Console.CursorLeft -= 2;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (toggle != true)
                        {
                            Console.Write(brush);
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
                        Console.ForegroundColor = (ConsoleColor)szinbor;
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
                                    else if (i == 0 && j == Console.WindowWidth - 20)
                                    {
                                        Console.Write(mhv);
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                                    {
                                        Console.Write(lb);
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 20)
                                    {
                                        Console.Write(mvv);
                                    }
                                    else
                                    {
                                        Console.Write(mv);
                                    }
                                }
                                else if (j == 0 || j == Console.WindowWidth - 20)
                                {
                                    Console.Write(hv);
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
                    Console.SetCursorPosition(2, Console.CursorTop);
                }
                else if (Console.CursorLeft >= Console.WindowWidth - 1)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 3, Console.CursorTop);
                }
                else if (Console.CursorTop <= 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft, 2);
                }
                else if (Console.CursorTop >= Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight - 3);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
