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
       pipa -> alkalmazkodó keret az ablakhoz
        -> akár több border lehetőség
        -> --------> alex egy buzi !!4! <-------- 
         */
        static void Main(string[] args)
        {
            //Console.SetWindowSize(170, 50);
            Console.Title = "Conint (Console Paint)";
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


            //max 225,60 min 120,30

            Console.Write("_________               .__        __                                                                          \r\n\\_   ___ \\  ____   ____ |__| _____/  |_                                                                        \r\n/    \\  \\/ /  _ \\ /    \\|  |/    \\   __\\                                                                       \r\n\\     \\___(  <_> )   |  \\  |   |  \\  |                                                                         \r\n \\______  /\\____/|___|  /__|___|  /__|                                                                         \r\n        \\/            \\/        \\/                                                                             \r\n                    .___       ___.             ___ ___               __             .______________           \r\n  _____ _____     __| _/____   \\_ |__ ___.__.  /   |   \\ __ __  _____/  |_  ____   __| _/\\_   _____/______  ___\r\n /     \\\\__  \\   / __ |/ __ \\   | __ <   |  | /    ~    \\  |  \\/    \\   __\\/ __ \\ / __ |  |    __)/  _ \\  \\/  /\r\n|  Y Y  \\/ __ \\_/ /_/ \\  ___/   | \\_\\ \\___  | \\    Y    /  |  /   |  \\  | \\  ___// /_/ |  |     \\(  <_> >    < \r\n|__|_|  (____  /\\____ |\\___  >  |___  / ____|  \\___|_  /|____/|___|  /__|  \\___  >____ |  \\___  / \\____/__/\\_ \\\r\n      \\/     \\/      \\/    \\/       \\/\\/             \\/            \\/          \\/     \\/      \\/             \\/");

            Console.WriteLine();

            Console.Write("Milyen hosszú és magas legyen a cmd?(vesszővel elválasztva, max:225,60 - min:120,30): ");
            while (true)
            {

                string[] scale = Console.ReadLine()!.Split(',');
                try
                {
                    if (int.Parse(scale[0]) > 225 && int.Parse(scale[1]) > 60)
                    {
                        Console.Write("Az értékek túl nagyok, az ablak nem lehet nagyobb mint 225x60! Adj meg kisebb értékeket!: ");
                    }
                    else if (int.Parse(scale[0]) < 120 && int.Parse(scale[1]) < 30)
                    {
                        Console.Write("Az értékek túl kicsik, az ablak nem lehet kisebb mint 120x30! Adj meg nagyobb értékeket!: ");
                    }
                    else
                    {
                        Console.SetWindowSize(int.Parse(scale[0]), int.Parse(scale[1]));
                        break;
                    }

                }
                catch (Exception)
                {
                    Console.Write("Hiba történt az értékek beállítása közben, kérlek csak számokat és vesszőt használj!: ");
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Console magassága: {Console.WindowHeight}, szélessége: {Console.WindowWidth}");

            Console.WriteLine();

            Console.Write("A keretnek milyen szint szeretnél?(kérlek számot írj be): ");
            while (szinval)
            {
                try
                {
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
                catch (Exception)
                {
                    Console.Write("Hiba történt a szín beállítása közben, kérlek csak számokat használj!: ");
                }
            }
            Console.WriteLine();
               
            Console.Write("Milyen stílusú legyen a keret?(─(0) vagy ═(1), a megfelelő számmal válassz): ");
            while (yesstil)
            {
                try
                {
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
                        Console.Write("Nem jó számot adtál meg! Próbáld újra!: ");
                    }

                }
                catch (Exception)
                {
                    Console.Write("Hiba történt a stílus beállítása közben, kérlek csak 0 vagy 1 számot adj meg!: ");
                }
            }

            Console.WriteLine();

            Console.Write("Kérlek válassz egy karaktert ecsetnek 1-9 között(█,░,▒,▓,■,▲,►,▼,◄): ");
            while (ybrush)
            {
                try
                {

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
                catch (Exception)
                {
                    Console.Write("Hiba történt az ecset beállítása közben, kérlek csak 1-9 közötti számot adj meg!: ");
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
                        else if (i == 0 && j == Console.WindowWidth - 30)
                        {
                            Console.Write(mhv);
                        }
                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                        {
                            Console.Write(lb);
                        }
                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 30)
                        {
                            Console.Write(mvv);
                        }
                        else
                        {
                            Console.Write(mv);
                        }
                    }
                    else if (j == 0 || j == Console.WindowWidth - 30)
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
            Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.WindowHeight / 2);


            Console.ForegroundColor = ConsoleColor.White;

            bool toggle = false;
            int back_color = 0;
            int forg_color = 15;
            bool nbrush = false;
            CreateUI();
            do
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.B:
                        if (back_color <= 15)
                        {
                            Console.Clear();
                            Console.BackgroundColor = (ConsoleColor)back_color;
                            Console.Clear();
                            back_color++;
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
                                        else if (i == 0 && j == Console.WindowWidth - 30)
                                        {
                                            Console.Write(mhv);
                                        }
                                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                                        {
                                            Console.Write(lb);
                                        }
                                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 30)
                                        {
                                            Console.Write(mvv);
                                        }
                                        else
                                        {
                                            Console.Write(mv);
                                        }
                                    }
                                    else if (j == 0 || j == Console.WindowWidth - 30)
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
                            Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.WindowHeight / 2);
                            
                            Console.ForegroundColor = (ConsoleColor)forg_color;
                        }
                        else
                        {
                            back_color = 0;
                            Console.BackgroundColor = (ConsoleColor)back_color;
                        }
                        break;
                    case ConsoleKey.Insert:
                        nbrush = true;
                        break;
                    case ConsoleKey.Home:
                        nbrush = false;
                        break;
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
                            if (nbrush == true)
                            {
                                Console.CursorLeft--;
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop++;
                                Console.CursorLeft--;
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop++;
                                Console.CursorLeft--;
                                if (!(Console.CursorTop >= Console.WindowHeight - 2))
                                {
                                    Console.Write(brush);
                                    Console.Write(brush);
                                    Console.Write(brush);
                                    Console.CursorLeft -= 2;
                                }
                                else
                                {
                                    Console.CursorLeft++;
                                }
                            }
                            else
                            {
                                Console.Write(brush);
                                Console.CursorTop++;
                                Console.CursorLeft--;
                            }
                                
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (toggle == true)
                        {
                            Console.CursorTop--;
                        }
                        else if (toggle == false)
                        {
                            if (nbrush == true)
                            {
                                Console.CursorLeft--;
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop--;
                                Console.CursorLeft--;
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                if (!(Console.CursorTop <= 2))
                                {
                                    Console.CursorTop--;
                                    Console.CursorLeft--;
                                    Console.Write(brush);
                                    Console.Write(brush);
                                    Console.Write(brush);
                                    Console.CursorLeft -= 2;
                                }
                                
                            }
                            else
                            {
                                Console.Write(brush);
                                Console.CursorLeft--;
                                Console.CursorTop--;
                            }
                                
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (toggle == true)
                        {
                            Console.CursorLeft--;
                        }
                        else if (toggle == false)
                        {
                            if (nbrush == true)
                            {
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.Write(brush);
                                Console.CursorLeft++;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop--;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.Write(brush);
                                Console.CursorLeft++;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop+=2;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.Write(brush);
                                Console.CursorLeft++;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop--;
                                Console.CursorLeft --;
                            }
                            else
                            {
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                            }
                                
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (toggle != true)
                        {
                            if (nbrush == true)
                            {
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.Write(brush);
                                Console.CursorLeft++;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop--;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.Write(brush);
                                Console.CursorLeft++;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop+=2;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.Write(brush);
                                Console.CursorLeft++;
                                Console.Write(brush);
                                Console.CursorLeft -= 2;
                                Console.CursorTop--;
                                Console.CursorLeft++;
                                if (Console.CursorLeft >= Console.WindowWidth - 31)
                                {
                                    Console.CursorLeft--;
                                }
                            }
                            else
                            {
                                Console.Write(brush);
                            }
                            
                        }
                        else
                        {
                            Console.CursorLeft++;
                        }
                        break;
                    case ConsoleKey.PageUp:
                        
                        if (forg_color >= 0)
                        {
                            Console.ForegroundColor = (ConsoleColor)forg_color;
                            forg_color--;
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
                                    else if (i == 0 && j == Console.WindowWidth - 30)
                                    {
                                        Console.Write(mhv);
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                                    {
                                        Console.Write(lb);
                                    }
                                    else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 30)
                                    {
                                        Console.Write(mvv);
                                    }
                                    else
                                    {
                                        Console.Write(mv);
                                    }
                                }
                                else if (j == 0 || j == Console.WindowWidth - 30)
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
                        CreateUI();
                        Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.WindowHeight / 2);
                        break;
                    case ConsoleKey.End:
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.WindowHeight / 2);
                        Console.Write("Biztosan vissza szeretnél menni a menübe? Y/N: ");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            Main(args);
                            return;
                        }
                        else
                        {
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
                                        else if (i == 0 && j == Console.WindowWidth - 30)
                                        {
                                            Console.Write(mhv);
                                        }
                                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 1)
                                        {
                                            Console.Write(lb);
                                        }
                                        else if (i == Console.WindowHeight - 1 && j == Console.WindowWidth - 30)
                                        {
                                            Console.Write(mvv);
                                        }
                                        else
                                        {
                                            Console.Write(mv);
                                        }
                                    }
                                    else if (j == 0 || j == Console.WindowWidth - 30)
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
                            Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.WindowHeight / 2);
                        }
                        break;

                    
                }
                ClampCursor(nbrush);
                

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        static void ClampCursor(bool nbrush)
        {
            int leftMin = 2;
            int leftMax = nbrush ? Console.WindowWidth - 31 : Console.WindowWidth - 31;
            int topMin = nbrush ? 2 : 1;
            int topMax = nbrush ? Console.WindowHeight - 3 : Console.WindowHeight - 2;

            if (leftMax < leftMin) leftMax = leftMin;
            if (topMax < topMin) topMax = topMin;

            int left = Math.Clamp(Console.CursorLeft, leftMin, leftMax);
            int top = Math.Clamp(Console.CursorTop, topMin, topMax);

            if (left != Console.CursorLeft || top != Console.CursorTop)
            {
                Console.SetCursorPosition(left, top);
            }
        }

        static void CreateUI()
        { //Rajzolásnál lévő jobb oldali UIra
            Console.SetCursorPosition(Console.WindowWidth - 28, 1);
            Console.WriteLine("->Conint - Console Paint<-");
            Console.SetCursorPosition(Console.WindowWidth - 28, 2);
            Console.WriteLine("--------------------------");
            Console.SetCursorPosition(Console.WindowWidth - 28, 3);
            Console.WriteLine("Vezérlése a programnak");
            Console.SetCursorPosition(Console.WindowWidth - 28, 4);
            Console.WriteLine("--------------------------");
            Console.SetCursorPosition(Console.WindowWidth - 28, 5);
            Console.WriteLine("Insert - Nagyobb ecset ON");
            Console.SetCursorPosition(Console.WindowWidth - 28, 6);
            Console.WriteLine("Home - Nagyobb ecset OFF");
            Console.SetCursorPosition(Console.WindowWidth - 28, 7);
            Console.WriteLine("Q - Ecset OFF");
            Console.SetCursorPosition(Console.WindowWidth - 28, 8);
            Console.WriteLine("R - Ecset ON");
            Console.SetCursorPosition(Console.WindowWidth - 28, 9);
            Console.WriteLine("Nyílak - Ecset mozgatása");
            Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.WindowHeight / 2);
        }
    }
}

/* File.ReadAllLines(path)
   File.WriteAllLines (path, content)
   ----------------------------------
   File.Exist
   Directory
   mentéshez adatok segíthetnek (char,color,x,y;...,...;) splitelni mondjuk vesszőnél
   ----------------------------------
   Dictionary<K,T> Kulcs és Érték pár, tupplet célszerű használni kulcsnak és értéknek is
   ----------------------------------
   HashSet<T> -- csak fun fact
   Tupple meg említendő, de fontos tudni az arrayt meg listet is
*/