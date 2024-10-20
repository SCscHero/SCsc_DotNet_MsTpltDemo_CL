using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType.SystemDataTable {
    public partial class DataTableTest {
        [Test]
        public void TestCountColumnsWithRT() {
            DataTable table = new DataTable();
            table.Columns.Add("Column1");
            table.Columns.Add("RTColumn2");
            table.Columns.Add("AnotherColumn");
            table.Columns.Add("RTColumn4");

            int result = DataTableTest.CountColumnsWithRT(table);

            Assert.AreEqual(2, result);
        }
        public static int CountColumnsWithRT(DataTable table) {
            return table.Columns.Cast<DataColumn>().Count(column => column.ColumnName.Contains("RT"));
        }




        [Test]
        public void TestChangeColumnName() {
            DataTable table = new DataTable();
            table.Columns.Add("OldColumnName");
            // 更改列名
            table.Columns["OldColumnName"].ColumnName="NewColumnName";
            // 验证列名是否更改成功
            Assert.AreEqual("NewColumnName", table.Columns[0].ColumnName);
        }





    }
}
