using JetBrains.Annotations;

namespace SimpleProto.AI.BehaviourTrees
{
    public abstract class BehaviourTreeNode : IBehaviourTreeNode
    {
        public NodeState State { get; private set; }


        /// <summary>
        /// Resets the state of the node
        /// </summary>
        /// <param name="context"></param>
        public void Reset(object context)
        {
            State = NodeState.Ready;
            OnReset(context);
        }

        /// <summary>
        /// Executes behaviour tree node
        /// </summary>
        /// <param name="context">An actor</param>
        /// <returns>New state of the node</returns>
        public NodeState Execute(object context)
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

        /// <summary>
        /// Marks node as failed
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void Cancel(object context)
        {
            State = NodeState.Failure;
            OnFailure(context);
        }

        protected virtual void OnSuccess([NotNull] object context)
        {
        }

        protected virtual void OnFailure([NotNull] object context)
        {
        }

        protected virtual void OnReset([NotNull] object context)
        {
        }

        protected virtual NodeState OnStart([NotNull] object context)
        {
            return NodeState.Running;
        }

        protected virtual NodeState OnRunning([NotNull] object context) => NodeState.Failure;
    }

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
