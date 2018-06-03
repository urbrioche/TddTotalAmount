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

            return (EffectiveEndDate(period).AddDays(1) - EffectiveStartDate(period)).Days;
        }

        private bool HasNoOverlapping(Period period)
        {
            return EndDate < period.StartDate || StartDate > period.EndDate;
        }

        private DateTime EffectiveStartDate(Period period)
        {
            return StartDate < period.StartDate ? period.StartDate : StartDate;
        }

        private DateTime EffectiveEndDate(Period period)
        {
            return EndDate > period.EndDate ? period.EndDate : EndDate;
        }
    }
}