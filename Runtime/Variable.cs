namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Variable is a container for the parameters that can be shared between
    /// multiple behaviour tree nodes.
    /// </summary>
    /// <typeparam name="TValue">Type of the stored value</typeparam>
    public sealed class Variable<TValue> : IReadWriteSource<TValue>
    {
        private TValue _value;

        public TValue Get() => _value;

        public void Set(TValue value) => _value = value;

        public static implicit operator InOutVariable<TValue>(Variable<TValue> reference)
        {
            return new InOutVariable<TValue>(reference);
        }

        public static implicit operator InVariable<TValue>(Variable<TValue> binding)
        {
            return new InVariable<TValue>(binding);
        }

        public static implicit operator OutVariable<TValue>(Variable<TValue> reference)
        {
            return new OutVariable<TValue>(reference);
        }
    }
}