using LifeLog.Core;
using LifeLog.Model;
using LifeLog.SQLite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static LifeLog.Console.MenuUtil;

namespace LifeLog.Console
{
    public class UserMenu: IMenu
    {
        public void Run()
        {
            string[] prompts = new string[]
            {
                "Enter Day",
                "View Days",
                "Quit",
            };

            SelectionAction[] actions = new SelectionAction[]
            {
                EnterDay,
                ViewDays,
                () => { },
            };

            RunMenu(prompts, actions);
        }

        private void EnterDay()
        {
            object dateObject;
            object scoreObject;
            Calendar calendar = new Calendar();

            if (GetUserInput(out dateObject, "Date", DateValidator) && GetUserInput(out scoreObject, "Score", ScoreValidator))
            {
                DateTime date = (DateTime)dateObject;
                int score = (int)scoreObject;

                Day day = new Day()
                {
                    Date = date,
                    Score = score,
                };

                Save(day);
            }

            Run();
        }

        private  void ViewDays()
        {
            const string sql = "SELECT * FROM days ORDER BY date DESC";
            Database.Query(sql, DayDataLoader);

            Run();
        }

        private bool GetUserInput(out object value, string prompt, InputValidator validator)
        {
            string input;
            do
            {
                System.Console.WriteLine("{0}: ", prompt);
                input = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    value = null;
                    return false;
                }

            } while (!validator(input, out value));

            return true;
        }
        private static bool DateValidator(string input, out object value)
        {
            DateTime date;
            bool success = DateTime.TryParse(input, out date) && IsDateValid(date);
            value = date;
            return success;
        }

        private static bool ScoreValidator(string input, out object value)
        {
            int score;
            bool success = int.TryParse(input, out score) && IsScoreValid(score);
            value = score;
            return success;
        }

        public static bool IsDateValid(DateTime date)
        {
            return date.CompareTo(DateTime.Today) <= 0;
        }

        public static bool IsScoreValid(int score)
        {
            return score >= 1 && score <= 10;
        }

        public static void Save(Day day)
        {
            string sql = string.Format("INSERT INTO days (date, score) values ('{0}', '{1}')", day.Date.Ticks, day.Score);
            Database.ExecuteNonQuery(sql);
        }

        private void DayDataLoader(SQLiteDataReader reader, out List<Dictionary<string, object>> results)
        {
            results = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                long ticks = reader.GetInt64(0);
                DateTime date = new DateTime(ticks);
                int score = reader.GetInt32(1);
                System.Console.WriteLine("{0}: {1}", date.ToShortDateString(), score);
            }
        }

        private delegate bool InputValidator(string input, out object value);
    }
}