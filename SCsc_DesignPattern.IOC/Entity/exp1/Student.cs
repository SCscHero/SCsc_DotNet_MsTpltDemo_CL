using SCsc_DesignPattern.IOC._Attribute;

namespace SCsc_DesignPattern.IOC.Entity.exp1
{
    /// <summary>
    /// 学生类
    /// </summary>
    [IOCService]
    class Student
    {
        [IOCInject]
        public Teacher teacher { set; get; }

        public void Study()
        {
            teacher.Classes();
            Console.WriteLine("学生开始学习");
        }
    }
}
