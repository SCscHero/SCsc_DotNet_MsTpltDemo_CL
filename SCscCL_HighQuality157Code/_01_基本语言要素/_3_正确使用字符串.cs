using System.Text;

namespace SCscCL_HighQuality157Code._01_基本语言要素
{
    [TestClass]
    public class _3_正确使用字符串
	{
        [TestMethod]
        public void 正确操作字符串()
        {
            string inCorrectStr = "str1" + 9;//会产生装箱和拆箱行为。
            string correctStr = "str2" + 9.ToString();//效率比装箱拆箱高。
        }

        #region 避免分配额外的内存空间
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void 避免分配额外的内存空间EQ1()
        {
            //eq1:哪种写法底层调用的更有效率？
            //以下两行代码创建了3个字符串对象，并执行了一次string.Contact方法。
            string s1 = "abc";
            s1 = "" + s1 + "356";

            //该方法发生了一次装箱，并调用了一次string.Contact方法。
            string s2 = 9 + "456";

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void 避免分配额外的内存空间EQ2_1()
        {
            #region eq2:哪种写法更加节省空间，更有效率？
            string str1 = "t";
            str1 += "e";
            str1 += "s";
            str1 += "t";

            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            string str2 = a + b + c + d;
            //以上写法，创建的字符串对象数量相等。且前者效率更低，原因是调用了3次string.Contact方法。而后者只调用了1次。
            #endregion
        }
        /// <summary>
        /// 使用StringBuilder做优化
        /// </summary>
        [TestMethod]
        public void 避免分配额外的内存空间EQ2_2()
        {
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            StringBuilder sbStr = new StringBuilder(a);
            sbStr.Append(b);
            sbStr.Append(c);
            sbStr.Append(d);
        }
        /// <summary>
        /// 使用String.Format等价写法
        /// </summary>
        [TestMethod]
        public void 避免分配额外的内存控件EQ2_3()
        {
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            //以上写法，是第二种写法的进阶版，同时还有个string.Format方法，可以简化以上写法。
            string strFormat = string.Format("{0}{1}{2}{3}", a, b, c, d);
        }

        /// <summary>
        /// 使用dollar关键字语法糖底层调用效率对比
        /// </summary>
        [TestMethod]
        public void 避免分配额外的内存空间EQ2_4()
        {
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            string dollarStr = $"{a}{b}{c}{d}";
            //从IL层面推测，应该是使用dollar做拼接最省空间。
        }
        #endregion

        [TestMethod]
        public void 字符串拼接等效()
        {
            //以下两句写法等价，不会在运行时拼接，而是在编译时生成一个字符串。
            string eq1EquationStr1 = "111" + "222" + "333";
            string eq1EquationStr2 = "111222333";

            //以下两句写法等价，CLR会将常量当作一个静态字符串处理。
            const string eq2Const = "t";
            string eq2EquationStr1 = "111t";
            string eq2EquationStr2 = "111" + eq2Const;


        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void 使用StringBuilder来弥补string的性能损耗()
        {
            //【Tips】使用StringBuilder预先思考其分配的长度，避免空间浪费以及频繁分配内存。
            //StringBuilder并不会重新创建一个string对象，它的效率源于预先以非托管的方式分配内存。如果StringBuilder没有先定义长度，则默认分配的长度为16。当StringBuilder字符串长度小于等于16时，StringBuilder不会重新分配内存；当StringBuilder字符长度大于16小于32时，StringBuilder又会重新分配内存，使之成为16的倍数。在上面的代码中，如果预先判断字符串的长度将大于16，则可以为其设定一个更加合适的长度（如32）。StringBuilder重新分配内存时是按照上次容量加倍进行分配的。当然，我们需要注意，StringBuilder指定的长度要合适，太小了，需要频繁分配内存，太大了，浪费空间。
            string str = "abcdefghijklmnopqrstuvwxyz";
            var sbStr = new StringBuilder(26);
        }

    }
}