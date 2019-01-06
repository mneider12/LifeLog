using LifeLog.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Model
{
    public class Day
    {
        private Day() { }

        public static Day Create(DateTime date, int score)
        {
            if (IsDateValid(date) && IsScoreValid(score))
            {
                return new Day()
                {
                    Date = date,
                    Score = score,
                };
            }
            else
            {
                return null;
            }
        }

        public static bool IsDateValid(DateTime date)
        {
            return date.CompareTo(DateTime.Today) <= 0;
        }

        public static bool IsScoreValid(int score)
        {
            return score >= 1 && score <= 10;
        }

        public void Save()
        {
            string sql = string.Format("INSERT INTO days (date, score) values ('{0}', '{1}')", Date.Ticks, Score);
            Database.ExecuteNonQuery(sql);
        }

        public DateTime Date { get; set; }
        public int Score { get; set; }
    }
}
