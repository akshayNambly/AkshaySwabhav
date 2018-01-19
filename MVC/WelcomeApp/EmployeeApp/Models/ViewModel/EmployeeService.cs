using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApp.Models.ViewModel
{
    public class EmployeeService
    {
        private static List<Employee> EmpList = new List<Employee>()
        {
            new Employee() { EmpID = System.Guid.NewGuid ().ToString(), EmpName = "Akshay", HireDate = "17th July 2017", Salary = 21500 },
            new Employee() { EmpID = System.Guid.NewGuid ().ToString(), EmpName = "Raj", HireDate = "17th July 2017", Salary = 21500 },
            new Employee() { EmpID = System.Guid.NewGuid ().ToString(), EmpName = "Suraj", HireDate = "17th June 2016", Salary = 27500 },
            new Employee() { EmpID = System.Guid.NewGuid ().ToString(), EmpName = "Yadnnyesh", HireDate = "3rd May 2016", Salary = 28500 },
            new Employee() { EmpID = System.Guid.NewGuid ().ToString(), EmpName = "Mayur", HireDate = "5th May 2015", Salary = 41500 }
        };
        public List<Employee> GetList()
        {
            return EmpList;
        }
        public Employee GetEmployeeByID(string ID)
        {
            return EmpList.Find( e => e.EmpID == ID);
        }
        public void EditEmployee(Employee emp)
        {
            foreach(var employee in EmpList.Where( e => e.EmpID.Equals(emp.EmpID)))
            {
                employee.EmpName = emp.EmpName;
                employee.Salary = emp.Salary;
                employee.HireDate = emp.HireDate;
            }
            
        }
        public void DeleteEmployee(string id)
        {
            var temp=EmpList.Find(e => e.EmpID.Equals(id));
            EmpList.Remove(temp);
        }
        public void AddEmployee(Employee employee)
        {
            employee.EmpID = System.Guid.NewGuid().ToString();
            EmpList.Add(employee);
        }
        public List<Employee> SearchEmployee(Predicate<Employee> search)
        {
            return EmpList.FindAll(search);
        }
    }

}