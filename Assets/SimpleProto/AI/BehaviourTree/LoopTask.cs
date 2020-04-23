using System;

namespace SimpleProto.AI.BehaviourTrees
{
    public class Loop : Decorator
    {
        private int _counter;

        public int RepeatTimes { get; set; }

        public bool RepeatInfinite { get; set; }

        protected override void OnReset()
        {
            _counter = 0;
            base.OnReset();
        }

        protected override NodeState OnRunning(ExecutionContext context)
        {
            if (Child.State == NodeState.Success || Child.State == NodeState.Failure)
            {
                _counter++;
                if (!RepeatInfinite && RepeatTimes <= _counter)
                {
                    return Child.State;
                }
                Child.Reset();
            }

            Child.Execute(context);

            return NodeState.Running;
        }
    }
}