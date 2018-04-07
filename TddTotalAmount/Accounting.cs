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
            var budgets = _repository.GetAll();
            var period = new Period(startDate, endDate);

            if (budgets.Any())
            {               
                var budget = budgets[0];
                return period.OverlappingDays(new Period(budget.FirstDay, budget.LastDay)) * budget.DailyAmount();
            }
            return 0;
        }
    }
}