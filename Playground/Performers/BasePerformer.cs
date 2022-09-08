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
        private readonly IReceptorFactory _receptorFactory;

        public BasePerformer(IEther ether, IReceptorFactory receptorFactory)
        {
            _ether = ether;
            _receptorFactory = receptorFactory;
        }

        public virtual async Task Register<T>(Func<Note<T>, Task<ExecutionState>> func)
        {
            var receptor = _receptorFactory.Build(func);

            await _ether.Attach(receptor).ConfigureAwait(false);
        }
    }
}
