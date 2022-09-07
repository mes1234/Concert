using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert.Abstractions
{
    /// <summary>
    /// Conductor is an object which conduct whole processing
    /// Bootstraps, Stops and Add new Performers
    /// </summary>
    public interface IConductor
    {
        public Task Attach(IPerformer performer);
    }
}
