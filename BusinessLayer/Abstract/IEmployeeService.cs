using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEmployeeService
    {
        void EmployeeAdd(Employee employee);
        void EmployeeDelete(Employee employee);
        void EmployeeUpdate(Employee employee);
        List<Employee> GetList();
        Employee GetById(int id);
        List<Employee> GetEmployeeByID(int id);
    }
}
