using UnitTest.Templates.SupportUnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Smocks;

namespace UnitTest.Templates.Basic
{
    [TestClass]
    public class _06_StaticClass_Test
    {
        [TestMethod]
        public void Should_Mock_Function_With_Return_Value()
        {
            //Arrange
            var mock = new Mock<ICallStatic>();

            //Smock.Run(context =>
            //{
            //    context.Setup(() => StaticClass.Add(1,2)).Returns(3);
            //});

            mock.Setup(x => x.Add(1, 2)).Returns(3);
            var result = new CallStatic(mock.Object).Add(1, 2);

            Assert.AreEqual(result, 3);
        }
    }
}
