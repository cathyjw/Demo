using Moq;
using UnitTest.Templates.SupportUnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Templates.Basics
{
    [TestClass]
    public class Arguments
    {
        [TestMethod]
        public void Should_Return_Null_When_No_Argument_Match()
        {
            //Arrage
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Returns(customer);

            //Act
            var controller = new TestController(mock.Object);

            //Assert
            var actual = controller.GetCustomer(id+1);
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void Should_Return_When_Arguments_Match()
        {
            //Arrage
            var id = 12;
            var name = "John Smith";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(It.IsAny<int>())).Returns(customer);
            //mock.Setup(x => x.Find(It.Is<int>(i => i > 0))).Returns(customer);
            //mock.Setup(x => x.Find(It.IsInRange(0,100,Range.Inclusive))).Returns(customer);

            //Act
            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id);
            //Assert
            Assert.AreSame(customer, actual);
            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
        }
    }
}
