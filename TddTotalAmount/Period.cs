using System;

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
            if (EndDate < budget.StartDate)
            {
                return 0;
            }
            return (EndDate.AddDays(1) - StartDate).Days;
        }
    }
}