using System;

namespace TddTotalAmount
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

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

            return (EndDate.AddDays(1) - StartDate).Days;
        }
    }
}