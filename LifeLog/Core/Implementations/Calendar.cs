using System;

namespace LifeLog.Core
{
    public class Calendar : ICalendar
    {
        /// <summary>
        /// Get today's date
        /// </summary>
        /// <returns>today's date</returns>
        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}
