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

        public DateTime EndDate { get; }
        public DateTime StartDate { get; }

        public int OverLappingDays(Period period)
        {
            if (HasNoOverlapping(period))
            {
                return 0;
            }

            return (EffectiveEndDate(period).AddDays(1) - EffectiveStartDate(period)).Days;
        }

        private bool HasNoOverlapping(Period period)
        {
            return StartDate > period.EndDate || EndDate < period.StartDate;
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