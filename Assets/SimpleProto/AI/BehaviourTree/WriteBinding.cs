using System;

namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class WriteBinding<TValue> : IWriteOnlySource<TValue>
    {
        private readonly Action<TValue> _setter;

        public WriteBinding(Action<TValue> setter)
        {
            _setter = setter;
        }

        public void Set(TValue value)
        {
            _setter(value);
        }

        public static implicit operator OutVariable<TValue>(WriteBinding<TValue> binding)
        {
            return new OutVariable<TValue>(binding);
        }
    }
}