using Concert.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleThreaded
{
    public class SimplePropagationPolicy : IPropagationPolicy
    {
        public async Task<ExecutionState> Execute<T>(IEnumerable<IReceptor<T>> receptors, Note<T> note)
        {
            CheckInputs(receptors);

            return await Run(receptors, note).ConfigureAwait(false);
        }

        private static void CheckInputs(IEnumerable<IReceptor> receptors)
        {
            if (receptors is null)
            {
                throw new ArgumentNullException(nameof(receptors));
            }
        }

        private static async Task<ExecutionState> Run<T>(IEnumerable<IReceptor<T>> receptors, Note<T> note)
        {
            foreach (var receptor in receptors)
            {
                await receptor.Receive(note).ConfigureAwait(false);
            }

            return ExecutionState.AllCompleted;
        }
    }
}
