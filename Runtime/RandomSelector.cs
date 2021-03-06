using UnityEngine;

namespace SimpleProto.AI.BehaviourTrees
{
    public class RandomSelector : Composite
    {
        private int _selectedIndex = -1;
        
        protected override NodeState OnStart(object context)
        {
            if (Children.Count == 0)
                return NodeState.Failure;

            _selectedIndex = Random.Range(0, Children.Count);

            return NodeState.Running;
        }

        protected override NodeState OnRunning(object context)
        {
            var child = Children[_selectedIndex];
            return child.Execute(context);
        }
    }
}