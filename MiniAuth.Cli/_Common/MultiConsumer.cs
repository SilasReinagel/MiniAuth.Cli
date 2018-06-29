using System.Collections.Generic;
using System.Linq;

namespace MiniAuth.Cli
{
    public sealed class MultiConsumer<T> : IConsumer<T>
    {
        private readonly List<IConsumer<T>> _consumers;

        public MultiConsumer(params IConsumer<T>[] consumers)
        {
            _consumers = consumers.ToList();
        }
        
        public void Put(T value) => _consumers.ForEach(x => x.Put(value));
    }
}
