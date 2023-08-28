using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsLangVersion.Fdmts_Reflection
{
    public class ReflectionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private class Student
        {
            public int Name { get; set; }
        }
        [Test]
        public void 反射_确定类型是否为泛型_Eq01()
        {
            Type t1 = typeof(Dictionary<string, Student>);
            Console.WriteLine("Namespace>>>" + t1.Namespace);
            Console.WriteLine("Assembly>>>" + t1.Assembly);
            Console.WriteLine("IsGenericType>>>" + t1.IsGenericType);
            Console.WriteLine("IsGenericTypeDefinition>>>" + t1.IsGenericTypeDefinition);
        }

        [Test]
        public void 反射_获取泛型类型参数_Eq02()
        {
            Type t1 = typeof(Dictionary<string, Student>);
            Type[] typeParams = t1.GetGenericArguments();
            Console.WriteLine($"List {typeParams.Length} type arguments:");
            foreach (var item in typeParams)
            {
                if (item.IsGenericParameter)
                {
                    DisplayGenericParameter_Eq02(item);
                }
                else
                {
                    Console.WriteLine("Type argument: {0}", item);
                }
            }
        }
        private static void DisplayGenericParameter_Eq02(Type tp)
        {
            Console.WriteLine("      Type parameter: {0} position {1}", tp.Name, tp.GenericParameterPosition);
        }

        /// <summary>
        /// Ref:https://learn.microsoft.com/zh-cn/dotnet/framework/reflection-and-codedom/how-to-examine-and-instantiate-generic-types-with-reflection
        /// </summary>
        [Test]
        public void 反射_获取父类类型_Eq03()
        {
            //1.获取其基类的类型
            var rflRes = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(EfTypeMap_Eq03<>)));
            foreach (var item in rflRes)
            {
                Console.WriteLine("Assembly：" + item.Assembly);
                Console.WriteLine("FullName：" + item.FullName);
                Console.WriteLine("GenericTypeArguments：" + item.GenericTypeArguments);
                Console.WriteLine("BaseType：" + item.BaseType);//获取其基类的类型
                Console.WriteLine("ParentClassName：" + item.BaseType.Name);
                var parentClassGenericT = item?.BaseType?.GetGenericArguments().Where(r => r == typeof(Bas_Menu)).FirstOrDefault();
                Console.WriteLine("ParentClass.IsGenericType：" + ((item.BaseType?.IsGenericType ?? false)).ToString());//获取其基类的类型

                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                //var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                //configuration.ApplyConfiguration(modelBuilder);
            }

        }
        private class BaseEntity_Eq03 { }
        private interface IEfTypeMap_Eq03<T> where T : BaseEntity_Eq03
        {
            void Configure();
        }
        private class EfTypeMap_Eq03<T> : IEfTypeMap_Eq03<T> where T : BaseEntity_Eq03
        {
            public void Configure()
            {

            }
        }
        private class Bas_Menu : BaseEntity_Eq03 { public string MenuName { get; set; } }
        private class Bas_MenuFl : EfTypeMap_Eq03<Bas_Menu> { }


        private class Room_Eq04 { }
        private class Kitchen_Eq04 : Room_Eq04 { }
        private class Bedroom_Eq04 : Room_Eq04 { }
        private class Guestroom_Eq04 : Bedroom_Eq04 { }
        private class MasterBedroom_Eq04 : Bedroom_Eq04 { }
        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/api/system.type.isassignablefrom?view=net-8.0
        /// </summary>
        [Test]
        public void 反射_IsAssignableFrom函数根据基类Type获取遍历_Eq04()
        {
            // Demonstrate classes:
            Console.WriteLine("Defined Classes:");
            Room_Eq04 room1 = new Room_Eq04();
            Kitchen_Eq04 kitchen1 = new Kitchen_Eq04();
            Bedroom_Eq04 bedroom1 = new Bedroom_Eq04();
            Guestroom_Eq04 guestroom1 = new Guestroom_Eq04();
            MasterBedroom_Eq04 masterbedroom1 = new MasterBedroom_Eq04();

            Type room1Type = room1.GetType();
            Type kitchen1Type = kitchen1.GetType();
            Type bedroom1Type = bedroom1.GetType();
            Type guestroom1Type = guestroom1.GetType();
            Type masterbedroom1Type = masterbedroom1.GetType();

            Console.WriteLine("room assignable from kitchen: {0}", room1Type.IsAssignableFrom(kitchen1Type));
            Console.WriteLine("bedroom assignable from guestroom: {0}", bedroom1Type.IsAssignableFrom(guestroom1Type));
            Console.WriteLine("kitchen assignable from masterbedroom: {0}", kitchen1Type.IsAssignableFrom(masterbedroom1Type));

            // Demonstrate arrays:
            Console.WriteLine();
            Console.WriteLine("Integer arrays:");

            int[] array2 = new int[2];
            int[] array10 = new int[10];
            int[,] array22 = new int[2, 2];
            int[,] array24 = new int[2, 4];

            Type array2Type = array2.GetType();
            Type array10Type = array10.GetType();
            Type array22Type = array22.GetType();
            Type array24Type = array24.GetType();

            Console.WriteLine("int[2] assignable from int[10]: {0}", array2Type.IsAssignableFrom(array10Type));
            Console.WriteLine("int[2] assignable from int[2,4]: {0}", array2Type.IsAssignableFrom(array24Type));
            Console.WriteLine("int[2,4] assignable from int[2,2]: {0}", array24Type.IsAssignableFrom(array22Type));

            // Demonstrate generics:
            Console.WriteLine();
            Console.WriteLine("Generics:");

            // Note that "int?[]" is the same as "Nullable<int>[]"
            int?[] arrayNull = new int?[10];
            List<int> genIntList = new List<int>();
            List<Type> genTList = new List<Type>();

            Type arrayNullType = arrayNull.GetType();
            Type genIntListType = genIntList.GetType();
            Type genTListType = genTList.GetType();

            Console.WriteLine("int[10] assignable from int?[10]: {0}", array10Type.IsAssignableFrom(arrayNullType));
            Console.WriteLine("List<int> assignable from List<Type>: {0}", genIntListType.IsAssignableFrom(genTListType));
            Console.WriteLine("List<Type> assignable from List<int>: {0}", genTListType.IsAssignableFrom(genIntListType));

            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void 反射_使用Is关键字判断类型的误区_Eq05()
        {

            Console.WriteLine(@"typeof(Apple_Eq05).GetInterfaces().FirstOrDefault()>>>" + typeof(Apple_Eq05).GetInterfaces()?.Where(r => r.Name == nameof(IPhotosynthesis_Eq05))?.FirstOrDefault()?.Name ?? "Empty");
            Console.WriteLine(@"使用Type is Type做判断>>>>>>>>>>>");
            Console.WriteLine(@"typeof(Apple_Eq05).GetInterfaces()?.Where(r => r.Name == nameof(IPhotosynthesis_Eq05))?.FirstOrDefault()>>>" + (typeof(Apple_Eq05).GetInterfaces()?.Where(r => r.Name == nameof(IPhotosynthesis_Eq05))?.FirstOrDefault() is IPhotosynthesis_Eq05));


            Console.WriteLine(@"使用instance is Type做判断>>>>>>>>>>>");
            Console.WriteLine(Activator.CreateInstance(typeof(Apple_Eq05)) is IPhotosynthesis_Eq05);

            Console.WriteLine(@"或者使用IsAssignableFrom>>>>Ref：https://www.cnblogs.com/radray/p/4529482.html");
            Console.WriteLine("使用IsAssignableFrom判断Apple是不是继承与IsAssignableFrom：" + typeof(Apple_Eq05).IsAssignableFrom(typeof(IPhotosynthesis_Eq05)));
        }
        private interface IPhotosynthesis_Eq05
        {
            void AbsorbingEnergy();
        }
        private class Botany_Eq05 : IPhotosynthesis_Eq05
        {
            public virtual void AbsorbingEnergy()
            {
                Console.WriteLine("光合作用");
            }
        }
        private class Apple_Eq05 : Botany_Eq05 { }

        private class Eq06_People
        {
            public string Name = "SCscHero";
            public void GetName()
            {
                Console.WriteLine(Name);
            }
            public void GetName(string newName)
            {
                Console.WriteLine(newName);
            }
        }
        [Test]
        public void 反射_通过GetField方法获得类的Symbol()
        {
            var fieldName = typeof(Eq06_People).GetField(nameof(Eq06_People.Name));
        }
        [Test]
        public void 反射_通过GetMethod方法获得类的Symbol_重载情况()
        {
            try
            {
                //var methodGetName = typeof(Eq06_People).GetMethod(nameof(Eq06_People.GetName));//Exception: Not found.
                //需要输入对应参数才能找到相应的Method
                var methodGetName = typeof(Eq06_People).GetMethod(nameof(Eq06_People.GetName),new Type[0]);
                var methodGetName1 = typeof(Eq06_People).GetMethod(nameof(Eq06_People.GetName), new Type[] { typeof(string) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private class MyFieldClassA
        {
            public string Field = "A Field";
        }

        private class MyFieldClassB
        {
            private string field = "B Field";
            public string Field
            {
                get
                {
                    return field;
                }
                set
                {
                    if (field != value)
                    {
                        field = value;
                    }
                }
            }
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/api/system.type.getfield?view=net-7.0&devlangs=csharp&f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.Type.GetField)%3Bk(SolutionItemsProject)%3Bk(DevLang-csharp)%26rd%3Dtrue#code-try-2
        /// </summary>
        [Test]
        public void 反射_通过GetField方法获得类的Symbol_官方()
        {
            MyFieldClassB myFieldObjectB = new MyFieldClassB();
            MyFieldClassA myFieldObjectA = new MyFieldClassA();

            Type myTypeA = typeof(MyFieldClassA);
            FieldInfo myFieldInfo = myTypeA.GetField("Field");

            Type myTypeB = typeof(MyFieldClassB);
            FieldInfo myFieldInfo1 = myTypeB.GetField("field",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("The value of the public field is: '{0}'",
                myFieldInfo.GetValue(myFieldObjectA));
            Console.WriteLine("The value of the private field is: '{0}'",
                myFieldInfo1.GetValue(myFieldObjectB));
        }
    }
}