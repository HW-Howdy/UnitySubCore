using System.Collections.Generic;

namespace UnitySubCore.BT
{
	public sealed class SequenceNode : ABTNode
	{
		private List<ABTNode> _children;

		public SequenceNode(List<ABTNode> children)
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
				if (result != ENodeState.Success)
				{
					_state = result;
					return (_state);
				}
			}
			_state = ENodeState.Success;
			return (_state);
		}
	}
}