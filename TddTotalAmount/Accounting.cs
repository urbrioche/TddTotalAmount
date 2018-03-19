using System;
using System.Linq;

namespace TddTotalAmount
{
    public class Accounting
    {
        private IRepository<Budget> _repository;

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
                return EffectiveDays(period);
            }

            return 0;
        }

        private static int EffectiveDays(Period period)
        {
            return (period.EndDate.AddDays(1) - period.StartDate).Days;
        }
    }
}