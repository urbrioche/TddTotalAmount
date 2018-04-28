using System;
using System.Linq;

namespace TddTotalAmount
{
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