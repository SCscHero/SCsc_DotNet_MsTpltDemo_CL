using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Nd_Aspose.Cells {
    public partial class ApCellsTest {
        [Test]
        public void TestSetBorder() {
            // 创建工作簿
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];
            // 设置单元格值
            worksheet.Cells[0, 0].PutValue("Test Cell");
            // 获取样式对象
            Style style = worksheet.Cells[0, 0].GetStyle();
            // 设置边框
            style.Borders[BorderType.TopBorder].LineStyle=CellBorderType.Thin;
            style.Borders[BorderType.BottomBorder].LineStyle=CellBorderType.Thin;
            style.Borders[BorderType.LeftBorder].LineStyle=CellBorderType.Thin;
            style.Borders[BorderType.RightBorder].LineStyle=CellBorderType.Thin;
            // 应用样式到单元格
            worksheet.Cells[0, 0].SetStyle(style);
            // 验证边框设置
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.TopBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.BottomBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.LeftBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.RightBorder].LineStyle);
            workbook.Save(dlBorderXlsx);
        }

        [Test]
        public void TestSetBatchCellBorder() {
            // 创建工作簿
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            // 设置多个单元格的值
            worksheet.Cells[0, 0].PutValue("Cell1");
            worksheet.Cells[0, 1].PutValue("Cell2");
            worksheet.Cells[1, 0].PutValue("Cell3");
            worksheet.Cells[1, 1].PutValue("Cell4");
            worksheet.Cells[2, 1].PutValue("Cell5");
            worksheet.Cells[2, 2].PutValue("Cell2-2");
            worksheet.Cells[3, 1].PutValue("Cell6");
            worksheet.Cells[3, 2].PutValue("Cell3-2");

            // 获取样式对象
            Style style = workbook.CreateStyle();

            // 设置边框
            style.Borders[BorderType.TopBorder].LineStyle=CellBorderType.Thin;
            style.Borders[BorderType.BottomBorder].LineStyle=CellBorderType.Thin;
            style.Borders[BorderType.LeftBorder].LineStyle=CellBorderType.Thin;
            style.Borders[BorderType.RightBorder].LineStyle=CellBorderType.Thin;

            // 应用样式到指定范围的单元格：从1行1列开始，向下两行，向右三列的范围内；
            worksheet.Cells.CreateRange(0, 0, 2, 3).SetStyle(style);
            //worksheet.Cells.CreateRange(1, 0, 1, 1).SetStyle(style);

            // 验证边框设置
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.TopBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.BottomBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.LeftBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[0, 0].GetStyle().Borders[BorderType.RightBorder].LineStyle);

            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[1, 0].GetStyle().Borders[BorderType.TopBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[1, 0].GetStyle().Borders[BorderType.BottomBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[1, 0].GetStyle().Borders[BorderType.LeftBorder].LineStyle);
            Assert.AreEqual(CellBorderType.Thin, worksheet.Cells[1, 0].GetStyle().Borders[BorderType.RightBorder].LineStyle);
            workbook.Save(dlBorderBulkXlsx);
        }
    }
}
