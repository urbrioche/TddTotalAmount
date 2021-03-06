﻿using System;

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
            get
            {
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return DateTime.ParseExact(YearMonth + daysInMonth, "yyyyMMdd", null);
            }
        }

        public int DailyAmount()
        {
            return Amount / (LastDay.AddDays(1) - FirstDay).Days;
        }

        public decimal EffectiveAmount(Period period)
        {
            var dailyAmount = DailyAmount();

            var overlappingDays = period.OverlappingDays(new Period(FirstDay, LastDay));
            return overlappingDays * dailyAmount;
        }
    }
}