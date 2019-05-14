using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTest.Templates.SupportUnitTest;

namespace UnitTest.Templates.Advanced
{
    [TestClass]
    public class RollingMocks
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow(0, 12, "Bob")]
        [DataRow(1, 17, "Sue")]
        [DataRow(2, 100065, "Tony")]
        public void Should_Enable_Rolling_Mocks(int index, int id, string name)
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 12, Name = "Bob"},
                new Customer {Id = 17, Name = "Sue"},
                new Customer {Id = 100065, Name = "Tony"},
            };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(It.IsInRange(0, 2, Range.Inclusive)))
                .Returns((int x) => customers[x]);

            var controller = new TestController(mock.Object);
            var cust = controller.GetCustomer(index);
            Assert.AreEqual(id,cust.Id);
            Assert.AreEqual(name,cust.Name);
        }
    }
}