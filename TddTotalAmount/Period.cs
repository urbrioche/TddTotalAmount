using System;

namespace TddTotalAmount
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public int EffectiveDays()
        {
            return (EndDate.AddDays(1) - StartDate).Days;
        }
    }
}