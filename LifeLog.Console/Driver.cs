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
    /// All necessary dependencies should be defined here
    /// </summary>
    public class Driver
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
    }
}