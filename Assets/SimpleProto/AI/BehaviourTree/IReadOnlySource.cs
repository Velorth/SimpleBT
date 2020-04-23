namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// IReadOnlySource is a generic interface for the data provided to the behaviour tree nodes.
    /// </summary>
    /// <typeparam name="TValue">The type of the data.</typeparam>
    public interface IReadOnlySource<out TValue>
    {
        TValue Get();
    }
}