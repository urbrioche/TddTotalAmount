﻿using System;
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
                var days = (endDate.AddDays(1) - startDate).Days;

                return days;
            }
            return 0;
        }
    }
}