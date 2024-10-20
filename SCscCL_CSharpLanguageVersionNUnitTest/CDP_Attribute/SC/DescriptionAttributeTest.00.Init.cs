using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsLangVersion.Fdmts_Keyword.staticSyntaxTest;

namespace CsLangVersion.CDP_Attribute.SC {
    public partial class DescriptionAttributeTest {

        [Description("This is My Sample Method's Description")]
        public void SampleMethod() {

        }

        [Test]
        public void GetDescriptionOfSampleMethod() {
            System.Console.WriteLine(@$"UT Excuted {nameof(DescriptionAttributeTest)}_{nameof(GetDescriptionOfSampleMethod)}");
            var methodInfo = typeof(DescriptionAttributeTest).GetMethod(nameof(SampleMethod));
            var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(DescriptionAttribute));
            if(descriptionAttribute!=null) {
                Console.WriteLine(descriptionAttribute.Properties["Description"][0]);
            }
            System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
        }


    }
}
