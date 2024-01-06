namespace SCsc_DesignPattern.IOC.Strategy
{
	/// <summary>
	/// Assembly 对象创建策略
	/// </summary>
	public class AssemblyObjectCreateStrategy : IObjectCreateStrategy
	{
		public object CreateObject(Type type)
		{
			return type.Assembly.CreateInstance(type.FullName);
		}
	}
}
