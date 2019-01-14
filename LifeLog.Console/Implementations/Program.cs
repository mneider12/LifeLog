using LifeLog.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LifeLog.Console.MenuUtil;

namespace LifeLog.Console
{
    /// <summary>
    /// Text user interface
    /// </summary>
    public class Program: IProgram
    {
        /// <summary>
        /// program entry point
        /// </summary>
        /// <param name="args">
        ///     if args[0] = "-a" then run in admin mode
        /// </param>
        public static void Main(string[] args)
        {
            Dictionary<RunMode, IMenu> startMenus = new Dictionary<RunMode, IMenu>()
            {
                { RunMode.User, new UserMenu() },
                { RunMode.Admin, new AdminMenu() },
            };

            Console console = new Console();
            Program program = new Program(args, console, startMenus);
            program.Run();
        }

        /// <summary>
        /// program runner
        /// </summary>
        /// <param name="args">
        ///     if args[0] = "-a" then run in admin mode
        /// </param>
        /// <param name="console">
        ///     program host console
        /// </param>
        private Program(string[] args, IConsole console, Dictionary<RunMode, IMenu> startMenus)
        {
            mode = GetRunMode(args);
            this.console = console;
        }

        /// <summary>
        /// Run the program
        /// </summary>
        public void Run()
        {
            SetupConsole();
            RunMenu();
        }

        /// <summary>
        /// Determine from the input arguments which mode to run the program in
        /// </summary>
        /// <param name="args">
        ///     if args[0] = "-a" then run in admin mode
        /// </param>
        /// <returns>RunMode to use</returns>
        private static RunMode GetRunMode(string[] args)
        {
            RunMode mode;

            if (args.Length >= 1 && args[0] == "-a")
            {
                mode = RunMode.Admin;
            }
            else
            {
                mode = RunMode.User;
            }

            return mode;
        }

        /// <summary>
        /// Set the console title based on mode
        /// </summary>
        private void SetupConsole()
        {
            string appTitle;
            switch (mode)
            {
                case RunMode.Admin:
                    appTitle = ADMIN_APP_TITLE;
                    break;
                default:
                    appTitle = USER_APP_TITLE;
                    break;
            }

            SetTitle(appTitle);
        }

        /// <summary>
        /// set the console title
        /// </summary>
        /// <param name="appTitle">title</param>
        private void SetTitle(string appTitle)
        {
            console.Title = appTitle;
        }

        private void RunMenu()
        {
            IMenu menu;
            switch (mode)
            {
                case RunMode.Admin:
                    menu = new AdminMenu();
                    menu.Run();
                    break;
                default:
                    UserMenuOld.Run();
                    break;
            }
        }

        private enum RunMode
        {
            User,
            Admin,
        }

        private RunMode mode;
        private IConsole console;

        private const string USER_APP_TITLE = "LifeLog";
        private const string ADMIN_APP_TITLE = "LifeLog Admin";
    }
}
