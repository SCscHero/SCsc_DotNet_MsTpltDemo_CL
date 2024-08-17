using System.Runtime.InteropServices;

namespace CsLangVersion.Hpbms_MemoryMgt {
  public partial class MemoryAddress {
    [SetUp]
    public void Setup() {

    }

    [StructLayout(LayoutKind.Sequential)] // 确保没有额外的填充或对齐  
    private class MyClass() {
      public int Id;
      public string Name;
    }


  }
}
