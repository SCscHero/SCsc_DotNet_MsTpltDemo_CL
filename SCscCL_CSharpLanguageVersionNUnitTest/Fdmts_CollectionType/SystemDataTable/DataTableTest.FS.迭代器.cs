using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType.SystemDataTable {

  public partial class DataTableTest {
    [Test]
    public void AsEnumerable_Select() {

      System.Console.WriteLine(@$"UT Excuted {nameof(DataTableTest)}_{nameof(AsEnumerable_Select)}");
      int index = 1;//Column Index
      
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    [Test]
    public void NewHashSetWithGenericityByErc() {

      System.Console.WriteLine(@$"UT Excuted {nameof(DataTableTest)}_{nameof(NewHashSetWithGenericityByErc)}");
      int index = 1;//Column Index
      var hsString = new HashSet<string>(employeeDt.AsEnumerable().Select(x => Convert.ToString(x[index])));
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
