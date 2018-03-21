using System;

namespace TddTotalAmount
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }
        public DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

            }
        }

        public DateTime LastDay
        {
            get
            {
                return DateTime.ParseExact(YearMonth + TotalDays, "yyyyMMdd", null);
            }
        }

        public int TotalDays
        {
            get
            {
                return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            }
        }

        public int DailyAmount()
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