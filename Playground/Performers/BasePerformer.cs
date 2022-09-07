using Concert.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleThreaded.Performers
{
    public class BasePerformer : IPerformer
    {
        private readonly IEther _ether;



        public BasePerformer(IEther ether)
        {
            _ether = ether;
        }

        public virtual async Task Register<T>(Func<Note<T>, Task<ExecutionState>> func)
        {
            // TODO move to factory
            var receptor = new SingleThreadedReceptor<T>(func);

            await _ether.Attach(receptor);
        }
    }
}
