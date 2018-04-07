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

            var totalAmount = 0m;
            foreach (var budget in budgets)
            {
                totalAmount += budget.EffectiveAmount(period);
            }

            return totalAmount;          
        }
    }
}