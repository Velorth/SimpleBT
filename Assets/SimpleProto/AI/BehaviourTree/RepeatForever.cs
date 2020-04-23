namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Repeat decorated node in the infinite loop.
    /// </summary>
    public sealed class RepeatForever : Decorator
    {
        protected override NodeState OnRunning(ExecutionContext actor)
        {
            if (Child.State == NodeState.Failure || Child.State == NodeState.Success)
            {
                Child.Reset();
            }

            if (Child.State == NodeState.Ready || Child.State == NodeState.Running)
            {
                Child.Execute(actor);
            }

            return NodeState.Running;
        }
    }
}