using LifeLog.SQLite;
using static LifeLog.Console.BaseMenu;

namespace LifeLog.Console
{
    public class AdminMenu: IMenu
    {
        public AdminMenu()
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

            menu = new BaseMenu(prompts, actions);
        }

        public void Run()
        {
            menu.Run();
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

        private void InstallLifeLog()
        {
            bool create = true;
            if (Database.Exists())
            {
                if (MenuUtil.YesNoPrompt("Database already exists, are you sure you would like to re-create it?"))
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

            menu.Run();
        }

        private BaseMenu menu;
    }
}
