using System;
using System.Linq.Expressions;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Templates.SupportUnitTest;

namespace UnitTest.Templates.Basics
{
    [TestClass]
    public class Verification
    {
        [TestMethod]
        public void Should_Verify_Mock_Functions_Executed_Marked_Verifiable()
        {
            //Arrange
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            mock.Setup(call).Returns(customer).Verifiable("Method not called");

            //Act
            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id);

            //Assert
            Assert.AreSame(customer, actual);
            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
            mock.Verify(call);
        }

        [TestMethod]
        public void Should_Verify_Times_Executed()
        {
            //Arrange
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            mock.Setup(call).Returns(customer).Verifiable("Method not called");

            //Act
            var controller = new TestController(mock.Object);
            var actual1 = controller.GetCustomer(id);
            //var actual2 = controller.GetCustomer(id);
            //Expected invocation on the mock once, but was 4 times: x => x.Find

            //Assert
            mock.Verify(call, Times.Once);
            //2 times or never
            //mock.Verify(call, Times.Exactly(2));
            //mock.Verify(call, Times.Never);
        }


        [TestMethod]
        public void Should_Verify_All_Mock_Functions()
        {
            //Arrange
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Returns(customer);

            //Act and Assert
            Assert.ThrowsException<MockException>(() => mock.VerifyAll());
        }

        [TestMethod]
        public void Should_Not_Verify_Mock_Functions_Not_Verifiable()
        {
            //Arrange
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();

            //Act and Assert
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            mock.Setup(call).Returns(customer);
            mock.Verify();
        }

        [TestMethod]
        public void Should_Verify_Mock_Functions_Not_Executed_Marked_Verifiable()
        {
            //Arrange
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            var errorMessage = "Method not called";
            mock.Setup(call).Returns(customer).Verifiable(errorMessage);
            //if x.Find(id) was never called, exception will be throw
            //in this case, exception is thrown since GetCustomer was not called.

            //Act and Assert
            var ex = Assert.ThrowsException<MockException>(()=>mock.Verify(call));
        }


    }
}
