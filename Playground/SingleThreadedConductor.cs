using Concert.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleThreaded
{
    public class SingleThreadedConductor : IConductor
    {
        private readonly ICollection<IPerformer> _performers = new List<IPerformer>();

        public int PerformerCount => _performers.Count;

        public Task Attach(IPerformer performer)
        {
            _performers.Add(performer);

            return Task.CompletedTask;
        }
    }
}
