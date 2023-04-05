using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsLangVersion.CsharpFundamentals_Operator
{
    /// <summary>
    /// TODO:暂以中文命名，简单清晰。
    /// </summary>
    public class 问号点操作符Test
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Eq1_问号点操作符TestModel
        private class Eq1_RawData
        {
            public string Code { set; get; }
            public string Name { set; get; }
        }
        #endregion

        [Test]
        public void Eq1_问号点操作符TestModel()
        {
            List<Eq1_RawData> mList = new List<Eq1_RawData>() {
                new Eq1_RawData{Code="s1",Name="s1Name"},
                new Eq1_RawData{Code="s2",Name="s2Name"}
            };

            var filterM1 = mList?.Where(r => r.Code == "s1").FirstOrDefault();
            Console.WriteLine(filterM1?.Name??"Default");

            List<Eq1_RawData> mListNull = null;
            var filterM2 = mListNull?.Where(r => r.Code == "s1").FirstOrDefault();
            Console.WriteLine(filterM2?.Name??"Default");

            Assert.Pass();
        }
    }
}
