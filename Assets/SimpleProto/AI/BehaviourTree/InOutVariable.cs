namespace SimpleProto.AI.BehaviourTrees
{
    public struct InOutVariable<TValue>
    {
        private TValue _value;
        private readonly IReadWriteSource<TValue> _binding;

        public TValue Get() => _binding == null ? _value : _binding.Get();
        
        public void Set(TValue value)
        {
            _binding?.Set(value);

            _value = value;
        }

        public InOutVariable(IReadWriteSource<TValue> reference)
        {
            _binding = reference;
            _value = default;
        }

        public InOutVariable(TValue value)
        {
            _value = value;
            _binding = null;
        }

        public static implicit operator InOutVariable<TValue>(TValue value)
        {
            return new InOutVariable<TValue>(value);
        }
    }
}