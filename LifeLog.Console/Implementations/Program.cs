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
            Program program = new Program(args);
            program.Run();
        }

        /// <summary>
        /// program runner
        /// </summary>
        /// <param name="args">
        ///     if args[0] = "-a" then run in admin mode
        /// </param>
        private Program(string[] args)
        {
            mode = GetRunMode(args);
            Run();
        }

        /// <summary>
        /// Run the program
        /// </summary>
        public void Run()
        {
            SetupConsole();
            if (mode == RunMode.Admin)
            {
                AdminMenu.Run();
            }
            else
            {
                UserMenu.Run();
            }
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

        private static void SetTitle(string appTitle)
        {
            System.Console.Title = appTitle;
        }

        private enum RunMode
        {
            User,
            Admin,
        }

        private RunMode mode;

        private const string USER_APP_TITLE = "LifeLog";
        private const string ADMIN_APP_TITLE = "LifeLog Admin";
    }
}
