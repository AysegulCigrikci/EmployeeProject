using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmployeeRepository : IEmployeeDal
    {
        Context c = new Context();
        //CRUD işlemleri için db tarafı
        public void Delete(Employee t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public Employee GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetListAll(Expression<Func<Employee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee t)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
