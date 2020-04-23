namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// OutVariable is a container for the output parameters of the behaviour tree nodes.
    /// </summary>
    /// <typeparam name="TValue">The type of the output value.</typeparam>
    public struct OutVariable<TValue>
    {
        private readonly IWriteOnlySource<TValue> _binding;

        public void Set(TValue value)
        {
            _binding?.Set(value);
        }

        public OutVariable(IWriteOnlySource<TValue> binding)
        {
            _binding = binding;
        }
    }
}