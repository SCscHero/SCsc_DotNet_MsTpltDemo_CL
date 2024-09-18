using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Keyword {
  internal partial class ExceptionTest {
    [Test]
    public void List_First若找不到则会报错() {
      try {

      } catch(Exception ex) {

        System.Console.WriteLine(@$"SCscHero={DateTime.Now.ToString("HHmmss")}====
SCscHeroDesc");
        throw ex;
      }


      try {
        var strings = new List<string>() { "AB", "BA" };
        strings.First(r => r=="SC");
      } catch(Exception ex) {
        Assert.IsTrue(ex is System.InvalidOperationException);
        throw ex;
      }
      //    System.InvalidOperationException: Sequence contains no matching element
      //+System.Linq.ThrowHelper.ThrowNoMatchException()
      //+System.Linq.Enumerable.First<TSource>(IEnumerable<TSource>, Func<TSource, bool>)

      //System.InvalidOperationException: Sequence contains no matching element
      //at System.Linq.ThrowHelper.ThrowNoMatchException()
      //at Repo4SCscHero.GetUserPropt(string Input)\n at lambda_method11(Closure, Object, Object[])
    }
  }
}
