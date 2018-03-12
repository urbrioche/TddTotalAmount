using System;

namespace TddTotalAmount
{
    internal class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public int EffectiveDays(Budget budget)
        {
            if (EndDate < budget.FirstDay)
            {
                return 0;
            }

            if (StartDate > budget.LastDay)
            {
                return 0;
            }

            //var effectiveEndDate = EndDate;
            //var effectiveStartDate = StartDate < budget.FirstDay ? budget.FirstDay : StartDate;

            var effectiveEndDate = EndDate;
            var effectiveStartDate = StartDate;
            if (StartDate < budget.FirstDay)
            {
                effectiveStartDate = budget.FirstDay;
            }

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }
    }
}