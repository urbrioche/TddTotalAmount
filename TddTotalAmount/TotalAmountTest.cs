﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TddTotalAmount
{
    [TestClass]
    public class TotalAmountTest
    {
        private IRepository<Budget> _repository = Substitute.For<IRepository<Budget>>();
        private Accounting _accounting;

        [TestInitialize]
        public void TestInit()
        {
            _accounting = new Accounting(_repository);
        }

        [TestMethod]
        public void no_budget()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 4, 4));
        }

        [TestMethod]
        public void one_effective_day_period_inside_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void no_effective_day_period_before_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2018, 3, 31), new DateTime(2018, 3, 31));
        }

        [TestMethod]
        public void no_effective_day_period_after_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2018, 5, 1), new DateTime(2018, 5, 1));
        }

        [TestMethod]
        public void one_effective_day_period_overlap_budget_month_FirstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 3, 31), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void one_effective_day_period_overlap_budget_month_LastDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 4, 30), new DateTime(2018, 5, 1));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void invalid_period()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 6, 30), new DateTime(2018, 5, 1));
        }

        [TestMethod]
        public void daily_amount()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 300 });
            TotalAmountShouldBe(20, new DateTime(2018, 4, 1), new DateTime(2018, 4, 2));
        }

        [TestMethod]
        public void multiple_budgets()
        {
            GivenBudgets(
                new Budget { YearMonth = "201804", Amount = 300 },
                new Budget { YearMonth = "201806", Amount = 30 }
            );
            TotalAmountShouldBe(103, new DateTime(2018, 4, 21), new DateTime(2018, 6, 3));
        }

        private void TotalAmountShouldBe(int expected, DateTime start, DateTime end)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(start, end));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _repository.GetAll().Returns(budgets.ToList());
        }
    }
}
