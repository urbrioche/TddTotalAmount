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

        public DateTime EndDate { get; }
        public DateTime StartDate { get; }

        public int EffectiveDays(Budget budget)
        {
            if (EndDate < budget.FirstDay)
            {
                return 0;
            }

            var days = (EndDate.AddDays(1) - StartDate).Days;
            return days;
        }
    }
}