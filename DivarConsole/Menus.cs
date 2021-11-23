using System;
using System.Threading;

namespace DivarConsole
{
    public class Menus
    {
        private readonly Utility _utility = new Utility();
        public ConsoleKeyInfo BaseMenu()
        {
            _utility.ShowHeader("Menu", "Menu");
            Console.WriteLine("(1)Show All Advertise\n" +
                              "(2)Add New Advetise\n" +
                              "(3)Search In Advertises\n" +
                              "(4)My Published Advertise\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 2);
            Console.WriteLine("(F1) Admin Menu\n");
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("(ESC)Exit\n");
            Console.ResetColor();
            Console.WriteLine();

            return _utility.Getkey("Enter Your Choice From App Menu : ");
        }
        public ConsoleKeyInfo AdminMenu()
        {
            _utility.ShowHeader("Admin menu", "Menu list");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("(1)Add new category");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("(2)Add new city");
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("(3)Add new area");
            Console.SetCursorPosition(21,2);
            Console.WriteLine("(4)Show all category");
            Console.SetCursorPosition(21, 3);
            Console.WriteLine("(5)Show all city");
            Console.SetCursorPosition(21, 4);
            Console.WriteLine("(6)Show all area");
            Console.SetCursorPosition(42, 2);
            Console.WriteLine("(7)Show all advertise");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(42, 4);
            Console.WriteLine("(Backspace)Log out");
            Console.ResetColor();

            Console.SetCursorPosition(0,5);
            return _utility.Getkey("Enter your choice from admin menu: ");
        }
        public bool AdminLogin()
        {
            Console.Clear();
            Console.WriteLine("Enter admin Password : ");
            var pass = Console.ReadLine();
            if(pass == "23916558")
            {
                return true;
            }
            return false;
        }
        public void StartApp()
            
        {
            //Console.WriteLine(" ║╔ ╣╠ ╗ ╗ ╚ ╝ ");
            Console.WriteLine("╔════════╗   ╔════════╗ ╔═╗            ╔═╗   ╔════╗       ╔════════╗      \n" +
                              "║ ╔════╗ ╚╗  ╚══╗  ╔══╝ ╚╗╚╗          ╔╝╔╝  ╔╝╔══╗╚╗      ║ ╔═════╗╚╗     \n" +
                              "║ ║    ╚╗ ╚╗    ║  ║     ╚╗╚╗        ╔╝╔╝  ╔╝╔╝  ╚╗╚╗     ║ ║     ╚╗╚╗    \n" +
                              "║ ║     ╚╗ ╚╗   ║  ║      ╚╗╚╗      ╔╝╔╝  ╔╝╔╝    ╚╗╚╗    ║ ║     ╔╝╔╝    \n" +
                              "║ ║     ╔╝ ╔╝   ║  ║       ╚╗╚╗    ╔╝╔╝  ╔╝ ╚══════╝ ╚╗   ║ ╚═════╝╔╝    \n" +
                              "║ ║    ╔╝ ╔╝    ║  ║        ╚╗╚╗  ╔╝╔╝  ╔╝╔══════════╗╚╗  ║ ╔═════╗╚╗     \n" +
                              "║ ╚════╝ ╔╝  ╔══╝  ╚══╗      ╚╗╚══╝╔╝  ╔╝╔╝          ╚╗╚╗ ║ ║     ╚╗╚╗     \n" +
                              "╚════════╝   ╚════════╝       ╚════╝   ╚═╝            ╚═╝ ╚═╝      ╚═╝    \n");
            string Loading = "■";
            
            for (int i = 0; i <= 40; i++)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write($"Loading . . .({Loading}){i*2.5}%");
                Thread.Sleep(250);
                Loading += "■";
            }
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Loading Complete ! Press Any Key to Show Menu  . . . . . . . . . . . ");
            Console.ReadKey();
        }
    }
}
