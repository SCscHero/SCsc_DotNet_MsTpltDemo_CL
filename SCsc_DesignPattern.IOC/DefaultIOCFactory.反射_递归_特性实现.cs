using SCsc_DesignPattern.IOC._Attribute;
using System.Reflection;

namespace SCsc_DesignPattern.IOC
{
	/// <summary>
	/// 创建一个IOC工厂（通用）
	/// List：数组
	/// Set：链表
	/// 字典：优先选择，效率高
	/// 集合当中
	/// （保证查询效率和唯一性）
	/// </summary>
	public class DefaultIOCFactory
	{
		/// <summary>
		/// 1、IOC容器(存储对象)
		/// </summary>
		private Dictionary<string, object> iocContainer = new Dictionary<string, object>();

		/// <summary>
		/// 1、IOCType容器(缓存Type)
		/// </summary>
		private Dictionary<string, Type> iocTypeContainer = new Dictionary<string, Type>();

		/// <summary>
		/// 创建IOC工厂
		/// 【步骤1】创建对象
		/// 【步骤2】存储对象
		/// 【步骤3】对象和其属性赋值
		/// 【步骤4】通过特性标记需要创建的类，来替代所有类的创建
		/// </summary>
		public DefaultIOCFactory()
		{
			/*Student student = new Student();
			Teacher teacher = new Teacher();
			// 1、违背开闭原则。*/

			// 1、加载项目中所有类型(反射类型的集合)
			Assembly assembly = Assembly.Load("SCsc_DesignPattern.IOC");
			// 2、使用反射从程序集获取所有对象类型存储到FullName的字典中
			Type[] types = assembly.GetTypes();
			foreach (var type in types)
			{
				//【步骤4】只动态缓存被特性标记了的类
				IOCService iOCService = type.GetCustomAttribute<IOCService>();
				if (iOCService == null)
				{
					continue;
				}

				iocTypeContainer.Add(type.FullName, type);
			}
			foreach (var type in types)
			{
				//【步骤4】只动态创建被特性标记了的类
				IOCService iOCService = type.GetCustomAttribute<IOCService>();
				if (iOCService == null)
				{
					continue;
				}

				// 2.1 创建对象（student）
				object obj = CreateObject(type, types);
				//【非最优解】【硬编码实现，违背了开闭原则】2.1.1为对象的属性teacher赋值
				//PropertyInfo propertyInfo = type.GetProperty("teacher");
				//propertyInfo.SetValue(obj, new Teacher());


				// 3、如何存储对象
				// FullName是命令空间+类名，作为字典Key
				iocContainer.Add(type.FullName, obj);
			}
		}

		public object GetObject(string typeName)
		{
			return iocContainer[typeName];
		}

		/// <summary>
		/// 递归创建子属性孙子属性，实现思路：
		/// 【1】创建对象、属性赋值的代码抽象出来；
		/// 【2】如果是树形结构，即属性对象仍存在属性对象的情况，如果仍适用于该方法；
		/// 【3】递归调用；
		/// 【4】通过特性识别需要过滤的属性；
		/// 空间换时间的算法思想
		/// 时间换空间：局部临时变量实现
		/// </summary>
		public object CreateObject(Type type, Type[] types)
		{
			object _object = Activator.CreateInstance(type);
			foreach (var propertyInfo in type.GetProperties())
			{
				if (propertyInfo.GetCustomAttribute<IOCInject>() == null)
					continue;
				Type type1 = iocTypeContainer[propertyInfo.PropertyType.FullName];
				object _objectvalue = CreateObject(type1, types);
				propertyInfo.SetValue(_object, _objectvalue);
			}
			return _object;
		}

	}
}
