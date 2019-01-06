using LifeLog.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LifeLog.Console.MenuUtil;

namespace LifeLog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "-a")
            {
                RunAdmin();
            }
            else
            {
                RunUser();
            }
        }

        private static void RunUser()
        {
            SetupConsole(USER_APP_TITLE);
            UserMenu.Run();
        }

        private static void RunAdmin()
        {
            SetupConsole(ADMIN_APP_TITLE);
            AdminMenu.Run();
        }

        private static void SetupConsole(string appTitle)
        {
            System.Console.Title = appTitle;
        }

        private const string USER_APP_TITLE = "LifeLog";
        private const string ADMIN_APP_TITLE = "LifeLog Admin";
    }
}
