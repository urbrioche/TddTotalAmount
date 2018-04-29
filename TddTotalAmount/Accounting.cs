using System;
using System.Linq;

namespace TddTotalAmount
{
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
                var budget = budgets[0];
                var totalDays = (budget.LastDay.AddDays(1) - budget.FirstDay).Days;
                var dailyAmount = budget.Amount / totalDays;
                var overlappingDays = new Period(startDate, endDate).OverlappingDays(new Period(budget.FirstDay, budget.LastDay));

                return dailyAmount * overlappingDays;
            }
            return 0;
        }
    }
}