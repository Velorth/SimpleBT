using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace SimpleProto.AI.BehaviourTrees
{
    public abstract class Decorator : BehaviourTreeNode,
        IEnumerable<IBehaviourTreeNode>
    {
        /// <summary>
        /// Gets or sets decorated task node
        /// </summary>
        public IBehaviourTreeNode Child { get; set; }

        protected Decorator([NotNull]IBehaviourTreeNode node)
        {
            Child = node;
        }

        protected Decorator()
        {
        }

        protected override void OnReset(object context)
        {
            Child.Reset(context);
        }

        public void Add(IBehaviourTreeNode child)
        {
            Child = child;
        }

        IEnumerator<IBehaviourTreeNode> IEnumerable<IBehaviourTreeNode>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        private struct Enumerator : IEnumerator<IBehaviourTreeNode>
        {
            private readonly Decorator _decorator;

            public Enumerator(Decorator decorator)
            {
                _decorator = decorator;
            }

            public bool MoveNext()
            {
                return false;
            }

            public void Reset()
            {
            }

            public IBehaviourTreeNode Current => _decorator.Child;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }

    public abstract class Decorator<TContext> : BehaviourTreeNode<TContext>, IEnumerable<IBehaviourTreeNode>
    {
        /// <summary>
        /// Gets or sets decorated task node
        /// </summary>
        public IBehaviourTreeNode Child { get; set; }

        protected Decorator([NotNull]IBehaviourTreeNode node)
        {
            Child = node;
        }

        protected Decorator()
        {
        }

        protected override void OnReset(TContext context)
        {
            Child.Reset(context);
        }

        public void Add(IBehaviourTreeNode child)
        {
            Child = child;
        }

        IEnumerator<IBehaviourTreeNode> IEnumerable<IBehaviourTreeNode>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        private struct Enumerator : IEnumerator<IBehaviourTreeNode>
        {
            private readonly Decorator<TContext> _decorator;

            public Enumerator(Decorator<TContext> decorator)
            {
                _decorator = decorator;
            }

            public bool MoveNext()
            {
                return false;
            }

            public void Reset()
            {
            }

            public IBehaviourTreeNode Current => _decorator.Child;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}