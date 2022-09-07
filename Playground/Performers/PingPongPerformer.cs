using Concert.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleThreaded.Performers
{
    public class PingPongPerformer : BasePerformer
    {
        public PingPongPerformer(IEther ether) : base(ether)
        {
            // TODO this should be async
            Register<object>(Pong).GetAwaiter().GetResult();
        }

        private Task<ExecutionState> Pong(Note<object> note)
        {
            Console.WriteLine($"Tadam {note.Id}");

            return Task.FromResult(ExecutionState.AllCompleted);
        }

    }
}
