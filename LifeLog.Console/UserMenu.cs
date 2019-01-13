using LifeLog.Model;
using LifeLog.SQLite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LifeLog.Console.MenuUtil;

namespace LifeLog.Console
{
    public class UserMenu
    {
        public static void Run()
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

        private static void EnterDay()
        {
            object dateObject;
            object scoreObject;
            
            if (GetUserInput(out dateObject, "Date", DateValidator) && GetUserInput(out scoreObject, "Score", ScoreValidator))
            {
                DateTime date = (DateTime)dateObject;
                int score = (int)scoreObject;

                Day day = new Day(date, score);

                day.Save();
            }

            Run();
        }

        private static void ViewDays()
        {
            const string sql = "SELECT * FROM days ORDER BY date DESC";
            Database.Query(sql, DayDataLoader);

            Run();
        }

        private static bool GetUserInput(out object value, string prompt, InputValidator validator)
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
            bool success = DateTime.TryParse(input, out date) && Day.IsDateValid(date);
            value = date;
            return success;
        }

        private static bool ScoreValidator(string input, out object value)
        {
            int score;
            bool success = int.TryParse(input, out score) && Day.IsScoreValid(score);
            value = score;
            return success;
        }

        private static void DayDataLoader(SQLiteDataReader reader, out List<Dictionary<string, object>> results)
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
