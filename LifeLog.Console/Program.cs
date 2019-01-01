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
            System.Console.Title = APP_TITLE;
            System.Console.ReadLine();
        }

        private const string APP_TITLE = "LifeLog Admin";
    }
}
