using Concert.Abstractions;
using FluentAssertions;
using NSubstitute;
using SingleThreaded.Performers;
using Xunit;

namespace SingleThreaded.Tests
{
    public class ConductorTests
    {
        [Fact]
        public void WhenAttachingNewPerformerItShouldBeAttachedToEtherTest()
        {
            //Arrange
            var ether = Substitute.For<IEther>();
            var receptorFactory = Substitute.For<IReceptorFactory>();
            var performer = new BasePerformer(ether, receptorFactory);
            var conductor = new SingleThreadedConductor();

            //Act
            conductor.Attach(performer);

            //Assert
            conductor.PerformerCount.Should().Be(1);
        }
    }
}