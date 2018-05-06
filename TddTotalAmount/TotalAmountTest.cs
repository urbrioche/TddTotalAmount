﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TddTotalAmount
{
    [TestClass]
    public class TotalAmountTest
    {
        [TestMethod]
        public void no_budgets()
        {
            var repository = Substitute.For<IRepository<Budget>>();
            repository.GetAll().Returns(new List<Budget>());

            var accounting = new Accounting(repository);
            var totalAmount = accounting.TotalAmount(new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
            Assert.AreEqual(0, totalAmount);
        }
    }
}
