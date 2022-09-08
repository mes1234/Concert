using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert.Abstractions
{
    /// <summary>
    /// Receptor is a bridge between <see cref="IEther"/> and <see cref="IPerformer"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReceptor<T> : IReceptor
    {
        public Task Receive(Note<T> note);
    }
#pragma warning disable CA1040
    public interface IReceptor
    {

    }
}
