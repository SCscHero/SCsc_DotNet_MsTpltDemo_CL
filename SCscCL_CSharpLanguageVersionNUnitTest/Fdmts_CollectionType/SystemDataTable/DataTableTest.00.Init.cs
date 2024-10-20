using System;
using System.Data;

namespace CsLangVersion.Fdmts_CollectionType.SystemDataTable
{
  [TestFixture]
  public partial class DataTableTest
    {
        //https://www.cnblogs.com/lgx5/p/4813436.html#:~:text=%E5%9C%A8C%23%E4%B8%AD%E8%A6%81%E5%AF%B9Datatable%E6%8E%92%E5%BA%8F%EF%BC%8C%E5%8F%AF%E4%BD%BF%E7%94%A8DefaultView%E7%9A%84Sort%E6%96%B9%E6%B3%95%E3%80%82,%E5%85%88%E8%8E%B7%E5%8F%96Datatable%E7%9A%84DefaultView%EF%BC%8C%E7%84%B6%E5%90%8E%E8%AE%BE%E7%BD%AE%E5%BE%97%E5%88%B0%E7%9A%84Dataview%E7%9A%84sort%E5%B1%9E%E6%80%A7%EF%BC%8C%E6%9C%80%E5%90%8E%E7%94%A8%E8%A7%86%E5%9B%BE%E7%9A%84ToTable%E6%96%B9%E6%B3%95%E5%B0%86%E6%8E%92%E5%A5%BD%E5%BA%8F%E7%9A%84dataview%E5%AF%BC%E5%87%BA%E4%B8%BADatatable%E3%80%82
        [Test]
        public void DataTable排序示例1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(new object[] { 12, "lwolf" });
            dt.Rows.Add(new object[] { 100, "kkkkk" });
            dt.Rows.Add(new object[] { 19, "jim" });
            dt.Rows.Add(new object[] { 1, "test" });

            DataTable dtCopy = dt.Copy();
            DataView dv = dt.DefaultView;
            dv.Sort = "ID DESC";
            dtCopy = dv.ToTable();

            for (int i = 0; i < dtCopy.Rows.Count; i++)
            {
                Console.Write(dtCopy.Rows[i]["ID"] + "--");
                Console.WriteLine(dtCopy.Rows[i]["Name"] + "--");
            }
        }

        [Test]
        public void DataTable字符串类型排序失败示例2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");//因为是字符串，所以排序不对
            dt.Rows.Add("小明", "21");
            dt.Rows.Add("小张", "10");
            dt.Rows.Add("小红", "9");
            dt.Rows.Add("小伟", "7");
            dt.Rows.Add("小美", "3");
            dt.DefaultView.Sort = "Age ASC";
            dt = dt.DefaultView.ToTable();
            Console.WriteLine();
        }

        [Test]
        public void DataTable字符串类型排序示例2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");//因为是字符串，所以排序不对
            dt.Rows.Add("小明", "21");
            dt.Rows.Add("小张", "10");
            dt.Rows.Add("小红", "9");
            dt.Rows.Add("小伟", "7");
            dt.Rows.Add("小美", "3");

            dt.Columns.Add("排序辅助列", typeof(int));//新增排序辅助列
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["排序辅助列"] = Convert.ToInt32(dt.Rows[i]["Age"]);
            }
            dt.DefaultView.Sort = "排序辅助列 ASC";
            dt = dt.DefaultView.ToTable();
            Console.WriteLine();
        }

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
            dt.Columns.Add("column0", Type.GetType("System.String"));
            dt.Columns.Add("column0", typeof(string));
            //3.通过列架构添加列
            DataColumn dc1 = new DataColumn("column1", Type.GetType("System.DateTime"));
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
            table.Columns.Add("colStr1", typeof(string));
            table.Columns.Add("colStr2", Type.GetType("System.String"));
            table.Columns.Add("colInt3", Type.GetType("System.Int32"));
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
                    if (dt.Columns[j].DataType == typeof(string) && dt.Rows[i][j].ToString() == "0")
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
