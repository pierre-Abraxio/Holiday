using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestMoroccoPublicHoliday
    {

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 11)]
        [DataRow(1, 14)]
        [DataRow(3, 20)]
        [DataRow(5, 27)]
        [DataRow(6, 17)]
        [DataRow(7, 30)]
        [DataRow(8, 14)]
        [DataRow(8, 21)]
        [DataRow(8, 26)]
        [DataRow(11, 6)]
        [DataRow(11, 18)]
        public void TestHolidays2026(int month, int day)
        {
            var holiday = new DateTime(2026, month, day, 0, 0, 0, DateTimeKind.Local);
            var holidayCalendar = new MoroccoPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        [DataRow(2025, 3, 31)]
        [DataRow(2025, 6, 6)]
        [DataRow(2025, 9, 5)]
        [DataRow(2025, 6, 27)]
        public void TestIslamicHolidays2025(int year, int month, int day)
        {
            var holiday = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Local);
            var holidayCalendar = new MoroccoPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

    }
}
