using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Templates.SupportUnitTest;

namespace UnitTest.Templates.Advanced
{
    [TestClass]
    public class CallBacks
    {
        [TestMethod]
        public void Should_Call_Back_After_Executing_Mocked_Function()
        {
            //Arrange
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };

            var mockRepo = new Mock<IRepo>();
            mockRepo.Setup(x => x.Find(It.IsAny<int>()))
                .Callback(() => Console.WriteLine("Before Execution"))
                .Returns(customer)
                .Callback(() => Console.WriteLine("After Execution"));

            TestController controller = new TestController(mockRepo.Object);

            var returnedCustomer = controller.GetCustomer(id);

            Assert.AreEqual(returnedCustomer, customer);
            Assert.AreEqual(returnedCustomer.Id, customer.Id);

        }
    }
}