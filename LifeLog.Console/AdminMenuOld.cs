using LifeLog.SQLite;
using static LifeLog.Console.MenuUtil;

namespace LifeLog.Console
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminMenuOld
    {
        public static void Run()
        {
            string[] prompts = new string[]
            {
                GetInstallDatabasePrompt(),
                "Quit",
            };

            SelectionAction[] actions = new SelectionAction[]
            {
                InstallLifeLog,
                () => { },
            };

            RunMenu(prompts, actions);
        }

        private static string GetInstallDatabasePrompt()
        {
            if (Database.Exists())
            {
                return "Re-install LifeLog";
            }
            else
            {
                return "Install LifeLog";
            }
        }

        private static void InstallLifeLog()
        {
            bool create = true;
            if (Database.Exists())
            {
                if (YesNoPrompt("Database already exists, are you sure you would like to re-create it?"))
                {
                    Database.Delete();
                }
                else
                {
                    create = false;
                }
            }
            if (create)
            {
                Database.Create();
                System.Console.WriteLine("Database created successfully");
                System.Console.WriteLine("Press enter to continue");
                System.Console.ReadLine();
            }
 
            Run();
        }
    }
}
