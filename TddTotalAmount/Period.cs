using System;

namespace TddTotalAmount
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get;}

        public int EffectiveDays()
        {
            return (StartDate.AddDays(1) - StartDate).Days;
        }
    }
}