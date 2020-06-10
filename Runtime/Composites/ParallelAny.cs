namespace SimpleProto.AI.BehaviourTrees
{
    public class ParallelAny : Composite
    {
        protected override NodeState OnRunning(object context)
        {
            var allFailed = true;
            for (var i = 0; i < Children.Count; ++i)
            {
                var childState = Children[i].Execute(context);
                if (childState == NodeState.Success)
                    return NodeState.Success;
                if (childState != NodeState.Failure)
                    allFailed = false;
            }

            return allFailed ? NodeState.Failure : NodeState.Running;
        }
    }
}