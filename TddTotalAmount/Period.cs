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

        public int OverLappingDays(Period period)
        {
            if (StartDate > period.EndDate)
            {
                return 0;
            }
            if (EndDate < period.StartDate)
            {
                return 0;
            }
            return (StartDate.AddDays(1) - StartDate).Days;
        }
    }
}