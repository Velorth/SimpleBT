namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class Invert : Decorator
    {
        protected override NodeState OnRunning(object context)
        {
            if (Child.State == NodeState.Ready || Child.State == NodeState.Running)
            {
                Child.Execute(context);
            }
            
            if (Child.State == NodeState.Success)
                return NodeState.Failure;

            if (Child.State == NodeState.Failure)
                return NodeState.Success;

            return NodeState.Running;
        }
    }
}