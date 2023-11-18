using System.Collections.Generic;
using System.Linq;

namespace CsLangVersion.Fdmts_CollectionType
{
	internal class ListExceptionTest
	{
		private class StudentModel
		{
			public string Name { get; set; }
			public string Father { get; set; }
		}

		[Test]
		public void ex001_Where引发null()
		{
			List<StudentModel> listVoidValue = new List<StudentModel>();
			List<StudentModel> listValuable = new List<StudentModel>()
{
		new StudentModel()
		{
				Name = "SCscHero",
				Father = "Dragon"
		},
		new StudentModel()
		{
				Name = "XiaoMing",
				Father = "XiaoMingFather"
		}
};
			var fatherSel = listValuable.Where(o => o.Name == "SCscHero").FirstOrDefault().Father;
			try
			{
				fatherSel = listVoidValue.Where(o => o.Name == "SCscHero").FirstOrDefault()?.Father ?? null;
				//如果Where语句搜不到可能会是null，则取首行时候要小心。
				var temp = listVoidValue.Where(o => o.Name == "SCscHero").FirstOrDefault().Father;
			}
			catch (System.Exception ex)
			{
				throw;
			}

		}
	}
}
