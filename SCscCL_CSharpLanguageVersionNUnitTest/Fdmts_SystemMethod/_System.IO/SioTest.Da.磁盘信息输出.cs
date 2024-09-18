using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CsLangVersion.Fdmts_SystemMethod._System.IO {
  partial class SioTest {
    [Test]
    public void PrintDriveInfo磁盘信息输出() {
      System.Console.WriteLine(@$"UT Excuted {nameof(SioTest)}_{nameof(PrintDriveInfo磁盘信息输出)}");
      // 获取所有逻辑驱动器的信息  
      DriveInfo[] allDrives = DriveInfo.GetDrives();
      Console.WriteLine($"The number of local disks is{allDrives.Count()}\n----------------------------------------------------");
      foreach(DriveInfo d in allDrives) {
        Console.WriteLine("Drive {0}", d.Name);
        Console.WriteLine("  DriveType: {0}", d.DriveType);

        if(d.IsReady) {
          Console.WriteLine("  DriveFormat: {0}", d.DriveFormat);
          Console.WriteLine("    Total Size: {0:N0} bytes", d.TotalSize);
          Console.WriteLine("    Total Free Space: {0:N0} bytes", d.TotalFreeSpace);

          // 注意：获取卷标可能需要驱动器已准备好并且不是网络驱动器  
          try {
            Console.WriteLine("    Volume Label: {0}", d.VolumeLabel);
          } catch(IOException) {
            Console.WriteLine("    Volume Label: Not available");
          }
          // 还可以进行更复杂的操作，比如列出该驱动器上的目录和文件  
        }
        Console.WriteLine(string.Empty);
        System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
      }
    }
  }
}


