using System;

namespace TddTotalAmount
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        private DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        private DateTime LastDay => DateTime.ParseExact(YearMonth + TotalDays, "yyyyMMdd", null);

        private int TotalDays => DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);

        private int DailyAmount()
        {
            return Amount / TotalDays;
        }

        public decimal EffectiveAmount(Period period)
        {
            var dailyAmount = DailyAmount();
            var overlappingDays = period.OverlappingDays(new Period(FirstDay, LastDay));
            return dailyAmount * overlappingDays;
        }
    }
}