using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert.Abstractions
{
    public interface IReceptorFactory
    {
        public IReceptor<T> Build<T>(Func<Note<T>, Task<ExecutionState>> func);
    }
}
