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
                var period = new Period(startDate, endDate);

                return budget.EffectiveAmount(period);
            }
            return 0;
        }
    }
}