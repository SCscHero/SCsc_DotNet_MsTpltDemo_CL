namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _09_习惯重载运算符
	{
		#region Test_Eq1
		private class Eq1Salary
		{
			public int RMB { get; set; }
			public static Eq1Salary operator +(Eq1Salary s1, Eq1Salary s2)
			{
				s2.RMB += s1.RMB;
				return s2;
			}
		};
		#endregion
		[TestMethod]
		public void Eq1重载运算符基础使用()
		{
			Eq1Salary s1 = new Eq1Salary() { RMB = 50};
			Eq1Salary s2 = new Eq1Salary() { RMB = 100};
			Eq1Salary s3 = s1 + s2;
		}
	}
}
