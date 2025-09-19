using System.Collections.Generic;

namespace UnitySubCore.BT
{
	public sealed class SelectorNode : ABTNode
	{
		private List<ABTNode> _children;

		public SelectorNode(List<ABTNode> children)
		{
			_children = children;
			return;
		}

		public override ENodeState Evaluate()
		{
			ENodeState result;

			foreach (ABTNode child in _children)
			{
				result = child.Evaluate();
				if (result != ENodeState.Failure)
				{
					_state = result;
					return (_state);
				}
			}
			_state = ENodeState.Failure;
			return (_state);
		}
	}
}