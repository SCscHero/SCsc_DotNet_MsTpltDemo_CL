/*
【先决知识点】
1.设计模式：工厂；
2.集合：字典；
3.反射；
4.特性；
5.递归；

【IOC】控制反转，结合工厂设计模式创建对象。
【容器】集合List Set字典。
【IOC容器】
工厂创建对象后存储到集合中。
【基本功能】
1.创建对象；
2.存储对象；
3.DI（依赖注入），对象属性赋值；
【高级功能TODO】
4.AOP面向切面编程，对象的代理；
5.生命周期，即对象存在的作用域，Scope，Transient，单例
 */


using SCsc_DesignPattern.IOC.Entity.exp1;
using SCsc_DesignPattern.IOC;


DefaultIOCFactory defaultIOCFactory = new DefaultIOCFactory();
Student student = (Student)defaultIOCFactory.GetObject("SCsc_DesignPattern.IOC.Entity.exp1.Student");
student.Study();

Console.WriteLine("Demo Done");