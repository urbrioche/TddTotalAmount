using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void No_Effective_Day_Period_Before_Budget_Month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2018, 3, 31), new DateTime(2018, 3, 31));
        }

        [TestMethod]
        public void No_Effective_Day_Period_After_Budget_Month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2018, 5, 1), new DateTime(2018, 5, 1));
        }

        [TestMethod]
        public void One_Effective_Day_Period_Overlap_Budget_Month_FirstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 3, 31), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void One_Effective_Day_Period_Overlap_Budget_Month_LastDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 4, 30), new DateTime(2018, 5, 1));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Invalid_Period()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 6, 30), new DateTime(2018, 5, 1));
        }

        [TestMethod]
        public void Daily_Amount()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 300 });
            TotalAmountShouldBe(20, new DateTime(2018, 4, 1), new DateTime(2018, 4, 2));
        }

        [TestMethod]
        public void Multiple_Budgets()
        {
            GivenBudgets(
                new Budget { YearMonth = "201804", Amount = 300 },
                new Budget { YearMonth = "201806", Amount = 30 });
            TotalAmountShouldBe(103, new DateTime(2018, 4, 21), new DateTime(2018, 6, 3));
        }

        private void TotalAmountShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(startDate, endDate));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _repository.GetAll().Returns(budgets.ToList());
        }
    }
}
