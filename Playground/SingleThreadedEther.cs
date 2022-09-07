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

        public Task Attach<T>(IReceptor<T> receptor)
        {
            AddReceptor(receptor);

            return Task.CompletedTask;
        }

        public async Task<ExecutionState> Propagate<T>(Note<T> note)
        {
            // TODO add execution policy and summary
            foreach (var receptor in GetReceptors<T>())
            {
                await receptor.Receive(note).ConfigureAwait(false);
            }

            return ExecutionState.AllCompleted;
        }

        private bool SlotExists(Type type)
        {
            return _ether.ContainsKey(type);
        }

        private void BootstrapEtherSlot(Type type)
        {
            _ether.Add(type, new HashSet<IReceptor>());
        }

        private void AddReceptor<T>(IReceptor<T> receptor)
        {
            var type = typeof(T);

            if (!SlotExists(type))
            {
                BootstrapEtherSlot(type);
            }

            var boxedReceptor = (IReceptor)receptor;

            _ether[type].Add(boxedReceptor);
        }

        private IEnumerable<IReceptor<T>> GetReceptors<T>()
        {
            if (!SlotExists(typeof(T)))
            {
                return Enumerable.Empty<IReceptor<T>>();
            }

            var receptors = _ether.Where(x => x.Key == typeof(T)).SelectMany(r => r.Value);

            return receptors.Select(r => Recast<T>(r));
        }

        private IReceptor<T> Recast<T>(IReceptor receptor)
        {
            return (IReceptor<T>)receptor;
        }
    }
}
