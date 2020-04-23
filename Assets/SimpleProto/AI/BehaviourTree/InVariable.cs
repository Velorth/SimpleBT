namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// InVariable is a container for the input parameter of the behaviour tree node.
    /// </summary>
    /// <typeparam name="TValue">The type of the input value.</typeparam>
    public struct InVariable<TValue>
    {
        private readonly TValue _value;
        private readonly IReadOnlySource<TValue> _binding;

        public TValue Get()
        {
            return _binding != null ? _binding.Get() : _value;
        }

        public InVariable(IReadOnlySource<TValue> binding)
        {
            _binding = binding;
            _value = default;
        }

        public InVariable(TValue value)
        {
            _binding = null;
            _value = value;
        }

        public static implicit operator InVariable<TValue>(TValue value)
        {
            return new InVariable<TValue>(value);
        }

        public static implicit operator TValue(InVariable<TValue> variable)
        {
            return variable.Get();
        }
    }
}