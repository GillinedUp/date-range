using System;

namespace DateRangeNamespace
{
    class Program
    {
        static void ExitProgram(string msg)
        {
            if (!(msg == ""))
            {
                Console.WriteLine(msg);
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            if (args.Length > 2 || args.Length < 2)
            {
                ExitProgram("Wrong number of arguments.");
            }
            string firstDateString = args[0];
            string secondDateString = args[1];
            DateRange dateRange = new DateRange();
            try
            {
                var dates = dateRange.ParseDates(firstDateString, secondDateString);
                var firstDate = dates[0];
                var secondDate = dates[1];
                dateRange.ValidateDates(firstDate, secondDate);
                string dateRangeString = dateRange.GetDateRangeString(firstDate, secondDate);
                Console.WriteLine(dateRangeString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ExitProgram("");
            }
        }
    }
}
