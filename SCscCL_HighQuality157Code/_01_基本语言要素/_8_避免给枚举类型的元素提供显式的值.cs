namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _8_避免给枚举类型的元素提供显式的值
	{
		#region TestModel_Eq1
		private enum Eq1Race
		{
			TE = 1,
			OC = 2,
			NE,
			UD = 3
		};
		#endregion

		/// <summary>
		/// 避免枚举类型的重复值带来的问题
		/// </summary>
		[TestMethod]
		public void Eq1避免未给枚举值显式赋值()
		{
			Console.WriteLine(Eq1Race.NE==Eq1Race.UD);//true;
		}


		#region TestModel_Eq2
		[Flags]
		private enum Eq2Week
		{
			None = 0x0,
			Money = 0x1,
			Tuesday = 0x2,
			Wednesday = 0x4,
			Thursday = 0x8,
			Friday = 0x10,
			Saturday = 0x20,
			Sunday=0x40,
		};
		#endregion
		[TestMethod]
		public void	 Eq2当存在Flags特性的情况()
		{

		}
	}
}
