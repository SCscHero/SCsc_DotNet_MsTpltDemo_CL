using System;
using System.Text.Json.Serialization;

namespace CsLangVersion.Fdmts_Keyword
{
    /// <summary>
    /// TODO:Record关键字使用【Ref】https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record?devlangs=csharp&f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(record_CSharpKeyword)%3Bk(SolutionItemsProject)%3Bk(DevLang-csharp)%26rd%3Dtrue
    /// 从c# 9开始，您可以使用record修饰符来定义一个引用类型，该类型提供了封装数据的内置功能。
    /// </summary>
    internal class recordSyntax
    {
        //下面两个例子演示了记录(或记录类)引用类型:
        // 在记录上声明主构造函数时，编译器会为主构造函数参数生成公共属性。记录的主要构造函数参数称为位置参数。编译器创建镜像主构造函数或位置参数的位置属性。编译器不会在没有记录修饰符的类型上合成主构造函数参数的属性。
        private record Person(string FirstName, string LastName);
        private record Person1
        {
            public required string FirstName { get; init; }
            public required string LastName { get; init; }
        };

        //下面两个例子演示了记录结构的值类型:
        private readonly record struct Point(double X, double Y, double Z);
        private record struct Point1
        {
            public double X { get; init; }
            public double Y { get; init; }
            public double Z { get; init; }
        }
        //你也可以创建带有可变属性和字段的记录:
        private record Person3
        {
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
        };
        //记录结构也可以是可变的，包括位置记录结构和没有位置参数的记录结构:
        private record struct DataMeasurement(DateTime TakenAt, double Measurement);
        private record struct Point4
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }
        private record Eq1_Person(string FirstName, string LastName);


        //记录声明中提供的每个位置参数的公共自动实现属性。
        //对于记录类型和只读记录结构类型:一个仅初始化属性。
        //对于记录结构类型:一个读写属性。
        //一个主构造函数，其参数与记录声明中的位置参数匹配。
        //对于记录结构类型，将每个字段设置为默认值的无参数构造函数。
        //一个解构方法，对于记录声明中提供的每个位置参数都有一个out参数。该方法解构使用位置语法定义的属性;它忽略使用标准属性语法定义的属性。
        [Test]
        public void 使用record_Positional文法示例()
        {
            Person person = new("Nancy", "Davolio");
            Console.WriteLine(person);
            // output: Person { FirstName = Nancy, LastName = Davolio }
        }

        //您可能希望向编译器从记录定义中创建的任何这些元素添加属性。可以将目标添加到应用于位置记录属性的任何属性中。下面的示例将System.Text.Json.Serialization.JsonPropertyNameAttribute应用于Person记录的每个属性。target表示该属性应用于编译器生成的属性。其他值为field:将属性应用于字段，param:将属性应用于参数。
        public record Person5([property: JsonPropertyName("firstName")] string FirstName,
        [property: JsonPropertyName("lastName")] string LastName);

        [Test]
        public void 使用record()
        {

        }
    }
}
