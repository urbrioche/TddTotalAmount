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

            var effectiveEndDate = EndDate > period.EndDate ? period.EndDate : EndDate;
            var effectiveStartDate = StartDate < period.StartDate ? period.StartDate : StartDate;
            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }
    }

    public class Accounting
    {
        private IRepository<Budget> _repo;

        public Accounting(IRepository<Budget> repo)
        {
            _repo = repo;
        }
        public decimal TotalAmount(DateTime startDate, DateTime endDate)
        {
            var budgets = _repo.GetAll();
            if (budgets.Any())
            {
                Budget budget = budgets[0];
                return new Period(startDate, endDate).OverlappingDays(new Period(budget.FirstDay, budget.LastDay));
            }
            return 0;
        }
    }
}