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

        public int EffectiveDays(Budget budget)
        {
            if (EndDate < budget.FirstDay)
            {
                return 0;
            }

            if (StartDate > budget.LastDay)
            {
                return 0;
            }

            var effectiveEndDate = EndDate > budget.LastDay ? budget.LastDay: EndDate;

            var effectiveStartDate = StartDate < budget.FirstDay ? budget.FirstDay : StartDate;
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
                return new Period(startDate, endDate).EffectiveDays(budgets[0]);
            }
            return 0;
        }
    }
}