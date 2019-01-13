using LifeLog.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Model
{
    /// <summary>
    /// Log for one day
    /// </summary>
    public class Day : IDay
    {
        /// <summary>
        /// Date of log
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// day's overall score
        /// </summary>
        public int Score { get; set; }
    }
}
