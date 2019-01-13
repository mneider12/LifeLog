using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Core
{
    /// <summary>
    /// Interface for dependency on system calendar
    /// </summary>
    public interface ICalendar
    {
        DateTime Today { get; }
    }
}
