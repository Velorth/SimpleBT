
namespace SimpleProto.AI.BehaviourTrees
{
    public abstract class BehaviourTreeNode<TContext> : IBehaviourTreeNode
    {
        public NodeState State { get; private set; }

        public virtual void Reset(object context)
        {
            State = NodeState.Ready;
            if (context is TContext tContext)
            {
                OnReset(tContext);
            }
        }

        void IBehaviourTreeNode.Cancel(object context)
        {
            if (context is TContext tContext)
            {
                Cancel(tContext);
            }
        }

        NodeState IBehaviourTreeNode.Execute(object context)
        {
            if (context is TContext tContext)
                return Execute(tContext);
            
            return NodeState.Failure;
        }

        public void Cancel(TContext context)
        {
        }

        public NodeState Execute(TContext context)
        {
            if (State == NodeState.Success || State == NodeState.Failure)
                return State;

            if (State == NodeState.Ready)
            {
                State = OnStart(context);
            }

            if (State == NodeState.Running)
            {
                State = OnRunning(context);
            }

            if (State == NodeState.Success)
            {
                OnSuccess(context);
            }
            else if (State == NodeState.Failure)
            {
                OnFailure(context);
            }

            return State;
        }

        protected virtual void OnSuccess(TContext context)
        {
        }

        protected virtual void OnFailure(TContext context)
        {
        }

        protected virtual void OnReset(TContext context)
        {
        }

        protected virtual NodeState OnStart(TContext context)
        {
            return NodeState.Running;
        }

        protected virtual NodeState OnRunning(TContext context) => NodeState.Failure;
    }
}
