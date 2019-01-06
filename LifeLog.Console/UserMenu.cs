using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LifeLog.Console.MenuUtil;

namespace LifeLog.Console
{
    public class UserMenu
    {
        public static void Run()
        {
            string[] prompts = new string[]
            {
                "Enter Day",
                "Quit",
            };

            SelectionAction[] actions = new SelectionAction[]
            {
                () => { },
                () => { },
            };

            RunMenu(prompts, actions);
        }
    }
}
