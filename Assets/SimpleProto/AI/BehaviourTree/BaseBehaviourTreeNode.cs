using System;

namespace SimpleProto.AI.BehaviourTrees
{
    public abstract class BaseBehaviourTreeNode : IBehaviourTreeNode
    {
        public NodeState State { get; private set; }


        /// <summary>
        /// Resets the state of the node
        /// </summary>
        public void Reset()
        {
            State = NodeState.Ready;
            OnReset();
        }

        /// <summary>
        /// Executes behaviour tree node
        /// </summary>
        /// <param name="context">An actor</param>
        /// <returns>New state of the node</returns>
        public NodeState Execute(ExecutionContext context)
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
                OnCompleted();
            }
            else if (State == NodeState.Failure)
            {
                OnFailed(context);
            }

            return State;
        }

        /// <summary>
        /// Marks node as failed
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void Cancel(ExecutionContext context)
        {
            State = NodeState.Failure;
            OnFailed(context);
        }

        protected virtual void OnCompleted()
        {
        }

        protected virtual void OnFailed(ExecutionContext context)
        {
        }

        protected virtual void OnReset()
        {
        }

        protected virtual NodeState OnStart(ExecutionContext context)
        {
            return NodeState.Running;
        }

        protected virtual NodeState OnRunning(ExecutionContext context) => NodeState.Failure;
    }
}