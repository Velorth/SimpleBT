namespace SimpleProto.AI.BehaviourTrees
{
    public enum NodeState
    {
        /// <summary>
        /// The node is ready to run
        /// </summary>
        Ready,

        /// <summary>
        /// The execution of node have sucessfully completed
        /// </summary>
        Success,

        /// <summary>
        /// The execution of node have failed
        /// </summary>
        Failure,

        /// <summary>
        /// The node is still running
        /// </summary>
        Running
    }
}