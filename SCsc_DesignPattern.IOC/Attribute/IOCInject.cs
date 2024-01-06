namespace SCsc_DesignPattern.IOC._Attribute
{
	/// <summary>
	/// IOC属性过滤特性
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	class IOCInject : Attribute
	{
		public IOCInject()
		{

		}
	}
}
