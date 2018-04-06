using System;
using System.Collections.Generic;

namespace TddTotalAmount
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }

    public class Accounting
    {
        private readonly IRepository<Budget> _repository;

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