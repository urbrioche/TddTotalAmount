using System;

namespace TddTotalAmount
{
    public class Period
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public decimal EffectiveDays(Budget budget)
        {
            if (EndDate < budget.FirstDay || StartDate > budget.LastDay)
            {
                return 0;
            }
            return (EndDate.AddDays(1) - StartDate).Days;
        }
    }
}