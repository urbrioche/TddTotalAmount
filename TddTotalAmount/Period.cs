using System;

namespace TddTotalAmount
{
    public class Period
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public int EffectiveDays(Period period)
        {
            if (HasNoOverlapping(period))
            {
                return 0;
            }

            return (EffectiveEndDate(period).AddDays(1) - EffectiveStartDate(period)).Days;
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