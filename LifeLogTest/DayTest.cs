using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeLog.Model
{
    [TestClass]
    public class DayTest
    {
        [TestMethod]
        public void Constructor_DateAndScoreSet()
        {
            DateTime expectedDate = DateTime.Today.AddDays(-2);     // past date is valid
            int expectedScore = 5;                                  // 5 is a valid score 1-10                 

            Day testDay = new Day()
            {
                Date = expectedDate,
                Score = expectedScore,
            };

            Assert.AreEqual(expectedDate, testDay.Date);
            Assert.AreEqual(expectedScore, testDay.Score);
        }
    }
}
