namespace UnitySubCore.BT
{
	public enum ENodeState
	{
		Failure = 0,
		Success = 1,
		Running = 2,
	}

	public abstract class ABTNode
	{
		protected ENodeState _state;

		public ENodeState State { get => _state; }

		public abstract ENodeState Evaluate();
	}
}
