using Moq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Templates.Advanced
{
    [TestClass]
    public class MockingAbstractClass
    {
        [TestMethod]
        public void Should_Replace_Abstract_Implementation()
        {
            var mock = new Mock<MyConverter>();
            var expected = "10";
            mock.Setup(m => m.ConvertBack(10)).Returns(expected);
            var actual = mock.Object.ConvertBack(10);
            Assert.AreEqual(expected, actual);
        }
    }
    public abstract class MyConverter : IValueConverter
    {
        public abstract Object Convert(int input);

        public virtual string ConvertBack(int input)
        {
            return input.ToString();
        }
    }
    public interface IValueConverter
    {
        Object Convert(int input);
        string ConvertBack(int input);
    }
}
