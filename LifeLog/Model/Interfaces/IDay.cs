using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Model
{
    /// <summary>
    /// represents a record of a single day
    /// </summary>
    public interface IDay
    {
        DateTime Date { get; set; }
        int Score { get; set; }
    }
}
