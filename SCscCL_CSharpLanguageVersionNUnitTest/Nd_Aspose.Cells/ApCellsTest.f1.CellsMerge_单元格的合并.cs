using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Nd_Aspose.Cells {
  public partial class ApCellsTest {
        [Test]
        public void TestMergeCells() {
            // 创建工作簿
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];
            // 合并单元格 A1:B2
            worksheet.Cells.Merge(0, 0, 4, 2);
            // 设置合并后单元格的值
            worksheet.Cells[0, 0].PutValue("合并后的单元格内容");
            workbook.Save(dlMergeXlsx);
        }

        [Test]
        public void TestUnmergeCells() {
            // 创建工作簿
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            // 先合并一些单元格
            worksheet.Cells.Merge(0, 0, 3, 3);

            // 取消合并
            worksheet.Cells.UnMerge(0, 0,1,1);
            workbook.Save(dlUnMergeXlsx);

        }
    }
}
