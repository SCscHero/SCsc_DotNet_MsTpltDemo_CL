using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType {
    public partial class ListTest {

        [Test]
        public void List_String数组转ListString时不同遍历方式影响排序() {
            // 声明并初始化字符串数组  
            string[] myArray = new string[3] { "成员1", "成员2", "成员3" };
            List<string> myList = new List<string> { "元素1", "元素2", "元素3", "元素4", "元素5" };

            var resForeach = ArrToListForeach(myArray,myList);
            var resFor = ArrToListFor(myArray, myList);

            // 打印数组中的每个元素  

        }

        private static List<string> ArrToListForeach(string[] arr, List<string> listString = null, int insertPostion = 2) {
            List<string> headers = new List<string>();
            for(int i = 0; i<=arr.Length-1; i++) {
                headers.Add(arr[i]);
            }
            if(listString!=null&&listString.Count>0) {
                foreach(string str in listString) {
                    headers.Insert(insertPostion, str);
                }
            }
            return headers;
        }

        private static List<string> ArrToListFor(string[] arr, List<string> listString = null, int insertPostion = 2) {
            List<string> headers = new List<string>();
            for(int i = 0; i<=arr.Length-1; i++) {
                headers.Add(arr[i]);
            }
            if(listString!=null&&listString.Count>0) {
                for(int i = 0; i<=listString.Count-1; i++) {
                    headers.Insert(insertPostion+i, listString[i]);
                }
            }
            return headers;
        }
    }
}
