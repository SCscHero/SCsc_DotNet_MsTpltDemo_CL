using SCsc_DesignPattern.IOC._Attribute;

namespace SCsc_DesignPattern.IOC.Entity.exp1
{
    /// <summary>
    /// 老师
    /// </summary>
    [IOCService]
    class Teacher
    {
        public School school { set; get; }
        public void Classes()
        {
            school.Print();
        }
    }
}
