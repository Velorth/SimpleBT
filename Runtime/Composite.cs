using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Base class for composite nodes with children
    /// </summary>
    public abstract class Composite : BaseBehaviourTreeNode, IEnumerable<IBehaviourTreeNode>
    {
        private readonly List<IBehaviourTreeNode> _children = new List<IBehaviourTreeNode>();

        /// <summary>
        /// Gets the collection of children nodes
        /// </summary>
        [NotNull]
        public IList<IBehaviourTreeNode> Children { get { return _children; } }

        protected override void OnReset(object context)
        {
            for (var i = 0; i < _children.Count; ++i)
            {
                var child = _children[i];
                child.Reset(context);
            }
        }

        public IEnumerator<IBehaviourTreeNode> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds new child to the composite node
        /// </summary>
        /// <param name="child"></param>
        public void Add([NotNull]IBehaviourTreeNode child)
        {
            Children.Add(child);
        }
    }
}