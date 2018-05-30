﻿using System;

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
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return DateTime.ParseExact(YearMonth + daysInMonth, "yyyyMMdd", null);
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
            var dailyAmount = Amount / TotalDays;
            return dailyAmount;
        }

        public decimal EffectiveAmount(Period period)
        {
            var dailyAmount = DailyAmount();
            var days = period.OverlappingDays(new Period(FirstDay, LastDay));
            return days * dailyAmount;
        }
    }
}