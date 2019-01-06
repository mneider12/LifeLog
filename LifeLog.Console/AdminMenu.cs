using LifeLog.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LifeLog.Console.MenuUtil;

namespace LifeLog.Console
{
    public class AdminMenu
    {
        public static void Run()
        {
            string[] prompts = new string[]
            {
                "Install LifeLog",
                "Quit",
            };

            SelectionAction[] actions = new SelectionAction[]
            {
                InstallLifeLog,
                () => { },
            };

            RunMenu(prompts, actions);
        }

        private static void InstallLifeLog()
        {
            Database.Create();
            System.Console.WriteLine("Database created successfully");
            System.Console.WriteLine("Press enter to continue");
            System.Console.ReadLine();
            Run();
        }
    }
}
