using LifeLog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Model
{
    public class DayValidator: IDayValidator
    {
        public DayValidator(ICalendar calendar)
        {
            this.calendar = calendar;
        }

        public bool Validate(DateTime date, int score)
        {
            return ValidateDate(date) && ValidateScore(score);
        }

        private bool ValidateDate(DateTime date)
        {
            return date != null && date <= calendar.Today;
        }

        private bool ValidateScore(int score)
        {
            return score >= 1 && score <= 10;
        }

        private ICalendar calendar;
    }
}
