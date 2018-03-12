using System;

namespace TddTotalAmount
{
    internal class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException();
            
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public int OverlappingDays(Period period)
        {
            if (EndDate < period.StartDate)
            {
                return 0;
            }

            if (StartDate > period.EndDate)
            {
                return 0;
            }

            //var effectiveEndDate = EndDate;
            //var effectiveStartDate = StartDate < budget.FirstDay ? budget.FirstDay : StartDate;

            var effectiveEndDate = EndDate;
            var effectiveStartDate = StartDate;
            if (StartDate < period.StartDate)
            {
                effectiveStartDate = period.StartDate;
            }

            if (EndDate > period.EndDate)
            {
                effectiveEndDate = period.EndDate;
            }

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }
    }
}