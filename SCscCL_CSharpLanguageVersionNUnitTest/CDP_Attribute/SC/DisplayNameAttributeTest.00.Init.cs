using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.CDP_Attribute.SC {
    partial class DisplayNameAttributeTest {
        [DisplayName("This is My Sample Method's DisplayName")]
        public void SampleMethod() {

        }

        [Test]
        public void GetDisplayOfSampleMethod() {
            System.Console.WriteLine(@$"UT Excuted {nameof(DisplayNameAttributeTest)}_{nameof(GetDisplayOfSampleMethod)}");
            var methodInfo = typeof(DisplayNameAttributeTest).GetMethod(nameof(SampleMethod));
            var displayAttr = (DisplayNameAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(DisplayNameAttribute));
            if(displayAttr!=null) {
                Console.WriteLine(displayAttr.DisplayName);
            }
            System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
        }


    }
}
