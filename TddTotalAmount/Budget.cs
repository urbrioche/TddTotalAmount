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
            get { return DateTime.ParseExact(YearMonth + TotalDays(), "yyyyMMdd", null); }
        }

        private int TotalDays()
        {
            return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
        }
    }
}