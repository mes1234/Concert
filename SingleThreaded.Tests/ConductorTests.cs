using Concert.Abstractions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace SingleThreaded.Tests
{
    public class ConductorTests
    {
        [Fact]
        public void WhenAttachingNewPerformerItShouldBeAttachedToEtherTest()
        {
            //Arrange
            var performer = Substitute.For<IPerformer>();
            var conductor = new SingleThreadedConductor();

            //Act
            conductor.Attach(performer);

            //Assert
            conductor.PerformerCount.Should().Be(1);
        }
    }
}