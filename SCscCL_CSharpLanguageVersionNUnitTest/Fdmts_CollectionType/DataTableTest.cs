using System;
using System.Data;

namespace CsLangVersion.Fdmts_CollectionType
{
	public class DataTableTest
	{

		[Test]
		public void DataTable基础使用()
		{
			//创建一个空表
			DataTable dt = new DataTable();
			//创建一个名为"Table_New"的空表
			DataTable dtTableName = new DataTable("Table_New");
			//DataTable(string tableName, string tableNamespace) 
			//指定的表名和命名空间初始化DataTable类的新实例
			DataTable dtTableNew = new DataTable("Table_New", "Test");

		}

		[Test]
		public void DataColumn基础使用()
		{
			DataTable dt = new DataTable();
			DataColumn dc = new DataColumn();
			//1.创建空列
			dt.Columns.Add(dc);
			//2.创建带列名和类型名的列(两种方式任选其一)
			dt.Columns.Add("column0", System.Type.GetType("System.String"));
			dt.Columns.Add("column0", typeof(String));
			//3.通过列架构添加列
			DataColumn dc1 = new DataColumn("column1", System.Type.GetType("System.DateTime"));
			DataColumn dc2 = new DataColumn("column1", typeof(DateTime));
			dt.Columns.Add(dc);
		}
		/// <summary>
		/// 【Ref】https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable.columns?view=net-7.0&devlangs=csharp&f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.Data.DataTable.Columns)%3Bk(SolutionItemsProject)%3Bk(DevLang-csharp)%26rd%3Dtrue
		/// </summary>
		[Test]
		public void DataColumn的遍历列()
		{
			DataTable table = new DataTable();
			table.Columns.Add("colStr1", typeof(String));
			table.Columns.Add("colStr2", System.Type.GetType("System.String"));
			table.Columns.Add("colInt3", System.Type.GetType("System.Int32"));
			table.Columns.Add("colDecimal4", typeof(decimal));
			foreach (DataColumn col in table.Columns)
			{
				Console.WriteLine(col.ColumnName);
			}
		}

		[Test]
		public void 指定列类型DataTable遍历单元格设置为空()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("职员ID", typeof(int));
			dt.Columns.Add("入职日期", typeof(string));
			dt.Columns.Add("离职日期", typeof(string));

			dt.Rows.Add(0, "2023-04-06", "0");
			dt.Rows.Add(44, "0", "0");
			dt.Rows.Add(0, "0", "0");
			dt.Rows.Add(223, "2023-07-18", "");

			Console.WriteLine("清除前");
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				for (int j = 0; j < dt.Columns.Count; j++)
				{
					//需要判断String类型才可以制定为""。
					if (dt.Columns[j].DataType == typeof(String) && dt.Rows[i][j].ToString() == "0")
						dt.Rows[i][j] = "";
				}
			}
			Console.WriteLine("清除后");

		}

		[Test]
		public void 不指定列类型DataTable遍历单元格()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("职员ID");
			dt.Columns.Add("入职日期");
			dt.Columns.Add("离职日期");

			dt.Rows.Add(121, "2023-04-06", "0");
			dt.Rows.Add(44, "0", "0");
			dt.Rows.Add(0, "0", "0");
			dt.Rows.Add(223, "2023-07-18", "");

			Console.WriteLine("清除前");
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				for (int j = 0; j < dt.Columns.Count; j++)
				{
					if (dt.Rows[i][j].ToString() == "0")
						dt.Rows[i][j] = "";
				}
			}
			Console.WriteLine("清除后");

		}

		/// <summary>
		/// https://learn.microsoft.com/zh-cn/dotnet/api/system.data.datatable.select?view=net-7.0
		/// </summary>
		[Test]
		public void DataTable筛选()
		{
			DataTable table = new DataTable();
			table.Columns.Add("职员ID");
			table.Columns.Add("入职日期");
			table.Columns.Add("离职日期");

			table.Rows.Add(121, "2023-04-06", "");
			table.Rows.Add(44, "", "");
			table.Rows.Add(144, "", "");
			table.Rows.Add(223, "2023-07-18", "");
			table.Rows.Add(477, "2019-07-01", "2022-01-05");
			table.Rows.Add(391, "2022-01-21", "2022-05-05");
			table.Rows.Add(341, "2022-01-21", "2022-09-05");
			// Presuming the DataTable has a column named Date.
			string expression;
			expression = "入职日期 = ''";
			DataRow[] foundRows;
			// Use the Select method to find all rows matching the filter.
			try
			{
				foundRows = table.Select(expression);
				var resTable = table.Clone();
				foreach (var item in foundRows)
				{
					resTable.Rows.Add(item);
					//当一个DataRow属于多个Table后会包异常，如果Add的时候使用item.ItemArray则不会有这个异常。
					//resTable.Rows.Add(item.ItemArray);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			Console.ReadKey();
		}

		[Test]
		public void DataTable复制结构()
		{
			DataTable table1 = new DataTable();
			table1.Columns.Add("职员ID");
			table1.Columns.Add("入职日期");
			table1.Columns.Add("离职日期");

			table1.Rows.Add(121, "2023-04-06", "");
			table1.Rows.Add(44, "", "");
			table1.Rows.Add(223, "2023-07-18", "");
			table1.Rows.Add(477, "2019-07-01", "2022-01-05");
			table1.Rows.Add(391, "2022-01-21", "2022-05-05");
			table1.Rows.Add(391, "2022-01-21", "2022-09-05");
			//【方案一】复制结构+数据
			DataTable table2 = table1.Copy();
			table2.Clear();
			//【方案二】只复制结构
			DataTable table3 = table1.Clone();
			Console.ReadKey();
		}

		[Test]
		public void DataRow基础使用()
		{
			DataTable dt = new DataTable();
			//1.创建空行
			DataRow dr = dt.NewRow();
			dt.Rows.Add(dr);
			//2.创建空行
			dt.Rows.Add();
			//3.通过行框架创建并赋值
			dt.Rows.Add("张三", DateTime.Now);//Add里面参数的数据顺序要和dt中的列的顺序对应 
																			//4.通过复制dt2表的某一行来创建
																			// dt.Rows.Add(dt2.Rows[i].ItemArray);
		}



	}
}
