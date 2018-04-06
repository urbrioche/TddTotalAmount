﻿using System;

namespace TddTotalAmount
{
    //note: use transform parameter to extract period class
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public int EffectiveDays(Budget budget)
        {
            if (StartDate > budget.LastDay)
            {
                return 0;
            }
            if (EndDate < budget.FirstDay)
            {
                return 0;
            }


            var effectiveEndDate = EndDate > budget.LastDay ? budget.LastDay : EndDate;
            var effectiveStartDate = StartDate < budget.FirstDay ? budget.FirstDay : StartDate;
            return (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
        }
    }
}