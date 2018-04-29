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
                return new Period(startDate, endDate).OverlappingDays(new Period(budgets[0].FirstDay, budgets[0].LastDay));
            }
            return 0;
        }
    }
}