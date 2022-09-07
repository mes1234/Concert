﻿using Concert.Abstractions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SingleThreaded.Tests
{
    public class EtherTests
    {
        [Fact]
        public async Task WhenReceptorIsAddedAndNoteIsPropagadedReceptorShouldBeTriggeredTest()
        {
            //Arrange
            var receptor = Substitute.For<IReceptor<object>>();
            var ether = new SingleThreadedEther();
            var note = new Note<object>
            {
                Content = "data"
            };

            //Act
            await ether.Attach(receptor);
            await ether.Propagate(note);

            //Assert
            await receptor.Received(1).Receive(note);
        }
    }
}
