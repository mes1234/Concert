using Concert.Abstractions;
using FluentAssertions;
using NSubstitute;
using SingleThreaded.Performers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SingleThreaded.Tests
{
    public class PerformerTests
    {
        [Fact]
        public void WhenPingPongPerformerIsAttachedToEtherItIsTriggeredTest()
        {
            //Arrange
            var ether = Substitute.For<IEther>();
            var receptorFactory = Substitute.For<IReceptorFactory>();
            new PingPongPerformer(ether, receptorFactory);

            //Assert
            ether.Received(1).Attach<object>(Arg.Any<IReceptor<object>>());
        }

        [Fact]
        public async Task WhenPingPongPerformerIsAttachedAndNoteIsPropagatedPeformerReactsTest()
        {
            //Arrange
            var propagationPolicy = new SimplePropagationPolicy();
            var receptorFactory = Substitute.For<IReceptorFactory>();
            var ether = new SingleThreadedEther(propagationPolicy);
            new PingPongPerformer(ether, receptorFactory);

            //Act
            var result = await ether.Propagate(new Note<object>());

            //Assert
            result.Should().Be(ExecutionState.AllCompleted);
        }
    }
}
