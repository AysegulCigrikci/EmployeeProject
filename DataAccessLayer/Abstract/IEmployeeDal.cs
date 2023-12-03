using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEmployeeDal:IGenericDal<Employee>
    {
        //IGenericDaldan miras yolu ile methodları alıyoruz
        //Sadece genericDal da işlem yapıldıgında diger hepsine eklenecek. 
       
    }
}
