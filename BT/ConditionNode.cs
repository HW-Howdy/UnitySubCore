using System;

namespace UnitySubCore.BT
{
	public sealed class ConditionNode : ABTNode
	{
		private Func<bool> _condition;

		public ConditionNode(Func<bool> condition)
		{
			_condition = condition;
			return;
		}

		public override ENodeState Evaluate()
		{
			ENodeState result;

			if (_condition.Invoke())
			{
				result = ENodeState.Success;
			}
			else
			{
				result = ENodeState.Failure;
			}
			_state = result;
			return (_state);
		}
	}
}
