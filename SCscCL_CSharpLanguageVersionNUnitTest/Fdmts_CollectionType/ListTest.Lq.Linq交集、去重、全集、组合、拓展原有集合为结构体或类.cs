using System;
using System.Collections.Generic;
using System.Linq;

namespace CsLangVersion.Fdmts_CollectionType {
    public partial class ListTest {



    /// <summary>
    /// TODO
    /// </summary>
    [Test]
    public void List_Distinct_Test() {
      IList<int> intList1 = new List<int>() { 0, 5, 7, 1, 3, 4 };
      IList<int> intList2 = new List<int>() { 1, 3, 5, 0, 0, 7 };

      var IntersectList = intList1.Intersect(intList2);

      //var res1 = decimal.Compare(dec1, dec2);//0
      //var res2 = decimal.Compare(dec2, dec2);//0
      //var res3 = decimal.Compare(dec1, dec3);//-1
      Console.ReadLine();
    }

    #region TestModel
    private struct MoreStruct {
      public int intVal;
      public string strVal;
    }

    private class MoreClass {
      public int intVal;
      public string strVal;
    }
    #endregion

    /// <summary>
    /// listLInq一对多列
    /// </summary>
    [Test]
    public void List_EleOne2More_Test() {
      //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(select_CSharpKeyword)%3Bk(SolutionItemsProject)%3Bk(DevLang-csharp)%26rd%3Dtrue

      List<int> needToTransformedList = new List<int>() { 0, 5, 7, 1, 3, 4, 6, 8, 2, 0, 5, 6, 7 };
      var moreAnonymousArray = (from list in needToTransformedList
                                select new { queryInt = list, strEmpty = "" }).ToArray();
      for(int i = 0; i<moreAnonymousArray.Count(); i++) {
        //moreAnonymousArray[i].strEmpty = $@"Custom";
      }

      //选择1：Linq转换成匿名对象，但注意该集合是只读的。
      var moreAnonymousList = (from list in needToTransformedList
                               select new { queryInt = list, strEmpty = "" }).ToList();
      for(int i = 0; i<moreAnonymousList.Count(); i++) {
        //moreAnonymousList[i] with { strEmpty = "xxx"};
        //Error CS0201  Only assignment, call, increment, decrement, await, and new object expressions can be used as a statement



        //moreAnonymous[i].strEmpty = "xxx";
        //Error CS0021  Cannot apply indexing with[] to an expression of type 'IEnumerable<<anonymous type: int queryInt, string strEmpty>>'  
        //Error CS0200  Property or indexer '<anonymous type: int queryInt, string strEmpty>.strEmpty' cannot be assigned to --it is read only
      }
      ;
      //转换为Class
      var moreClass = (from list in needToTransformedList
                       select new MoreClass { intVal=list, strVal="" }).ToList();
      for(int i = 0; i<moreClass.Count; i++) {
        moreClass[i].strVal=$"intVal={moreClass[i].intVal.ToString()};";
      }
      //compile error:转换为Struct
      var moreStructToList = (from list in needToTransformedList
                              select new MoreStruct { intVal=list, strVal="" }).ToList();
      for(int i = 0; i<moreStructToList.Count; i++) {
        ////compile error CS1612:Cannot modify the return value of 'List<ListTest.MoreStruct>.this[int]' because it is not a variable
        //moreStructToList[i].strVal = $"intVal={moreStructToList[i].intVal.ToString()};";
      }
      //转换为Struct的Array
      var moreStructArray = (from list in needToTransformedList
                             select new MoreStruct { intVal=list, strVal="" }).ToArray();
      for(int i = 0; i<moreStructArray.Count(); i++) {
        moreStructArray[i].strVal=$"intVal={moreStructArray[i].intVal.ToString()};";
      }

      var dic = needToTransformedList.ToDictionary(r => System.Guid.NewGuid().ToString("D"), r => new MoreClass() { intVal=r, strVal=$"{r.ToString()}'s String" });
      var dic1 = needToTransformedList.ToDictionary(r => System.Guid.NewGuid().ToString("D"), r => new { intVal = r, strVal = $"{r.ToString()}'s String" });

      Console.WriteLine();
    }


    /// <summary>
    /// 取交集
    /// </summary>
    [Test]
    public void List_Intersect_Test() {
      IList<int> listInt1 = new List<int>() { 0, 5, 7, 1, 3, 4 };
      IList<int> listInt2 = new List<int>() { 1, 3, 5, 0, 0, 7 };

      var IntersectList = listInt1.Intersect(listInt2);

      //var res1 = decimal.Compare(dec1, dec2);//0
      //var res2 = decimal.Compare(dec2, dec2);//0
      //var res3 = decimal.Compare(dec1, dec3);//-1
      Console.ReadLine();
    }
  }
}
