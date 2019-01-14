using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Console
{
    /// <summary>
    /// interact with the console program host
    /// </summary>
    public interface IConsole
    {
        string Title { get; set; }
    }
}
