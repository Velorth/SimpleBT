using System;

namespace SimpleProto.AI.BehaviourTrees
{
    public class Conditional : Decorator
    {
        public Predicate<ExecutionContext> Condition { get; set; }

        protected override NodeState OnRunning(ExecutionContext context)
        {
            if (Child.State == NodeState.Failure || Child.State == NodeState.Success)
                return Child.State;

            if (Condition != null && !Condition(context))
                return NodeState.Failure;

            Child.Execute(context);

            return Child.State;
        }
    }
}
