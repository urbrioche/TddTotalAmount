using System;

namespace TddTotalAmount
{
    public class Budget
    {
        public int Amount { get; set; }
        public string YearMonth { get; set; }

        public DateTime FirstDay
        {
            get { return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null); }
        }

        public DateTime LastDay
        {
            get { return DateTime.ParseExact(YearMonth + TotalDays, "yyyyMMdd", null); }
        }

        public int TotalDays
        {
            get
            {
                var totalDays = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return totalDays;
            }
        }

        public int DailyAmount()
        {
            return Amount / TotalDays;
        }

        public decimal EffectiveAmount(Period period)
        {
            return period.OverlappingDays(new Period(FirstDay, LastDay)) * DailyAmount();
        }
    }
}