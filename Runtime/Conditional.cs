using System;
using SimpleProto.AI.BehaviourTrees;

namespace SimpleProto.AI
{
    public class Conditional : Decorator
    {
        public Predicate<object> Condition { get; set; }

        protected override NodeState OnRunning(object agent)
        {
            if (Child.State == NodeState.Failure || Child.State == NodeState.Success)
                return Child.State;

            if (Condition != null && !Condition(agent))
                return NodeState.Failure;

            Child.Execute(agent);

            return Child.State;
        }
    }
}
