using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeLog.Model
{
    [TestClass]
    public class DayTest
    {
        [TestMethod]
        public void Create_ValidDateAndTime_DayIsCreated()
        {
            DateTime expectedDate = DateTime.Today.AddDays(-2);     // past date is valid
            int expectedScore = 5;                                  // 5 is a valid score 1-10                 

            Day testDay = Day.Create(expectedDate, expectedScore);

            Assert.AreEqual(expectedDate, testDay.Date);
            Assert.AreEqual(expectedScore, testDay.Score);
        }

        [TestMethod]
        public void Create_InvalidDateAndTime_DayIsNull()
        {
            DateTime invalidDate = DateTime.Today.AddDays(2);   // can't future date
            int invalidScore = 11;                              // 11 is outside range 1-10

            DateTime validDate = DateTime.Today.AddDays(-2);    // past date is valid
            int validScore = 10;                                // 10 is valid 1-10 inclusive

            Day testDay = Day.Create(invalidDate, invalidScore);

            Assert.IsNull(testDay);

            testDay = Day.Create(invalidDate, validScore);

            Assert.IsNull(testDay);

            testDay = Day.Create(validDate, invalidScore);

            Assert.IsNull(testDay);

            testDay = Day.Create(validDate, validScore);        // sanity check that the inputs are actually valid

            Assert.IsNotNull(testDay);
        }

        [TestMethod]
        public void IsDateValid_ValidDate_ReturnTrue()
        {
            //Assert.IsTrue(Day.IsDateValid())
        }
    }
}
