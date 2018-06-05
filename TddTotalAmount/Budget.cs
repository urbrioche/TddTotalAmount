﻿using System;

namespace TddTotalAmount
{
    public class Budget
    {
        public int Amount { get; set; }
        public DateTime FirstDay
        {
            get { return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null); }
        }

        public DateTime LastDay
        {
            get { return DateTime.ParseExact(YearMonth + TotalDays, "yyyyMMdd", null); }
        }

        public string YearMonth { get; set; }
        private int TotalDays
        {
            get { return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month); }
        }

        public decimal EffectiveAmount(Period period)
        {
            return period.OverlappingDays(new Period(FirstDay, LastDay)) * DailyAmount();
        }

        private int DailyAmount()
        {
            return Amount / TotalDays;
        }
    }
}