using System;

namespace TddTotalAmount
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime StartDate => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public DateTime EndDate
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(StartDate.Year, StartDate.Month);
                return DateTime.ParseExact(YearMonth + daysInMonth, "yyyyMMdd", null);
            }
        }
    }
}