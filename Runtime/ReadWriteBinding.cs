using System;
using JetBrains.Annotations;

namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// ReadWriteBinding is a two-way binding allowing to read and write external values.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public sealed class ReadWriteBinding<TValue> : IReadWriteSource<TValue>
    {
        private readonly Func<TValue> _getter;
        private readonly Action<TValue> _setter;

        public ReadWriteBinding([NotNull] Func<TValue> getter, [NotNull] Action<TValue> setter)
        {
            _getter = getter;
            _setter = setter;
        }

        public TValue Get() => _getter();

        public void Set(TValue value) => _setter(value);
    }
}