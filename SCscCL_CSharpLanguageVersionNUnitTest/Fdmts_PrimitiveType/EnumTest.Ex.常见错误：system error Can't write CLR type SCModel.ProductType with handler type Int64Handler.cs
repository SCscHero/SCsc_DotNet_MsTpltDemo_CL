using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType {
    public enum ProductType {
        Unknown = 0,
        Electronics = 1,
        Clothing = 2,
        Food = 3
    }

    public class Product {
        public int Id { get; set; }
        public ProductType Type { get; set; }
    }

    [TestFixture]
    internal partial class EnumTest {
        [Test]
        public void 枚举未显示转换Int报错() {
            var product = new Product() {
                Id=1,
                Type=ProductType.Electronics
            };
            /*The SugarParameter type constructor accepts an object.As follows:*/
            // public SugarParameter(string name, object value) {
            //    Value=value;
            //    ParameterName=name;
            //    if(value!=null) {
            //        SettingDataType(value.GetType());
            //     }
            //}

            /*Enum types can also be passed in, but they will not be correctly converted to INT, and we will need to display the conversion, or throw an error if we don't: system error:Can't write CLR type Product.ProductType with handler type Int64Handler*/

            //var productList = daoHelper.Context.Ado.SqlQuery<ProductEntity>(@"select * from Product where producttype=@ProductType", new SugarParameter[] {
            //      new SugarParameter("@ProductType", product.Type),
            //});
        }
    }
}
