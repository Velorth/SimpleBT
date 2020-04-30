namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// IWriteOnlySource is an interface to return data from the behaviour tree nodes.
    /// </summary>
    /// <typeparam name="TValue">The type of the data.</typeparam>
    public interface IWriteOnlySource<in TValue>
    {
        void Set(TValue value);
    }
}