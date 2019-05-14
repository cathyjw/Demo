using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Templates.SupportUnitTest;

namespace UnitTest.Templates.Advanced
{
    [TestClass]
    public class CustomizeMockBehavior
    {

        [TestMethod]
        public void Should_Not_Error_When_Using_Loose_Mocks_And_Not_Setting_Up_Method()
        {
            var mockRepo = new Mock<IRepo>(MockBehavior.Loose);
            var controller = new TestController(mockRepo.Object);
            var customer = controller.GetCustomer(12);
            Assert.IsNull(customer);

        }
        [TestMethod]
        public void Should_Error_When_Using_Strict_Mocks_And_Not_Setting_Up_Method()
        {
            //Arrage
            var mockRepo = new Mock<IRepo>(MockBehavior.Strict);
            var controller = new TestController(mockRepo.Object);
            var id = 12;
            mockRepo.Setup(x => x.Find(12)).Returns(new Customer());
            
            //Act
            var ex = Assert.ThrowsException<MockException>(()=>controller.GetCustomer(id));

            //Assert
            Assert.AreEqual("IRepo.AddRecord(" + new Customer().GetType().Name + ") invocation failed with mock behavior Strict.\nAll invocations on the mock must have a corresponding setup.", ex.Message);

        }
    }
}