namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// IReadWriteSource is an interface to provide mutable data to the behaviour tree nodes.
    /// </summary>
    /// <typeparam name="TValue">The type of the data.</typeparam>
    public interface IReadWriteSource<TValue> : IReadOnlySource<TValue>, IWriteOnlySource<TValue>
    {
    }
}