using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

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
            var totalAmount = accounting.TotalAmount();
            Assert.AreEqual(0, totalAmount);
        }
    }
}