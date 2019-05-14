using System;
using Moq;
using UnitTest.Templates.SupportUnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Templates.Basics
{
    [TestClass]
    public class Exceptions
    {
        [TestMethod]
        public void Should_Mock_General_Exceptions()
        {
            //Arrage
            var id = 12;
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Throws<ArgumentException>();
            
            //Act
            var controller = new TestController(mock.Object);

            //Assert
            Assert.ThrowsException<ArgumentException>(() => controller.GetCustomer(12));
        }
        [TestMethod]
        public void Should_Mock_Specific_Exceptions()
        {
            //Arrage
            var id = 12;
            var mock = new Mock<IRepo>();
            var param = "Id";
            var message = "Missing parameter";
            mock.Setup(x => x.Find(id)).Throws(new ArgumentException(message,param));

            //Act
            var controller = new TestController(mock.Object);
            //if now exception is thrown out from GetCustomer, following test will be failed.
            var ex = Assert.ThrowsException<ArgumentException>(() => controller.GetCustomer(id));

            //Assert
            Assert.AreEqual($"{message}\r\nParameter name: {param}",ex.Message);
            Assert.AreEqual(param,ex.ParamName);
        }
    }

}
