using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert.Abstractions
{
    public interface IPropagationPolicy
    {
        public Task<ExecutionState> Execute<T>(IEnumerable<IReceptor<T>> receptors, Note<T> note);
    }
}
