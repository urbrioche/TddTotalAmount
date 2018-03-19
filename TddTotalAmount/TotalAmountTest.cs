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
        [TestMethod]
        public void No_Budgets()
        {
            var repository = Substitute.For<IRepository<Budget>>();
            repository.GetAll().Returns(new List<Budget>());

            var accounting = new Accounting(repository);
            var totalAmount = accounting.TotalAmount(new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
            Assert.AreEqual(0, totalAmount);
        }
    }
}
