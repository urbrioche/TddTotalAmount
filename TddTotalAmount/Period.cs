﻿using System;

namespace TddTotalAmount
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public int EffectiveDays(Budget budget)
        {
            if (EndDate < budget.FirstDay || StartDate > budget.LastDay)
            {
                return 0;
            }
            var days = (EndDate.AddDays(1) - StartDate).Days;
            return days;
        }
    }
}