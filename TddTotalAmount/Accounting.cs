using System;

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
            return 0;
        }
    }
}