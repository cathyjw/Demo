using Moq;
using Moq.Protected;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Templates.Advanced
{
    [TestClass]
    public class MockingProtectedMethod
    {
        [TestMethod]
        public void Should_Call_Protected_Method()
        {
            //Arrange
            var mockProtected = new Mock<MyClassWithProtectedMethod>();

            // you should call this function in any case. Without calling next Verify will not give you any benefit at all
            mockProtected.Protected()
                .Setup<string>("MyProtectedMethod")
                .Returns("MyProtectedMethod is called")
                .Verifiable(); 

            //Act
            mockProtected.Object.CallingFunc();

            //Assert
            mockProtected.Verify();
        }
    }

    public class MyClassWithProtectedMethod
    {
        public string CallingFunc()
        {
            return this.MyProtectedMethod();
        }
        protected virtual string MyProtectedMethod()
        {
            var returned = "MyProtectedMethod is called";
            return returned;
        }
    }
}
