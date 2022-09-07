using Concert.Abstractions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SingleThreaded.Tests
{
    public class ReceptorTests
    {
        [Fact]
        public async Task WhenFunctionIsRegisteredItShouldBeTriggeredTest()
        {
            //Arrange
            var flip = false;
            var function = new Func<Note<object>, Task<ExecutionState>>(async obj =>
            {
                flip = true;
                await Task.Delay(1000);
                return ExecutionState.AllCompleted;
            });
            var receptor = new SingleThreadedReceptor<object>(function);

            //Act
            await receptor.Receive(new Note<object> { });

            //Assert

            flip.Should().BeTrue();
        }
    }
}
