using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Console
{
    /// <summary>
    /// wrapper for calls to the standard console
    /// </summary>
    class Console: IConsole
    {
        /// <summary>
        /// display title
        /// </summary>
        public string Title
        {
            get
            {
                return System.Console.Title;
            }
            set
            {
                System.Console.Title = value;
            }
        }
    }
}
