using System;
using System.Linq;

namespace TddTotalAmount
{
    public class Accounting
    {
        private IRepository<Budget> _repository;

        public Accounting(IRepository<Budget> repository)
        {
            this._repository = repository;
        }

        public decimal TotalAmount(DateTime startDate, DateTime endDate)
        {
            var budgets = _repository.GetAll();
            if (budgets.Any())
            {
                var budget = budgets[0];
                var period = new Period(startDate, endDate);
                var days = period.EffectiveDays(budget);

                return days;
            }
            return 0;
        }
    }
}