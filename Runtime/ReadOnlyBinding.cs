using System;

namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class ReadOnlyBinding<TValue> : IReadOnlySource<TValue>
    {
        private readonly Func<TValue> _getter;

        public ReadOnlyBinding(Func<TValue> getter)
        {
            _getter = getter;
        }

        public TValue Get()
        {
            return _getter();
        }

        public static implicit operator InVariable<TValue>(ReadOnlyBinding<TValue> source) =>
            new InVariable<TValue>(source);
    }
}