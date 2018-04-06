using System;

namespace TddTotalAmount
{
    //note: use transform parameter to extract period class
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException();
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public int OverlappingDays(Period period)
        {
            if (StartDate > period.EndDate)
            {
                return 0;
            }

            if (EndDate < period.StartDate)
            {
                return 0;
            }


            var effectiveEndDate = EndDate > period.EndDate ? period.EndDate : EndDate;
            var effectiveStartDate = StartDate < period.StartDate ? period.StartDate : StartDate;
            return (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
        }
    }
}