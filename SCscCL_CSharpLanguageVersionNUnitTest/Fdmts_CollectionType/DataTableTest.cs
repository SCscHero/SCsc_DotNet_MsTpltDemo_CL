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
