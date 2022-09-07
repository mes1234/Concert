using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert.Abstractions
{
    /// <summary>
    /// Note is an atomic portion of data passed between <see cref="IPerformer"/>
    /// </summary>
    /// <typeparam name="T">Type of content</typeparam>
    public readonly record struct Note<T>
    {
        public readonly Guid Id;
        public readonly T Content { get; init; }
    }
}
