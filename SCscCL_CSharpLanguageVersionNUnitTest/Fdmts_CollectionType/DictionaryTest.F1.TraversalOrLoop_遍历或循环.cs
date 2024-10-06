using System;
using System.Collections.Generic;
using System.Data;

namespace CsLangVersion.Fdmts_CollectionType {
  public partial class DictionaryTest {

    [Test]

    public void Dictionary遍历KeyValuePair() {
      Dictionary<string, string> optionsDic = new Dictionary<string, string>();
      optionsDic.Add("client_id", "client_idTest");
      optionsDic.Add("client_secret", "client_secretTest");
      optionsDic.Add("grant_type", "authorization_codeTest");
      optionsDic.Add("code", "codeTest");

      string res = string.Empty;
      foreach(var item in optionsDic) {
        res+=$"{item.Key}={item.Value}&";
      }
      res=res.Trim('&');
    }

  }
}