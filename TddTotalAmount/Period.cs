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
            if (HasNoOverlapping(period))
            {
                return 0;
            }

            return TotalDays(EffectiveEndDate(period), EffectiveStartDate(period));
        }

        private static int TotalDays(DateTime endDate, DateTime startDate)
        {
            return (endDate.AddDays(1) - startDate).Days;
        }

        private DateTime EffectiveStartDate(Period period)
        {
            return StartDate < period.StartDate ? period.StartDate : StartDate;
        }

        private DateTime EffectiveEndDate(Period period)
        {
            return EndDate > period.EndDate ? period.EndDate : EndDate;
        }

        private bool HasNoOverlapping(Period period)
        {
            return EndDate < period.StartDate || StartDate > period.EndDate;
        }
    }
}