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

        public int EffectiveDays(Budget budget)
        {
            if (HasNoOverlapping(budget))
            {
                return 0;
            }

            return (EffectiveEndDate(budget).AddDays(1) - EffectiveStartDate(budget)).Days;
        }

        private bool HasNoOverlapping(Budget budget)
        {
            return EndDate < budget.FirstDay || StartDate > budget.LastDay;
        }

        private DateTime EffectiveStartDate(Budget budget)
        {
            return StartDate < budget.FirstDay ? budget.FirstDay : StartDate;
        }

        private DateTime EffectiveEndDate(Budget budget)
        {
            return EndDate > budget.LastDay ? budget.LastDay : EndDate;
        }
    }
}