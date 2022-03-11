using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace UnitTestCourse.Test
{
    public class DemoRepositoryTests
    {
        [Fact]
        public void ShouldLog()
        {
            // Arrange
            var logger = new Mock<ILogger<DemoRepository>>();

            var sut = new DemoRepository(logger.Object);

            sut.GetAll();

            logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("GetAll methed has been called", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}
