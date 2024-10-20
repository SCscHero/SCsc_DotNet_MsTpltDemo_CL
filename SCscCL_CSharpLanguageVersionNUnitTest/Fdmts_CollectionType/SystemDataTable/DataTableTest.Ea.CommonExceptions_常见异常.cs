using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType.SystemDataTable {
    public partial class DataTableTest {
        [Test]
        public void 列重复() {
            System.Console.WriteLine(@$"UT Excuted {nameof(DataTableTest)}_{nameof(列重复)}");
            // Act & Assert  
            bool exceptionThrown = false;
            try {
                // Arrange  
                DataTable table = new DataTable("TestTable");
                DataColumn firstColumn = new DataColumn("ID", typeof(int));
                table.Columns.Add(firstColumn);
                DataColumn duplicateColumn = new DataColumn("ID", typeof(int)); // 尝试添加重复的列  
                table.Columns.Add(duplicateColumn);
            } catch(ArgumentException ex) {
                exceptionThrown=true;
            } finally {
                // 使用Assert来验证是否捕获到了预期的异常  
                Assert.IsTrue(exceptionThrown, "Adding a duplicate column to a DataTable should throw an ArgumentException.");
                System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
            }
        }
    }
}

