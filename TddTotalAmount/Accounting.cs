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
            if (budgets.Any())
            {
                var budget = budgets[0];
                var dailyAmount = budget.DailyAmount();
                var days = period.OverlappingDays(new Period(budget.FirstDay, budget.LastDay));
                return days * dailyAmount;
            }
            return 0;
        }
    }
}