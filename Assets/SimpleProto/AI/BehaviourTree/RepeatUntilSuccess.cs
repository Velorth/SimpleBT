
namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Repeat decorated node until it succeeds.
    /// </summary>
    public sealed class RepeatUntilSuccess : Decorator
    {
        protected override NodeState OnRunning(ExecutionContext actor)
        {
            if (Child.State == NodeState.Failure)
            {
                Child.Reset();
            }

            if (Child.State == NodeState.Ready || Child.State == NodeState.Running)
            {
                Child.Execute(actor);
            }

            return Child.State == NodeState.Success
                ? NodeState.Success
                : NodeState.Running;
        }
    }
}