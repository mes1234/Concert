using Concert.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleThreaded
{
    public class SingleThreadedReceptor<T> : IReceptor<T>
    {
        private readonly Func<Note<T>, Task> _func;

        public SingleThreadedReceptor(Func<Note<T>, Task> func)
        {
            _func = func;
        }

        public async Task Receive(Note<T> note)
        {
            await _func(note).ConfigureAwait(false);
        }
    }
}
