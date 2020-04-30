namespace SimpleProto.AI.BehaviourTrees
{
    public class Loop : Decorator
    {
        private int _counter;

        public int RepeatTimes { get; set; }

        public bool RepeatInfinite { get; set; }

        protected override void OnReset(object context)
        {
            _counter = 0;
            base.OnReset(context);
        }

        protected override NodeState OnRunning(object context)
        {
            if (Child.State == NodeState.Success || Child.State == NodeState.Failure)
            {
                _counter++;
                if (!RepeatInfinite && RepeatTimes <= _counter)
                {
                    return Child.State;
                }
                Child.Reset(context);
            }

            Child.Execute(context);

            return NodeState.Running;
        }
    }
}