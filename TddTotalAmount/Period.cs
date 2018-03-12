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
            var days = (EndDate.AddDays(1) - StartDate).Days;
            return days;
        }
    }
}