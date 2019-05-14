using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Templates.SupportUnitTest;
using System.Collections.Generic;

namespace UnitTest.Templates.Basics
{
    [TestClass]
    public class FirstExample
    {
        //private int id { get; set; }
        //private string name { get; set; }
        [TestInitialize()]
        public void SetUp()
        {
            //id = 12;
            //name = "Jie Wang";
        }

        [TestCleanup]
        public void TearDown()
        {
        }

        [TestMethod]
        public void Should_Mock_Function_With_Return_Value()
        {
            //Arrange
            //List<Customer> custList = new List<Customer>();
            var id = 12;
            var name = "John Smith";
            var customer = new Customer {Id = id, Name = name};
            //custList.Add(customer);
            var mock = new Mock<IRepo>();

            //var mock = new IUserSerive();
            //mock.Setup(x=>x.Login).Rreturn($data)
            mock.Setup(x=>x.Find(id)).Returns(customer);

            var controller = new TestController(mock.Object);
            //Act
            var actual = controller.GetCustomer(id);
            //Assert
            //Assert.Fail();
            Assert.AreSame(customer, actual);
            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
        }

        [TestMethod]
        public void Should_Mock_Repetitive_Function_Calls_With_Return_Values()
        {
            var id1 = 12;
            var name1 = "John Smith";
            var customer1 = new Customer {Id = id1, Name = name1};
            var id2 = 1;
            var name2 = "Joan May";
            var customer2 = new Customer {Id = id2, Name = name2};
            var mock = new Mock<IRepo>();
            mock.SetupSequence(x => x.Find(It.IsAny<int>()))
                .Returns(customer1)
                .Returns(customer2);

            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id1);
            Assert.AreSame(customer1,actual);
            Assert.AreEqual(id1,actual.Id);
            Assert.AreEqual(name1,actual.Name);
            actual = controller.GetCustomer(id2);
            Assert.AreSame(customer2,actual);
            Assert.AreEqual(id2,actual.Id);
            Assert.AreEqual(name2,actual.Name);
        }

        [TestMethod]
        public void Should_Mock_Function_With_Void_Return()
        {
            var id = 12;
            var name = "John Smith";
            var customer = new Customer {Id = id, Name = name};
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.AddRecord(customer));

            var controller = new TestController(mock.Object);
            controller.SaveCustomer(customer);
        }
    }
}
