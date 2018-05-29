using System;

namespace TddTotalAmount
{
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

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public int OverlappingDays(Period period)
        {
            if (HasNoOverlapping(period))
            {
                return 0;
            }

            return (EffectiveEndDate(period).AddDays(1) - EffectiveStartDate(period)).Days;
        }

        private bool HasNoOverlapping(Period period)
        {
            return EndDate < period.StartDate || StartDate > period.EndDate;
        }

        private DateTime EffectiveStartDate(Period period)
        {
            var effectiveStartDate = StartDate < period.StartDate ? period.StartDate : StartDate;
            return effectiveStartDate;
        }

        private DateTime EffectiveEndDate(Period period)
        {
            var effectiveEndDate = EndDate > period.EndDate ? period.EndDate : EndDate;
            return effectiveEndDate;
        }
    }
}