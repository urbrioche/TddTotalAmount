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
                return EffectiveDays(startDate, endDate);
            }
            return 0;
        }

        private static int EffectiveDays(DateTime startDate, DateTime endDate)
        {
            return (endDate.AddDays(1) - startDate).Days;
        }
    }
}