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
            new PingPongPerformer(ether);

            //Assert
            ether.Received(1).Attach<object>(Arg.Any<IReceptor<object>>());
        }

        [Fact]
        public async Task WhenPingPongPerformerIsAttachedAndNoteIsPropagatedPeformerReactsTest()
        {
            //Arrange
            var ether = new SingleThreadedEther();
            new PingPongPerformer(ether);

            //Act
            var result = await ether.Propagate(new Note<object>());

            //Assert
            result.Should().Be(ExecutionState.AllCompleted);
        }
    }
}
