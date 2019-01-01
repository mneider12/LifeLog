using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupConsole();
            
            MenuOption selection = GetSelection();

            System.Console.ReadLine();
        }

        private static void SetupConsole()
        {
            System.Console.Title = APP_TITLE;
        }

        private static void DisplayMenu()
        {
            System.Console.WriteLine("{0}) Install LifeLog", (int) MenuOption.InstallLifeLog);
            System.Console.WriteLine("{0}) Quit", (int) MenuOption.Quit);
        }

        private static MenuOption GetSelection()
        {
            string input;
            MenuOption selection;
            do
            {
                DisplayMenu();
                input = System.Console.ReadLine();

            } while (!(Enum.TryParse(input, out selection) && Enum.IsDefined(typeof(MenuOption), selection)));

            return selection;
        }
        
        private enum MenuOption
        {
            InstallLifeLog = 1,
            Quit,
        }

        private const string APP_TITLE = "LifeLog Admin";
    }
}
