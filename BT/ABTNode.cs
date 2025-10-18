namespace UnitySubCore.BT
{
	/// <summary>
	/// State return value of Node
	/// </summary>
	public enum ENodeState
	{
		Failure = 0,
		Success = 1,
		Running = 2,
	}

	/// <summary>
	/// Abstract parent class in BT Node
	/// </summary>
	public abstract class ABTNode
	{
		protected ENodeState _state;

		public ENodeState State { get => _state; }

		/// <summary>
		/// act appropriately according to the type of node
		/// </summary>
		/// <returns>value of an action</returns>
		public abstract ENodeState Evaluate();
	}
}
