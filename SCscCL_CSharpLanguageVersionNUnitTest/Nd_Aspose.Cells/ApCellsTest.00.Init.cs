using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Nd_Aspose.Cells {
    public partial class ApCellsTest {
        public const string saveMergeXlsxPath = @"%USERPROFILE%\Downloads\UTDemo_AsposeCells.Merge.xlsx";
        public static readonly string dlMergeXlsx = Environment.ExpandEnvironmentVariables(saveMergeXlsxPath);
        public const string saveUnMergeXlsxPath = @"%USERPROFILE%\Downloads\UTDemo_AsposeCells.UnMerge.xlsx";
        public static readonly string dlUnMergeXlsx = Environment.ExpandEnvironmentVariables(saveUnMergeXlsxPath);

        public const string saveBorderXlsxPath = @"%USERPROFILE%\Downloads\UTDemo_AsposeCells.SetBorder.xlsx";
        public static readonly string dlBorderXlsx = Environment.ExpandEnvironmentVariables(saveBorderXlsxPath);
        public const string saveBorderBulkXlsxPath = @"%USERPROFILE%\Downloads\UTDemo_AsposeCells.SetBorderBulk.xlsx";
        public static readonly string dlBorderBulkXlsx = Environment.ExpandEnvironmentVariables(saveBorderBulkXlsxPath);

        [SetUp]
        public void Init_SetUp() {
        
        }

    }
}
