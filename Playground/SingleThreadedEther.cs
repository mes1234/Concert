using Concert.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleThreaded
{
    public class SingleThreadedEther : IEther
    {

        private readonly IDictionary<Type, ICollection<IReceptor>> _ether = new Dictionary<Type, ICollection<IReceptor>>();
        private readonly IPropagationPolicy _propagationPolicy;

        public SingleThreadedEther(IPropagationPolicy propagationPolicy)
        {
            _propagationPolicy = propagationPolicy;
        }

        public Task Attach<T>(IReceptor<T> receptor)
        {
            AddReceptor<T>(receptor);

            return Task.CompletedTask;
        }

        public async Task<ExecutionState> Propagate<T>(Note<T> note)
        {
            return await _propagationPolicy.Execute(GetReceptors<T>(), note).ConfigureAwait(false);
        }

        private bool SlotExists(Type type)
        {
            return _ether.ContainsKey(type);
        }

        private void BootstrapEtherSlot(Type type)
        {
            _ether.Add(type, new HashSet<IReceptor>());
        }

        private void AddReceptor<T>(IReceptor receptor)
        {
            var type = typeof(T);

            if (!SlotExists(type))
            {
                BootstrapEtherSlot(type);
            }

            _ether[type].Add(receptor);
        }

        private IEnumerable<IReceptor<T>> GetReceptors<T>()
        {
            if (!SlotExists(typeof(T)))
            {
                return Enumerable.Empty<IReceptor<T>>();
            }

            var receptors = _ether.Where(x => x.Key == typeof(T)).SelectMany(r => r.Value);

            return receptors.Select(r => (IReceptor<T>)r);
        }
    }
}
