using System.Text;

namespace SCscCL_HighQuality157Code._01_��������Ҫ��
{
    [TestClass]
    public class _3_��ȷʹ���ַ���
	{
        [TestMethod]
        public void ��ȷ�����ַ���()
        {
            string inCorrectStr = "str1" + 9;//�����װ��Ͳ�����Ϊ��
            string correctStr = "str2" + 9.ToString();//Ч�ʱ�װ�����ߡ�
        }

        #region ������������ڴ�ռ�
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ������������ڴ�ռ�EQ1()
        {
            //eq1:����д���ײ���õĸ���Ч�ʣ�
            //�������д��봴����3���ַ������󣬲�ִ����һ��string.Contact������
            string s1 = "abc";
            s1 = "" + s1 + "356";

            //�÷���������һ��װ�䣬��������һ��string.Contact������
            string s2 = 9 + "456";

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ������������ڴ�ռ�EQ2_1()
        {
            #region eq2:����д�����ӽ�ʡ�ռ䣬����Ч�ʣ�
            string str1 = "t";
            str1 += "e";
            str1 += "s";
            str1 += "t";

            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            string str2 = a + b + c + d;
            //����д�����������ַ�������������ȡ���ǰ��Ч�ʸ��ͣ�ԭ���ǵ�����3��string.Contact������������ֻ������1�Ρ�
            #endregion
        }
        /// <summary>
        /// ʹ��StringBuilder���Ż�
        /// </summary>
        [TestMethod]
        public void ������������ڴ�ռ�EQ2_2()
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
        /// ʹ��String.Format�ȼ�д��
        /// </summary>
        [TestMethod]
        public void ������������ڴ�ؼ�EQ2_3()
        {
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            //����д�����ǵڶ���д���Ľ��װ棬ͬʱ���и�string.Format���������Լ�����д����
            string strFormat = string.Format("{0}{1}{2}{3}", a, b, c, d);
        }

        /// <summary>
        /// ʹ��dollar�ؼ����﷨�ǵײ����Ч�ʶԱ�
        /// </summary>
        [TestMethod]
        public void ������������ڴ�ռ�EQ2_4()
        {
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            string dollarStr = $"{a}{b}{c}{d}";
            //��IL�����Ʋ⣬Ӧ����ʹ��dollar��ƴ����ʡ�ռ䡣
        }
        #endregion

        [TestMethod]
        public void �ַ���ƴ�ӵ�Ч()
        {
            //��������д���ȼۣ�����������ʱƴ�ӣ������ڱ���ʱ����һ���ַ�����
            string eq1EquationStr1 = "111" + "222" + "333";
            string eq1EquationStr2 = "111222333";

            //��������д���ȼۣ�CLR�Ὣ��������һ����̬�ַ�������
            const string eq2Const = "t";
            string eq2EquationStr1 = "111t";
            string eq2EquationStr2 = "111" + eq2Const;


        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ʹ��StringBuilder���ֲ�string���������()
        {
            //��Tips��ʹ��StringBuilderԤ��˼�������ĳ��ȣ�����ռ��˷��Լ�Ƶ�������ڴ档
            //StringBuilder���������´���һ��string��������Ч��Դ��Ԥ���Է��йܵķ�ʽ�����ڴ档���StringBuilderû���ȶ��峤�ȣ���Ĭ�Ϸ���ĳ���Ϊ16����StringBuilder�ַ�������С�ڵ���16ʱ��StringBuilder�������·����ڴ棻��StringBuilder�ַ����ȴ���16С��32ʱ��StringBuilder�ֻ����·����ڴ棬ʹ֮��Ϊ16�ı�����������Ĵ����У����Ԥ���ж��ַ����ĳ��Ƚ�����16�������Ϊ���趨һ�����Ӻ��ʵĳ��ȣ���32����StringBuilder���·����ڴ�ʱ�ǰ����ϴ������ӱ����з���ġ���Ȼ��������Ҫע�⣬StringBuilderָ���ĳ���Ҫ���ʣ�̫С�ˣ���ҪƵ�������ڴ棬̫���ˣ��˷ѿռ䡣
            string str = "abcdefghijklmnopqrstuvwxyz";
            var sbStr = new StringBuilder(26);
        }

    }
}