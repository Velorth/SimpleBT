using System;
using JetBrains.Annotations;

namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class WriteOnlyBinding<TValue> : IWriteOnlySource<TValue>
    {
        private readonly Action<TValue> _setter;

        public WriteOnlyBinding([NotNull] Action<TValue> setter)
        {
            _setter = setter;
        }

        public void Set(TValue value)
        {
            _setter(value);
        }

        public static implicit operator OutVariable<TValue>(WriteOnlyBinding<TValue> source) =>
            new OutVariable<TValue>(source);
    }
}