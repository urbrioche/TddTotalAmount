﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public void no_budgets()
        {
            GivenBudgets();

            TotalAmountShouldBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        private void TotalAmountShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            var totalAmount = _accounting.TotalAmount(startDate, endDate);

            Assert.AreEqual(expected, totalAmount);
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _repository.GetAll().Returns(budgets.ToList());
        }
    }
}
