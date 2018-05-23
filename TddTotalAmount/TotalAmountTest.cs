using System;
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
            var accounting = new Accounting(repository);
            var totalAmount = accounting.TotalAmount(new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
            Assert.AreEqual(totalAmount, 0);
        }
    }
}
