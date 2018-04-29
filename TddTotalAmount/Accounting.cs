using System;
using System.Linq;

namespace TddTotalAmount
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

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

            var effectiveEndDate = EndDate > period.EndDate ? period.EndDate: EndDate;

            var effectiveStartDate = StartDate < period.StartDate ? period.StartDate : StartDate;
            return (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
        }
    }

    public class Accounting
    {
        private IRepository<Budget> _repo;

        public Accounting(IRepository<Budget> repo)
        {
            this._repo = repo;
        }

        public decimal TotalAmount(DateTime startDate, DateTime endDate)
        {
            var budgets = _repo.GetAll();
            if (budgets.Any())
            {
                return new Period(startDate, endDate).OverlappingDays(new Period(budgets[0].FirstDay, budgets[0].LastDay));
            }
            return 0;
        }
    }
}