namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class Success : BehaviourTreeNode
    {
        protected override NodeState OnStart(object context)
        {
            return NodeState.Success;
        }
    }
}