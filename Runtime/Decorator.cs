using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace SimpleProto.AI.BehaviourTrees
{
    public abstract class Decorator : BehaviourTreeNode,
        IEnumerable<IBehaviourTreeNode>
    {
        private IBehaviourTreeNode _child;
        private bool _useInternalSequence;

        /// <summary>
        /// Gets or sets decorated task node
        /// </summary>
        public IBehaviourTreeNode Child
        {
            get => _child;
            set
            {
                _child = value;
                _useInternalSequence = false;
            }
        }

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
            if (_useInternalSequence)
            {
                ((Sequence)_child).Add(child);
            }
            else if (_child != null)
            {
                _child = new Sequence { _child, child };
                _useInternalSequence = true;
            }
            else
            {
                _child = child;
            }
        }

        IEnumerator<IBehaviourTreeNode> IEnumerable<IBehaviourTreeNode>.GetEnumerator()
        {
            return _useInternalSequence ? ((Sequence)_child).GetEnumerator() : new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _useInternalSequence ? ((Sequence)_child).GetEnumerator() : new Enumerator(this);
        }

        private struct Enumerator : IEnumerator<IBehaviourTreeNode>
        {
            private readonly Decorator _decorator;
            private bool _hasNext;

            public Enumerator(Decorator decorator)
            {
                _decorator = decorator;
                _hasNext = true;
            }

            public bool MoveNext()
            {
                if (!_hasNext) return false;

                _hasNext = false;
                return true;

            }

            public void Reset()
            {
                _hasNext = true;
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
        private IBehaviourTreeNode _child;
        private bool _useInternalSequence;

        /// <summary>
        /// Gets or sets decorated task node
        /// </summary>
        public IBehaviourTreeNode Child
        {
            get => _child;
            set
            {
                _child = value;
                _useInternalSequence = false;
            }
        }

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
            if (_useInternalSequence)
            {
                ((Sequence)_child).Add(child);
            }
            else if (_child != null)
            {
                _child = new Sequence { _child, child };
                _useInternalSequence = true;
            }
            else
            {
                _child = child;
            }
        }

        IEnumerator<IBehaviourTreeNode> IEnumerable<IBehaviourTreeNode>.GetEnumerator()
        {
            return _useInternalSequence ? ((Sequence)_child).GetEnumerator() : new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _useInternalSequence ? ((Sequence)_child).GetEnumerator() : new Enumerator(this);
        }

        private struct Enumerator : IEnumerator<IBehaviourTreeNode>
        {
            private readonly Decorator<TContext> _decorator;
            private bool _hasNext;

            public Enumerator(Decorator<TContext> decorator)
            {
                _decorator = decorator;
                _hasNext = true;
            }

            public bool MoveNext()
            {
                if (!_hasNext) return false;

                _hasNext = false;
                return true;

            }

            public void Reset()
            {
                _hasNext = true;
            }

            public IBehaviourTreeNode Current => _decorator.Child;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}