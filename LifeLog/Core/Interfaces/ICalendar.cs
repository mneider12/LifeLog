using System;

namespace LifeLog.Core
{
    /// <summary>
    /// Interface for dependency on system calendar
    /// </summary>
    public interface ICalendar
    {
        /// <summary>
        /// today's date
        /// </summary>
        DateTime Today { get; }
    }
}
