using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert.Abstractions
{
    /// <summary>
    /// Ether is a medium where <see cref="Note{T}"/> exists <br/>
    /// Ether can have <see cref="IReceptor{T}"/> attached which reacts to 
    /// given <see cref="Note{T}"/>
    /// </summary>
    /// <see cref="Note{T}"/>
    public interface IEther
    {
        public Task Attach<T>(IReceptor<T> receptor);

        public Task<ExecutionState> Propagate<T>(Note<T> note);
    }
}
