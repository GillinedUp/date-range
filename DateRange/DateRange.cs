using System;
using System.Text;
using System.Globalization;

namespace DateRangeNamespace
{
    public class DateRange
    {
        readonly string format = "dd.MM.yyyy";

        public void ValidateDates(DateTime date1, DateTime date2)
        {
            if (DateTime.Compare(date1, date2) > 0)
                throw new ArgumentException("The first date is not earlier than the second.");
        }

        public DateTime[] ParseDates(string dateString1, string dateString2)
        {
            var provider = CultureInfo.InvariantCulture;
            var date1 = DateTime.ParseExact(dateString1, format, provider);
            var date2 = DateTime.ParseExact(dateString2, format, provider);
            DateTime[] dates = { date1, date2 };
            return dates;
        }

        public string GetDateRangeString(DateTime date1, DateTime date2)
        {
            StringBuilder dateStringBuilder = new StringBuilder();
            if (date1.Year != date2.Year)
                dateStringBuilder.Append(date1.ToString(format));
            else if (date1.Month != date2.Month)
                dateStringBuilder.Append(String.Format("{0:dd}.{0:MM}", date1));
            else if (date1.Day != date2.Day)
                dateStringBuilder.Append(String.Format("{0:dd}", date1));
            if (DateTime.Compare(date1, date2) < 0)
                dateStringBuilder.Append(" - ");
            dateStringBuilder.Append(date2.ToString(format));
            return dateStringBuilder.ToString();
        }

    }
}
