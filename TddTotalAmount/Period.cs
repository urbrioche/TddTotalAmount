using System;

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
            if (StartDate > budget.LastDay)
            {
                return 0;
            }
            if (EndDate < budget.FirstDay)
            {
                return 0;
            }
            return (StartDate.AddDays(1) - StartDate).Days;
        }
    }
}