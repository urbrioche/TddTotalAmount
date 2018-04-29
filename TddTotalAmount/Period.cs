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

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public int OverlappingDays(Period period)
        {
            if (HasNoOverlappingDays(period))
            {
                return 0;
            }

            return TotalDays(EffectiveEndDate(period), EffectiveStartDate(period));
        }

        private bool HasNoOverlappingDays(Period period)
        {
            return EndDate < period.StartDate || StartDate > period.EndDate;
        }

        private static int TotalDays(DateTime effectiveEndDate, DateTime effectiveStartDate)
        {
            return (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
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