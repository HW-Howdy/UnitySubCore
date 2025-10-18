using System;

namespace UnitySubCore.BT
{
	public sealed class ActionNode : ABTNode
	{
		private Func<ENodeState> _action;

		/// <param name="action">act of Node</param>
		public ActionNode(Func<ENodeState> action)
		{
			if (action == null)
				throw (new ArgumentNullException(nameof(action)) );
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