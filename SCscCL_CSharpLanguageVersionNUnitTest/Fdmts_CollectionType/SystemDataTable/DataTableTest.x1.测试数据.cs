using System.Collections.Generic;
using System;
using System.Data;

namespace CsLangVersion.Fdmts_CollectionType.SystemDataTable {
  //PE：用C#给我构建一个职员的Datatable，编写几个类型，有int类型，string类型和Datetime类型。并插入50条数据左右给我。主要数据要仿真，接近真实的数据，并且string类型的列/Datetime类型的列要有一定的重复。INT列为唯一ID；
  public partial class DataTableTest {
    public DataTable employeeDt = GetEmployeeDt50();
    public static DataTable GetEmployeeDt50() {
      // 创建一个DataTable  
      DataTable employeeTable = new DataTable("Employees");

      // 添加列  
      employeeTable.Columns.Add("ID", typeof(int));
      employeeTable.Columns.Add("Name", typeof(string));
      employeeTable.Columns.Add("Department", typeof(string));
      employeeTable.Columns.Add("JoinDate", typeof(DateTime));

      // 设置ID列为PrimaryKey以确保唯一性  
      employeeTable.PrimaryKey=new DataColumn[] { employeeTable.Columns["ID"] };

      // 预定义的数据集  
      List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Hannah" };
      List<string> departments = new List<string> { "IT", "HR", "Finance", "Marketing" };
      List<DateTime> dates = new List<DateTime>
      {
                new DateTime(2020, 1, 1),
                new DateTime(2021, 3, 15),
                new DateTime(2022, 7, 4),
                new DateTime(2023, 10, 28)
            };

      // 生成唯一ID的方法（这里简单使用递增的ID，但在实际应用中可能需要更复杂的逻辑）  
      int currentId = 1;

      // 插入数据  
      Random random = new Random();
      for(int i = 0; i<50; i++) {
        // 随机选择名称和部门  
        int nameIndex = random.Next(names.Count);
        int departmentIndex = random.Next(departments.Count);

        // 随机选择加入日期（为了重复，我们可以根据i的值来决定是否选择相同的日期）  
        DateTime joinDate = dates[i%dates.Count]; // 这样会导致日期有一定的重复  

        // 插入新行  
        employeeTable.Rows.Add(currentId++, names[nameIndex], departments[departmentIndex], joinDate);
      }

      // 输出DataTable的内容以验证  
      foreach(DataRow row in employeeTable.Rows) {
        Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}, Department: {row["Department"]}, JoinDate: {row["JoinDate"]}");
      }
      return employeeTable;
    }
  }
}
