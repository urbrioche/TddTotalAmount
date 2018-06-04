using System;

namespace TddTotalAmount
{
    public class Period
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Period(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException();
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        public int OverlappingDays(Period period)
        {
            if (EndDate < period.StartDate || StartDate > period.EndDate)
            {
                return 0;
            }

            var effectiveEndDate = EndDate > period.EndDate ? period.EndDate : EndDate;
            var effectiveStartDate = StartDate < period.StartDate ? period.StartDate : StartDate;

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }
    }
}