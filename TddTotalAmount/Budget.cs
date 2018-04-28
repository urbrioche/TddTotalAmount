using System;

namespace TddTotalAmount
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        private DateTime FirstDay
        {
            get { return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null); }
        }

        private DateTime LastDay
        {
            get { return DateTime.ParseExact(YearMonth + DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month), "yyyyMMdd", null); }
        }

        private int TotalDays
        {
            get { return (LastDay.AddDays(1) - FirstDay).Days; }
        }

        private int DailyAmount()
        {
            return Amount / TotalDays;
        }

        public int EffectiveAmount(Period period)
        {
            return period.OverlappingDays(new Period(FirstDay, LastDay)) * DailyAmount();
        }
    }
}