using System;
using System.Linq;

namespace TddTotalAmount
{
    public class Accounting
    {
        private readonly IRepository<Budget> _repository;

        public Accounting(IRepository<Budget> repository)
        {
            _repository = repository;
        }

        public decimal TotalAmount(DateTime startDate, DateTime endDate)
        {
            var period = new Period(startDate, endDate);
            var budgets = _repository.GetAll();
            var totalAmount = 0m;
            foreach (var budget in budgets)
            {
                totalAmount += budget.EffectiveAmount(period);
            }

            return totalAmount;
            if (budgets.Any())
            {
                var budget = budgets[0];
                return budget.EffectiveAmount(period);
            }

            return 0;
        }
    }
}