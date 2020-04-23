using System;

namespace SimpleProto.AI.BehaviourTrees
{
    public static class Bindings
    {
        public static ReadOnlyBinding<TValue> Create<TValue>(Func<TValue> foo) => 
            new ReadOnlyBinding<TValue>(foo);

        public static WriteOnlyBinding<TValue> Create<TValue>(Action<TValue> setter) =>
            new WriteOnlyBinding<TValue>(setter);

        public static ReadWriteBinding<TValue> Create<TValue>(Func<TValue> getter, Action<TValue> setter) =>
            new ReadWriteBinding<TValue>(getter, setter);
    }
}