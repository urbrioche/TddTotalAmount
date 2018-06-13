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

        public int EffectiveDays(Budget budget, Period period)
        {
            if (HasNoOverlapping(period))
            {
                return 0;
            }

            var days = (EffectiveEndDate(period).AddDays(1) - EffectiveStartDate(period)).Days;
            return days;
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