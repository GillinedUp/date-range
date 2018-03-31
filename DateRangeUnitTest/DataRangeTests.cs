using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRangeNamespace;

namespace DateRangeUnitTest
{
    [TestClass]
    public class DateRangeTests
    {
        [TestMethod]
        public void ParseDatesTest()
        {
            // arrange
            DateRange dateRange = new DateRange();
            string format = "dd.MM.yyyy";
            string date1Expected = "01.02.2017";
            string date2Expected = "02.02.2017";

            //act
            var dates = dateRange.ParseDates(date1Expected, date2Expected);
            string date1Actual = dates[0].ToString(format);
            string date2Actual = dates[1].ToString(format);

            //assert
            Assert.AreEqual(date1Expected, date1Actual);
            Assert.AreEqual(date2Expected, date2Actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestForExceptionInValidateDates()
        {
            // arrange
            DateRange dateRange = new DateRange();
            var date1 = new DateTime(2017, 2, 2);
            var date2 = new DateTime(2017, 2, 1);

            //act
            dateRange.ValidateDates(date1, date2);
        }

        [TestMethod]
        public void TestForNoExceptionForEqualDates()
        {
            // arrange
            DateRange dateRange = new DateRange();
            var date1 = new DateTime(2017, 2, 2);
            var date2 = new DateTime(2017, 2, 2);

            //act
            dateRange.ValidateDates(date1, date2);
        }

        [TestMethod]
        public void TestForNoExceptionForDifferentDates()
        {
            // arrange
            DateRange dateRange = new DateRange();
            var date1 = new DateTime(2017, 1, 2);
            var date2 = new DateTime(2018, 7, 5);

            //act
            dateRange.ValidateDates(date1, date2);
        }

        [TestMethod]
        public void EqualDatesGetDatesRangeTest()
        {
            // arrange
            DateRange dateRange = new DateRange();
            var date1 = new DateTime(2018, 12, 31);
            var date2 = new DateTime(2018, 12, 31);

            //act
            string dateRangeStr = dateRange.GetDateRangeString(date1, date2);
            Assert.AreEqual(dateRangeStr, "31.12.2018");
        }

        [TestMethod]
        public void DifferentYearsGetDatesRangeTest()
        {
            // arrange
            DateRange dateRange = new DateRange();
            var date1 = new DateTime(2017, 6, 20);
            var date2 = new DateTime(2018, 6, 20);

            //act
            string dateRangeStr = dateRange.GetDateRangeString(date1, date2);
            Assert.AreEqual(dateRangeStr, "20.06.2017 - 20.06.2018");
        }

        [TestMethod]
        public void DifferentMounthsGetDatesRangeTest()
        {
            // arrange
            DateRange dateRange = new DateRange();
            var date1 = new DateTime(45, 5, 5);
            var date2 = new DateTime(45, 6, 5);

            //act
            string dateRangeStr = dateRange.GetDateRangeString(date1, date2);
            Assert.AreEqual(dateRangeStr, "05.05 - 05.06.0045");
        }

        [TestMethod]
        public void DifferentDaysGetDatesRangeTest()
        {
            // arrange
            DateRange dateRange = new DateRange();
            var date1 = new DateTime(557, 10, 5);
            var date2 = new DateTime(557, 10, 17);

            //act
            string dateRangeStr = dateRange.GetDateRangeString(date1, date2);
            Assert.AreEqual(dateRangeStr, "05 - 17.10.0557");
        }
    }
}
