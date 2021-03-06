﻿using System;
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
            return budgets.Sum(b => b.EffectiveAmount(period));
        }
    }
}