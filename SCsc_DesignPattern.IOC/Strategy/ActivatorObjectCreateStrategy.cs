namespace SCsc_DesignPattern.IOC.Strategy
{
	/// <summary>
	/// Activator 对象创建策略
	/// </summary>
	public class ActivatorObjectCreateStrategy : IObjectCreateStrategy
	{
		public object CreateObject(Type type)
		{
			return Activator.CreateInstance(type);
		}
	}
}
