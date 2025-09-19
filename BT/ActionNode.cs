using System;

namespace UnitySubCore.BT
{
	public sealed class ActionNode : ABTNode
	{
		private Func<ENodeState> _action;

		public ActionNode(Func<ENodeState> action)
		{
			_action = action;
			return;
		}

		public override ENodeState Evaluate()
		{
			_state = _action.Invoke();
			return (_state);
		}
	}
}