using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

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
            TotalAmountShoudBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void one_effective_day_period_insdie_budget_month()
        {
            GivenBudgets(new Budget() { YearMonth = "201804", Amount = 30 });
            TotalAmountShoudBe(1, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        private void TotalAmountShoudBe(int expected, DateTime startDate, DateTime endDate)
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