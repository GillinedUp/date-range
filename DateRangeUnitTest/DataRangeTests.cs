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
    }
}
