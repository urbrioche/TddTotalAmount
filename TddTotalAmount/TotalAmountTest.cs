using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TddTotalAmount
{
    [TestClass]
    public class TotalAmountTest
    {
        [TestMethod]
        public void no_budget()
        {
            var repository = Substitute.For<IRepository<Budget>>();
            repository.GetAll().Returns(new List<Budget>());
            var accounting = new Accounting(repository);
            var totalAmount = accounting.TotalAmount(new DateTime(2018, 4, 1), new DateTime(2018, 4, 4));
            Assert.AreEqual(0, totalAmount);
        }
    }
}
