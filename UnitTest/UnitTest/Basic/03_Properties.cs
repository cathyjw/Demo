using System;
using UnitTest.Templates.SupportUnitTest;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Templates.Basics
{
    [TestClass]
    public class Properties
    {
        [TestMethod]
        public void Should_Mock_Properties_Specifically()
        {
            //Arrange
            var mock = new Mock<IRepo>();
            var tenantId = 5;
            mock.Setup(x => x.TenantId).Returns(tenantId);
            //Act
            var controller = new TestController(mock.Object);
            //Assert
            Assert.AreEqual(tenantId,controller.TenantId());
        }

        [TestMethod]
        public void Should_Stub_Properties()
        {
            var mock = new Mock<IRepo>();
            var tenantId = 5;
            //Setup without a default value
            //mock.SetupProperty(x => x.TenantId);

            //This sets a default value
            mock.SetupProperty(x => x.TenantId,tenantId);

            var controller = new TestController(mock.Object);
            Assert.AreEqual(tenantId,controller.TenantId());

            var newTenantId = 12;
            mock.Object.TenantId = newTenantId;
            Assert.AreEqual(newTenantId, controller.TenantId());
        }

        [TestMethod]
        public void Should_Mock_And_Verify_Setter()
        {
            var mock = new Mock<IRepo>();
            var tenantId = 5;
            Action<IRepo> set = x => x.TenantId = tenantId;
            mock.SetupSet(set);
            var controller = new TestController(mock.Object);
            controller.SetTenantId(tenantId);
            mock.VerifySet(set);
        }

        [TestMethod]
        public void Should_Mock_Nested_Properties()
        {
            //properties need to be virtual if nested
            var mock = new Mock<IOrder>();
            mock.Setup(x => x.CustomerOnOrder.AddressNavigation.Location).Returns("Elm");
            var controller = new OrderController(mock.Object);

            Assert.AreEqual("Elm",controller.GetCustomer().AddressNavigation.Location);
        }

    }
}
