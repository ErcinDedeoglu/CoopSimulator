using System;

namespace CoopSimulator.Helper
{
    public class DateHelper
    {
        public static int MonthDifferenceBetweenTwoDate(DateTime startDate, DateTime endDate)
        {
            return (startDate.Year - endDate.Year) * 12 + startDate.Month - endDate.Month;
        }

        public static int WeekDifferenceBetweenTwoDate(DateTime startDate, DateTime endDate)
        {
            return (int) Math.Floor((endDate - startDate).TotalDays / 7);
        }

        public static int YearDifferenceBetweenTwoDate(DateTime startDate, DateTime endDate)
        {
            int years = endDate.Year - startDate.Year;

            if (startDate.Month == endDate.Month && endDate.Day < startDate.Day || endDate.Month < startDate.Month)
            {
                years--;
            }

            return years;
        }
    }
}