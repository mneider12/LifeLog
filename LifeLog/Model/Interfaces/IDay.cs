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
        /// <summary>
        /// Date of log
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// Day's overall score
        /// </summary>
        int Score { get; set; }
    }
}
