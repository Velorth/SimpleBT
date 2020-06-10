namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class Failure : BehaviourTreeNode
    {
        protected override NodeState OnStart(object context)
        {
            return NodeState.Failure;
        }
    }
}