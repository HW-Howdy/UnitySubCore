namespace UnitySubCore.StringTable
{
	public interface IUSCStringTable
	{
		public string Language { get; }
		public string Get(string key);
		public bool Contains(string key);
	}
}