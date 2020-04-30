namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Repeat decorated node in the infinite loop.
    /// </summary>
    public sealed class RepeatForever : Decorator
    {
        protected override NodeState OnRunning(object context)
        {
            if (Child.State == NodeState.Failure || Child.State == NodeState.Success)
            {
                Child.Reset(context);
            }

            if (Child.State == NodeState.Ready || Child.State == NodeState.Running)
            {
                Child.Execute(context);
            }

            return NodeState.Running;
        }
    }
}