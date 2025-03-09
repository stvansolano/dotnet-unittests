using Moq;
using Xunit;

namespace UnitTests
{
    // dotnet test --filter FullyQualifiedName~UnitTests.HelloWorldTests
    // From VSCode: Enable terminal.integrated.shellIntegration.enabled' setting to use the integrated terminal
    public class HelloWorldTests
    {
        [Fact]
        public void TestMethod()
        {
            // Arrange
            var mock = new Mock<IMyInterface>();
            mock.Setup(m => m.MyMethod()).Returns("Hello, World!");

            // Act
            var result = mock.Object.MyMethod();

            // Assert
            Assert.Equal("Hello, World!", result);
            mock.Verify(m => m.MyMethod(), Times.Once());
        }

        [Fact]
        public void TestMethod_ReturnsDifferentValue()
        {
            // Arrange
            var mock = new Mock<IMyInterface>();
            mock.Setup(m => m.MyMethod()).Returns("Goodbye, World!");

            // Act
            var result = mock.Object.MyMethod();

            // Assert
            Assert.Equal("Goodbye, World!", result);
            mock.Verify(m => m.MyMethod(), Times.Once());
        }

        [Fact]
        public void TestMethod_CallsMethodTwice()
        {
            // Arrange
            var mock = new Mock<IMyInterface>();
            mock.Setup(m => m.MyMethod()).Returns("Hello, World!");

            // Act
            var result1 = mock.Object.MyMethod();
            var result2 = mock.Object.MyMethod();

            // Assert
            Assert.Equal("Hello, World!", result1);
            Assert.Equal("Hello, World!", result2);
            mock.Verify(m => m.MyMethod(), Times.Exactly(2));
        }
    }

    public interface IMyInterface
    {
        string MyMethod();
    }
}
