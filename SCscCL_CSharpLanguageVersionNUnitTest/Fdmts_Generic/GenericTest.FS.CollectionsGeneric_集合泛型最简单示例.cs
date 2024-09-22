using System;
using System.Collections;
using System.Collections.Generic;

namespace CsLangVersion.Fdmts_Generic {
  /// <summary>
  /// GenericTest中文简称泛型
  /// </summary>
  public partial class GenericTest {
    public class Bookshelf {
      public IEnumerable Book { get; set; }
    }
    public class BookshelfWithGeneric {
      public IEnumerable<Book> Book { get; set; }
    }

    public class Book {
      public string BookName { get; set; }
    }

    [Test]
    public void 泛型最基础使用_Demo1() {

      System.Console.WriteLine(@$"UT Excuted {nameof(GenericTest)}_{nameof(泛型最基础使用_Demo1)}");

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
