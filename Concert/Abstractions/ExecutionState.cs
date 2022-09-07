using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert.Abstractions
{
    public class ExecutionState
    {
        private enum ExecutionStates
        {
            AllCompleted,
            NonCompleted,
            SomeFailed
        }

        private readonly ExecutionStates _state;

        private ExecutionState(ExecutionStates state)
        {
            _state = state;
        }
        public readonly static ExecutionState AllCompleted = new ExecutionState(ExecutionStates.AllCompleted);
        public readonly static ExecutionState NonCompleted = new ExecutionState(ExecutionStates.NonCompleted);
        public readonly static ExecutionState SomeFailed = new ExecutionState(ExecutionStates.SomeFailed);
    }
}
