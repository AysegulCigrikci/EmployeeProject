using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        //İş katmanı kontroller sağlanır

        IEmployeeDal _employeeDal;

        //constractor

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void EmployeeAdd(Employee employee)
        {
            _employeeDal.Insert(employee);
        }

        public void EmployeeDelete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public void EmployeeUpdate(Employee employee)
        {
            _employeeDal.Update(employee);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetByID(id);
        }

        public List<Employee> GetList()
        {
            return _employeeDal.GetListAll();
        }

        public List<Employee> GetEmployeeByID(int id)
        {
            return _employeeDal.GetListAll(x => x.EmployeeID == id);
        }

    }
}
