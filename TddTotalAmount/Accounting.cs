using System;
using System.Collections.Generic;
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
            return _repository.GetAll().Sum(b => b.EffectiveAmount(new Period(startDate, endDate)));
        }
    }
}