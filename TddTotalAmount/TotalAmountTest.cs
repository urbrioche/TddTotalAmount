using System;
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
        public void No_Budgets()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void One_Effective_Day_Period_Inside_Budget_Month()
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
