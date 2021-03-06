namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Repeat decorated node until it succeeds.
    /// </summary>
    public sealed class RepeatUntilSuccess : Decorator
    {
        protected override NodeState OnRunning(object context)
        {
            if (Child.State == NodeState.Failure)
            {
                Child.Reset(context);
            }

            if (Child.State == NodeState.Ready || Child.State == NodeState.Running)
            {
                Child.Execute(context);
            }

            return Child.State == NodeState.Success
                ? NodeState.Success
                : NodeState.Running;
        }
    }

    public sealed class RepeatWhileSuccess : Decorator
    {
        protected override NodeState OnRunning(object context)
        {
            if (Child.State == NodeState.Success)
            {
                Child.Reset(context);
            }

            Child.Execute(context);

            return Child.State == NodeState.Failure ? NodeState.Failure : NodeState.Running;
        }
    }
}