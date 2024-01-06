namespace SCsc_DesignPattern.IOC._Attribute
{
	/// <summary>
	/// IOC类型过滤特性
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class IOCService : Attribute
	{
		public IOCService()
		{

		}
	}
}
