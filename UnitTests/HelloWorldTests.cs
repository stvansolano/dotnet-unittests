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
    }

    public interface IMyInterface
    {
        string MyMethod();
    }
}
