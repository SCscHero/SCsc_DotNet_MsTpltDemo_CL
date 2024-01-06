namespace SCsc_DesignPattern.IOC
{
	/// <summary>
	/// IOC抽象工厂
	/// </summary>
	public abstract class IOCFactory
	{
		/// <summary>
		/// IOC抽象工厂方法
		/// </summary>
		/// <param name="typeName"></param>
		/// <returns></returns>
		public abstract object GetObject(string typeName);
	}
}
