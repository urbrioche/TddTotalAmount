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
                var days = period.Effective();
                return days;
            }
            return 0;
        }
    }
}